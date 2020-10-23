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
using Project.User_Controls_L2;

namespace Project.User_Controls_L3
{
    public partial class Stores_OrdersUL3 : UserControl
    {
        public static Stores_OrdersUL3 _Stores_OrdersUL3;

        projectstored ps = new projectstored();

        public static Stores_OrdersUL3 Stores_Orders
        {
            get
            {
                if (_Stores_OrdersUL3 == null)
                {
                    _Stores_OrdersUL3 = new Stores_OrdersUL3();
                }
                return _Stores_OrdersUL3;
            }
        }

        public Stores_OrdersUL3()
        {
            InitializeComponent();
            ps.fillcombo(cm_stores, ps.GetStoresData(), "StoreName", "StoreID", "Select store");
            ps.fillcombo(cm_itemgroups, ps.GetItemGroup(), "Name", "ItemGroupID", "Select Item group");

        }

        private void Stores_OrdersUL3_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
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

        private void button4_Click(object sender, EventArgs e)
        {
            cm_stores.Enabled = false;
            cm_ordertype.Enabled = false;
            //item code - item name-quantity-unit price -totall
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (cm_items.SelectedValue.ToString() == dataGridView1.Rows[i].Cells[2].Value.ToString())
                {
                    int oq = int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                    int nw = int.Parse(txt_quantity.Text) + oq;
                    if (nw <= int.Parse(lbl_balance.Text) || cm_ordertype.Text == "Import")
                    {
                        dataGridView1.Rows[i].Cells[4].Value = nw;
                        return;
                    }
                    else  { MessageBox.Show("Current balance in inventory is smaller than you want"); return; }
                }
            }

            if (int.Parse(txt_quantity.Text) <= int.Parse(lbl_balance.Text) || cm_ordertype.Text=="Import")
            {
                //double total = int.Parse(txt_quantity.Text) * double.Parse(txt_unitprice.Text);
                dataGridView1.Rows.Add("Delete",cm_itemgroups.Text ,cm_items.SelectedValue, cm_items.Text, txt_quantity.Text);
                //calc();
                //net();
            }
            else MessageBox.Show("Current balance in inventory is smaller than you want");
        }
        private void currentbalance()
        {
            try
            {


                if (cm_stores.SelectedValue.ToString() != "System.Data.DataRowView" && cm_items.SelectedValue.ToString() != "System.Data.DataRowView")

                {
                    if (Convert.ToInt32(cm_stores.SelectedValue) > 0 && Convert.ToInt32(cm_items.SelectedValue) > 0)
                    {
                        lbl_balance.Text = ps.getQuantityByStoreID(Convert.ToInt32(cm_stores.SelectedValue), Convert.ToInt32(cm_items.SelectedValue)).ToString();

                    }

                }
            }
            catch (Exception)
            {
                lbl_balance.Text = "0";
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
            if (s.SelectedIndex == -1 || s.Text== "Select store" || s.Text== "Select Item group" || s.Text== "Select your item")
            {
                MessageBox.Show(s.Name + "Field is required");
                s.Focus();
                return true;
            }
            else { return false; }

        }

        private void cm_stores_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentbalance();
        }

        private void cm_ordertype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cm_itemgroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cm_itemgroups.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                string igid = cm_itemgroups.SelectedValue.ToString();
                ps.fillcombo(cm_items, ps.GetItems("ItemGroupID", igid), "ItemName", "ItemID", "Select your item");
            }
        }

        private void cm_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentbalance();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (validateTextBox(OrderNO)) { }
            else if (validateTextBox(SerialNo)) { }
            else if (validatecm(cm_stores)) { }
            else if (validatecm(cm_ordertype)) { }
            //else if (validateRichTextBox(richTextBox1)) { }
            else if (validatecm(cm_itemgroups)) { }
            else if (validatecm(cm_items)) { }
            else if (validateTextBox(txt_quantity)) { }
            else
            {
                int storeid = Convert.ToInt32(cm_stores.SelectedValue);
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    int itemid = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                    int quantity = Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                    if (cm_ordertype.Text != "Import")
                        quantity *= -1;
                    // ps.InsertNewPurchaseInvoiceDetail(id, itemid, quantity, price, " ");
                    ps.InsertNewStoreDetail(storeid, itemid, quantity, " ");
                }
                MessageBox.Show("Store Order Succesful");
                btnnew_Click(sender, e);
            }
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            cm_stores.Enabled = true;
            cm_ordertype.Enabled = true;
            dataGridView1.Rows.Clear();
            lbl_balance.Text = "0";
            foreach (Control c in tableLayoutPanel1.Controls)
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
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if click is on new row or header row
            if (e.RowIndex == dataGridView1.NewRowIndex || e.RowIndex < 0)
                return;

            //Check if click is on specific column 
            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                //Put some logic here, for example to remove row from your binding list.
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                MessageBox.Show("must be number");
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                MessageBox.Show("must be number");
                e.Handled = true;
            }
        }

        private void txt_quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                MessageBox.Show("must be number");
                e.Handled = true;
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (validateTextBox(OrderNO)) { }
            else if (validateTextBox(SerialNo)) { }
            else if (validatecm(cm_stores)) { }
            else if (validatecm(cm_ordertype)) { }
            //else if (validateRichTextBox(richTextBox1)) { }
            else if (validatecm(cm_itemgroups)) { }
            else if (validatecm(cm_items)) { }
            else if (validateTextBox(txt_quantity)) { }
            else { }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (validateTextBox(OrderNO)) { }
            else if (validateTextBox(SerialNo)) { }
            else if (validatecm(cm_stores)) { }
            else if (validatecm(cm_ordertype)) { }
            //else if (validateRichTextBox(richTextBox1)) { }
            else if (validatecm(cm_itemgroups)) { }
            else if (validatecm(cm_items)) { }
            else if (validateTextBox(txt_quantity)) { }
            else { }
        }

        private void btn_AddDepartment_Click(object sender, EventArgs e)
        {
            AddUsercontrol form = new AddUsercontrol();
            form.panel2.Controls.Add(Stores.SUC3);
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddUsercontrol form = new AddUsercontrol();
            form.panel2.Controls.Add(ItemGroup.IGUC1);
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddUsercontrol form = new AddUsercontrol();
            form.panel2.Controls.Add(ItemDefinitionUCL2.IDU2);
            form.ShowDialog();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {

        }

        private void cm_stores_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetStoresData();
            if (cm_stores.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(cm_stores, ps.GetStoresData(), "StoreName", "StoreID", "Select Store");

            }
        }

        private void cm_itemgroups_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetItemGroup();
            if (cm_itemgroups.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(cm_itemgroups, ps.GetItemGroup(), "Name", "ItemGroupID", "Select Item Group");

            }
        }

        private void cm_items_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetItems();
            if (cm_items.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(cm_items, ps.GetItems(), "ItemName", "ItemID", "Select Item");

            }
        }
    }
}
