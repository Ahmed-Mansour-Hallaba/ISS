using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Reports
{
    public partial class SaleInvoice : Form
    {
        public int sid
        {
            get; set;
        }
        public SaleInvoice()
        {
            InitializeComponent();
        }

        private void SaleInvoice_Load(object sender, EventArgs e)
        {
            this.getSaleInvoiceTableAdapter.Fill(this._V9_1DataSet.GetSaleInvoice, sid);
            this.reportViewer1.RefreshReport();
        }
    }
}
