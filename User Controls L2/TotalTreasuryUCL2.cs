using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.User_Controls_L2
{
    public partial class TotalTreasuryUCL2 : UserControl
    {
        private static TotalTreasuryUCL2 _TTrsUC;
        public static TotalTreasuryUCL2 TTrsUC
        {
            get
            {
                if (_TTrsUC == null)
                {
                    _TTrsUC = new TotalTreasuryUCL2();
                }
                return _TTrsUC;
            }
        }
        public TotalTreasuryUCL2()
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

        private void TotalTreasuryUCL2_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchPanel.Width = 0;
        }
    }
}
