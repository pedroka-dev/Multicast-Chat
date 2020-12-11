using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MulticastChat
{
    public partial class FormMain : Form
    {
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

        }

        private void buttonJoin_Click(object sender, EventArgs e)
        {
            if(textBoxUserName.Text.Length == 0 || textBoxAddress.Text.Length == 0 || textBoxPort.Text.Length == 0)
            {
                MessageBox.Show("Fields 'User Name', 'Address' and 'Port' cannot be blank.", "Invalid Arguments");
            }
            else
            {
                MessageBox.Show("Joined the Chat room.", "Login sucessfull");

                //Deve testar conexao antes de fazer essa parte
                buttonExit.Enabled = true;
                listBoxMessageChat.Enabled = true;
                textBoxNewMessage.Enabled = true;
                buttonSend.Enabled = true;
                buttonJoin.Enabled = false;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
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
    }
}
