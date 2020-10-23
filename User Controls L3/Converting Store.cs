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
    public partial class Converting_Store : UserControl
    {
        //Showing UserControl Code
        public static Converting_Store _CSUC3;
        
        public static Converting_Store CSUC3
        {
            get
            {
                if (_CSUC3 == null)
                {
                    _CSUC3 = new Converting_Store();
                }
                return _CSUC3;
            }
        }
        projectstored ps = new projectstored();
        public Converting_Store()
        {
            InitializeComponent();
            ps.fillcombo(FromStore, ps.GetStoresData(), "StoreName", "StoreID", "Select store");
            ps.fillcombo(ToStore, ps.GetStoresData(), "StoreName", "StoreID", "Select store");
            ps.fillcombo(itemgroup, ps.GetItemGroup(), "Name", "ItemGroupID", "Select Item group");
           

        }

        private void cm_itemgroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemgroup.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                string igid = itemgroup.SelectedValue.ToString();
                ps.fillcombo(items, ps.GetItems("ItemGroupID", igid), "ItemName", "ItemID", "Select your item");
            }
        }
        private void currentbalance()
        {
            try
            {
                if (FromStore.SelectedValue.ToString() != "System.Data.DataRowView" && items.SelectedValue.ToString() != "System.Data.DataRowView")

                {
                    if (Convert.ToInt32(FromStore.SelectedValue) > 0 && Convert.ToInt32(items.SelectedValue) > 0)
                    {
                        lbl_balance.Text = ps.getQuantityByStoreID(Convert.ToInt32(FromStore.SelectedValue), Convert.ToInt32(items.SelectedValue)).ToString();

                    }

                }
            }
            catch (Exception)
            {
                lbl_balance.Text = "0";
            }
        }

        private void cm_from_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentbalance();
        }

        private void cm_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentbalance();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FromStore.Enabled = false;
            FromStore.Enabled = false;
            dt_date.Enabled = false;
            //item code - item name-quantity-unit price -totall
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (items.SelectedValue.ToString() == dataGridView1.Rows[i].Cells[2].Value.ToString())
                {
                    int oq = int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                    int nw = int.Parse(txt_quantity.Text) + oq;
                    if (nw <= int.Parse(lbl_balance.Text))
                    {
                        dataGridView1.Rows[i].Cells[4].Value = nw;
                        return;
                    }
                    else { MessageBox.Show("Current balance in inventory is smaller than you want"); return; }
                }
            }
            if (int.Parse(txt_quantity.Text) <= int.Parse(lbl_balance.Text))
            {
                dataGridView1.Rows.Add("Delete",itemgroup.Text, items.SelectedValue, items.Text, txt_quantity.Text);
              
            }
            else MessageBox.Show("Current balance in inventory is smaller than you want");
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
            if (s.SelectedIndex == -1 ||s.Text== "Select store" || s.Text == "Select your item" || s.Text == "Select Item group")
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
            if (validateTextBox((ConversionNo))) { }
            else if (validateTextBox((ID))) { }
            else if (validatecm(FromStore)) { }
            else if (validatecm(ToStore)) { }
            else if (validatecm(itemgroup)) { }
            else if (validatecm(items)) { }
            else if (validateTextBox((txt_quantity))) { }
            else
            {
                try
                {
                    int from = Convert.ToInt32(FromStore.SelectedValue);
                    int to = Convert.ToInt32(ToStore.SelectedValue);
                    int id = ps.InsertNewConversion(from, to, txt_notes.Text);
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        int itemid = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                        int quantity = Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                        ps.InsertNewConversionDetail(id, itemid, quantity, " ");
                    }
                    ps.ExecConversionProcess(id);
                    btnnew_Click(sender, e);
                    MessageBox.Show("Conversion successful");

                }
                catch (Exception)
                {

                    MessageBox.Show("Conversion failed");

                }
            }
        }
        //NewButton's Code
        private void btnnew_Click(object sender, EventArgs e)
        {
            FromStore.Enabled = true;
            ToStore.Enabled = true;
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

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (validateTextBox((ConversionNo))) { }
            else if (validateTextBox((ID))) { }
            else if (validatecm(FromStore)) { }
            else if (validatecm(ToStore)) { }
            else if (validatecm(itemgroup)) { }
            else if (validatecm(items)) { }
            else if (validateTextBox((txt_quantity))) { }
            else
            {
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

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (validateTextBox((ConversionNo))) { }
            else if (validateTextBox((ID))) { }
            else if (validatecm(FromStore)) { }
            else if (validatecm(ToStore)) { }
            else if (validatecm(itemgroup)) { }
            else if (validatecm(items)) { }
            else if (validateTextBox((txt_quantity))) { }
            else
            {
            }
        }

        private void btn_Addmanagement_Click(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            AddUsercontrol form = new AddUsercontrol();
            form.panel2.Controls.Add(ItemDefinitionUCL2.IDU2);
            form.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchPanel.Width = 0;
        }

        private void Converting_Store_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {

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
    }
}
