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
    public partial class Report23 : UserControl
    {
        public static Report23 _Rep23;
        public static Report23 Rep23
        {
            get
            {
                if (_Rep23 == null)
                {
                    _Rep23 = new Report23();
                }
                return _Rep23;
            }
        }
        projectsp.projectstored ps = new projectsp.projectstored();
        public Report23()
        {
            InitializeComponent();
            ps.fillcombo(cm_customer, ps.GetCustomers(), "CustomerName", "CustomerID", "All Customers");
            dt_from.Value = DateTime.Now;
            dt_to.Value = DateTime.Now;
        }

        private void Report23_Load(object sender, EventArgs e)
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
                int cid = Convert.ToInt32(cm_customer.SelectedValue);
                cid = (cid == -1 ? 0 : cid);

                this.report_MaintainanceTableAdapter.Fill(this._V9_1DataSet.Report_Maintainance, cid, dt_from.Value, dt_to.Value);

                this.reportViewer1.RefreshReport();
            }
        }
    }
}
