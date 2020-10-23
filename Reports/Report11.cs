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
    public partial class Report11 : UserControl
    {
        public static Report11 _Rep11;
        public static Report11 Rep11
        {
            get
            {
                if (_Rep11 == null)
                {
                    _Rep11 = new Report11();
                }
                return _Rep11;
            }
        }
        projectsp.projectstored ps = new projectsp.projectstored();
        public Report11()
        {
            InitializeComponent();
            ps.fillcombo(cm_emp, ps.GetEmployees(), "EmployeeName", "EmployeeID", "All employees");
            dt_from.Value = DateTime.Now;
            dt_to.Value = DateTime.Now;
        }

        private void Report11_Load(object sender, EventArgs e)
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
                this.report_OverTimesTableAdapter.Fill(this._V9_1DataSet.Report_OverTimes, cid, dt_from.Value, dt_to.Value);

                this.reportViewer1.RefreshReport();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cm_emp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dt_to_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dt_from_ValueChanged(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
