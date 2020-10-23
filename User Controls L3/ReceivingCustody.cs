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
    public partial class ReceivingCustody : UserControl
    {
        //Showing UserControl Code
        private static ReceivingCustody _RCU3;
        public static ReceivingCustody RCU3
        {
            get
            {
                if (_RCU3 == null)
                {
                    _RCU3 = new ReceivingCustody();
                }
                return _RCU3;
            }
        }
        int recievingcustody_id = -1;
        projectstored ps = new projectstored();

        public ReceivingCustody()
        {
            InitializeComponent();
            // Fill Employee ComboBox
            DataTable dt1 = ps.GetEmployees();
            DataRow dr1 = dt1.NewRow();
            dr1["EmployeeName"] = "No Employee";
            dr1["EmployeeID"] = -1;
            dt1.Rows.InsertAt(dr1, 0);
            cmbemployee.DataSource = dt1;
            cmbemployee.DisplayMember = "EmployeeName";
            cmbemployee.ValueMember = "EmployeeID";
            cmbemployee.BindingContext = this.BindingContext;
            //Fill Item Name ComboBox
            DataTable dt2 = ps.GetItemGroup();
            DataRow dr2 = dt2.NewRow();
            dr2["Name"] = "No Item";
            dr2["ItemGroupID"] = -1;
            dt2.Rows.InsertAt(dr2, 0);
            cmbItemname.DataSource = dt2;
            cmbItemname.DisplayMember = "Name";
            cmbItemname.ValueMember = "ItemGroupID";
            cmbItemname.BindingContext = this.BindingContext;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //-------add Employee defination UC
            AddUsercontrol form = new AddUsercontrol();
            form.panel2.Controls.Add(EmployeeDefintionUCL2.EDU2);
            form.ShowDialog();
        }

        private void btn_Addmanagement_Click(object sender, EventArgs e)
        {
            //--------add Item Defination UC
            AddUsercontrol form = new AddUsercontrol();
            form.panel2.Controls.Add(ItemDefinitionUCL2.IDU2);
            form.ShowDialog();
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
                if (c is ComboBox)
                {
                    c.Text = " "; 
                }
            }
            recievingcustody_id= -1;
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
            if (s.Text == "No Employee" ||s.Text== "No Item") 
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
            else if (validatecm(cmbItemname)) { }
            //else if (validateRichTextBox(rtbnotes)) { }
            else if (ps.InsertNewReceivingCustody(Convert.ToInt32(cmbemployee.SelectedValue), Convert.ToInt32(cmbItemname.SelectedValue),this.dateTimePicker1.Text, rtbnotes.Text))
            {
                MessageBox.Show("Custody added Successfully");
                btnnew_Click(sender, e);
                cmbemployee.Text = "No Employee";
                cmbItemname.Text = "No Item";
            }
            else
            {
                MessageBox.Show("An Error Occurred");
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {

        }

        private void ReceivingCustody_Load(object sender, EventArgs e)
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

        private void cmbItemname_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetItems();
            if (cmbItemname.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(cmbItemname, ps.GetItems(), "ItemName", "ItemID", "Select Item");

            }
        }
    }
}
