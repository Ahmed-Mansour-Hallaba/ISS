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
using System.Text.RegularExpressions;

namespace Project.NewUserControls
{
    public partial class DelegateRegistrationUC2 : UserControl
    {
        //Showing UserControl Code
        public static DelegateRegistrationUC2 _drguc2;
        public static DelegateRegistrationUC2 drguc2
        {
            get
            {
                if (_drguc2 == null)
                {
                    _drguc2 = new DelegateRegistrationUC2();
                }
                return _drguc2;
            }
        }
        int delegate_id = -1;
        projectstored ps = new projectstored();
        public DelegateRegistrationUC2()
        {
            InitializeComponent();
            //Code For Filling the ComboBox
            DataTable dt = ps.GetTableAttributes("DelegatesView");
            DataRow dr = dt.NewRow();
            dr["COLUMN_NAME"] = "Select search parameter";
            dt.Rows.InsertAt(dr, 0);
            cmbsearch.DataSource = dt;
            cmbsearch.DisplayMember = "COLUMN_NAME";
            cmbsearch.BindingContext = this.BindingContext;
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void txtmobile_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtmobile.Text, "^01[0-2]{1}[0-9]{9}"))
            {
                MessageBox.Show("Please enter phone in coreect format such as 01111111111.");
                txtmobile.Clear();
            }
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
            delegate_id = -1;
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


        //SaveButton's Code
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txtdelegatename)) { }
            else if (validateTextBox(txtratio)) { }
            else if (validatemobile(txtphone)) { }
            else if (validatemobile(txtmobile)) { }
            else if (validateTextBox(txtsalary)) { }
            else if (ValidateChildren(ValidationConstraints.None) && ps.InsertNewDelegate(txtdelegatename.Text, int.Parse(txtratio.Text), txtgoverner.Text, txtcountry.Text, txtphone.Text, txtmobile.Text, double.Parse(txtsalary.Text)))
            {
                MessageBox.Show("The Data Saved Successfully");
                btnnew_Click(sender, e);
            }
            else
            {
                MessageBox.Show("An Error Occurred");
            }
            autocomplete();
        }
        //UpdateButton's Code
        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txtdelegatename)) { }
            else if (validateTextBox(txtratio)) { }
            else if (validateTextBox(txtsalary)) { }
            else if (ps.UpdateDelegate(delegate_id, txtdelegatename.Text, int.Parse(txtratio.Text), txtgoverner.Text, txtcountry.Text, txtphone.Text, txtmobile.Text, double.Parse(txtsalary.Text), rchtxtnotes.Text))
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
        //AutoComplete Function
        public void autocomplete()
        {
            txtsearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtsearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            DataTable dt = ps.GetDelegate();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (cmbsearch.Text == "DelegateName")
                {
                    string name = dt.Rows[i]["DelegateName"].ToString();
                    col.Add(name);
                }

                else if (cmbsearch.Text == "Phone")
                {
                    txtsearch.Clear();
                    string name = dt.Rows[i]["Phone"].ToString();
                    col.Add(name);
                }
                else if (cmbsearch.Text == "Mobile")
                {
                    txtsearch.Clear();
                    string name = dt.Rows[i]["Mobile"].ToString();
                    col.Add(name);
                }
            }

            txtsearch.AutoCompleteCustomSource = col;
        }
        private void cmbsearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            autocomplete();
        }

        private void pcontrols_Paint(object sender, PaintEventArgs e)
        {

        }
        //validate TextBox
      

        //SearchButton's Code
        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txtsearch)) { }
            else
            {
                DataTable dt = ps.GetDelegate(cmbsearch.Text, txtsearch.Text);
                if (dt.Rows.Count == 1)
                {
                    delegate_id = int.Parse(dt.Rows[0][0].ToString());
                    txtdelegatename.Text = dt.Rows[0][1].ToString();
                    txtratio.Text = dt.Rows[0][2].ToString();
                    txtgoverner.Text = dt.Rows[0][3].ToString();
                    txtcountry.Text = dt.Rows[0][4].ToString();
                    txtphone.Text = dt.Rows[0][5].ToString();
                    txtmobile.Text = dt.Rows[0][6].ToString();
                    txtsalary.Text = dt.Rows[0][7].ToString();
                    rchtxtnotes.Text = dt.Rows[0][8].ToString();
                }
                else
                {
                    MessageBox.Show("This Delegate Not Esists");
                }
            }
        }
        //DeleteButton's Code
        private void btndelete_Click(object sender, EventArgs e)
        {
            int NumberOfClick = 0;
            ++NumberOfClick;
            switch (NumberOfClick)
            {
                case 1:
                    try
                    {
                        if (validateTextBox(txtdelegatename)) { }
                        else if (validateTextBox(txtratio)) { }
                        else if (validateTextBox(txtsalary)) { }
                        else
                        {
                            ps.DeleteDelegate(txtdelegatename.Text);
                            btnnew_Click(sender, e);
                            MessageBox.Show("The Delegate Deleted Successfully");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Your Delete operation Failed");
                    }

                    break;
                case 2:
                    MessageBox.Show( "Fields is required");
                    break;
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
        //Validation Function
        //public void Validation()
        //{

        //    TextBox[] newTextBox = { txtdelegatename, txtratio, txtsalary };
        //    for (int inti = 0; inti <3; inti++)
        //    {
        //        if (newTextBox[inti].Text == string.Empty)
        //        {
        //            MessageBox.Show("Please fill The Required TextBoxes");
        //            newTextBox[inti].Focus();
        //            return;
        //        }
        //    }
        //}
        private void txtdelegatename_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Name Must Be Text");
            }
        }
        private void txtratio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Ratio Must Be Number");
            }
        }


        private void txtgoverner_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Governer Must Be Text");
            }
        }

        private void txtcountry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Country Must Be Text");
            }
        }

        private void txtphone_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtmobile_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtsalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                MessageBox.Show("must be number");
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtphone_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtphone.Text, "^01[0-2]{1}[0-9]{9}"))
            {
                MessageBox.Show("Please enter phone in coreect format such as 01111111111.");
                txtphone.Clear();

            }
        }

        private void DelegateRegistrationUC2_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }
    }
}
