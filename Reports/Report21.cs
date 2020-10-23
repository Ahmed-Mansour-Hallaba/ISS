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
    public partial class Report21 : UserControl
    {
        public static Report21 _Rep21;
        public static Report21 Rep21
        {
            get
            {
                if (_Rep21 == null)
                {
                    _Rep21 = new Report21();
                }
                return _Rep21;
            }
        }
        projectsp.projectstored ps = new projectsp.projectstored();
        public Report21()
        {
            InitializeComponent();
            ps.fillcombo(cm_delegate, ps.GetDelegate(), "DelegateName", "DelegateID", "Select Delegate");
            dt_from.Value = DateTime.Now;
            dt_to.Value = DateTime.Now;

        }

        private void Report21_Load(object sender, EventArgs e)
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
                int cid = Convert.ToInt32(cm_delegate.SelectedValue);
                if (cid == -1)
                {
                    MessageBox.Show("Please select delegate");
                }
                else
                {

                    this.report_DelegateInvoicesTableAdapter.Fill(this._V9_1DataSet.Report_DelegateInvoices, cid, dt_from.Value, dt_to.Value);

                    this.reportViewer1.RefreshReport();
                }
            }
        }
    }
}
