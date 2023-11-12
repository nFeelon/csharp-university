using System.IO.Compression;

class FNVLog
{
    private string logFilePath = "fnvlogfile.txt";
    public void WriteLog(string message)
    {
        using (StreamWriter writer = new StreamWriter(logFilePath, true))
            writer.WriteLine($"{DateTime.Now}: {message}");
    }

    public string ReadLog()
    {
        using (StreamReader reader = new StreamReader(logFilePath))
            return reader.ReadToEnd();
    }

    public List<string> SearchLog(string keyword)
    {
        List<string> matches = new List<string>();
        using (StreamReader reader = new StreamReader(logFilePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
                if (line.Contains(keyword))
                    matches.Add(line);
        }
        return matches;
    }
}

class FNVDiskInfo
{
    public long GetFreeSpace(string driveName)
    {
        DriveInfo drive = new DriveInfo(driveName);
        return drive.AvailableFreeSpace;
    }

    public string GetFileSystem(string driveName)
    {
        DriveInfo drive = new DriveInfo(driveName);
        return drive.DriveFormat;
    }

    public void GetDiskInfo()
    {
        DriveInfo[] drives = DriveInfo.GetDrives();
        foreach (DriveInfo drive in drives)
        {
            Console.WriteLine($"Drive: {drive.Name}");
            Console.WriteLine($"Size: {drive.TotalSize} bytes");
            Console.WriteLine($"Available space: {drive.AvailableFreeSpace} bytes");
            Console.WriteLine($"Volume label: {drive.VolumeLabel}");
            Console.WriteLine();
        }
    }
}

class FNVFileInfo
{
    public string GetFullPath(string fileName) => Path.GetFullPath(fileName);
    public string GetExtension(string fileName) => Path.GetExtension(fileName);
    public string GetName(string fileName) => Path.GetFileName(fileName);
    public DateTime GetCreationDate(string fileName) => File.GetCreationTime(fileName);
    public DateTime GetModificationDate(string fileName) => File.GetLastWriteTime(fileName);
    public long GetSize(string fileName)
    {
        FileInfo file = new FileInfo(fileName);
        return file.Length;
    }
}

class FNVDirInfo
{
    public int GetFileCount(string dirName)
    {
        string[] files = Directory.GetFiles(dirName);
        return files.Length;
    }
    public int GetSubdirCount(string dirName)
    {
        string[] subdirs = Directory.GetDirectories(dirName);
        return subdirs.Length;
    }

    public DateTime GetCreationTime(string dirName) => Directory.GetCreationTime(dirName);

    public List<string> GetParentDirs(string dirName)
    {
        List<string> parents = new List<string>();
        DirectoryInfo dir = new DirectoryInfo(dirName);
        while (dir.Parent != null)
        {
            parents.Add(dir.Parent.Name);
            dir = dir.Parent;
        }
        return parents;
    }
}

class FNVFileManager
{
    public void ReadDisk(string driveName)
    {
        string[] files = Directory.GetFiles(driveName);
        string[] folders = Directory.GetDirectories(driveName);
        Directory.CreateDirectory("FNVInspect");
        using (StreamWriter writer = new StreamWriter("FNVInspect/fnvdirinfo.txt"))
        {
            writer.WriteLine($"Files in {driveName}:");
            foreach (string file in files)
                writer.WriteLine(file);
            writer.WriteLine();
            writer.WriteLine($"Folders in {driveName}:");
            foreach (string folder in folders)
                writer.WriteLine(folder);
        }
        File.Copy("FNVInspect/fnvdirinfo.txt", "FNVInspect/fnvdirinfo_copy.txt");
        File.Delete("FNVInspect/fnvdirinfo.txt");
    }

    public void CopyFiles(string sourceDir, string targetDir, string extension)
    {
        Directory.CreateDirectory("FNVFiles");
        string[] files = Directory.GetFiles(sourceDir, $"*.{extension}");
        foreach (string file in files)
            File.Copy(file, $"FNVFiles/{Path.GetFileName(file)}");
        Directory.Move("FNVFiles", targetDir);
    }
    public void ArchiveFiles(string sourceDir, string targetDir)
    {
        ZipFile.CreateFromDirectory(sourceDir, "FNVFiles.zip");
        ZipFile.ExtractToDirectory("FNVFiles.zip", targetDir);
    }
}

