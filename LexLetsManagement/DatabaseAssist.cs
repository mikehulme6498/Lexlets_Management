using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Azure.KeyVault;
using System.Threading.Tasks;

namespace LexLetsManagement
{
    class DatabaseAssist
    {

        static private SqlConnection connectToLexlets;
        static public string ConnectionName { get; private set; }

        static public SqlConnection ConnectToLexlets
        {
            get { return connectToLexlets; }
        }

        static public bool ConnectToDatabase()
        {
            if (DatabaseAssist.ConnectToLexlets.State.ToString() == "Closed")
            {
                try
                {
                    DatabaseAssist.ConnectToLexlets.Open();
                    return true;
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message.ToString(),"Cannot locate selected database", MessageBoxButtons.OK);
                    return false;
                }
            }
            return true;
        }

        static public void BackupDatabase()
        {
            string date = DateTime.Now.ToString("dd.MM.yyyy");
            string time = DateTime.Now.ToString("hh-mm-ss");
            string OriginalFilePath = Directory.GetCurrentDirectory() + @"\lexletsdatabase.mdf";
            string OriginalFilePath2 = Directory.GetCurrentDirectory() + @"\lexletsdatabase_log.ldf";
            string DestinationFilePath = @"C:\Users\mikeh\OneDrive\Programming\C#\LexLets Database Backup\Backup " + date + " at " + time + @"\";
      
            try
            {
                Directory.CreateDirectory(DestinationFilePath);
                File.Copy(OriginalFilePath, DestinationFilePath + "lexletsdatabase.mdf");
                File.Copy(OriginalFilePath2, DestinationFilePath + "lexletsdatabase_log.ldf");
                MessageBox.Show("Backup Was successful", "Success");
            }
            catch
            {
                DialogResult result = MessageBox.Show("Could not find the specifed path to backup would you like to manually select one", "Path not found", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    FolderBrowserDialog fbd = new FolderBrowserDialog();

                    if(fbd.ShowDialog() == DialogResult.OK)
                    {
                        DestinationFilePath = fbd.SelectedPath + @"\LexLets Database Backup\Backup " + date + " at " + time + @"\";
                        Directory.CreateDirectory(DestinationFilePath);
                        File.Copy(OriginalFilePath, DestinationFilePath + "lexletsdatabase.mdf");
                        File.Copy(OriginalFilePath2, DestinationFilePath + "lexletsdatabase_log.ldf");
                        MessageBox.Show("Backup Was successful", "Success");
                    }
                }

            }
        }
        
