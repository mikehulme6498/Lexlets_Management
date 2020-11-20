using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LexLetsManagement
{
    public partial class FrmOutgoing : Form
    {
        public FrmOutgoing()
        {
            InitializeComponent();
        }

        private void FrmOutgoing_Load(object sender, EventArgs e)
        {
            FillCombo(cmbCategory, "SELECT * FROM tblOutgoingCategory ORDER BY CategoryName ASC", "CategoryName");
            FillCombo(cmbMethod, "SELECT * FROM tblPaymentMethods ORDER BY MethodName ASC", "MethodName");
        }

        private void FillCombo(ComboBox combo, string sql, string columnName)
        {
            combo.Items.Clear();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DatabaseAssist.ConnectToLexlets);
            DataTable dt = new DataTable();
            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                adapter.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    combo.Items.Add(dt.Rows[i][columnName].ToString());
                }
                DatabaseAssist.ConnectToLexlets.Close();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData() != 0)
            {
                MessageBox.Show("Please Fix Fields With Errors", "Error", MessageBoxButtons.OK);
                return;
            }
            else
            {
                if (radExpense.Checked)
                {
                    User.AddToUserLog("Add Transaction", User.Username + " Added an expense " + "(" + cmbCategory.SelectedItem.ToString() + " - " + txtDescription.Text);
                    SaveTransaction("INSERT into tbloutgoing VALUES (@date, @category, @description, @amount, @paymentmethod, @receipt)");
                }
                else if (radIncome.Checked)
                {
                    User.AddToUserLog("Add Transaction", User.Username + " Added Income " + "(" + cmbCategory.SelectedItem.ToString() + " - " + txtDescription.Text);
                    SaveTransaction("INSERT into tblincome VALUES (@date, @category, @description, @amount, @paymentmethod, @receipt)");
                }
                else
                {
                    MessageBox.Show("Please Select if Transcation is an Expense or Income.", "Error", MessageBoxButtons.OK);
                }
            }

            DialogResult result = MessageBox.Show("Transaction Saved, Would You Like To Add Another?", "Success", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                ClearAll();
            }
            else
            {
                this.Close();
            }
        }

        private void ClearAll()
        {
            txtAmount.Text = "";
            txtDescription.Text = "";
            cmbCategory.Text = "";
            cmbMethod.Text = "";
            chkReceipt.Checked = false;
            radExpense.Checked = true;
            txtDescription.Focus();
        }

        private void SaveTransaction(string sql)
        {
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();

            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                command = new SqlCommand(sql, DatabaseAssist.ConnectToLexlets);

                command.Parameters.AddWithValue("@date", Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString()));
                command.Parameters.AddWithValue("@category", cmbCategory.SelectedItem.ToString());
                command.Parameters.AddWithValue("@description", txtDescription.Text);
                command.Parameters.AddWithValue("@amount", Convert.ToDouble(Helper.RemovePoundSign(txtAmount.Text)));
                command.Parameters.AddWithValue("@paymentmethod", cmbMethod.SelectedItem.ToString());
                if (chkReceipt.Checked)
                {
                    command.Parameters.AddWithValue("@receipt", "Yes");
                }
                else
                {
                    command.Parameters.AddWithValue("@receipt", "No");
                }
                command.ExecuteNonQuery();
                DatabaseAssist.ConnectToLexlets.Close();
            }
        }

        private int ValidateData()
        {
            int errors = 0;

            if (cmbCategory.SelectedIndex == -1)
            {
                errors++;
                picErrorCategory.Visible = true;
            }
            else
            {
                picErrorCategory.Visible = false;
            }

            if (cmbMethod.SelectedIndex == -1)
            {
                errors++;
                picErrorMethod.Visible = true;
            }
            else
            {
                picErrorMethod.Visible = false;
            }

            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                errors++;
                picErrorDescription.Visible = true;
            }
            else
            {
                picErrorDescription.Visible = false;
            }

            if (Helper.CheckTextBoxForString(txtAmount.Text) == "notnumber" || Helper.CheckTextBoxForString(txtAmount.Text) == "empty")
            {
                errors++;
                picErrorAmount.Visible = true;
            }
            else
            {
                picErrorAmount.Visible = false;
            }

            return errors;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radExpense_CheckedChanged(object sender, EventArgs e)
        {
            if (gbxTransaction.Text == "Add Expense")
            {
                gbxTransaction.Text = "Add Income";
            }
            else
            {
                gbxTransaction.Text = "Add Expense";
            }
        }
    }
}
