namespace Project.Reports
{
    partial class SaleInvoice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.getSaleInvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._V9_1DataSet = new Project._V9_1DataSet();
            this.getSaleInvoiceTableAdapter = new Project._V9_1DataSetTableAdapters.GetSaleInvoiceTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.getSaleInvoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._V9_1DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.getSaleInvoiceBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Project.Reports.Report28.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1283, 716);
            this.reportViewer1.TabIndex = 1;
            // 
            // getSaleInvoiceBindingSource
            // 
            this.getSaleInvoiceBindingSource.DataMember = "GetSaleInvoice";
            this.getSaleInvoiceBindingSource.DataSource = this._V9_1DataSet;
            // 
            // _V9_1DataSet
            // 
            this._V9_1DataSet.DataSetName = "_V9_1DataSet";
            this._V9_1DataSet.EnforceConstraints = false;
            this._V9_1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // getSaleInvoiceTableAdapter
            // 
            this.getSaleInvoiceTableAdapter.ClearBeforeFill = true;
            // 
            // SaleInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 716);
            this.Controls.Add(this.reportViewer1);
            this.Name = "SaleInvoice";
            this.Text = "SaleInvoice";
            this.Load += new System.EventHandler(this.SaleInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.getSaleInvoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._V9_1DataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource getSaleInvoiceBindingSource;
        private _V9_1DataSet _V9_1DataSet;
        private _V9_1DataSetTableAdapters.GetSaleInvoiceTableAdapter getSaleInvoiceTableAdapter;
    }
}