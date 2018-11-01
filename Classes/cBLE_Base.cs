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

namespace BLEScanner.Classes
{
    class cBLE_Base
    {

        public cBLE_Base()
        {
            Create_BLE_Device_DataTable();
        }

        private byte[] BLE_Base_Addr = new byte[6];
        public  int    NumOfBLE_Device = 0;
        private DataTable dtBLE_Device;
        public  string SelectedAddr = null;



        public void Create_BLE_Device_DataTable()
        {
            dtBLE_Device = new DataTable("BLE_Devices");

            dtBLE_Device.Columns.Add("RSSI");
            dtBLE_Device.Columns.Add("Pkt_Type");
            dtBLE_Device.Columns.Add("Addr");
            dtBLE_Device.Columns.Add("Addr_Type");
            dtBLE_Device.Columns.Add("Bonded");
        }


        public void Bind_Grid_to_DataTable(DataGridView inGrid)
        {
            inGrid.DataSource = dtBLE_Device;
        }


        public bool Add_Device_to_DataTable(string[] inStr)
        {
            //for(int i=0; i<5; i++)
             //   inGrid.AutoResizeColumn(0);

            for (int i = 0; i < dtBLE_Device.Rows.Count; i++)
            {
                if (dtBLE_Device.Rows[i]["Addr"].ToString() == inStr[2])
                {
                    dtBLE_Device.Rows[i]["RSSI"] = inStr[0];
                    dtBLE_Device.Rows[i]["Pkt_Type"] = inStr[1];
                    dtBLE_Device.Rows[i]["Addr_Type"] = inStr[3];
                    dtBLE_Device.Rows[i]["Bonded"] = inStr[4];

                    
                    return false;
                }               
            }

            DataRow record = dtBLE_Device.NewRow();
            record["RSSI"] = inStr[0];
            record["Pkt_Type"] = inStr[1];
            record["Addr"] = inStr[2];
            record["Addr_Type"] = inStr[3];
            record["Bonded"] = inStr[4];
            dtBLE_Device.Rows.Add(record);
            return true;
        }




        public void Connect_to_BLE_Device(string Addr, Bluegiga.BGLib bglib, SerialPort serialAPI, char symbol)
        {
            string[] AddrSplited = Addr.Split(symbol);
            byte[] addr = new byte[6];
            int add = 0;
            int value = 0;
            string hex = null;

            for (int i = 0; i < AddrSplited.Length-1; i++)
            {
                value = Convert.ToInt32(AddrSplited[i], 16);
                byte charValue = (byte)value;
                addr[add++] = charValue;
            }


            //BLECommandGAPConnectDirect
            bglib.SendCommand(serialAPI, bglib.BLECommandGAPConnectDirect(addr, 0x00,10,250,300,0) );




        }


        public static byte[] RcvByte = new byte[64];
        public static int RcvEventType = -1;
        public static int RcvResponseType = -1;
        public static string Log = null;

        public const int EventConnSts = 0;
        public const int EventDisconnSts = 1;
        public const int EventAttClientFindInfo = 2;

        public const int RspConnSts = 0;
        public const int RspDisconn = 1;
        public const int RspAttClientFindInfo = 2;


        public int Get_RcvEvent()
        {
            return RcvEventType;
        }

        public void Set_RcvEvent(int a)
        {
            RcvEventType = a;
        }

        public int Get_RcvResponse()
        {
            return RcvResponseType;
        }

        public void Set_RcvResponse(int a)
        {
            RcvResponseType = a;
        }

        public string Get_Log()
        {
            return Log;
        }


        //ble_evt_connection_status connection
        public void ConnectionStatusEvent(object sender, Bluegiga.BLE.Events.Connection.StatusEventArgs e)
        {
            String log = string.Format("Connection: {0}, Flags: {1}, Addr: {2}\r\n", e.connection, e.flags, e.address[0]);
            Log = log;
            int add = 0;

            RcvByte[add++] = e.connection;
            RcvByte[add++] = e.flags;
            for(int i=0; i<e.address.Length; i++)
                RcvByte[add++] = e.address[i];

            RcvEventType = EventConnSts;
            RcvResponseType = -1;
        }




        //ble_rsp_connection_disconnect connection: 0 (0x00) result:0x0000 ['No Error']
        public void DisconnectResponse(object sender, Bluegiga.BLE.Responses.Connection.DisconnectEventArgs e)
        {        
            
            String log = string.Format("disconn Result: {0}\r\n", e.result);
            Log = log;

            byte[] inUint16 = new byte[2];
            inUint16 = BitConverter.GetBytes( e.result);
            RcvByte[0] = inUint16[0];
            RcvByte[1] = inUint16[1];

            RcvEventType        = -1;
            RcvResponseType     = RspDisconn;

        }



        //ble_evt_connection_disconnected connection: 0 (0x00) reason:0x0216 ['Local device terminated the connection.']
        public void DisconnectEvent(object sender, Bluegiga.BLE.Events.Connection.DisconnectedEventArgs e)
        {
            String log = string.Format("disconn Reason: {0}\r\n", e.reason);
            Log = log;

            byte[] inUint16 = new byte[2];
            inUint16 = BitConverter.GetBytes(e.reason);
            RcvByte[0] = inUint16[0];
            RcvByte[1] = inUint16[1];

            RcvEventType = EventDisconnSts;
            RcvResponseType = -1;
        }




        //ble_rsp_attclient_find_information connection: 0 (0x00) result:0x0000 ['No Error']
        public void AttClientFindInfoResponse(object sender, Bluegiga.BLE.Responses.ATTClient.FindInformationEventArgs e)
        {
            String log = string.Format("Result: {0}\r\n", e.result);
            Log = log;

            byte[] inUint16 = new byte[2];
            inUint16 = BitConverter.GetBytes(e.result);
            RcvByte[0] = inUint16[0];
            RcvByte[1] = inUint16[1];

            RcvEventType = -1;
            RcvResponseType = RspAttClientFindInfo;

        }


        public void AttClientFindInfoEvent(object sender, Bluegiga.BLE.Events.ATTClient.FindInformationFoundEventArgs e)
        {
            String log = string.Format("Connection: {0}, Character Handle: {1}, UUID: {2}\r\n", e.connection, e.chrhandle, e.uuid);
            Log = log;

            RcvEventType = EventAttClientFindInfo;
            RcvResponseType = -1;

            int add = 0;
            byte[] inUint16 = new byte[2];

            RcvByte[add++] = e.connection;

            inUint16 = BitConverter.GetBytes(e.chrhandle);
            RcvByte[add++] = inUint16[0];
            RcvByte[add++] = inUint16[1];

            for (int i = 0; i < e.uuid.Length; i++)
                RcvByte[add++] = e.uuid[i];

        }


    }
}
