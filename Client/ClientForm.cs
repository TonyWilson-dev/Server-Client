using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientForm : Form
    {
        private TCP_Client m_client;
        private string m_NickName;
        public string m_Message;
        public Packets.ChatMessagePacket m_ChatMessage;
      
       public ClientForm(TCP_Client client) 
        {
            InitializeComponent();
            m_client = client;           
        }

        public void UpdateChatWindow(string message)
        {
            if(MessageWindow.InvokeRequired) // ??
            {
                Invoke(new Action(() =>
              {
                  UpdateChatWindow(message);
              }));
            }
            else
            {
                MessageWindow.Text += message + Environment.NewLine;
                MessageWindow.SelectionStart = MessageWindow.Text.Length;
                MessageWindow.ScrollToCaret();
            }

        }
       
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (m_NickName == null)
            {
                MessageWindow.Text = "Please put in a nickname and join the server";
            }
            else
            {
                var chatMessage = new Packets.ChatMessagePacket(m_Message);
                chatMessage.m_PacketType = 0;
                m_client.TCP_SendMessage(chatMessage); //implement method in client class
                InputField.Text = ("");
            }
        }

        private void InputField_TextChanged(object sender, EventArgs e)
        {
            m_Message = InputField.Text;
        }

        private void MessageWindow_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void joinButton_Click(object sender, EventArgs e)
        {
            var setNickName = new Packets.SetNickName(nicknameTextBox.Text);
            m_client.TCP_SendMessage(setNickName); //implement method in client class
            m_NickName = nicknameTextBox.Text;
            introLabel.Text = ("Your nick name is: " + nicknameTextBox.Text);
            joinButton.Hide();
            
            /*
            DMbutton.Show();
            DMIntro.Show();
            nicknameTextBox.Text = "";
            */
        }

        private void introLabel_Click(object sender, EventArgs e)
        {

        }

        private void DMbutton_Click(object sender, EventArgs e)
        {
            var DM = new Packets.PrivateMessage(InputField.Text, nicknameTextBox.Text, m_NickName);
            m_client.TCP_SendMessage(DM);
            InputField.Text = "";
            nicknameTextBox.Text = "";
        }
    }
}
