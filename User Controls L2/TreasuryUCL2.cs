using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projectsp;
namespace Project.User_Controls_L2
{
    public partial class TreasuryUCL2 : UserControl
    {
        int treasury_id = -1;
        projectstored ps = new projectstored();
        private static TreasuryUCL2 _TrsUC;
        public static TreasuryUCL2 TrsUC
        {
            get
            {
                if (_TrsUC == null)
                {
                    _TrsUC = new TreasuryUCL2();
                }
                return _TrsUC;
            }
        }
        public TreasuryUCL2()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (SearchPanel.Width == 0)
            {
                SearchPanel.Width = 200;
            }
            else
            {
                SearchPanel.Width = 0;
            }
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            foreach (Control c in groupBox1.Controls)
            {
                if (c is TextBox)
                {
                   c.Text = "0";
                }
            }
            foreach (Control c in groupBox_Treasury.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "0";
                }
            }
            treasury_id = -1;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchPanel.Width = 0;
        }

        private void TreasuryUCL2_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }
    }
}
