using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.User_Controls_L3
{
    public partial class Return_Purchased_Invoice : UserControl
    {
        public static Return_Purchased_Invoice _RPIUC3;
        public static Return_Purchased_Invoice RPIUC3
        {
            get
            {
                if (_RPIUC3 == null)
                {
                    _RPIUC3 = new Return_Purchased_Invoice();
                }
                return _RPIUC3;
            }
        }
        public Return_Purchased_Invoice()
        {
         //   InitializeComponent();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
           /* if (SearchPanel.Width == 0)
            {
                SearchPanel.Width = 200;
            }
            else
            {
                SearchPanel.Width = 0;
            }*/
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //SearchPanel.Width = 0;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {

        }
    }
}
