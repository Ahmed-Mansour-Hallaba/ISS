namespace Project.Reports
{
    partial class Report8
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource10 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.Report_LeastProfitableItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._V9_1DataSet = new Project._V9_1DataSet();
            this.reportLeastProfitableItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.report_LeastProfitableItemsTableAdapter = new Project._V9_1DataSetTableAdapters.Report_LeastProfitableItemsTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Report_LeastProfitableItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._V9_1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportLeastProfitableItemsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Report_LeastProfitableItemsBindingSource
            // 
            this.Report_LeastProfitableItemsBindingSource.DataMember = "Report_LeastProfitableItems";
            this.Report_LeastProfitableItemsBindingSource.DataSource = this._V9_1DataSet;
            // 
            // _V9_1DataSet
            // 
            this._V9_1DataSet.DataSetName = "_V9_1DataSet";
            this._V9_1DataSet.EnforceConstraints = false;
            this._V9_1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportLeastProfitableItemsBindingSource
            // 
            this.reportLeastProfitableItemsBindingSource.DataMember = "Report_LeastProfitableItems";
            this.reportLeastProfitableItemsBindingSource.DataSource = this._V9_1DataSet;
            // 
            // reportViewer1
            // 
            this.reportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Top;
            reportDataSource10.Name = "DataSet1";
            reportDataSource10.Value = this.Report_LeastProfitableItemsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource10);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Project.Reports.Report9.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 100);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(650, 500);
            this.reportViewer1.TabIndex = 0;
            // 
            // report_LeastProfitableItemsTableAdapter
            // 
            this.report_LeastProfitableItemsTableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 100);
            this.panel1.TabIndex = 1;
            // 
            // Report8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Name = "Report8";
            this.Size = new System.Drawing.Size(650, 510);
            this.Load += new System.EventHandler(this.Report8_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Report_LeastProfitableItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._V9_1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportLeastProfitableItemsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource reportLeastProfitableItemsBindingSource;
        private _V9_1DataSet _V9_1DataSet;
        private _V9_1DataSetTableAdapters.Report_LeastProfitableItemsTableAdapter report_LeastProfitableItemsTableAdapter;
        private System.Windows.Forms.BindingSource Report_LeastProfitableItemsBindingSource;
        private System.Windows.Forms.Panel panel1;
    }
}
