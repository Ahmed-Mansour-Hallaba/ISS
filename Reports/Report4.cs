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
    public partial class Report4 : UserControl
    {
        public static Report4 _Rep4;
        public static Report4 Rep4
        {
            get
            {
                if (_Rep4 == null)
                {
                    _Rep4 = new Report4();
                }
                return _Rep4;
            }
        }

        projectstored ps = new projectstored();
        public Report4()
        {
            InitializeComponent();
            ps.fillcombo(cm_delegate, ps.GetDelegate(), "DelegateName", "DelegateID", "All Delegates");

        }

        private void Report4_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            int cid = Convert.ToInt32(cm_delegate.SelectedValue);
            cid = (cid == -1 ? 0 : cid);
            this.report_DelegatesTableAdapter.Fill(this._V9_1DataSet.Report_Delegates, cid);

            this.reportViewer1.RefreshReport();
        }
    }
}
