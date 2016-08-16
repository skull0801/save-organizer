using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

public class MFGame {
    private string _saveFolderPath;
    private string _backupsFolderPath;

    public bool canBackup
    {
        get
        {
            return currentProfile != null && !String.IsNullOrWhiteSpace(saveFolderPath) && !String.IsNullOrWhiteSpace(backupsFolderPath);
        }
    }

    public string name { get; set; }
    private int _currentProfileIndex;
    [XmlIgnore] public int currentProfileIndex
    {
        get
        {
            return _currentProfileIndex;
        }
        set
        {
            if (value >= 0 && value < profiles.Count)
            {
                _currentProfileIndex = value;
            }
        }
    }
    [XmlIgnore] public MFProfile currentProfile
    {
        get
        {
            if (_currentProfileIndex != -1)
            {
                return profiles[currentProfileIndex];
            }
            return null;
        }
    }
    [XmlIgnore] public List<MFProfile> profiles;
    public string saveFolderName
    {
        get {return Path.GetFileName(saveFolderPath);}
    }

    public MFGame()
    {
        profiles = new List<MFProfile>();
        _currentProfileIndex = -1;
    }

    public MFGame(string name) : this()
    {
        this.name = name;
    }

    public MFGame(string name, string saveFolderPath, string backupsFolderPath) : this(name)
    {
        this.saveFolderPath = saveFolderPath;
        this.backupsFolderPath = backupsFolderPath;
    }

    public string[] GetAllProfileNames()
    {
        string[] names = new string[profiles.Count];
        for (int i = 0; i < profiles.Count; i++)
        {
            names[i] = profiles[i].name;
        }
        return names;
    }

    /// <summary>
    /// gets the current save and adds it to the current profile
    /// </summary>
    public MFSave BackupCurrentSave()
    {
        if (canBackup)
        {
            return currentProfile.BackupSaveFromPath(saveFolderPath);
        }
        return null;
    }

    /// <summary>
    /// Adds profile to profiles in a game, returns wheter or not it could be added
    /// </summary>
    public bool AddProfile(MFProfile profile)
    {
        if (!Contains(profile))
        {
            profiles.Add(profile);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool RemoveProfileAtIndex(int index)
    {
        if (index >= 0 && index < profiles.Count)
        {
            MFProfile profile = profiles[index];
            if (profile.Delete())
            {
                profiles.RemoveAt(index);
                if (_currentProfileIndex >= profiles.Count)
                {
                    _currentProfileIndex = profiles.Count - 1;
                }
                return true;
            }
        }
        return false;
    }

    public bool RemoveProfile(MFProfile profile)
    {
        return RemoveProfileAtIndex(profiles.IndexOf(profile));
    }

    public bool Contains(MFProfile profile)
    {
        return profiles.Contains(profile);
    }

    /// <summary>
    /// Loads all the profiles for the game (folders in the backups path)
    /// </summary>
    public void LoadProfiles()
    {
        profiles.Clear();
        if (backupsFolderPath != null)
        {
            //TODO catch exceptions
            List<string> dirs = new List<string>(Directory.EnumerateDirectories(backupsFolderPath));
            foreach(string dir in dirs)
            {
                MFProfile profile = new MFProfile(dir);
                profile.game = this;
                profile.LoadSaves();
                AddProfile(profile);
            }
            if (_currentProfileIndex < 0)
            {
                if (profiles.Count > 0)
                {
                    _currentProfileIndex = 0;
                    Console.WriteLine("SET TO 0");
                }
            }
            else if (_currentProfileIndex >= profiles.Count)
            {
                _currentProfileIndex = -1;
                Console.WriteLine("SET TO -1");
            }
        }
    }

    public MFProfile ProfileWithName(string name)
    {
        foreach(MFProfile profile in profiles)
        {
            if (profile.name.Equals(name))
            {
                return profile;
            }
        }
        return null;
    }

    /// <summary>
    /// checks if the path has the same structure as the save file for that game
    /// </summary>
    public bool IsPathAValidBackup(string path)
    {
        // TODO check if it has the same structure as the save file
        return true;
    }

    public override string ToString()
    {
        return String.Format("Name: {0}, Save Path: {1}, Backup Path: {2}, Profiles: {3}", name, saveFolderPath, backupsFolderPath, string.Join(", ", profiles));
    }

    public string backupsFolderPath
    {
        get
        {
            return _backupsFolderPath;
        }
        set
        {
            _backupsFolderPath = value;
        }
    }

    public string saveFolderPath
    {
        get
        {
            return _saveFolderPath;
        }
        set
        {
            _saveFolderPath = value;
        }
    }

}
