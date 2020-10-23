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
    public partial class Report16 : UserControl
    {
        public static Report16 _Rep16;
        public static Report16 Rep16
        {
            get
            {
                if (_Rep16 == null)
                {
                    _Rep16 = new Report16();
                }
                return _Rep16;
            }
        }
        projectsp.projectstored ps = new projectsp.projectstored();
        public Report16()
        {
            InitializeComponent();
            ps.fillcombo(cm_itemgroup, ps.GetItemGroup(), "Name", "ItemGroupID", "All ItemGroups");
            dt_from.Value = DateTime.Now;
            dt_to.Value = DateTime.Now;
        }

        private void Report16_Load(object sender, EventArgs e)
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
                int gid = Convert.ToInt32(cm_itemgroup.SelectedValue);
                gid = (gid == -1 ? 0 : gid);
                int itid = 0;
                if (gid != -1)
                {
                    itid = Convert.ToInt32(cm_item.SelectedValue);
                    itid = (itid == -1 ? 0 : itid);
                }
                this.report_SalesAndPurchasesTableAdapter.Fill(this._V9_1DataSet.Report_SalesAndPurchases, gid, itid, dt_from.Value, dt_to.Value);
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
