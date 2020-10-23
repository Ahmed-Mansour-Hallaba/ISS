namespace Project.User_Controls_L3
{
    partial class Installments_System
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Installments_System));
            this.SearchPanel = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnsearch = new System.Windows.Forms.Button();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtpriceorigin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbcustomer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Addmanagement = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtpurpose = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtprofit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txttotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtinstallmentno = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.rtbnotes = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbpaymenttype = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtpayinadvance = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtinstallmentvalue = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btnnew = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchPanel
            // 
            this.SearchPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(31)))), ((int)(((byte)(38)))));
            this.SearchPanel.Controls.Add(this.label12);
            this.SearchPanel.Controls.Add(this.pictureBox2);
            this.SearchPanel.Controls.Add(this.btnsearch);
            this.SearchPanel.Controls.Add(this.txtsearch);
            this.SearchPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.SearchPanel.Location = new System.Drawing.Point(615, 0);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Size = new System.Drawing.Size(0, 500);
            this.SearchPanel.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Snap ITC", 21.75F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(33, 199);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(135, 37);
            this.label12.TabIndex = 11;
            this.label12.Text = "Search";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Project.Properties.Resources.icons8_Right;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnsearch
            // 
            this.btnsearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(162)))));
            this.btnsearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(162)))));
            this.btnsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsearch.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.btnsearch.ForeColor = System.Drawing.Color.White;
            this.btnsearch.Location = new System.Drawing.Point(15, 272);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(170, 30);
            this.btnsearch.TabIndex = 7;
            this.btnsearch.TabStop = false;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseVisualStyleBackColor = false;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // txtsearch
            // 
            this.txtsearch.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.txtsearch.Location = new System.Drawing.Point(15, 239);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(170, 27);
            this.txtsearch.TabIndex = 6;
            this.txtsearch.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bunifuSeparator1);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(615, 500);
            this.panel1.TabIndex = 7;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(0, 383);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(615, 17);
            this.bunifuSeparator1.TabIndex = 60;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.89706F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.10294F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.Controls.Add(this.label16, 6, 4);
            this.tableLayoutPanel1.Controls.Add(this.label17, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.label18, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtpriceorigin, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbcustomer, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Addmanagement, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtpurpose, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtprofit, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txttotal, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtinstallmentno, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.rtbnotes, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label11, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.cmbpaymenttype, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtpayinadvance, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label9, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtinstallmentvalue, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.label15, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label14, 6, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.8889F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.88889F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.88889F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.88889F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.88889F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.55555F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(615, 266);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // label16
            // 
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(576, 158);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(36, 32);
            this.label16.TabIndex = 21;
            this.label16.Text = "*";
            // 
            // label17
            // 
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(576, 62);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(36, 32);
            this.label17.TabIndex = 22;
            this.label17.Text = "*";
            // 
            // label18
            // 
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(267, 94);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(14, 32);
            this.label18.TabIndex = 23;
            this.label18.Text = "*";
            // 
            // txtpriceorigin
            // 
            this.txtpriceorigin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtpriceorigin.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txtpriceorigin.Location = new System.Drawing.Point(135, 65);
            this.txtpriceorigin.MaxLength = 9;
            this.txtpriceorigin.Name = "txtpriceorigin";
            this.txtpriceorigin.Size = new System.Drawing.Size(126, 26);
            this.txtpriceorigin.TabIndex = 4;
            this.txtpriceorigin.TextChanged += new System.EventHandler(this.txtpriceorigin_TextChanged);
            this.txtpriceorigin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpriceorigin_KeyPress);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Tw Cen MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 32);
            this.label1.TabIndex = 19;
            this.label1.Text = "Customer Name";
            // 
            // cmbcustomer
            // 
            this.cmbcustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbcustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcustomer.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.cmbcustomer.FormattingEnabled = true;
            this.cmbcustomer.Location = new System.Drawing.Point(135, 33);
            this.cmbcustomer.Name = "cmbcustomer";
            this.cmbcustomer.Size = new System.Drawing.Size(126, 28);
            this.cmbcustomer.TabIndex = 1;
            this.cmbcustomer.MouseHover += new System.EventHandler(this.cmbcustomer_MouseHover);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(267, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 32);
            this.label2.TabIndex = 20;
            this.label2.Text = "*";
            // 
            // btn_Addmanagement
            // 
            this.btn_Addmanagement.BackColor = System.Drawing.Color.Transparent;
            this.btn_Addmanagement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Addmanagement.FlatAppearance.BorderSize = 0;
            this.btn_Addmanagement.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Addmanagement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Addmanagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Addmanagement.Image = ((System.Drawing.Image)(resources.GetObject("btn_Addmanagement.Image")));
            this.btn_Addmanagement.Location = new System.Drawing.Point(287, 33);
            this.btn_Addmanagement.Name = "btn_Addmanagement";
            this.btn_Addmanagement.Size = new System.Drawing.Size(20, 26);
            this.btn_Addmanagement.TabIndex = 2;
            this.btn_Addmanagement.UseVisualStyleBackColor = false;
            this.btn_Addmanagement.Click += new System.EventHandler(this.btn_Addmanagement_Click);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Tw Cen MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(313, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 32);
            this.label3.TabIndex = 32;
            this.label3.Text = "Purpose of Installment";
            // 
            // txtpurpose
            // 
            this.txtpurpose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtpurpose.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txtpurpose.Location = new System.Drawing.Point(439, 33);
            this.txtpurpose.Name = "txtpurpose";
            this.txtpurpose.Size = new System.Drawing.Size(131, 26);
            this.txtpurpose.TabIndex = 3;
            this.txtpurpose.TextChanged += new System.EventHandler(this.txtpurpose_TextChanged);
            this.txtpurpose.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpurpose_KeyPress);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Tw Cen MT", 11.25F);
            this.label4.Location = new System.Drawing.Point(3, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 32);
            this.label4.TabIndex = 20;
            this.label4.Text = "price origin";
            // 
            // txtprofit
            // 
            this.txtprofit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtprofit.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txtprofit.Location = new System.Drawing.Point(439, 65);
            this.txtprofit.MaxLength = 9;
            this.txtprofit.Name = "txtprofit";
            this.txtprofit.Size = new System.Drawing.Size(131, 26);
            this.txtprofit.TabIndex = 5;
            this.txtprofit.TextChanged += new System.EventHandler(this.txtprofit_TextChanged);
            this.txtprofit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtprofit_KeyPress);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Tw Cen MT", 11.25F);
            this.label5.Location = new System.Drawing.Point(313, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 32);
            this.label5.TabIndex = 21;
            this.label5.Text = "Profit";
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Tw Cen MT", 11.25F);
            this.label6.Location = new System.Drawing.Point(3, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 32);
            this.label6.TabIndex = 34;
            this.label6.Text = "Total";
            // 
            // txttotal
            // 
            this.txttotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txttotal.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txttotal.Location = new System.Drawing.Point(135, 97);
            this.txttotal.MaxLength = 9;
            this.txttotal.Name = "txttotal";
            this.txttotal.Size = new System.Drawing.Size(126, 26);
            this.txttotal.TabIndex = 6;
            this.txttotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttotal_KeyPress);
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Tw Cen MT", 11.25F);
            this.label7.Location = new System.Drawing.Point(313, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 32);
            this.label7.TabIndex = 35;
            this.label7.Text = "Installment NO";
            // 
            // txtinstallmentno
            // 
            this.txtinstallmentno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtinstallmentno.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txtinstallmentno.Location = new System.Drawing.Point(439, 97);
            this.txtinstallmentno.MaxLength = 4;
            this.txtinstallmentno.Name = "txtinstallmentno";
            this.txtinstallmentno.Size = new System.Drawing.Size(131, 26);
            this.txtinstallmentno.TabIndex = 7;
            this.txtinstallmentno.TextChanged += new System.EventHandler(this.txtinstallmentno_TextChanged);
            this.txtinstallmentno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtinstallmentno_KeyPress);
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("Tw Cen MT", 11.25F);
            this.label13.Location = new System.Drawing.Point(3, 190);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(126, 76);
            this.label13.TabIndex = 40;
            this.label13.Text = "Notes";
            // 
            // rtbnotes
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.rtbnotes, 6);
            this.rtbnotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbnotes.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.rtbnotes.Location = new System.Drawing.Point(135, 193);
            this.rtbnotes.Name = "rtbnotes";
            this.rtbnotes.Size = new System.Drawing.Size(477, 70);
            this.rtbnotes.TabIndex = 12;
            this.rtbnotes.Text = "";
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Tw Cen MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 158);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 32);
            this.label10.TabIndex = 38;
            this.label10.Text = "Installment Start Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePicker1.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(135, 161);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(126, 26);
            this.dateTimePicker1.TabIndex = 10;
            this.dateTimePicker1.Value = new System.DateTime(2019, 3, 27, 22, 11, 0, 0);
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Tw Cen MT", 11.25F);
            this.label11.Location = new System.Drawing.Point(313, 158);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 32);
            this.label11.TabIndex = 38;
            this.label11.Text = "Payment Type";
            // 
            // cmbpaymenttype
            // 
            this.cmbpaymenttype.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbpaymenttype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbpaymenttype.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.cmbpaymenttype.FormattingEnabled = true;
            this.cmbpaymenttype.Items.AddRange(new object[] {
            "Weekly",
            "Monthly"});
            this.cmbpaymenttype.Location = new System.Drawing.Point(439, 161);
            this.cmbpaymenttype.Name = "cmbpaymenttype";
            this.cmbpaymenttype.Size = new System.Drawing.Size(131, 28);
            this.cmbpaymenttype.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Tw Cen MT", 11.25F);
            this.label8.Location = new System.Drawing.Point(3, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 32);
            this.label8.TabIndex = 37;
            this.label8.Text = "Pay InAdvance";
            // 
            // txtpayinadvance
            // 
            this.txtpayinadvance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtpayinadvance.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txtpayinadvance.Location = new System.Drawing.Point(135, 129);
            this.txtpayinadvance.MaxLength = 9;
            this.txtpayinadvance.Name = "txtpayinadvance";
            this.txtpayinadvance.Size = new System.Drawing.Size(126, 26);
            this.txtpayinadvance.TabIndex = 8;
            this.txtpayinadvance.Text = "0";
            this.txtpayinadvance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpayinadvance_KeyPress);
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Tw Cen MT", 11.25F);
            this.label9.Location = new System.Drawing.Point(313, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 32);
            this.label9.TabIndex = 36;
            this.label9.Text = "Installment Value";
            // 
            // txtinstallmentvalue
            // 
            this.txtinstallmentvalue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtinstallmentvalue.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txtinstallmentvalue.Location = new System.Drawing.Point(439, 129);
            this.txtinstallmentvalue.Name = "txtinstallmentvalue";
            this.txtinstallmentvalue.Size = new System.Drawing.Size(131, 26);
            this.txtinstallmentvalue.TabIndex = 9;
            this.txtinstallmentvalue.Text = "0";
            this.txtinstallmentvalue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtinstallmentvalue_KeyPress);
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(267, 62);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 32);
            this.label15.TabIndex = 43;
            this.label15.Text = "*";
            // 
            // label14
            // 
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(576, 94);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 32);
            this.label14.TabIndex = 42;
            this.label14.Text = "*";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.btnupdate, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnnew, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btndelete, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnsave, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 400);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(615, 48);
            this.tableLayoutPanel2.TabIndex = 17;
            // 
            // btnupdate
            // 
            this.btnupdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(240)))));
            this.btnupdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnupdate.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 12F);
            this.btnupdate.Image = ((System.Drawing.Image)(resources.GetObject("btnupdate.Image")));
            this.btnupdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnupdate.Location = new System.Drawing.Point(462, 3);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(150, 42);
            this.btnupdate.TabIndex = 16;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Visible = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btnnew
            // 
            this.btnnew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(240)))));
            this.btnnew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnnew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnew.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 12F);
            this.btnnew.Image = ((System.Drawing.Image)(resources.GetObject("btnnew.Image")));
            this.btnnew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnnew.Location = new System.Drawing.Point(3, 3);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(147, 42);
            this.btnnew.TabIndex = 13;
            this.btnnew.Text = "New";
            this.btnnew.UseVisualStyleBackColor = false;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(240)))));
            this.btndelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndelete.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 12F);
            this.btndelete.Image = ((System.Drawing.Image)(resources.GetObject("btndelete.Image")));
            this.btndelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndelete.Location = new System.Drawing.Point(309, 3);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(147, 42);
            this.btndelete.TabIndex = 15;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Visible = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(240)))));
            this.btnsave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 12F);
            this.btnsave.Image = ((System.Drawing.Image)(resources.GetObject("btnsave.Image")));
            this.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsave.Location = new System.Drawing.Point(156, 3);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(147, 42);
            this.btnsave.TabIndex = 14;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SearchButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 448);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(615, 52);
            this.panel2.TabIndex = 16;
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.Color.Transparent;
            this.SearchButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.SearchButton.FlatAppearance.BorderSize = 0;
            this.SearchButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SearchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchButton.Font = new System.Drawing.Font("Tw Cen MT", 14.25F);
            this.SearchButton.ForeColor = System.Drawing.Color.Black;
            this.SearchButton.Image = ((System.Drawing.Image)(resources.GetObject("SearchButton.Image")));
            this.SearchButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SearchButton.Location = new System.Drawing.Point(0, 0);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(160, 52);
            this.SearchButton.TabIndex = 17;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // Installments_System
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SearchPanel);
            this.Name = "Installments_System";
            this.Size = new System.Drawing.Size(615, 500);
            this.SearchPanel.ResumeLayout(false);
            this.SearchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SearchPanel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btnnew;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbcustomer;
        private System.Windows.Forms.Button btn_Addmanagement;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtpurpose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtprofit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtinstallmentno;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txttotal;
        private System.Windows.Forms.TextBox txtpayinadvance;
        private System.Windows.Forms.TextBox txtpriceorigin;
        private System.Windows.Forms.TextBox txtinstallmentvalue;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbpaymenttype;
        private System.Windows.Forms.RichTextBox rtbnotes;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.Label label12;
    }
}
