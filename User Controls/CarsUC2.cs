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
using Project.User_Controls;
using System.Text.RegularExpressions;

namespace Project.NewUserControls
{
    public partial class CarsUC2 : UserControl
    {
        //Showing UserControl Code
        public static CarsUC2 _cuc2;
        public static CarsUC2 cuc2
        {
            get
            {
                if (_cuc2 == null)
                {
                    _cuc2 = new CarsUC2();
                }
                return _cuc2;
            }

        }
        int cars_id = -1;
        projectstored ps = new projectstored();
        public CarsUC2()
        {
            InitializeComponent();
            autocomplete();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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
        //NewButton's Code
        private void btnnew_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = " ";
                }
            }
            cars_id = -1;
        }
        //SaveButton's Code
        private void btnsave_Click(object sender, EventArgs e)
        {
            
            if (txtcarnumber.Text=="")
            {
                MessageBox.Show(txtcarnumber.Name + "Field is Required");
            }
            else if(ps.InsertNewCar(txtcarnumber.Text))
            {             
                MessageBox.Show("Car Number Saved Successfully");
                btnnew_Click(sender, e);
            }
            else
            {

                MessageBox.Show("An Error Occurred");
            }
            autocomplete();
        }
        //DeleteButton's Code
        int NumberOfClick = 0;
        private void btndelete_Click(object sender, EventArgs e)
        {

            //try
            //{


            //if (validateTextBox(txtcarnumber)) { }
            //else
            //{
            //    ps.DeleteCar(txtcarnumber.Text);
            //    btnnew_Click(sender, e);
            //    MessageBox.Show("The Car Number Deleted Successfully");
            //}
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Your Delete operation Failed");
            //}
            ++NumberOfClick;
            switch (NumberOfClick)
            {
                case 1:
                    try
                    {
                        if (validateTextBox(txtcarnumber)) { }
                        else
                        {
                            ps.DeleteCar(txtcarnumber.Text);
                            btnnew_Click(sender, e);
                            MessageBox.Show("The Car Number Deleted Successfully");
                        }
                    }
                    catch (Exception)
                    {
               MessageBox.Show("Your Delete operation Failed");
                    }

                    break;
                case 2:
                    MessageBox.Show(txtcarnumber.Name + "Field is required");
                    
                    break;
            }


        }
        //UpdateButton's Code
        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtcarnumber.Text=="")
            {
                MessageBox.Show("Please Enter CarNo");
            }
            else if (ps.UpdateCar(cars_id, txtcarnumber.Text))
            {
                MessageBox.Show("The Record is Updated Successfully");
                btnnew_Click(sender, e);
            }
            else
            {
                MessageBox.Show("The Update Operation is Failed");
            }
            autocomplete();
        }
        //AutoComplete Function
        public void autocomplete()
        {
            DataTable dt = ps.GetCars();
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            txtsearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtsearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtsearch.AutoCompleteCustomSource = col;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    col.Add(dt.Rows[i]["CarNo"].ToString());
                }
            }
            txtsearch.AutoCompleteCustomSource = col;
        }
        //SearchButton's Code
        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txtsearch)) { }
            else
            {
                DataTable dt = ps.GetCars("CarNo", txtsearch.Text);
                if (dt.Rows.Count == 1)
                {
                    cars_id = int.Parse(dt.Rows[0][0].ToString());
                    txtcarnumber.Text = dt.Rows[0][1].ToString();

                }
                else
                {
                    MessageBox.Show("This Car Number Not Found");
                }
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
        //public void RegXp(string re, TextBox tb, Label lb, string s)
        //{
        //    Regex regex = new Regex(re);
        //    if (regex.IsMatch(tb.Text))
        //    {
        //        lb.ForeColor = Color.Green;
        //        lb.Text = s + "valid";
        //    }
        //    else
        //    {
        //        lb.ForeColor = Color.Red;
        //        lb.Text = s + "invalid";
        //    }
        //}

        private void txtcarnumber_Validating(object sender, CancelEventArgs e)
        {
            //if (string.IsNullOrEmpty(txtcarnumber.Text))
            //{
            //    //e.Cancel = true;
            //    //_txt_code.Focus();
            //    errorProvider1.SetError(txtcarnumber, "this field is required");
            //}
            //else
            //{
            //    //e.Cancel = true;
            //    errorProvider1.SetError(txtcarnumber, null);
            //}
        }

        private void txtcarnumber_TextChanged(object sender, EventArgs e)
        {
            
            //RegXp(@"^[0-9]+$", txtcarnumber, label3, "Car Number");
            
        }

        private void txtcarnumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Car Number Must Be Number");
            }
        }

        private void CarsUC2_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }
    }
}
