namespace Project.Reports
{
    partial class Invoice
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
            this.getPurchaseInvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.v91DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._V9_1DataSet = new Project._V9_1DataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.getPurchaseInvoiceTableAdapter = new Project._V9_1DataSetTableAdapters.GetPurchaseInvoiceTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.getPurchaseInvoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v91DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._V9_1DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // getPurchaseInvoiceBindingSource
            // 
            this.getPurchaseInvoiceBindingSource.DataMember = "GetPurchaseInvoice";
            this.getPurchaseInvoiceBindingSource.DataSource = this.v91DataSetBindingSource;
            // 
            // v91DataSetBindingSource
            // 
            this.v91DataSetBindingSource.DataSource = this._V9_1DataSet;
            this.v91DataSetBindingSource.Position = 0;
            // 
            // _V9_1DataSet
            // 
            this._V9_1DataSet.DataSetName = "_V9_1DataSet";
            this._V9_1DataSet.EnforceConstraints = false;
            this._V9_1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.getPurchaseInvoiceBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Project.Reports.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(962, 582);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // getPurchaseInvoiceTableAdapter
            // 
            this.getPurchaseInvoiceTableAdapter.ClearBeforeFill = true;
            // 
            // Invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 582);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Invoice";
            this.Text = "Invoice";
            this.Load += new System.EventHandler(this.Invoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.getPurchaseInvoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v91DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._V9_1DataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource getPurchaseInvoiceBindingSource;
        private System.Windows.Forms.BindingSource v91DataSetBindingSource;
        private _V9_1DataSet _V9_1DataSet;
        private _V9_1DataSetTableAdapters.GetPurchaseInvoiceTableAdapter getPurchaseInvoiceTableAdapter;
    }
}