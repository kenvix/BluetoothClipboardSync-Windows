namespace Kenvix.ClipboardSync.UI
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SelectBluetoothDeviceDialog = new InTheHand.Windows.Forms.SelectBluetoothDeviceDialog();
            this.SelectDeviceButton = new System.Windows.Forms.Button();
            this.DeviceDescLabel = new System.Windows.Forms.Label();
            this.DeviceLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.MinGzipCompressSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SelectBluetoothDeviceDialog
            // 
            this.SelectBluetoothDeviceDialog.AddNewDeviceWizard = false;
            this.SelectBluetoothDeviceDialog.DeviceFilter = null;
            this.SelectBluetoothDeviceDialog.DiscoverableOnly = false;
            this.SelectBluetoothDeviceDialog.ForceAuthentication = false;
            this.SelectBluetoothDeviceDialog.Info = null;
            this.SelectBluetoothDeviceDialog.ShowAuthenticated = true;
            this.SelectBluetoothDeviceDialog.ShowDiscoverableOnly = false;
            this.SelectBluetoothDeviceDialog.ShowRemembered = true;
            this.SelectBluetoothDeviceDialog.ShowUnknown = false;
            this.SelectBluetoothDeviceDialog.SkipServicesPage = false;
            // 
            // SelectDeviceButton
            // 
            this.SelectDeviceButton.Location = new System.Drawing.Point(125, 9);
            this.SelectDeviceButton.Name = "SelectDeviceButton";
            this.SelectDeviceButton.Size = new System.Drawing.Size(145, 31);
            this.SelectDeviceButton.TabIndex = 0;
            this.SelectDeviceButton.Text = "选择设备 ... (&S)";
            this.SelectDeviceButton.UseVisualStyleBackColor = true;
            this.SelectDeviceButton.Click += new System.EventHandler(this.SelectDeviceButton_Click);
            // 
            // DeviceDescLabel
            // 
            this.DeviceDescLabel.AutoSize = true;
            this.DeviceDescLabel.Location = new System.Drawing.Point(12, 17);
            this.DeviceDescLabel.Name = "DeviceDescLabel";
            this.DeviceDescLabel.Size = new System.Drawing.Size(97, 15);
            this.DeviceDescLabel.TabIndex = 1;
            this.DeviceDescLabel.Text = "同步目标设备";
            // 
            // DeviceLabel
            // 
            this.DeviceLabel.AutoSize = true;
            this.DeviceLabel.Location = new System.Drawing.Point(294, 17);
            this.DeviceLabel.Name = "DeviceLabel";
            this.DeviceLabel.Size = new System.Drawing.Size(112, 15);
            this.DeviceLabel.TabIndex = 2;
            this.DeviceLabel.Text = "未选择任何设备";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(15, 209);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(175, 36);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "保存设置 (&O)";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "压缩数据的最小数据大小 (字节)";
            // 
            // MinGzipCompressSize
            // 
            this.MinGzipCompressSize.Location = new System.Drawing.Point(274, 50);
            this.MinGzipCompressSize.Name = "MinGzipCompressSize";
            this.MinGzipCompressSize.Size = new System.Drawing.Size(132, 25);
            this.MinGzipCompressSize.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(431, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(352, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "压缩可以提高传输速度，但是设置太小则会降低效率";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 267);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MinGzipCompressSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.DeviceLabel);
            this.Controls.Add(this.DeviceDescLabel);
            this.Controls.Add(this.SelectDeviceButton);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private InTheHand.Windows.Forms.SelectBluetoothDeviceDialog SelectBluetoothDeviceDialog;
        private System.Windows.Forms.Button SelectDeviceButton;
        private System.Windows.Forms.Label DeviceDescLabel;
        private System.Windows.Forms.Label DeviceLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MinGzipCompressSize;
        private System.Windows.Forms.Label label2;
    }
}