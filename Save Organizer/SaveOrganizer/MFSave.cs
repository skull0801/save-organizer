using System.IO;
using System;

public enum MFSaveRenameResult
{
    SUCCESS = 0,
    NAME_EXISTS = 1,
    EMPTY = 2
}

public class MFSave {
    public static readonly string DEFAULT_SAVE_NAME = "save ";
    public static readonly string BACKUP_SAVE_NAME = "backUpSaveName";
    public MFProfile profile;

    public string path
    {
        get
        {
            return _path;
        }
    }

    public string name
    {
        get
        {
            return Path.GetFileName(_path);
        }
    }
    private string _path;

    public MFSave(string path)
    {
        SetPath(path);
    }

    /// <summary>
    /// sets the path for the profile if it can be a valid path, and returns wheter or not it was set
    /// </summary>
    public bool SetPath(string path)
    {
        if (MFFileSystem.IsPathValid(path) && Directory.Exists(path))
        {
            _path = path;
            return true;
        }
        return false;
    }
    
    public static string GetDefaultNameForSaveInFolder(string folder)
    {
        long counter = 0;
        string name;
        do
        {
            counter++;
            name = Path.Combine(folder, DEFAULT_SAVE_NAME + counter.ToString());
        } while (Directory.Exists(name));
        return name;
    }

    public bool Load()
    {
        return LoadToPath(profile.game.saveFolderPath);
    }

    public MFSaveRenameResult RenameTo(string name)
    {
        if (String.IsNullOrWhiteSpace(name))
        {
            return MFSaveRenameResult.EMPTY;
        }
        DirectoryInfo parentInfo = Directory.GetParent(path);
        if (parentInfo != null)
        {
            string newPath = Path.Combine(parentInfo.FullName, name);
            if (!Directory.Exists(newPath))
            {
                //TODO catch exceptions
                Directory.Move(path, newPath);
                _path = newPath;
                return MFSaveRenameResult.SUCCESS;
            }
        }
        return MFSaveRenameResult.NAME_EXISTS;
    }

    public bool Delete()
    {

        Directory.Delete(path, true);
        return true;
    }

    public bool LoadToPath(string pathToLoad)
    {
        if (Directory.Exists(pathToLoad))
        {
            MFFileSystem.MoveDirectory(pathToLoad, BACKUP_SAVE_NAME);
            MFFileSystem.CopyDirectory(path, pathToLoad);
            if (Directory.Exists(pathToLoad))
            {
                Directory.Delete(BACKUP_SAVE_NAME, true);
                return true;
            }
            else
            {
                MFFileSystem.MoveDirectory(BACKUP_SAVE_NAME, pathToLoad);
                return false;
            }
        } else
        {
            return false;
        }
    }

    public override string ToString()
    {
        return name;
    }

}
