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
    public partial class Report22 : UserControl
    {
        public static Report22 _Rep22;
        public static Report22 Rep22
        {
            get
            {
                if (_Rep22 == null)
                {
                    _Rep22 = new Report22();
                }
                return _Rep22;
            }
        }
        projectsp.projectstored ps = new projectsp.projectstored();
        public Report22()
        {
            InitializeComponent();
            dt_from.Value = DateTime.Now;
            dt_to.Value = DateTime.Now;

        }

        private void Report22_Load(object sender, EventArgs e)
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
                this.report_JournalsTableAdapter.Fill(this._V9_1DataSet.Report_Journals, dt_from.Value, dt_to.Value);

                this.reportViewer1.RefreshReport();
            }
        }
    }
}
