using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project.User_Controls_L2;
using Project.User_Controls;

namespace Project.User_Controls_L3
{
    public partial class SalesInvoice : UserControl
    {
        public static SalesInvoice _SIUC3;
        public static SalesInvoice SIUC3
        {
            get
            {
                if (_SIUC3 == null)
                {
                    _SIUC3 = new SalesInvoice();
                }
                return _SIUC3;
            }
        }
        projectsp.projectstored ps = new projectsp.projectstored();
           
        public SalesInvoice()
        {
            InitializeComponent();
            ps.fillcombo(cm_customer, ps.GetCustomers(), "CustomerName", "CustomerID", "Select Customer");
            ps.fillcombo(cm_delegate, ps.GetDelegate(), "DelegateName", "DelegateID", "Select Customer");
            ps.fillcombo(cm_stores, ps.GetStoresData(), "StoreName", "StoreID", "Select store");
            ps.fillcombo(cm_itemgroup, ps.GetItemGroup(), "Name", "ItemGroupID", "Select Item group");

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

        private void SalesInvoice_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void btn_Addmanagement_Click(object sender, EventArgs e)
        {
            AddUsercontrol form = new AddUsercontrol();
            form.panel2.Controls.Add(CustomerDataUCL2.CDU2);
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddUsercontrol form = new AddUsercontrol();
            form.panel2.Controls.Add(Stores.SUC3);
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddUsercontrol form = new AddUsercontrol();
            form.panel2.Controls.Add(ItemGroup.IGUC1);
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddUsercontrol form = new AddUsercontrol();
            form.panel2.Controls.Add(ItemDefinitionUCL2.IDU2);
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cm_customer.Enabled = false;
            dt_invoicedate.Enabled = false;
            cm_stores.Enabled = false;
            //item code - item name-quantity-unit price -totall
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (cm_items.SelectedValue.ToString() == dataGridView1.Rows[i].Cells[1].Value.ToString())
                {
                    int oq = int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                    int nw = int.Parse(txt_quantity.Text) + oq;
                    if (nw <= int.Parse(lbl_balance.Text))
                    {
                        double tot = nw * double.Parse(txt_unitprice.Text);
                        dataGridView1.Rows[i].Cells[3].Value = nw;
                        dataGridView1.Rows[i].Cells[4].Value = txt_unitprice.Text;
                        dataGridView1.Rows[i].Cells[5].Value = tot;
                        calc();
                        net();
                        return;
                    }
                    else { MessageBox.Show("Current balance in inventory is smaller than you want"); return; }
                }
            }
            if (int.Parse(txt_quantity.Text) <= int.Parse(lbl_balance.Text))
            {
                double total = int.Parse(txt_quantity.Text) * double.Parse(txt_unitprice.Text);
                dataGridView1.Rows.Add("Delete", cm_items.SelectedValue, cm_items.Text, txt_quantity.Text, txt_unitprice.Text, total.ToString());
                calc();
                net();
            }
            else MessageBox.Show("Current balance in inventory is smaller than you want");
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txt_seial)) { }
            else if (validatecm(cm_customer)) { }
            else if (validatecm(cm_stores)) { }
            else if (validatecm(cm_itemgroup)) { }
            else if (validatecm(cm_items)) { }
            else if (validatecm(cm_price)) { }
            else if (validateTextBox(txt_quantity)) { }
            else if (validateTextBox(txt_unitprice)) { }
            else if (validateTextBox(txt_discount)) { }
            else if (validateTextBox(txt_discountratio)) { }
            else if (validateTextBox(txt_tax)) { }
            else if (validateTextBox(txt_taxratio)) { }
            else if (validateTextBox(txt_add)) { }
            else if (validateTextBox(txt_addratio)) { }
            // else if (validateTextBox(txt_paid)) { }
            // else if (validateTextBox(txt_remain)) { }
            else if (validateTextBox(txt_totalinvoice)) { }
            else if (validateTextBox(txt_netinvoice)) { }
            else if (validateRichTextBox(richTextBox1)) { }
            else if (validateRichTextBox(richTextBox2)) { }
            else
            {
                int storeid = Convert.ToInt32(cm_stores.SelectedValue);
                int customerid = Convert.ToInt32(cm_customer.SelectedValue);
                int delegateid = Convert.ToInt32(cm_delegate.SelectedValue);
                double t = 0;
                double a = 0;
                double d = 0;
                double tot = 0;
                double totnet = 0;
                double.TryParse(txt_taxratio.Text, out t);
                double.TryParse(txt_addratio.Text, out a);
                double.TryParse(txt_discountratio.Text, out d);
                double.TryParse(txt_totalinvoice.Text, out tot);
                double.TryParse(txt_netinvoice.Text, out totnet);
                int id = ps.InsertNewSaleInvoice(customerid,delegateid,storeid,d, t, a, tot, totnet);
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    int itemid = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                    int quantity = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                    int price = Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                    ps.InsertNewSaleInvoiceDetail(id, itemid, quantity, price, " ");
                    ps.InsertNewStoreDetail(storeid, itemid, -1 * quantity, " ");
                }
                //report
                Reports.Invoice inv = new Reports.Invoice();
                inv.sid = id;
                inv.Show();
                btnnew_Click(sender, e);
                //MessageBox.Show("Success");
            }

        }

        private void btndelete_Click(object sender, EventArgs e)
        {

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
            if (s.SelectedIndex == -1 || s.Text == "Select Customer" || s.Text == "Select store" || s.Text == "Select Item group" || s.Text == "Select your item" || s.Text == "Select price type")
            {
                MessageBox.Show(s.Name + "Field is required");
                s.Focus();
                return true;
            }
            else { return false; }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            cm_customer.Enabled = true;
            dt_invoicedate.Enabled = true;
            cm_stores.Enabled = true;
            lbl_balance.Text = "0";
            dataGridView1.Rows.Clear();
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

        private void cm_customer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cm_itemgroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cm_itemgroup.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                string igid = cm_itemgroup.SelectedValue.ToString();
                ps.fillcombo(cm_items, ps.GetItems("ItemGroupID", igid), "ItemName", "ItemID", "Select your item");
            }
        }

        private void cm_price_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cm_price.Text == "Buy")
            {
                DataTable dt = ps.GetItems("ItemID", cm_items.SelectedValue.ToString());
                txt_unitprice.Text = dt.Rows[0][5].ToString();
            }
            else if (cm_price.Text == "Sell")
            {
                DataTable dt = ps.GetItems("ItemID", cm_items.SelectedValue.ToString());
                txt_unitprice.Text = dt.Rows[0][7].ToString();
            }
        }

        private void cm_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            cm_price.SelectedIndex = 0;
            txt_unitprice.Text = "0";
            txt_quantity.Text = "1";
            currentbalance();
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

        private void txt_unitprice_TextChanged(object sender, EventArgs e)
        {
            calctot();

        }

        private void txt_quantity_TextChanged(object sender, EventArgs e)
        {
            calctot();

        }
        private void calctot()
        {
            int q = 0;
            int.TryParse(txt_quantity.Text, out q);
            double p = 0;
            double.TryParse(txt_unitprice.Text, out p);
            double r = p * q;
            txt_total.Text = r.ToString();
        }
        private void calc()
        {
            double tot = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                tot += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
            }
            txt_totalinvoice.Text = tot.ToString();

        }

        private void txt_discountratio_TextChanged(object sender, EventArgs e)
        {
            double tot = double.Parse(txt_totalinvoice.Text);
            double d = 0;
            double.TryParse(txt_discountratio.Text, out d);

            if (d > tot)
            {
                txt_discountratio.Text = "0";
                txt_discount.Text = "0";
                return;
            }
            double c = d / tot * 100;
            txt_discount.Text = c.ToString();
            net();
        }

        private void txt_discount_TextChanged(object sender, EventArgs e)
        {
            double tot = double.Parse(txt_totalinvoice.Text);
            double d = 0;
            double.TryParse(txt_discount.Text, out d);

            if (d > 100)
            {

                txt_discount.Text = "0";
                txt_discountratio.Text = "0";
                return;

            }
            double c = d * tot / 100;
            txt_discountratio.Text = c.ToString();
            net();
        }

        private void txt_tax_TextChanged(object sender, EventArgs e)
        {
            double tot = double.Parse(txt_totalinvoice.Text);
            double d = 0;
            double.TryParse(txt_tax.Text, out d);
            if (d > 100)
            {
                txt_taxratio.Text = "0";
                txt_tax.Text = "0";
                return;
            }
            double c = d * tot / 100;
            txt_taxratio.Text = c.ToString();
            net();

        }

        private void txt_taxratio_TextChanged(object sender, EventArgs e)
        {
            double tot = double.Parse(txt_totalinvoice.Text);
            double d = 0;
            double.TryParse(txt_taxratio.Text, out d);
            if (d > tot)
            {
                txt_taxratio.Text = "0";
                txt_tax.Text = "0";
                return;
            }
            double c = d / tot * 100;
            txt_tax.Text = c.ToString();
            net();
        }

        private void txt_addratio_TextChanged(object sender, EventArgs e)
        {
            double tot = double.Parse(txt_totalinvoice.Text);
            double d = 0;
            double.TryParse(txt_addratio.Text, out d);
            if (d > tot)
            {
                txt_addratio.Text = "0";
                txt_add.Text = "0";
                return;
            }
            double c = d / tot * 100;
            txt_add.Text = c.ToString();
            net();
        }

        private void txt_add_TextChanged(object sender, EventArgs e)
        {
            double tot = double.Parse(txt_totalinvoice.Text);
            double d = 0;
            double.TryParse(txt_add.Text, out d);
            if (d > 100)
            {
                txt_addratio.Text = "0";
                txt_add.Text = "0";
                return;
            }
            double c = d * tot / 100;
            txt_addratio.Text = c.ToString();
            net();

        }
        private void net()
        {
            double tot = double.Parse(txt_totalinvoice.Text);
            double t = 0;
            double a = 0;
            double d = 0;
            double.TryParse(txt_taxratio.Text, out t);
            double.TryParse(txt_addratio.Text, out a);
            double.TryParse(txt_discountratio.Text, out d);
            double net = tot + t + a - d;
            txt_netinvoice.Text = net.ToString();

        }

        private void cm_stores_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentbalance();

        }

        private void txt_seial_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txt_seial_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_quantity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_unitprice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cm_customer_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetCustomers();
            if (cm_customer.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(cm_customer, ps.GetCustomers(), "CustomerName", "CustomerID", "Select Customer");

            }
        }

        private void cm_stores_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetStoresData();
            if (cm_stores.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(cm_stores, ps.GetStoresData(), "StoreName", "StoreID", "Select Store");

            }
        }

        private void cm_itemgroup_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetItemGroup();
            if (cm_itemgroup.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(cm_itemgroup, ps.GetItemGroup(), "Name", "ItemGroupID", "Select Item Group");

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

        private void cm_delegate_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetDelegate();
            if (cm_delegate.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(cm_delegate, ps.GetDelegate(), "DelegateName", "DelegateID", "Select Delegate");

            }
        }
    }
}
