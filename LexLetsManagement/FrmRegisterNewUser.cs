using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LexLetsManagement
{
    public partial class FrmRegisterNewUser : Form
    {
        public FrmRegisterNewUser()
        {
            InitializeComponent();
        }

        private void RegisterNewUser_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private string HashPassword()
        {
            DataTable user = DatabaseAssist.CreateDataTable("Select * FROM tblUsers WHERE Username =@param", txtUsername.Text);
            string salt = user.Rows[0]["Salt"].ToString();
            //string hash = user.Rows[0]["Password"].ToString();
            string password = txtPassword2.Text;
            return Helper.GenerateSHA256HASH(password, salt);
        }

        private bool IsUsernameValid()
        {
            if (txtUsername.TextLength >= 4)
            {
                DataTable users = DatabaseAssist.CreateDataTable("Select Username FROM tblUsers");

                for (int i = 0; i < users.Rows.Count; i++)
                {
                    if (users.Rows[i]["Username"].ToString() == txtUsername.Text.ToCamelCase())
                    {
                        lblUserExists.Text = "Username Taken";
                        lblUserExists.ForeColor = Color.Red;
                        lblUserExists.Visible = true;
                        users.Dispose();
                        return false;
                    }
                }

                lblUserExists.Text = "Username Available";
                lblUserExists.ForeColor = Color.Green;
                lblUserExists.Visible = true;
                users.Dispose();
                return true;
            }

            if (txtUsername.TextLength <= 4)
            {
                lblUserExists.Text = "Must Be At Least 4 Charactors";
                lblUserExists.ForeColor = Color.Red;
                lblUserExists.Visible = true;

            }

            return false;
        }

        private bool DoesPasswordMatch()
        {
            if (txtPassword.Text != txtPassword2.Text)
            {
                lblPasswordMatch.Visible = true;
                return false;
            }
            else
            {
                lblPasswordMatch.Visible = false;
                return true;
            }
        }

        private bool IsEmailValid()
        {
            string regEx = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            if (txtEmail.TextLength > 6)
            {
                Match match = Regex.Match(txtEmail.Text, regEx);
                if (!match.Success)
                {
                    lblEmailWrong.Visible = true;
                    return false;
                }
                else
                {
                    lblEmailWrong.Visible = false;
                    return true;
                }
            }
            return false;
        }

        private void ShouldRegisterButtonBeEnabled()
        {
            if (IsUsernameValid() == true && DoesPasswordMatch() == true && IsEmailValid() == true)
            {
                BtnRegister.Enabled = true;
            }
            else
            {
                BtnRegister.Enabled = false;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEmail_KeyUp(object sender, KeyEventArgs e)
        {
            ShouldRegisterButtonBeEnabled();
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            ShouldRegisterButtonBeEnabled();
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            ShouldRegisterButtonBeEnabled();
        }

        private void txtUsername_KeyUp(object sender, KeyEventArgs e)
        {
            ShouldRegisterButtonBeEnabled();
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            ShouldRegisterButtonBeEnabled();
        }

        private void txtPassword2_KeyUp(object sender, KeyEventArgs e)
        {
            ShouldRegisterButtonBeEnabled();
        }
        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string salt = Helper.CreateSalt(20);
            string hashedPassword = Helper.GenerateSHA256HASH(txtPassword2.Text, salt);
            string originalDatabase = DatabaseAssist.ConnectionName;
            string testDatabase = originalDatabase == "Home" ? "HomeTest" : "WorkTest";

            AddNewUserToDatabase(hashedPassword, salt);
            //DatabaseAssist.SetConnectionString(testDatabase);
            //AddNewUserToDatabase(hashedPassword, salt);
            DatabaseAssist.SetConnectionStringAsync(originalDatabase);

            this.Enabled = false;
            MessageBox.Show("Access Level by defult is set to minimum\n\nPlease contact administrator to request a higher access level.", "User Created", MessageBoxButtons.OK);

            this.Close();
        }

        private void AddNewUserToDatabase(string hashed, string salt)
        {
            DatabaseAssist.ConnectToDatabase();
            SqlCommand command = new SqlCommand(@"INSERT into tblUsers (Username, Password, AccessLevel, FailedLoginAttempts, AccountLocked, Salt, Email) VALUES (@user, @password, @access, @failed, @locked, @salt, @email)", DatabaseAssist.ConnectToLexlets);
            command.Parameters.AddWithValue("@user", txtUsername.Text.ToCamelCase());
            command.Parameters.AddWithValue("@password", hashed);
            command.Parameters.AddWithValue("@access", 3);
            command.Parameters.AddWithValue("@failed", 0);
            command.Parameters.AddWithValue("@locked", "false");
            command.Parameters.AddWithValue("@salt", salt);
            command.Parameters.AddWithValue("@email", txtEmail.Text.ToLower());
            command.ExecuteNonQuery();
            DatabaseAssist.ConnectToLexlets.Close();
        }        
    }
}
