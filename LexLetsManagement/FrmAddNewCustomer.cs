using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace LexLetsManagement
{
    public partial class FrmAddNewCustomer : Form
    {

        public FrmAddNewCustomer()
        {
            InitializeComponent();
        }
        
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateEntries() > 0)
            {
                MessageBox.Show("Please correct highlighted fields", "Error");
            }
            else
            { 
                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();
                String sql = "";

                sql = "INSERT into tblCustomers VALUES (@fname, @sname, @add1, @add2, @pcode, @email, @sub)";
                if (DatabaseAssist.ConnectToDatabase() == true)
                {
                    command = new SqlCommand(sql, DatabaseAssist.ConnectToLexlets);
                    command.Parameters.AddWithValue("@fname", TxtFirstName.Text);
                    command.Parameters.AddWithValue("@sname", TxtSurName.Text);
                    command.Parameters.AddWithValue("@add1", TxtAdd1.Text);
                    command.Parameters.AddWithValue("@add2", TxtAdd2.Text);
                    command.Parameters.AddWithValue("@pcode", TxtPostCode.Text);
                    command.Parameters.AddWithValue("@email", TxtEmail.Text);
                    command.Parameters.AddWithValue("@sub", CmbSub.SelectedItem);

                    int i = command.ExecuteNonQuery();
                    command.Dispose();
                    DatabaseAssist.ConnectToLexlets.Close();

                    if (i != 0)
                    {

                        MessageBox.Show("Customer Saved");
                        TxtFirstName.Text = "";
                        TxtSurName.Text = "";
                        TxtAdd1.Text = "";
                        TxtAdd2.Text = "";
                        TxtEmail.Text = "";
                        TxtPostCode.Text = "";
                        CmbSub.Text = "";
                    }

                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int ValidateEntries()
        {
            TextBox[] txtBoxes = new TextBox[] { TxtFirstName, TxtSurName, TxtAdd1, TxtAdd2, TxtPostCode, TxtEmail };
            PictureBox[] errorPic = new PictureBox[] { PicError0, PicError1, PicError2, PicError3, PicError4, PicError5, PicError6 };
            int count = 0;
            int score = 0;

            foreach (TextBox text in txtBoxes)
            {
                if (String.IsNullOrEmpty(text.Text) || text.Text.Length <= 2)
                {
                    errorPic[count].Visible = true;
                    new ToolTip().SetToolTip(errorPic[count], "Field Cannot Be Empty and needs more than 2 charactors");
                    score++;
                }
                else
                {
                    errorPic[count].Visible = false;
                }
                count++;
            }

            if (!txtBoxes[5].Text.Contains("@") || !txtBoxes[5].Text.Contains("."))
            {
                errorPic[5].Visible = true;
                new ToolTip().SetToolTip(errorPic[5], "Invalid Email Address");
                score++;
            }
            else
            {
                errorPic[5].Visible = false;
                new ToolTip().Hide(errorPic[5]);
            }

            if (CmbSub.SelectedIndex == -1)
            {
                errorPic[6].Visible = true;
                new ToolTip().SetToolTip(errorPic[6], "Please Select From The Drop Down Menu");
                score++;
            }
            else
            {
                errorPic[6].Visible = false;
                new ToolTip().Hide(errorPic[6]);

            }
            return score;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValidateEntries();
        }

     }
}
