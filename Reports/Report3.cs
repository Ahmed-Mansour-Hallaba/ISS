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
    public partial class Report3 : UserControl
    {
        public static Report3 _Rep3;
        public static Report3 Rep3
        {
            get
            {
                if (_Rep3 == null)
                {
                    _Rep3 = new Report3();
                }
                return _Rep3;
            }
        }
        projectstored ps = new projectstored();

        public Report3()
        {
            InitializeComponent();
            ps.fillcombo(cm_bank, ps.GetBank(), "Name", "BankID", "All Banks");
            dt_from.Value = DateTime.Now;
            dt_to.Value = DateTime.Now;

        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            if (dt_from.Value > dt_to.Value)
            {
                MessageBox.Show("Date from must be before date to");

            }
            else
            {
                int cid = Convert.ToInt32(cm_bank.SelectedValue);
                cid = (cid == -1 ? 0 : cid);
                this.report_BankAccountsTableAdapter.Fill(this._V9_1DataSet.Report_BankAccounts, cid, dt_from.Value, dt_to.Value);

                this.reportViewer1.RefreshReport();
            }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void cm_bank_SelectedIndexChanged(object sender, EventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
