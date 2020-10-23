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
using System.Text.RegularExpressions;

namespace Project.User_Controls
{
    public partial class BanksUS2 : UserControl
    {
        //Showing UserControl Code
        public static BanksUS2 _buc2;
        public static BanksUS2 buc2
        {
            get
            {
                if (_buc2 == null)
                {
                    _buc2 = new BanksUS2();
                }
                return _buc2;
            }
        }
        int bank_id = -1;
        projectstored ps = new projectstored();

        public BanksUS2()
        {
            InitializeComponent();
            autocomplete();
        }
        //AutoComplete Function
        public void autocomplete()
        {
            txtsearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtsearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            DataTable dt = ps.GetBank();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                {
                    string name = dt.Rows[i]["Name"].ToString();
                    col.Add(name);
                }
            }
            txtsearch.AutoCompleteCustomSource = col;
        }
        // Seacrch Code
        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txtsearch)) { }
            else
            {
                DataTable dt = ps.GetBank("Name", txtsearch.Text);
                if (dt.Rows.Count == 1)
                {
                    bank_id = int.Parse(dt.Rows[0][0].ToString());
                    txtbankname.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    MessageBox.Show("This Bank Name Not Found");
                }
            }
           
        }
        private void pcontrols_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pcontrols_Paint_1(object sender, PaintEventArgs e)
        {

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

        //Save Code
        private void btnsave_Click_1(object sender, EventArgs e)
        {
            if (txtbankname.Text=="")
            {
                MessageBox.Show(txtbankname.Name+"Field is Required");
            }
            else if (ps.InsertNewBank(txtbankname.Text))
            {
                    MessageBox.Show("Bank Saved Successfully");
                    btnnew_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Please Enter Bank Name");
            }
            autocomplete();
        }
        //NewButton's Code
        private void btnnew_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
            bank_id = -1;
        }
        //DeleteButton's Code
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (txtbankname.Text == "")
            {
                MessageBox.Show("Please Select Bank");
            }
            else
            {
                try
                {
                    ps.DeleteBank(txtbankname.Text);
                    btnnew_Click(sender, e);
                    MessageBox.Show("This Bank Name Deleted Successfully");

                }
                catch (Exception)
                {

                    MessageBox.Show("Your Delete operation Failed");
                }
            }
        }
        //UpdateButton's Code
        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtbankname.Text=="")
            {
                MessageBox.Show("Please Enter Bank Name");
            }
            else if (txtbankname.Text!=""&&ps.UpdateBank(bank_id, txtbankname.Text))
            {
                MessageBox.Show("The Record is Updated Successfully");
                btnnew_Click(sender, e);

            }
            else
            {
                MessageBox.Show("The Update Operation is Failed");
            }
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
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchPanel.Width = 0;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
     

        private void txtbankname_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label3_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void txtbankname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar)&&!char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("BankName Must Be Text");
            }
        }

        private void BanksUS2_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }
    }
}
