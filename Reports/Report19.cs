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
    public partial class Report19 : UserControl
    {
        public static Report19 _Rep19;
        public static Report19 Rep19
        {
            get
            {
                if (_Rep19 == null)
                {
                    _Rep19 = new Report19();
                }
                return _Rep19;
            }
        }
        projectsp.projectstored ps = new projectsp.projectstored();
        public Report19()
        {
            InitializeComponent();
            ps.fillcombo(cm_vendor, ps.GetVendor(), "Name", "VendorID", "All Vendors");
            dt_from.Value = DateTime.Now;
            dt_to.Value = DateTime.Now;
        }

        private void Report19_Load(object sender, EventArgs e)
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
                int cid = Convert.ToInt32(cm_vendor.SelectedValue);
                cid = (cid == -1 ? 0 : cid);

                this.report_VendorTotalOrdersTableAdapter.Fill(this._V9_1DataSet.Report_VendorTotalOrders, cid, dt_from.Value, dt_to.Value);

                this.reportViewer1.RefreshReport();
            }
        }
    }
}
