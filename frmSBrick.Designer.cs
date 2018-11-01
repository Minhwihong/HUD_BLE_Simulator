namespace BLEScanner
{
    partial class frmSBrick
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
            this.btnFront = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSbrickDrive = new System.Windows.Forms.Button();
            this.btnSbrickStop = new System.Windows.Forms.Button();
            this.tmSbrickTick = new System.Windows.Forms.Timer(this.components);
            this.tmSbrickKeepConn = new System.Windows.Forms.Timer(this.components);
            this.chbSbrickCh1 = new System.Windows.Forms.CheckBox();
            this.chbSbrickCh2 = new System.Windows.Forms.CheckBox();
            this.chbSbrickCh3 = new System.Windows.Forms.CheckBox();
            this.chbSbrickCh4 = new System.Windows.Forms.CheckBox();
            this.txtDrivePower = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDriveDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tmCheckAlive = new System.Windows.Forms.Timer(this.components);
            this.numDrivePower = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDrivePower)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFront
            // 
            this.btnFront.Location = new System.Drawing.Point(100, 20);
            this.btnFront.Name = "btnFront";
            this.btnFront.Size = new System.Drawing.Size(70, 50);
            this.btnFront.TabIndex = 0;
            this.btnFront.Text = "Front";
            this.btnFront.UseVisualStyleBackColor = true;
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(27, 73);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(70, 50);
            this.btnLeft.TabIndex = 1;
            this.btnLeft.Text = "Left";
            this.btnLeft.UseVisualStyleBackColor = true;
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(174, 73);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(70, 50);
            this.btnRight.TabIndex = 2;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(100, 129);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(70, 50);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBack);
            this.groupBox1.Controls.Add(this.btnFront);
            this.groupBox1.Controls.Add(this.btnRight);
            this.groupBox1.Controls.Add(this.btnLeft);
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 199);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // btnSbrickDrive
            // 
            this.btnSbrickDrive.Location = new System.Drawing.Point(465, 21);
            this.btnSbrickDrive.Name = "btnSbrickDrive";
            this.btnSbrickDrive.Size = new System.Drawing.Size(70, 50);
            this.btnSbrickDrive.TabIndex = 4;
            this.btnSbrickDrive.Text = "Go";
            this.btnSbrickDrive.UseVisualStyleBackColor = true;
            this.btnSbrickDrive.Click += new System.EventHandler(this.btnSbrickDrive_Click);
            // 
            // btnSbrickStop
            // 
            this.btnSbrickStop.Location = new System.Drawing.Point(541, 21);
            this.btnSbrickStop.Name = "btnSbrickStop";
            this.btnSbrickStop.Size = new System.Drawing.Size(70, 50);
            this.btnSbrickStop.TabIndex = 4;
            this.btnSbrickStop.Text = "stop";
            this.btnSbrickStop.UseVisualStyleBackColor = true;
            this.btnSbrickStop.Click += new System.EventHandler(this.btnSbrickStop_Click);
            // 
            // tmSbrickTick
            // 
            this.tmSbrickTick.Interval = 103;
            this.tmSbrickTick.Tick += new System.EventHandler(this.tmSbrickTick_Tick);
            // 
            // tmSbrickKeepConn
            // 
            this.tmSbrickKeepConn.Interval = 1001;
            this.tmSbrickKeepConn.Tick += new System.EventHandler(this.tmSbrickKeepConn_Tick);
            // 
            // chbSbrickCh1
            // 
            this.chbSbrickCh1.AutoSize = true;
            this.chbSbrickCh1.Location = new System.Drawing.Point(390, 21);
            this.chbSbrickCh1.Name = "chbSbrickCh1";
            this.chbSbrickCh1.Size = new System.Drawing.Size(51, 16);
            this.chbSbrickCh1.TabIndex = 5;
            this.chbSbrickCh1.Text = "CH.1";
            this.chbSbrickCh1.UseVisualStyleBackColor = true;
            // 
            // chbSbrickCh2
            // 
            this.chbSbrickCh2.AutoSize = true;
            this.chbSbrickCh2.Location = new System.Drawing.Point(390, 43);
            this.chbSbrickCh2.Name = "chbSbrickCh2";
            this.chbSbrickCh2.Size = new System.Drawing.Size(51, 16);
            this.chbSbrickCh2.TabIndex = 6;
            this.chbSbrickCh2.Text = "CH.2";
            this.chbSbrickCh2.UseVisualStyleBackColor = true;
            // 
            // chbSbrickCh3
            // 
            this.chbSbrickCh3.AutoSize = true;
            this.chbSbrickCh3.Location = new System.Drawing.Point(390, 65);
            this.chbSbrickCh3.Name = "chbSbrickCh3";
            this.chbSbrickCh3.Size = new System.Drawing.Size(51, 16);
            this.chbSbrickCh3.TabIndex = 7;
            this.chbSbrickCh3.Text = "CH.3";
            this.chbSbrickCh3.UseVisualStyleBackColor = true;
            // 
            // chbSbrickCh4
            // 
            this.chbSbrickCh4.AutoSize = true;
            this.chbSbrickCh4.Location = new System.Drawing.Point(390, 87);
            this.chbSbrickCh4.Name = "chbSbrickCh4";
            this.chbSbrickCh4.Size = new System.Drawing.Size(51, 16);
            this.chbSbrickCh4.TabIndex = 8;
            this.chbSbrickCh4.Text = "CH.4";
            this.chbSbrickCh4.UseVisualStyleBackColor = true;
            // 
            // txtDrivePower
            // 
            this.txtDrivePower.Location = new System.Drawing.Point(699, 82);
            this.txtDrivePower.Name = "txtDrivePower";
            this.txtDrivePower.Size = new System.Drawing.Size(80, 21);
            this.txtDrivePower.TabIndex = 9;
            this.txtDrivePower.Text = "160";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(394, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "Power";
            // 
            // txtDriveDir
            // 
            this.txtDriveDir.Location = new System.Drawing.Point(308, 143);
            this.txtDriveDir.Name = "txtDriveDir";
            this.txtDriveDir.Size = new System.Drawing.Size(80, 21);
            this.txtDriveDir.TabIndex = 20;
            this.txtDriveDir.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(306, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "Direction (0 or 1)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(351, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "삽1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(351, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 23;
            this.label4.Text = "삽2";
            // 
            // tmCheckAlive
            // 
            this.tmCheckAlive.Enabled = true;
            this.tmCheckAlive.Interval = 87;
            this.tmCheckAlive.Tick += new System.EventHandler(this.tmCheckAlive_Tick);
            // 
            // numDrivePower
            // 
            this.numDrivePower.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numDrivePower.Location = new System.Drawing.Point(308, 116);
            this.numDrivePower.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numDrivePower.Name = "numDrivePower";
            this.numDrivePower.Size = new System.Drawing.Size(80, 21);
            this.numDrivePower.TabIndex = 24;
            this.numDrivePower.Value = new decimal(new int[] {
            160,
            0,
            0,
            0});
            // 
            // frmSBrick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 507);
            this.Controls.Add(this.numDrivePower);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDriveDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDrivePower);
            this.Controls.Add(this.chbSbrickCh4);
            this.Controls.Add(this.chbSbrickCh3);
            this.Controls.Add(this.chbSbrickCh2);
            this.Controls.Add(this.chbSbrickCh1);
            this.Controls.Add(this.btnSbrickStop);
            this.Controls.Add(this.btnSbrickDrive);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "frmSBrick";
            this.Text = "frmSBrick";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSBrick_FormClosing);
            this.Load += new System.EventHandler(this.frmSBrick_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSBrick_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmSBrick_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmSBrick_KeyUp);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numDrivePower)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFront;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSbrickDrive;
        private System.Windows.Forms.Button btnSbrickStop;
        private System.Windows.Forms.Timer tmSbrickTick;
        private System.Windows.Forms.Timer tmSbrickKeepConn;
        private System.Windows.Forms.CheckBox chbSbrickCh1;
        private System.Windows.Forms.CheckBox chbSbrickCh2;
        private System.Windows.Forms.CheckBox chbSbrickCh3;
        private System.Windows.Forms.CheckBox chbSbrickCh4;
        private System.Windows.Forms.TextBox txtDrivePower;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDriveDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer tmCheckAlive;
        private System.Windows.Forms.NumericUpDown numDrivePower;
    }
}