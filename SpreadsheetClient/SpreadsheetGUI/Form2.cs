using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpreadsheetGUI
{
    public partial class ConnectScreen : Form
    {
        public event Action<string, string> connect;

        public ConnectScreen()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect(IPAddressText.Text, PortNumberText.Text);
        }

    }
}
