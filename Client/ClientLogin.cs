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
    public partial class ClientLogin : Form
    {
        private TCP_Client m_client;
        public ClientLogin(TCP_Client client)
        {
            InitializeComponent();
            m_client = client;
            Console.WriteLine("Login form created");
        }

        public ClientLogin()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
