namespace Project.Reports
{
    partial class Report15
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
            this.reportPurchaseItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._V9_1DataSet = new Project._V9_1DataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_show = new System.Windows.Forms.Button();
            this.cm_vendor = new System.Windows.Forms.ComboBox();
            this.cm_item = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cm_itemgroup = new System.Windows.Forms.ComboBox();
            this.dt_to = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dt_from = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.report_PurchaseItemsTableAdapter = new Project._V9_1DataSetTableAdapters.Report_PurchaseItemsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.reportPurchaseItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._V9_1DataSet)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportPurchaseItemsBindingSource
            // 
            this.reportPurchaseItemsBindingSource.DataMember = "Report_PurchaseItems";
            this.reportPurchaseItemsBindingSource.DataSource = this._V9_1DataSet;
            // 
            // _V9_1DataSet
            // 
            this._V9_1DataSet.DataSetName = "_V9_1DataSet";
            this._V9_1DataSet.EnforceConstraints = false;
            this._V9_1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.reportPurchaseItemsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Project.Reports.Report16.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 123);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(820, 492);
            this.reportViewer1.TabIndex = 15;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.512196F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.46951F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.10976F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 179F));
            this.tableLayoutPanel1.Controls.Add(this.btn_show, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.cm_vendor, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.cm_item, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cm_itemgroup, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dt_to, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.dt_from, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 37, 0, 0);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(820, 123);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // btn_show
            // 
            this.btn_show.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_show.Location = new System.Drawing.Point(641, 82);
            this.btn_show.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_show.Name = "btn_show";
            this.btn_show.Size = new System.Drawing.Size(176, 39);
            this.btn_show.TabIndex = 10;
            this.btn_show.Text = "Show";
            this.btn_show.UseVisualStyleBackColor = true;
            this.btn_show.Click += new System.EventHandler(this.btn_show_Click);
            // 
            // cm_vendor
            // 
            this.cm_vendor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cm_vendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cm_vendor.FormattingEnabled = true;
            this.cm_vendor.Location = new System.Drawing.Point(641, 39);
            this.cm_vendor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cm_vendor.Name = "cm_vendor";
            this.cm_vendor.Size = new System.Drawing.Size(176, 24);
            this.cm_vendor.TabIndex = 9;
            // 
            // cm_item
            // 
            this.cm_item.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cm_item.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cm_item.FormattingEnabled = true;
            this.cm_item.Location = new System.Drawing.Point(351, 39);
            this.cm_item.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cm_item.Name = "cm_item";
            this.cm_item.Size = new System.Drawing.Size(201, 24);
            this.cm_item.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 43);
            this.label1.TabIndex = 2;
            this.label1.Text = "ItemGroup";
            // 
            // cm_itemgroup
            // 
            this.cm_itemgroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cm_itemgroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cm_itemgroup.FormattingEnabled = true;
            this.cm_itemgroup.Location = new System.Drawing.Point(99, 39);
            this.cm_itemgroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cm_itemgroup.Name = "cm_itemgroup";
            this.cm_itemgroup.Size = new System.Drawing.Size(186, 24);
            this.cm_itemgroup.TabIndex = 1;
            this.cm_itemgroup.SelectedIndexChanged += new System.EventHandler(this.cm_itemgroup_SelectedIndexChanged);
            // 
            // dt_to
            // 
            this.dt_to.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_to.Location = new System.Drawing.Point(351, 82);
            this.dt_to.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dt_to.Name = "dt_to";
            this.dt_to.Size = new System.Drawing.Size(201, 22);
            this.dt_to.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 43);
            this.label2.TabIndex = 3;
            this.label2.Text = "From";
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(291, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 43);
            this.label3.TabIndex = 3;
            this.label3.Text = "To";
            // 
            // dt_from
            // 
            this.dt_from.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_from.Location = new System.Drawing.Point(99, 82);
            this.dt_from.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dt_from.Name = "dt_from";
            this.dt_from.Size = new System.Drawing.Size(186, 22);
            this.dt_from.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label4.Location = new System.Drawing.Point(291, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Item";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label5.Location = new System.Drawing.Point(558, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "Vendor";
            // 
            // report_PurchaseItemsTableAdapter
            // 
            this.report_PurchaseItemsTableAdapter.ClearBeforeFill = true;
            // 
            // Report15
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Report15";
            this.Size = new System.Drawing.Size(820, 615);
            this.Load += new System.EventHandler(this.Report15_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reportPurchaseItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._V9_1DataSet)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_show;
        private System.Windows.Forms.ComboBox cm_vendor;
        private System.Windows.Forms.ComboBox cm_item;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cm_itemgroup;
        private System.Windows.Forms.DateTimePicker dt_to;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dt_from;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource reportPurchaseItemsBindingSource;
        private _V9_1DataSet _V9_1DataSet;
        private _V9_1DataSetTableAdapters.Report_PurchaseItemsTableAdapter report_PurchaseItemsTableAdapter;
    }
}
