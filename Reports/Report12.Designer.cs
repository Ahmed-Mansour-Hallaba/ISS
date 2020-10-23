namespace Project.Reports
{
    partial class Report12
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportStoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._V9_1DataSet = new Project._V9_1DataSet();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cm_item = new System.Windows.Forms.ComboBox();
            this.cm_grp = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_show = new System.Windows.Forms.Button();
            this.cm_store = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.report_StoresTableAdapter = new Project._V9_1DataSetTableAdapters.Report_StoresTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.reportStoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._V9_1DataSet)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportStoresBindingSource
            // 
            this.reportStoresBindingSource.DataMember = "Report_Stores";
            this.reportStoresBindingSource.DataSource = this._V9_1DataSet;
            // 
            // _V9_1DataSet
            // 
            this._V9_1DataSet.DataSetName = "_V9_1DataSet";
            this._V9_1DataSet.EnforceConstraints = false;
            this._V9_1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.95122F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.80488F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.cm_item, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cm_grp, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_show, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.cm_store, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 37, 0, 0);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(820, 123);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // cm_item
            // 
            this.cm_item.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cm_item.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cm_item.FormattingEnabled = true;
            this.cm_item.Location = new System.Drawing.Point(429, 82);
            this.cm_item.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cm_item.Name = "cm_item";
            this.cm_item.Size = new System.Drawing.Size(222, 24);
            this.cm_item.TabIndex = 10;
            // 
            // cm_grp
            // 
            this.cm_grp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cm_grp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cm_grp.FormattingEnabled = true;
            this.cm_grp.Location = new System.Drawing.Point(126, 82);
            this.cm_grp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cm_grp.Name = "cm_grp";
            this.cm_grp.Size = new System.Drawing.Size(240, 24);
            this.cm_grp.TabIndex = 9;
            this.cm_grp.SelectedIndexChanged += new System.EventHandler(this.cm_grp_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 43);
            this.label1.TabIndex = 2;
            this.label1.Text = "Store Name";
            // 
            // btn_show
            // 
            this.btn_show.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_show.Location = new System.Drawing.Point(657, 82);
            this.btn_show.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_show.Name = "btn_show";
            this.btn_show.Size = new System.Drawing.Size(160, 39);
            this.btn_show.TabIndex = 5;
            this.btn_show.Text = "Show";
            this.btn_show.UseVisualStyleBackColor = true;
            this.btn_show.Click += new System.EventHandler(this.btn_show_Click);
            // 
            // cm_store
            // 
            this.cm_store.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cm_store.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cm_store.FormattingEnabled = true;
            this.cm_store.Location = new System.Drawing.Point(126, 39);
            this.cm_store.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cm_store.Name = "cm_store";
            this.cm_store.Size = new System.Drawing.Size(240, 24);
            this.cm_store.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 43);
            this.label2.TabIndex = 3;
            this.label2.Text = "Item Group";
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(372, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 43);
            this.label3.TabIndex = 3;
            this.label3.Text = "Item";
            // 
            // reportViewer1
            // 
            this.reportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.reportStoresBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Project.Reports.Report13.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 123);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(820, 492);
            this.reportViewer1.TabIndex = 9;
            // 
            // report_StoresTableAdapter
            // 
            this.report_StoresTableAdapter.ClearBeforeFill = true;
            // 
            // Report12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Report12";
            this.Size = new System.Drawing.Size(820, 615);
            this.Load += new System.EventHandler(this.Report12_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reportStoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._V9_1DataSet)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cm_item;
        private System.Windows.Forms.ComboBox cm_grp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_show;
        private System.Windows.Forms.ComboBox cm_store;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource reportStoresBindingSource;
        private _V9_1DataSet _V9_1DataSet;
        private _V9_1DataSetTableAdapters.Report_StoresTableAdapter report_StoresTableAdapter;
    }
}
