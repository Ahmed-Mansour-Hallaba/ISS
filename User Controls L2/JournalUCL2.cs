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
    public partial class JournalUCL2 : UserControl
    {
        //Showing UserControl Code
        public static JournalUCL2 _Jouuc2;
        public static JournalUCL2 Jouuc2
        {
            get
            {
                if (_Jouuc2 == null)
                {
                    _Jouuc2 = new JournalUCL2();
                }
                return _Jouuc2;
            }
        }
        public JournalUCL2()
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
            DataTable dt = ps.GetJounrals();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string name = dt.Rows[i]["Amount"].ToString();
                col.Add(name);
            }
            txtsearch.AutoCompleteCustomSource = col;
        }
        int journal_id = -1;
        projectstored ps = new projectstored();
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
        //NewButton's Code
        private void btn_New_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is TextBox || c is RichTextBox)
                {
                    c.Text = "";
                }
               
            }
            journal_id = -1;
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
        //SaveButton's Code
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txt_year)) { }
            else if(validatecm(comboBox_Type)){ }
            else if (validatecm(comboBox_To)) { }
            else if (validateTextBox(txt_Amount)) { }
            else if (validatecm(comboBox_Description)) { }
            
            else if (ps.InsertNewJournal(comboBox_Type.SelectedItem.ToString(), comboBox_To.SelectedItem.ToString(), double.Parse(txt_Amount.Text), comboBox_Description.SelectedItem.ToString()))
            {
                MessageBox.Show("Journal added Successfully");
                btn_New_Click(sender, e);
            }
            else
            {
                MessageBox.Show("An Error Occurred");
            }

            autocomplete();
        }

        private void cmbsearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        //DeleteButtons's Code
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txt_year)) { }
            else if (validatecm(comboBox_Type)) { }
            else if (validatecm(comboBox_To)) { }
            else if (validateTextBox(txt_Amount)) { }
            else if (validatecm(comboBox_Description)) { }
            
            else
            {
                try
                {
                    ps.DeleteJounral(journal_id);
                    MessageBox.Show("Journal deleted Successfully");
                    btn_New_Click(sender, e);
                }
                catch (SqlException)
                {
                    MessageBox.Show("Your Delete Operation Failed");
                }
            }
        }
        //SearchButton's Code
        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txtsearch)) { }
            else
            {
                DataTable dt = ps.GetJounrals("Amount", txtsearch.Text);
                if (dt.Rows.Count == 1)
                {
                    journal_id = int.Parse(dt.Rows[0][0].ToString());
                    txt_year.Text = dt.Rows[0][1].ToString();
                    comboBox_Type.Text = dt.Rows[0][2].ToString();
                    comboBox_To.Text = dt.Rows[0][3].ToString();
                    txt_Amount.Text = dt.Rows[0][4].ToString();
                    comboBox_Description.Text = dt.Rows[0][5].ToString();
                    SearchButton_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Journal Not Found");
                }
            }
        }
        //UpdateButtons's Code
        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txt_year)) { }
            else if (validatecm(comboBox_Type)) { }
            else if (validatecm(comboBox_To)) { }
            else if (validateTextBox(txt_Amount)) { }
            else if (validatecm(comboBox_Description)) { }
           
            else if (ps.UpdateJournal(journal_id, comboBox_Type.Text, comboBox_To.Text, double.Parse(txt_Amount.Text), richTextBox1.Text))
            {
                MessageBox.Show("Journal Updated Successfully");
                btn_New_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Your Update Operation Failed");
            }
            autocomplete();
        }

        private void txt_Amount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void JournalUCL2_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchPanel.Width = 0;
        }
    }
}
