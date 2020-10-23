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
using System.Data.SqlClient;

namespace Project.User_Controls_L3
{
    public partial class Attendances : UserControl
    {
        //Showing UserControl Code
        private static Attendances _ATEN3;
        public static Attendances ATEN3
        {
            get
            {
                if (_ATEN3 == null)
                {
                    _ATEN3 = new Attendances();
                }
                return _ATEN3;
            }
        }
        int attendance_id = -1;
        projectstored ps = new projectstored();
        public Attendances()
        {
            InitializeComponent();
            // Fill Employee ComboBox
            DataTable dt1 = ps.GetEmployees();
            ps.fillcombo(cmbemployee, dt1, "EmployeeName", "EmployeeID", "select employee");

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
        //SaveButton's Code
        private void btnsave_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (validatecm(cmbemployee)) { }
                else if (ps.InsertNewAttendance(Convert.ToInt32(cmbemployee.SelectedValue), dateTimePicker2.Text, rtb_Notes.Text))
                {
                    MessageBox.Show("Attendance Inserted Successfully");
                    btnnew_Click(sender, e);
                    cmbemployee.Text = "select employee";
                }
                else
                {
                    MessageBox.Show("An Error Occurred");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //NewButton's Code
        private void btnnew_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is TextBox || c is RichTextBox )
                {
                    c.Text = "";
                }
                if (c is ComboBox)
                {
                    c.Text = "No Employee";
                }
            }
            attendance_id = -1;
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            //DataTable dt = ps.GetAttendances("EmployeeID", txtsearch.Text);
            //if (dt.Rows.Count == 1)
            //{
            //    attendance_id = int.Parse(dt.Rows[0][0].ToString());
            //    cmbemployee.Text = dt.Rows[0][1].ToString();
            //    dateTimePicker1.Text = dt.Rows[0][2].ToString();
            //    dateTimePicker2.Text = dt.Rows[0][3].ToString();
            //    rtb_Notes.Text = dt.Rows[0][4].ToString();
            //    SearchButton_Click(sender, e);
            //}
            //else
            //{
            //    MessageBox.Show("attendence Not Found");
            //}
        }
        private void btndelete_Click(object sender, EventArgs e)
        {
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
        }

        private void Attendances_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
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
