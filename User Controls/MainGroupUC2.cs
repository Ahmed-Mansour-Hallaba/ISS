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
using Project.NewUserControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Project.NewUserControls
{
    public partial class MainGroupUC2 : UserControl
    {
        //Showing UserContol Code
        public static MainGroupUC2 _mguc2;
        public static MainGroupUC2 mguc2
        {
            get
            {
                if (_mguc2 == null)
                {
                    _mguc2 = new MainGroupUC2();
                }
                return _mguc2;

            }
        }
        int maingroup_id = -1;
        projectstored ps = new projectstored();
        public MainGroupUC2()
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
            DataTable dt = ps.GetMainGroup();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                {
                    string name = dt.Rows[i]["Name"].ToString();
                    col.Add(name);
                }
            }
    
            txtsearch.AutoCompleteCustomSource = col;
        }
        //validate TextBox
       
        //SearchButton's Code
        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txtsearch)) { }
            else
            {
                DataTable dt = ps.GetMainGroup("Name", txtsearch.Text);
                if (dt.Rows.Count == 1)
                {
                    maingroup_id = int.Parse(dt.Rows[0][0].ToString());
                    txtgroupname.Text = dt.Rows[0][1].ToString();
                }
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }
        //NewButton's Code
        private void btnnew_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = " ";
                }
            }
            maingroup_id = -1;
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
        //SaveButton's Code
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txtgroupname)) { }
            else if (ps.InsertNewGroup(txtgroupname.Text))
            {
                MessageBox.Show("The Group Name Saved Successfully");
                btnnew_Click(sender, e);
            }
            else
            {
                MessageBox.Show("An Error Occurred");
            }
            autocomplete();
        }
        //DeleteButton's Code
        private void btndelete_Click(object sender, EventArgs e)
        {
            //if (validateTextBox(txtgroupname)) { }
            //else
            //{
            //    try
            //    {
            //        ps.DeleteMainGroup(txtgroupname.Text);
            //        btnnew_Click(sender, e);
            //        MessageBox.Show("The Group Name Deleted Successfully");
            //    }
            //    catch (Exception)
            //    {

            //        MessageBox.Show("Your Delete operation Failed");
            //    }
            //}
            int NumberOfClick = 0;
            ++NumberOfClick;
            switch (NumberOfClick)
            {
                case 1:
                    if (validateTextBox(txtgroupname)) { }
                    else
                    {
                        try
                        {
                            ps.DeleteMainGroup(txtgroupname.Text);
                            btnnew_Click(sender, e);
                            MessageBox.Show("The Group Name Deleted Successfully");
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("Your Delete operation Failed");
                        }
                    }

                        break;
                case 2:
                    MessageBox.Show(txtgroupname.Name + "Field is required");

                    break;
            }
        }
        //UpdateButton's Code
        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txtgroupname)) { }
            else if (ps.UpdateGroup(maingroup_id, txtgroupname.Text))
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
       
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pcontrols_MouseClick(object sender, MouseEventArgs e)
        {
            SearchPanel.Width = 0;
        }

        private void txtgroupname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar)&& !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Group Must Be Text");
            }
        }

        private void MainGroupUC2_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }
    }
}
