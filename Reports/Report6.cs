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
    public partial class Report6 : UserControl
    {
        public static Report6 _Rep6;
        public static Report6 Rep6
        {
            get
            {
                if (_Rep6 == null)
                {
                    _Rep6 = new Report6();
                }
                return _Rep6;
            }
        }
        projectsp.projectstored ps = new projectsp.projectstored();
        public Report6()
        {
            InitializeComponent();
            ps.fillcombo(cm_store, ps.GetStoresData(), "StoreName", "StoreID", "All Stores");
            dt_from.Value = DateTime.Now;
            dt_to.Value = DateTime.Now;
        }

        private void Report6_Load(object sender, EventArgs e)
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
                int cid = Convert.ToInt32(cm_store.SelectedValue);
                cid = (cid == -1 ? 0 : cid);


                // this.getPurchaseInvoiceTableAdapter.Fill(this._V9_1DataSet.GetPurchaseInvoice, sid);
                this.report_ConversionsTableAdapter.Fill(this._V9_1DataSet.Report_Conversions, dt_from.Value, dt_to.Value, cid);

                this.reportViewer1.RefreshReport();
            }
        }
    }
}
