using System;
using System.Windows.Forms;

namespace RootFolderMonitor
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            string rootFolder = @"C:\YourRootFolder"; // Replace with your root folder path

            // Start clipboard and file system monitoring
            ClipboardMonitor clipboardMonitor = new ClipboardMonitor(rootFolder);
            FileSystemMonitor fileSystemMonitor = new FileSystemMonitor(rootFolder);

            Application.Run(clipboardMonitor);
        }
    }
}
