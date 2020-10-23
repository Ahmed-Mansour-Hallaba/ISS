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
    public partial class Report5 : UserControl
    {
        public static Report5 _Rep5;
        public static Report5 Rep5
        {
            get
            {
                if (_Rep5 == null)
                {
                    _Rep5 = new Report5();
                }
                return _Rep5;
            }
        }
        projectsp.projectstored ps = new projectsp.projectstored();
        public Report5()
        {
            InitializeComponent();
            ps.fillcombo(cm_emp, ps.GetEmployees(), "EmployeeName", "EmployeeID", "All employees");

        }

        private void Report5_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            int cid = Convert.ToInt32(cm_emp.SelectedValue);
            cid = (cid == -1 ? 0 : cid);


            // this.getPurchaseInvoiceTableAdapter.Fill(this._V9_1DataSet.GetPurchaseInvoice, sid);
            this.report_EmployeesTableAdapter.Fill(this._V9_1DataSet.Report_Employees, cid);

            this.reportViewer1.RefreshReport();

        }
    }
}
