using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Kenvix.ClipboardSync.Feature.Clipboard;
using Kenvix.ClipboardSync.UI;

namespace Kenvix.ClipboardSync
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var x = new WindowsClipboardMonitor(new PrinterClipboardHandler());
            x.StartMonitor();
            Application.Run(new HostForm());
        }
    }
}
