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
    public partial class Report13 : UserControl
    {
        public static Report13 _Rep13;
        public static Report13 Rep13
        {
            get
            {
                if (_Rep13 == null)
                {
                    _Rep13 = new Report13();
                }
                return _Rep13;
            }
        }
        projectsp.projectstored ps = new projectsp.projectstored();

        public Report13()
        {
            InitializeComponent();
            ps.fillcombo(cm_emp, ps.GetEmployees(), "EmployeeName", "EmployeeID", "All employees");
            dt_from.Value = DateTime.Now;
            dt_to.Value = DateTime.Now;
        }

        private void Report13_Load(object sender, EventArgs e)
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
                int cid = Convert.ToInt32(cm_emp.SelectedValue);
                cid = (cid == -1 ? 0 : cid);

                // this.getPurchaseInvoiceTableAdapter.Fill(this._V9_1DataSet.GetPurchaseInvoice, sid);
                this.report_VacationsTableAdapter.Fill(this._V9_1DataSet.Report_Vacations, cid, dt_from.Value, dt_to.Value);

                this.reportViewer1.RefreshReport();
            }
        }
    }
}
