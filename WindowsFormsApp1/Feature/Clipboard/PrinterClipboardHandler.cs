using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kenvix.ClipboardSync.Feature.Clipboard
{
    public class PrinterClipboardHandler : ClipboardHandler
    {
        public void OnClipboardChanged(string text)
        {
            Console.WriteLine("Clipboard update: " + text);
        }

        public void OnClipboardExceptionThrown(Exception e)
        {
            Console.Error.WriteLine(e.ToString());
        }
    }
}
