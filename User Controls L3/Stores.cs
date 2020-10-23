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
using Project.User_Controls_L2;
using System.Text.RegularExpressions;

namespace Project.User_Controls_L3
{
    public partial class Stores : UserControl
    {
        projectstored ps = new projectstored();
        int storeid = -1;
        public static Stores _SUC3;
        public static Stores SUC3
        {
            get
            {
                if (_SUC3 == null)
                {
                    _SUC3 = new Stores();
                }
                return _SUC3;
            }
        }
        public Stores()
        {
            InitializeComponent();
            ps.fillcombo(cm_emp, ps.GetEmployees(), "EmployeeName", "EmployeeID", "Select Employee");
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
            if (s.SelectedIndex == -1 ||s.Text== "Select Employee")
            {
                MessageBox.Show(s.Name + "Field is required");
                s.Focus();
                return true;
            }
            else { return false; }

        }
        //ValidateMobile
        
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchPanel.Width = 0;
        }

        private void btn_Addmanagement_Click(object sender, EventArgs e)
        {
            //Employee defination uc
            AddUsercontrol form = new AddUsercontrol();
            form.panel2.Controls.Add(EmployeeDefintionUCL2.EDU2);
            form.ShowDialog();
        }
        private void btnnew_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if(c is TextBox)
                {
                    c.Text = " ";
                }
                if (c is RichTextBox)
                {
                    c.Text = "";
                }
                if (c is ComboBox)
                {
                    c.Text = " ";
                }
            }
            storeid = -1;
        }
        public bool validatemobile(TextBox s)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(s.Text, "^01[0-5]{1}[0-9]{8}"))
            {
                MessageBox.Show(s.Name + " must be in mobile format 01012345678.");
                s.Focus();
                return true;

            }
            else { return false; }

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            //name emp phone address notes
            if (validateTextBox(txt_storename)) { }
            else if (validatecm(cm_emp)) { }
            else if (validateTextBox(txt_phone)) { }
            else if (validatemobile(txt_phone)) { }
            else if (validateRichTextBox(txt_address)) { }
            else if (ps.InsertNewStore(txt_storename.Text, Convert.ToInt32(cm_emp.SelectedValue), txt_phone.Text, txt_address.Text, txt_notes.Text))
            {
                MessageBox.Show("Store added Successfully");
                autocomplete();
                btnnew_Click(sender, e);
                cm_emp.Text = "Select Employee";
            }
            else
            {
                MessageBox.Show("An Error Occurred");
            }
        }
        public void autocomplete()
        {
            txtsearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtsearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            DataTable dt = ps.GetStoresData();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string name = dt.Rows[i]["StoreName"].ToString();
                col.Add(name);
            }
            txtsearch.AutoCompleteCustomSource = col;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txt_storename)) { }
            else if (validatecm(cm_emp)) { }
            else if (validateTextBox(txt_phone)) { }
            else if (validatemobile(txt_phone)) { }
            else if (validateRichTextBox(txt_address)) { }
            //else if (validateRichTextBox(txt_notes)) { }
            else
            {
                try
                {
                    ps.DeleteStore(storeid);
                    MessageBox.Show("Store deleted successfuly");
                    autocomplete();
                    btnnew_Click(sender, e);
                    cm_emp.Text = "Select Employee";
                }
                catch (SqlException)
                {

                    MessageBox.Show("Your Update Operation Failed");
                }
            }
        }
        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txt_storename)) { }
            else if (validatecm(cm_emp)) { }
            else if (validateTextBox(txt_phone)) { }
            else if (validatemobile(txt_phone)) { }
            else if (validateRichTextBox(txt_address)) { }
            //else if (validateRichTextBox(txt_notes)) { }

            else if (ps.UpdateStoreData(storeid, txt_storename.Text, Convert.ToInt32(cm_emp.SelectedValue), txt_phone.Text, txt_address.Text, txt_notes.Text))
            {
                MessageBox.Show("Store Updated Successfully");
                btnnew_Click(sender, e);
                cm_emp.Text = "Select Employee";
            }
            else
            {
                MessageBox.Show("Your Update Operation Failed");
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txtsearch)) { }
            else
            {
                DataTable dt = ps.GetStoresData("StoreName", txtsearch.Text);
                if (dt.Rows.Count == 1)
                {

                    storeid = Convert.ToInt32(dt.Rows[0][0]);
                    txt_storename.Text = dt.Rows[0][1].ToString();
                    cm_emp.SelectedValue = dt.Rows[0][2].ToString();
                    txt_phone.Text = dt.Rows[0][3].ToString();
                    txt_address.Text = dt.Rows[0][4].ToString();
                    txt_notes.Text = dt.Rows[0][5].ToString();


                }
                else
                {
                    MessageBox.Show("Store not found");
                }
            }
        }

        private void txt_storename_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar)&&!char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Store Name Must Be text");
            }
        }

        //private void txt_phone_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        //    //{
        //    //    e.Handled = true;
        //    //    MessageBox.Show("Phone Must Be Number");
        //    //}
        //}

        private void txt_address_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Must Be Number");
            }
        }

        private void txt_phone_TextChanged(object sender, EventArgs e)
        {
        }

        private void Stores_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void cm_emp_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetEmployees();
            if (cm_emp.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(cm_emp, ps.GetEmployees(), "EmployeeName", "EmployeeID", "Select Employee");

            }
        }
    }
}
