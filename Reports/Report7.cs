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
    public partial class Report7 : UserControl
    {
        public static Report7 _Rep7;
        public static Report7 Rep7
        {
            get
            {
                if (_Rep7 == null)
                {
                    _Rep7 = new Report7();
                }
                return _Rep7;
            }
        }
        projectsp.projectstored ps = new projectsp.projectstored();
        public Report7()
        {
            InitializeComponent();
            ps.fillcombo(cm_itmgrp, ps.GetItemGroup(), "Name", "ITemGroupID", "All Item groups");

        }

        private void Report7_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            int cid = Convert.ToInt32(cm_itmgrp.SelectedValue);
            cid = (cid == -1 ? 0 : cid);


            // this.getPurchaseInvoiceTableAdapter.Fill(this._V9_1DataSet.GetPurchaseInvoice, sid);
            this.report_ItemsTableAdapter.Fill(this._V9_1DataSet.Report_Items, cid);

            this.reportViewer1.RefreshReport();

        }
    }
}
