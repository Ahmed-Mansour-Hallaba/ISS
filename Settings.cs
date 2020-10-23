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
    public partial class Settings : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        public Settings()
        {
            InitializeComponent();
        }


        private void Settings_Load(object sender, EventArgs e)
        {
            //settings
            //(this.Owner as Form1).leftpanel.BackColor = Properties.Settings.Default.left;
            //(this.Owner as Form1).flowLayoutPanel1.BackColor = Properties.Settings.Default.FS;
            //(this.Owner as Form1).Screenspanel.BackColor = Properties.Settings.Default.FS;
            //(this.Owner as Form1).panelbackgro.BackColor = Properties.Settings.Default.panelback;
            //(this.Owner as Form1).titlepanel.BackColor = Properties.Settings.Default.title;
            //this.title.BackColor= Properties.Settings.Default.title;
            //this.panel1.BackColor= Properties.Settings.Default.title;
            //this.button2.BackColor = Properties.Settings.Default.FS;

        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Properties.Settings.Default.left = (this.Owner as Form1).leftpanel.BackColor;
            //Properties.Settings.Default.FS = (this.Owner as Form1).flowLayoutPanel1.BackColor;
            //Properties.Settings.Default.FS = (this.Owner as Form1).Screenspanel.BackColor;
            //Properties.Settings.Default.panelback = (this.Owner as Form1).panelbackgro.BackColor;
            //Properties.Settings.Default.title = (this.Owner as Form1).titlepanel.BackColor;
            //this.title.BackColor = Properties.Settings.Default.title;
            //this.panel1.BackColor = Properties.Settings.Default.title;
            //this.button2.BackColor = Properties.Settings.Default.FS;
            //Properties.Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void Exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void titlepanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        Point lastPoint;
        private void titlepanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //(this.Owner as Form1).leftpanel.BackColor = Color.FromArgb(1, 28, 45);
            //(this.Owner as Form1).flowLayoutPanel1.BackColor = Color.FromArgb(1, 28, 45);
            //(this.Owner as Form1).Screenspanel.BackColor = Color.FromArgb(1, 28, 45);
            //(this.Owner as Form1).panelbackgro.BackColor = Color.FromArgb(1, 28, 45);
            //(this.Owner as Form1).titlepanel.BackColor = Color.FromArgb(31, 181, 172);
            //this.title.BackColor = Color.FromArgb(31, 181, 172);
            //this.panel1.BackColor = Color.FromArgb(31, 181, 172);
            //button2.FlatAppearance.BorderColor = Color.FromArgb(1, 28, 45);
            //button2.BackColor = Color.FromArgb(1, 28, 45);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //(this.Owner as Form1).leftpanel.BackColor = Color.FromArgb(0, 119, 162);
            //(this.Owner as Form1).flowLayoutPanel1.BackColor = Color.FromArgb(0, 119, 162);
            //(this.Owner as Form1).Screenspanel.BackColor = Color.FromArgb(0, 119, 162);
            //(this.Owner as Form1).panelbackgro.BackColor = Color.FromArgb(0, 119, 162);
            //(this.Owner as Form1).titlepanel.BackColor = Color.FromArgb(25, 31, 38);
            //this.title.BackColor = Color.FromArgb(25, 31, 38);
            //this.panel1.BackColor = Color.FromArgb(25, 31, 38);
            //button2.FlatAppearance.BorderColor = Color.FromArgb(0, 119, 162);
            //button2.BackColor = Color.FromArgb(0, 119, 162);

        }
    }
}
