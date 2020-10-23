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
namespace Project.User_Controls_L2
{
    public partial class VendorsPaymentsUCL2 : UserControl
    {
        //Showing UserControl Code
        private static VendorsPaymentsUCL2 _VPL2;
        public static VendorsPaymentsUCL2 VPL2
        {
            get
            {
                if (_VPL2 == null)
                {
                    _VPL2 = new VendorsPaymentsUCL2();
                }
                return _VPL2;
            }
        }
        int vendorpayment_id = -1;
        projectstored ps = new projectstored();
        public VendorsPaymentsUCL2()
        {
            InitializeComponent();
            ps.fillcombo(comboBox_Vendor, ps.GetVendor(), "Name", "VendorID", "Select Vendor");
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
        //AutoComplete Function
        public void autocomplete()
        {
            txtsearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtsearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            DataTable dt = ps.GetVendorPayments();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string name = dt.Rows[i]["Amount"].ToString();
                col.Add(name);

            }
            txtsearch.AutoCompleteCustomSource = col;
        }
        //NewButton's Code
        private void btn_New_Click(object sender, EventArgs e)
        {
            foreach (Control c  in tableLayoutPanel1.Controls)
            {
                if (c is TextBox || c is RichTextBox)
                {
                    c.Text = " ";
                }
            }
            vendorpayment_id = -1;
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
            if (s.SelectedIndex == -1 || s.Text== "Select Vendor")
            {
                MessageBox.Show(s.Name + "Field is required");
                s.Focus();
                return true;
            }
            else { return false; }

        }
        //SaveButton's Code
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (validatecm(comboBox_Vendor)) { }
            else if (validateTextBox(txt_Amount)) { }

            else if (ps.InsertNewVendorPayments(int.Parse(comboBox_Vendor.SelectedValue.ToString()), int.Parse(txt_Amount.Text), richTextBox_Notes.Text))
            {
                MessageBox.Show("Vendor Payment added Successully");
                btn_New_Click(sender, e);
                comboBox_Vendor.Text = "Select Vendor";
            }
            else
            {
                MessageBox.Show("An Error Occurred");
            }
        }
        
        //DeleteButton's Code
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            
            int NumberOfClick = 0;
            ++NumberOfClick;
            switch (NumberOfClick)
            {
                case 1:
                        try
                        {
                        if (validatecm(comboBox_Vendor)) { }
                        else if (validateTextBox(txt_Amount)) { }
                        else if (validateRichTextBox(richTextBox_Notes)) { }
                        else 
                        {
                            ps.DeleteVendorPayment(vendorpayment_id);
                            MessageBox.Show("Vendor Payment deleted Successfully");
                            btn_New_Click(sender, e);
                            comboBox_Vendor.Text = "Select Vendor";
                        }
                        
                        }
                        catch (SqlException)
                        {
                            MessageBox.Show("Your Delete Operation Failed");
                        }
                    

                    break;
                case 2:
                    MessageBox.Show(txt_Amount.Name + "Field is required");

                    break;
            }

        }
        //UpdateButton's Code
        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (validatecm(comboBox_Vendor)) { }
            else if (validateTextBox(txt_Amount)) { }

            else if (ps.UpdateVendorPayments(vendorpayment_id, Convert.ToInt32(comboBox_Vendor.SelectedValue), double.Parse(txt_Amount.Text), richTextBox_Notes.Text))
            {
                MessageBox.Show("Vendor Updated Successfully");
                btn_New_Click(sender, e);
                comboBox_Vendor.Text = "Select Vendor";
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
                DataTable dt = ps.GetVendorPayments("Amount", txtsearch.Text);
                if (dt.Rows.Count == 1)
                {
                    vendorpayment_id = int.Parse(dt.Rows[0][0].ToString());
                    comboBox_Vendor.SelectedValue = dt.Rows[0][1].ToString();
                    txt_Amount.Text = dt.Rows[0][2].ToString();
                    dateTimePicker_Date.Text = dt.Rows[0][3].ToString();
                    richTextBox_Notes.Text = dt.Rows[0][4].ToString();
                    SearchButton_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Payment Not Found");
                }
            }
        }

        private void txt_Amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Amount Must Be Number");
            }
        }

        private void VendorsPaymentsUCL2_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchPanel.Width = 0;
        }

        private void comboBox_Vendor_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetVendor();
            if (comboBox_Vendor.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(comboBox_Vendor, ps.GetVendor(), "Name", "VendorID", "Select Bank");

            }
        }
    }
}
