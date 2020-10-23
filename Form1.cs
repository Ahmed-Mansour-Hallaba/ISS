using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projectsp;
using System.Data.SqlClient;
using Project.User_Controls;
using Project.User_Controls_L2;
using Project.NewUserControls;
using Project.User_Controls_L3;
using System.Threading;
using Project.Reports;
using System.Drawing.Drawing2D;

namespace Project
{

    public partial class Form1 : Form
    {
        //shadow code + icon minimized
        const int WS_MINIMIZEBOX = 0x20000;
        const int CS_DBLCLKS = 0x8;
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                cp.Style |= WS_MINIMIZEBOX;
                cp.ClassStyle |= CS_DBLCLKS;
                return cp;
            }
        }
        //----------------------------------
        //Move Form----
        private void titlepanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        Point lastPoint;
        private void titlepanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        //----
        //Expand & Coll
        private bool isCollapsed;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            //-----------------------
            if (!Contentpanel.Controls.Contains(HP.HPUC1))
            {
                Contentpanel.Controls.Clear();
                Contentpanel.Controls.Add(HP.HPUC1);
                HP.HPUC1.BringToFront();
            }
            else
            {
                HP.HPUC1.BringToFront();
            }
        }
        //----------------------------------
        private void IconMaxmiz_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            IconMinmiz.Visible = true;
            IconMaxmiz.Visible = false;
            //IconMaxmiz.BackColor = Color.FromArgb(232, 232, 232);
        }

        private void IconMinmiz_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            IconMinmiz.Visible = false;
            IconMaxmiz.Visible = true;
            //IconMinmiz.BackColor = Color.FromArgb(232, 232, 232);
        }

        private void titlepanel_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                IconMinmiz.Visible = true;
                IconMaxmiz.Visible = false;
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                IconMinmiz.Visible = false;
                IconMaxmiz.Visible = true;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void IconMaxmiz_MouseHover(object sender, EventArgs e)
        {
            IconMaxmiz.BackColor = Color.FromArgb(229, 229, 229);
        }

        private void IconMaxmiz_MouseLeave(object sender, EventArgs e)
        {
            IconMaxmiz.BackColor = System.Drawing.Color.Transparent;
        }
        private void IconMinmiz_MouseHover(object sender, EventArgs e)
        {
            IconMinmiz.BackColor = Color.FromArgb(229, 229, 229);
        }

        private void IconMinmiz_MouseLeave(object sender, EventArgs e)
        {
            IconMinmiz.BackColor = System.Drawing.Color.Transparent;
        }

        private void MinBox_MouseHover(object sender, EventArgs e)
        {
            MinBox.BackColor = Color.FromArgb(229, 229, 229);
        }

        private void MinBox_MouseLeave(object sender, EventArgs e)
        {
            MinBox.BackColor = System.Drawing.Color.Transparent;
        }
        //----------------------------------
        //close with opacity
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0.0)
            {
                this.Opacity -= 0.050;
            }
            else
            {
                timer1.Stop();
                Application.Exit();
            }
        }
        private void Exitbtn_Click(object sender, EventArgs e)
        {
            close.Start();
        }
        //------------------
        private void timer1_Tick(object sender, EventArgs e)
        {
            //if(isCollapsed)
            //    {
            //        MainMpanel.Height += 10;
            //        if (MainMpanel.Size == MainMpanel.MaximumSize)
            //        {
            //            timer1.Stop();
            //            isCollapsed = false;
            //        }
            //    }
            //    else
            //    {
            //        MainMpanel.Height -= 10;
            //        this.MainMan.Image = Project.Properties.Resources.Expand;
            //        if (MainMpanel.Size == MainMpanel.MinimumSize)
            //        {
            //            timer1.Stop();
            //            isCollapsed = true;
            //        }
            //    }
        }


        private void Department_Click(object sender, EventArgs e)
        {
        }

        private void slidb_Click(object sender, EventArgs e)
        {
            if (Screenspanel.Width == 270)
            {
                Screenspanel.Visible = true;
                Screenspanel.Width = 0;
                SilidingTransition1.ShowSync(Screenspanel);
            }
            else
            {
                Screenspanel.Visible = false;
                Screenspanel.Width = 270;
                SilidingTransition1.ShowSync(Screenspanel);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int move = flowLayoutPanel1.VerticalScroll.Value + flowLayoutPanel1.VerticalScroll.SmallChange * 30;
            flowLayoutPanel1.AutoScrollPosition = new Point(0, move);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int move = flowLayoutPanel1.VerticalScroll.Value - flowLayoutPanel1.VerticalScroll.SmallChange * 30;
            flowLayoutPanel1.AutoScrollPosition = new Point(0, move);
        }

        projectstored ps = new projectstored();
        public int uid
        {
            get; set;
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            //Load settings
            //leftpanel.BackColor = Properties.Settings.Default.left;
            //flowLayoutPanel1.BackColor = Properties.Settings.Default.FS;
            //Screenspanel.BackColor = Properties.Settings.Default.FS;
            //panelbackgro.BackColor = Properties.Settings.Default.panelback;
            //titlepanel.BackColor = Properties.Settings.Default.title;
            //-------------------------------------------------------------
            //for maxmized screen with show taskbar 
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            //-------------------------------------
            //hide scrollbar in flowLayoutPanel1
            flowLayoutPanel1.Parent = Screenspanel;
            flowLayoutPanel1.Width = Screenspanel.ClientSize.Width + SystemInformation.VerticalScrollBarWidth;
            flowLayoutPanel1.Height = Screenspanel.ClientRectangle.Height;
            //--------------------------------------
            //Login
            Panel[] arr = new Panel[11] { Storespanel, HumanResourcespanel, Customerpanel, Purchasepanel, Treasurypanel, Bankpanel, Vendorspanel, Carspanel, Salespanel, Reportspanel, Userspanel };

            for (int i = 0; i < 11; i++)
            {

                arr[i].Visible = false;

            }

            DataTable pdt = ps.GetPrivilege("UserID", uid.ToString());

            for (int i = 0; i < pdt.Rows.Count; i++)
            {
                int c = Convert.ToInt32(pdt.Rows[i][1]);
                if (c == 12)
                    continue;

                arr[c - 1].Visible = true;

            }
            //-------------------------------------
        }
       
        private void Home_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(HP.HPUC1))
            {
                Contentpanel.Controls.Clear();
                Contentpanel.Controls.Add(HP.HPUC1);
                HP.HPUC1.BringToFront();
            }
            else
            {
                HP.HPUC1.BringToFront();
            }
        }
        private void Sales_Click(object sender, EventArgs e)
        {
            if (Salespanel.Size == Salespanel.MinimumSize)
            {
                Salespanel.Size = Salespanel.MaximumSize;
            }
            else
            {
                Salespanel.Size = Salespanel.MinimumSize;
            }
        }

        private void Customer_Click(object sender, EventArgs e)
        {
            if (Customerpanel.Size == Customerpanel.MinimumSize)
            {
                Customerpanel.Size = Customerpanel.MaximumSize;
            }
            else
            {
                Customerpanel.Size = Customerpanel.MinimumSize;
            }
        }
        private void Stores_Click(object sender, EventArgs e)
        {
            if (Storespanel.Size == Storespanel.MinimumSize)
            {
                Storespanel.Size = Storespanel.MaximumSize;
            }
            else
            {
                Storespanel.Size = Storespanel.MinimumSize;
            }
        }

        private void HumanResources_Click(object sender, EventArgs e)
        {
            if (HumanResourcespanel.Size == HumanResourcespanel.MinimumSize)
            {
                HumanResourcespanel.Size = HumanResourcespanel.MaximumSize;
            }
            else
            {
                HumanResourcespanel.Size = HumanResourcespanel.MinimumSize;
            }
        }

        private void ItemGr_Click(object sender, EventArgs e)
        {
        }

        private void Vendors_Click(object sender, EventArgs e)
        {
            if (Vendorspanel.Size == Vendorspanel.MinimumSize)
            {
                Vendorspanel.Size = Vendorspanel.MaximumSize;
            }
            else
            {
                Vendorspanel.Size = Vendorspanel.MinimumSize;
            }
        }

        private void Treasury_Click(object sender, EventArgs e)
        {
            if (Treasurypanel.Size == Treasurypanel.MinimumSize)
            {
                Treasurypanel.Size = Treasurypanel.MaximumSize;
            }
            else
            {
                Treasurypanel.Size = Treasurypanel.MinimumSize;
            }
        }

        private void Bank_Click(object sender, EventArgs e)
        {
            if (Bankpanel.Size == Bankpanel.MinimumSize)
            {
                Bankpanel.Size = Bankpanel.MaximumSize;
            }
            else
            {
                Bankpanel.Size = Bankpanel.MinimumSize;
            }
        }

        private void Cars_Click(object sender, EventArgs e)
        {
            if (Carspanel.Size == Carspanel.MinimumSize)
            {
                Carspanel.Size = Carspanel.MaximumSize;
            }
            else
            {
                Carspanel.Size = Carspanel.MinimumSize;
            }
        }

        private void Users_Click(object sender, EventArgs e)
        {
            if (Userspanel.Size == Userspanel.MinimumSize)
            {
                Userspanel.Size = Userspanel.MaximumSize;
            }
            else
            {
                Userspanel.Size = Userspanel.MinimumSize;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            projectstored ps = new projectstored();
            DataTable dt = ps.GetUser();
        }

        private void Thembtn_Click(object sender, EventArgs e)
        {
            if (Rightpanel.Width == 0)
            {
                Rightpanel.Visible = true;
                Rightpanel.Width = 200;

            }
            else
            {
                Rightpanel.Visible = false;
                Rightpanel.Width = 0;
            }
        }

        private void HumanResourcesbtn1_Click(object sender, EventArgs e)
        {

            if (!Contentpanel.Controls.Contains(MainManagementUC2.mmuc2))
            {
                Contentpanel.Controls.Clear();
                Contentpanel.Controls.Add(MainManagementUC2.mmuc2);
                MainManagementUC2.mmuc2.BringToFront();
            }
            else
            {
                MainManagementUC2.mmuc2.BringToFront();
            }
        }

        private void Salesbtn1_Click(object sender, EventArgs e)
        {


            if (!Contentpanel.Controls.Contains(DelegateRegistrationUC2.drguc2))
            {
                Contentpanel.Controls.Clear();
                Contentpanel.Controls.Add(DelegateRegistrationUC2.drguc2);
                DelegateRegistrationUC2.drguc2.BringToFront();
            }
            else
            {
                DelegateRegistrationUC2.drguc2.BringToFront();
            }
        }

        private void Customerbtn1_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(CustomerGroupUC2.cguc2))
            {
                Contentpanel.Controls.Add(CustomerGroupUC2.cguc2);
                CustomerGroupUC2.cguc2.BringToFront();
            }
            else
            {
                CustomerGroupUC2.cguc2.BringToFront();
            }
        }

        private void Carsbtn2_Click(object sender, EventArgs e)
        {
            Contentpanel.Controls.Clear();
            if (!Contentpanel.Controls.Contains(ExpensesTypeUC2.ext))
            {
                Contentpanel.Controls.Add(ExpensesTypeUC2.ext);
                ExpensesTypeUC2.ext.BringToFront();
            }
            else
                ExpensesTypeUC2.ext.BringToFront();
        }

        private void Storesbtn5_Click(object sender, EventArgs e)
        {
            Contentpanel.Controls.Clear();
            if (!Contentpanel.Controls.Contains(MainGroupUC2.mguc2))
            {
                Contentpanel.Controls.Add(MainGroupUC2.mguc2);
                MainGroupUC2.mguc2.BringToFront();
            }
            else
                MainGroupUC2.mguc2.BringToFront();
        }

        private void Storesbtn4_Click(object sender, EventArgs e)
        {
            Contentpanel.Controls.Clear();
            if (!Contentpanel.Controls.Contains(UnitsUC2.unuc2))
            {
                Contentpanel.Controls.Add(UnitsUC2.unuc2);
                UnitsUC2.unuc2.BringToFront();
            }
            else
                UnitsUC2.unuc2.BringToFront();
        }

        private void Carsbtn1_Click(object sender, EventArgs e)
        {
            Contentpanel.Controls.Clear();
            if (!Contentpanel.Controls.Contains(CarsUC2.cuc2))
            {
                Contentpanel.Controls.Add(CarsUC2.cuc2);
                CarsUC2.cuc2.BringToFront();
                
            }
            else
                CarsUC2.cuc2.BringToFront();
        }

        private void Bankbtn1_Click(object sender, EventArgs e)
        {
            Contentpanel.Controls.Clear();
            if (!Contentpanel.Controls.Contains(BanksUS2.buc2))
            {
                Contentpanel.Controls.Add(BanksUS2.buc2);
                BanksUS2.buc2.BringToFront();
            }
            else
            {
                BanksUS2.buc2.BringToFront();
            }
        }

        private void Usersbtn1_Click(object sender, EventArgs e)
        {
            Contentpanel.Controls.Clear();
            if (!Contentpanel.Controls.Contains(UsersUC.instance))
            {
                Contentpanel.Controls.Add(UsersUC.instance);
                UsersUC.instance.BringToFront();
            }
            else
                UsersUC.instance.BringToFront();
        }

        private void Vendorsbtn1_Click(object sender, EventArgs e)
        {
            Contentpanel.Controls.Clear();
            if (!Contentpanel.Controls.Contains(VendorsUC2.venuc2))
            {
                Contentpanel.Controls.Add(VendorsUC2.venuc2);
                VendorsUC2.venuc2.BringToFront();
            }
            else
                VendorsUC2.venuc2.BringToFront();
        }

        private void Customerbtn2_Click(object sender, EventArgs e)
        {
            Contentpanel.Controls.Clear();
            if (!Contentpanel.Controls.Contains(CustomerDataUCL2.CDU2))
            {
                Contentpanel.Controls.Add(CustomerDataUCL2.CDU2);
                CustomerDataUCL2.CDU2.BringToFront();
                CustomerDataUCL2.CDU2.fillcombos();
            }
            else
                CustomerDataUCL2.CDU2.BringToFront();
        }

        private void Vendorsbtn2_Click(object sender, EventArgs e)
        {
            Contentpanel.Controls.Clear();
            if (!Contentpanel.Controls.Contains(VendorsPaymentsUCL2.VPL2))
            {
                Contentpanel.Controls.Add(VendorsPaymentsUCL2.VPL2);
                VendorsPaymentsUCL2.VPL2.BringToFront();
            }
            else
                VendorsPaymentsUCL2.VPL2.BringToFront();
        }

        private void Bankbtn2_Click(object sender, EventArgs e)
        {
            Contentpanel.Controls.Clear();
            if (!Contentpanel.Controls.Contains(BankingTransactionUCL2.BTuc2))
            {
                Contentpanel.Controls.Add(BankingTransactionUCL2.BTuc2);
                BankingTransactionUCL2.BTuc2.BringToFront();
            }
            else
                BankingTransactionUCL2.BTuc2.BringToFront();
        }

        private void Bankbtn3_Click(object sender, EventArgs e)
        {
            Contentpanel.Controls.Clear();
            if (!Contentpanel.Controls.Contains(BankingAccountsUCL2.BALU2))
            {
                Contentpanel.Controls.Add(BankingAccountsUCL2.BALU2);
                BankingAccountsUCL2.BALU2.BringToFront();
            }
            else
                BankingAccountsUCL2.BALU2.BringToFront();
        }

        public bool button1WasClicked = false;
        private void HumanResourcesbtn3_Click(object sender, EventArgs e)
        {
            button1WasClicked = true;
            if (!Contentpanel.Controls.Contains(EmployeeDefintionUCL2.EDU2))
            {
                Contentpanel.Controls.Add(EmployeeDefintionUCL2.EDU2);
                EmployeeDefintionUCL2.EDU2.BringToFront();
            }
            else
            {
                EmployeeDefintionUCL2.EDU2.BringToFront();
            }
        }

        private void Treasurybtn2_Click(object sender, EventArgs e)
        {
            Contentpanel.Controls.Clear();
            if (!Contentpanel.Controls.Contains(AccountTreeUCL2.ATU2))
            {
                Contentpanel.Controls.Add(AccountTreeUCL2.ATU2);
                AccountTreeUCL2.ATU2.BringToFront();
            }
            else
                EmployeeDefintionUCL2.EDU2.BringToFront();
        }

        private void Treasurybtn4_Click(object sender, EventArgs e)
        {
            Contentpanel.Controls.Clear();
            if (!Contentpanel.Controls.Contains(BalanceDataUCL2.BDU2))
            {
                Contentpanel.Controls.Add(BalanceDataUCL2.BDU2);
                BalanceDataUCL2.BDU2.BringToFront();
            }
            else
                BalanceDataUCL2.BDU2.BringToFront();
        }

        private void Treasurybtn8_Click(object sender, EventArgs e)
        {
            Contentpanel.Controls.Clear();
            if (!Contentpanel.Controls.Contains(EstimatedBudgetUCL2.EBU2))
            {
                Contentpanel.Controls.Add(EstimatedBudgetUCL2.EBU2);
                EstimatedBudgetUCL2.EBU2.BringToFront();
            }
            else
                EstimatedBudgetUCL2.EBU2.BringToFront();
        }

        private void Treasurybtn1_Click(object sender, EventArgs e)
        {
            Contentpanel.Controls.Clear();
            if (!Contentpanel.Controls.Contains(JournalUCL2.Jouuc2))
            {
                Contentpanel.Controls.Add(JournalUCL2.Jouuc2);
                JournalUCL2.Jouuc2.BringToFront();
            }
            else
                JournalUCL2.Jouuc2.BringToFront();
        }

        private void Treasurybtn3_Click(object sender, EventArgs e)
        {
            Contentpanel.Controls.Clear();
            if (!Contentpanel.Controls.Contains(Bond.BU2))
            {
                Contentpanel.Controls.Add(Bond.BU2);
                Bond.BU2.Dock = DockStyle.Fill;
                Bond.BU2.BringToFront();
            }
            else
                Bond.BU2.BringToFront();
        }

        private void Treasurybtn5_Click(object sender, EventArgs e)
        {
            Contentpanel.Controls.Clear();
            if (!Contentpanel.Controls.Contains(BeginingBalanceDataUCL2.BBDU2))
            {
                Contentpanel.Controls.Add(BeginingBalanceDataUCL2.BBDU2);
                BeginingBalanceDataUCL2.BBDU2.Dock = DockStyle.Fill;
                BeginingBalanceDataUCL2.BBDU2.BringToFront();
            }
            else
                BeginingBalanceDataUCL2.BBDU2.BringToFront();
        }

        private void Carsbtn3_Click(object sender, EventArgs e)
        {
            Contentpanel.Controls.Clear();
            if (!Contentpanel.Controls.Contains(ExpensesDataUCL2.EDuc2))
            {
                Contentpanel.Controls.Add(ExpensesDataUCL2.EDuc2);
                ExpensesDataUCL2.EDuc2.Dock = DockStyle.Fill;
                ExpensesDataUCL2.EDuc2.BringToFront();
            }
            else
                ExpensesDataUCL2.EDuc2.BringToFront();
        }

        private void Treasurybtn6_Click(object sender, EventArgs e)
        {
            Contentpanel.Controls.Clear();
            if (!Contentpanel.Controls.Contains(TreasuryUCL2.TrsUC))
            {
                Contentpanel.Controls.Add(TreasuryUCL2.TrsUC);
                TreasuryUCL2.TrsUC.Dock = DockStyle.Fill;
                TreasuryUCL2.TrsUC.BringToFront();
            }
            else
                TreasuryUCL2.TrsUC.BringToFront();
        }

        private void HumanResourcesbtn4_Click(object sender, EventArgs e)
        {
            Contentpanel.Controls.Clear();
            if (!Contentpanel.Controls.Contains(Attendances.ATEN3))
            {
                Contentpanel.Controls.Add(Attendances.ATEN3);
                Attendances.ATEN3.Dock = DockStyle.Fill;
                Attendances.ATEN3.BringToFront();
                
            }
            else
                Attendances.ATEN3.BringToFront();
        }

        private void HumanResourcesbtn5_Click(object sender, EventArgs e)
        {
            Contentpanel.Controls.Clear();
            if (!Contentpanel.Controls.Contains(OverTime.OVTU3))
            {
                Contentpanel.Controls.Add(OverTime.OVTU3);
                OverTime.OVTU3.Dock = DockStyle.Fill;
                OverTime.OVTU3.BringToFront();
            }
            else
                OverTime.OVTU3.BringToFront();
        }

        private void Customerbtn3_Click(object sender, EventArgs e)
        {
            Contentpanel.Controls.Clear();
            if (!Contentpanel.Controls.Contains(Installments_System.ISU3))
            {
                Contentpanel.Controls.Add(Installments_System.ISU3);
                Installments_System.ISU3.Dock = DockStyle.Fill;
                Installments_System.ISU3.BringToFront();
            }
            else
                Installments_System.ISU3.BringToFront();
        }

        private void HumanResourcesbtn6_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(ReceivingCustody.RCU3))
            {
                Contentpanel.Controls.Add(ReceivingCustody.RCU3);
                ReceivingCustody.RCU3.Dock = DockStyle.Fill;
                ReceivingCustody.RCU3.BringToFront();
            }
            else
                ReceivingCustody.RCU3.BringToFront();
        }

        private void HumanResourcesbtn9_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Departure.DEPTU3))
            {
                Contentpanel.Controls.Add(Departure.DEPTU3);
                Departure.DEPTU3.Dock = DockStyle.Fill;
                Departure.DEPTU3.BringToFront();
            }
            else
                Departure.DEPTU3.BringToFront();
        }

        private void HumanResourcesbtn10_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Vacations.VACU3))
            {
                Contentpanel.Controls.Add(Vacations.VACU3);
                Vacations.VACU3.Dock = DockStyle.Fill;
                Vacations.VACU3.BringToFront();
            }
            else
                Vacations.VACU3.BringToFront();
        }

        private void HumanResourcesbtn8_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Skills.SkillU3))
            {
                Contentpanel.Controls.Add(Skills.SkillU3);
                Skills.SkillU3.Dock = DockStyle.Fill;
                Skills.SkillU3.BringToFront();
            }
            else
                Skills.SkillU3.BringToFront();
        }

        private void Purchasebtn_Click(object sender, EventArgs e)
        {
            if (Purchasepanel.Size == Purchasepanel.MinimumSize)
            {
                Purchasepanel.Size = Purchasepanel.MaximumSize;
            }
            else
            {
                Purchasepanel.Size = Purchasepanel.MinimumSize;
            }
        }

        private void Reportsbtn_Click(object sender, EventArgs e)
        {
            if (Reportspanel.Size == Reportspanel.MinimumSize)
            {
                Reportspanel.Size = Reportspanel.MaximumSize;
            }
            else
            {
                Reportspanel.Size = Reportspanel.MinimumSize;
            }
        }

        private void Purchasesbtn1_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Purchase_Invoice.PIUC3))
            {
                Contentpanel.Controls.Add(Purchase_Invoice.PIUC3);
                Purchase_Invoice.PIUC3.Dock = DockStyle.Fill;
                Purchase_Invoice.PIUC3.BringToFront();
            }
            else
                Purchase_Invoice.PIUC3.BringToFront();
            
        }

        private void Storesbtn3_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Converting_Store.CSUC3))
            {
                Contentpanel.Controls.Add(Converting_Store.CSUC3);
                Converting_Store.CSUC3.Dock = DockStyle.Fill;
                Converting_Store.CSUC3.BringToFront();
            }
            else
                Converting_Store.CSUC3.BringToFront();
        }

        private void Reportsbtn3_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Report3.Rep3))
            {
                Contentpanel.Controls.Add(Report3.Rep3);
                Report3.Rep3.Dock = DockStyle.Fill;
                Report3.Rep3.BringToFront();
            }
            else
                Report3.Rep3.BringToFront();
        }

        private void Reportsbtn2_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Report2.Rep2))
            {
                Contentpanel.Controls.Add(Report2.Rep2);
                Report2.Rep2.Dock = DockStyle.Fill;
                Report2.Rep2.BringToFront();
            }
            else
                Report2.Rep2.BringToFront();
        }

        private void Reportsbtn1_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Report1.Rep1))
            {
                Contentpanel.Controls.Add(Report1.Rep1);
                Report1.Rep1.Dock = DockStyle.Fill;
                Report1.Rep1.BringToFront();
            }
            else
                Report1.Rep1.BringToFront();
        }

        private void Storesbtn1_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(User_Controls_L3.Stores.SUC3))
            {
                Contentpanel.Controls.Add(User_Controls_L3.Stores.SUC3);
                User_Controls_L3.Stores.SUC3.Dock = DockStyle.Fill;
                User_Controls_L3.Stores.SUC3.BringToFront();
            }
            else
                User_Controls_L3.Stores.SUC3.BringToFront();
          
        }

        private void Storesbtn6_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(ItemDefinitionUCL2.IDU2))
            {
                Contentpanel.Controls.Add(ItemDefinitionUCL2.IDU2);
                ItemDefinitionUCL2.IDU2.Dock = DockStyle.Fill;
                ItemDefinitionUCL2.IDU2.BringToFront();
            }
            else
                ItemDefinitionUCL2.IDU2.BringToFront();
        }
        private void Storesbtn2_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Stores_OrdersUL3.Stores_Orders))
            {
                Contentpanel.Controls.Add(Stores_OrdersUL3.Stores_Orders);
                Stores_OrdersUL3.Stores_Orders.BringToFront();
            }
            else
                Stores_OrdersUL3.Stores_Orders.BringToFront();
        }
        private void Reportbtn4_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Report4.Rep4))
            {
                Contentpanel.Controls.Add(Report4.Rep4);
                Report4.Rep4.BringToFront();
            }
            else
                Report4.Rep4.BringToFront();
        }

        private void Reportbtn5_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Report5.Rep5))
            {
                Contentpanel.Controls.Add(Report5.Rep5);
                Report5.Rep5.BringToFront();
            }
            else
                Report5.Rep5.BringToFront();
        }

        private void Reportbtn6_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Report6.Rep6))
            {
                Contentpanel.Controls.Add(Report6.Rep6);
                Report6.Rep6.BringToFront();
            }
            else
                Report6.Rep6.BringToFront();
        }

        private void Reportbtn7_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Report7.Rep7))
            {
                Contentpanel.Controls.Add(Report7.Rep7);
                Report7.Rep7.BringToFront();
            }
            else
                Report7.Rep7.BringToFront();
        }

        private void Reportbtn8_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Report8.Rep8))
            {
                Contentpanel.Controls.Add(Report8.Rep8);
                Report8.Rep8.BringToFront();
            }
            else
                Report8.Rep8.BringToFront();
        }

        private void Reportbtn9_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Report9.Rep9))
            {
                Contentpanel.Controls.Add(Report9.Rep9);
                Report9.Rep9.BringToFront();
            }
            else
                Report9.Rep9.BringToFront();
        }

        private void Reportbtn10_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Report10.Rep10))
            {
                Contentpanel.Controls.Add(Report10.Rep10);
                Report10.Rep10.BringToFront();
            }
            else
                Report10.Rep10.BringToFront();
        }

        private void Reportbtn11_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Report11.Rep11))
            {
                Contentpanel.Controls.Add(Report11.Rep11);
                Report11.Rep11.BringToFront();
            }
            else
                Report11.Rep11.BringToFront();
        }

        private void Reportbtn12_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Report12.Rep12))
            {
                Contentpanel.Controls.Add(Report12.Rep12);
                Report12.Rep12.BringToFront();
            }
            else
                Report12.Rep12.BringToFront();
        }

        private void Reportbtn13_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Report13.Rep13))
            {
                Contentpanel.Controls.Add(Report13.Rep13);
                Report13.Rep13.BringToFront();
            }
            else
                Report13.Rep13.BringToFront();
        }

        private void Reportbtn14_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Report14.Rep14))
            {
                Contentpanel.Controls.Add(Report14.Rep14);
                Report14.Rep14.BringToFront();
            }
            else
                Report14.Rep14.BringToFront();
        }

        private void Reportbtn15_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Report15.Rep15))
            {
                Contentpanel.Controls.Add(Report15.Rep15);
                Report15.Rep15.BringToFront();
            }
            else
                Report15.Rep15.BringToFront();
        }

        private void Reportbtn16_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Report16.Rep16))
            {
                Contentpanel.Controls.Add(Report16.Rep16);
                Report16.Rep16.BringToFront();
            }
            else
                Report16.Rep16.BringToFront();
        }

        private void Reportbtn17_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Report17.Rep17))
            {
                Contentpanel.Controls.Add(Report17.Rep17);
                Report17.Rep17.BringToFront();
            }
            else
                Report17.Rep17.BringToFront();
        }

        private void Reportbtn18_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Report18.Rep18))
            {
                Contentpanel.Controls.Add(Report18.Rep18);
                Report18.Rep18.BringToFront();
            }
            else
                Report18.Rep18.BringToFront();
        }

        private void Reportbtn19_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Report19.Rep19))
            {
                Contentpanel.Controls.Add(Report19.Rep19);
                Report19.Rep19.BringToFront();
            }
            else
                Report19.Rep19.BringToFront();
        }

        private void Reportbtn20_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Report20.Rep20))
            {
                Contentpanel.Controls.Add(Report20.Rep20);
                Report20.Rep20.BringToFront();
            }
            else
                Report20.Rep20.BringToFront();
        }
        private void Treasurybtn7_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(TotalTreasuryUCL2.TTrsUC))
            {
                Contentpanel.Controls.Add(TotalTreasuryUCL2.TTrsUC);
                TotalTreasuryUCL2.TTrsUC.BringToFront();
            }
            else
                TotalTreasuryUCL2.TTrsUC.BringToFront();
        }

        private void HumanResourcesbtn2_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Department.Departmenuc))
            {
                Contentpanel.Controls.Add(Department.Departmenuc);
                Department.Departmenuc.BringToFront();
            }
            else
                Department.Departmenuc.BringToFront();
        }

        private void HumanResourcesbtn7_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Warnings.WarnU3))
            {
                Contentpanel.Controls.Add(Warnings.WarnU3);
                Warnings.WarnU3.BringToFront();
            }
            else
                Warnings.WarnU3.BringToFront();
        }

        private void Salesbtn2_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Maintenance.MUC3))
            {
                Contentpanel.Controls.Add(Maintenance.MUC3);
                Maintenance.MUC3.BringToFront();
            }
            else
                Maintenance.MUC3.BringToFront();
        }

        private void Salesbtn3_Click(object sender, EventArgs e)
        {
                if (!Contentpanel.Controls.Contains(SalesInvoice.SIUC3))
            {
                Contentpanel.Controls.Add(SalesInvoice.SIUC3);
                SalesInvoice.SIUC3.BringToFront();
            }
            else
                SalesInvoice.SIUC3.BringToFront();
        }

        private void Settingbtn_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            s.Owner = this;
            s.ShowDialog();
        }

        private void Reportbtn21_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Report21.Rep21))
            {
                Contentpanel.Controls.Add(Report21.Rep21);
                Report21.Rep21.BringToFront();
            }
            else
                Report21.Rep21.BringToFront();
        }

        private void Reportbtn22_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Report22.Rep22))
            {
                Contentpanel.Controls.Add(Report22.Rep22);
                Report22.Rep22.BringToFront();
            }
            else
                Report22.Rep22.BringToFront();
        }

        private void Reportbtn23_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Report23.Rep23))
            {
                Contentpanel.Controls.Add(Report23.Rep23);
                Report23.Rep23.BringToFront();
            }
            else
                Report23.Rep23.BringToFront();
        }

        private void Reportbtn24_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Report24.Rep24))
            {
                Contentpanel.Controls.Add(Report24.Rep24);
                Report24.Rep24.BringToFront();
            }
            else
                Report24.Rep24.BringToFront();
        }

        private void Reportbtn25_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Report25.Rep25))
            {
                Contentpanel.Controls.Add(Report25.Rep25);
                Report25.Rep25.BringToFront();
            }
            else
                Report25.Rep25.BringToFront();
        }

        private void Reportbtn26_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(Report26.Rep26))
            {
                Contentpanel.Controls.Add(Report26.Rep26);
                Report26.Rep26.BringToFront();
            }
            else
                Report26.Rep26.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            About A = new About();
            A.ShowDialog();
        }

        private void Storesbtn7_Click(object sender, EventArgs e)
        {
            if (!Contentpanel.Controls.Contains(ItemGroup.IGUC1))
            {
                Contentpanel.Controls.Add(ItemGroup.IGUC1);
                ItemGroup.IGUC1.BringToFront();
            }
            else
                ItemGroup.IGUC1.BringToFront();
        }
        private const string sHTMLHelpFileName = "Intelligent Sales System.chm";
        private void userMbtn_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Application.StartupPath + @"\" + sHTMLHelpFileName);
        }
    }
}
