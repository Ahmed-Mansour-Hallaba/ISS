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
    public partial class Report10 : UserControl
    {
        public static Report10 _Rep10;
        public static Report10 Rep10
        {
            get
            {
                if (_Rep10 == null)
                {
                    _Rep10 = new Report10();
                }
                return _Rep10;
            }
        }
        public Report10()
        {
            InitializeComponent();
            this.report_MostProfitableItemsTableAdapter.Fill(this._V9_1DataSet.Report_MostProfitableItems);

            this.reportViewer1.RefreshReport();
        }

        private void Report10_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }
    }
}
