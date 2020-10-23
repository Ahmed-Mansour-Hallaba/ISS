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
    public partial class Report25 : UserControl
    {
        public static Report25 _Rep25;
        public static Report25 Rep25
        {
            get
            {
                if (_Rep25 == null)
                {
                    _Rep25 = new Report25();
                }
                return _Rep25;
            }
        }
        projectsp.projectstored ps = new projectsp.projectstored();
        public Report25()
        {
            InitializeComponent();
            ps.fillcombo(cm_itemgroup, ps.GetItemGroup(), "Name", "ItemGroupID", "All ItemGroups");
            ps.fillcombo(cm_customer, ps.GetCustomers(), "CustomerName", "CustomerID", "All Customers");
            dt_from.Value = DateTime.Now;
            dt_to.Value = DateTime.Now;
        }

        private void Report25_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void cm_itemgroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cm_itemgroup.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                string igid = cm_itemgroup.SelectedValue.ToString();
                ps.fillcombo(cm_item, ps.GetItems("ItemGroupID", igid), "ItemName", "ItemID", "All items");
            }
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            if (dt_from.Value > dt_to.Value)
            {
                MessageBox.Show("Date from must be before date to");

            }
            else
            {
                int sid = Convert.ToInt32(cm_customer.SelectedValue);
                sid = (sid == -1 ? 0 : sid);
                int gid = Convert.ToInt32(cm_itemgroup.SelectedValue);
                gid = (gid == -1 ? 0 : gid);
                int itid = 0;
                if (gid != -1)
                {
                    itid = Convert.ToInt32(cm_item.SelectedValue);
                    itid = (itid == -1 ? 0 : itid);
                }
                this.report_SalesItemsTableAdapter.Fill(this._V9_1DataSet.Report_SalesItems, sid, gid, itid, dt_from.Value, dt_to.Value);
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
