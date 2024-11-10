using System;
using System.Windows.Forms;
using System.IO;

public class ClipboardMonitor : Form
{
    private string rootFolder;

    public ClipboardMonitor(string root)
    {
        rootFolder = root;
        this.Load += (s, e) => AddClipboardFormatListener(this.Handle);
    }

    protected override void WndProc(ref Message m)
    {
        const int WM_CLIPBOARDUPDATE = 0x031D;
        
        if (m.Msg == WM_CLIPBOARDUPDATE)
        {
            IDataObject iData = Clipboard.GetDataObject();
            if (iData.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])iData.GetData(DataFormats.FileDrop);
                foreach (string file in files)
                {
                    if (!file.StartsWith(rootFolder))
                    {
                        MessageBox.Show("You cannot copy files outside the root folder.");
                        Clipboard.Clear();
                        break;
                    }
                }
            }
        }
        base.WndProc(ref m);
    }

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern void AddClipboardFormatListener(IntPtr hwnd);
}
