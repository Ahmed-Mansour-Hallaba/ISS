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

namespace Project
{
    public partial class UnitsUC2 : UserControl
    {
        int unit_ID = -1;
        //Showing UserControl Code
        private static UnitsUC2 _unuc2;
        public static UnitsUC2 unuc2
        {
            get
            {
                if (_unuc2 == null)
                {
                    _unuc2 = new UnitsUC2();
                }
                return _unuc2;
            }
        }
        public UnitsUC2()
        {
            InitializeComponent();
            autocomplete();
        }
        //AutoComplete Function
        public void autocomplete()
        { 
            txt_search.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_search.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            DataTable dt = ps.GetUnit();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string name = dt.Rows[i]["Name"].ToString();
                col.Add(name);

            }
            txt_search.AutoCompleteCustomSource = col;
        }
        projectstored ps = new projectstored();
        //NewButton Function
        private void btn_new_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
            unit_ID = -1;
        }
        //SaveButton's Code
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_unitname.Text=="")
            {
                MessageBox.Show("This Field is Required");
            }

           else if (ps.InsertNewUnit(txt_unitname.Text))
            {
              
                MessageBox.Show("Unit added Successfully");
                btn_new_Click(sender, e);
            }
            else
            {
                MessageBox.Show("An Error Occurred");
            }
            autocomplete();
        }
        //DeleteButton's Function
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (txt_unitname.Text == "")
            {
                MessageBox.Show("Please Select Unit You Need To Delete");
            }
            else
            {
                try
                {

                    ps.DeleteMainUnit(txt_unitname.Text);
                    btn_new_Click(sender, e);
                    MessageBox.Show("Your Delete Success");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Your Delete  Operation Failed");
                }
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
        //SearchButton's Code
        private void Btn_search_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txt_search)) { }
            else
            {
                DataTable dt = ps.GetUnit("Name", txt_search.Text);
                if (dt.Rows.Count == 1)
                {
                    unit_ID = int.Parse(dt.Rows[0][0].ToString());
                    txt_unitname.Text = dt.Rows[0][1].ToString();
                    SearchButton_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("This Unit is not Found");
                }
            }
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
        //UpdateButton's Code
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (txt_unitname.Text=="")
            {
                MessageBox.Show("This Field is Required");
            }
            else if (ps.UpdateUnit(unit_ID, txt_unitname.Text))
            {
                MessageBox.Show("Unit Updated Successfully");
                btn_new_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Your Update Operation Failed");
            }
            autocomplete();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchPanel.Width = 0;
        }

        private void txt_unitname_TextChanged(object sender, EventArgs e)
        { }

        private void txt_unitname_Validating(object sender, CancelEventArgs e)
        {
        }

        private void txt_unitname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Unit Must Be Text");
            }
        }

        private void UnitsUC2_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }
    }
}

