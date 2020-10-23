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
    public partial class OverTime : UserControl
    {
        int overtime_id = -1;
        projectstored ps = new projectstored();
        //Showing User Control Code 
        private static OverTime _OVTU3;
        public static OverTime OVTU3
        {
            get
            {
                if (_OVTU3 == null)
                {
                    _OVTU3 = new OverTime();
                }
                return _OVTU3;
            }
        }
        public OverTime()
        {
            InitializeComponent();
            // Fill Employee ComboBox
            DataTable dt1 = ps.GetEmployees();
            ps.fillcombo(cmbemployee, dt1, "EmployeeName", "EmployeeID", "select employee");
        }

        private void btn_Addmanagement_Click(object sender, EventArgs e)
        {
            //Employee definition uc
            AddUsercontrol form = new AddUsercontrol();
            form.panel2.Controls.Add(EmployeeDefintionUCL2.EDU2);
            form.ShowDialog();
        }
        //NewButton's Code
        private void btnnew_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is TextBox ||c is RichTextBox )
                {
                    c.Text = "";
                }
                if(c is ComboBox)
                {
                    c.Text = "No Employee";
                }
            }
            overtime_id= -1;
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
        // ValidateRichTextBox
        public bool validateRichTextBox(RichTextBox s)
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
            if (s.Text == "select employee")
            {
                MessageBox.Show(s.Name + "Field is required");
                s.Focus();
                return true;
            }
            else { return false; }

        }

        //SaveButton's Code
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (validatecm(cmbemployee)) { }
            else if (validateTextBox(txthour)) { }
            //else if (validateRichTextBox(rtbNotes)) { }
            else if (ps.InsertNewOverTime(cmbemployee.Text, dateTimePicker1.Text, int.Parse(txthour.Text), rtbNotes.Text))
            {
                MessageBox.Show("OverTime added Successfully");
                btnnew_Click(sender, e);
                cmbemployee.Text = "select employee";
            }
            else
            {
                MessageBox.Show("An Error Occurred");
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btndelete_Click(object sender, EventArgs e)
        {

        }

        private void txthour_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)&&!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("This Field Must Be Number");
            }
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
