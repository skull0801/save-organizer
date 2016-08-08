using System.IO;
using System;

public class MFSave {
    public static readonly string DEFAULT_SAVE_NAME = "save ";

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
        try
        {
            Path.GetFullPath(path);
            if (Directory.Exists(path))
            {
                _path = path;
                return true;
            }
        }
        catch (NotSupportedException e) {}
        catch (ArgumentException e) {}
        return false;
    }

    public static string GetDefaultNameForSaveInFolder(string folder)
    {
        long counter = 0;
        string name;
        do
        {
            counter++;
            name = Path.Combine(folder, MFSave.DEFAULT_SAVE_NAME + counter.ToString());
        } while (Directory.Exists(name));
        return name;
    }

    public override string ToString()
    {
        return name;
    }

}
