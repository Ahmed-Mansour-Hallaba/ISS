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

namespace Project.User_Controls
{
    [Docking(DockingBehavior.AutoDock)]
    public partial class UsersUC : UserControl
    {
        private Rectangle button11OrginalRect;
        private Size UserOriginalSize;
        //call UserControl Code
        private static UsersUC _instance;

        public static UsersUC instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UsersUC();
                }
                return _instance;
            }
        }
        //-------------------------------------
        int user_id = -1;
        projectstored ps = new projectstored();
        public UsersUC()
        {
            InitializeComponent();
            DataTable dt = ps.GetTableAttributes("UsersView");
            DataRow dr = dt.NewRow();
            dr["COLUMN_NAME"] = "Select search parameter";
            dt.Rows.InsertAt(dr, 0);
            usercombo.DataSource = dt;
            usercombo.DisplayMember = "COLUMN_NAME";
            usercombo.BindingContext = this.BindingContext;
        }
        //NewButton's Code
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is TextBox || c is RichTextBox)
                {
                    c.Text = "";
                }
            }
            user_id = -1;
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
        //password and confirm password
        public bool validatepassword()
        {
            if (_txt_pass.Text != _txt_confirmpass.Text)
            {
                MessageBox.Show("confirm password not matching with new passsword");
                _txt_confirmpass.Focus();
                return true;
            }
            else
            {
                return false;
            }
        }
        //passwordsozw
        public bool validatepasssize(TextBox s)
        {
            if (_txt_pass.Text.Length < 5)
            {

                MessageBox.Show("Password must be at least 5 characters long");
                _txt_confirmpass.Clear();
                return true;
            }
            else { return false; }
        }
        public bool validatemobile(TextBox s)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(s.Text, "^01[0-5]{1}[0-9]{8}"))
            {
                MessageBox.Show(s.Name + " must be in mobile format 01012345678.");
                s.Focus();
                return true;

            }
            else { return false; }

        }


        //SaveButton's Code
        private void button2_Click(object sender, EventArgs e)
        {
            CheckBox[] arr = new CheckBox[12] { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10, checkBox11, checkBox12 };
            int id = -1;
            if (validateTextBox(_txt_name)) { }
            else if (validateTextBox(_txt_code)) { }
            else if (validateTextBox(_txt_pass)) { }
            else if (validatepasssize(_txt_pass)) { }
            else if (validateTextBox(_txt_confirmpass)) { }
            else if (validatepasssize(_txt_confirmpass)) { }
            else if (validatepassword()) { }
            else if (validatemobile(_txt_phone)) { }

            else {
                id = ps.InsertNewUser(_txt_name.Text, _txt_pass.Text, _txt_code.Text, _txt_phone.Text, _txt_address.Text, _rich_notes.Text);
                if(id!=-1)
                {
                    for (int i = 0; i < 12; i++)
                    {
                        if(arr[i].Checked)
                            if (!ps.InsertNewPriveledge(user_id, i + 1))
                            {
                                MessageBox.Show("Error in priviledges");
                                return;
                            }
                    }
                    MessageBox.Show("User added Successfully");
                   
                    button1_Click(sender, e);
                }
            else
            {
                    MessageBox.Show("An Error Occurred");
                }
                autocomplete();
            }
        }
        //DeleteButton's Code
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateTextBox(_txt_name)) { }
                else if (validateTextBox(_txt_code)) { }
                else if (validateTextBox(_txt_pass)) { }
                else if (validatepasssize(_txt_pass)) { }
                else if (validateTextBox(_txt_confirmpass)) { }
                else if (validatepasssize(_txt_confirmpass)) { }
                else if (validatepassword()) { }
                else if (validatemobile(_txt_phone)) { }
                else
                {
                    ps.DeleteUser(_txt_name.Text);
                    button1_Click(sender, e);
                    MessageBox.Show("Your Deleted Successfully");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Your Delete Operation Failed");

            }
            
        }
        //UpdateButton's Code
     
        private void button4_Click(object sender, EventArgs e)
        {
            CheckBox[] arr = new CheckBox[12] { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10, checkBox11, checkBox12 };
            if (validateTextBox(_txt_name)) { }
            else if (validateTextBox(_txt_code)) { }
            else if (validateTextBox(_txt_pass)) { }
            else if (validatepasssize(_txt_pass)) { }
            else if (validateTextBox(_txt_confirmpass)) { }
            else if (validatepasssize(_txt_confirmpass)) { }
            else if (validatepassword()) { }
            else if (validatemobile(_txt_phone)) { }
            else if (ps.UpdateUser(user_id, _txt_name.Text, _txt_pass.Text, _txt_code.Text, _txt_phone.Text, _txt_address.Text, _rich_notes.Text))
            {
                ps.DeletePrivilege(user_id);
                for (int i = 0; i < 12; i++)
                {
                    if (arr[i].Checked)
                      if(!ps.InsertNewPriveledge(user_id, i + 1))
                        {
                            MessageBox.Show("Error in priviledges");
                            return;
                        }
                }
                MessageBox.Show("User Updated Successfully");
                button1_Click(sender, e);
            }
            else MessageBox.Show("Your Update Operation Failed");
            autocomplete();
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
        //AutoComplete Function
        public void autocomplete()
        {
            _txt_name.AutoCompleteSource = AutoCompleteSource.CustomSource;
            _txt_name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            DataTable dt = ps.GetUser();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (usercombo.Text == "UserName")
                {
                    string name = dt.Rows[i]["UserName"].ToString();
                    col.Add(name);
                }

                else if (usercombo.Text == "Code")
                {
                    textBox7.Clear();
                    string name = dt.Rows[i]["Code"].ToString();
                    col.Add(name);
                }
                else if(usercombo.Text=="Phone")
                {
                    textBox7.Clear();
                    string name = dt.Rows[i]["Phone"].ToString();
                    col.Add(name);
                }
            }

                textBox7.AutoCompleteCustomSource = col;
            }
        //SearchButton's Code
        private void button6_Click(object sender, EventArgs e)
        {
            CheckBox[] arr = new CheckBox[12] { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10, checkBox11, checkBox12 };

            if (validateTextBox(textBox7)) { }
            else
            {
                DataTable dt = ps.GetUser(usercombo.Text, textBox7.Text);
                if (dt.Rows.Count == 1)
                {
                    user_id = int.Parse(dt.Rows[0][0].ToString());
                    DataTable pdt = ps.GetPrivilege("UserID", user_id.ToString());
                    _txt_name.Text = dt.Rows[0][1].ToString();
                    _txt_code.Text = dt.Rows[0][3].ToString();
                    _txt_phone.Text = dt.Rows[0][4].ToString();
                    _txt_address.Text = dt.Rows[0][5].ToString();
                    _rich_notes.Text = dt.Rows[0][6].ToString();
                    for (int i = 0; i < pdt.Rows.Count; i++)
                    {
                        int c = Convert.ToInt32(pdt.Rows[i][1]);
                        arr[c - 1].Checked = true;

                    }
                    SearchButton_Click(sender, e);

                }
                else
                {
                    MessageBox.Show("User Not Exist");
                }
            }

        }

        private void usercombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            autocomplete();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchPanel.Width = 0;
        }

        private void UsersUC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            //this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            //this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            UserOriginalSize = this.Size;
            button11OrginalRect = new Rectangle(button1.Location.X, button1.Location.Y, button1.Width, button1.Height);
        }
        private void resizeChildernControls()
        {
            resizeChildernControls(button11OrginalRect, button1);
        }

        private void resizeChildernControls(Rectangle panel1OrginalRect, Button button1)
        {

        }
        private void resizeControl(Rectangle orginalControlRect, Control control)
        {
            
            float xRatio = (float)(this.Width) / (float)(UserOriginalSize.Width);
            float yRatio = (float)(this.Height) / (float)(UserOriginalSize.Height);

            int newX = (int)(orginalControlRect.X * xRatio);
            int newY = (int)(orginalControlRect.Y * yRatio);
            int newWidth = (int)(orginalControlRect.X * xRatio);
            int newHeight = (int)(orginalControlRect.Y * yRatio);

            control.Location = new Point(newX, newY);
            control.Size = new Size(newWidth, newHeight);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UsersUC_Resize(object sender, EventArgs e)
        {
            resizeChildernControls();
        }
        private void _txt_phone_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(_txt_phone.Text, "^01[0-2]{1}[0-9]{9}"))
            {
                MessageBox.Show("Please enter phone in coreect format such as 01111111111.");
                _txt_phone.Clear();
            }
        }

        private void _txt_code_TextChanged(object sender, EventArgs e)
        {

        }

        private void _txt_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar)&&!char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Name Must Be letter");
            }
        }

        private void _txt_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Code Must Be Number");
            }
        }

        private void _txt_pass_KeyPress(object sender, KeyPressEventArgs e)
        {
        
        }

        private void _txt_phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = true;
            //    MessageBox.Show("Phone Must Be Number");
            //}
        }

        private void _txt_address_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Address Must Be text");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void _txt_confirmpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void _txt_address_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        bool t = false;
        bool t1 = false;
        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (t1) return;
            t = true;
            CheckBox[] arr = new CheckBox[12] { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10, checkBox11, checkBox12 };
            for (int i = 0; i < 12; i++)
            {
                arr[i].Checked = checkBox12.Checked;
            }
            t = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (t) return;
            t1 = true;
            CheckBox[] arr = new CheckBox[11] { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10, checkBox11 };
            for (int i = 0; i < 11; i++)
            {
                if (arr[i].Checked == false )
                { checkBox12.Checked = false; t1 = false; return; }
            }
            t1 = false;
        }
    }
    }


