using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LexLetsManagement
{
    public partial class FrmAddNewCollection : Form
    {
        int rowCount = 1;

        public FrmAddNewCollection()
        {
            InitializeComponent();
        }

        private void CreateSkuCombo()
        {
            string sql = "Select SKU FROM tblProductData ORDER BY SKU ASC";

            ComboBox sku = new ComboBox
            {
                Name = "cmbSku" + rowCount.ToString(),
                AutoSize = false,
                Size = new System.Drawing.Size(flowLayoutSKU.Width, 25)
            };

            sku.Leave += new System.EventHandler(sku_Leave);
            sku.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            sku.Font = new Font("Arial", 7, FontStyle.Regular);
            sku.ForeColor = Color.Black;
            FillCombo(sku, sql, "SKU", 0);
            sku.SelectedIndexChanged += new System.EventHandler(sku_SelectedIndexChanged);
            flowLayoutSKU.Controls.Add(sku);
            btnAddAnother.Location = new Point(50, sku.Location.Y + 110);
            btnDelete.Location = new Point(15, sku.Location.Y + 85);
        }

        private void CreateLabel(string name, FlowLayoutPanel panel)
        {
            Label label = new Label();
            label.Name = name + rowCount.ToString();
            label.BorderStyle = BorderStyle.FixedSingle;
            label.AutoSize = false;
            label.Font = new Font("Arial", 10, FontStyle.Regular);
            label.ForeColor = Color.Black;
            label.Size = new System.Drawing.Size(panel.Width, 21);
            label.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            label.TextAlign = ContentAlignment.TopCenter;
            label.BorderStyle = BorderStyle.None;
            panel.Controls.Add(label);
        }
        private void sku_Leave(object sender, EventArgs e)
        {
            Helper.ValidateCombo(sender as ComboBox);
        }

        private void sku_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetActiveRowInformation(sender as ComboBox);
            btnAddAnother.Visible = true;
        }

        private void GetActiveRowInformation(ComboBox comboBox)
        {
            if (DatabaseAssist.ConnectToDatabase() == true)
            {

                SqlDataAdapter da = new SqlDataAdapter("Select Description, CostToMake, SellPrice FROM tblProductData where SKU =@sku", DatabaseAssist.ConnectToLexlets);
                da.SelectCommand.Parameters.AddWithValue("@sku", Convert.ToInt32(comboBox.SelectedItem));
                DataTable dt = new DataTable();

                da.Fill(dt);

                foreach (Label lab in flowLayoutDescription.Controls)
                {
                    if (lab.Name == "lblDescription" + (rowCount - 1).ToString())
                    {
                        lab.Text = (dt.Rows[0]["Description"].ToString());
                    }
                }

                foreach (Label lab in flowLayoutCost.Controls)
                {
                    if (lab.Name == "lblCost" + (rowCount - 1).ToString())
                    {
                        lab.Text = "£" + (dt.Rows[0]["CostToMake"].ToString());
                    }
                }

                foreach (Label lab in flowLayoutSellPrice.Controls)
                {
                    if (lab.Name == "lblSellPrice" + (rowCount - 1).ToString())
                    {
                        lab.Text = "£" + (dt.Rows[0]["SellPrice"].ToString());
                    }
                }


                DatabaseAssist.ConnectToLexlets.Close();
                da.Dispose();
                dt.Dispose();
                dt.Clear();
            }
        }


        public void FillCombo(ComboBox combo, string sql, string columnName, int selectedItem)
        {
            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, DatabaseAssist.ConnectToLexlets);
                DataTable dt = new DataTable();

                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    combo.Items.Add(dt.Rows[i][columnName]);
                }

                combo.SelectedValue = dt.Rows[selectedItem][columnName];
                combo.Text = dt.Rows[selectedItem][columnName].ToString();

                DatabaseAssist.ConnectToLexlets.Close();
                da.Dispose();
                dt.Dispose();
                dt.Clear();
            }
        }

        private void CreateRow()
        {
            if (rowCount == 11)
            {
                MessageBox.Show("Maximum Products Added", "Error");
            }
            else
            {
                CreateSkuCombo();
                CreateLabel("lblDescription", flowLayoutDescription);
                CreateLabel("lblCost", flowLayoutCost);
                CreateLabel("lblSellPrice", flowLayoutSellPrice);
                rowCount++;
            }
        }


        private void FrmAddNewCollection_Load(object sender, EventArgs e)
        {
            CreateRow();
        }

        private void BtnDone_Click(object sender, EventArgs e)
        {
            double suggestedPrice = 0;
            double sellPrice = 0;

            string sql = "Select ProductCategoryDescription from tblProductCategory Order by ProductCategoryDescription asc";
            TxtSKU.Text = DatabaseAssist.GetLastSKU().ToString();
            TxtCost.Text = "£" + GetTotals(flowLayoutCost).ToString();
            sellPrice = GetTotals(flowLayoutSellPrice);
            suggestedPrice = Math.Ceiling(GetTotals(flowLayoutSellPrice) - ((GetTotals(flowLayoutSellPrice) / 100) * 10));

            lblSellPrice.Text = "Selling Seperately would be £" + sellPrice;
            lblSuggested.Text = "Suggested price £" + suggestedPrice.ToString();

            gbxProductDetails.Enabled = true;
            gbxMaterials.Enabled = false;
            lblSuggested.Visible = true;
            lblSellPrice.Visible = true;
            btnAddAnother.Visible = false;
            btnDelete.Visible = false;
            BtnDone.Visible = false;
            BtnEdit.Visible = true;
            FillCombo(CmbCategory, sql, "ProductCategoryDescription", 2);

        }

        private double GetTotals(FlowLayoutPanel panel)
        {
            double total = 0;

            foreach (Label label in panel.Controls)
            {
                total += Convert.ToDouble(Helper.RemovePoundSign(label.Text));
            }
            return total;
        }

        private void TxtDescription_TextChanged(object sender, EventArgs e)
        {
            CmbCategory.Enabled = true;
        }

        private void CmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtCost.Enabled = true;
            TxtPrice.Enabled = true;
            BtnAttachImage.Enabled = true;
        }

        private void btnAddAnother_Click_1(object sender, EventArgs e)
        {
            CreateRow();
            btnDelete.Visible = true;
            btnAddAnother.Visible = false;
        }

        private void BtnAttachImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png)"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picPath = dlg.FileName.ToString();
                TxtPicPath.Text = picPath;
                picImage.ImageLocation = picPath;

            }

            lblAddImage.Visible = false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

            if (ValidateEntries() != 0)
            {
                MessageBox.Show("Please Fix highlighted fields", "Error");
                return;
            }
            else
            {
                SaveToCollectionContains();
                SaveToCollectionData();
                User.AddToUserLog("Add Collection", User.Username + " Added a new collection (" + TxtDescription.Text + ")");
                DialogResult result = MessageBox.Show("Collection Saved, Would You Like To Add Another??", "Success", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    ClearAll();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void ClearAll()
        {
            flowLayoutSKU.Controls.Clear();
            flowLayoutDescription.Controls.Clear();
            flowLayoutSellPrice.Controls.Clear();
            flowLayoutCost.Controls.Clear();
            TxtCost.Text = "";
            TxtDescription.Text = "";
            TxtPicPath.Text = "";
            TxtSKU.Text = "";
            TxtPrice.Text = "";
            BtnEdit.Visible = false;
            BtnDone.Visible = true;
            rowCount = 1;
            picImage.Image = null;
            gbxMaterials.Enabled = true;
            lblSuggested.Visible = false;
            lblSellPrice.Visible = false;
            CreateRow();

        }

        private void SaveToCollectionData()
        {
            byte[] imagebt = null;
            FileStream fstream = new FileStream(TxtPicPath.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imagebt = br.ReadBytes((int)fstream.Length);
            string sql = "INSERT into tblProductData (SKU, Category, Description, CostToMake, SellPrice, Image, QTYSold, DateAdded) VALUES (@sku, @category, @description, @cost, @sell, @image, @sold, @added)";
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();

            command = new SqlCommand(sql, DatabaseAssist.ConnectToLexlets);
            command.Parameters.AddWithValue("@sku", Convert.ToInt32(TxtSKU.Text));
            command.Parameters.AddWithValue("@category", CmbCategory.SelectedItem.ToString());
            command.Parameters.AddWithValue("@description", TxtDescription.Text);
            command.Parameters.AddWithValue("@cost", Helper.RemovePoundSign(TxtCost.Text));
            command.Parameters.AddWithValue("@sell", Helper.RemovePoundSign(TxtPrice.Text));
            command.Parameters.AddWithValue("@image", imagebt);
            command.Parameters.AddWithValue("@sold", 0);
            command.Parameters.AddWithValue("@added", DateTime.Now);

            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                command.ExecuteNonQuery();
            }
            DatabaseAssist.ConnectToLexlets.Close();
        }

        private void SaveToCollectionContains()
        {
            List<int> SKU = new List<int>();
            string sql = "";
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();

            foreach (ComboBox combo in flowLayoutSKU.Controls)
            {
                SKU.Add(Convert.ToInt32(combo.SelectedItem));
            }

            for (int i = 0; i < SKU.Count; i++)
            {
                sql = "INSERT into tblCollectionContains VALUES (@collectionsku, @productsku)";
                command = new SqlCommand(sql, DatabaseAssist.ConnectToLexlets);
                command.Parameters.AddWithValue("@collectionsku", Convert.ToInt32(TxtSKU.Text));
                command.Parameters.AddWithValue("@productsku", SKU[i]);
                if (DatabaseAssist.ConnectToDatabase() == true)
                {
                    command.ExecuteNonQuery();
                }
                DatabaseAssist.ConnectToLexlets.Close();
            }
        }

        private int ValidateEntries()
        {
            int errors = 0;

            string checkSKU = "select SKU from tblProductData WHERE SKU =@param";

            if (DatabaseAssist.CheckIfItemExists(checkSKU, TxtSKU.Text) == true)
            {
                picErrorSKU.Visible = true;
                new ToolTip().SetToolTip(picErrorSKU, "SKU Already Exists, Please Try Another - The next aviable is : " + DatabaseAssist.GetLastSKU().ToString());
                errors++;
            }
            else
            {
                picErrorSKU.Visible = false;
            }

            if (Helper.CheckTextBoxForString(TxtDescription.Text) == "empty")
            {
                picErrorDescription.Visible = true;
                new ToolTip().SetToolTip(picErrorDescription, "Field Cannot Be Empty");
                errors++;
            }
            else
            {
                picErrorDescription.Visible = false;
            }

            if (Helper.CheckTextBoxForString(TxtCost.Text) != "number")
            {
                picErrorCost.Visible = true;
                new ToolTip().SetToolTip(picErrorCost, "Please enter a number");
                errors++;
            }
            else
            {
                picErrorCost.Visible = false;
            }

            if (Helper.CheckTextBoxForString(TxtPrice.Text) != "number")
            {
                picErrorPrice.Visible = true;
                new ToolTip().SetToolTip(picErrorPrice, "Please enter a number");
                errors++;
            }
            else
            {
                picErrorPrice.Visible = false;
            }

            if (Helper.CheckTextBoxForString(TxtPicPath.Text) == "empty")
            {
                lblAddImage.Visible = true;
                errors++;
            }
            else
            {
                lblAddImage.Visible = false;
            }

            return errors;
        }

        private void ClearRow()
        {

            foreach (ComboBox sku in flowLayoutSKU.Controls)
            {
                if (sku.Name == "cmbSku" + (rowCount - 1).ToString()) // Clears current Row
                {
                    flowLayoutSKU.Controls.Remove(sku);
                    sku.Dispose();
                }

                if (sku.Name == "cmbSku" + (rowCount - 2).ToString()) // Enables previous rows cmbsku for selection
                {
                    sku.Enabled = true;
                }
            }

            RemoveLabelFromCurrentRow(flowLayoutDescription, "lblDescription");
            RemoveLabelFromCurrentRow(flowLayoutCost, "lblCost");
            RemoveLabelFromCurrentRow(flowLayoutSellPrice, "lblSellPrice");
            rowCount--;
        }

        private void RemoveLabelFromCurrentRow(FlowLayoutPanel panel, string labelName)
        {
            foreach (Label lab in panel.Controls)
            {
                if (lab.Name == labelName + (rowCount - 1).ToString())
                {
                    panel.Controls.Remove(lab);
                    lab.Dispose();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ClearRow();
            btnDelete.Location = new Point(btnDelete.Location.X, btnDelete.Location.Y - 25);
            btnAddAnother.Location = new Point(btnAddAnother.Location.X, btnAddAnother.Location.Y - 25);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            BtnEdit.Visible = false;
            BtnDone.Visible = true;
            gbxProductDetails.Enabled = false;
            gbxMaterials.Enabled = true;
            btnAddAnother.Visible = true;
            btnDelete.Visible = true;
        }
       
    }
}

