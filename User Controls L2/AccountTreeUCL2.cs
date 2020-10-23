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
using System.Text.RegularExpressions;

namespace Project.User_Controls_L2
{
    public partial class AccountTreeUCL2 : UserControl
    {
        int Account_id = -1;
        projectstored ps = new projectstored();
        //Showing UserControl Code
        private static AccountTreeUCL2 _ATU2;
        public static AccountTreeUCL2 ATU2
        {
            get
            {
                if (_ATU2 == null)
                {
                    _ATU2 = new AccountTreeUCL2();
                }
                return _ATU2;
            }
        }
        public AccountTreeUCL2()
        {
            InitializeComponent();
            ps.fillcombo(comboBox_MainGroup, ps.GetAccountTreeGroups(), "TreeGroupName", "TreeGroupID", "Select tree group");
            autocomplete();
            fillgrid();
        }
        public void fillgrid()
        {
            DataTable dt = ps.GetAccountTreeAndGroups();
            dataGridView1.DataSource = dt;
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
            if (s.SelectedIndex == -1)
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
            DataTable dt = ps.GetAccountTree();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string name = dt.Rows[i]["TreeGroupID"].ToString();
                col.Add(name);

            }
            txtsearch.AutoCompleteCustomSource = col;
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
            Account_id = -1;
        }

        //Save Button's Code
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (validatecm(comboBox_MainGroup)) { }
            else if (validateTextBox(txt_TreeId)) { }
            else if (ps.InsertNewAccountTree(txt_TreeId.Text,Convert.ToInt32(comboBox_MainGroup.SelectedValue)))
                {
                  //  MessageBox.Show("Account added Successfully");
                fillgrid();
                    btn_New_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("An error occurred");
                }
            autocomplete();
        }

        private void cmbsearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //validate TextBox
       
        //SearchButton's Code
        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txtsearch)) { }
            else
            {
                DataTable dt = ps.GetAccountTree("TreeGroupID", txtsearch.Text);
                if (dt.Rows.Count == 1)
                {
                    Account_id = int.Parse(dt.Rows[0][0].ToString());
                    comboBox_MainGroup.Text = dt.Rows[0][1].ToString();
                    txt_TreeId.Text = dt.Rows[0][2].ToString();
                    SearchButton_Click(sender, e);

                }
                else
                {
                    MessageBox.Show("This Account Not Found");
                }
                txtsearch.Clear();
            }
        }
        //UpdateButton's Code
        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (validatecm(comboBox_MainGroup)) { }
            else if (validateTextBox(txt_TreeId)) { }
            else if (ps.UpdateAccountTree(Account_id,comboBox_MainGroup.Text,int.Parse(txt_TreeId.Text)))
            {
                MessageBox.Show("Account Tree Updated Successfully");
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
            if (validatecm(comboBox_MainGroup)) { }
            else if (validateTextBox(txt_TreeId)) { }
            else
            {
                try
                {
                    ps.DeleteAccountTree(Account_id);

                    MessageBox.Show("Account deleted successfuly");
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

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txt_TreeId_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void AccountTreeUCL2_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchPanel.Width = 0;
        }

        private void comboBox_MainGroup_MouseHover(object sender, EventArgs e)
        {
          
        }

        private void lbl_Name_Click(object sender, EventArgs e)
        {

        }
    }
}
