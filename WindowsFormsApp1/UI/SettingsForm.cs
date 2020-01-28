using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Windows.Forms;
using Kenvix.ClipboardSync.Preferences;

namespace Kenvix.ClipboardSync.UI
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            MinGzipCompressSize.Text = MainPreferences.Default.MinGzipCompressSize.ToString();

            if (MainPreferences.Default.DeviceAddress.Length > 1)
            {
                UpdateDeviceDisplay(MainPreferences.Default.DeviceName, MainPreferences.Default.DeviceAddress);
            }
        }

        private void SelectDeviceButton_Click(object sender, EventArgs e)
        {
            try
            {
                var result = SelectBluetoothDeviceDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var device = SelectBluetoothDeviceDialog.SelectedDevice;

                    if (!device.Authenticated)
                        throw new AuthenticationException("设备未认证或不支持，请先打开系统设置，与设备配对并认证后再选择。");

                    UpdateDeviceDisplay(device.DeviceName, device.DeviceAddress.ToString());

                    MainPreferences.Default.DeviceName = device.DeviceName;
                    MainPreferences.Default.DeviceAddress = device.DeviceAddress.ToString();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDeviceDisplay(string name, string address)
        {
            DeviceLabel.Text = name + " (" + address + ")";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            MainPreferences.Default.MinGzipCompressSize = Int32.Parse(MinGzipCompressSize.Text);
            MainPreferences.Default.Save();
        }
    }
}
