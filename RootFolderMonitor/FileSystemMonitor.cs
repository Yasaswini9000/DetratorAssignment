using System;
using System.IO;

public class FileSystemMonitor
{
    private FileSystemWatcher watcher;
    private string rootFolder;

    public FileSystemMonitor(string root)
    {
        rootFolder = root;
        watcher = new FileSystemWatcher();
        watcher.Path = rootFolder;
        watcher.Filter = "*.*";
        watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName;
        watcher.Changed += OnChanged;
        watcher.EnableRaisingEvents = true;
    }

    private void OnChanged(object sender, FileSystemEventArgs e)
    {
        string fullPath = e.FullPath;
        if (!fullPath.StartsWith(rootFolder))
        {
            Console.WriteLine($"Unauthorized operation blocked: {fullPath}");
            // Additional logic can be added to block the operation.
        }
    }
}
