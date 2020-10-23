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
    public partial class Report20 : UserControl
    {
        public static Report20 _Rep20;
        public static Report20 Rep20
        {
            get
            {
                if (_Rep20 == null)
                {
                    _Rep20 = new Report20();
                }
                return _Rep20;
            }
        }
        projectsp.projectstored ps = new projectsp.projectstored();
        public Report20()
        {
            InitializeComponent();
            ps.fillcombo(cm_vendor, ps.GetVendor(), "Name", "VendorID", "All Vendors");
            dt_from.Value = DateTime.Now;
            dt_to.Value = DateTime.Now;

        }

        private void Report20_Load(object sender, EventArgs e)
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

                this.report_VendorTotalBillsNumberTableAdapter.Fill(this._V9_1DataSet.Report_VendorTotalBillsNumber, cid, dt_from.Value, dt_to.Value);

                this.reportViewer1.RefreshReport();
            }
        }
    }
}
