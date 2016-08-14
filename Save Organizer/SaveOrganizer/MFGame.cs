using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

public class MFGame {
    private string _saveFolderPath;
    private string _backupsFolderPath;

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
    }

    public MFGame(string name) : this()
    {
        this.name = name;
    }

    public MFGame(string name, string saveFolderPath, string backupsFolderPath) : this(name)
    {
        this.saveFolderPath = saveFolderPath;
        this.backupsFolderPath = backupsFolderPath;
        LoadProfiles();
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
        if (currentProfile != null && saveFolderPath != null)
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
        if (!profiles.Contains(profile))
        {
            profiles.Add(profile);
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Loads all the profiles for the game (folders in the backups path)
    /// </summary>
    public void LoadProfiles()
    {
        if (backupsFolderPath != null)
        {
            //TODO catch exceptions
            List<string> dirs = new List<string>(Directory.EnumerateDirectories(backupsFolderPath));
            foreach(string dir in dirs)
            {
                MFProfile profile = new MFProfile(dir);
                profile.game = this;
                profile.LoadSaves();
                profiles.Add(profile);
            }
            if (_currentProfileIndex < -1 || _currentProfileIndex >= profiles.Count)
            {
                _currentProfileIndex = -1;
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
            if (Directory.Exists(value))
            {
                _backupsFolderPath = value;
                LoadProfiles();
            }
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
            if (Directory.Exists(value))
            {
                _saveFolderPath = value;
            }
        }
    }

}
