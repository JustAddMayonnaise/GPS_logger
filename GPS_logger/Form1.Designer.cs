namespace GPS_logger
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cmbbxCOMPorts = new System.Windows.Forms.ComboBox();
            this.btnConnectDisconnect = new System.Windows.Forms.Button();
            this.serCOM = new System.IO.Ports.SerialPort(this.components);
            this.txtbxBytesInQueue = new System.Windows.Forms.TextBox();
            this.tmrSerRead = new System.Windows.Forms.Timer(this.components);
            this.txtbxBytesToRead = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbxUTCTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbxGPSQual = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.tmrTimeOut = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.txtbxFileName = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // cmbbxCOMPorts
            // 
            this.cmbbxCOMPorts.FormattingEnabled = true;
            this.cmbbxCOMPorts.Location = new System.Drawing.Point(12, 12);
            this.cmbbxCOMPorts.Name = "cmbbxCOMPorts";
            this.cmbbxCOMPorts.Size = new System.Drawing.Size(121, 21);
            this.cmbbxCOMPorts.TabIndex = 0;
            this.cmbbxCOMPorts.DropDown += new System.EventHandler(this.cmbbxCOMPortsMSP_DropDown);
            // 
            // btnConnectDisconnect
            // 
            this.btnConnectDisconnect.Location = new System.Drawing.Point(149, 13);
            this.btnConnectDisconnect.Name = "btnConnectDisconnect";
            this.btnConnectDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnectDisconnect.TabIndex = 1;
            this.btnConnectDisconnect.Text = "Connect";
            this.btnConnectDisconnect.UseVisualStyleBackColor = true;
            this.btnConnectDisconnect.Click += new System.EventHandler(this.btnConnectMSP_Click);
            // 
            // serCOM
            // 
            this.serCOM.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serCOM_DataReceived);
            // 
            // txtbxBytesInQueue
            // 
            this.txtbxBytesInQueue.Location = new System.Drawing.Point(93, 39);
            this.txtbxBytesInQueue.Multiline = true;
            this.txtbxBytesInQueue.Name = "txtbxBytesInQueue";
            this.txtbxBytesInQueue.ReadOnly = true;
            this.txtbxBytesInQueue.Size = new System.Drawing.Size(131, 23);
            this.txtbxBytesInQueue.TabIndex = 2;
            // 
            // tmrSerRead
            // 
            this.tmrSerRead.Enabled = true;
            this.tmrSerRead.Interval = 10;
            this.tmrSerRead.Tick += new System.EventHandler(this.tmrSerRead_Tick);
            // 
            // txtbxBytesToRead
            // 
            this.txtbxBytesToRead.Location = new System.Drawing.Point(93, 75);
            this.txtbxBytesToRead.Multiline = true;
            this.txtbxBytesToRead.Name = "txtbxBytesToRead";
            this.txtbxBytesToRead.ReadOnly = true;
            this.txtbxBytesToRead.Size = new System.Drawing.Size(131, 23);
            this.txtbxBytesToRead.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Bytes in Queue:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 104);
            this.textBox1.MaxLength = 200;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(420, 268);
            this.textBox1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Bytes To read:";
            // 
            // txtbxUTCTime
            // 
            this.txtbxUTCTime.Location = new System.Drawing.Point(561, 300);
            this.txtbxUTCTime.Name = "txtbxUTCTime";
            this.txtbxUTCTime.ReadOnly = true;
            this.txtbxUTCTime.Size = new System.Drawing.Size(100, 20);
            this.txtbxUTCTime.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(493, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "UTC Time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(493, 329);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "GPS Quality";
            // 
            // txtbxGPSQual
            // 
            this.txtbxGPSQual.Location = new System.Drawing.Point(561, 326);
            this.txtbxGPSQual.Name = "txtbxGPSQual";
            this.txtbxGPSQual.ReadOnly = true;
            this.txtbxGPSQual.Size = new System.Drawing.Size(100, 20);
            this.txtbxGPSQual.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(493, 355);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Time out";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(561, 352);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 11;
            // 
            // tmrTimeOut
            // 
            this.tmrTimeOut.Interval = 1000;
            this.tmrTimeOut.Tick += new System.EventHandler(this.tmrTimeOut_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 389);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "File Directory";
            // 
            // txtbxFileName
            // 
            this.txtbxFileName.Location = new System.Drawing.Point(77, 386);
            this.txtbxFileName.Name = "txtbxFileName";
            this.txtbxFileName.Size = new System.Drawing.Size(358, 20);
            this.txtbxFileName.TabIndex = 13;
            this.txtbxFileName.Click += new System.EventHandler(this.txtbxFileName_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtbxFileName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtbxGPSQual);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtbxUTCTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbxBytesToRead);
            this.Controls.Add(this.txtbxBytesInQueue);
            this.Controls.Add(this.btnConnectDisconnect);
            this.Controls.Add(this.cmbbxCOMPorts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "David\'s GPS Logger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbbxCOMPorts;
        private System.Windows.Forms.Button btnConnectDisconnect;
        private System.IO.Ports.SerialPort serCOM;
        private System.Windows.Forms.TextBox txtbxBytesInQueue;
        private System.Windows.Forms.Timer tmrSerRead;
        private System.Windows.Forms.TextBox txtbxBytesToRead;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbxUTCTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbxGPSQual;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Timer tmrTimeOut;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtbxFileName;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

