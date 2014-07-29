namespace MouseClickWithAccelerometer
{
    partial class ControllerView
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
            this.components = new System.ComponentModel.Container();
            this.mySerialPort = new System.IO.Ports.SerialPort(this.components);
            this.btConnection = new System.Windows.Forms.Button();
            this.cbPortName = new System.Windows.Forms.ComboBox();
            this.rtbInfo = new System.Windows.Forms.RichTextBox();
            this.lbPortName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mySerialPort
            // 
            this.mySerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.mySerialPort_DataReceived);
            // 
            // btConnection
            // 
            this.btConnection.Location = new System.Drawing.Point(244, 12);
            this.btConnection.Name = "btConnection";
            this.btConnection.Size = new System.Drawing.Size(75, 35);
            this.btConnection.TabIndex = 0;
            this.btConnection.Text = "Start Connection";
            this.btConnection.UseVisualStyleBackColor = true;
            this.btConnection.Click += new System.EventHandler(this.btConnection_Click);
            // 
            // cbPortName
            // 
            this.cbPortName.FormattingEnabled = true;
            this.cbPortName.Location = new System.Drawing.Point(77, 12);
            this.cbPortName.Name = "cbPortName";
            this.cbPortName.Size = new System.Drawing.Size(147, 21);
            this.cbPortName.TabIndex = 1;
            // 
            // rtbInfo
            // 
            this.rtbInfo.Location = new System.Drawing.Point(15, 59);
            this.rtbInfo.Name = "rtbInfo";
            this.rtbInfo.Size = new System.Drawing.Size(209, 96);
            this.rtbInfo.TabIndex = 2;
            this.rtbInfo.Text = "";
            // 
            // lbPortName
            // 
            this.lbPortName.AutoSize = true;
            this.lbPortName.Location = new System.Drawing.Point(12, 15);
            this.lbPortName.Name = "lbPortName";
            this.lbPortName.Size = new System.Drawing.Size(60, 13);
            this.lbPortName.TabIndex = 3;
            this.lbPortName.Text = "Port Name:";
            // 
            // ControllerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 185);
            this.Controls.Add(this.lbPortName);
            this.Controls.Add(this.rtbInfo);
            this.Controls.Add(this.cbPortName);
            this.Controls.Add(this.btConnection);
            this.Name = "ControllerView";
            this.Text = "Mouse Click with Accelerometer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort mySerialPort;
        private System.Windows.Forms.Button btConnection;
        private System.Windows.Forms.ComboBox cbPortName;
        private System.Windows.Forms.RichTextBox rtbInfo;
        private System.Windows.Forms.Label lbPortName;
    }
}

