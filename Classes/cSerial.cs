using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;

namespace BLEScanner.Classes
{
    class cSerial
    {
        

        public cSerial()
        {
        }

        public string RcvLog = null;
        public bool RcvMsg = false;

        public void ShowSerialLog(RichTextBox rtxtLog)
        {
            rtxtLog.AppendText(RcvLog);
            RcvLog = "";
        }


    }

    public static class SerialBase
    {
        public static SerialPort Serial_API;
        public static string PorName = "";

        public static void Conn_Serial(int speed)
        {
            Serial_API = new SerialPort("COM1", speed, Parity.None, 8, StopBits.One);

            Serial_API.Handshake = Handshake.RequestToSend;
        }
    }


}
