namespace BLEScanner
{
    partial class frmMain
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
            this.serialAPI = new System.IO.Ports.SerialPort(this.components);
            this.btnStopScan = new System.Windows.Forms.Button();
            this.btnStartScan = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.cmbComPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSerialConn = new System.Windows.Forms.Button();
            this.rtxtLog = new System.Windows.Forms.RichTextBox();
            this.tmLog = new System.Windows.Forms.Timer(this.components);
            this.btnBLE_Conn_1 = new System.Windows.Forms.Button();
            this.dtGrViewBLE_Devices = new System.Windows.Forms.DataGridView();
            this.dtGrviewService = new System.Windows.Forms.DataGridView();
            this.btnDisconn = new System.Windows.Forms.Button();
            this.btnDiscoverService = new System.Windows.Forms.Button();
            this.tmConnGetSts = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.txtConnIntvMin = new System.Windows.Forms.TextBox();
            this.txtConnIntvMax = new System.Windows.Forms.TextBox();
            this.txtConnTimeout = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLegacy = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOpenSbrick = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrViewBLE_Devices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrviewService)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStopScan
            // 
            this.btnStopScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopScan.Location = new System.Drawing.Point(283, 17);
            this.btnStopScan.Name = "btnStopScan";
            this.btnStopScan.Size = new System.Drawing.Size(117, 21);
            this.btnStopScan.TabIndex = 1;
            this.btnStopScan.Text = "Sto&p Scanning";
            this.btnStopScan.UseVisualStyleBackColor = true;
            this.btnStopScan.Click += new System.EventHandler(this.btnStopScan_Click);
            // 
            // btnStartScan
            // 
            this.btnStartScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartScan.Location = new System.Drawing.Point(406, 17);
            this.btnStartScan.Name = "btnStartScan";
            this.btnStartScan.Size = new System.Drawing.Size(117, 21);
            this.btnStartScan.TabIndex = 2;
            this.btnStartScan.Text = "&Start Scanning";
            this.btnStartScan.UseVisualStyleBackColor = true;
            this.btnStartScan.Click += new System.EventHandler(this.btnStartScan_Click);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(7, 229);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(783, 129);
            this.txtLog.TabIndex = 3;
            // 
            // cmbComPort
            // 
            this.cmbComPort.FormattingEnabled = true;
            this.cmbComPort.Location = new System.Drawing.Point(86, 16);
            this.cmbComPort.Name = "cmbComPort";
            this.cmbComPort.Size = new System.Drawing.Size(94, 20);
            this.cmbComPort.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Serial Port";
            // 
            // btnSerialConn
            // 
            this.btnSerialConn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSerialConn.Location = new System.Drawing.Point(187, 17);
            this.btnSerialConn.Name = "btnSerialConn";
            this.btnSerialConn.Size = new System.Drawing.Size(82, 21);
            this.btnSerialConn.TabIndex = 6;
            this.btnSerialConn.Text = "Connect";
            this.btnSerialConn.UseVisualStyleBackColor = true;
            this.btnSerialConn.Click += new System.EventHandler(this.btnSerialConn_Click);
            // 
            // rtxtLog
            // 
            this.rtxtLog.Location = new System.Drawing.Point(7, 364);
            this.rtxtLog.Name = "rtxtLog";
            this.rtxtLog.Size = new System.Drawing.Size(784, 166);
            this.rtxtLog.TabIndex = 7;
            this.rtxtLog.Text = "";
            // 
            // tmLog
            // 
            this.tmLog.Interval = 2;
            this.tmLog.Tick += new System.EventHandler(this.tmLog_Tick);
            // 
            // btnBLE_Conn_1
            // 
            this.btnBLE_Conn_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBLE_Conn_1.Enabled = false;
            this.btnBLE_Conn_1.Location = new System.Drawing.Point(10, 170);
            this.btnBLE_Conn_1.Name = "btnBLE_Conn_1";
            this.btnBLE_Conn_1.Size = new System.Drawing.Size(229, 29);
            this.btnBLE_Conn_1.TabIndex = 8;
            this.btnBLE_Conn_1.Text = "--";
            this.btnBLE_Conn_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBLE_Conn_1.UseVisualStyleBackColor = true;
            this.btnBLE_Conn_1.Click += new System.EventHandler(this.btnBLE_Conn_1_Click);
            // 
            // dtGrViewBLE_Devices
            // 
            this.dtGrViewBLE_Devices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrViewBLE_Devices.Location = new System.Drawing.Point(8, 42);
            this.dtGrViewBLE_Devices.Name = "dtGrViewBLE_Devices";
            this.dtGrViewBLE_Devices.RowTemplate.Height = 23;
            this.dtGrViewBLE_Devices.Size = new System.Drawing.Size(515, 118);
            this.dtGrViewBLE_Devices.TabIndex = 10;
            this.dtGrViewBLE_Devices.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtGrViewBLE_Devices_CellMouseDoubleClick);
            // 
            // dtGrviewService
            // 
            this.dtGrviewService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrviewService.Location = new System.Drawing.Point(529, 41);
            this.dtGrviewService.Name = "dtGrviewService";
            this.dtGrviewService.RowTemplate.Height = 23;
            this.dtGrviewService.Size = new System.Drawing.Size(509, 118);
            this.dtGrviewService.TabIndex = 11;
            // 
            // btnDisconn
            // 
            this.btnDisconn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisconn.Enabled = false;
            this.btnDisconn.Location = new System.Drawing.Point(856, 375);
            this.btnDisconn.Name = "btnDisconn";
            this.btnDisconn.Size = new System.Drawing.Size(113, 29);
            this.btnDisconn.TabIndex = 12;
            this.btnDisconn.Text = "Disconnect";
            this.btnDisconn.UseVisualStyleBackColor = true;
            this.btnDisconn.Click += new System.EventHandler(this.btnDisconn_Click);
            // 
            // btnDiscoverService
            // 
            this.btnDiscoverService.Location = new System.Drawing.Point(245, 168);
            this.btnDiscoverService.Name = "btnDiscoverService";
            this.btnDiscoverService.Size = new System.Drawing.Size(115, 31);
            this.btnDiscoverService.TabIndex = 13;
            this.btnDiscoverService.Text = "Discover Service";
            this.btnDiscoverService.UseVisualStyleBackColor = true;
            this.btnDiscoverService.Click += new System.EventHandler(this.btnDiscoverService_Click);
            // 
            // tmConnGetSts
            // 
            this.tmConnGetSts.Interval = 2000;
            this.tmConnGetSts.Tick += new System.EventHandler(this.tmConnGetSts_Tick);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(856, 340);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 29);
            this.button1.TabIndex = 14;
            this.button1.Text = "Get Conn Sts";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtConnIntvMin
            // 
            this.txtConnIntvMin.Location = new System.Drawing.Point(893, 410);
            this.txtConnIntvMin.Name = "txtConnIntvMin";
            this.txtConnIntvMin.Size = new System.Drawing.Size(76, 21);
            this.txtConnIntvMin.TabIndex = 15;
            this.txtConnIntvMin.Text = "60";
            // 
            // txtConnIntvMax
            // 
            this.txtConnIntvMax.Location = new System.Drawing.Point(893, 437);
            this.txtConnIntvMax.Name = "txtConnIntvMax";
            this.txtConnIntvMax.Size = new System.Drawing.Size(76, 21);
            this.txtConnIntvMax.TabIndex = 16;
            this.txtConnIntvMax.Text = "100";
            // 
            // txtConnTimeout
            // 
            this.txtConnTimeout.Location = new System.Drawing.Point(893, 464);
            this.txtConnTimeout.Name = "txtConnTimeout";
            this.txtConnTimeout.Size = new System.Drawing.Size(76, 21);
            this.txtConnTimeout.TabIndex = 17;
            this.txtConnTimeout.Text = "100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(799, 413);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "Conn intv Min";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(799, 440);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "Conn intv Max";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(799, 467);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "Timeout";
            // 
            // txtLegacy
            // 
            this.txtLegacy.Location = new System.Drawing.Point(893, 491);
            this.txtLegacy.Name = "txtLegacy";
            this.txtLegacy.Size = new System.Drawing.Size(76, 21);
            this.txtLegacy.TabIndex = 21;
            this.txtLegacy.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(836, 494);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "Legacy";
            // 
            // btnOpenSbrick
            // 
            this.btnOpenSbrick.Enabled = false;
            this.btnOpenSbrick.Location = new System.Drawing.Point(366, 168);
            this.btnOpenSbrick.Name = "btnOpenSbrick";
            this.btnOpenSbrick.Size = new System.Drawing.Size(125, 31);
            this.btnOpenSbrick.TabIndex = 23;
            this.btnOpenSbrick.Text = "Open Sbrick Panel";
            this.btnOpenSbrick.UseVisualStyleBackColor = true;
            this.btnOpenSbrick.Click += new System.EventHandler(this.btnOpenSbrick_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 564);
            this.Controls.Add(this.btnOpenSbrick);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLegacy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtConnTimeout);
            this.Controls.Add(this.txtConnIntvMax);
            this.Controls.Add(this.txtConnIntvMin);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDiscoverService);
            this.Controls.Add(this.btnDisconn);
            this.Controls.Add(this.dtGrviewService);
            this.Controls.Add(this.dtGrViewBLE_Devices);
            this.Controls.Add(this.btnBLE_Conn_1);
            this.Controls.Add(this.rtxtLog);
            this.Controls.Add(this.btnSerialConn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbComPort);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnStartScan);
            this.Controls.Add(this.btnStopScan);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "BLE Scanner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrViewBLE_Devices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrviewService)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
        private System.Windows.Forms.Button btnStopScan;
        private System.Windows.Forms.Button btnStartScan;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSerialConn;
        private System.Windows.Forms.RichTextBox rtxtLog;
        private System.Windows.Forms.Timer tmLog;
        private System.Windows.Forms.Button btnBLE_Conn_1;
        private System.Windows.Forms.DataGridView dtGrViewBLE_Devices;
        private System.Windows.Forms.DataGridView dtGrviewService;
        private System.Windows.Forms.Button btnDisconn;
        private System.Windows.Forms.Button btnDiscoverService;
        private System.Windows.Forms.Timer tmConnGetSts;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtConnIntvMin;
        private System.Windows.Forms.TextBox txtConnIntvMax;
        private System.Windows.Forms.TextBox txtConnTimeout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLegacy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnOpenSbrick;
        public System.Windows.Forms.ComboBox cmbComPort;
    }
}