        static  public void SetConnectionStringAsync(string db)
        {
            if (db == "AzureDB")
            {
                // Section removed for GitHub
            }
            else if (db == "Work")
            {
                connectToLexlets = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=M:\Settings\Desktop\New folder\LexLetsManagement\lexletsdatabase.mdf; Integrated Security = True");
                ConnectionName = "Work";
            }
            else if (db == "HomeTest")
            {
                connectToLexlets = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mike\Desktop\LexLets Management\LexLetsManagement\testdatabase.mdf ;Integrated Security=True");
                ConnectionName = "Test";
            }
            else if (db == "WorkTest")
            {
                connectToLexlets = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=M:\Settings\Desktop\New folder\LexLetsManagement\testdatabase.mdf; Integrated Security = True");
                ConnectionName = "Test";
            }
            else if(db =="Custom Location")
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string database = ofd.FileName;
                    FileInfo file = new FileInfo(database);
                    connectToLexlets = new SqlConnection((@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + database + "; Integrated Security = True"));
                    ConnectionName = "Custom :\n" + file.FullName;
                }
            }
            else
            {
                MessageBox.Show("No database selected");
            }
        }

        static public string GetDatabaseName()
        {
            return ConnectionName;
        }

        static public void UpdateMaterialQty(int sku, int quant, string AddRemove)
        {
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            ConnectToDatabase();

            // Retrieves All the materials that are used for the corresponding sku

            SqlDataAdapter da = new SqlDataAdapter("Select * from tblProductContains where sku = @sku", connectToLexlets);
            da.SelectCommand.Parameters.AddWithValue("@sku", sku);
            DataTable dtProductContains = new DataTable();
            da.Fill(dtProductContains);

            for (int i = 1; i <= quant; i++) // loops though the amount of times product was sold
            {
                for (int j = 0; j < dtProductContains.Rows.Count; j++) // loops through each material and adjusts stock
                {
                    int materialId = Convert.ToInt32(dtProductContains.Rows[j]["MaterialID"]);
                    int materialQuant = Convert.ToInt32(dtProductContains.Rows[j]["MaterialQTY"]);
                    int amountInStock = 0;

                    // Retrieve Qty instock to adjust and insert back in
                    SqlDataAdapter daGetQtyInStock = new SqlDataAdapter("Select QTYinStock from tblMaterials where MaterialId = @id", connectToLexlets);
                    daGetQtyInStock.SelectCommand.Parameters.AddWithValue("@id", materialId);
                    DataTable dtMaterials = new DataTable();
                    daGetQtyInStock.Fill(dtMaterials);

                    amountInStock = Convert.ToInt32((dtMaterials.Rows[0]["QTYinStock"]));

                    if (AddRemove == "Add")
                    {
                        amountInStock = amountInStock + materialQuant;
                    }
                    else if (AddRemove == "Remove")
                    {
                        amountInStock = amountInStock - materialQuant;
                    }

                    command = new SqlCommand(@"UPDATE tblMaterials SET QTYinStock = @qty WHERE MaterialID = @id", connectToLexlets);
                    command.Parameters.AddWithValue("@qty", amountInStock);
                    command.Parameters.AddWithValue("@id", materialId);
                    ConnectToDatabase();
                    command.ExecuteNonQuery();

                    connectToLexlets.Close();
                    dtMaterials.Dispose();
                }
            }
        }

        static public void UpdateProductQtySold(int sku, int quant, string AddRemove)
        {
            int currentAmountSold;
            if (connectToLexlets.State.ToString() == "Closed") { connectToLexlets.Open(); }
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();


            // Retrieve Qty sold to update and insert back in
            SqlDataAdapter da = new SqlDataAdapter("Select QTYSold from tblProductData where sku = @sku", connectToLexlets);
            da.SelectCommand.Parameters.AddWithValue("@sku", sku);
            DataTable dt = new DataTable();
            da.Fill(dt);


            if (dt.Rows.Count == 0)
            {
                return;
            }

            currentAmountSold = Convert.ToInt32((dt.Rows[0]["QTYSold"]));

            if (AddRemove == "Add")
            {
                currentAmountSold = currentAmountSold + quant;
            }
            else if (AddRemove == "Remove")
            {
                currentAmountSold = currentAmountSold - quant;
            }

            command = new SqlCommand(@"UPDATE tblProductData SET QTYSold = @qtysold WHERE SKU = @sku", connectToLexlets);
            command.Parameters.AddWithValue("@qtysold", currentAmountSold);
            command.Parameters.AddWithValue("@sku", sku);
            ConnectToDatabase();
            command.ExecuteNonQuery();
            connectToLexlets.Close();
            dt.Dispose();
            da.Dispose();
        }

        static public void UpdateGiftBoxes(string description, int quant, string AddRemove)
        {
            int currentAmountSold = 0;
            
            int matID = Convert.ToInt16(GetOneCellValue("Select MaterialID FROM tblGiftBox Where BoxName= @param",description,"MaterialID"));

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlDataAdapter da = new SqlDataAdapter("Select QTYinStock from tblMaterials where MaterialId = @id", connectToLexlets);
            da.SelectCommand.Parameters.AddWithValue("@id", matID);
            DataTable dt = new DataTable();
            da.Fill(dt);

            currentAmountSold = Convert.ToInt32((dt.Rows[0]["QTYinStock"]));

                if (AddRemove == "Add")
                {
                    currentAmountSold = currentAmountSold + quant;
                }
                else if (AddRemove == "Remove")
                {
                    currentAmountSold = currentAmountSold - quant;
                }

            command = new SqlCommand(@"UPDATE tblMaterials SET QTYinStock = @qtyinstock WHERE MaterialId = @id", connectToLexlets);
            command.Parameters.AddWithValue("@qtyinstock", currentAmountSold);
            command.Parameters.AddWithValue("@id", matID);
            ConnectToDatabase();
            command.ExecuteNonQuery();
            
            dt.Dispose();
            da.Dispose();
        }

       static public void RunQuery(string sqlstring)
        {
            SqlCommand command;
            command = new SqlCommand(@sqlstring, connectToLexlets);

            ConnectToDatabase();
            command.ExecuteNonQuery();
            connectToLexlets.Close();

        }

        static public string GetOneCellValue(string sql, int param, string column)
        {
            string value = "";
            ConnectToDatabase();
            SqlDataAdapter da = new SqlDataAdapter(sql, connectToLexlets);
            da.SelectCommand.Parameters.AddWithValue("@param", param);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connectToLexlets.Close();
            value = (dt.Rows[0][column]).ToString();
            return value;
        }

        static public string GetOneCellValue(string sql, string param, string column)
        {
            string value = "";
            ConnectToDatabase();
            SqlDataAdapter da = new SqlDataAdapter(sql, connectToLexlets);
            da.SelectCommand.Parameters.AddWithValue("@param", param);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connectToLexlets.Close();
            value = (dt.Rows[0][column]).ToString();
            return value;
        }

        static public string GetOneCellValue(string sql, int param, int param2, string column)
        {
            string value = "";
            ConnectToDatabase();
            SqlDataAdapter da = new SqlDataAdapter(sql, connectToLexlets);
            da.SelectCommand.Parameters.AddWithValue("@param", param);
            da.SelectCommand.Parameters.AddWithValue("@param2", param2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connectToLexlets.Close();
            value = (dt.Rows[0][column]).ToString();
            return value;
        }

        static public string GetOneCellValue(string sql, int param, int param2, string param3, string column)
        {
            string value = "";
            ConnectToDatabase();
            SqlDataAdapter da = new SqlDataAdapter(sql, connectToLexlets);
            da.SelectCommand.Parameters.AddWithValue("@param", param);
            da.SelectCommand.Parameters.AddWithValue("@param2", param2);
            da.SelectCommand.Parameters.AddWithValue("@param3", param3);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connectToLexlets.Close();
            try
            {
                value = (dt.Rows[0][column]).ToString();
            }
            catch
            {
                value = "0";
            }
                return value;
        }

        static public int GetOneCellValue(string sql, string param, string param2, string param3, string column)
        {
            int value;
            ConnectToDatabase();
            SqlDataAdapter da = new SqlDataAdapter(sql, connectToLexlets);
            da.SelectCommand.Parameters.AddWithValue("@param", param);
            da.SelectCommand.Parameters.AddWithValue("@param2", param2);
            da.SelectCommand.Parameters.AddWithValue("@param3", param3);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connectToLexlets.Close();
            try
            {
                value = Convert.ToInt32(dt.Rows[0][column]);
            }
            catch
            {
                value = -1;
            }
            return value;
        }

        static public int GetLastSKU()
        {
            int tempSKU;

            try
            {
                ConnectToDatabase();
                SqlDataAdapter da = new SqlDataAdapter("select SKU from tblProductData ORDER BY SKU DESC", connectToLexlets);
                DataTable dt = new DataTable();
                da.Fill(dt);
                tempSKU = Convert.ToInt32(dt.Rows[0]["SKU"]);
                tempSKU++;
                connectToLexlets.Close();
                da.Dispose();
                dt.Dispose();
                dt.Clear();
            }
            catch
            {
                return -1;
            }
            return tempSKU;
        }

        static public bool CheckIfItemExists(string sql, string param)
        {
            ConnectToDatabase();
            SqlDataAdapter da = new SqlDataAdapter(sql, connectToLexlets);
            da.SelectCommand.Parameters.AddWithValue("@param", param);
            DataTable dt = new DataTable();
            da.Fill(dt);
                        
            connectToLexlets.Close();

            if (dt.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public List<int> GetAllCustomerID()
        {
            List<int> customerID = new List<int>();
            ConnectToDatabase();

            SqlDataAdapter da = new SqlDataAdapter("Select CustomerID from tblCustomers", connectToLexlets);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i =0; i<dt.Rows.Count; i++)
            {
                customerID.Add(Convert.ToInt32(dt.Rows[i]["CustomerID"]));
            }
            da.Dispose();
            dt.Dispose();
            connectToLexlets.Close();
            return customerID;
        }

        static public DataTable CreateDataTable(string sql)
        {
            ConnectToDatabase();
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DatabaseAssist.ConnectToLexlets);
            adapter.Fill(data);
            connectToLexlets.Close();
            return data;

        }

        static public DataTable CreateDataTable(string sql, int param)
        {
            ConnectToDatabase();
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DatabaseAssist.ConnectToLexlets);
            adapter.SelectCommand.Parameters.AddWithValue("@param", param);
            adapter.Fill(data);
            connectToLexlets.Close();
            return data;
        }

        static public DataTable CreateDataTable(string sql, string param)
        {
            ConnectToDatabase();
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DatabaseAssist.ConnectToLexlets);
            adapter.SelectCommand.Parameters.AddWithValue("@param", param);
            adapter.Fill(data);
            connectToLexlets.Close();
            return data;
        }

        static public DataTable CreateDataTable(string sql, int param, int param2)
        {
            ConnectToDatabase();
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DatabaseAssist.ConnectToLexlets);
            adapter.SelectCommand.Parameters.AddWithValue("@param", param);
            adapter.SelectCommand.Parameters.AddWithValue("@param2", param2);
            adapter.Fill(data);
            connectToLexlets.Close();
            return data;
        }

        static public DataTable CreateDataTable(string sql, string param, string param2, string param3)
        {
            ConnectToDatabase();
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DatabaseAssist.ConnectToLexlets);
            adapter.SelectCommand.Parameters.AddWithValue("@param", param);
            adapter.SelectCommand.Parameters.AddWithValue("@param2", param2);
            adapter.SelectCommand.Parameters.AddWithValue("@param3", param3);
            adapter.Fill(data);
            connectToLexlets.Close();
            return data;
        }


    } 
}
