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
using Project.User_Controls;
using Project.NewUserControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
namespace Project.User_Controls_L2
{
    public partial class CustomerDataUCL2 : UserControl
    {
        //Showing UserControl Code
        private static CustomerDataUCL2 _CDU2;
        public static CustomerDataUCL2 CDU2
        {
            get
            {
                if (_CDU2 == null)
                {
                    _CDU2 = new CustomerDataUCL2();
                }
                return _CDU2;
            }
        }
        int Customer_id = -1;
        projectstored ps = new projectstored();
        //FillCombos Function
        public void fillcombos()
        {
            DataTable dt1 = ps.GetCustomerGroups();
            DataRow dr1 = dt1.NewRow();
            dr1["Name"] = "No CustomerGroup";
            dr1["CustomerGroupID"] = -1;
            dt1.Rows.InsertAt(dr1, 0);
            comboBox_CustGroup.DataSource = dt1;
            comboBox_CustGroup.DisplayMember = "Name";
            comboBox_CustGroup.ValueMember = "CustomerGroupID";
            comboBox_CustGroup.BindingContext = this.BindingContext;
            DataTable dt2 = ps.GetDelegate();
            DataRow dr2 = dt2.NewRow();
            dr2["DelegateName"] = "No Delegate";
            dr2["DelegateID"] = -1;
            dt2.Rows.InsertAt(dr2, 0);
            comboBox_Delegate.DataSource = dt2;
            comboBox_Delegate.DisplayMember = "DelegateName";
            comboBox_Delegate.ValueMember = "DelegateID";
            comboBox_Delegate.BindingContext = this.BindingContext;
        }
        public CustomerDataUCL2()
        {
            InitializeComponent();
            DataTable dt = ps.GetTableAttributes("CustomersView");
            DataRow dr = dt.NewRow();
            dr["COLUMN_NAME"] = "Select search parameter";
            dt.Rows.InsertAt(dr, 0);
            cmbsearch.DataSource = dt;
            cmbsearch.DisplayMember = "COLUMN_NAME";
            cmbsearch.BindingContext = this.BindingContext;
            // Fill Form Data
            fillcombos();
           
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

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is TextBox || c is RichTextBox)
                {
                    c.Text = " ";
                }
            }
            Customer_id = -1;
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
            if (s.Text == "No CustomerGroup" || s.Text== "No Delegate")
            {
                MessageBox.Show(s.Name + "Field is required");
                s.Focus();
                return true;
            }
            else { return false; }

        }
        //SaveButton's Code
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txt_Code)) { }
            else if (validateTextBox(txt_Name)) { }
            else if (validateTextBox(txt_Country)) { }
            else if (validateTextBox(txt_City)) { }
            else if (validateTextBox(txt_Address)) { }
            else if (validateTextBox(txt_phone)) { }
            else if (validateTextBox(txt_Email)) { }
            else if (validateTextBox(txt_Fax)) { }
            else if (validateTextBox(txt_postalcode)) { }
            else if (validatecm(comboBox_CustGroup)) { }
            else if (validatecm(comboBox_Delegate)) { }
            else if (ps.InsertNewCustomer(int.Parse(txt_Code.Text), txt_Name.Text, txt_Country.Text, txt_City.Text, txt_Address.Text, txt_phone.Text, txt_Email.Text, int.Parse(txt_Fax.Text), int.Parse(txt_postalcode.Text), int.Parse(txt_Credit.Text), Convert.ToInt32(comboBox_CustGroup.SelectedValue), Convert.ToInt32(comboBox_Delegate.SelectedValue), richTextBox_Notes.Text))
            {
                MessageBox.Show("Customer added Successflly");
                btn_New_Click(sender, e);
                comboBox_CustGroup.Text = "No CustomerGroup";
                comboBox_Delegate.Text = "No Delegate";
            }
            else
            {
                MessageBox.Show("An Error Occurred");
            }
            autocomplete();
        }
        //AutoComplete Function
        public void autocomplete()
        {
            txtsearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtsearch.AutoCompleteMode = AutoCompleteMode.Suggest;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            DataTable dt = ps.GetCustomers();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (cmbsearch.Text == "CustomerCode")
                {
                    string name = dt.Rows[i]["CustomerCode"].ToString();
                    col.Add(name);
                }
                else if (cmbsearch.Text == "Phone")
                {
                    txtsearch.Clear();
                    string name = dt.Rows[i]["Phone"].ToString();
                    col.Add(name);
                }
                else if (cmbsearch.Text == "CustomerName")
                {
                    txtsearch.Clear();
                    string name = dt.Rows[i]["CustomerName"].ToString();
                    col.Add(name);
                }
                else if (cmbsearch.Text == "Email")
                {
                    txtsearch.Clear();
                    string name = dt.Rows[i]["Email"].ToString();
                    col.Add(name);
                }
            }
            txtsearch.AutoCompleteCustomSource = col;
        }
        private void cmbsearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            autocomplete();
        }
        //SearchButton's Code
        private void btnsearch_Click(object sender, EventArgs e)
        {
            DataTable dt = ps.GetCustomers(cmbsearch.Text, txtsearch.Text);
            if (dt.Rows.Count == 1)
            {
                Customer_id = int.Parse(dt.Rows[0][0].ToString());
                txt_Code.Text = dt.Rows[0][1].ToString();
                txt_Name.Text = dt.Rows[0][2].ToString();
                txt_Country.Text = dt.Rows[0][3].ToString();
                txt_City.Text = dt.Rows[0][4].ToString();
                txt_Address.Text = dt.Rows[0][5].ToString();
                txt_phone.Text = dt.Rows[0][6].ToString();
                txt_Email.Text = dt.Rows[0][7].ToString();
                txt_Fax.Text = dt.Rows[0][8].ToString();
                txt_postalcode.Text = dt.Rows[0][9].ToString();
                txt_Credit.Text = dt.Rows[0][10].ToString();
                comboBox_CustGroup.SelectedValue = dt.Rows[0][11].ToString();
                comboBox_Delegate.SelectedValue = dt.Rows[0][12].ToString();
                richTextBox_Notes.Text = dt.Rows[0][13].ToString();
            }
            else
                MessageBox.Show("Customer not Existed");

        }
        //UpdateButton's Code
        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txt_Code)) { }
            else if (validateTextBox(txt_Name)) { }
            else if (validateTextBox(txt_Country)) { }
            else if (validateTextBox(txt_City)) { }
            else if (validateTextBox(txt_Address)) { }
            else if (validateTextBox(txt_phone)) { }
            else if (validateTextBox(txt_Email)) { }
            else if (validateTextBox(txt_Fax)) { }
            else if (validateTextBox(txt_postalcode)) { }
            else if (validatecm(comboBox_CustGroup)) { }
            else if (validatecm(comboBox_Delegate)) { }
            else if (ps.UpdateCustomer(Customer_id, int.Parse(txt_Code.Text), txt_Name.Text, txt_Country.Text, txt_City.Text, txt_Address.Text, txt_phone.Text, txt_Email.Text, int.Parse(txt_Fax.Text), int.Parse(txt_postalcode.Text), int.Parse(txt_Credit.Text), Convert.ToInt32(comboBox_CustGroup.SelectedValue), Convert.ToInt32(comboBox_Delegate.SelectedValue), richTextBox_Notes.Text))
            {
                MessageBox.Show("The Record is Updated Successfully");
                btn_New_Click(sender, e);
                comboBox_CustGroup.Text = "No CustomerGroup";
                comboBox_Delegate.Text = "No Delegate";
            }
            else
            {
                MessageBox.Show("Your Update Operation Failed");
            }
        }
        CustomerGroupUC2 cguc2;
        private void btn_AddCustGroup_Click(object sender, EventArgs e)
        {
            AddUsercontrol form = new AddUsercontrol();
            form.panel2.Controls.Add(CustomerGroupUC2.cguc2);
            form.ShowDialog();

        }
        DelegateRegistrationUC2 drguc2;
        private void button1_Click(object sender, EventArgs e)
        {
            AddUsercontrol form = new AddUsercontrol();
            form.panel2.Controls.Add(DelegateRegistrationUC2.drguc2);
            form.ShowDialog();
        }
        //DeleteButton's Code
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txt_Code)) { }
            else if (validateTextBox(txt_Name)) { }
            else if (validateTextBox(txt_Country)) { }
            else if (validateTextBox(txt_City)) { }
            else if (validateTextBox(txt_Address)) { }
            else if (validateTextBox(txt_phone)) { }
            else if (validateTextBox(txt_Email)) { }
            else if (validateTextBox(txt_Fax)) { }
            else if (validateTextBox(txt_postalcode)) { }
            else if (validatecm(comboBox_CustGroup)) { }
            else if (validatecm(comboBox_Delegate)) { }
            else
            {
                try
                {
                    ps.DeleteCustomer(Customer_id);
                    MessageBox.Show("Customer deleted successfuly");
                    btn_New_Click(sender, e);
                    comboBox_CustGroup.Text = "No CustomerGroup";
                    comboBox_Delegate.Text = "No Delegate";
                }
                catch (SqlException)
                {
                    MessageBox.Show("Your Delete Operation Failed");
                }
            }
        }
        private void txt_Code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)&& !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Code Must Be Number");
            }
        }

        private void txt_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Name Must Be Text");
            }
        }

        private void txt_Email_Leave(object sender, EventArgs e)
        {
            Regex mRegxExpression;

            if (txt_Email.Text.Trim() != string.Empty)

            {
                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                if (!mRegxExpression.IsMatch(txt_Email.Text.Trim()))

                {

                    MessageBox.Show("E-mail address format is not correct.", "MojoCRM", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txt_Email.Focus();

                }
            }
        }

        private void txt_phone_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_phone.Text, "^01[0-2]{1}[0-9]{9}"))
            {
                MessageBox.Show("Please enter phone in coreect format such as 01111111111.");
                txt_phone.Clear();
            }
        }

        private void txt_Fax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Code Must Be Number");
            }
        }

        private void txt_postalcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Code Must Be Number");
            }
        }

        private void txt_Credit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Code Must Be Number");
            }
        }

        private void txt_City_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Name Must Be Text");
            }
        }

        private void txt_Country_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Name Must Be Text");
            }
        }

        private void CustomerDataUCL2_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchPanel.Width = 0;
        }

        private void comboBox_CustGroup_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetCustomerGroups();
            if (comboBox_CustGroup.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(comboBox_CustGroup, ps.GetCustomerGroups(), "Name", "CustomerGroupID", "Select Bank");

            }
        }

        private void comboBox_Delegate_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetDelegate();
            if (comboBox_Delegate.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(comboBox_Delegate, ps.GetDelegate(), "DelegateName", "DelegateID", "Select Bank");

            }
        }
    }
}
