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
    public partial class MainManagementUC2 : UserControl
    {
        //Showing User Control Code
        public static MainManagementUC2 _mmuc2;
        public static MainManagementUC2 mmuc2
        {
            get
            {
                if (_mmuc2 == null)
                {
                    _mmuc2 = new MainManagementUC2();
                }
                return _mmuc2;
            }
        }

        projectstored ps = new projectstored();
        int managmentname_id = -1;
        public MainManagementUC2()
        {
            InitializeComponent();
            autocomplete();
        }
        //New Button Code
        private void btnnew_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is TextBox || c is RichTextBox)
                {
                    c.Text = "";
                }
            }
            managmentname_id = -1;

        }
        //SaveButton's Code
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtmanagementname.Text == "")
            {
                MessageBox.Show("Please Enter Management Name");
            }
            
            else if (ps.InsertNewManagement(txtmanagementname.Text))
            {
               MessageBox.Show("Management Name added Successfully");
                btnnew_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Error!");
            }
            autocomplete();
            }
        //DeleteButton's Code
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (txtmanagementname.Text == "")
            {
                MessageBox.Show("Please Enter Name You Need To Delete");
            }
            else
            {
                try
                {
                    ps.DeleteMainManagement(txtmanagementname.Text);
                    btnnew_Click(sender, e);
                    MessageBox.Show("Management Name Deleted Successfuly");
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
            if (txtmanagementname.Text == "")
            {
                MessageBox.Show("Please Enter Management Name");
            }
            else if (ps.UpdateManagement(managmentname_id, txtmanagementname.Text))
            {
                btnnew_Click(sender, e);
                MessageBox.Show("Management Name Updated Successfully");
            }
          
            else MessageBox.Show("Your Update Operation Failed");
            autocomplete();
        }
        //AutoComplete Function
        public void autocomplete()
        {
            txtsearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtsearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            DataTable dt = ps.GetMainManagement();
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
            if (validateTextBox(txtsearch)) { }
            else
            {
                DataTable dt = ps.GetMainManagement("name", txtsearch.Text);
                if (dt.Rows.Count == 1)
                {
                    managmentname_id = int.Parse(dt.Rows[0][0].ToString());
                    txtmanagementname.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    MessageBox.Show("Main Management is Not Exist");
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

        private void txtmanagementname_TextChanged(object sender, EventArgs e)
        {
           
        }
        
        private void txtmanagementname_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            SearchPanel.Width = 0;
        }

        private void MainManagementUC2_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void txtmanagementname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)&&!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Name Must Be Text");
            }
        }
    }
}
