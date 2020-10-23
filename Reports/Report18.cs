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
    public partial class Report18 : UserControl
    {
        public static Report18 _Rep18;
        public static Report18 Rep18
        {
            get
            {
                if (_Rep18 == null)
                {
                    _Rep18 = new Report18();
                }
                return _Rep18;
            }
        }
        projectsp.projectstored ps = new projectsp.projectstored();
        public Report18()
        {
            InitializeComponent();
            ps.fillcombo(cm_vendor, ps.GetVendor(), "Name", "VendorID", "Select Vendor");
            dt_from.Value = DateTime.Now;
            dt_to.Value = DateTime.Now;

        }

        private void Report18_Load(object sender, EventArgs e)
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
                if (cid == -1)
                {
                    MessageBox.Show("Please select vendor");
                }
                else
                {
                    this.report_VendorPurchaseMovementTableAdapter.Fill(this._V9_1DataSet.Report_VendorPurchaseMovement, cid, dt_from.Value, dt_to.Value);

                    this.reportViewer1.RefreshReport();
                }
            }
        }
    }
}
