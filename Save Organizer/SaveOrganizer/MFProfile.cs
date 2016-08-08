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

    public string path
    {
        get
        {
            return _path;
        }
    }

    /// <summary>
    /// Loads all the saves for a profile (Valid folders in the path)
    /// </summary>
    public void LoadSaves()
    {
        if (path != null)
        {
            //TODO catch exceptions
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

    
    /// <summary>
    /// Copies the save from a certain path into the profile with a default name
    /// </summary>
    public void BackupSaveFromPath(string savePath)
    {
        string saveName = MFSave.GetDefaultNameForSaveInFolder(path);
        MFFileSystem.CopyDirectory(savePath, saveName);
        MFSave save = new MFSave(saveName);
        saves.Add(save);
    }

    public bool LoadSave(MFSave save)
    {
        return save != null && save.LoadToPath(game.saveFolderPath);
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

    public MFProfile(string path)
    {
        this.saves = new List<MFSave>();
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
