using System.Collections.Generic;
using System.IO;
using System;

public class MFProfile : IEquatable<MFProfile> {
    public List<MFSave> saves;
    public MFGame game { get; set; }
    private string _path;
    public string name
    {
        get
        {
            return Path.GetFileName(_path);
        }
    }

    public bool canLoadSave
    {
        get
        {
            return !String.IsNullOrWhiteSpace(game.saveFolderPath) && saves.Count > 0;
        }
    }

    public string path
    {
        get
        {
            return _path;
        }
    }

    public string parentDirectory
    {
        get
        {
            if (!String.IsNullOrWhiteSpace(path))
            {
                return Directory.GetParent(path).FullName;
            }
            return null;
        }
    }

    /// <summary>
    /// Loads all the saves for a profile (Valid folders in the path)
    /// </summary>
    public void LoadSaves()
    {
        if (Directory.Exists(path))
        {
            //TODO catch exceptions
            saves.Clear();
            List<string> dirs = new List<string>(Directory.EnumerateDirectories(path));
            foreach (string dir in dirs)
            {
                if (IsPathAValidBackup(dir))
                {
                    MFSave save = new MFSave(dir);
                    save.profile = this;
                    saves.Add(save);
                }
            }
        }
    }

    public bool Delete()
    {
        if (Directory.Exists(path))
        {
            try
            {
                Directory.Delete(path, true);
                return true;
            }
            catch (Exception e)
            {
                // TODO catch specific exceptions
                Console.WriteLine("ERROR WHEN DELETING!" + e.Message);
                return false;
            }
        }
        else
        {
            return true;
        }
    }

    public string[] GetAllSaveFileNames()
    {
        string[] names = new string[saves.Count];
        for (int i = 0; i < saves.Count; i++)
        {
            names[i] = saves[i].name;
        }
        return names;
    }

    /// <summary>
    /// Copies the save from a certain path into the profile with a default name
    /// </summary>
    public MFSave BackupSaveFromPath(string savePath)
    {
        // TODO maybe this can have an error?
        string saveName = MFSave.GetDefaultNameForSaveInFolder(path);
        MFFileSystem.CopyDirectory(savePath, saveName);
        MFSave save = new MFSave(saveName);
        saves.Add(save);
        return save;
    }

    public bool RenameTo(string newName)
    {
        string parent = parentDirectory;
        if (parentDirectory != null)
        {
            string newPath = Path.Combine(parent, newName);
            if (!Directory.Exists(newPath))
            {
                //TODO catch exceptions
                Directory.Move(path, newPath);
                _path = newPath;
                return true;
            }
        }
        return false;
    }

    public bool LoadSave(MFSave save)
    {
        return save != null && Directory.Exists(game.saveFolderPath) && save.LoadToPath(game.saveFolderPath);
    }

    public bool LoadSaveWithName(string saveName)
    {
        return LoadSave(SaveWithName(saveName));
    }

    public MFSave SaveWithName(string saveName)
    {
        foreach(MFSave save in saves)
        {
            if (save.name.Equals(saveName))
            {
                return save;
            }
        }
        return null;
    }

    public bool RemoveSaveAtIndex(int index)
    {
        if (index >= 0 && index < saves.Count)
        {
            MFSave save = saves[index];
            if (save.Delete())
            {
                saves.RemoveAt(index);
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// checks if save has the same structure as the save file in the game
    /// </summary>
    public bool IsPathAValidBackup(string path)
    {
        return game != null && game.IsPathAValidBackup(path);
    }

    /// <summary>
    /// sets the path for the profile if it can be a valid path, and returns wheter or not it was set
    /// </summary>
    public bool SetPath(string path)
    {
        try
        {
            Path.GetFullPath(path);
            if (_path == null && !Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            _path = path;
            LoadSaves();
        }
        catch (NotSupportedException e)
        {
            return false;
        }
        catch (ArgumentException e)
        {
            return false;
        }
        return true;
    }

    public MFProfile()
    {
        this.saves = new List<MFSave>();
    }

    public MFProfile(string path) : this()
    {
        this.SetPath(path);
    }

    public MFProfile(string path, MFGame game) : this(path)
    {
        this.game = game;
    }

    public override string ToString()
    {
        return String.Format("(Name: {0}, Saves: {1})", name, String.Join(", ", saves));
    }

    public bool Equals(MFProfile other)
    {
        return other.path.Equals(path);
    }
}
