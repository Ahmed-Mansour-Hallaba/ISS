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
    public partial class Start : Form
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
        public Start()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            bunifuFormFadeTransition1.ShowAsyc(this);
        }
    }
}
