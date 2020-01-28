using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kenvix.ClipboardSync.UI
{
    public partial class MessageForm : Form
    {
        public MessageForm(string message)
        {
            InitializeComponent();
            MessageTextBox.Text = message;
            this.Text += DateTime.Now.ToLongTimeString();
        }
    }
}
