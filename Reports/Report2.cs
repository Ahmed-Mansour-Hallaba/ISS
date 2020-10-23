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
    public partial class Report2 : UserControl
    {
        public static Report2 _Rep2;
        public static Report2 Rep2
        {
            get
            {
                if (_Rep2 == null)
                {
                    _Rep2 = new Report2();
                }
                return _Rep2;
            }
        }
        projectstored ps = new projectstored();
        public Report2()
        {
            InitializeComponent();
            ps.fillcombo(cm_emp, ps.GetEmployees(), "EmployeeName", "EmployeeID", "All employees");
            dt_from.Value = DateTime.Now;
            dt_to.Value = DateTime.Now;

        }

        private void btn_show_Click(object sender, EventArgs e)
        {

        }

        private void btn_show_Click_1(object sender, EventArgs e)
        {
            if (dt_from.Value > dt_to.Value)
            {
                MessageBox.Show("Date from must be before date to");

            }
            else
            {
                int cid = Convert.ToInt32(cm_emp.SelectedValue);
                cid = (cid == -1 ? 0 : cid);
                this.report_AttendanceDepartureTableAdapter.Fill(this._V9_1DataSet.Report_AttendanceDeparture, cid, dt_from.Value, dt_to.Value);

                this.reportViewer1.RefreshReport();

            }
        }
    }
}
