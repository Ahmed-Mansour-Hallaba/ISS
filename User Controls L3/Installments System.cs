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

namespace Project.User_Controls_L3
{
    public partial class Installments_System : UserControl
    {
        //Showing UserControl Code
        private static Installments_System _ISU3;
        public static Installments_System ISU3
        {
            get
            {
                if (_ISU3 == null)
                {
                    _ISU3 = new Installments_System();
                }
                return _ISU3;
            }
        }
        int installment_id = -1;
        projectstored ps = new projectstored();
        public Installments_System()
        {
            InitializeComponent();
           
           autocomplete();
            // Fill Customer ComboBox
            DataTable dt1 = ps.GetCustomers();
            ps.fillcombo(cmbcustomer, dt1, "CustomerName", "CustomerID", "select customer");
            txttotal.ReadOnly = true;
            txtinstallmentvalue.ReadOnly = true;
            
        }
        private void calc()
        {
            double x,y,z,t;
            double v;
            if(!double.TryParse(txtpriceorigin.Text,out x))
            {
                x = 0;
            }

            if (!double.TryParse(txtprofit.Text, out y))
            {
                y = 0;
            }

            if (!double.TryParse(txtinstallmentno.Text, out z))
            {
                z = 1;
            }
            z = Math.Max(1, z);
            t = x + y;
            txttotal.Text = t.ToString();
            v = t / z;
            txtinstallmentvalue.Text = v.ToString();

        }
        private void btn_Addmanagement_Click(object sender, EventArgs e)
        {
            //------Customers uc
            AddUsercontrol form = new AddUsercontrol();
            form.panel2.Controls.Add(CustomerDataUCL2.CDU2);
            form.ShowDialog();
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
            installment_id = -1;
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
            if (s.SelectedIndex == -1 || s.Text== "select customer")
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
            if (validatecm(cmbcustomer)) { }
            else if (validateTextBox(txtpriceorigin)) { }
            else if (validateTextBox(txtpurpose)) { }
            else if (validateTextBox(txtprofit)) { }
            else if (validateTextBox(txttotal)) { }
            else if (validateTextBox(txtinstallmentno)) { }
            //else if (validateTextBox(txtpayinadvance)) { }
            //else if (validateTextBox(txtinstallmentvalue)) { }
            else if (validatecm(cmbpaymenttype)) { }
            else if (ps.InsertNewInstallment(Convert.ToInt32(cmbcustomer.SelectedValue), double.Parse(txtpriceorigin.Text), double.Parse(txtprofit.Text), int.Parse(txtinstallmentno.Text), double.Parse(txtpayinadvance.Text), dateTimePicker1.Text, cmbpaymenttype.SelectedItem.ToString(), txtpurpose.Text, rtbnotes.Text))
            {
                MessageBox.Show("System added Successfully");
                btnnew_Click(sender, e);
                cmbcustomer.Text = "select customer";
            }
            else
            {
                MessageBox.Show("An Error Occurred");
            }
        }
        //DeleteButton's Code
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (validatecm(cmbcustomer)) { }
            else if (validateTextBox(txtpriceorigin)) { }
            else if (validateTextBox(txtpurpose)) { }
            else if (validateTextBox(txtprofit)) { }
            else if (validateTextBox(txttotal)) { }
            else if (validateTextBox(txtinstallmentno)) { }
            //else if (validateTextBox(txtpayinadvance)) { }
            //else if (validateTextBox(txtinstallmentvalue)) { }
            else if (validatecm(cmbpaymenttype)) { }
           
            else
            {
                try
                {
                    ps.DeleteInstallment(installment_id);
                    MessageBox.Show("deleted success");
                    btnnew_Click(sender, e);
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
            if (validatecm(cmbcustomer)) { }
            else if (validateTextBox(txtpriceorigin)) { }
            else if (validateTextBox(txtpurpose)) { }
            else if (validateTextBox(txtprofit)) { }
            else if (validateTextBox(txttotal)) { }
            else if (validateTextBox(txtinstallmentno)) { }
            //else if (validateTextBox(txtpayinadvance)) { }
            //else if (validateTextBox(txtinstallmentvalue)) { }
            else if (validatecm(cmbpaymenttype)) { }
            
            else if (ps.UpdateInstallment(installment_id,int.Parse(cmbcustomer.Text),double.Parse(txtpriceorigin.Text),double.Parse(txtprofit.Text),int.Parse(txtinstallmentno.Text),double.Parse(txtpayinadvance.Text),dateTimePicker1.Text,cmbpaymenttype.Text,txtpurpose.Text,rtbnotes.Text))
            {
                MessageBox.Show("Updated Successfully");
                btnnew_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Your Update Operation Failed");
            }
        }
        //SearchButton's Code
        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txtsearch)) { }
            else
            {
                DataTable dt = ps.GetInstallements("CustomerID", txtsearch.Text);
                if (dt.Rows.Count == 1)
                {
                    installment_id = int.Parse(dt.Rows[0][0].ToString());
                    cmbcustomer.SelectedValue = dt.Rows[0][1].ToString();
                    txtpriceorigin.Text = dt.Rows[0][2].ToString();
                    txtprofit.Text = dt.Rows[0][3].ToString();
                    txtinstallmentno.Text = dt.Rows[0][4].ToString();
                    txtpayinadvance.Text = dt.Rows[0][5].ToString();
                    dateTimePicker1.Text = dt.Rows[0][6].ToString();
                    cmbpaymenttype.SelectedValue = dt.Rows[0][7].ToString();
                    txtpurpose.Text = dt.Rows[0][8].ToString();
                    rtbnotes.Text = dt.Rows[0][9].ToString();

                    SearchButton_Click(sender, e);
                }

                else
                {
                    MessageBox.Show("attendence Not Found");
                }
            }
        }
        //AutoComplete Function
        public void autocomplete()
        {
            txtsearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtsearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            DataTable dt = ps.GetInstallements();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string name = dt.Rows[i]["CustomerID"].ToString();
                col.Add(name);
            }
            txtsearch.AutoCompleteCustomSource = col;
        }

        private void cmb_serach_SelectedIndexChanged(object sender, EventArgs e)
        {
            autocomplete();
        }

        private void txtpriceorigin_TextChanged(object sender, EventArgs e)
        {
            calc();
        }

        private void txtprofit_TextChanged(object sender, EventArgs e)
        {
            calc();
        }

        private void txtinstallmentno_TextChanged(object sender, EventArgs e)
        {
            calc();
        }

        private void txtpriceorigin_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtprofit_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txttotal_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtinstallmentno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("This Field Must Be Number");
            }
        }

        private void txtpayinadvance_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtinstallmentvalue_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtpurpose_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Purpose Must Be Text");
            }
        }

        private void txtpurpose_TextChanged(object sender, EventArgs e)
        {
            //if (!System.Text.RegularExpressions.Regex.IsMatch(txtpurpose.Text, "^[a-zA-Z ]"))
            //{
            //    MessageBox.Show("This textbox accepts only alphabetical characters");
            //    txtpurpose.Clear();

            //}
        }

        private void cmbcustomer_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetCustomers();
            if (cmbcustomer.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(cmbcustomer, ps.GetCustomers(), "CustomerName", "CustomerID", "Select Customer");

            }
        }
    }
}
