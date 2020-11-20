using Excel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LexLetsManagement
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
        }

        DataSet result;

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            Helper.FillCombo(cmbUsers, "SELECT Username FROM tblUsers", "Username");
            Helper.FillCombo(cmbSKU, "SELECT SKU From tblProductData", "SKU");
            Helper.FillCombo(cmbUser, "Select Username from tblUsers", "Username");

            LoadData("select tblUsersLog.Date, tblUsers.Username, tblUsersLog.Category, tblUsersLog.Activity FROM tblUsersLog inner join tblUsers on tblUsersLog.UserID = tblUsers.UserId ORDER BY tblUsersLog.Date DESC");
            if (User.AccessLevel != 1)
            {
                tabControl1.TabPages.Remove(UserAccess);
                tabControl1.TabPages.Remove(ImportFromExcel);
                tabControl1.TabPages.Remove(TestTab);
            }
        }

        private void LoadData(string sql)
        {
            string userID = "1";
            dataGridView1.DataSource = null;
            dataGridView1.Update();
            dataGridView1.Refresh();
            SqlCommand cmd;
            SqlDataAdapter adapter = new SqlDataAdapter();
            try
            {
                if (cmbUsers.SelectedItem != null)
                {
                    userID = DatabaseAssist.GetOneCellValue("SELECT UserId FROM tblUsers WHERE Username = @param", cmbUsers.SelectedItem.ToString(), "UserId");
                }
            }
            catch
            {

            }
            if (DatabaseAssist.ConnectToDatabase() == true)
            {

                cmd = new SqlCommand(sql, DatabaseAssist.ConnectToLexlets);
                cmd.Parameters.AddWithValue("@user", Convert.ToInt32(userID));
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tbl1");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "tbl1";

                DatabaseAssist.ConnectToLexlets.Close();
            }
        }

        private void CmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData("select tblUsersLog.Date, tblUsers.Username, tblUsersLog.Category, tblUsersLog.Activity FROM tblUsers inner join tblUsersLog on tblUsers.UserId = tblUsersLog.UserID where tblUsers.UserId = @user ORDER BY tblUsersLog.Date DESC");
        }

        private void CmbSKU_SelectedValueChanged(object sender, EventArgs e)
        {
            lblDescription.Text = DatabaseAssist.GetOneCellValue("Select Description from tblProductData WHERE SKU = @param", Convert.ToInt32(cmbSKU.SelectedItem), "Description");
        }

        private void BtnAdjust_Click(object sender, EventArgs e)
        {
            if (Helper.CheckTextBoxForString(txtQuant.Text) == "notnumber")
            {
                MessageBox.Show("Please Enter a valid Quantity to add/remove", "Error");
                txtQuant.Focus();
                txtQuant.Text = "";
                return;
            }
            else if (cmbSKU.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select a valid SKU", "Error");
                cmbSKU.Focus();
                cmbSKU.SelectedText = "";
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to adjust material " + cmbSKU.SelectedItem.ToString(), "Are you sure?", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                if (radAdd.Checked)
                {
                    DatabaseAssist.UpdateMaterialQty(Convert.ToInt32(cmbSKU.SelectedItem), Convert.ToInt32(txtQuant.Text), "Add");
                    User.AddToUserLog("Materials Adjusted", User.Username + "Added Materials for SKU " + cmbSKU.SelectedItem.ToString());
                }
                else if (radRemove.Checked)
                {
                    DatabaseAssist.UpdateMaterialQty(Convert.ToInt32(cmbSKU.SelectedItem), Convert.ToInt32(txtQuant.Text), "Remove");
                    User.AddToUserLog("Materials Adjusted", User.Username + "Removed Materials for SKU " + cmbSKU.SelectedItem.ToString());
                }
            }
            else
            {
                return;
            }

            MessageBox.Show("Materials have been Adjusted", "Success");
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Files|*.xls;*.xlsx;*.xlsm", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                    IExcelDataReader reader = ExcelReaderFactory.CreateBinaryReader(fs);
                    reader.IsFirstRowAsColumnNames = true;
                    result = reader.AsDataSet();
                    cmbSheet.Items.Clear();
                    foreach (DataTable dt in result.Tables)
                        cmbSheet.Items.Add(dt.TableName);
                    reader.Close();
                }
            }

        }

        private void CmbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewExcel.DataSource = result.Tables[cmbSheet.SelectedIndex];
        }

        private void BtnCopyToTable_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dataGridViewExcel.Rows)
            {
                string sqlquery = "insert into tblImportSales VALUES (@order, @fname, @sname, @add1, @add2, @email," +
                    "@date, @subtotal, @shipping, @total, @percent, @gbp, @payment, @sku, @qty, @price, @gift, @size, @postcode)";
                SqlCommand com = new SqlCommand(sqlquery, DatabaseAssist.ConnectToLexlets);
                com.Parameters.AddWithValue("@order", dr.Cells["Order ."].Value ?? DBNull.Value);
                com.Parameters.AddWithValue("@fname", dr.Cells["FirstName"].Value ?? DBNull.Value);
                com.Parameters.AddWithValue("@sname", dr.Cells["SurName"].Value ?? DBNull.Value);
                com.Parameters.AddWithValue("@add1", dr.Cells["Shipping Street Address"].Value ?? DBNull.Value);
                com.Parameters.AddWithValue("@add2", dr.Cells["Shipping City"].Value ?? DBNull.Value);
                com.Parameters.AddWithValue("@email", dr.Cells["Email Address"].Value ?? DBNull.Value);
                com.Parameters.AddWithValue("@date", Convert.ToDateTime(dr.Cells["Order Date and Time Stamp"].Value ?? DBNull.Value));
                com.Parameters.AddWithValue("@subtotal", Convert.ToDouble(dr.Cells["Subtotal"].Value ?? DBNull.Value));
                com.Parameters.AddWithValue("@shipping", Convert.ToDouble(dr.Cells["Shipping Cost"].Value ?? DBNull.Value));
                com.Parameters.AddWithValue("@total", Convert.ToDouble(dr.Cells["Total"].Value ?? DBNull.Value));
                com.Parameters.AddWithValue("@percent", dr.Cells["Percent"].Value ?? DBNull.Value);
                com.Parameters.AddWithValue("@gbp", Convert.ToDouble(dr.Cells["GBP"].Value ?? DBNull.Value));
                com.Parameters.AddWithValue("@payment", dr.Cells["PaymentMethod"].Value ?? DBNull.Value);
                com.Parameters.AddWithValue("@sku", dr.Cells["SKU"].Value ?? DBNull.Value);
                com.Parameters.AddWithValue("@qty", dr.Cells["LineItem Qty"].Value ?? DBNull.Value);
                com.Parameters.AddWithValue("@price", Convert.ToDouble(dr.Cells["LineItem Sale Price"].Value ?? DBNull.Value));
                com.Parameters.AddWithValue("@gift", dr.Cells["GiftBox"].Value ?? DBNull.Value);
                com.Parameters.AddWithValue("@size", dr.Cells["size"].Value ?? DBNull.Value);
                com.Parameters.AddWithValue("@postcode", dr.Cells["Shipping Zip"].Value ?? DBNull.Value);

                if (DatabaseAssist.ConnectToDatabase() == true)
                {
                    com.ExecuteNonQuery();
                    DatabaseAssist.ConnectToLexlets.Close();
                }

            }
            MessageBox.Show("Table Has Been Inserted");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //Selects all invoice numbers
            DataTable Invoices = DatabaseAssist.CreateDataTable("SELECT DISTINCT [Order] From tblImportSales", 1, 1);
            int currentId;

            for (int i = 0; i < Invoices.Rows.Count; i++) //Selects each individual invoice number
            {

                DataTable orders = DatabaseAssist.CreateDataTable("SELECT * FROM tblImportSales WHERE [Order] = @param", Convert.ToInt32(Invoices.Rows[i]["Order"]), 1);

                currentId = GetCustomerID(orders);

                DataTable invoiceData = DatabaseAssist.CreateDataTable("SELECT * FROM tblInvoiceData WHERE InvoiceNumber= @Param", Convert.ToInt32(Invoices.Rows[i]["Order"]));

                if (invoiceData.Rows.Count == 0) // skips this step if invoice already exists 
                {
                    InsertSaleIntoInvoiceData(currentId, orders);
                    AddToIncome(orders);
                }

                DataTable invoiceProducts = DatabaseAssist.CreateDataTable("SELECT * FROM tblInvoiceProducts WHERE InvoiceNumber= @Param", Convert.ToInt32(Invoices.Rows[i]["Order"]));

                if (invoiceProducts.Rows.Count == 0) // skips this step if invoice already exists 
                {
                    InsertIntoInvoiceProducts(orders);
                }
            }
        }

        private void AddToIncome(DataTable orders)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";

            string invoice = orders.Rows[0]["Order"].ToString();
            string fname = orders.Rows[0]["FirstName"].ToString();
            string sname = orders.Rows[0]["Surname"].ToString();
            string description = "Invoice No: " + invoice + " - " + fname + " " + sname;
            double price;

            double fee;

            if (orders.Rows[0]["PaymentMethod"].ToString() == "PayPal")
            {
                fee = (3.4 / 100) * Convert.ToDouble(orders.Rows[0]["Total"]) + 0.20;
            }
            else
            {
                fee = (1.4 / 100) * Convert.ToDouble(orders.Rows[0]["Total"]) + 0.20;

            }
            fee = Math.Round(fee, 2);

            price = (Convert.ToDouble(orders.Rows[0]["Subtotal"]) + Convert.ToDouble(orders.Rows[0]["Shipping"]));

            try
            {
                price -= Convert.ToDouble(orders.Rows[0]["CouponCode"]);
            }
            catch
            {

            }

            try
            {
                price -= Convert.ToDouble(orders.Rows[0]["CouponCode"]);
            }
            catch
            {

            }

            price -= fee;

            sql = "INSERT into tblincome VALUES (@date, @category, @description, @amount, @method, @receipt)";

            SqlCommand com = new SqlCommand(sql, DatabaseAssist.ConnectToLexlets);
            com.Parameters.AddWithValue("@date", Convert.ToDateTime(orders.Rows[0]["Date"]));
            com.Parameters.AddWithValue("@category", "Sale");
            com.Parameters.AddWithValue("@description", description);
            com.Parameters.AddWithValue("@amount", price);
            com.Parameters.AddWithValue("@method", orders.Rows[0]["PaymentMethod"]);
            com.Parameters.AddWithValue("@receipt", "No");
            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                com.ExecuteNonQuery();
                DatabaseAssist.ConnectToLexlets.Close();
            }
        }

        private void InsertIntoInvoiceProducts(DataTable orders)
        {

            for (int i = 0; i < orders.Rows.Count; i++)
            {
                string GiftBox = orders.Rows[i]["GiftBox"].ToString();
                double giftPrice;
                string sqlquery = "insert into tblInvoiceProducts VALUES (@invoice, @sku, @size, @qty, @giftbox, @giftboxprice, @skuprice)";
                SqlCommand com = new SqlCommand(sqlquery, DatabaseAssist.ConnectToLexlets);

                if (GiftBox == "Yes")
                {
                    GiftBox = "Silver Box - Bracelet";
                    giftPrice = 4.50;
                }
                else
                {
                    GiftBox = "No";
                    giftPrice = 0;
                }
                com.Parameters.AddWithValue("@invoice", Convert.ToInt32(orders.Rows[i]["Order"]));
                com.Parameters.AddWithValue("@sku", Convert.ToInt32(orders.Rows[i]["SKU"]));
                com.Parameters.AddWithValue("@size", orders.Rows[i]["Size"]);
                com.Parameters.AddWithValue("@qty", Convert.ToInt32(orders.Rows[i]["Qty"]));
                com.Parameters.AddWithValue("@GiftBox", GiftBox);
                com.Parameters.AddWithValue("@GiftBoxprice", giftPrice);
                com.Parameters.AddWithValue("@skuprice", Convert.ToDouble(orders.Rows[i]["ItemPrice"]));

                if (DatabaseAssist.ConnectToDatabase() == true)
                {
                    com.ExecuteNonQuery();
                    DatabaseAssist.ConnectToLexlets.Close();
                }
                DatabaseAssist.UpdateProductQtySold(Convert.ToInt32(orders.Rows[i]["SKU"]), Convert.ToInt32(orders.Rows[i]["Qty"]), "Add");
            }
        }

        private void InsertSaleIntoInvoiceData(int id, DataTable orders)
        {
            double fee;
            double coupon;

            if (orders.Rows[0]["PaymentMethod"].ToString() == "PayPal")
            {
                fee = (3.4 / 100) * Convert.ToDouble(orders.Rows[0]["Total"]) + 0.20;
            }
            else
            {
                fee = (1.4 / 100) * Convert.ToDouble(orders.Rows[0]["Total"]) + 0.20;

            }
            fee = Math.Round(fee, 2);

            try
            {
                coupon = Convert.ToDouble(orders.Rows[0]["CouponCode"]);
            }
            catch
            {
                coupon = 0;
            }


            string sqlquery = "insert into tblInvoiceData VALUES (@invoice, @id, @sale, @Shipping, @PayMethod, @addCost, @comment, @percent, @gbp, @total, @fee)";
            SqlCommand com = new SqlCommand(sqlquery, DatabaseAssist.ConnectToLexlets);
            com.Parameters.AddWithValue("@invoice", Convert.ToInt32(orders.Rows[0]["Order"]));
            com.Parameters.AddWithValue("@id", id);
            com.Parameters.AddWithValue("@sale", Convert.ToDateTime(orders.Rows[0]["Date"]));
            com.Parameters.AddWithValue("@Shipping", Convert.ToDouble(orders.Rows[0]["Shipping"]));
            com.Parameters.AddWithValue("@PayMethod", orders.Rows[0]["PaymentMethod"]);
            com.Parameters.AddWithValue("@addCost", 0);
            com.Parameters.AddWithValue("@comment", "");
            com.Parameters.AddWithValue("@percent", coupon);
            com.Parameters.AddWithValue("@gbp", Convert.ToDouble(orders.Rows[0]["Discount"]));
            com.Parameters.AddWithValue("@total", (Convert.ToDouble(orders.Rows[0]["Subtotal"]) + Convert.ToDouble(orders.Rows[0]["Shipping"])));
            com.Parameters.AddWithValue("@fee", fee);
            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                com.ExecuteNonQuery();
                DatabaseAssist.ConnectToLexlets.Close();
            }
        }

        private int GetCustomerID(DataTable orders)
        {

            // check if customer exists, if it does return id number if not add to table then search again to get id number then return
            int id = 1;
            string fname = orders.Rows[0]["FirstName"].ToString();
            string sname = orders.Rows[0]["Surname"].ToString();
            string postcode = orders.Rows[0]["Postcode"].ToString();

            DataTable customer = DatabaseAssist.CreateDataTable("SELECT * FROM tblCustomers WHERE FirstName = @param AND Surname=@param2 AND Postcode =@param3", fname, sname, postcode);

            if (customer.Rows.Count > 0)
            {

                id = Convert.ToInt32(customer.Rows[0]["CustomerID"]);
            }
            else
            {
                string sqlquery = "insert into tblCustomers VALUES (@firstName, @surname, @add1, @add2, @postcode, @email, @sub, @comments)";
                SqlCommand com = new SqlCommand(sqlquery, DatabaseAssist.ConnectToLexlets);
                com.Parameters.AddWithValue("@firstName", orders.Rows[0]["FirstName"]);
                com.Parameters.AddWithValue("@surname", orders.Rows[0]["Surname"]);
                com.Parameters.AddWithValue("@add1", orders.Rows[0]["Address1"]);
                com.Parameters.AddWithValue("@add2", orders.Rows[0]["Address2"]);
                com.Parameters.AddWithValue("@postcode", orders.Rows[0]["Postcode"]);
                com.Parameters.AddWithValue("@email", orders.Rows[0]["Email"]);
                com.Parameters.AddWithValue("@sub", "No");
                com.Parameters.AddWithValue("@comments", "");
                if (DatabaseAssist.ConnectToDatabase() == true)
                {
                    com.ExecuteNonQuery();
                    DatabaseAssist.ConnectToLexlets.Close();
                }
                id = DatabaseAssist.GetOneCellValue("SELECT CustomerID FROM tblCustomers WHERE FirstName = @param AND Surname=@param2 AND Postcode =@param3", fname, sname, postcode, "CustomerID");
                listBox1.Items.Add("New Id : " + id + " - " + fname + " " + sname);
            }
            customer.Dispose();
            return id;
        }



        private void Button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dataGridViewExcel.Rows)
            {
                string sqlquery = "insert into tblOutgoing VALUES (@date, @cat, @desc, @amount, @payment, @receipt)";
                SqlCommand com = new SqlCommand(sqlquery, DatabaseAssist.ConnectToLexlets);
                com.Parameters.AddWithValue("@date", Convert.ToDateTime(dr.Cells["Date"].Value));
                com.Parameters.AddWithValue("@cat", dr.Cells["Category"].Value ?? DBNull.Value);
                com.Parameters.AddWithValue("@desc", dr.Cells["Description"].Value ?? DBNull.Value);
                com.Parameters.AddWithValue("@amount", Convert.ToDouble(dr.Cells["Amount"].Value ?? DBNull.Value));
                com.Parameters.AddWithValue("@payment", dr.Cells["PaymentMethod"].Value ?? DBNull.Value);
                com.Parameters.AddWithValue("@receipt", dr.Cells["Receipt"].Value ?? DBNull.Value);

                if (DatabaseAssist.ConnectToDatabase() == true)
                {
                    com.ExecuteNonQuery();
                    DatabaseAssist.ConnectToLexlets.Close();
                }

            }
            MessageBox.Show("Table Has Been Inserted");
        }

        private void BtnCust_Click(object sender, EventArgs e)
        {
            DataTable duplicates = DatabaseAssist.CreateDataTable("SELECT Email, count(*) as Entires From tblCustomers GROUP BY Email HAVING count(*) > 1 ORDER BY count(*) DESC");

            for (int i = 0; i < duplicates.Rows.Count; i++)
            {
                DataTable currentCustomer = DatabaseAssist.CreateDataTable("select * from tblCustomers where Email = @param", duplicates.Rows[i]["Email"].ToString());

                for (int j = 1; j < currentCustomer.Rows.Count; j++)
                {
                    int firstId = Convert.ToInt32(currentCustomer.Rows[0]["CustomerID"]);
                    int idToAlter = Convert.ToInt32(currentCustomer.Rows[j]["CustomerID"]);
                    string add1 = currentCustomer.Rows[j]["Address1"].ToString();
                    string add2 = currentCustomer.Rows[j]["Address2"].ToString();
                    string postcode = currentCustomer.Rows[j]["postcode"].ToString();


                    CopyToOldAdresses(firstId, add1, add2, postcode);
                    AlterIdFromInvoices(firstId, idToAlter);
                    DeleteRow(idToAlter);
                }
            }
        }

        private void CopyToOldAdresses(int id, string add1, string add2, string postcode)
        {
            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlCommand com = new SqlCommand("INSERT INTO tblCustomersOtherAdresses VALUES(@id, @add1, @add2, @postcode)", DatabaseAssist.ConnectToLexlets);
                com.Parameters.AddWithValue("@id", id);
                com.Parameters.AddWithValue("@add1", add1);
                com.Parameters.AddWithValue("@add2", add2);
                com.Parameters.AddWithValue("@postcode", postcode);
                com.ExecuteNonQuery();
                DatabaseAssist.ConnectToLexlets.Close();
            }
        }

        private void AlterIdFromInvoices(int newid, int oldId)
        {
            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlCommand com = new SqlCommand("Update tblInvoiceData set CustomerId = @newId WHERE CustomerId = @oldId", DatabaseAssist.ConnectToLexlets);
                com.Parameters.AddWithValue("@newId", newid);
                com.Parameters.AddWithValue("@oldId", oldId);
                com.ExecuteNonQuery();
                DatabaseAssist.ConnectToLexlets.Close();
            }
        }

        private void DeleteRow(int id)
        {
            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlCommand com = new SqlCommand("DELETE FROM tblCustomers WHERE CustomerId = @id", DatabaseAssist.ConnectToLexlets);
                com.Parameters.AddWithValue("@id", id);
                com.ExecuteNonQuery();
                DatabaseAssist.ConnectToLexlets.Close();
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {

            string salt = Helper.CreateSalt(20);
            string hashedPassword = Helper.GenerateSHA256HASH(txtPassword.Text, salt);

            txtSalt.Text = salt;
            txtEncrypted.Text = hashedPassword;
        }



        private void btnTest_Click(object sender, EventArgs e)
        {
            string salt = txtTestSalt.Text;
            string hashedPassword = Helper.GenerateSHA256HASH(txtTestPass.Text, salt);


            txtTestEncrypted.Text = hashedPassword;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
            txtResult.Text = txtInput.Text.ToCamelCase();
        }

        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbAccess.Enabled = true;
            LoadUser();
            pnlUserInfo.Visible = true;
        }

        private void LoadUser()
        {
            if (cmbUser.SelectedItem != null)
            {
                DataTable selectedUser = DatabaseAssist.CreateDataTable("Select * from tblUsers Where Username=@param", cmbUser.SelectedItem.ToString());
                lblAccessLevel.Text = $"Current Access Level : { selectedUser.Rows[0]["AccessLevel"].ToString() }";
                lblFailedLoginAttemps.Text = selectedUser.Rows[0]["FailedLoginAttempts"].ToString();
                lblUserId.Text = selectedUser.Rows[0]["UserId"].ToString();
                lblAccessLevel.Visible = true;
                SetAccountStateLabel(Convert.ToBoolean(selectedUser.Rows[0]["AccountLocked"]));
            }
            else
            {
                MessageBox.Show("Please Select a User", "No user selected");
            }
        }

        private void SetAccountStateLabel(bool locked)
        {

            if (locked == true)
            {
                lblAccountState.ForeColor = Color.Red;
                lblAccountState.Text = "Locked";
                btnUnlock.Visible = true;
            }
            else
            {
                lblAccountState.ForeColor = Color.Green;
                lblAccountState.Text = "OK";
            }
        }

        private void cmbAccess_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnUpdate.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DatabaseAssist.ConnectToDatabase();
            SqlDataAdapter adapter = new SqlDataAdapter("UPDATE tblUsers SET AccessLevel = @access Where UserId = @user", DatabaseAssist.ConnectToLexlets);
            adapter.SelectCommand.Parameters.AddWithValue("@access", cmbAccess.SelectedIndex + 1);
            adapter.SelectCommand.Parameters.AddWithValue("@user", lblUserId.Text);
            adapter.SelectCommand.ExecuteNonQuery();
            DatabaseAssist.ConnectToLexlets.Close();
            MessageBox.Show("User Access Level Updated", "Success");
        }

        private void BtnUnlock_Click(object sender, EventArgs e)
        {
            DatabaseAssist.ConnectToDatabase();
            SqlDataAdapter adapter = new SqlDataAdapter("UPDATE tblUsers SET AccountLocked = @locked, FailedLoginAttempts = @attempts Where UserId = @user", DatabaseAssist.ConnectToLexlets);
            adapter.SelectCommand.Parameters.AddWithValue("@locked", "false");
            adapter.SelectCommand.Parameters.AddWithValue("@attempts", 0);
            adapter.SelectCommand.Parameters.AddWithValue("@user", lblUserId.Text);
            adapter.SelectCommand.ExecuteNonQuery();
            DatabaseAssist.ConnectToLexlets.Close();
            MessageBox.Show("Account unlocked", "Success");
            LoadUser();
        }

        private void LblAccountState_TextChanged(object sender, EventArgs e)
        {
            CheckUnblockButtonVisibilty();
        }

        private void CheckUnblockButtonVisibilty()
        {
            btnUnlock.Visible = lblAccountState.Text == "OK" ? false : true;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlDataAdapter adapter = new SqlDataAdapter("Delete From tblUsers WHERE UserId = @id", DatabaseAssist.ConnectToLexlets);
                adapter.SelectCommand.Parameters.AddWithValue("@id", lblUserId.Text);
                adapter.SelectCommand.ExecuteNonQuery();
                DatabaseAssist.ConnectToLexlets.Close();
                MessageBox.Show(cmbUser.SelectedItem.ToString() + " has been removed", "User Deleted");
                pnlUserInfo.Visible = false;
                cmbUser.Text = "";
                Helper.FillCombo(cmbUser, "Select Username from tblUsers", "Username");
            }
        }
    }
}
