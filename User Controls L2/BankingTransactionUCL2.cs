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
    public partial class BankingTransactionUCL2 : UserControl
    {
        public static BankingTransactionUCL2 _BTuc2;
        public static BankingTransactionUCL2 BTuc2
        {
            get
            {
                if (_BTuc2 == null)
                {
                    _BTuc2 = new BankingTransactionUCL2();
                }
                return _BTuc2;
            }
        }
        projectstored ps = new projectstored();
        int banktrans_id = -1;
        public BankingTransactionUCL2()
        {
            InitializeComponent();
            // fill bank Combobox
            DataTable dt1 = ps.GetBank();
            DataRow dr1 = dt1.NewRow();
            dr1["Name"] = "No Bank";
            dr1["BankID"] = -1;
            dt1.Rows.InsertAt(dr1, 0);
            cmbbank.DataSource = dt1;
            cmbbank.DisplayMember = "Name";
            cmbbank.ValueMember = "BankID";
            cmbbank.BindingContext = this.BindingContext;
            // fill Branches Combobox
         /*   DataTable dt2 = ps.GetBranches();
            DataRow dr2 = dt2.NewRow();
            dr2["Name"] = "No Branch";
            dr2["BranchID"] = -1;
            dt2.Rows.InsertAt(dr2, 0);
            cmbbranch.DataSource = dt2;
            cmbbranch.DisplayMember = "Name";
            cmbbranch.ValueMember = "BranchID";
            cmbbranch.BindingContext = this.BindingContext;*/
            // Fill account No ComboBox
           /* DataTable dt3 = ps.GetBanksAccounts();
            DataRow dr3 = dt3.NewRow();
            dr3["AccountNo"] = "-1";
            dr3["BankAccountID"] = -1;
            dt3.Rows.InsertAt(dr3, 0);
            cmbaccountno.DataSource = dt3;
            cmbaccountno.DisplayMember = "AccountNo";
            cmbaccountno.ValueMember = "BankAccountID";
            cmbaccountno.BindingContext = this.BindingContext;*/
            autocomplete();
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
            if (s.SelectedIndex == -1 ||s.Text== "No Bank" || s.Text== "Select  Branch")
            {
                MessageBox.Show(s.Name + "Field is required");
                s.Focus();
                return true;
            }
            else { return false; }

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

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (validatecm(cmbbank)) { }
            else if (validatecm(cmbbranch)) { }
            else if (validateTextBox(txtvalue)) { }
            else if (validatecm(cmbaccountno)) { }
            else if (validateTextBox(txtcontractno)) { }
            else if (validatemobile(txtcontractno)) { }
            else if (validateRadioButton()) { }
            else if (rdbdeposit.Checked == true)
            {
                if (ps.InsertNewBankTransaction(Convert.ToInt32(cmbbank.SelectedValue), int.Parse(txtvalue.Text), int.Parse(txtcontractno.Text), rdbdeposit.Text, rtbnotes.Text))
                {
                    MessageBox.Show("Bank Transaction added Successfully");
                    btn_New_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("An Error occured");
                }
            }
            else if (rdpwithdra.Checked == true)
            {
                if (ps.InsertNewBankTransaction(Convert.ToInt32(cmbbank.SelectedValue), int.Parse(txtvalue.Text), int.Parse(txtcontractno.Text), rdpwithdra.Text, rtbnotes.Text))
                {
                    MessageBox.Show("Bank Transaction added Successfully");
                    btn_New_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("An Error occured");
                }
            }
            autocomplete();
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is TextBox || c is RichTextBox)
                {
                    c.Text = "";
                }
            }
          banktrans_id = -1;
        }
        bool validateRadioButton( )
        {
            if(rdbdeposit.Checked==false && rdpwithdra.Checked == false)
            {
                MessageBox.Show(" Please check Deposite and wuthdraw");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (validatecm(cmbbank)) { }
            else if (validatecm(cmbbranch)) { }
            else if (validateTextBox(txtvalue)) { }
            else if (validatecm(cmbaccountno)) { }
            else if (validateTextBox(txtcontractno)) { }
            else if (validatemobile(txtcontractno)) { }
            else if (validateRadioButton()) { }
            if (rdbdeposit.Checked == true)
            {
                if (ps.UpdateBankTransaction(banktrans_id, Convert.ToInt32(cmbbank.SelectedValue), int.Parse(txtvalue.Text), int.Parse(txtcontractno.Text), rdbdeposit.Text, rtbnotes.Text))
                {
                    MessageBox.Show("Bank Transaction updated Successfully");
                    btn_New_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("An Error Occurred");
                }
            }
            else if (rdpwithdra.Checked == true)
            {
                if (ps.UpdateBankTransaction(banktrans_id, Convert.ToInt32(cmbbank.SelectedValue), int.Parse(txtvalue.Text), int.Parse(txtcontractno.Text), rdpwithdra.Text, rtbnotes.Text))
                {
                    MessageBox.Show("Bank Transaction Updated Successfully");
                    btn_New_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("An Error Occurred");
                }
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (validatecm(cmbbank)) { }
                else if (validatecm(cmbbranch)) { }
                else if (validateTextBox(txtvalue)) { }
                else if (validatecm(cmbaccountno)) { }
                else if (validateTextBox(txtcontractno)) { }
                else if (validatemobile(txtcontractno)) { }
                else if (validateRadioButton()) { }
                else
                {
                    ps.DeleteBankTransaction(banktrans_id);
                    MessageBox.Show("Banh Transaction deleted Successfully");
                    btn_New_Click(sender, e);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("An Error Occured");
            }
        }
        public void autocomplete()
        {

            //txtsearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //txtsearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            DataTable dt = ps.GetBankTransactions();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string name = dt.Rows[i]["Value"].ToString();
                col.Add(name);

            }
            //txtsearch.AutoCompleteCustomSource = col;
        }


        private void cmbbank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbbank.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                DataTable dt2 = ps.GetBranches("BankID", cmbbank.SelectedValue.ToString());
                DataRow dr2 = dt2.NewRow();
                dr2["Name"] = "Select  Branch";
                dr2["BranchID"] = -1;
                dt2.Rows.InsertAt(dr2, 0);
                cmbbranch.DataSource = dt2;
                cmbbranch.DisplayMember = "Name";
                cmbbranch.ValueMember = "BranchID";
                cmbbranch.BindingContext = this.BindingContext;
            }
        }

        private void cmbbranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbbranch.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                DataTable dt3 = ps.GetBanksAccounts("BranchID", cmbbranch.SelectedValue.ToString());
                DataRow dr3 = dt3.NewRow();
                dr3["AccountNo"] = -1;
                dr3["BankAccountID"] = -1;
                dt3.Rows.InsertAt(dr3, 0);
                cmbaccountno.DataSource = dt3;
                cmbaccountno.DisplayMember = "AccountNo";
                cmbaccountno.ValueMember = "BankAccountID";
                cmbaccountno.BindingContext = this.BindingContext;
            }
        }

        private void txtvalue_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtvalue.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only integer numbers.");
                txtvalue.Clear();
            }
        }

        private void txtcontractno_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtcontractno.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only integer numbers.");
                txtcontractno.Clear();
            }
        }

        private void BankingTransactionUCL2_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }
    }
}
