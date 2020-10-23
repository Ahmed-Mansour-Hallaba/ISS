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
    public partial class Report26 : UserControl
    {
        public static Report26 _Rep26;
        public static Report26 Rep26
        {
            get
            {
                if (_Rep26 == null)
                {
                    _Rep26 = new Report26();
                }
                return _Rep26;
            }
        }
        projectsp.projectstored ps = new projectsp.projectstored();
        public Report26()
        {
            InitializeComponent();
            ps.fillcombo(cm_delegate, ps.GetDelegate(), "DelegateName", "DelegateID", "All Delegates");
            ps.fillcombo(cm_store, ps.GetStoresData(), "StoreName", "StoreID", "All Storess");
            ps.fillcombo(cm_customer, ps.GetCustomers(), "CustomerName", "CustomerID", "All Customers");
            dt_from.Value = DateTime.Now;
            dt_to.Value = DateTime.Now;
        }

        private void Report26_Load(object sender, EventArgs e)
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
                int did = Convert.ToInt32(cm_delegate.SelectedValue);
                did = (did == -1 ? 0 : did);
                int sid = Convert.ToInt32(cm_store.SelectedValue);
                sid = (sid == -1 ? 0 : sid);

                this.report_SalesInvoiceTableAdapter.Fill(this._V9_1DataSet.Report_SalesInvoice, dt_from.Value, dt_to.Value, cid, did, sid);
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
