using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LexLetsManagement
{ 
    public partial class frmlogin : Form
    {
    public frmlogin()
    {
        InitializeComponent();
    }

    private void Butexit_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void Butlogin_Click(object sender, EventArgs e)
    {
        if (CheckFieldsAreFilled() == false)
        {
            MessageBox.Show("Please Fill in all fields", "Username & Password");
            return;
        }

        DatabaseAssist.SetConnectionStringAsync(cmbDatabase.SelectedItem.ToString());

        if (CheckUserExists() == true)
        {
            if ((cmbDatabase.SelectedItem.ToString() == "AzureDB" || cmbDatabase.SelectedItem.ToString() == "Work") && User.AccessLevel == 3)
            {
                MessageBox.Show("User does not have access to main database \nPlease select a test database", "Access Level", MessageBoxButtons.OK);
                return;
            }
            else if (User.AcountLocked == true)
            {
                MessageBox.Show("Account is locked - There has been too many failed attempts. Please Contact the system admnitstrator", "Account Locked", MessageBoxButtons.OK);
                return;
            }
            else
            {
                Frmmainmenu main = new Frmmainmenu();
                User.AddToUserLog("Login", User.Username + " Logged In");
                this.Hide();
                main.ShowDialog();
            }
        }
        else
        {
            return;
        }
    }
    private bool CheckFieldsAreFilled()
    {
        bool valid = true;

        if (txtUser.Text == string.Empty || txtPassword.Text == string.Empty || cmbDatabase.SelectedItem == null)
        {
            valid = false;
        }

        return valid;
    }

    private bool CheckUserExists()
    {
        bool userExists = false;
        string lockAccount = "false";

        if (DatabaseAssist.ConnectToDatabase() == true)
        {

            SqlDataAdapter da = new SqlDataAdapter("Select * FROM tblUsers WHERE Username =@user AND Password =@pass", DatabaseAssist.ConnectToLexlets);
            da.SelectCommand.Parameters.AddWithValue("@user", txtUser.Text.ToLower());
            da.SelectCommand.Parameters.AddWithValue("@pass", HashPassword());
            DataTable dt = new DataTable();
            da.Fill(dt);
            DatabaseAssist.ConnectToLexlets.Close();

            if (dt.Rows.Count == 0)
            {
                string failedAttempts = "";
                try
                {
                    failedAttempts = DatabaseAssist.GetOneCellValue("select * From tblUsers WHERE Username = @param", txtUser.Text.ToLower(), "FailedLoginAttempts");
                }
                catch
                {
                    MessageBox.Show("User Does Not Exist", "No User Found");
                    return false;
                }
                int failed = Convert.ToInt16(failedAttempts);
                bool locked = Convert.ToBoolean(DatabaseAssist.GetOneCellValue("select * From tblUsers WHERE Username = @param", txtUser.Text.ToLower(), "AccountLocked"));


                if (failed >= 3 && locked == false)
                {
                    MessageBox.Show("Too many failed attempts account is now locked. Click yes to request for account to be unlocked", "Too many failed attempts", MessageBoxButtons.YesNo);
                    lockAccount = "true";
                }
                else if (locked == true)
                {
                    MessageBox.Show("Account is locked. Please contact the system administrator to regain access", "Too many failed attempts", MessageBoxButtons.OK);
                    return false;
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password - " + (3 - failed) + " Attemps Remaining", "Error", MessageBoxButtons.OK);
                }
                SqlCommand command = new SqlCommand();
                command = new SqlCommand(@"UPDATE tblUsers SET FailedLoginAttempts = @failed, AccountLocked =@locked WHERE Username =@user", DatabaseAssist.ConnectToLexlets);
                command.Parameters.AddWithValue("@failed", Convert.ToInt16(failed + 1));
                command.Parameters.AddWithValue("@locked", lockAccount);
                command.Parameters.AddWithValue("@user", txtUser.Text.ToLower());
                DatabaseAssist.ConnectToDatabase();
                command.ExecuteNonQuery();
                DatabaseAssist.ConnectToLexlets.Close();

                userExists = false;
                return userExists;
            }
            else
            {
                User.Username = (dt.Rows[0]["Username"].ToString());
                User.AccessLevel = Convert.ToInt16(dt.Rows[0]["AccessLevel"]);
                User.UserId = Convert.ToInt16(dt.Rows[0]["UserId"]);
                User.AcountLocked = Convert.ToBoolean(dt.Rows[0]["AccountLocked"]);
                userExists = true;
                return userExists;
            }
        }
        return userExists;
    }

    private string HashPassword()
    {
        string salt = "";
        DataTable user = DatabaseAssist.CreateDataTable("Select * FROM tblUsers WHERE Username =@param", txtUser.Text.ToLower());
        try
        {
            salt = user.Rows[0]["Salt"].ToString();
        }
        catch
        {
            return string.Empty;
        }
        //string hash = user.Rows[0]["Password"].ToString();
        string password = txtPassword.Text;

        return Helper.GenerateSHA256HASH(password, salt);
    }

    private void lblNewUser_Click(object sender, EventArgs e)
    {

        if (cmbDatabase.SelectedItem == null)
        {
            MessageBox.Show("Please select a database to register too", "No database selected");
            return;
        }

        DatabaseAssist.SetConnectionStringAsync(cmbDatabase.SelectedItem.ToString());

        if (DatabaseAssist.ConnectToDatabase() == true)
        {
            FrmRegisterNewUser newUser = new FrmRegisterNewUser();
            newUser.ShowDialog();
        }
    }


    }
}
