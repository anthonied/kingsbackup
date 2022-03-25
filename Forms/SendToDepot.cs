using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Liquid.Forms
{
    public partial class SendToDepot : Form
    {
        public string sFilename = "";
        public string sHostAddress = "";
        public string sFtpUsername = "";
        public string sFtpPassword = "";
        public int iDelay = 0;
        TcpClient tcpClient;
        FileStream fstFile;
        NetworkStream strRemote;
        FileInfo fInfo;

        public SendToDepot()
        {
            InitializeComponent();
        }

        private void ConnectToServer()
        {
            // Create a new instance of a TCP client
            tcpClient = new TcpClient();
            try
            {
                // Connect the TCP client to the specified IP and port
                tcpClient.Connect(sHostAddress, 815);
                txtLog.Text += "Successfully connected to server\r\n";
                lblStatus.Text = "Connected to server";
                lblConnectToServer.ImageIndex = 1;
                lblConnectToServer.Text = "";
                cmdSendToServer.Enabled = true;
                tSendDocument.Enabled = true;
            }
            catch (Exception exMessage)
            {
                // Display any possible error
                lblStatus.Text = "Error in connection";
                txtLog.Text += exMessage.Message + "\r\n";
                lblConnectToServer.ImageIndex = 0;
                lblConnectToServer.Text = "";
                cmdSendToServer.Enabled = false;
            }
        }

        private void SendToDepot_Load(object sender, EventArgs e)
        {
            fInfo = new FileInfo(sFilename);
            lblFilename.Text = fInfo.Name;
            lblDocLoadStatus.ImageIndex = 1;
            lblDocLoadStatus.Text = "";
            tcpClient = new TcpClient();
            ConnectToServer();
            
        }

        private void SendFile()
        {
            // If tclClient is not connected, try a connection
            if (tcpClient.Connected == false)
            {
                // Call the ConnectToServer method and pass the parameters entered by the user
                ConnectToServer();
            }
            tSendDocument.Enabled = false;
         
                txtLog.Text += "Sending file indicator\r\n";
                // Get a stream connected to the server
                strRemote = tcpClient.GetStream();
            

                if (Upload())
                {
                    string FileName = fInfo.Name;
                    // Store the file name as a sequence of bytes
                    byte[] ByteFileName = new byte[2048];
                    ByteFileName = System.Text.Encoding.ASCII.GetBytes(FileName.ToCharArray());
                    // Write the sequence of bytes (the file name) to the network stream
                    strRemote.Write(ByteFileName, 0, ByteFileName.Length);

                    // Get and store the file size
                    long FileSize = fInfo.Length;
                    // Store the file size as a sequence of bytes
                    byte[] ByteFileSize = new byte[2048];
                    ByteFileSize = System.Text.Encoding.ASCII.GetBytes(FileSize.ToString().ToCharArray());
                    // Write the sequence of bytes (the file size) to the network stream
                    strRemote.Write(ByteFileSize, 0, ByteFileSize.Length);
                    txtLog.Text += "Sending the file " + fInfo.Name + "(" + fInfo.Length + "bytes)\r\n";

                    txtLog.Text += "File sent. Closing streams and connections.\r\n";
                    // Update the log textbox and close the connections and streams
                    lblDocSend.ImageIndex = 1;
                }
                else
                {
                    lblDocSend.ImageIndex = 1;
                    txtLog.Text = "Error";
                }
                lblDocSend.Text = "";
             
                tcpClient.Close();
                strRemote.Close();            
                txtLog.Text += "Streams and connections are now closed.\r\n";
                tDelay.Enabled = true;
                lblBusyText.Text = "Closing ...";
            
        }

        private void cmdSendToServer_Click(object sender, EventArgs e)
        {
            pnlBusy.Visible = true;
            SendFile();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            try
            {
                strRemote.Close();    
            }
            catch
            {

            }
            try
            {
                tcpClient.Close();            
            }
            catch
            {

            }
            try
            {
                fstFile.Close();
            }
            catch
            {

            }
            tDelay.Enabled = true; 
            txtLog.Text += "Disconnected from server.\r\n";
            lblBusyText.Text = "Disconnecting...";
            pnlBusy.Visible = true;
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            ConnectToServer();
        }

        private void tDelay_Tick(object sender, EventArgs e)
        {
            iDelay++;
            if (iDelay >= 5)
            {
                tDelay.Enabled = false;
                this.Close();
            }
        }

        private bool Upload()
        {

            string uri = "ftp://" + sHostAddress + "/" + fInfo.Name;
            FtpWebRequest reqFTP;

            // Create FtpWebRequest object from the Uri provided
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + sHostAddress + "/" + fInfo.Name));

            // Provide the WebPermission Credintials
            reqFTP.Credentials = new NetworkCredential(sFtpUsername, sFtpPassword);

            // By default KeepAlive is true, where the control connection is not closed
            // after a command is executed.
            reqFTP.KeepAlive = false;

            // Specify the command to be executed.
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

            // Specify the data transfer type.
            reqFTP.UseBinary = true;

            // Notify the server about the size of the uploaded file
            reqFTP.ContentLength = fInfo.Length;

            // The buffer size is set to 2kb
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;

            // Opens a file stream (System.IO.FileStream) to read the file to be uploaded
            FileStream fs = fInfo.OpenRead();

            try
            {
                // Stream to which the file to be upload is written
                Stream strm = reqFTP.GetRequestStream();

                // Read from the file stream 2kb at a time
                contentLen = fs.Read(buff, 0, buffLength);

                // Till Stream content ends
                while (contentLen != 0)
                {
                    // Write Content from the file stream to the FTP Upload Stream
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }

                // Close the file stream and the Request Stream
                strm.Close();
                fs.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Upload Error");
                return false;
            }
        }

        private void tSendDocument_Tick(object sender, EventArgs e)
        {
            SendFile();
        }

    }
}