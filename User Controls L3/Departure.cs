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
    public partial class Departure : UserControl
    {
        //Showing UserControl Code
        private static Departure _DEPTU3;
        public static Departure DEPTU3
        {
            get
            {
                if (_DEPTU3 == null)
                {
                    _DEPTU3 = new Departure();
                }
                return _DEPTU3;
            }
        }
        int depature_id = -1;
        projectstored ps = new projectstored();
        public Departure()
        {
            InitializeComponent();
            // Fill Employee ComboBox
            DataTable dt1 = ps.GetEmployees();
            ps.fillcombo(cmbemployee, dt1, "EmployeeName", "EmployeeID", "select employee");
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;

        }
        //NewButton's Code
        private void btnnew_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is RichTextBox)
                {
                    c.Text = "";
                }
            }
            depature_id = -1;
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
            else if (ps.InsertNewDeparture(Convert.ToInt32(cmbemployee.SelectedValue),dateTimePicker2.Text,rtbnotes.Text))
            {
                MessageBox.Show("Depature added Successfully");
                btnnew_Click(sender, e);
                cmbemployee.Text = "select employee";
            }
            else
            {
                MessageBox.Show("An Error Occurred");
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
           
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
        }

        private void Departure_Load(object sender, EventArgs e)
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
