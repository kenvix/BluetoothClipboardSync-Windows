using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kenvix.ClipboardSync.Feature.Clipboard
{
    public interface ClipboardMonitor
    {
        void StartMonitor();
        void StopMonitor();
    }
}
