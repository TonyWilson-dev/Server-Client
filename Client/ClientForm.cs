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

        public string m_Message;

        public Packets.ChatMessagePacket m_ChatMessage;

        public ClientForm()
        {
            InitializeComponent();
        }

        
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
            var m_ChatMessage = new Packets.ChatMessagePacket(m_Message);
            m_ChatMessage.m_PacketType = 0;
            m_client.TCP_SendMessage(m_ChatMessage); //implement method in client class
            InputField.Text = ("");
        }

        private void InputField_TextChanged(object sender, EventArgs e)
        {
            m_Message = InputField.Text;
        }

        private void MessageWindow_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
