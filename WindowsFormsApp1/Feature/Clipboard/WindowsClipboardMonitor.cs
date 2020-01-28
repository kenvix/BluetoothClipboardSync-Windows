using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Kenvix.ClipboardSync.Feature.Clipboard;

namespace Kenvix.ClipboardSync.Feature.Clipboard
{
    public class WindowsClipboardMonitor : ClipboardMonitor
    {
        private ClipboardHandler handler;
        private Thread thread = null;

        class MonitorCore : Form
        {
            private IntPtr nextClipboardViewer;
            private ClipboardHandler handler;

            public MonitorCore(ClipboardHandler handler)
            {
                nextClipboardViewer = (IntPtr)SetClipboardViewer((int)Handle);
                this.handler = handler;
            }

            /// <summary>
            /// 要处理的 WindowsSystem.Windows.Forms.Message。
            /// </summary>
            /// <param name="m"></param>
            protected override void WndProc(ref Message m)
            {
                // defined in winuser.h
                const int WM_DRAWCLIPBOARD = 0x308;
                const int WM_CHANGECBCHAIN = 0x030D;

                switch (m.Msg)
                {
                    case WM_DRAWCLIPBOARD:
                        DisplayClipboardData();
                        SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                        break;
                    case WM_CHANGECBCHAIN:
                        if (m.WParam == nextClipboardViewer)
                            nextClipboardViewer = m.LParam;
                        else
                            SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                        break;
                    default:
                        base.WndProc(ref m);
                        break;
                }
            }

            /// <summary>
            /// 显示剪贴板内容
            /// </summary>
            public void DisplayClipboardData()
            {
                try
                {
                    IDataObject iData = new DataObject();
                    iData = System.Windows.Forms.Clipboard.GetDataObject();

                    if (iData.GetDataPresent(DataFormats.Rtf))
                        handler?.OnClipboardChanged(iData.GetData(DataFormats.Rtf).ToString());
                    else if (iData.GetDataPresent(DataFormats.Text))
                        handler?.OnClipboardChanged(iData.GetData(DataFormats.Text).ToString());
                }
                catch (Exception e)
                {
                    handler?.OnClipboardExceptionThrown(e);
                }
            }

            public void Stop()
            {
                ChangeClipboardChain(Handle, nextClipboardViewer);
            }

            #region WindowsAPI
            /// <summary>
            /// 将CWnd加入一个窗口链，每当剪贴板的内容发生变化时，就会通知这些窗口
            /// </summary>
            /// <param name="hWndNewViewer">句柄</param>
            /// <returns>返回剪贴板观察器链中下一个窗口的句柄</returns>
            [DllImport("User32.dll")]
            protected static extern int SetClipboardViewer(int hWndNewViewer);

            /// <summary>
            /// 从剪贴板链中移出的窗口句柄
            /// </summary>
            /// <param name="hWndRemove">从剪贴板链中移出的窗口句柄</param>
            /// <param name="hWndNewNext">hWndRemove的下一个在剪贴板链中的窗口句柄</param>
            /// <returns>如果成功，非零;否则为0。</returns>
            [DllImport("User32.dll", CharSet = CharSet.Auto)]
            public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

            /// <summary>
            /// 将指定的消息发送到一个或多个窗口
            /// </summary>
            /// <param name="hwnd">其窗口程序将接收消息的窗口的句柄</param>
            /// <param name="wMsg">指定被发送的消息</param>
            /// <param name="wParam">指定附加的消息特定信息</param>
            /// <param name="lParam">指定附加的消息特定信息</param>
            /// <returns>消息处理的结果</returns>
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
            #endregion

            protected override void SetVisibleCore(bool value)
            {
                base.SetVisibleCore(false);
            }
        }

        public WindowsClipboardMonitor(ClipboardHandler handler)
        {
            this.handler = handler;
        }

        public void StartMonitor()
        {
            thread = new Thread(() => Application.Run(new MonitorCore(handler)));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        /// <summary>
        /// 关闭程序，从观察链移除
        /// </summary>
        public void StopMonitor()
        {
            if (thread != null && thread.IsAlive)
                thread.Abort();
        }
    }

}
