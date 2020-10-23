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
    public partial class ExpensesTypeUC2 : UserControl
    {
        int expenses_id = -1;
        //Showing UserControl Code
        public static ExpensesTypeUC2 _ext;
        public static ExpensesTypeUC2 ext
        {
            get
            {
                if (_ext == null)
                {
                    _ext = new ExpensesTypeUC2();
                }
                return _ext;
            }
        }
        projectstored ps = new projectstored();
        public ExpensesTypeUC2()
        {

            InitializeComponent();
            autocomplete();
        }
        //SaveButton's Code
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txttypename.Text=="")
            {
                MessageBox.Show("Thsi Field is Required");
            }
           else if (ps.InsertNewExpense(txttypename.Text))
            {
                MessageBox.Show("Expenses added Successfully");
                btnnew_Click(sender, e);
            }
            else if (txttypename.Text == "")
            {
                MessageBox.Show("Please Enter Expenses Type Value");
            }
            
            else MessageBox.Show("This Expense Type is already Exist");
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
            expenses_id = -1;

        }
        //DeleteButton's Code
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (txttypename.Text == "")
            {
                MessageBox.Show("Please Select Type You Need To Delete");
            }
            else
            {
                try
                {
                    ps.DeleteExpenseType(txttypename.Text);
                    MessageBox.Show("Expense Type deleted Successfuly");
                    btnnew_Click(sender, e);
                }
                catch (SqlException)
                {
                    MessageBox.Show("Your Delete Operation Failed");
                }
            }
        }
        //UpdateButton's Code
        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txttypename.Text == "")
            {
                MessageBox.Show("Thsi Field is Required");
            }
            else if (ps.UpdateExpense(expenses_id, txttypename.Text))
            {
                btnnew_Click(sender, e);
                MessageBox.Show("Expenses Updated Successfully");
            }
            else MessageBox.Show("Your Update Operation Failed");
            autocomplete();
        }
        //AutoComplete Function
        public void autocomplete()
        {
            txtseach.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtseach.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            DataTable dt = ps.GetExpenseType();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string name = dt.Rows[i]["Name"].ToString();
                col.Add(name);
            }
            txtseach.AutoCompleteCustomSource = col;
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
        //SearchButton's Code
        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txtseach)) { }
            else
            {
                // txttypename.Text = txtseach.Text;
                DataTable dt = ps.GetExpenseType("name", txtseach.Text);
                if (dt.Rows.Count == 1)
                {
                    expenses_id = int.Parse(dt.Rows[0][0].ToString());
                    txttypename.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    MessageBox.Show("This Type not Exist");
                }
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void cmbsearch_SelectedIndexChanged(object sender, EventArgs e)
        { 
        }
        private void txtseach_TextChanged(object sender, EventArgs e)
        {
            //   autocomplete();
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
        private void txttypename_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ExpensesTypeUC2_MouseClick(object sender, MouseEventArgs e)
        {
            SearchPanel.Width = 0;
        }

        private void ExpensesTypeUC2_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void txttypename_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Type Must Be Text");
            }
        }
    }
}