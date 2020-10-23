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
    public partial class Report12 : UserControl
    {
        public static Report12 _Rep12;
        public static Report12 Rep12
        {
            get
            {
                if (_Rep12 == null)
                {
                    _Rep12 = new Report12();
                }
                return _Rep12;
            }
        }
        projectsp.projectstored ps = new projectsp.projectstored();
        public Report12()
        {
            InitializeComponent();

            ps.fillcombo(cm_grp, ps.GetItemGroup(), "Name", "ItemGroupID", "All Item Groups");
            ps.fillcombo(cm_store, ps.GetStoresData(), "StoreName", "StoreID", "All Stores");

        }

        private void Report12_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void cm_grp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cm_grp.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                string igid = cm_grp.SelectedValue.ToString();
                ps.fillcombo(cm_item, ps.GetItems("ItemGroupID", igid), "ItemName", "ItemID", "All items");
            }
        }

        private void btn_show_Click(object sender, EventArgs e)
        {

            int sid = Convert.ToInt32(cm_store.SelectedValue);
            sid = (sid == -1 ? 0 : sid);
           int gid = Convert.ToInt32(cm_grp.SelectedValue);
            gid = (gid == -1 ? 0 : gid);
            int itid = 0;
            if(gid!=-1)
            {
                itid = Convert.ToInt32(cm_item.SelectedValue);
                itid = (itid == -1 ? 0 : itid);
            }
           

            // this.getPurchaseInvoiceTableAdapter.Fill(this._V9_1DataSet.GetPurchaseInvoice, sid);
            this.report_StoresTableAdapter.Fill(this._V9_1DataSet.Report_Stores,sid,gid,itid);

            this.reportViewer1.RefreshReport();
        }
    }
}
