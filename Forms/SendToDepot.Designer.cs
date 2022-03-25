namespace Liquid.Forms
{
    partial class SendToDepot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendToDepot));
            this.lblStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHostAddress = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.cmdSendToServer = new System.Windows.Forms.Button();
            this.lblFilename = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDocSend = new System.Windows.Forms.Label();
            this.ilStatus = new System.Windows.Forms.ImageList(this.components);
            this.lblConnectToServer = new System.Windows.Forms.Label();
            this.lblDocLoadStatus = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.pnlBusy = new System.Windows.Forms.Panel();
            this.lblBusyText = new System.Windows.Forms.Label();
            this.tDelay = new System.Windows.Forms.Timer(this.components);
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.picBusy = new System.Windows.Forms.PictureBox();
            this.tSendDocument = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlBusy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBusy)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(128, 87);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(24, 13);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Idle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Present Status:";
            // 
            // lblHostAddress
            // 
            this.lblHostAddress.AutoSize = true;
            this.lblHostAddress.Location = new System.Drawing.Point(128, 58);
            this.lblHostAddress.Name = "lblHostAddress";
            this.lblHostAddress.Size = new System.Drawing.Size(52, 13);
            this.lblHostAddress.TabIndex = 7;
            this.lblHostAddress.Text = "127.0.0.1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Host Address:";
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtLog.Location = new System.Drawing.Point(0, 205);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(645, 168);
            this.txtLog.TabIndex = 10;
            // 
            // cmdSendToServer
            // 
            this.cmdSendToServer.Enabled = false;
            this.cmdSendToServer.Location = new System.Drawing.Point(493, 145);
            this.cmdSendToServer.Name = "cmdSendToServer";
            this.cmdSendToServer.Size = new System.Drawing.Size(126, 54);
            this.cmdSendToServer.TabIndex = 11;
            this.cmdSendToServer.Text = "Send to Server";
            this.cmdSendToServer.UseVisualStyleBackColor = true;
            this.cmdSendToServer.Click += new System.EventHandler(this.cmdSendToServer_Click);
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Location = new System.Drawing.Point(128, 26);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(61, 13);
            this.lblFilename.TabIndex = 12;
            this.lblFilename.Text = "filename.rpt";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Document Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblFilename);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.lblHostAddress);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 127);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection details";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDocSend);
            this.groupBox2.Controls.Add(this.lblConnectToServer);
            this.groupBox2.Controls.Add(this.lblDocLoadStatus);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(362, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 127);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connection Status";
            // 
            // lblDocSend
            // 
            this.lblDocSend.ImageList = this.ilStatus;
            this.lblDocSend.Location = new System.Drawing.Point(189, 82);
            this.lblDocSend.Name = "lblDocSend";
            this.lblDocSend.Size = new System.Drawing.Size(22, 22);
            this.lblDocSend.TabIndex = 19;
            this.lblDocSend.Text = "...";
            this.lblDocSend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ilStatus
            // 
            this.ilStatus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilStatus.ImageStream")));
            this.ilStatus.TransparentColor = System.Drawing.Color.Transparent;
            this.ilStatus.Images.SetKeyName(0, "tick_no.gif");
            this.ilStatus.Images.SetKeyName(1, "tick_yes.gif");
            // 
            // lblConnectToServer
            // 
            this.lblConnectToServer.ImageList = this.ilStatus;
            this.lblConnectToServer.Location = new System.Drawing.Point(189, 51);
            this.lblConnectToServer.Name = "lblConnectToServer";
            this.lblConnectToServer.Size = new System.Drawing.Size(22, 22);
            this.lblConnectToServer.TabIndex = 18;
            this.lblConnectToServer.Text = "...";
            this.lblConnectToServer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDocLoadStatus
            // 
            this.lblDocLoadStatus.ImageList = this.ilStatus;
            this.lblDocLoadStatus.Location = new System.Drawing.Point(189, 22);
            this.lblDocLoadStatus.Name = "lblDocLoadStatus";
            this.lblDocLoadStatus.Size = new System.Drawing.Size(22, 22);
            this.lblDocLoadStatus.TabIndex = 17;
            this.lblDocLoadStatus.Text = "...";
            this.lblDocLoadStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Document Send:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Connected To Server:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Document Loaded:";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(12, 145);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(115, 54);
            this.cmdCancel.TabIndex = 16;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // pnlBusy
            // 
            this.pnlBusy.Controls.Add(this.lblBusyText);
            this.pnlBusy.Controls.Add(this.picBusy);
            this.pnlBusy.Location = new System.Drawing.Point(230, 143);
            this.pnlBusy.Name = "pnlBusy";
            this.pnlBusy.Size = new System.Drawing.Size(164, 56);
            this.pnlBusy.TabIndex = 21;
            this.pnlBusy.Visible = false;
            // 
            // lblBusyText
            // 
            this.lblBusyText.AutoSize = true;
            this.lblBusyText.Location = new System.Drawing.Point(52, 21);
            this.lblBusyText.Name = "lblBusyText";
            this.lblBusyText.Size = new System.Drawing.Size(95, 13);
            this.lblBusyText.TabIndex = 14;
            this.lblBusyText.Text = "Busy sending file...";
            // 
            // tDelay
            // 
            this.tDelay.Interval = 1000;
            this.tDelay.Tick += new System.EventHandler(this.tDelay_Tick);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Image = global::Liquid.Properties.Resources.refresh;
            this.cmdRefresh.Location = new System.Drawing.Point(426, 145);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(64, 54);
            this.cmdRefresh.TabIndex = 22;
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // picBusy
            // 
            this.picBusy.Image = ((System.Drawing.Image)(resources.GetObject("picBusy.Image")));
            this.picBusy.Location = new System.Drawing.Point(7, 10);
            this.picBusy.Name = "picBusy";
            this.picBusy.Size = new System.Drawing.Size(35, 40);
            this.picBusy.TabIndex = 20;
            this.picBusy.TabStop = false;
            // 
            // tSendDocument
            // 
            this.tSendDocument.Interval = 1000;
            this.tSendDocument.Tick += new System.EventHandler(this.tSendDocument_Tick);
            // 
            // SendToDepot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 373);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.pnlBusy);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdSendToServer);
            this.Controls.Add(this.txtLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SendToDepot";
            this.Text = "Send Document To Workstation";
            this.Load += new System.EventHandler(this.SendToDepot_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnlBusy.ResumeLayout(false);
            this.pnlBusy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBusy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblHostAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button cmdSendToServer;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDocSend;
        private System.Windows.Forms.Label lblConnectToServer;
        private System.Windows.Forms.Label lblDocLoadStatus;
        private System.Windows.Forms.ImageList ilStatus;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.PictureBox picBusy;
        private System.Windows.Forms.Panel pnlBusy;
        private System.Windows.Forms.Label lblBusyText;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.Timer tDelay;
        private System.Windows.Forms.Timer tSendDocument;
    }
}