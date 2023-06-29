using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Skills_International_Project
{
    public partial class Registration_Form : Form
    {
        public Registration_Form()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7J7AAD9;Initial Catalog=Final_Project;Integrated Security=True");
        SqlCommand com;

        string gender;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (rbMale.Checked)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }
            try
            {
                con.Open();
                string sqlinsert = "Insert into Registrations(regNo, firstName, lastName, dateOfBirth, gender, address," +
                    " email, mobilePhone, homePhone, parentName, nic, contactNo)Values " +
                    "('" + cmbRegno.Text + "' ,'" + txtFname.Text + "' , '" + txtLname.Text + "' ,'" + dtpDOB.Text + "','" + gender + "'," +
                    "'" + txtAddress.Text + "','" + txtEmail.Text + "','" + txtMphone.Text + "','" + txtHphone.Text + "','" + txtPname.Text + "'," +
                    "'" + txtNIC.Text + "','" + txtCnumber.Text + "')";
                com = new SqlCommand(sqlinsert, con);
                com.ExecuteNonQuery();
                MessageBox.Show("Register Student", "Record Added Succesfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

            private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbMale.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                con.Open();
                string sqlupdate = "update registrations set firstName ='" + txtFname.Text + "',lastName ='" + txtLname.Text + "'" +
                    ",dateOfBirth ='" + dtpDOB.Text + "',gender ='" + gender + "',address ='" + txtAddress.Text + "',email ='" + txtEmail.Text + "'," +
                    "mobilePhone='" + txtMphone.Text + "',homePhone ='" + txtHphone.Text + "',parentName ='" + txtPname.Text + "'" +
                    ",nic='" + txtNIC.Text + "',contactNo='" + txtCnumber.Text + "' where regNo ='" + cmbRegno.Text + "'";
                com = new SqlCommand(sqlupdate, con);
                com.ExecuteNonQuery();
                MessageBox.Show("Update Student", "Record Update Succesfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            { 
                con.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbRegno.Text = "";
            txtFname.Text = "";
            txtLname.Text = "";
            dtpDOB.Format = DateTimePickerFormat.Custom;
            dtpDOB.CustomFormat = "yyyy/MM/dd";
            DateTime thisDay = DateTime.Today;
            dtpDOB.Text = thisDay.ToString();
            rbMale.Checked = false;
            rbFemale.Checked = false;
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtMphone.Text = "";
            txtHphone.Text = "";
            txtPname.Text = "";
            txtNIC.Text = "";
            txtCnumber.Text = "";
            cmbRegno.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string sql_delete = "delete from registrations where regNO='" + cmbRegno.Text + "'";
                com = new SqlCommand(sql_delete, con);
                com.ExecuteNonQuery();

                var delete = (MessageBox.Show("Delete", "Are you sure, Do you really want to Delete this Record...?", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question));

                if (delete == DialogResult.Yes)
                {
                    MessageBox.Show("Delete Student", "Record Deleted Succesfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cmbRegno.Text = "";
                txtFname.Text = "";
                txtLname.Text = "";
                dtpDOB.Format = DateTimePickerFormat.Custom;
                dtpDOB.CustomFormat = "yyyy/MM/dd";
                DateTime thisDay = DateTime.Today;
                dtpDOB.Text = thisDay.ToString();
                rbMale.Checked = false;
                rbFemale.Checked = false;
                txtAddress.Text = "";
                txtEmail.Text = "";
                txtMphone.Text = "";
                txtHphone.Text = "";
                txtPname.Text = "";
                txtNIC.Text = "";
                txtCnumber.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void llblLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login_Form loginForm = new Login_Form();
            loginForm.Show();
            this.Close();
        }

        private void llblExit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure, Do you really want to exit....?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void cmbRegno_SelectedIndexChanged(object sender, EventArgs e)
        {
            string no = cmbRegno.Text;
            if (no != "New Register")
            {
                con.Open();
                string query_select = "select * from registrations where regNo =" + no;
                SqlCommand com = new SqlCommand(query_select, con);
                SqlDataReader row = com.ExecuteReader();
                while (row.Read())
                {
                    txtFname.Text = row[1].ToString();
                    txtLname.Text = row[2].ToString();
                    dtpDOB.Format = DateTimePickerFormat.Custom;
                    dtpDOB.CustomFormat = "yyyy/MM/dd";
                    dtpDOB.Text = row[3].ToString();
                    if (row[4].ToString() == "Male")
                    {
                        rbMale.Checked = true;
                        rbFemale.Checked = false;

                    }
                    else
                    {
                        rbMale.Checked = false;
                        rbFemale.Checked = true;
                    }
                    txtAddress.Text = row[5].ToString();
                    txtEmail.Text = row[6].ToString();
                    txtMphone.Text = row[7].ToString();
                    txtHphone.Text = row[8].ToString();
                    txtPname.Text = row[9].ToString();
                    txtNIC.Text = row[10].ToString();
                    txtCnumber.Text = row[11].ToString();
                }
                con.Close();
                btnRegister.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnClear.Enabled = true;
            }
            else
            {
                cmbRegno.SelectedIndex = 0;
                txtFname.Text = "";
                txtLname.Text = "";
                dtpDOB.Format = DateTimePickerFormat.Custom;
                dtpDOB.CustomFormat = "yyyy/MM/dd";
                DateTime thisDay = DateTime.Today;
                dtpDOB.Text = thisDay.ToString();
                rbMale.Checked = false;
                rbFemale.Checked = false;
                txtAddress.Text = "";
                txtEmail.Text = "";
                txtMphone.Text = "";
                txtHphone.Text = "";
                txtPname.Text = "";
                txtNIC.Text = "";
                txtCnumber.Text = "";
                btnRegister.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnClear.Enabled = true;
            }
        }

    private void Registration_Form_Load(object sender, EventArgs e)
        {
            con.Open();
            string query_select = "select * from registrations";
            SqlCommand cmd = new SqlCommand(query_select, con);
            SqlDataReader row = cmd.ExecuteReader();
            cmbRegno.Items.Add("New Register");
            while (row.Read())
            {
                cmbRegno.Items.Add(row[0].ToString());
            }
            con.Close();
            MaximizeBox = false;
        }
    }
}
