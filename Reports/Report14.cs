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
    public partial class Report14 : UserControl
    {
        public static Report14 _Rep14;
        public static Report14 Rep14
        {
            get
            {
                if (_Rep14 == null)
                {
                    _Rep14 = new Report14();
                }
                return _Rep14;
            }
        }
        projectsp.projectstored ps = new projectsp.projectstored();
        public Report14()
        {
            InitializeComponent();
            ps.fillcombo(cm_store, ps.GetStoresData(), "StoreName", "StoreID", "All Store");
            ps.fillcombo(cm_vendor, ps.GetVendor(), "Name", "VendorID", "All Vendor");
            dt_from.Value = DateTime.Now;
            dt_to.Value = DateTime.Now;
        }

        private void Report14_Load(object sender, EventArgs e)
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
                int vid = Convert.ToInt32(cm_store.SelectedValue);
                sid = (sid == -1 ? 0 : sid);
                vid = (vid == -1 ? 0 : vid);


                this.report_PurchaseInvoicesTableAdapter.Fill(this._V9_1DataSet.Report_PurchaseInvoices, dt_from.Value, dt_to.Value, sid, vid);
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
