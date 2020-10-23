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
    public partial class Report8 : UserControl
    {
        public static Report8 _Rep8;
        public static Report8 Rep8
        {
            get
            {
                if (_Rep8 == null)
                {
                    _Rep8 = new Report8();
                }
                return _Rep8;
            }
        }
        public Report8()
        {
            InitializeComponent();
            this.report_LeastProfitableItemsTableAdapter.Fill(this._V9_1DataSet.Report_LeastProfitableItems);

            this.reportViewer1.RefreshReport();
        }

        private void Report8_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }
    }
}
