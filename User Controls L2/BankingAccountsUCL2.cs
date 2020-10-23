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
    public partial class BankingAccountsUCL2 : UserControl
    {
        //Showing UserControl Code
        private static BankingAccountsUCL2 _BALU2;
        public static BankingAccountsUCL2 BALU2
        {
            get
            {
                if (_BALU2 == null)
                {
                    _BALU2 = new BankingAccountsUCL2();
                }
                return _BALU2;
            }
        }
        projectstored ps = new projectstored();
        int bank_id = -1;
        public BankingAccountsUCL2()
        {
            InitializeComponent();
            //autocomplete();
            DataTable dt = ps.GetTableAttributes("BanksAccountsView");
            DataRow dr = dt.NewRow();
            dr["COLUMN_NAME"] = "Select search parameter";
            dt.Rows.InsertAt(dr, 0);
            cmbsearch.DataSource = dt;
            cmbsearch.DisplayMember = "COLUMN_NAME";
            cmbsearch.BindingContext = this.BindingContext;
            //Fill ComboBox
            DataTable dt1 = ps.GetBank();
            DataRow dr1 = dt1.NewRow();
            dr1["Name"] = "No Bank";
            dr1["BankID"] = -1;
            dt1.Rows.InsertAt(dr1, 0);
            comboBox_Bank.DataSource = dt1;
            comboBox_Bank.DisplayMember = "Name";
            comboBox_Bank.ValueMember = "BankID";
            comboBox_Bank.BindingContext = this.BindingContext;
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
        //AutoComplete Function
        public void autocomplete()
        {
            txtsearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtsearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            DataTable dt = ps.GetBanksAccounts();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string name = dt.Rows[i]["AccountNo"].ToString();
                col.Add(name);
            }
            txtsearch.AutoCompleteCustomSource = col;
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
            bank_id = -1;
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
            if (s.SelectedIndex == -1 || s.Text == "No Bank" || s.Text == "Select  Branch")
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
            if (validateTextBox(txt_AccountNum)) { }
            else if (validatecm(comboBox_Bank)) { }
            else if (validatecm(comboBox_Branch)) { }
            else if (validateTextBox(txt_Currency)) { }
            else if (ps.InsertNewBankAccount(Convert.ToInt32(txt_AccountNum.Text),Convert.ToInt32(comboBox_Branch.SelectedValue),int.Parse(txt_Currency.Text),richTextBox_Notes.Text))
            {
                MessageBox.Show("Bank Account added Successfully");
                btn_New_Click(sender, e);
            }
            else
            {
                MessageBox.Show("An error Occurred");
            }
            autocomplete();
        }

        private void cmbsearch_Click(object sender, EventArgs e)
        {

        }

        private void cmbsearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            autocomplete();
        }

        //SearchButton's Code
        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txtsearch)) { }
            else
            {
                DataTable dt = ps.GetBanksAccounts("AccountNo", txtsearch.Text);
                if (dt.Rows.Count == 1)
                {
                    bank_id = int.Parse(dt.Rows[0][0].ToString());
                    txt_AccountNum.Text = dt.Rows[0][1].ToString();
                    DataTable dt1 = ps.GetBranches("BranchID", dt.Rows[0][2].ToString());
                    comboBox_Bank.SelectedValue = dt1.Rows[0][2];   
                    comboBox_Branch.SelectedValue = dt.Rows[0][2];
                    txt_Currency.Text = dt.Rows[0][3].ToString();
                    richTextBox_Notes.Text = dt.Rows[0][4].ToString();
                    SearchButton_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Bank Account not found");
                }
            }
            
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txt_AccountNum)) { }
            else if (validatecm(comboBox_Bank)) { }
            else if (validatecm(comboBox_Branch)) { }
            else if (validateTextBox(txt_Currency)) { }
            else if (ps.UpdateBankAccount(bank_id, int.Parse(txt_AccountNum.Text), Convert.ToInt32(comboBox_Branch.SelectedValue), int.Parse(txt_Currency.Text), richTextBox_Notes.Text))
            {
                MessageBox.Show("Bank Account Updated Successfully");
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
            if (validateTextBox(txt_AccountNum)) { }
            else if (validatecm(comboBox_Bank)) { }
            else if (validatecm(comboBox_Branch)) { }
            else if (validateTextBox(txt_Currency)) { }
          
            else
            {
                try
                {
                    ps.DeleteBankAccount(bank_id);
                    MessageBox.Show("Bank Account deleted successfuly");
                    btn_New_Click(sender, e);
                }
                catch (SqlException)
                {

                    MessageBox.Show("Your Delete Operation Failed");
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox_Bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Bank.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                DataTable dt2 = ps.GetBranches("BankID", comboBox_Bank.SelectedValue.ToString());
                DataRow dr2 = dt2.NewRow();
                dr2["Name"] = "No Branch";
                dr2["BranchID"] = -1;
                dt2.Rows.InsertAt(dr2, 0);
                comboBox_Branch.DataSource = dt2;
                comboBox_Branch.DisplayMember = "Name";
                comboBox_Branch.ValueMember = "BranchID";
                comboBox_Branch.BindingContext = this.BindingContext;
            }
        }

        private void txt_AccountNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("AccounNo Must Be Number");
            }
        }

        private void txt_Currency_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Currency Must Be Number");
            }
        }

        private void BankingAccountsUCL2_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchPanel.Width = 0;
        }

        private void comboBox_Bank_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetBank();
            if (comboBox_Bank.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(comboBox_Bank, ps.GetBank(), "Name", "BankID", "Select Bank");

            }
        }
    }
}
