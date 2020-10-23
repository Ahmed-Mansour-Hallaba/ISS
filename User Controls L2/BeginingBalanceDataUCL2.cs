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
namespace Project.User_Controls_L2
{
    public partial class BeginingBalanceDataUCL2 : UserControl
    {
        //Showing UserControl Code
        private static BeginingBalanceDataUCL2 _BBDU2;
        public static BeginingBalanceDataUCL2 BBDU2
        {
            get
            {
                if (_BBDU2 == null)
                {
                    _BBDU2 = new BeginingBalanceDataUCL2();
                }
                return _BBDU2;
            }
        }
        projectstored ps = new projectstored();
        int beginbalance_id = -1;
        public BeginingBalanceDataUCL2()
        {
            InitializeComponent();

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
            DataTable dt2 = ps.GetCustomers();
            DataRow dr2 = dt2.NewRow();
            dr2["CustomerName"] = "No Customer";
            dr2["CustomerID"] = -1;
            dt2.Rows.InsertAt(dr2, 0);
            cmbcust.DataSource = dt2;
            cmbcust.DisplayMember = "CustomerName";
            cmbcust.ValueMember = "CustomerID";
            cmbcust.BindingContext = this.BindingContext;
            autocomplete();
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
            else if (radioButton2.Checked==true && s.Text == "No Vendor")
            {
                MessageBox.Show(s.Name + "Field is required");
                s.Focus();
                return true;
            }
            else if (radioButton1.Checked==true && s.Text == "No Customer")
            {
                MessageBox.Show(s.Name + "Field is required");
                s.Focus();
                return true;
            }
            else { return false; }

        }
        bool validateRadioButton()
        {
            if(radioButton1.Checked==true && radioButton2.Checked == true)
            {
                MessageBox.Show("Musr checked Customer or vendors");
                return true;
            }
            else
            {
                return false;
            }
        }
        //AutoComplete Function
        public void autocomplete()
        {
            txtsearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtsearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            DataTable dt = ps.GetBegingBalances();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string name = dt.Rows[i]["Value"].ToString();
                col.Add(name);

            }
            txtsearch.AutoCompleteCustomSource = col;
        }
        //NewButton's Code
        private void btn_New_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
            beginbalance_id = -1;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                cmbcust.Enabled = true;
                cmbvendor.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                cmbcust.Enabled = false;
                cmbvendor.Enabled = true;
            }
        }
        //SaveButton's Code
        private void btn_Save_Click(object sender, EventArgs e)
        {
            //if (validateRadioButton()) { }
             if (validatecm(cmbcust)) { }
            else if(validatecm(cmbvendor)){ }
            else if (validatecm(cmbmovement)) { }
            else if (validateTextBox(txtvalue)) { }
            
            else if (radioButton1.Checked == true) 
            {
                if (cmbcust.Text == "" || cmbmovement.Text == "" || txtvalue.Text == "")
                {
                    MessageBox.Show("These Fields are Required");
                }
                else if (ps.InsertNewBegingBalance(radioButton1.Text, Convert.ToInt32(cmbvendor.SelectedValue), Convert.ToInt32(cmbcust.SelectedValue), cmbmovement.SelectedItem.ToString(), double.Parse(txtvalue.Text)))
                {
                    MessageBox.Show("Begining Balance Data added Successfully");
                    btn_New_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("An Error Occurred");
                }
            }
            else if (radioButton2.Checked == true)
            {
                if (cmbcust.Text == "" || cmbmovement.Text == "" || txtvalue.Text == "")
                {
                    MessageBox.Show("These Fields are Required");
                }
                else if (ps.InsertNewBegingBalance(radioButton2.Text, Convert.ToInt32(cmbvendor.SelectedValue), Convert.ToInt32(cmbcust.SelectedValue), cmbmovement.SelectedItem.ToString(), double.Parse(txtvalue.Text)))
                {
                    MessageBox.Show("Begining Balance Data added Successfully");
                    btn_New_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("An Error Occured");
                }
            }
            autocomplete();
        }
        //SearchButton's Code
        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txtsearch)) { }
            else
            {
                DataTable dt = ps.GetBegingBalances("Value", txtsearch.Text);
                if (dt.Rows.Count == 1)
                {
                    beginbalance_id = int.Parse(dt.Rows[0][0].ToString());
                    if (dt.Rows[0][1].ToString() == "Customer")
                    {
                        radioButton1.Select();
                        cmbvendor.Enabled = false;
                    }
                    else if (dt.Rows[0][1].ToString() == "Vendor")
                    {
                        radioButton2.Select();
                        cmbcust.Enabled = false;
                    }

                    cmbvendor.Text = dt.Rows[0][2].ToString();
                    cmbcust.Text = dt.Rows[0][3].ToString();
                    cmbmovement.Text = dt.Rows[0][4].ToString();
                    DTPicker.Text = dt.Rows[0][5].ToString();
                    txtvalue.Text = dt.Rows[0][6].ToString();
                    SearchButton_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("This Value Not Found");
                }
            }
        }
        //DeleteButton's Code
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            
             if (validatecm(cmbcust)) { }
            else if (validatecm(cmbvendor)) { }
            else if (validatecm(cmbmovement)) { }
            else if (validateTextBox(txtvalue)) { }
            else
            {
                try
                {
                    ps.DeleteBegingBalance(beginbalance_id);
                    MessageBox.Show("Balance deleted Successfully");
                    btn_New_Click(sender, e);
                }
                catch (SqlException)
                {
                    MessageBox.Show("An Error Occured");
                }
            }
        }
        //UpdateButton's Code
        private void btn_Update_Click(object sender, EventArgs e)
        {
          
             if (validatecm(cmbcust)) { }
            else if (validatecm(cmbvendor)) { }
            else if (validatecm(cmbmovement)) { }
            else if (validateTextBox(txtvalue)) { }
            else if (radioButton1.Checked == true)
            {
                if (cmbcust.Text == "" || cmbmovement.Text == "" || txtvalue.Text == "")
                {
                    MessageBox.Show("These Fields are Required");
                }
               else if (ps.UpdateBegingBalance(beginbalance_id, radioButton1.Text, Convert.ToInt32(cmbvendor.SelectedValue), Convert.ToInt32(cmbcust.SelectedValue), cmbmovement.SelectedItem.ToString(), double.Parse(txtvalue.Text)))
                {
                    MessageBox.Show("Balance Updated Successfully");
                    btn_New_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("An Error Occurred");
                }
            }
            else if (radioButton2.Checked == true)
            {
                if (cmbvendor.Text == "" || cmbmovement.Text == "" || txtvalue.Text == "")
                {
                    MessageBox.Show("These Fields are Required");
                }
                else if (ps.UpdateBegingBalance(beginbalance_id, radioButton2.Text, Convert.ToInt32(cmbvendor.SelectedValue), Convert.ToInt32(cmbcust.SelectedValue), cmbmovement.SelectedItem.ToString(), double.Parse(txtvalue.Text)))
                {
                    MessageBox.Show("Balance Updated Successfully");
                    btn_New_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("An Error Occurred");
                }
            }
            autocomplete();
        }

        private void txtvalue_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchPanel.Width = 0;
        }

        private void BeginingBalanceDataUCL2_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void cmbcust_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetCustomers();
            if (cmbcust.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(cmbcust, ps.GetCustomers(), "CustomerName", "CustomerID", "Select Customer");
            }
        }

        private void cmbvendor_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetVendor();
            if (cmbvendor.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(cmbvendor, ps.GetBank(), "Name", "VendorID", "Select Vendor");

            }
        }
    }
}