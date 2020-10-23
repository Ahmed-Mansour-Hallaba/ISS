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
    public partial class ItemDefinitionUCL2 : UserControl
    {
        private static ItemDefinitionUCL2 _IDU2;
        int itemid = -1;
        projectstored ps = new projectstored();
        public static ItemDefinitionUCL2 IDU2
        {
            get
            {
                if (_IDU2 == null)
                {
                    _IDU2 = new ItemDefinitionUCL2();
                }
                return _IDU2;
            }
        }
        public ItemDefinitionUCL2()
        {
            InitializeComponent();
            ps.fillcombo(cm_group, ps.GetItemGroup(), "Name", "ItemGroupID", "Select Item Group");
            ps.fillcombo(cm_units, ps.GetUnit(), "Name", "UnitID", "Select unit");
       //     ps.fillcombo(cm_store, ps.GetStoresData(), "StoreName", "StoreID", "Select Store");
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
            if (s.SelectedIndex == -1 ||s.Text== "Select Item Group" || s.Text== "Select unit" || s.Text== "Select Store")
            {
                MessageBox.Show(s.Name + "Field is required");
                s.Focus();
                return true;
            }
            else { return false; }

        }
        public void autocomplete()
        {
            txtsearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtsearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            DataTable dt = ps.GetItems();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string name = dt.Rows[i]["ItemName"].ToString();
                col.Add(name);
            }
            txtsearch.AutoCompleteCustomSource = col;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txt_name)) { }
            else if (validatecm(cm_group)) { }
            else if (validatecm(cm_units)) { }
            else if (validateTextBox(txt_retail)) { }
            else if (validateTextBox(txt_purchase)) { }
            else if (validateTextBox(txt_profit)) { }
            else if (validateTextBox(txt_selling)) { }
            else if (validateTextBox(txt_sale)) { }
            else if (validateTextBox(txt_color)) { }
           
            else if (ps.InsertNewItem(txt_name.Text, Convert.ToInt32(cm_group.SelectedValue), Convert.ToInt32(cm_units.SelectedValue), double.Parse(txt_retail.Text), double.Parse(txt_purchase.Text), double.Parse(txt_profit.Text), double.Parse(txt_selling.Text), double.Parse(txt_sale.Text), txt_color.Text, 1, rtb_notes.Text))
            {
                MessageBox.Show("Item added Successfully");
                autocomplete();
                btn_New_Click(sender, e);
                cm_group.Text = "Select Item Group";
                cm_units.Text = "Select Unit";

            }
            else
            {
                MessageBox.Show("An Error Occurred");
            }
            autocomplete();

        }

private void btn_New_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel3.Controls)
            {
                if (c is TextBox)
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
            itemid = -1;
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txt_name)) { }
            else if (validatecm(cm_group)) { }
            else if (validatecm(cm_units)) { }
            else if (validateTextBox(txt_retail)) { }
            else if (validateTextBox(txt_purchase)) { }
            else if (validateTextBox(txt_profit)) { }
            else if (validateTextBox(txt_selling)) { }
            else if (validateTextBox(txt_sale)) { }
            else if (validateTextBox(txt_color)) { }
           // else if (validatecm(cm_store)) { }
            //else if (validateTextBox(txt_begginingbalance)) { }
            
            else
            {
                try
                {
                    ps.DeleteItem(itemid);
                    MessageBox.Show("Item deleted successfuly");
                    autocomplete();
                    btn_New_Click(sender, e);
                    cm_group.Text = "Select Item Group";
                    cm_units.Text = "Select Unit";
                }
                catch (SqlException)
                {

                    MessageBox.Show("Store not Found");
                }
            }
        }
        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txt_name)) { }
            else if (validatecm(cm_group)) { }
            else if (validatecm(cm_units)) { }
            else if (validateTextBox(txt_retail)) { }
            else if (validateTextBox(txt_purchase)) { }
            else if (validateTextBox(txt_profit)) { }
            else if (validateTextBox(txt_selling)) { }
            else if (validateTextBox(txt_sale)) { }
            else if (validateTextBox(txt_color)) { }
            //else if (validatecm(cm_store)) { }
            //else if (validateTextBox(txt_begginingbalance)) { }
            
            else if (ps.UpdateItem(itemid,txt_name.Text, Convert.ToInt32(cm_group.SelectedValue), Convert.ToInt32(cm_units.SelectedValue), double.Parse(txt_retail.Text), double.Parse(txt_purchase.Text), double.Parse(txt_profit.Text), double.Parse(txt_selling.Text), double.Parse(txt_sale.Text), txt_color.Text, 0, rtb_notes.Text))
            {
                MessageBox.Show("Item Updated Successfully");
                autocomplete();
                btn_New_Click(sender, e);
                cm_group.Text = "Select Item Group";
                cm_units.Text = "Select Unit";
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
                DataTable dt = ps.GetItems("ItemName", txtsearch.Text);
                if (dt.Rows.Count == 1)
                {
                    itemid = Convert.ToInt32(dt.Rows[0][0]);
                    txt_name.Text = dt.Rows[0][1].ToString();
                    cm_group.SelectedValue = dt.Rows[0][2];
                    cm_units.SelectedValue = Convert.ToInt32(dt.Rows[0][3]);
                    txt_retail.Text = dt.Rows[0][4].ToString();
                    txt_purchase.Text = dt.Rows[0][5].ToString();
                    txt_profit.Text = dt.Rows[0][6].ToString();
                    txt_selling.Text = dt.Rows[0][7].ToString();
                    txt_sale.Text = dt.Rows[0][8].ToString();
                    txt_color.Text = dt.Rows[0][9].ToString();
                }
                else
                {
                    MessageBox.Show("Item not found");
                }
            }
        }

        private void txt_retail_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_purchase_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_profit_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_selling_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_sale_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_begginingbalance_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_name_KeyPress(object sender, KeyPressEventArgs e)
        {
           /* if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Name Must Be Text");
            }*/
        }

        private void txt_color_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Name Must Be Text");
            }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchPanel.Width = 0;
        }

        private void ItemDefinitionUCL2_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void cm_group_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetItemGroup();
            if (cm_group.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(cm_group, ps.GetItemGroup(), "Name", "ItemGroupID", "Select Item Group");

            }
        }

        private void cm_units_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetUnit();
            if (cm_units.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(cm_units, ps.GetUnit(), "Name", "UnitID", "Select Unit");

            }
        }
    }
    }
    
