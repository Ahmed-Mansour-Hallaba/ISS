using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Reports
{
    public partial class Report15 : UserControl
    {
        public static Report15 _Rep15;
        public static Report15 Rep15
        {
            get
            {
                if (_Rep15 == null)
                {
                    _Rep15 = new Report15();
                }
                return _Rep15;
            }
        }
        projectsp.projectstored ps = new projectsp.projectstored();
        public Report15()
        {
            InitializeComponent();
            ps.fillcombo(cm_itemgroup, ps.GetItemGroup(), "Name", "ItemGroupID", "All ItemGroups");
            ps.fillcombo(cm_vendor, ps.GetVendor(), "Name", "VendorID", "All Vendors");
            dt_from.Value = DateTime.Now;
            dt_to.Value = DateTime.Now;
        }

        private void Report15_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            if (dt_from.Value > dt_to.Value)
            {
                MessageBox.Show("Date from must be before date to");

            }
            else
            {

                int sid = Convert.ToInt32(cm_vendor.SelectedValue);
                sid = (sid == -1 ? 0 : sid);
                int gid = Convert.ToInt32(cm_itemgroup.SelectedValue);
                gid = (gid == -1 ? 0 : gid);
                int itid = 0;
                if (gid != -1)
                {
                    itid = Convert.ToInt32(cm_item.SelectedValue);
                    itid = (itid == -1 ? 0 : itid);
                }
                this.report_PurchaseItemsTableAdapter.Fill(this._V9_1DataSet.Report_PurchaseItems, sid, gid, itid, dt_from.Value, dt_to.Value);
                this.reportViewer1.RefreshReport();
            }
        }

        private void cm_itemgroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cm_itemgroup.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                string igid = cm_itemgroup.SelectedValue.ToString();
                ps.fillcombo(cm_item, ps.GetItems("ItemGroupID", igid), "ItemName", "ItemID", "All items");
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
