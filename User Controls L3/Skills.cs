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
using Project.User_Controls_L2;

namespace Project.User_Controls_L3
{
    public partial class Skills : UserControl
    {
        private static Skills _SkillU3;
        public static Skills SkillU3
        {
            get
            {
                if (_SkillU3 == null)
                {
                    _SkillU3 = new Skills();
                }
                return _SkillU3;
            }
        }
        projectstored ps = new projectstored();
        int skill_id = -1;
        public Skills()
        {
            InitializeComponent();
            // Fill Employee ComboBox
            /* DataTable dt1 = ps.GetEmployees();
             DataRow dr1 = dt1.NewRow();
             dr1["EmployeeName"] = "No Employee";
             dr1["EmployeeID"] = -1;
             dt1.Rows.InsertAt(dr1, 0);
             cmbemployee.DataSource = dt1;
             cmbemployee.DisplayMember = "EmployeeName";
             cmbemployee.ValueMember = "EmployeeID";
             cmbemployee.BindingContext = this.BindingContext;
             */
            DataTable dt1 = ps.GetEmployees();

            ps.fillcombo(cmbemployee, dt1, "EmployeeName", "EmployeeID", "select employee");

        }


        //validate TextBox
        public bool validateTextBox(TextBox s)
        {
            if (s.Text == "")
            {
                MessageBox.Show(s.Name + "Field is required");
                s.Focus();
                return true;
            }
            else { return false; }
        }
        // ValidateRichTextBox
        public bool validateRichTextBox(RichTextBox s)
        {
            if (s.Text == "")
            {
                MessageBox.Show(s.Name + "Field is required");
                s.Focus();
                return true;
            }
            else { return false; }

        }
        //Validatecombobox
        public bool validatecm(ComboBox s)
        {
            if (s.SelectedIndex == -1 || s.Text== "select employee")
            {
                MessageBox.Show(s.Name + "Field is required");
                s.Focus();
                return true;
            }
            else { return false; }

        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (validatecm(cmbemployee)) { }
            else if (validateTextBox(txtskills)) { }
            else if (validateTextBox(txtlevel)) { }
            //else if (validateRichTextBox(rtbnotes)) { }
            else if (ps.InsertNewSkill(Convert.ToInt32(cmbemployee.SelectedValue),txtskills.Text,int.Parse(txtlevel.Text),rtbnotes.Text))
            {
                MessageBox.Show("Skill added Successfully");
                btnnew_Click(sender, e);
                cmbemployee.Text = "select employee";
            }
            else
            {
                MessageBox.Show("An Error Occured");
            }
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is TextBox || c is RichTextBox)
                {
                    c.Text = "";
                }
            }
            skill_id = -1;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {

        }

        private void btn_Addmanagement_Click(object sender, EventArgs e)
        {
            AddUsercontrol form = new AddUsercontrol();
            form.panel2.Controls.Add(EmployeeDefintionUCL2.EDU2);
            form.ShowDialog();
        }

        private void Skills_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void btnsave_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtskills_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Skills Must Be Text");
            }
        }

        private void cmbemployee_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetEmployees();
            if (cmbemployee.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(cmbemployee, ps.GetEmployees(), "EmployeeName", "EmployeeID", "Select Employee");

            }
        }
    }
}
