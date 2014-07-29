using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Runtime.InteropServices;

namespace MouseClickWithAccelerometer
{
    public partial class ControllerView : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        ControllerModel cm;
        bool hasCoonnected = false;
        string RxString;

        public ControllerView()
        {
            InitializeComponent();
            var ports = SerialPort.GetPortNames();
            cbPortName.DataSource = ports;
        }

        private void mySerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            RxString = mySerialPort.ReadExisting();
            this.Invoke(new EventHandler(ProcessData));
        }


        private void ProcessData(object sender, EventArgs e)
        {
            rtbInfo.AppendText(RxString);
            this.Invoke(new EventHandler(ProcessClick));
        }

        private void ProcessClick(object sender, EventArgs e)
        {
            cm.doMouseClick();
        }


        private void btConnection_Click(object sender, EventArgs e)
        {
            if (!hasCoonnected)
            {
                try
                {
                    mySerialPort.PortName = cbPortName.SelectedItem.ToString();
                    mySerialPort.BaudRate = 9600;
                    mySerialPort.Open();
                    cm = new ControllerModel();
                    cbPortName.Enabled = false;
                    btConnection.Text = "Close Connection";
                    hasCoonnected = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                try
                {
                    mySerialPort.Close();
                    cbPortName.Enabled = true;
                    btConnection.Text = "Start Connection";
                    hasCoonnected = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
            }

        }

    }
}
