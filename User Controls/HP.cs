using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class HP : UserControl
    {
        public static HP _HPUC1;

        public static HP HPUC1
        {
            get
            {
                if (_HPUC1 == null)
                {
                    _HPUC1 = new HP();
                }
                return _HPUC1;
            }
        }
        public HP()
        {
            InitializeComponent();
        }

        private void HP_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void bunifuGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
