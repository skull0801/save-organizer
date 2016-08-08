using System.IO;

public class MFFileSystem
{
    public static void CopyDirectory(string source, string dest)
    {
        DirectoryInfo dir = new DirectoryInfo(source);

        DirectoryInfo[] dirs = dir.GetDirectories();

        if (!Directory.Exists(dest))
        {
            Directory.CreateDirectory(dest);
        }

        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            string temppath = Path.Combine(dest, file.Name);
            file.CopyTo(temppath, false);
        }

        foreach (DirectoryInfo subdir in dirs)
        {
            string temppath = Path.Combine(dest, subdir.Name);
            CopyDirectory(subdir.FullName, temppath);
        }
    }
}
