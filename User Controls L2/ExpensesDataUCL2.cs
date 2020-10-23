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
using Project.NewUserControls;
using Project.User_Controls;
namespace Project.User_Controls_L2
{
    public partial class ExpensesDataUCL2 : UserControl
    {
        //Showing UserControl Code
        public static ExpensesDataUCL2 _Educ2;
        public static ExpensesDataUCL2 EDuc2
        {
            get
            {
                if (_Educ2 == null)
                {
                    _Educ2 = new ExpensesDataUCL2();
                }
                return _Educ2;
            }
        }
        public ExpensesDataUCL2()
        {
            InitializeComponent();
            //fill Car combo box
            DataTable dt1 = ps.GetCars();
            DataRow dr1 = dt1.NewRow();
            dr1["CarNo"] = "No Car";
            dr1["CarID"] = -1;
            dt1.Rows.InsertAt(dr1, 0);
            cmbcarno.DataSource = dt1;
            cmbcarno.DisplayMember = "CarNo";
            cmbcarno.ValueMember = "CarID";
            cmbcarno.BindingContext = this.BindingContext;
            //fill Expense Type combo box
            DataTable dt2 = ps.GetExpenseType();
            DataRow dr2 = dt2.NewRow();
            dr2["Name"] = "No Expense";
            dr2["ExpenseTypeID"] = -1;
            dt2.Rows.InsertAt(dr2, 0);
            cmbexpensestype.DataSource = dt2;
            cmbexpensestype.DisplayMember = "Name";
            cmbexpensestype.ValueMember = "ExpenseTypeID";
            cmbexpensestype.BindingContext = this.BindingContext;

            autocomplete();
        }
        projectstored ps = new projectstored();
        int Expenses_id = -1;
        //AutoComplete Function
        public void autocomplete()
        {
            txtsearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtsearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            DataTable dt = ps.GetExpensesData();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string name = dt.Rows[i]["Value"].ToString();
                col.Add(name);

            }
            txtsearch.AutoCompleteCustomSource = col;
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
            Expenses_id = -1;
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
            if (s.Text == "No Car" || s.Text == "No Expense")
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
            if (validatecm(cmbexpensestype)) { }
            else if (validatecm(cmbcarno)) { }
            else if (validateTextBox(txtvalue)) { }
            
            else if (ps.InsertNewExpenseData(Convert.ToInt32(cmbexpensestype.SelectedValue), Convert.ToInt32(cmbcarno.SelectedValue), int.Parse(txtvalue.Text), rtbdescription.Text))
            {
                MessageBox.Show("Expenses Data added Successfully");
                btn_New_Click(sender, e);
            }
            else
            {
                MessageBox.Show("An Error Occurred");
            }
            autocomplete();
        }
        //SearchButton's Code
        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txtsearch)) { }
            else
            {
                DataTable dt = ps.GetExpensesData("Value", txtsearch.Text);
                if (dt.Rows.Count == 1)
                {
                    Expenses_id = int.Parse(dt.Rows[0][0].ToString());
                    cmbexpensestype.SelectedValue = dt.Rows[0][1].ToString();
                    cmbcarno.SelectedValue = dt.Rows[0][2].ToString();
                    txtvalue.Text = dt.Rows[0][3].ToString();
                    DTPicker.Text = dt.Rows[0][4].ToString();
                    rtbdescription.Text = dt.Rows[0][5].ToString();
                    SearchButton_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("This Expense Not Found");
                }

            }
        }
        //UpdateButton's Code
        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (validatecm(cmbexpensestype)) { }
            else if (validatecm(cmbcarno)) { }
            else if (validateTextBox(txtvalue)) { }
            
            else if (ps.UpdateExpenseData(Expenses_id, Convert.ToInt32(cmbexpensestype.SelectedValue), Convert.ToInt32(cmbcarno.SelectedValue), int.Parse(txtvalue.Text), rtbdescription.Text))
            {
                MessageBox.Show("Expense Updated Successfully");
                btn_New_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Your Update Operation Failed");
            }
            autocomplete();
        }
        //DeleteButton's Value
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (validatecm(cmbexpensestype)) { }
            else if (validatecm(cmbcarno)) { }
            else if (validateTextBox(txtvalue)) { }
            
            else
            {
                try
                {
                    ps.DeleteExpenseData(Expenses_id);
                    btn_New_Click(sender, e);
                    MessageBox.Show("Expense Deleted Successfully");

                }
                catch (SqlException)
                {
                    MessageBox.Show("Your Update Operation Failed");
                }
            }
        }
        ExpensesTypeUC2 ext;
        private void button1_Click(object sender, EventArgs e)
        {
            AddUsercontrol form = new AddUsercontrol();
            form.panel2.Controls.Add(ExpensesTypeUC2.ext);
            form.ShowDialog();
            
        }
        CarsUC2 cuc2;
        private void button2_Click(object sender, EventArgs e)
        {
            AddUsercontrol form = new AddUsercontrol();
            form.panel2.Controls.Add(CarsUC2.cuc2);
            form.ShowDialog();
        }

        private void txtvalue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Value Must Be Number");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchPanel.Width = 0;
        }

        private void ExpensesDataUCL2_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void cmbexpensestype_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetExpenseType();
            if (cmbexpensestype.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(cmbexpensestype, ps.GetExpenseType(), "Name", "ExpenseTypeID", "Select Expense");

            }
        }

        private void cmbcarno_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetCars();
            if (cmbcarno.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(cmbcarno, ps.GetCars(), "CarNo", "CarID", "Select Car");

            }
        }
    }
}
