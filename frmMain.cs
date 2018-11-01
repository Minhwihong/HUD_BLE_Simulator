// Bluegiga BGLib C# interface library
// 2013-01-15 by Jeff Rowberg <jeff@rowberg.net>
// Updates should (hopefully) always be available at https://github.com/jrowberg/bglib

/* ============================================
BGLib C# interface library code is placed under the MIT license
Copyright (c) 2013 Jeff Rowberg

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
===============================================
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using BLEScanner.Classes;
using System.Threading;


namespace BLEScanner
{
    public partial class frmMain : Form
    {

        public      Bluegiga.BGLib bglib = new Bluegiga.BGLib();
        cSerial     mSerial = new cSerial();
        cBLE_Base   BLE_Base = new cBLE_Base();
        Thread      thread_BLE_Connected = null;
        public      System.IO.Ports.SerialPort serialAPI;


        string richtxtLog = null;

        public void SystemBootEvent(object sender, Bluegiga.BLE.Events.System.BootEventArgs e)
        {
            String log = String.Format("ble_evt_system_boot:" + Environment.NewLine + "\tmajor={0}, minor={1}, patch={2}, build={3}, ll_version={4}, protocol_version={5}, hw={6}" + Environment.NewLine,
                e.major,
                e.minor,
                e.patch,
                e.build,
                e.ll_version,
                e.protocol_version,
                e.hw
                );
            Console.Write(log);
            ThreadSafeDelegate(delegate 
            {
                txtLog.Text = "";
                txtLog.AppendText(log);
            });
        }



        public void GAPConnectResponseEvent(object sender, Bluegiga.BLE.Responses.GAP.ConnectDirectEventArgs e)
        {
            String log = string.Format("Result: {0}, Connection Handler: {1}\r\n", e.result,e.connection_handle);
            ThreadSafeDelegate(delegate { ProcAfterConnectResponse(log, (byte)e.result); } );
            //bglib.SendCommand(serialAPI, bglib.BLECommandGAPEndProcedure());
        }


        private void ProcAfterConnectResponse(string log, byte conn)
        {
            txtLog.AppendText(log);
            if (conn == 0)
            {
                if (thread_BLE_Connected == null)
                {
                    thread_BLE_Connected = new Thread(new ThreadStart(SBrick_Control_Thread));
                    thread_BLE_Connected.Start();
                    
                }
                

            }
            btnDisconn.Enabled = true;
        }





        //ble_evt_connection_status connection
        public void ConnectionStatusEvent(object sender, Bluegiga.BLE.Events.Connection.StatusEventArgs e)
        {
            String log = string.Format("Connection: {0}, Flags: {1}, Addr: {2}\r\n", e.connection, e.flags, e.address[0]);
            ThreadSafeDelegate(delegate { rtxtLog.Text = ""; rtxtLog.AppendText(log); });
        }




        //ble_rsp_connection_disconnect connection: 0 (0x00) result:0x0000 ['No Error']
        public void DisconnectResponse(object sender, Bluegiga.BLE.Responses.Connection.DisconnectEventArgs e)
        {

            String log = string.Format("disconn Result: {0}\r\n", e.result);
            ThreadSafeDelegate(delegate { rtxtLog.Text = ""; rtxtLog.AppendText(log); });


        }



        //ble_evt_connection_disconnected connection: 0 (0x00) reason:0x0216 ['Local device terminated the connection.']
        public void DisconnectEvent(object sender, Bluegiga.BLE.Events.Connection.DisconnectedEventArgs e)
        {
            String log = string.Format("disconn Reason: {0}\r\n", e.reason);
            ThreadSafeDelegate(delegate { rtxtLog.Text = ""; rtxtLog.AppendText(log); });

        }




        //ble_rsp_attclient_find_information connection: 0 (0x00) result:0x0000 ['No Error']
        public void AttClientFindInfoResponse(object sender, Bluegiga.BLE.Responses.ATTClient.FindInformationEventArgs e)
        {
            String log = string.Format("Result: {0}\r\n", e.result);
            ThreadSafeDelegate(delegate { rtxtLog.AppendText(log); });
        }


        public void AttClientFindInfoEvent(object sender, Bluegiga.BLE.Events.ATTClient.FindInformationFoundEventArgs e)
        {
            String log = string.Format("Connection: {0}, Character Handle: {1}, UUID: {2}\r\n", e.connection, e.chrhandle, ByteArrayToHexString(e.uuid));
            ThreadSafeDelegate(delegate 
            {
                rtxtLog.AppendText(log);
                if (e.chrhandle == 26)
                {
                    btnOpenSbrick.Enabled = true;
                }
            });
        }








        private void SBrick_Control_Thread()
        {
            
            
        }



        public void GAPScanResponseEvent(object sender, Bluegiga.BLE.Events.GAP.ScanResponseEventArgs e)
        {
            String log = String.Format("ble_evt_gap_scan_response:" + Environment.NewLine + "\trssi={0}, packet_type={1}, bd_addr=[ {2}], address_type={3}, bond={4}, data=[ {5}]" + Environment.NewLine,
                (SByte)e.rssi,
                (SByte)e.packet_type,
                ByteArrayToHexString(e.sender),
                (SByte)e.address_type,
                (SByte)e.bond,
                ByteArrayToHexString(e.data)
                );
            Console.Write(log);

            string[] BLE_Info = new string[5];
            BLE_Info[0] = e.rssi.ToString();
            BLE_Info[1] = e.packet_type.ToString();
            BLE_Info[2] = ByteArrayToHexString(e.sender);
            BLE_Info[3] = e.address_type.ToString();
            BLE_Info[4] = e.bond.ToString(); 

            ThreadSafeDelegate(delegate 
            {
                txtLog.AppendText(log);
                BLE_Base.Add_Device_to_DataTable(BLE_Info);
            } );
        }




        // Thread-safe operations from event handlers
        // I love StackOverflow: http://stackoverflow.com/q/782274
        public void ThreadSafeDelegate(MethodInvoker method)
        {
            if (InvokeRequired)
                BeginInvoke(method);
            else
                method.Invoke();
        }
        


        public frmMain()
        {
            InitializeComponent();
        }




        private void frmMain_Load(object sender, EventArgs e)
        {
            string[] Ports = SerialPort.GetPortNames();
            for (int i = 0; i < Ports.Length; i++)
                cmbComPort.Items.Add(Ports[i]);
            cmbComPort.SelectedIndex = 0;


            bglib.BLEEventSystemBoot                += new Bluegiga.BLE.Events.System.BootEventHandler(this.SystemBootEvent);
            bglib.BLEEventGAPScanResponse           += new Bluegiga.BLE.Events.GAP.ScanResponseEventHandler(this.GAPScanResponseEvent);

            bglib.BLEResponseGAPConnectDirect       += new Bluegiga.BLE.Responses.GAP.ConnectDirectEventHandler(this.GAPConnectResponseEvent);
            bglib.BLEEventConnectionStatus          += new Bluegiga.BLE.Events.Connection.StatusEventHandler(ConnectionStatusEvent);

            bglib.BLEResponseConnectionDisconnect   += new Bluegiga.BLE.Responses.Connection.DisconnectEventHandler(DisconnectResponse);
            bglib.BLEEventConnectionDisconnected    += new Bluegiga.BLE.Events.Connection.DisconnectedEventHandler(DisconnectEvent);

            bglib.BLEResponseATTClientFindInformation   += new Bluegiga.BLE.Responses.ATTClient.FindInformationEventHandler(AttClientFindInfoResponse);
            bglib.BLEEventATTClientFindInformationFound += new Bluegiga.BLE.Events.ATTClient.FindInformationFoundEventHandler(AttClientFindInfoEvent);

            BLE_Base.Bind_Grid_to_DataTable(dtGrViewBLE_Devices);

        
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (System.IO.Ports.SerialPort)sender;
            int numOfByte = sp.BytesToRead;
            Byte[] inData = new Byte[numOfByte];

            // read all available bytes from serial port in one chunk
            sp.Read(inData, 0, numOfByte);
            
            // DEBUG: display bytes read
            Console.WriteLine("<= RX ({0}) [ {1}]", inData.Length, ByteArrayToHexString(inData));

            mSerial.RcvMsg = true;
            mSerial.RcvLog = String.Format("<= RX ({0}) [ {1}]\r\n", inData.Length, ByteArrayToHexString(inData));
            
            // parse all bytes read through BGLib parser
            for (int i = 0; i < inData.Length; i++)
            {
                bglib.Parse(inData[i]);
            }
        }

        private void btnStartScan_Click(object sender, EventArgs e)
        {
            // send gap_discover(mode: 1)
            //serialAPI.Write(new Byte[] { 0, 1, 6, 2, 1 }, 0, 5);
            bglib.SendCommand(serialAPI, bglib.BLECommandGAPDiscover(1));
        }

        private void btnStopScan_Click(object sender, EventArgs e)
        {
            // send gap_end_procedure()
            //serialAPI.Write(new Byte[] { 0, 0, 6, 4 }, 0, 4);
            bglib.SendCommand(serialAPI, bglib.BLECommandGAPEndProcedure());
        }

        public string ByteArrayToHexString(Byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}:", b);
            string ret = hex.ToString();
            //char[] cc = ret.ToCharArray();
            //char[] cc2 = new char[cc.Length - 1];
            //Buffer.BlockCopy(cc, 0, cc2, 0, cc.Length - 1);
            //ret = new string(cc2);
            return ret;
        }

        private void btnSerialConn_Click(object sender, EventArgs e)
        {
            serialAPI.Handshake = System.IO.Ports.Handshake.RequestToSend;
            serialAPI.BaudRate = 256000;
            serialAPI.PortName = cmbComPort.Text;
            serialAPI.DataBits = 8;
            serialAPI.StopBits = System.IO.Ports.StopBits.One;
            serialAPI.Parity = System.IO.Ports.Parity.None;
            serialAPI.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(DataReceivedHandler);
            serialAPI.Open();
            Console.WriteLine("Port open");
            tmLog.Enabled = true;

            SerialBase.PorName = serialAPI.PortName;
        }






        private void tmLog_Tick(object sender, EventArgs e)
        {
            if (mSerial.RcvMsg)
            {
                mSerial.RcvMsg = false;
                mSerial.ShowSerialLog(rtxtLog);
                //rtxtLog.AppendText(richtxtLog);
            }
            
        }

        private void dtGrViewBLE_Devices_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIdx = dtGrViewBLE_Devices.CurrentCell.RowIndex;

            string inStr = dtGrViewBLE_Devices[2, rowIdx].Value.ToString();

            btnBLE_Conn_1.Text = "Conn to : " + inStr;
            btnBLE_Conn_1.Enabled = true;
            BLE_Base.SelectedAddr = inStr;
        }



        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(serialAPI.IsOpen)
                bglib.SendCommand(serialAPI, bglib.BLECommandGAPEndProcedure());

            serialAPI.Close();
        }




        private void btnBLE_Conn_1_Click(object sender, EventArgs e)
        {
            //BLE_Base.Connect_to_BLE_Device(BLE_Base.SelectedAddr, bglib, serialAPI, ':');

            string[] AddrSplited = BLE_Base.SelectedAddr.Split(':');
            byte[] addr = new byte[6];
            int add = 0;
            int value = 0;
            string hex = null;

            for (int i = 0; i < AddrSplited.Length - 1; i++)
            {
                value = Convert.ToInt32(AddrSplited[i], 16);
                byte charValue = (byte)value;
                addr[add++] = charValue;
            }

            int conn_intv_min = Convert.ToInt32(txtConnIntvMin.Text);
            int conn_intv_max = Convert.ToInt32(txtConnIntvMax.Text);
            int conn_timeout = Convert.ToInt32(txtConnTimeout.Text);
            int conn_legacy = Convert.ToInt32(txtLegacy.Text);


            bglib.SendCommand(serialAPI, bglib.BLECommandGAPConnectDirect(addr, 0x00, (ushort)conn_intv_min, (ushort)conn_intv_max, (ushort)conn_timeout, (ushort)conn_legacy));


        }

        private void btnDisconn_Click(object sender, EventArgs e)
        {
            bglib.SendCommand(serialAPI, bglib.BLECommandConnectionDisconnect(0));


        }

        private void btnDiscoverService_Click(object sender, EventArgs e)
        {
            bglib.SendCommand(serialAPI, bglib.BLECommandATTClientFindInformation(0,1,65535));
        }

        private void tmConnGetSts_Tick(object sender, EventArgs e)
        {
            bglib.SendCommand(serialAPI, bglib.BLECommandConnectionGetStatus(0));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bglib.SendCommand(serialAPI, bglib.BLECommandConnectionGetStatus(0));
        }

        private void btnOpenSbrick_Click(object sender, EventArgs e)
        {
            frmSBrick sFrmSbrick = new frmSBrick();
            serialAPI.Close();
            sFrmSbrick.Show();
        }
    }
}
