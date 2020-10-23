using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projectsp;
namespace Project.Reports
{
    public partial class Report1 : UserControl
    {
        public static Report1 _Rep1;
        public static Report1 Rep1
        {
            get
            {
                if (_Rep1 == null)
                {
                    _Rep1 = new Report1();
                }
                return _Rep1;
            }
        }
        public Report1()
        {
            InitializeComponent();

        }

        private void Report1_Load(object sender, EventArgs e)
        {
            projectstored ps = new projectstored();
            ps.fillcombo(cm_cars, ps.GetCars(), "CarNo", "CarID", "Select car");
            dt_from.Value = DateTime.Now;
            dt_to.Value = DateTime.Now;


        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            int cid = Convert.ToInt32(cm_cars.SelectedValue);
            if(dt_from.Value>dt_to.Value)
            {
                MessageBox.Show("Date from must be before date to");

            }
            else if (cid==-1)
            {
                MessageBox.Show("Please select car number");
            }
            else
            {
                // this.getPurchaseInvoiceTableAdapter.Fill(this._V9_1DataSet.GetPurchaseInvoice, sid);
                this.report_CarExpensesTableAdapter.Fill(this._V9_1DataSet.Report_CarExpenses, cid, dt_from.Value, dt_to.Value);
                this.reportViewer1.RefreshReport();

            }
        }
    }
}
