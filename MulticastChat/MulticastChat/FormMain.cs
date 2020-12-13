using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
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
        public delegate void dListOngoing(string message);
        public dListOngoing listOngoing;
        public bool useEncription;
        RijndaelManaged rijndaelEncryption = new RijndaelManaged();

        private void SendMessage(String message)
        {
            if (message.Length > 0)
            {
                Byte[] buff;
                if (useEncription)
                {
                    buff = EncryptStringToBytes(textBoxUserName.Text + ": " + message, rijndaelEncryption.Key, rijndaelEncryption.IV);
                }
                else 
                {
                    buff = Encoding.Unicode.GetBytes(textBoxUserName.Text + ": " + message);
                }
                client.Send(buff, buff.Length, multiCastEP);
                textBoxNewMessage.Text = "";
            }
        }

        private void JoinGroup()
        {
            if (!int.TryParse(textBoxPort.Text, out port))
                throw new ApplicationException("Invalid Port Number");
            if (!IPAddress.TryParse(textBoxAddress.Text, out group))
                throw new ApplicationException("Invalid Multicast Group Address");

            useEncription = checkBoxUseEncryption.Checked;

            if (useEncription)
            {
                byte[] key = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
                byte[] iv = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F};

                rijndaelEncryption.Key = key;
                rijndaelEncryption.IV = iv;
                //rijndaelEncryption.Key = Encoding.UTF32.GetBytes(textBoxKey.Text);
                //rijndaelEncryption.IV = Encoding.Unicode.GetBytes(textBoxKey.Text);
            }

            client = new UdpClient();
            client.Client.ExclusiveAddressUse = false;
            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            client.JoinMulticastGroup(group, TIME_TO_LIVE);
            multiCastEP = new IPEndPoint(group, port);
            client.Client.Bind(new IPEndPoint(IPAddress.Any, port));
            this.stayAlive = true;
            receiveThread = new Thread(this.runThread);
            receiveThread.Start();
            this.SendMessage("has joined the chat!");
            textBoxNewMessage.Focus();

        }

        private void LeaveGroup()
        {
            if (group != null)
            {
                SendMessage("Leaving Chat");
                Application.DoEvents();
                Thread.Sleep(500);
                stayAlive = false;
                Application.DoEvents();
                receiveThread.Abort();
                //while (receiveThread.IsAlive) Application.DoEvents();
                client.DropMulticastGroup(group);
                client.Close();
                client = null;
                group = null;
                multiCastEP = null;

                Thread.Sleep(500);
            }
        }

        private void runThread()
        {
            Byte[] buff;
            String message;
            IPEndPoint ep = null;

            while (stayAlive)
            { 
                buff = client.Receive(ref ep);
                if (useEncription)
                {
                    message = DecryptStringFromBytes(buff, rijndaelEncryption.Key, rijndaelEncryption.IV);
                }
                else
                {
                    message = Encoding.Unicode.GetString(buff);
                }
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

        private byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;
        }

        private string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            string plaintext = null;

            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
                try
                {
                    using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
                catch(Exception e)
                {
                    plaintext = Encoding.Unicode.GetString(cipherText);
                }
            }
            return plaintext;
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

        private void textBoxKey_TextChanged(object sender, EventArgs e)
        {
            textBoxKey.Text = textBoxKey.Text.Replace(" ", "");
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
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
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.LeaveGroup();

            listBoxMessageChat.Items.Clear();
            buttonExit.Enabled = false;
            listBoxMessageChat.Enabled = false;
            textBoxNewMessage.Enabled = false;
            buttonSend.Enabled = false;
            buttonJoin.Enabled = true;
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

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.LeaveGroup();
        }
    }
}
