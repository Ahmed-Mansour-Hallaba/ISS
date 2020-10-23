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
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Project.NewUserControls;
using Project.User_Controls;

namespace Project.User_Controls_L2
{
    public partial class EmployeeDefintionUCL2 : UserControl
    {
        private static EmployeeDefintionUCL2 _EDU2;
        public static EmployeeDefintionUCL2 EDU2
        {
            get
            {
                if (_EDU2 == null)
                {
                    _EDU2 = new EmployeeDefintionUCL2();
                }
                return _EDU2;
            }
        }
        public EmployeeDefintionUCL2()
        {
            InitializeComponent();
        //    ps.fillcombo(comboBox_Management, ps.GetMainManagement(), "Name", "MainManagementID", "Select MainManagement");
            ps.fillcombo(comboBox_Dep, ps.GetMainDepartment(), "Name", "MainDepartmentID", "Select MainDepartment");
            //ps.fillcombo(cmbsearch, ps.GetTableAttributes("EmployeesView"), "COLUMN_NAME", "COLUMN_NAME", "Select search parameter");
            DataTable dt = ps.GetTableAttributes("EmployeesView");
            DataRow dr = dt.NewRow();
            dr["COLUMN_NAME"] = "Select search parameter";
            dt.Rows.InsertAt(dr, 0);
            cmbsearch.DataSource = dt;
            cmbsearch.DisplayMember = "COLUMN_NAME";
            cmbsearch.BindingContext = this.BindingContext;
        }
        projectstored ps = new projectstored();
        int employee_id = -1;
        private void btn_New_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is TextBox || c is RichTextBox)
                {
                    c.Text = "";
                }
            }
            employee_id = -1;
        }
        public bool validatestring(TextBox s)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(s.Text, "^[a-zA-Z ]"))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters");
                s.Clear();
                return true;
            }
            else { return false; }
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
        public bool validateMaskedTextBox(MaskedTextBox s)
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
            if (s.SelectedIndex == -1 || s.Text == "Select MainManagement" || s.Text == "No Department")
            {
                MessageBox.Show(s.Name + "Field is required");
                s.Focus();
                return true;
            }
            else { return false; }

        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            bool gender = false;

            if (comboBox_Gender.Text == "Male")
            { gender = false; }
            else if (comboBox_Gender.Text == "Female")
                    { gender = true; }



            if (validateTextBox(txt_EmployeeName)) { }
            else if (validatestring(txt_EmployeeName)) { }
            else if (validateTextBox(txt_code)) { }
            else if (validateTextBox(txt_Email)) { }
            else if (validateTextBox(txt_Mobile)) { }
            else if (validateTextBox(txt_Phone)) { }
         //   else if (validatecm(comboBox_Management)) { }
            else if (validatecm(comboBox_Dep)) { }
          //  else if (validateTextBox(txt_NationalID)) { }
         //   else if (validateTextBox(txt_Job)) { }
          //  else if (validatestring(txt_Job)) { }
            else if (validateTextBox(txt_InsuranceNO)) { }
            //else if (validateMaskedTextBox(txt_Nationality)) { }
         //   else if (validatecm(comboBox_Socialstate)) { }
          //  else if (validatecm(comboBox_Gender)) { }
            else if (validateRichTextBox(richTextBox_Address)) { }
            else if (validateTextBox(txt_maxsickholiday)) { }
            else if (validateTextBox(txt_maxemergencyholiday)) { }
            else if (validateTextBox(txt_maxannualholiday)) { }
            else if (validateTextBox(txt_AdditionalHRS)) { }
            else if (validateTextBox(txt_Compinsurance)) { }
            else if (validateTextBox(txt_WorkingTax)) { }
            else if (validateTextBox(txt_Mainsalary)) { }
            else if (validateTextBox(txt_fixedremunaration)) { }
            else if (validateTextBox(txt_Email)) { }
            else if (validateRichTextBox(richTextBox_Notes)) { }
            // ps.InsertNewEmployee(txr_EmployeeName.Text, int.Parse(txt_EmployeeCode.Text), dateTimePicker_BirthDate.Text, bool.Parse(comboBox_Gender.SelectedText), txt_Mobile.Text, txt_Phone.Text, int.Parse(comboBox_Dep.Text), int.Parse(txt_InsuranceNO.Text), richTextBox_Address.Text, int.Parse(txt_maxsickholiday.Text), int.Parse(txt_maxemergencyholiday.Text), int.Parse(txt_maxannualholiday.Text), int.Parse(txt_Mainsalary.Text), int.Parse(txt_fixedremunaration.Text), float.Parse(txt_other.Text), float.Parse(txt_WorkingTax.Text), float.Parse(txt_EmpIn.Text), float.Parse(txt_Compinsurance.Text), int.Parse(txt_AdditionalHRS.Text), richTextBox_Notes.Text)
            else if (ps.InsertNewEmployee(txt_EmployeeName.Text, int.Parse(txt_code.Text), dateTimePicker_BirthDate.Text, gender, txt_Email.Text, txt_Phone.Text, txt_Mobile.Text, Convert.ToInt32(comboBox_Dep.SelectedValue), int.Parse(txt_InsuranceNO.Text), richTextBox_Address.Text, int.Parse(txt_maxsickholiday.Text), int.Parse(txt_maxemergencyholiday.Text), int.Parse(txt_maxannualholiday.Text), int.Parse(txt_Mainsalary.Text), float.Parse(txt_fixedremunaration.Text), float.Parse(txt_others.Text), float.Parse(txt_WorkingTax.Text), float.Parse(txt_InsuranceNO.Text), float.Parse(txt_Compinsurance.Text), int.Parse(txt_AdditionalHRS.Text), richTextBox_Notes.Text))
            {

                MessageBox.Show("Employee added Successfully");
                btn_New_Click(sender, e);
            }
            else
            {
                MessageBox.Show("An Error Occurred");
            }

        }
        private void btn_Addmanagement_Click(object sender, EventArgs e)
        {
            AddUsercontrol form = new AddUsercontrol();
            form.panel2.Controls.Add(MainManagementUC2.mmuc2);
            form.ShowDialog();
        }

        private void btn_AddDepartment_Click(object sender, EventArgs e)
        {
            AddUsercontrol form = new AddUsercontrol();
            form.panel2.Controls.Add(Department.Departmenuc);
            form.ShowDialog();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (SearchPanel.Width == 0)
            {
                SearchPanel.Width = 200;
            }
            else
            {
                SearchPanel.Width = 0;
            }
        }

        private void EmployeeDefintionUCL2_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchPanel.Width = 0;
        }

        private void comboBox_Management_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (comboBox_Management.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                DataTable dt2 = ps.GetMainDepartment("MainManagementID", comboBox_Management.SelectedValue.ToString());
                DataRow dr2 = dt2.NewRow();
                dr2["Name"] = "No Department";
                dr2["MainDepartmentID"] = -1;
                dt2.Rows.InsertAt(dr2, 0);
                comboBox_Dep.DataSource = dt2;
                comboBox_Dep.DisplayMember = "Name";
                comboBox_Dep.ValueMember = "MainDepartmentID";
                comboBox_Dep.BindingContext = this.BindingContext;
            }*/
        }

        private void txr_EmployeeName_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_code.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only integer numbers.");
                txt_code.Clear();
            }
        }



        private void txt_maxsickholiday_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_maxsickholiday.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only integer numbers.");
                txt_maxsickholiday.Clear();
            }
        }

        private void txt_maxemergencyholiday_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_maxemergencyholiday.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only integer numbers.");
                txt_maxemergencyholiday.Clear();
            }
        }

        private void txt_maxannualholiday_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_maxannualholiday.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only integer numbers.");
                txt_maxannualholiday.Clear();
            }
        }

        private void txt_Mainsalary_TextChanged(object sender, EventArgs e)
        {
            //if (System.Text.RegularExpressions.Regex.IsMatch(txt_Mainsalary.Text, "[^0-9]"))
            //{
            //    MessageBox.Show("Please enter only integer numbers.");
            //    txt_Mainsalary.Clear();
            //}
        }

        private void txt_Mainsalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                MessageBox.Show("must be number in format such as 0.0");
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txt_fixedremunaration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                MessageBox.Show("must be number in format such as 0.0");
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txt_WorkingTax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                MessageBox.Show("must be number in format 0.0");
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txt_InsuranceNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                MessageBox.Show("must be number in format 0.0");
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txt_Compinsurance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                MessageBox.Show("must be number in format 0.0");
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txt_AdditionalHRS_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_AdditionalHRS.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only integer numbers.");
                txt_AdditionalHRS.Clear();
            }
        }

        private void txt_Mobile_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_Mobile.Text, "^01[0-2]{1}[0-9]{9}"))
            {
                MessageBox.Show("Please enter phone in coreect format such as 01111111111.");
                txt_Mobile.Clear();
            }
        }

        private void txt_Phone_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_Phone.Text, "^01[0-2]{1}[0-9]{9}"))
            {
                MessageBox.Show("Please enter phone in coreect format such as 01111111111.");
                txt_Phone.Clear();
            }
        }

        private void txt_Email_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Email_Leave(object sender, EventArgs e)
        {
            {

                Regex mRegxExpression;

                if (txt_Email.Text.Trim() != string.Empty)

                {

                    mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                    if (!mRegxExpression.IsMatch(txt_Email.Text.Trim()))

                    {

                        MessageBox.Show("E-mail address format is not correct.", "MojoCRM", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        txt_Email.Focus();

                    }

                }
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                ps.DeleteEmployee(employee_id);
                MessageBox.Show("Employee deleted successfuly");
                btn_New_Click(sender, e);
            }
            catch (SqlException)
            {
                MessageBox.Show("Your Delete Operation Failed");
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            bool gender = false;

            if (comboBox_Gender.Text == "Male")
            { gender = false; }
            else if (comboBox_Gender.Text == "Female")
            { gender = true; }


            if (validateTextBox(txt_EmployeeName)) { }
            else if (validatestring(txt_EmployeeName)) { }
            else if (validateTextBox(txt_code)) { }
            else if (validateTextBox(txt_Email)) { }
            else if (validateTextBox(txt_Mobile)) { }
            else if (validateTextBox(txt_Phone)) { }
         //   else if (validatecm(comboBox_Management)) { }
            else if (validatecm(comboBox_Dep)) { }
           // else if (validateTextBox(txt_NationalID)) { }
            //else if (validateTextBox(txt_Job)) { }
            //else if (validatestring(txt_Job)) { }
            else if (validateTextBox(txt_InsuranceNO)) { }
            //else if (validateMaskedTextBox(txt_Nationality)) { }
          //  else if (validatecm(comboBox_Socialstate)) { }
            else if (validatecm(comboBox_Gender)) { }
            else if (validateRichTextBox(richTextBox_Address)) { }
            else if (validateTextBox(txt_maxsickholiday)) { }
            else if (validateTextBox(txt_maxemergencyholiday)) { }
            else if (validateTextBox(txt_maxannualholiday)) { }
            else if (validateTextBox(txt_AdditionalHRS)) { }
            else if (validateTextBox(txt_Compinsurance)) { }
            else if (validateTextBox(txt_WorkingTax)) { }
            else if (validateTextBox(txt_Mainsalary)) { }
            else if (validateTextBox(txt_fixedremunaration)) { }
            else if (validateTextBox(txt_Email)) { }
      //      else if (validateRichTextBox(richTextBox_Notes)) { }
            // ps.InsertNewEmployee(txr_EmployeeName.Text, int.Parse(txt_EmployeeCode.Text), dateTimePicker_BirthDate.Text, bool.Parse(comboBox_Gender.SelectedText), txt_Mobile.Text, txt_Phone.Text, int.Parse(comboBox_Dep.Text), int.Parse(txt_InsuranceNO.Text), richTextBox_Address.Text, int.Parse(txt_maxsickholiday.Text), int.Parse(txt_maxemergencyholiday.Text), int.Parse(txt_maxannualholiday.Text), int.Parse(txt_Mainsalary.Text), int.Parse(txt_fixedremunaration.Text), float.Parse(txt_other.Text), float.Parse(txt_WorkingTax.Text), float.Parse(txt_EmpIn.Text), float.Parse(txt_Compinsurance.Text), int.Parse(txt_AdditionalHRS.Text), richTextBox_Notes.Text)
            else if (ps.UpdateEmployee(employee_id, txt_EmployeeName.Text, int.Parse(txt_code.Text), dateTimePicker_BirthDate.Text, gender, txt_Email.Text, txt_Phone.Text, txt_Mobile.Text, Convert.ToInt32(comboBox_Dep.SelectedValue), int.Parse(txt_InsuranceNO.Text), richTextBox_Address.Text, int.Parse(txt_maxsickholiday.Text), int.Parse(txt_maxemergencyholiday.Text), int.Parse(txt_maxannualholiday.Text), int.Parse(txt_Mainsalary.Text), float.Parse(txt_fixedremunaration.Text), float.Parse(lbl_other.Text), float.Parse(txt_WorkingTax.Text), float.Parse(txt_InsuranceNO.Text), float.Parse(txt_Compinsurance.Text), int.Parse(txt_AdditionalHRS.Text), richTextBox_Notes.Text))
            {

                MessageBox.Show("Employee added Successfully");
                btn_New_Click(sender, e);
            }
            else
            {
                MessageBox.Show("An Error Occurred");
            }
        }

        private void txt_EmployeeName_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void txt_Job_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (!System.Text.RegularExpressions.Regex.IsMatch(txt_Job.Text, "^[a-zA-Z ]"))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters");
                txt_Job.Clear();

            }*/
        }

        private void txt_Nationality_KeyPress(object sender, KeyPressEventArgs e)
        {
         /*   if (!System.Text.RegularExpressions.Regex.IsMatch(txt_Nationality.Text, "^[a-zA-Z ]"))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters");
                txt_Nationality.Clear();

            }*/
        }

        private void richTextBox_Address_KeyPress(object sender, KeyPressEventArgs e)
        {
        
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            //mycomboBox.SelectedIndex = mycomboBox.Items.IndexOf("value");
            DataTable dt = ps.GetEmployees(cmbsearch.Text, txtsearch.Text);
            if (dt.Rows.Count == 1)
            {
                employee_id = int.Parse(dt.Rows[0][0].ToString());
                txt_EmployeeName.Text = dt.Rows[0][1].ToString();
                txt_code.Text = dt.Rows[0][2].ToString();
                dateTimePicker_BirthDate.Value = DateTime.Parse(dt.Rows[0][3].ToString());
                bool gender = bool.Parse(dt.Rows[0][4].ToString());
                if (gender)
                    comboBox_Gender.SelectedIndex = 1;
                else comboBox_Gender.SelectedIndex = 0;
                txt_Email.Text = dt.Rows[0][5].ToString();
                txt_Phone.Text = dt.Rows[0][6].ToString();
                txt_Mobile.Text = dt.Rows[0][7].ToString();
                comboBox_Dep.SelectedValue = dt.Rows[0][8].ToString();
                dateTimePicker_Hiredate.Value = DateTime.Parse(dt.Rows[0][9].ToString());
                txt_InsuranceNO.Text = dt.Rows[0][10].ToString();
                richTextBox_Address.Text = dt.Rows[0][11].ToString();
                richTextBox_Notes.Text = dt.Rows[0][12].ToString();
                DataTable dt1 = ps.GetEmployeesHoliday("EmployeeID", employee_id.ToString());
                DataTable dt2 = ps.GetEmployeesFinance("EmployeeID", employee_id.ToString());

                txt_maxsickholiday.Text = dt1.Rows[0][1].ToString();
                txt_maxemergencyholiday.Text = dt1.Rows[0][2].ToString();
                txt_maxannualholiday.Text = dt1.Rows[0][3].ToString();
                txt_Mainsalary.Text = dt2.Rows[0][1].ToString();
                txt_fixedremunaration.Text = dt2.Rows[0][2].ToString();
                lbl_other.Text = dt2.Rows[0][3].ToString();
                txt_WorkingTax.Text = dt2.Rows[0][4].ToString();
                txt_InsuranceNO.Text = dt2.Rows[0][5].ToString();
                txt_Compinsurance.Text = dt2.Rows[0][6].ToString();
                txt_AdditionalHRS.Text = dt2.Rows[0][7].ToString();

            }
            else
                MessageBox.Show("Emloyee does not exist");
        }
        public void autocomplete()
        {
            txtsearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtsearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            DataTable dt = ps.GetEmployees();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (cmbsearch.Text == "EmployeeCode")
                {
                    string name = dt.Rows[i]["EmployeeCode"].ToString();
                    col.Add(name);
                }


                else if (cmbsearch.Text == "Email")
                {
                    txtsearch.Clear();
                    string name = dt.Rows[i]["Email"].ToString();
                    col.Add(name);
                }
                else if (cmbsearch.Text == "Mobile")
                {
                    txtsearch.Clear();
                    string name = dt.Rows[i]["Mobile"].ToString();
                    col.Add(name);
                }

                else if (cmbsearch.Text == "Phone")
                {
                    txtsearch.Clear();
                    string name = dt.Rows[i]["Phone"].ToString();
                    col.Add(name);
                }

            }
            txtsearch.AutoCompleteCustomSource = col;
        }
        private void txt_EmployeeName_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txt_EmployeeName.Text, "^[a-zA-Z ]"))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters");
                //txt_Job.Clear();
                txt_EmployeeName.Clear();
            }
        }

        private void txt_Nationality_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
           /* if (!System.Text.RegularExpressions.Regex.IsMatch(txt_Nationality.Text, "^[a-zA-Z ]"))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters");
                txt_Nationality.Clear();

            }*/
        }

        private void txt_Job_TextChanged(object sender, EventArgs e)
        {
           /* if (!System.Text.RegularExpressions.Regex.IsMatch(txt_Nationality.Text, "^[a-zA-Z ]"))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters");
                txt_Nationality.Clear();

            }*/
        }

        private void txt_Mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                MessageBox.Show("must be number in format 0.0");
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txt_Phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                MessageBox.Show("must be number in format 0.0");
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void cmbsearch_Click(object sender, EventArgs e)
        {
            autocomplete();
        }

        private void cmbsearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            autocomplete();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox_Dep_MouseHover(object sender, EventArgs e)
        {
            DataTable dt = ps.GetMainDepartment();
            if (comboBox_Dep.Items.Count - 1 != dt.Rows.Count)
            {
                ps.fillcombo(comboBox_Dep, ps.GetMainDepartment(), "Name", "MainDepartmentID", "Select Department");

            }
        }

        private void txt_EmployeeName_KeyUp(object sender, KeyEventArgs e)
        {
          

        }

        private void dateTimePicker_BirthDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
