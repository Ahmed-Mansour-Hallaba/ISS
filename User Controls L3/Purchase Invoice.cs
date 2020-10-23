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
    public partial class Purchase_Invoice : UserControl
    {
        public static Purchase_Invoice _PIUC3;
        projectstored ps = new projectstored();
        public static Purchase_Invoice PIUC3
        {
            get
            {
                if (_PIUC3 == null)
                {
                    _PIUC3 = new Purchase_Invoice();
                }
                return _PIUC3;
            }
        }
        public Purchase_Invoice()
        {
            InitializeComponent();
            ps.fillcombo(cm_vendor, ps.GetVendor(), "Name", "VendorID", "Select Vendor");
            ps.fillcombo(cm_stores, ps.GetStoresData(), "StoreName", "StoreID", "Select store");
            ps.fillcombo(cm_itemgroup, ps.GetItemGroup(), "Name", "ItemGroupID", "Select Item group");
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Item defination UC
            AddUsercontrol form = new AddUsercontrol();
            form.panel2.Controls.Add(ItemDefinitionUCL2.IDU2);
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Stores UC
            AddUsercontrol form = new AddUsercontrol();
            form.panel2.Controls.Add(Stores.SUC3);
            form.ShowDialog();
        }

        private void btn_Addmanagement_Click(object sender, EventArgs e)
        {
            //Vendors uc
            AddUsercontrol form = new AddUsercontrol();
            form.panel2.Controls.Add(VendorsUC2.venuc2);
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //items Group data uc
            AddUsercontrol form = new AddUsercontrol();
            form.panel2.Controls.Add(ItemGroup.IGUC1);
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cm_vendor.Enabled = false;
            dt_invoicedate.Enabled = false;
            cm_stores.Enabled = false;
            //item code - item name-quantity-unit price -totall
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (cm_items.SelectedValue.ToString() == dataGridView1.Rows[i].Cells[1].Value.ToString())
                {
                    int oq = int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                    int nw = int.Parse(txt_quantity.Text) + oq;

                    double tot = nw * double.Parse(txt_unitprice.Text);
                    dataGridView1.Rows[i].Cells[3].Value = nw;
                    dataGridView1.Rows[i].Cells[4].Value = txt_unitprice.Text;
                    dataGridView1.Rows[i].Cells[5].Value = tot;
                    calc();
                    net();
                    return;

                }
            }

            double total = int.Parse(txt_quantity.Text) * double.Parse(txt_unitprice.Text);
            dataGridView1.Rows.Add("Delete", cm_items.SelectedValue, cm_items.Text, txt_quantity.Text, txt_unitprice.Text, total.ToString());
            calc();
            net();

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
            if (s.SelectedIndex == -1 || s.Text== "Select Vendor" ||s.Text== "Select store" ||s.Text== "Select Item group" ||s.Text== "Select your item" ||s.Text== "Select price type")
            {
                MessageBox.Show(s.Name + "Field is required");
                s.Focus();
                return true;
            }
            else { return false; }

        }
        private void btnsave_Click(object sender, EventArgs e)
        {
          
             if (validateTextBox(txt_seial)) { }
            else if (validatecm(cm_vendor)) { }
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
                int vendorid = Convert.ToInt32(cm_vendor.SelectedValue);
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
                int id = ps.InsertNewPurchaseInvoice(storeid, vendorid, d, t, a, tot, totnet);
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    int itemid = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                    int quantity = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                    int price = Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                    ps.InsertNewPurchaseInvoiceDetail(id, itemid, quantity, price, " ");
                    ps.InsertNewStoreDetail(storeid, itemid,  quantity, " ");
                }
                //report
                Reports.Invoice inv = new Reports.Invoice();
                inv.sid = id;
                inv.Show();
                btnnew_Click(sender, e);
                //MessageBox.Show("Success");
            }
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
            if(cm_price.Text=="Buy")
            {
                DataTable dt = ps.GetItems("ItemID", cm_items.SelectedValue.ToString());
                txt_unitprice.Text =dt.Rows[0][5].ToString();
            }
            else if (cm_price.Text == "Sell")
            {
                DataTable dt = ps.GetItems("ItemID", cm_items.SelectedValue.ToString());
                txt_unitprice.Text = dt.Rows[0][7].ToString();
            }
        }

        private void cm_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            cm_price.SelectedIndex =0;
            txt_unitprice.Text = "0";
            txt_quantity.Text = "1";
            currentbalance();
        }
        private void currentbalance()
        {
            try
            {

  
            if (cm_stores.SelectedValue.ToString() != "System.Data.DataRowView" && cm_items.SelectedValue.ToString() != "System.Data.DataRowView" )

            {
                if (Convert.ToInt32(cm_stores.SelectedValue)>0 && Convert.ToInt32(cm_items.SelectedValue)>0)
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
                double.TryParse(txt_unitprice.Text,out p);
            double r = p * q;
            txt_total.Text = r.ToString();
        }
        private void calc()
        {
            double tot = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                   tot+=Convert.ToDouble( dataGridView1.Rows[i].Cells[5].Value) ;
            }
            txt_totalinvoice.Text = tot.ToString();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(button6.Text=="Cash")
            {
                button6.Text = "Defer";
                txt_paid.Visible = true;
                txt_remain.Visible = true;
                label31.Visible = true;
                label36.Visible = true;

            }
            else
            {
                button6.Text = "Cash";
              
                txt_paid.Visible = false;
                txt_remain.Visible = false;
                label31.Visible = false;
                label36.Visible = false;
            }
        }

        private void txt_discountratio_TextChanged(object sender, EventArgs e)
        {
          
            double tot= double.Parse(txt_totalinvoice.Text);
            double d = 0;
            double.TryParse(txt_discountratio.Text,out d);
          
            if (d>tot)
            {
                txt_discountratio.Text = "0";
                txt_discount.Text = "0";
                return;
            }
            double c = d / tot*100;
            txt_discount.Text = c.ToString();
            net();
        }

        private void txt_discount_TextChanged(object sender, EventArgs e)
        {
           
            double tot = double.Parse(txt_totalinvoice.Text);
            double d = 0;
            double.TryParse(txt_discount.Text,out d);
            
            if (d > 100)
            {

                txt_discount.Text = "0";
                txt_discountratio.Text = "0";
                return;

            }
            double c = d * tot/100;
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
            double c = d * tot/100;
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
            double.TryParse(txt_taxratio.Text,out t);
            double.TryParse(txt_addratio.Text,out a);
            double.TryParse(txt_discountratio.Text,out d);
            double net = tot + t + a-d;
            txt_netinvoice.Text = net.ToString();

        }

        private void cm_stores_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentbalance();
        }

        private void btnnew_Click(object sender, EventArgs e)
        {

            cm_vendor.Enabled = true;
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

        private void txt_discountratio_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_discount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_tax_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_taxratio_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_addratio_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_add_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_paid_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_remain_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_totalinvoice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_netinvoice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Purchase_Invoice_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void cm_vendor_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetVendor();
            if (cm_vendor.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(cm_vendor, ps.GetVendor(), "Name", "VendorID", "Select Vendor");

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
    }
}
