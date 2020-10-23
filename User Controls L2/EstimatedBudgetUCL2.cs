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
    public partial class EstimatedBudgetUCL2 : UserControl
    {
        int budget_id = -1;
        projectstored ps = new projectstored();
        private static EstimatedBudgetUCL2 _EBU2;
        public static EstimatedBudgetUCL2 EBU2
        {
            get
            {
                if (_EBU2 == null)
                {
                    _EBU2 = new EstimatedBudgetUCL2();
                }
                return _EBU2;
            }
        }
        private void fillyears()
        {
            //  ps.fillcombo(cm_searchyear, ps.GetEstimatedBudgets(), "YEAR", "ID", "Select financial year");

            cm_searchyear.DataSource = ps.GetEstimatedBudgets();
            cm_searchyear.DisplayMember = "YEAR";
            cm_searchyear.ValueMember = "ID";
        }
        public EstimatedBudgetUCL2()
        {
            InitializeComponent();
            fillyears();
            dt_financialyear.Format = DateTimePickerFormat.Custom;
            dt_financialyear.CustomFormat = "yyyy";
            dt_financialyear.ShowUpDown = true;
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
      

        private void btn_New_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is TextBox || c is RichTextBox)
                {
                    c.Text = "";
                }
            }
            budget_id = -1;
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
        public bool validateMaskedTextBox(MaskedTextBox s)
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

        private void btn_Save_Click(object sender, EventArgs e)
        {
        if (validateTextBox(txt_ExcpectedPurchases)) { }
            else if (validateTextBox(txt_expectedincome)) { }
            else if (validateMaskedTextBox(txt_Excpectedsales)) { }
            else if (validateTextBox(txt_expextedexpense)) { }
            else if (validateTextBox(txt_ExcpectedProfits)) { }
            
            else if (ps.InsertNewEstimatedBudget(int.Parse(dt_financialyear.Text), double.Parse(txt_ExcpectedPurchases.Text), double.Parse(txt_expectedincome.Text), double.Parse(txt_Excpectedsales.Text), double.Parse(txt_expextedexpense.Text), double.Parse(txt_ExcpectedProfits.Text), richTextBox_Notes.Text))
            {
                MessageBox.Show("Estimated Budget added Successfully");
                fillyears();
                btn_New_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Financial Year already Exists");

            }
            /*else
            {
                DataTable dt = ps.GetEstimatedBudgets();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string name = dt.Rows[i]["YEAR"].ToString();

                    if (txt_financialyear.Text == name)
                    {
                        MessageBox.Show("Financial Year already Exists");
                    }
                }
                autocomplete();
            }*/
        }
        private void btnsearch_Click(object sender, EventArgs e)
        {
           /* if (cm_searchyear.SelectedIndex>=0) {
                MessageBox.Show("Select Financial year");
            }
            else
            {*/
                DataTable dt = ps.GetEstimatedBudgets("YEAR", cm_searchyear.Text);
                if (dt.Rows.Count == 1)
                {
                    budget_id = int.Parse(dt.Rows[0][0].ToString());
                    dt_financialyear.Value =DateTime.Parse("1-1-"+dt.Rows[0][1].ToString());
                    txt_ExcpectedPurchases.Text = dt.Rows[0][2].ToString();
                    txt_expectedincome.Text = dt.Rows[0][3].ToString();
                    txt_Excpectedsales.Text = dt.Rows[0][4].ToString();
                    txt_expextedexpense.Text = dt.Rows[0][5].ToString();
                    txt_ExcpectedProfits.Text = dt.Rows[0][6].ToString();
                    richTextBox_Notes.Text = dt.Rows[0][7].ToString();
                }
                else
                {
                    MessageBox.Show("Please Enter Value You Need To Search");
                }
            //}
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
             if (validateTextBox(txt_ExcpectedPurchases)) { }
            else if (validateTextBox(txt_expectedincome)) { }
            else if (validateMaskedTextBox(txt_Excpectedsales)) { }
            else if (validateTextBox(txt_expextedexpense)) { }
            else if (validateTextBox(txt_ExcpectedProfits)) { }
            
            else
            {
               /* DataTable dt = ps.GetEstimatedBudgets();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string name = dt.Rows[i]["YEAR"].ToString();

                    if (txt_financialyear.Text == name)
                    {
                        MessageBox.Show("Financial Year already Exists");
                    }

                    else */if (ps.UpdateEstimatedBudget(budget_id, int.Parse(dt_financialyear.Text), double.Parse(txt_ExcpectedPurchases.Text), double.Parse(txt_expectedincome.Text), double.Parse(txt_Excpectedsales.Text), double.Parse(txt_expextedexpense.Text), double.Parse(txt_ExcpectedProfits.Text), richTextBox_Notes.Text))
                    {
                        MessageBox.Show("Budget Updated Successfully");
                        btn_New_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Your Update Operation Failed");
                    }
               // }
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (budget_id==-1) {
                MessageBox.Show("Select year");
            }
           
            else
            {
                try
                {
                    ps.DeleteEstimatedBudget(budget_id);
                    MessageBox.Show("Estimated Budget deleted Successfully");
                    btn_New_Click(sender, e);
                }
                catch (SqlException)
                {
                    MessageBox.Show("Your Delete Operation Failed");
                }
            }
        }
        private void txt_financialyear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Year Must Be Number");
            }
        }

        private void txt_ExcpectedPurchases_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_expectedincome_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_Excpectedsales_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_expextedexpense_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_ExcpectedProfits_KeyPress(object sender, KeyPressEventArgs e)
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

        private void EstimatedBudgetUCL2_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchPanel.Width = 0;
        }
    }
}
