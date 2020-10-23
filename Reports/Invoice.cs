using Microsoft.Reporting.WinForms;
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
    public partial class Invoice : Form
    {
        public Invoice()
        {
            InitializeComponent();
        }
        public int sid
        {
            get; set;
        }
        private void Invoice_Load(object sender, EventArgs e)
        {
                this.getPurchaseInvoiceTableAdapter.Fill(this._V9_1DataSet.GetPurchaseInvoice, sid);
                this.reportViewer1.RefreshReport();
            
           
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
