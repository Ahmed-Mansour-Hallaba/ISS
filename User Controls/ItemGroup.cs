using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project.NewUserControls;
using projectsp;
using System.Data.SqlClient;

namespace Project.User_Controls
{
    public partial class ItemGroup : UserControl
    {
        public static ItemGroup _IGUC1;

        public static ItemGroup IGUC1
        {
            get
            {
                if (_IGUC1 == null)
                {
                    _IGUC1 = new ItemGroup();
                }
                return _IGUC1;
            }
        }
        projectstored ps = new projectstored();
        int itemgroup_id = -1;
        public ItemGroup()
        {
            InitializeComponent();
            ps.fillcombo(cmbmaingroup, ps.GetMainGroup(), "Name", "MainGroupID", "Select Main Group");
            autocomplete();
        }
        public void autocomplete()
        {
            txtsearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtsearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            DataTable dt = ps.GetItemGroup();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                {
                    string name = dt.Rows[i]["Name"].ToString();
                    col.Add(name);
                }
            }
            txtsearch.AutoCompleteCustomSource = col;
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

        private void btn_Addmanagement_Click(object sender, EventArgs e)
        {
            AddUsercontrol form = new AddUsercontrol();
            form.panel2.Controls.Add(MainGroupUC2.mguc2);
            form.ShowDialog();
        }

        private void ItemGroup_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }
        public bool validatecm(ComboBox s)
        {
            if (s.SelectedIndex == -1 || s.Text == "Select ")
            {
                MessageBox.Show(s.Name + "Field is required");
                s.Focus();
                return true;
            }
            else { return false; }

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
        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbdelegatename_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetMainGroup();
            if (cmbmaingroup.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(cmbmaingroup, ps.GetMainGroup(), "Name", "MainGroupID", "Select main group");

            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txtgroup)) { }
            else if (validatecm(cmbmaingroup)) { }
            else if (ps.InsertNewItemGroup(txtgroup.Text, txtnotes.Text, Convert.ToInt32(cmbmaingroup.SelectedValue)))
            {
                MessageBox.Show("Item Group added Successfully");
                btnnew_Click(sender, e);
            }
            else
            {
                MessageBox.Show("This ItemGroup already Exists");
            }
            autocomplete();
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is TextBox || c is RichTextBox)
                {
                    c.Text = "";
                }
                else if (c is ComboBox)
                {
                    c.Text = "Select Main Group";
                }
            }
            itemgroup_id = -1;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateTextBox(txtgroup)) { }
                else if (validatecm(cmbmaingroup)) { }
                else
                {
                    ps.DeleteItemGroup(txtgroup.Text, cmbmaingroup.Text);
                    btnnew_Click(sender, e);
                    MessageBox.Show("Item Group Deleted Successfully");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Your Delete Operation Failed");
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txtgroup)) { }
            else if (validatecm(cmbmaingroup)) { }
            else if (ps.UpdateItemGroup(itemgroup_id, txtgroup.Text, txtnotes.Text, cmbmaingroup.Text))
            {
                MessageBox.Show("Item Group Updated Successfully");
                btnnew_Click(sender, e);
            }
            else
            {
                MessageBox.Show("This Item Group already Exists");
            }
            autocomplete();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            DataTable dt = ps.GetItemGroup("Name", txtsearch.Text);
            if (dt.Rows.Count == 1)
            {
                itemgroup_id = int.Parse(dt.Rows[0][0].ToString());
                txtgroup.Text = dt.Rows[0][1].ToString();
                txtnotes.Text = dt.Rows[0][2].ToString();
                cmbmaingroup.SelectedValue = dt.Rows[0][3].ToString();
            }
            else
            {
                MessageBox.Show("This Item Group Name Not Found");
            }
        }
    }
}
