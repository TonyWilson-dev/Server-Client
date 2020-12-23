using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Packets;
using Client;
using System.Windows.Forms;

namespace gameClient
{
    public partial class GameClient : Form
    {


        public int m_x;
        public int m_y;

        public GameClient()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var gameUpdate = new LocalGameUpdate(clientPlayer.Left, clientPlayer.Top);          
        }

        private void GameClient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                clientPlayer.Top -= 1;
            }

            if (e.KeyCode == Keys.S)
            {
                clientPlayer.Top += 1;
            }

            if (e.KeyCode == Keys.A)
            {
                clientPlayer.Left -= 1;
            }
            if (e.KeyCode == Keys.D)
            {
                clientPlayer.Left += 1;
            }

        }

        private void otherClientPlayer_Click(object sender, EventArgs e)
        {

        }
    }
}
