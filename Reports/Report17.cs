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
    public partial class Report17 : UserControl
    {
        public static Report17 _Rep17;
        public static Report17 Rep17
        {
            get
            {
                if (_Rep17 == null)
                {
                    _Rep17 = new Report17();
                }
                return _Rep17;
            }
        }
        projectsp.projectstored ps = new projectsp.projectstored();
        public Report17()
        {
            InitializeComponent();
            ps.fillcombo(cm_vendor, ps.GetVendor(), "Name", "VendorID", "All Vendors");
          
        }

        private void Report17_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            int cid = Convert.ToInt32(cm_vendor.SelectedValue);
            cid = (cid == -1 ? 0 : cid);

            // this.getPurchaseInvoiceTableAdapter.Fill(this._V9_1DataSet.GetPurchaseInvoice, sid);
            this.report_VendorsDataTableAdapter.Fill(this._V9_1DataSet.Report_VendorsData, cid);

            this.reportViewer1.RefreshReport();
        }
    }
}
