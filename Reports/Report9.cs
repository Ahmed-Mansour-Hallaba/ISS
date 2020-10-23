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
    public partial class Report9 : UserControl
    {
        public static Report9 _Rep9;
        public static Report9 Rep9
        {
            get
            {
                if (_Rep9 == null)
                {
                    _Rep9 = new Report9();
                }
                return _Rep9;
            }
        }
        public Report9()
        {
            InitializeComponent();
            dt_from.Value = DateTime.Now;
            dt_to.Value = DateTime.Now;
        }

        private void Report9_Load(object sender, EventArgs e)
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
                this.report_LeastSellingItemsTableAdapter.Fill(this._V9_1DataSet.Report_LeastSellingItems, dt_from.Value, dt_to.Value);

                this.reportViewer1.RefreshReport();
            }
        }
    }
}
