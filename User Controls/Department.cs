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
namespace Project.User_Controls
{
    public partial class Department : UserControl
    {
        projectstored ps = new projectstored();
        int dept_id = -1;
        public static Department _Departmenuc;
        public static Department Departmenuc
        {
            get
            {
                if (_Departmenuc == null)
                {
                    _Departmenuc = new Department();
                }
                return _Departmenuc;
            }
        }

        public Department()
        {
            InitializeComponent();
            //Fill ComboBox
            ps.fillcombo(cmbmanagement, ps.GetMainManagement(), "Name", "MainManagementID", "Select MainManagement");
            autocomplete();
        }

        private void Department_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
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
        public void autocomplete()
        {
            txtsearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtsearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            DataTable dt = ps.GetMainDepartment();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                {
                    string name = dt.Rows[i]["Name"].ToString();
                    col.Add(name);
                }
            }
            txtsearch.AutoCompleteCustomSource = col;
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is TextBox || c is RichTextBox)
                {
                    c.Text = "";
                }
            }
            dept_id = -1;
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
        public bool validatecm(ComboBox s)
        {
            if (s.SelectedIndex == -1 || s.Text == "Select MainManagement")
            {
                MessageBox.Show(s.Name + "Field is required");
                s.Focus();
                return true;
            }
            else { return false; }

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txtdepartment)) { }
            else if (validatecm(cmbmanagement)) { }
            else if (ps.InsertNewDepartment(txtdepartment.Text,cmbmanagement.Text))
            {
                MessageBox.Show("Department added Successfully");
                btnnew_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Department already Exists");
            }
            autocomplete();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {

            try
            {
                if (validateTextBox(txtdepartment)) { }
                else if (validatecm(cmbmanagement)) { }
                else
                {
                    ps.DeleteMainDepartment(txtdepartment.Text);
                    btnnew_Click(sender, e);
                    MessageBox.Show("Department Deleted Successfully");

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Your Delete operation Failed");
            }
            }
        

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txtdepartment)) { }
            else if (validatecm(cmbmanagement)) { }
            else if (ps.InsertNewDepartment(txtdepartment.Text, cmbmanagement.Text))
            {
                MessageBox.Show("The Record is Updated Successfully");
                btnnew_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Your Update Operation Failed");
            }
            autocomplete();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txtsearch)) { }
            else
            {
                DataTable dt = ps.GetMainDepartment("Name", txtsearch.Text);
                if (dt.Rows.Count == 1)
                {
                    dept_id = int.Parse(dt.Rows[0][0].ToString());
                    txtdepartment.Text = dt.Rows[0][1].ToString();
                    cmbmanagement.Text = dt.Rows[0][2].ToString();

                }
                else
                {
                    MessageBox.Show("This Department Name Not Found");
                }
            }
        }

        private void btn_Addmanagement_Click(object sender, EventArgs e)
        {
            AddUsercontrol form = new AddUsercontrol();
            form.panel2.Controls.Add(MainManagementUC2.mmuc2);
            form.ShowDialog();
        }

        private void cmbmanagement_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetMainManagement();
            if (cmbmanagement.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(cmbmanagement, ps.GetMainManagement(), "Name", "MainManagementID", "Select Main Management");

            }
        }
    }
}
