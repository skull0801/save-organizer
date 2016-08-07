using System;

class MFGame {
    public string name {get; set; }
    public MFProfile[] profiles;
    public string saveFolderPath { get; set;}
    public string backupsFolderPath { get; set;}
    public string saveFolderName
    {
        get {return System.IO.Path.GetDirectoryName(saveFolderPath);}
    }

}
