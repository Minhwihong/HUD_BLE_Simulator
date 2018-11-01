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
    public partial class frmSBrick : Form
    {
        //public Bluegiga.BGLib bglib = new Bluegiga.BGLib();
        Thread thread_Sbrick_control = null;
        //private System.IO.Ports.SerialPort serialAPI;
        frmMain MainResrc = new frmMain();

        int Sbrick_cmd = 0;
        byte[] SendCmd_Sbrick;
        int Alive_Cnt = 0;


        public frmSBrick()
        {
            InitializeComponent();
        }



        private void thSbrick_Control()
        {


        }




        private void btnSbrickDrive_Click(object sender, EventArgs e)
        {
            Sbrick_cmd = 0x01;
            tmSbrickKeepConn.Enabled    = false;
            tmSbrickTick.Enabled        = true;

            Alive_Cnt = 0;
        }



        private void frmSBrick_Load(object sender, EventArgs e)
        {
            thread_Sbrick_control = new Thread(new ThreadStart(thSbrick_Control));
            //tmSbrickTick.Enabled = true;
            tmSbrickKeepConn.Enabled = true;

            MainResrc.serialAPI.Handshake = System.IO.Ports.Handshake.RequestToSend;
            MainResrc.serialAPI.BaudRate = 256000;
            MainResrc.serialAPI.PortName = SerialBase.PorName;
            MainResrc.serialAPI.DataBits = 8;
            MainResrc.serialAPI.StopBits = System.IO.Ports.StopBits.One;
            MainResrc.serialAPI.Parity = System.IO.Ports.Parity.None;
            MainResrc.serialAPI.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(Sbrick_Rcv_Handler);
            MainResrc.serialAPI.Open();

        }

        private void tmSbrickKeepConn_Tick(object sender, EventArgs e)
        {
            byte[] sendZero = {0x00,0x00, 0x01, 0x02, 0x03 };

            MainResrc.bglib.SendCommand(MainResrc.serialAPI, MainResrc.bglib.BLECommandATTClientWriteCommand(0x00,26, sendZero));
        }


        private void Sbrick_Rcv_Handler(object sender, SerialDataReceivedEventArgs e)
        {

        }




        private void tmSbrickTick_Tick(object sender, EventArgs e)
        {
            byte ch = 0;
            byte dir = 0;
            byte power = 0;
            byte[] sendCmd;
            bool[] On_ch = new bool[4];
            int On_ch_cnt = 0;

            for (int i = 0; i < 4; i++) On_ch[i] = false;

            switch (Sbrick_cmd)
            {
                case 0x00:
                    break;

                case 0x01:
                    if (chbSbrickCh1.Checked) ch = 0;
                    if (chbSbrickCh2.Checked) ch = 1;
                    if (chbSbrickCh3.Checked) ch = 2;
                    if (chbSbrickCh4.Checked) ch = 3;
                    sendCmd = new byte[4];
                    dir = Convert.ToByte(txtDriveDir.Text);
                    power = (byte)numDrivePower.Value;
                    sendCmd[0] = 1;
                    sendCmd[1] = ch;
                    sendCmd[2] = dir;
                    sendCmd[3] = power;
                    MainResrc.bglib.SendCommand(MainResrc.serialAPI, MainResrc.bglib.BLECommandATTClientWriteCommand(0x00, 26, sendCmd));
                    break;


                case 0x02:
                    break;

                case 0x03:
                    break;


                case 0xF0:
                    MainResrc.bglib.SendCommand(MainResrc.serialAPI, MainResrc.bglib.BLECommandATTClientWriteCommand(0x00, 26, SendCmd_Sbrick));
                    break;
            }


            


        }

        private void btnSbrickStop_Click(object sender, EventArgs e)
        {
            Sbrick_cmd = 0;
            tmSbrickKeepConn.Enabled   = true;
            tmSbrickTick.Enabled        = false;

            byte ch = 0;
            byte dir = 0;

            if (chbSbrickCh1.Checked) ch = 0;
            if (chbSbrickCh2.Checked) ch = 1;
            if (chbSbrickCh3.Checked) ch = 2;
            if (chbSbrickCh4.Checked) ch = 3;
            byte[] sendCmd = { 0x01, ch, dir ,0};
            

            MainResrc.bglib.SendCommand(MainResrc.serialAPI, MainResrc.bglib.BLECommandATTClientWriteCommand(0x00, 26, sendCmd));
        }

        private void frmSBrick_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainResrc.bglib.SendCommand(MainResrc.serialAPI, MainResrc.bglib.BLECommandConnectionDisconnect(0));
            MainResrc.serialAPI.Close();
        }



        private void frmSBrick_KeyDown(object sender, KeyEventArgs e)
        {
            

            if (e.KeyCode == Keys.W|| e.KeyCode == Keys.S || e.KeyCode == Keys.A || e.KeyCode == Keys.D)
            {
                Alive_Cnt = 0;

                SendCmd_Sbrick = new byte[7];

                SendCmd_Sbrick[0] = 0x01;
                SendCmd_Sbrick[1] = 0x01;   // ch.1           
                SendCmd_Sbrick[3] = (byte)numDrivePower.Value;
                SendCmd_Sbrick[4] = 0x03;   // ch.3           
                SendCmd_Sbrick[6] = (byte)numDrivePower.Value;
                if (e.KeyCode == Keys.W)
                {
                    SendCmd_Sbrick[2] = 1;
                    SendCmd_Sbrick[5] = 0;
                    btnFront.BackColor = Color.Blue;                   
                }
                else if (e.KeyCode == Keys.S && (e.KeyCode != Keys.W || e.KeyCode == Keys.S) )
                {
                    SendCmd_Sbrick[2] = 0;
                    SendCmd_Sbrick[5] = 1;                    
                    btnBack.BackColor = Color.Blue;
                }
                else if (e.KeyCode == Keys.A && (e.KeyCode != Keys.W || e.KeyCode == Keys.S))
                {
                    SendCmd_Sbrick[2] = 1;
                    SendCmd_Sbrick[5] = 1;
                    btnLeft.BackColor = Color.Blue;                 
                }
                else if (e.KeyCode == Keys.D)
                {
                    SendCmd_Sbrick[2] = 0;
                    SendCmd_Sbrick[5] = 0;
                    btnRight.BackColor = Color.Blue;                   
                }

                tmSbrickKeepConn.Enabled = false;
                Sbrick_cmd = 0xF0;
                MainResrc.bglib.SendCommand(MainResrc.serialAPI, MainResrc.bglib.BLECommandATTClientWriteCommand(0x00, 26, SendCmd_Sbrick));
            }
        }



        private void frmSBrick_KeyUp(object sender, KeyEventArgs e)
        {
            

            if (e.KeyCode == Keys.W || e.KeyCode == Keys.S || e.KeyCode == Keys.A || e.KeyCode == Keys.D)
            {
                btnBack.BackColor = Color.WhiteSmoke;
                btnFront.BackColor = Color.WhiteSmoke;
                btnLeft.BackColor = Color.WhiteSmoke;
                btnRight.BackColor = Color.WhiteSmoke;

                Alive_Cnt = 0;
                tmSbrickKeepConn.Enabled = true;
                SendCmd_Sbrick = new byte[3];
                SendCmd_Sbrick[0] = 0x00;
                SendCmd_Sbrick[1] = 0x01;   // ch.1
                SendCmd_Sbrick[2] = 0x03;               
                Sbrick_cmd = 0xF0;
                MainResrc.bglib.SendCommand(MainResrc.serialAPI, MainResrc.bglib.BLECommandATTClientWriteCommand(0x00, 26, SendCmd_Sbrick));

            }
        }

        private void frmSBrick_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'o' || e.KeyChar == 'p')
            {
                
            }
        }

        private void tmCheckAlive_Tick(object sender, EventArgs e)
        {
            //if (Alive_Cnt > 20)
            //    tmSbrickKeepConn.Enabled = true;
            //else
            //    Alive_Cnt++;
        }
    }
}
