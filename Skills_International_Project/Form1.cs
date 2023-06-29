using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skills_International_Project
{
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtusername.Clear();
            txtpassword.Clear();
            txtusername.Focus();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username, password;

            username = txtusername.Text;
            password = txtpassword.Text;

            try
            {

                if (username == "Admin" && password == "Skills@1234")
                {
                    Registration_Form form2 = new Registration_Form();
                    form2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid login Credentials, Please check Username and Password and try again", "Invalid login Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtusername.Clear();
                    txtpassword.Clear();
                    txtusername.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void Login_Form_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure, Do you really want to exit....?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes) 
            {
                Application.Exit();
            }
        }
    }
}
