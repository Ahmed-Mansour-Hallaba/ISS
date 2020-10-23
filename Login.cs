using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Login : Form
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
        public Login()
        {
            InitializeComponent();
            bunifuFormFadeTransition1.ShowAsyc(this);
            
        }
        projectsp.projectstored ps = new projectsp.projectstored();
        private void Loginbtn_Click(object sender, EventArgs e)
        {
            if (Nametxt.Text == "")
                MessageBox.Show("UserName is empty");
            else if (Passtxt.Text == "")
                MessageBox.Show("Password is empty");
            else
            {
                int id = ps.CheckLogin(Nametxt.Text, Passtxt.Text);
                if(id>0)
                {
                    Form1 f1 = new Form1();
                    f1.uid = id;
                    this.Hide();
                    Thread t = new Thread(new ThreadStart(StartForm));
                    t.Start();
                    Thread.Sleep(5000);
                    t.Abort();
                    f1.Show();
                }
                else
                {
                    MessageBox.Show("Invalid credentials");
                }
            }
            
        }
        public void StartForm()
        {
            Application.Run(new Start());
        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Passtxt.isPassword = true;
        }

        private void Passtxt_OnValueChanged(object sender, EventArgs e)
        {
            Passtxt.isPassword = true;
        }
    }
}
