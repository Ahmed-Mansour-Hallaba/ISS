using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using projectsp;
namespace Project.User_Controls_L2
{
    public partial class Bond : UserControl
    {
        //Showing UserControl Code
        private static Bond _BU2;
        public static Bond BU2
        {
            get
            {
                if (_BU2 == null)
                {
                    _BU2 = new Bond();
                }
                return _BU2;
            }
        }
        int bond_id = -1;
        projectstored ps = new projectstored();

        public Bond()
        {
            InitializeComponent();
            autocomplete();

            // Fill Vendor ComboBox
            DataTable dt1 = ps.GetVendor();
            DataRow dr1 = dt1.NewRow();
            dr1["Name"] = "No Vendor";
            dr1["VendorID"] = -1;
            dt1.Rows.InsertAt(dr1, 0);
            cmbvendor.DataSource = dt1;
            cmbvendor.DisplayMember = "Name";
            cmbvendor.ValueMember = "VendorID";
            cmbvendor.BindingContext = this.BindingContext;
            // Fill Customer ComboBox
            /*  
              DataTable dt2 = ps.GetCustomerGroups();
              DataRow dr2 = dt2.NewRow();
              dr2["Name"] = "No Customer";
              dr2["CustomerGroupID"] = -1;
              dt2.Rows.InsertAt(dr2, 0);
              cmbcustomer.DataSource = dt2;
              cmbcustomer.DisplayMember = "Name";
              cmbcustomer.ValueMember = "CustomerGroupID";
              cmbcustomer.BindingContext = this.BindingContext;
              */
            ps.fillcombo(cmbcustomer, ps.GetCustomers(), "CustomerName", "CustomerID", "Select customer");
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
            if (s.SelectedIndex == -1 )
            {
                MessageBox.Show(s.Name + "Field is required");
                s.Focus();
                return true;
            }
            else if (cmbbondto.Text == "Vendor" && s.Text == "No Vendor")
            {
                MessageBox.Show(s.Name + "Field is required");
                s.Focus();
                return true;
            }
            else if (cmbbondto.Text == "Customer" &&  s.Text == "No Customer")
            {
                MessageBox.Show(s.Name + "Field is required");
                s.Focus();
                return true;
            }
            else { return false; }

        }
        //AutoComplete Function
        public void autocomplete()
        {
            txtsearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtsearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            DataTable dt = ps.GetBondData();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string name = dt.Rows[i]["Amount"].ToString();
                col.Add(name);
            }
            txtsearch.AutoCompleteCustomSource = col;
        }
        //SaveButton's Code
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (validatecm(cmbbondtype)) { }
            else if (validatecm(cmbbondto)) { }
            else if (validatecm(cmbvendor)) { }
            else if (validatecm(cmbcustomer)) { }
            else if (validateTextBox(txtamount)) { }
            
            else if (ps.InsertNewBondData(cmbbondtype.SelectedItem.ToString(), cmbbondto.SelectedItem.ToString(), Convert.ToInt32(cmbvendor.SelectedValue), Convert.ToInt32(cmbcustomer.SelectedValue), double.Parse(txtamount.Text), rtbnotes.Text))
            {
                MessageBox.Show("Bond Data added Successfully");
                btn_New_Click(sender, e);
            }
            else
            {
                MessageBox.Show("An Error Occurred");
            }
            autocomplete();
        }
        //NewButton's Code
        private void btn_New_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is TextBox || c is RichTextBox)
                {
                    c.Text = "";
                }
            }
           bond_id = -1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbbondto.Text=="Vendor")
            {
                cmbcustomer.Enabled = false;
            }
            else
                cmbcustomer.Enabled = true;
            if (cmbbondto.Text == "Customer")
            {
                cmbvendor.Enabled = false;
            }
            else
                cmbvendor.Enabled = true;
        }
        //SearchButton's Code
        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txtsearch)) { }
            else
            {
                DataTable dt = ps.GetBondData("Amount", txtsearch.Text);
                if (dt.Rows.Count == 1)
                {
                    bond_id = int.Parse(dt.Rows[0][0].ToString());
                    cmbbondtype.Text = dt.Rows[0][1].ToString();
                    cmbbondto.Text = dt.Rows[0][2].ToString();
                    cmbvendor.SelectedValue = dt.Rows[0][3].ToString();
                    cmbcustomer.SelectedValue = dt.Rows[0][4].ToString();
                    txtamount.Text = dt.Rows[0][5].ToString();
                    dateTimePicker1.Text = dt.Rows[0][6].ToString();
                    rtbnotes.Text = dt.Rows[0][7].ToString();

                    SearchButton_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("This Amount Not Found");
                }
            }
        }
        //UpdateButton's Code
        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (validatecm(cmbbondtype)) { }
            else if (validatecm(cmbbondto)) { }
            else if (validatecm(cmbvendor)) { }
            else if (validatecm(cmbcustomer)) { }
            else if (validateTextBox(txtamount)) { }
            
            else if (ps.UpdateBondData(bond_id, cmbbondtype.SelectedItem.ToString(), cmbbondto.SelectedItem.ToString(), Convert.ToInt32(cmbvendor.SelectedValue), Convert.ToInt32(cmbcustomer.SelectedValue), double.Parse(txtamount.Text), rtbnotes.Text))
            {
                MessageBox.Show("Bond Data Updated Successfully");
                btn_New_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Your Update Operation Failed");
            }
            autocomplete();
        }
        //DeleteButton's Code
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (validatecm(cmbbondtype)) { }
            else if (validatecm(cmbbondto)) { }
            else if (validatecm(cmbvendor)) { }
            else if (validatecm(cmbcustomer)) { }
            else if (validateTextBox(txtamount)) { }
           
            else
            {
                try
                {
                    ps.DeleteBondData(bond_id);
                    MessageBox.Show("Bond deleted Successfully");
                    btn_New_Click(sender, e);
                }
                catch (SqlException)
                {
                    MessageBox.Show("Your Delete Operation Failed");
                }
            }
        }

        private void txtamount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchPanel.Width = 0;
        }

        private void Bond_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void cmbvendor_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetVendor();
            if (cmbvendor.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(cmbvendor, ps.GetBank(), "Name", "VendorID", "Select Vendor");

            }
        }

        private void cmbcustomer_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetCustomers();
            if (cmbcustomer.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(cmbcustomer, ps.GetCustomers(), "CustomerName", "CustomerID", "Select Customer");
            }
        }
    }
}
