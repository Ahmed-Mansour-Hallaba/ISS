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
    public partial class BalanceDataUCL2 : UserControl
    {
        int Balance_id = -1;
        projectstored ps = new projectstored();
        //Showing UserControl Code
        private static BalanceDataUCL2 _BDU2;
        public static BalanceDataUCL2 BDU2
        {
            get
            {
                if (_BDU2 == null)
                {
                    _BDU2 = new BalanceDataUCL2();
                }
                return _BDU2;
            }
        }
        public BalanceDataUCL2()
        {
            InitializeComponent();
            autocomplete();
        }

        private void cmbaccountname_SelectedIndexChanged(object sender, EventArgs e)
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
        //Validatecombobox
        public bool validatecm(ComboBox s)
        {
            if (s.SelectedIndex == -1)
            {
                MessageBox.Show(s.Name + "Field is required");
                s.Focus();
                return true;
            }
            else { return false; }

        }
        //NewButton's Code
        private void btn_New_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is ComboBox)
                {
                    c.Text = "";
                }
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
            Balance_id = -1;
        }
        //SaveButton's Code
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (validatecm(cmbaccountname)) { }
            else if (validateTextBox(txtvalue)) { }
            else if (ps.InsertNewBalanceData(cmbaccountname.Text, double.Parse(txtvalue.Text)))
            {
                MessageBox.Show("Balance added Successfully");
                btn_New_Click(sender, e);
            }
            else
            {
                MessageBox.Show("An error Occurred");
            }
            autocomplete();
        }
        //AutoComplete Function
        public void autocomplete()
        {
            //txtsearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //txtsearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            DataTable dt = ps.GetBalancesData();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string name = dt.Rows[i]["Value"].ToString();
                col.Add(name);
            }
            //txtsearch.AutoCompleteCustomSource = col;
        }
        //DeleteButton's Code
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (validatecm(cmbaccountname)) { }
            else if (validateTextBox(txtvalue)) { }
            else
            {
                try
                {
                    ps.DeleteBalanceData(Balance_id);
                    MessageBox.Show("Balance Data Deleted Successfully");
                    btn_New_Click(sender, e);
                }
                catch (SqlException)
                {
                    MessageBox.Show("Your Delete Operation Failed");
                }
            }
           
        }
        //UpdateButton's Code
        private void button1_Click(object sender, EventArgs e)
        {
            if (validatecm(cmbaccountname)) { }
            else if (validateTextBox(txtvalue)) { }
            else if (ps.UpdateBalanceData(Balance_id,cmbaccountname.Text,double.Parse(txtvalue.Text)))
            {
                MessageBox.Show("Balance Updated Successfully");
                btn_New_Click(sender, e);
            }
            else
            {
                MessageBox.Show("An Error Occurred");
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

        private void BalanceDataUCL2_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }
        private void cmbaccountname_MouseHover(object sender, EventArgs e)
        {
            //DataTable dt = ps.GetAccountTree();
            //if (cmbaccountname.Items.Count - 1 != dt.Rows.Count)
            //{
            //    ps.fillcombo(cmbaccountname, ps.GetVendor(), "TreeName", "TreeID", "Select Account");

            //}
        }
    }
}

