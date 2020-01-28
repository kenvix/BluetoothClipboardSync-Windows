using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kenvix.ClipboardSync.Feature.Clipboard
{
    public interface ClipboardHandler
    {
        void OnClipboardChanged(String text);
        void OnClipboardExceptionThrown(Exception e);
    }
}
