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
namespace Project.User_Controls_L3
{
    public partial class Vacations : UserControl
    {
        private static Vacations _VACU3;
        public static Vacations VACU3
        {
            get
            {
                if (_VACU3 == null)
                {
                    _VACU3 = new Vacations();
                }
                return _VACU3;
            }
        }
        int vacations_id = -1;
        projectstored ps = new projectstored();
        public Vacations()
        {
            InitializeComponent();
            // Fill Employee ComboBox
            DataTable dt1 = ps.GetEmployees();
            ps.fillcombo(cmbemployee, dt1, "EmployeeName", "EmployeeID", "select employee");

            DataTable dt2 = ps.GetVacationTypes();
            ps.fillcombo(cmbtype, dt2, "Name", "TypeID", "Select Vacation type");


        }



        private void btnnew_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is RichTextBox)
                {
                    c.Text = "";
                }
                if (c is ComboBox)
                {
                    cmbemployee.Text = "No Employee";
                    cmbtype.Text = " ";
                }
            }
            vacations_id = -1;
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
            if (s.Text == "select employee"  || s.Text== "Select Vacation type")
            {
                MessageBox.Show(s.Name + "Field is required" );
                s.Focus();
                return true;
            }
            else { return false; }

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (validatecm(cmbemployee)) { }
            else if (validatecm(cmbtype)) { }
            //else if (validateRichTextBox(rtbnotes)) { }
            else if (ps.InsertNewVacation(Convert.ToInt32(cmbtype.SelectedValue), Convert.ToInt32(cmbemployee.SelectedValue), this.dateTimePicker1.Text, this.dateTimePicker2.Text, rtbnotes.Text))
            {
                MessageBox.Show("Vacation added Successfully");
                cmbemployee.Text = "select employee";
                cmbtype.Text = "Select Vacation type";

            }
            else MessageBox.Show("Vacation added Failed");

        }

        private void Vacations_Load(object sender, EventArgs e)
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
