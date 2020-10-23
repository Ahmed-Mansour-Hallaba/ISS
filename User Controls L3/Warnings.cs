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
using Project.User_Controls_L2;

namespace Project.User_Controls_L3
{
    public partial class Warnings : UserControl
    {
        projectstored ps = new projectstored();
        int warning_id = -1;
        private static Warnings _WarnU3;
        public static Warnings WarnU3
        {
            get
            {
                if (_WarnU3 == null)
                {
                    _WarnU3 = new Warnings();
                }
                return _WarnU3;
            }
        }
        public Warnings()
        {
            InitializeComponent();
        }

        private void btn_Addmanagement_Click(object sender, EventArgs e)
        {
            AddUsercontrol form = new AddUsercontrol();
            form.panel2.Controls.Add(EmployeeDefintionUCL2.EDU2);
            form.ShowDialog();
        }
        //validate TextBox
        public bool validateTextBox(TextBox s)
        {
            if (s.Text == "")
            {
                MessageBox.Show(s.Name + "Field is required");
                s.Focus();
                return true;
            }
            else { return false; }
        }
        //Validatecombobox
        public bool validatecm(ComboBox s)
        {
            if (s.SelectedIndex == -1 || s.Text== "No Employee")
            {
                MessageBox.Show(s.Name + "Field is required");
                s.Focus();
                return true;
            }
            else { return false; }

        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (validatecm(cmbemployee)) { }
            else if (validateTextBox(txtwarning)) { }
            else if (ps.InsertNewWarning(Convert.ToInt32(cmbemployee.SelectedValue), txtwarning.Text, rtbnotes.Text))
            {
                MessageBox.Show("Warning added Successfully");
                btnnew_Click(sender, e);
                cmbemployee.Text = "No Employee";
            }
            else
            {
                MessageBox.Show("An Error Occured");
            }
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is RichTextBox||c is TextBox)
                {
                    c.Text = "";
                }
            }
        }

        private void Warnings_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {

        }

        private void cmbemployee_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetEmployees();
            if (cmbemployee.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(cmbemployee, ps.GetEmployees(), "EmployeeName", "EmployeeID", "Select Employee");

            }
        }
    }
}
