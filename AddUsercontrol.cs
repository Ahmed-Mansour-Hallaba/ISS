using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class AddUsercontrol : Form
    {
        const int CS_DBLCLKS = 0x8;
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                cp.ClassStyle |= CS_DBLCLKS;
                return cp;
            }
        }
        public AddUsercontrol()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AddUsercontrol_Load(object sender, EventArgs e)
        {
            this.Refresh();
        }
        private void AddUsercontrol_FormClosing(object sender, FormClosingEventArgs e)
        {
            panel2.Controls.Clear();
        }
    }
}
