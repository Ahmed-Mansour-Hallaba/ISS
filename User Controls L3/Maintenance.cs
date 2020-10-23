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
    public partial class Maintenance : UserControl
    {
        projectstored ps = new projectstored();
        int maintenance_id = -1;
        public static Maintenance _MUC3;
        public static Maintenance MUC3
        {
            get
            {
                if (_MUC3 == null)
                {
                    _MUC3 = new Maintenance();
                }
                return _MUC3;
            }
        }
        public Maintenance()
        {
            InitializeComponent();
            ps.fillcombo(cm_custname, ps.GetCustomers(), "CustomerName", "CustomerID", "Select Customer");
            ps.fillcombo(cm_maintenance, ps.GetEmployees(), "EmployeeName", "EmployeeID", "Select Employee Maintenance");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Employee definition uc
            AddUsercontrol form = new AddUsercontrol();
            form.panel2.Controls.Add(EmployeeDefintionUCL2.EDU2);
            form.ShowDialog();
        }

        private void btn_Addmanagement_Click(object sender, EventArgs e)
        {
            // Customers uc
            AddUsercontrol form = new AddUsercontrol();
            form.panel2.Controls.Add(CustomerDataUCL2.CDU2);
            form.ShowDialog();
        }
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
            if (s.SelectedIndex == -1 ||s.Text== "Select Customer" || s.Text== "Select Employee Maintenance")
            {
                MessageBox.Show(s.Name + "Field is required");
                s.Focus();
                return true;
            }
            else { return false; }

        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (SearchPanel.Width == 0)
            {
                SearchPanel.Width = 200;
            }
            else
            {
                SearchPanel.Width = 0;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchPanel.Width = 0;
        }
        public bool validatemobile(TextBox s)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(s.Text, "^01[0-5]{1}[0-9]{8}"))
            {
                MessageBox.Show(s.Name + " must be in mobile format 01012345678.");
                s.Focus();
                return true;

            }
            else { return false; }

        }
        int count = 1;
        private void btnsave_Click(object sender, EventArgs e)
        {

            if (validatecm(cm_custname)) { }
            else if (validatecm(cm_maintenance)) { }
            else if (validateTextBox(txtcost)) { }
            else if (validateTextBox(txtphone)) { }
            else if (validatemobile(txtphone)) { }
            else if (validateRichTextBox(rtb_harddescription)) { }
            else if (validateRichTextBox(rtb_whatwill)) { }
            else if (validateRichTextBox(rtbnotes)) { }
            else if (ps.InsertNewMaintenance(Convert.ToInt32(cm_custname.SelectedValue), Convert.ToInt32(cm_maintenance.SelectedValue), float.Parse(txtcost.Text), txtphone.Text, DTP_Deliver.Text, rtb_harddescription.Text, rtbnotes.Text))
            {
                MessageBox.Show("Maintenance added Successfully");
                btnnew_Click(sender, e);
                count += 1;
                label2.Text = count.ToString();
                cm_custname.Text = "Select Customer";
                cm_maintenance.Text = "Select Employee Maintenance";
            }
            else
            {
                MessageBox.Show("An Error Occurred");
            }


        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is TextBox || c is RichTextBox)
                {
                    c.Text = "";
                }
            }
            maintenance_id = -1;
        }

        private void txtcost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                MessageBox.Show("must be number");
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtphone_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtb_harddescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show( rtb_harddescription.Name+ " Must Be Text");
            }
        }

        private void rtb_whatwill_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show(rtb_whatwill.Name+ "Must Be Text");
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (validatecm(cm_custname)) { }
            else if (validatecm(cm_maintenance)) { }
            else if (validateTextBox(txtcost)) { }
            else if (validateTextBox(txtphone)) { }
            else if (validateRichTextBox(rtb_harddescription)) { }
            else if (validateRichTextBox(rtb_whatwill)) { }
            
            else { }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (validatecm(cm_custname)) { }
            else if (validatecm(cm_maintenance)) { }
            else if (validateTextBox(txtcost)) { }
            else if (validateTextBox(txtphone)) { }
            else if (validateRichTextBox(rtb_harddescription)) { }
            else if (validateRichTextBox(rtb_whatwill)) { }
            
            else { }
        }

        private void Maintenance_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void cm_custname_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetCustomers();
            if (cm_custname.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(cm_custname, ps.GetCustomers(), "CustomerName", "CustomerID", "Select Customer");

            }
        }

        private void cm_maintenance_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetEmployees();
            if (cm_maintenance.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(cm_maintenance, ps.GetEmployees(), "EmployeeName", "EmployeeID", "Select Employee");

            }
        }
    }
    }

