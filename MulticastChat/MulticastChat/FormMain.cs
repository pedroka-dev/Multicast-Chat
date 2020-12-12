using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MulticastChat
{
    public partial class FormMain : Form
    {
        private const int TIME_TO_LIVE = 50;
        private UdpClient client = null;
        private IPAddress group = null;
        private int port = 0;
        private IPEndPoint multiCastEP = null;
        private bool stayAlive = true;
        private Thread receiveThread = null;
        private string defaultNameText = "";
        public delegate void dListOngoing(string message);
        public dListOngoing listOngoing;

        private void SendMessage(String message)
        {
            Byte[] buff;
            buff = Encoding.ASCII.GetBytes(textBoxUserName.Text + ": " + message);
            client.Send(buff, buff.Length, multiCastEP);
            textBoxNewMessage.Text = "";
        }

        private void JoinGroup()
        {
            //try
            //{

                if (!int.TryParse(textBoxPort.Text, out port))
                    throw new ApplicationException("Invalid Port Number");
                if (!IPAddress.TryParse(textBoxAddress.Text, out group))
                    throw new ApplicationException("Invalid Multicast Group Address");

                client = new UdpClient(port);
                client.JoinMulticastGroup(group, TIME_TO_LIVE);
                multiCastEP = new IPEndPoint(group, port);
                this.stayAlive = true;
                receiveThread = new Thread(this.runThread);
                receiveThread.Start();
                this.SendMessage("has joined the chat!");
                //this.AcceptButton = buttonSend;
                //this.CancelButton = buttonEnd;
                //this.buttonJoin.Enabled = false;
                //this.buttonEnd.Enabled = true;
                //this.buttonSend.Enabled = true;
                textBoxNewMessage.Focus();
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show("An error occured while joining:\n" + e.Message, "Connection Error");
            //    this.Dispose();
            //}
        }

        private void LeaveGroup()
        {
            if (group != null)
            {
                SendMessage("Leaving Chat");
                Application.DoEvents();
                Thread.Sleep(500);
                stayAlive = false;
                while (receiveThread.IsAlive) Application.DoEvents();
                receiveThread.Join();
                client.DropMulticastGroup(group);
                client.Close();
                client = null;
                group = null;
                multiCastEP = null;
            }
        }

        private void runThread()
        {
            Byte[] buff;
            String message;
            IPEndPoint ep = multiCastEP;

            while (stayAlive)
            { 
                buff = client.Receive(ref ep);
                message = Encoding.ASCII.GetString(buff);
                this.Invoke(this.listOngoing, message);
                Thread.Sleep(10);
            }
        }

        public void displayMessage(string message)
        {
            listBoxMessageChat.Items.Add(message);
            listBoxMessageChat.Refresh();
        }

        public FormMain()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBoxChat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPort_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxUseEncryption_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUseEncryption.Checked)
            {
                textBoxKey.Enabled = true;
            }
            else
            {
                textBoxKey.Enabled = false;
                textBoxKey.Clear();
            }
        }

        private void labelNewMessage_Click(object sender, EventArgs e)
        {

        }

        private void textBoxKey_TextChanged(object sender, EventArgs e)
        {
            textBoxKey.Text = textBoxKey.Text.Replace(" ", "");
        }

        private void labelPort_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            defaultNameText = textBoxUserName.Text;
            this.textBoxPort.Text = "" + 10002;
            this.textBoxAddress.Text = "224.0.0.251";
            textBoxNewMessage.Focus();
            listOngoing = new dListOngoing(displayMessage);
        }

        private void buttonJoin_Click(object sender, EventArgs e)
        {
            if (textBoxUserName.Text.Length == 0 || textBoxAddress.Text.Length == 0 || textBoxPort.Text.Length == 0)
            {
                MessageBox.Show("Fields 'User Name', 'Address' and 'Port' cannot be blank.", "Invalid Arguments");
            }
            else
            {
                this.JoinGroup();

                buttonExit.Enabled = true;
                listBoxMessageChat.Enabled = true;
                textBoxNewMessage.Enabled = true;
                buttonSend.Enabled = true;
                buttonJoin.Enabled = false;

                MessageBox.Show("Joined the Chat room.", "Login sucessfull");
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.LeaveGroup();

            buttonExit.Enabled = false;
            listBoxMessageChat.Enabled = false;
            textBoxNewMessage.Enabled = false;
            buttonSend.Enabled = false;
            buttonJoin.Enabled = true;
        }

        private void labelKey_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void labelMessageChat_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxAddress_TextChanged(object sender, EventArgs e)
        {
            textBoxAddress.Text = textBoxAddress.Text.Replace(" ", "");
        }

        private void labelAddress_Click(object sender, EventArgs e)
        {

        }

        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {
            textBoxUserName.Text = textBoxUserName.Text.Replace(" ", "");
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            this.SendMessage(textBoxNewMessage.Text);
        }

        private void textBoxNewMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.SendMessage(textBoxNewMessage.Text);
            }
        }
    }
}
