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
    public partial class CustomerGroupUC2 : UserControl
    {
        projectstored ps = new projectstored();
        int groupname_id = -1;
        //Showing UserControl Code
        public static CustomerGroupUC2 _cguc2;
        public static CustomerGroupUC2 cguc2
        {
            get
            {
                if (_cguc2 == null)
                {
                    _cguc2 = new CustomerGroupUC2();
                }
                return _cguc2;
            }
        }
        public CustomerGroupUC2()
        {
            InitializeComponent();
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
            groupname_id = -1;
        }
        //SaveButton's Function
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtgroupname.Text == "")
            {
                MessageBox.Show("This Field is Required");
            }
            else if (ps.InsertNewCustomerGroup(txtgroupname.Text))
            {
                MessageBox.Show("New Customer Group added Successfully");
                btnnew_Click(sender, e);
            }
            else MessageBox.Show("This group name is already exist");
            autocomplete();
            }
        //DeleteButton's Code
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (txtgroupname.Text=="")
            {
                MessageBox.Show("Please Select Group You Want to Delete");
            }
            else
            {
                try
                {
                    ps.DeleteCustomerGroup(groupname_id);
                    btnnew_Click(sender, e);
                    MessageBox.Show("This Group Name deleted Successfuly");
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Your Delete operation Failed");
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //UpdateButton's Code
        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtgroupname.Text == "")
            {
                MessageBox.Show("Please Enter Group");
            }
            else if (txtgroupname.Text!=""&&ps.UpdateCustomerGroup(groupname_id, txtgroupname.Text))
            {
                btnnew_Click(sender, e);
                MessageBox.Show("Groupe Name Updated Successfully");
            }
            else MessageBox.Show("The Update Operation is Failed");
            autocomplete();
        }
        //AutoComplete Function
        public void autocomplete()
        {
            txtsearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtsearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            DataTable dt = ps.GetCustomerGroups();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string name = dt.Rows[i]["Name"].ToString();
                col.Add(name);
            }
            txtsearch.AutoCompleteCustomSource = col;
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
            if (validateTextBox(txtgroupname)) { }
            else
            {
                DataTable dt = ps.GetCustomerGroups("name", txtsearch.Text);
                if (dt.Rows.Count == 1)
                {
                    groupname_id = int.Parse(dt.Rows[0][0].ToString());
                    txtgroupname.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    MessageBox.Show("Customer Group is Not Exist");
                }
            }
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

        private void txtgroupname_TextChanged(object sender, EventArgs e)
        {
        }
        
        private void txtgroupname_Validating(object sender, CancelEventArgs e)
        {
        }

        private void CustomerGroupUC2_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void txtgroupname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)&&!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Customer Group must be Text");
            }
        }
    }
}
