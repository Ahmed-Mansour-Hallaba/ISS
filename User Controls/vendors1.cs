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
using Project.User_Controls;
using System.Text.RegularExpressions;

namespace Project.User_Controls
{
    public partial class VendorsUC2 : UserControl
    {
        int venders_id = -1;
        projectstored ps = new projectstored();
        //Showing UserControl Code
        public static VendorsUC2 _venuc2;
        public static VendorsUC2 venuc2
        {
            get
            {
                if (_venuc2 == null)
                {
                    _venuc2 = new VendorsUC2();
                }
                return _venuc2;
            }
        }
        public VendorsUC2()
        {
            InitializeComponent();
            //Fill ComboBox Code
            DataTable dt = ps.GetTableAttributes("VendorsView");
            DataRow dr = dt.NewRow();
            dr["COLUMN_NAME"] = "Select search parameter";
            dt.Rows.InsertAt(dr, 0);
            cmbsearch.DataSource = dt;
            cmbsearch.DisplayMember = "COLUMN_NAME";
            cmbsearch.BindingContext = this.BindingContext;
            //fill delegatecombo box
            DataTable dt1 = ps.GetDelegate();
            DataRow dr1 = dt1.NewRow();
            dr1["DelegateName"] = "No delegate";
            dr1["DelegateID"] = -1;
            dt1.Rows.InsertAt(dr1, 0);
            cmbdelegatename.DataSource = dt1;
            cmbdelegatename.DisplayMember = "DelegateName";
            cmbdelegatename.ValueMember = "DelegateID";
            cmbdelegatename.BindingContext = this.BindingContext;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
            if (s.SelectedIndex == -1 ||s.Text== "No delegate" )
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
            DataTable dt = ps.GetVendor();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (cmbsearch.Text == "Address")
                {
                    string name = dt.Rows[i]["Address"].ToString();
                    col.Add(name);
                }

                else if (cmbsearch.Text == "Code")
                {
                    txtsearch.Clear();
                    string name = dt.Rows[i]["Code"].ToString();
                    col.Add(name);
                }
                else if (cmbsearch.Text == "Email")
                {
                    txtsearch.Clear();
                    string name = dt.Rows[i]["Email"].ToString();
                    col.Add(name);
                }
                else if (cmbsearch.Text == "Mobile")
                {
                    txtsearch.Clear();
                    string name = dt.Rows[i]["Mobile"].ToString();
                    col.Add(name);
                }
                else if (cmbsearch.Text == "Name")
                {
                    txtsearch.Clear();
                    string name = dt.Rows[i]["Name"].ToString();
                    col.Add(name);
                }
                else if (cmbsearch.Text == "Phone")
                {
                    txtsearch.Clear();
                    string name = dt.Rows[i]["Phone"].ToString();
                    col.Add(name);
                }

            }
            txtsearch.AutoCompleteCustomSource = col;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            autocomplete();
        }
        //NewButton's Code
        private void btnnew_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is TextBox || c is RichTextBox)
                {
                    c.Text = "";
                }
            }
            venders_id = -1;

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
        //SaveButton's Code
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txtcode)) { }
            else if (validateTextBox(txtname)) { }
            else if (validateTextBox(txtphone)) { }
            else if (validatemobile(txtphone)) { }
            else if (validateTextBox(txtmobile)) { }
            else if (validatemobile(txtmobile)) { }
            else if (validatecm(cmbdelegatename)) { }
            else if (validateTextBox(txtemail)) { }
            else if (ValidateChildren(ValidationConstraints.None) && ps.InsertNewVendor(txtcode.Text, txtname.Text, txtgoverner.Text, txtcity.Text, txtaddress.Text, txtphone.Text, txtfax.Text, txtmobile.Text, txtzip.Text, cmbdelegatename.SelectedValue.ToString(), txtemail.Text, double.Parse(txtlimitedcridet.Text), txtnotes.Text))
            {

                MessageBox.Show("Vendor added successfully");
                btnnew_Click(sender, e);
            }
            else { MessageBox.Show("Vendor is already existed"); }
        }
        //DeleteButton's Code
        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateTextBox(txtcode)) { }
                else if (validateTextBox(txtname)) { }
                else if (validateTextBox(txtphone)) { }
                else if (validatemobile(txtphone)) { }
                else if (validateTextBox(txtmobile)) { }
                else if (validatemobile(txtmobile)) { }
                else if (validatecm(cmbdelegatename)) { }
                else if (validateTextBox(txtemail)) { }
                {
                    ps.DeleteVendor(venders_id);

                    MessageBox.Show("Vendor deleted successfuly");
                    btnnew_Click(sender, e);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Vendor not existed");
            }

        }
        //UpdateButton's Code
        private void btnupdate_Click(object sender, EventArgs e)
        {

            if (validateTextBox(txtcode)) { }
            else if (validateTextBox(txtname)) { }
            else if (validateTextBox(txtphone)) { }
            else if (validatemobile(txtphone)) { }
            else if (validateTextBox(txtmobile)) { }
            else if (validatemobile(txtmobile)) { }
            else if (validatecm(cmbdelegatename)) { }
            else if (validateTextBox(txtemail)) { }

            else if (ps.UpdateVendor(venders_id, txtcode.Text, txtname.Text, txtgoverner.Text, txtcity.Text, txtaddress.Text, txtphone.Text, txtfax.Text, txtmobile.Text, txtzip.Text, cmbdelegatename.SelectedValue.ToString(), txtemail.Text, double.Parse(txtlimitedcridet.Text), txtnotes.Text))
            {
                MessageBox.Show("The Record is Updated Successfully");
                btnnew_Click(sender, e);
            }
            else
            {
                MessageBox.Show("This Vendor is not existed");
            }
        }
        //SearchButton's Code
        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txtsearch)) { }
            else
            {
                DataTable dt = ps.GetVendor(cmbsearch.Text, txtsearch.Text);
                if (dt.Rows.Count == 1)
                {
                    venders_id = int.Parse(dt.Rows[0][0].ToString());
                    txtcode.Text = dt.Rows[0][1].ToString();
                    txtname.Text = dt.Rows[0][2].ToString();
                    txtgoverner.Text = dt.Rows[0][3].ToString();
                    txtcity.Text = dt.Rows[0][4].ToString();
                    txtaddress.Text = dt.Rows[0][5].ToString();
                    txtphone.Text = dt.Rows[0][6].ToString();
                    txtfax.Text = dt.Rows[0][7].ToString();
                    txtmobile.Text = dt.Rows[0][8].ToString();
                    txtzip.Text = dt.Rows[0][9].ToString();
                    cmbdelegatename.SelectedValue= dt.Rows[0][10].ToString();
                    txtemail.Text = dt.Rows[0][11].ToString();
                    txtlimitedcridet.Text = dt.Rows[0][12].ToString();
                    txtnotes.Text = dt.Rows[0][13].ToString();
                }
                else
                {
                    MessageBox.Show("Vendor not exist");
                }
            }
        }

        private void cmbdelegatename_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchPanel.Width = 0;
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
        private void txtgoverner_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtcity_TextChanged(object sender, EventArgs e)
        {

        }
       
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void SearchPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbdelegatename_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void txtcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Code Must Be Number");
            }
        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Name Must Be Text");
            }
        }

        private void txtgoverner_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Governer Must Be Text");
            }
        }

        private void txtcity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("City Must Be Text");
            }
        }

        private void txtaddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Address Must Be Text");
            }
        }

        private void txtfax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Fax Must Be Number");
            }
        }

        private void txtphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Phone Must Be Number");
            }
        }

        private void txtmobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Mobile Must Be Number");
            }
        }

        private void txtemail_Leave(object sender, EventArgs e)
        {
            Regex mRegxExpression;

            if (txtemail.Text.Trim() != string.Empty)

            {

                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                if (!mRegxExpression.IsMatch(txtemail.Text.Trim()))

                {

                    MessageBox.Show("E-mail address format is not correct.", "MojoCRM", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtemail.Focus();

                }

            }
        }

        private void txtphone_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtmobile_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void VendorsUC2_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void txtzip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("ZIP Must Be Number");
            }
        }

        private void txtlimitedcridet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Limited Credit Must Be Number");
            }
        }

        private void cmbdelegatename_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetDelegate();
            if (cmbdelegatename.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(cmbdelegatename, ps.GetDelegate(), "DelegateName", "DelegateID", "Select Delegate");

            }
        }
    }
}

