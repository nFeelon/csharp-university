class Program
{
    public static void Main(string[] args)
    {
        FNVLog log = new FNVLog();
        log.WriteLog("Начало работы с классами");
        log.WriteLog("Проверка класса FNVDiskInfo");
        log.WriteLog("Проверка класса FNVFileInfo");
        Console.WriteLine(log.ReadLog());
        List<string> matches = log.SearchLog("Проверка");
        foreach (string match in matches)
            Console.WriteLine(match);

        FNVDiskInfo disk = new FNVDiskInfo();
        long freeSpace = disk.GetFreeSpace("C:");
        Console.WriteLine($"\nСвободное место на диске C: {freeSpace} байт");
        string fileSystem = disk.GetFileSystem("C:");
        Console.WriteLine($"Файловая система диска C: {fileSystem}");
        disk.GetDiskInfo();

        FNVFileManager manager = new FNVFileManager();
        manager.ReadDisk("D:\\Программирование\\2 sem\\lab12\\lab12\\bin\\Debug\\net7.0");
        manager.CopyFiles("FNVInspect", "FNVTest", "txt");
        manager.ArchiveFiles("FNVTest", "FNVExtract");

        FNVFileInfo file = new FNVFileInfo();
        string fullPath = file.GetFullPath("FNVInspect/fnvdirinfo_copy.txt");
        Console.WriteLine($"Полный путь к файлу fnvdirinfo_copy.txt: {fullPath}");
        long size = file.GetSize("FNVInspect/fnvdirinfo_copy.txt");
        Console.WriteLine($"Размер файла fnvdirinfo_copy.txt: {size} байт");
        string extension = file.GetExtension("FNVInspect/fnvdirinfo_copy.txt");
        Console.WriteLine($"Расширение файла fnvdirinfo_copy.txt: {extension}");
        string name = file.GetName("FNVInspect/fnvdirinfo_copy.txt");
        Console.WriteLine($"Имя файла fnvdirinfo_copy.txt: {name}");
        DateTime creationDate = file.GetCreationDate("FNVInspect/fnvdirinfo_copy.txt");
        Console.WriteLine($"Дата создания файла fnvdirinfo_copy.txt: {creationDate}");
        DateTime modificationDate = file.GetModificationDate("FNVInspect/fnvdirinfo_copy.txt");
        Console.WriteLine($"Дата изменения файла fnvdirinfo_copy.txt: {modificationDate}");

        FNVDirInfo dir = new FNVDirInfo();
        int fileCount = dir.GetFileCount("FNVInspect");
        Console.WriteLine($"\nКоличество файлов в папке FNVInspect: {fileCount}");
        DateTime creationTime = dir.GetCreationTime("FNVInspect");
        Console.WriteLine($"Время создания папки FNVInspect: {creationTime}");
        int subdirCount = dir.GetSubdirCount("FNVInspect");
        Console.WriteLine($"Количество подпапок в папке FNVInspect: {subdirCount}");
        List<string> parentDirs = dir.GetParentDirs("FNVInspect");
        Console.WriteLine($"Список родительских папок папки FNVInspect:");
        foreach (string parentDir in parentDirs)
            Console.Write(parentDir + " - ");

    }
}