using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net.Mail;
using System.Windows.Forms;


namespace LexLetsManagement
{
    public partial class FrmNewSale : Form
    {
        int rowCount = 1;
        double giftBoxPrice;
        Label[] lblDescription = new Label[20];
        double discountAmount = 0;
        Helper NewSale = new Helper();

        public FrmNewSale()
        {
            InitializeComponent();
        }

        private void FrmNewSale_Load(object sender, EventArgs e)
        {
            SetAutoTextForName();
            FillPaymentMethod();
            ShowHideProductPanels("hide");
            //CreateNewRow();
        }

        private void ShowHideProductPanels(string showOrHide)
        {
            showOrHide = showOrHide.ToUpper();
            bool showHide = false;

            if (showOrHide == "SHOW")
            {
                showHide = true;
            }
            else if (showOrHide == "HIDE")
            {
                showHide = false;
            }

            FlowLayoutDescription.Visible = showHide;
            FlowLayoutSize.Visible = showHide;
            FlowLayoutGift.Visible = showHide;
            FlowLayoutPrice.Visible = showHide;
            FlowLayoutQty.Visible = showHide;
            FlowLayoutSKU.Visible = showHide;
            FlowLayoutTotal.Visible = showHide;
        }
        private void SetAutoTextForName()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";
            AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();
            sql = "SELECT FirstName, Surname, Address1, Email FROM tblCustomers";
            SqlCommand command = new SqlCommand(sql, DatabaseAssist.ConnectToLexlets);
            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    autotext.Add(dr.GetString(0) + " " + dr.GetString(1) + " - " + dr.GetString(2) + " - " + dr.GetString(3));
                }
                TxtSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
                TxtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
                TxtSearch.AutoCompleteCustomSource = autotext;
                DatabaseAssist.ConnectToLexlets.Close();
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            // Autosearch show first name, last name and 1st line of address. This seperates the string and
            // places names into text box.
            try
            {
                var stringToSplit = TxtSearch.Text;
                var indexOfFirstSpace = stringToSplit.IndexOf(" ");
                var indexOfSecondSpace = stringToSplit.IndexOf(" ", indexOfFirstSpace + 1);
                var fName = stringToSplit.Substring(0, indexOfFirstSpace);
                var sName = stringToSplit.Substring(indexOfFirstSpace + 1, indexOfSecondSpace - indexOfFirstSpace - 1);
                TxtFName.Text = fName;
                TxtSName.Text = sName;
            }
            catch
            {
                TxtSearch.Focus();
            }
        }

        private void TxtSName_TextChanged(object sender, EventArgs e)
        {
            CheckIfCustomerExists(); // If customer exists it will load there ID number
        }

        public void CheckIfCustomerExists()
        {
            try
            {

                if (DatabaseAssist.ConnectToDatabase() == true)
                {
                    SqlCommand cmd = DatabaseAssist.ConnectToLexlets.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from tblCustomers WHERE FirstName =@fname AND Surname =@sname";
                    cmd.Parameters.AddWithValue("@fname", TxtFName.Text);
                    cmd.Parameters.AddWithValue("@sname", TxtSName.Text);
                    cmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        LblID.Visible = false;
                        TxtCusId.Visible = false;
                        TxtAdd1.Text = "";
                        TxtAdd2.Text = "";
                        TxtEmail.Text = "";
                        TxtPostcode.Text = "";
                        TxtCusId.Text = "";
                    }
                    else
                    {
                        LblID.Visible = true;
                        TxtCusId.Visible = true;
                        TxtSearch.Text = "";
                    }

                    foreach (DataRow dr in dt.Rows)
                    {
                        TxtAdd1.Text = dr["Address1"].ToString();
                        TxtAdd2.Text = dr["Address2"].ToString();
                        TxtPostcode.Text = dr["Postcode"].ToString();
                        TxtEmail.Text = dr["Email"].ToString();
                        TxtCusId.Text = dr["CustomerID"].ToString();
                    }
                    DatabaseAssist.ConnectToLexlets.Close();
                }
            }
            catch
            {
                // Empty, just prevents program from crashing when looping through
            }


        }

        private void TxtFName_TextChanged(object sender, EventArgs e)
        {
            CheckIfCustomerExists(); // Checks for existing user if name is being entered manually
        }

        public void GetActiveRowDescription(ComboBox comboSku)
        {
            try
            {
                if (DatabaseAssist.ConnectToDatabase() == true)
                {
                    SqlDataAdapter da = new SqlDataAdapter("Select Category, Description FROM tblProductData where SKU =@sku", DatabaseAssist.ConnectToLexlets);
                    da.SelectCommand.Parameters.AddWithValue("@sku", Convert.ToInt32(comboSku.SelectedItem));
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    foreach (Label lab in FlowLayoutDescription.Controls)
                    {
                        if (lab.Name == "lblDesc" + (rowCount - 1).ToString())
                        {

                            lab.Text = (dt.Rows[0]["Category"].ToString()) + " - " + (dt.Rows[0]["Description"].ToString());
                        }
                    }
                    DatabaseAssist.ConnectToLexlets.Close();
                    da.Dispose();
                    dt.Dispose();
                    dt.Clear();
                }
            }
            catch
            {
                MessageBox.Show("Please Select an SKU from dropdown", "Error");
            }
        }

        private void GetActiveRowPrice()
        {


            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlDataAdapter da = new SqlDataAdapter("Select SellPrice FROM tblProductData where SKU =@sku", DatabaseAssist.ConnectToLexlets);
                da.SelectCommand.Parameters.AddWithValue("@sku", GetActiveRowSKU());
                DataTable dt = new DataTable();

                da.Fill(dt);

                foreach (Label lab1 in FlowLayoutPrice.Controls)
                {
                    if (lab1.Name == "lblPrice" + (rowCount - 1).ToString())
                    {
                        double sizePrice = GetActiveRowSizeCost();
                        double sellPrice = Convert.ToDouble(dt.Rows[0]["SellPrice"]);
                        lab1.Text = "£" + (sizePrice + sellPrice);
                    }
                }
                DatabaseAssist.ConnectToLexlets.Close();
                da.Dispose();
                dt.Dispose();
            }
        }

        private int GetActiveRowSKU()
        {
            int sku = 0;

            foreach (ComboBox Sku in FlowLayoutSKU.Controls)
            {
                if (Sku.Name == "cmbSku" + (rowCount - 1).ToString())
                {
                    sku = Convert.ToInt32(Sku.SelectedItem);
                }
            }
            return sku;
        }


        public void FillPaymentMethod()
        {

            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlDataAdapter da = new SqlDataAdapter("Select MethodName FROM tblPaymentMethods", DatabaseAssist.ConnectToLexlets);
                DataTable dt = new DataTable();

                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CmbMethod.Items.Add(dt.Rows[i]["MethodName"]);
                }

                DatabaseAssist.ConnectToLexlets.Close();
                da.Dispose();
                dt.Dispose();
                dt.Clear();
            }
        }

        public void FillSkuCombo(ComboBox skuNum)
        {

            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlDataAdapter da = new SqlDataAdapter("Select SKU FROM tblProductData", DatabaseAssist.ConnectToLexlets);
                DataTable dt = new DataTable();

                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    skuNum.Items.Add(dt.Rows[i]["SKU"]);
                }

                DatabaseAssist.ConnectToLexlets.Close();
                da.Dispose();
                dt.Dispose();
                dt.Clear();
            }
        }


        private void CreateNewRow()
        {
            CreateSkuCombo();
            CreateDescriptionLabel();
            CreateSizeCombo();
            CreatePriceLabel();
            CreateQtyTextBox();
            CreateTotalLabel();
            CreateGiftCombo();
            rowCount++;
        }

        private void CreateSizeCombo()
        {
            ComboBox size = new ComboBox
            {
                Name = "cmbSize" + rowCount.ToString(),
                AutoSize = false,
                Size = new System.Drawing.Size(FlowLayoutSize.Width, 25)
            };
            size.SelectedIndexChanged += new System.EventHandler(Size_SelectedIndexChanged);
            size.Leave += new System.EventHandler(Size_Leave);
            size.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            size.Font = new Font("Arial", 7, FontStyle.Regular);
            size.ForeColor = Color.Black;
            size.Enabled = false;
            FlowLayoutSize.Controls.Add(size);
            BtnAddAnother.Location = new Point(25, size.Location.Y + 100);
            BtnDelete.Location = new Point(5, size.Location.Y + 60);
        }

        private void Size_Leave(object sender, EventArgs e)
        {
            Helper.ValidateCombo(sender as ComboBox);
        }

        private void Size_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetActiveRowPrice();
            UpdateActiveRowPrice();
        }

        private void FillSizeCombo(int id)
        {
            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlDataAdapter da = new SqlDataAdapter("Select Name, Cost FROM tblSizeOption Where ProductCategoryId = @id Order by name ASC", DatabaseAssist.ConnectToLexlets);
                da.SelectCommand.Parameters.AddWithValue("@id", id);
                DataTable dt = new DataTable();

                da.Fill(dt);

                foreach (ComboBox size in FlowLayoutSize.Controls)
                {
                    if (size.Name == "cmbSize" + (rowCount - 1).ToString())
                    {
                        size.Items.Clear();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            size.Items.Add(dt.Rows[i]["Name"] + " £" + (dt.Rows[i]["Cost"]));
                        }
                    }
                }
                DatabaseAssist.ConnectToLexlets.Close();
                da.Dispose();
                dt.Dispose();
                dt.Clear();
            }
        }

        private void CreateSkuCombo()
        {
            ComboBox sku = new ComboBox
            {
                Name = "cmbSku" + rowCount.ToString(),
                AutoSize = false,
                Size = new System.Drawing.Size(FlowLayoutSKU.Width, 25)
            };
            sku.SelectedIndexChanged += new System.EventHandler(Sku_SelectedIndexChanged);
            sku.Leave += new System.EventHandler(Sku_Leave);
            sku.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            sku.Font = new Font("Arial", 7, FontStyle.Regular);
            sku.ForeColor = Color.Black;
            FlowLayoutSKU.Controls.Add(sku);
            BtnAddAnother.Location = new Point(25, sku.Location.Y + 100);
            BtnDelete.Location = new Point(5, sku.Location.Y + 60);
            FillSkuCombo(sku);

        }

        private void Sku_Leave(object sender, EventArgs e)
        {
            ValidateCombo(sender as ComboBox);
        }

        private void ValidateCombo(ComboBox combo)
        {
            if (combo.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select from the drop down menu", "Invalid Selection");
                combo.Focus();
            }
        }

        private void CreateGiftCombo()
        {
            ComboBox gift = new ComboBox
            {
                Name = "cmbGift" + rowCount.ToString(),
                AutoSize = false,
                Size = new System.Drawing.Size(FlowLayoutGift.Width, 25),
                Margin = new System.Windows.Forms.Padding(0, 0, 0, 6),
                Font = new Font("Arial", 7, FontStyle.Regular),
                ForeColor = Color.Black
            };
            FlowLayoutGift.Controls.Add(gift);
            gift.Text = "No £0";
            gift.Enabled = false;
            gift.SelectedIndexChanged += new System.EventHandler(this.Gift_SelectedIndexChanged);
            gift.Leave += new System.EventHandler(Gift_Leave);
        }

        private void FillGiftCombo(int id)
        {

            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlDataAdapter da = new SqlDataAdapter("Select BoxName, Price FROM tblGiftBox Where ProductCatId = @id", DatabaseAssist.ConnectToLexlets);
                da.SelectCommand.Parameters.AddWithValue("id", id);
                DataTable dt = new DataTable();
                da.Fill(dt);
                giftBoxPrice = Convert.ToDouble((dt.Rows[0]["Price"]));

                foreach (ComboBox gift in FlowLayoutGift.Controls)
                {
                    if (gift.Name == "cmbGift" + (rowCount - 1).ToString())
                    {
                        gift.Items.Clear();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            gift.Items.Add(dt.Rows[i]["BoxName"] + " £" + dt.Rows[i]["Price"]);
                        }

                    }
                }
                DatabaseAssist.ConnectToLexlets.Close();
                da.Dispose();
                dt.Dispose();
                dt.Clear();
            }
        }

        private void Gift_Leave(object sender, EventArgs e)
        {
            ValidateCombo(sender as ComboBox);
        }

        private void Gift_SelectedIndexChanged(object sender, EventArgs e)
        {
            //AddGiftBoxToPrice(sender as ComboBox);
            UpdateActiveRowPrice();
            AddUpTotal();
        }

        private int GetActiveRowQuantity()
        {
            int quant = 0;
            foreach (TextBox qty in FlowLayoutQty.Controls)
            {
                if (qty.Name == "txtQuant" + (rowCount - 1).ToString())
                {
                    if (string.IsNullOrEmpty(qty.Text))
                    {
                        return 0;
                    }
                    else
                    {
                        quant = Convert.ToInt32(qty.Text);
                    }
                }
            }
            return quant;
        }

        private double GetActiveRowSizeCost()
        {
            double sizeCost = 0;

            foreach (ComboBox size in FlowLayoutSize.Controls)
            {
                if (size.Name == "cmbSize" + (rowCount - 1).ToString())
                {
                    if (string.IsNullOrEmpty(size.Text))
                    {
                        return 0;
                    }
                    else
                    {
                        string costToTrim = size.Text;
                        int trimPosition;
                        trimPosition = (costToTrim.IndexOf("£")) + 1;
                        costToTrim = costToTrim.Substring(trimPosition, costToTrim.Length - trimPosition);
                        sizeCost = Convert.ToDouble(costToTrim);
                    }
                }
            }
            return sizeCost;
        }

        private double GetActiveRowGiftBoxCost()
        {
            double giftCost = 0;

            foreach (ComboBox gift in FlowLayoutGift.Controls)
            {
                if (gift.Name == "cmbGift" + (rowCount - 1).ToString())
                {
                    if (string.IsNullOrEmpty(gift.Text))
                    {
                        return 0;
                    }
                    else
                    {
                        string costToTrim = gift.Text;
                        int trimPosition;
                        trimPosition = (costToTrim.IndexOf("£")) + 1;
                        costToTrim = costToTrim.Substring(trimPosition, costToTrim.Length - trimPosition);
                        giftCost = Convert.ToDouble(costToTrim);
                    }
                }
            }
            return giftCost;
        }

        private double GetActiveRowProductCost()
        {
            double productCost = 0;

            foreach (Label product in FlowLayoutPrice.Controls)
            {
                if (product.Name == "lblPrice" + (rowCount - 1).ToString())
                {
                    if (string.IsNullOrEmpty(product.Text))
                    {
                        return 0;
                    }
                    else
                    {
                        string costToTrim = product.Text;

                        costToTrim = costToTrim.Substring(1);
                        productCost = Convert.ToDouble(costToTrim);
                    }
                }
            }
            return productCost;
        }

        private void UpdateActiveRowPrice()
        {
            double newPrice = 0;

            foreach (Label total in FlowLayoutTotal.Controls) // Gets active rows total price
            {
                if (total.Name == "lblTotal" + (rowCount - 1).ToString())
                {
                    newPrice = (GetActiveRowProductCost() + GetActiveRowGiftBoxCost()) * GetActiveRowQuantity();
                    total.Text = "£" + newPrice.ToString();
                }
            }
        }
        private void CreateDescriptionLabel()
        {
            Label description = new Label
            {
                Name = "lblDesc" + rowCount.ToString(),
                BorderStyle = BorderStyle.FixedSingle,
                AutoSize = false,
                Font = new Font("Arial", 10, FontStyle.Regular),
                ForeColor = Color.Black,
                Size = new System.Drawing.Size(FlowLayoutDescription.Width, 21),
                Margin = new System.Windows.Forms.Padding(0, 0, 0, 5),
                TextAlign = ContentAlignment.TopCenter
            };
            description.BorderStyle = BorderStyle.None;
            FlowLayoutDescription.Controls.Add(description);
        }

        private void CreateTotalLabel()
        {
            Label total = new Label
            {
                Name = "lblTotal" + rowCount.ToString(),
                BorderStyle = BorderStyle.FixedSingle,
                AutoSize = false,
                Size = new System.Drawing.Size(FlowLayoutTotal.Width, 21),
                Font = new Font("Arial", 10, FontStyle.Regular),
                ForeColor = Color.Black,
                Margin = new System.Windows.Forms.Padding(0, 0, 0, 5),
                TextAlign = ContentAlignment.TopCenter
            };
            total.BorderStyle = BorderStyle.None;
            FlowLayoutTotal.Controls.Add(total);
        }

        private void CreatePriceLabel()
        {
            Label price = new Label
            {
                Name = "lblPrice" + rowCount.ToString(),
                BorderStyle = BorderStyle.FixedSingle,
                AutoSize = false,
                Size = new System.Drawing.Size(FlowLayoutPrice.Width, 21),
                Margin = new System.Windows.Forms.Padding(0, 0, 0, 5),
                Font = new Font("Arial", 10, FontStyle.Regular),
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.TopCenter
            };
            price.BorderStyle = BorderStyle.None;
            FlowLayoutPrice.Controls.Add(price);
        }

        private void CreateQtyTextBox()
        {
            TextBox quant = new TextBox
            {
                Name = "txtQuant" + rowCount.ToString(),
                BorderStyle = BorderStyle.FixedSingle
            };
            quant.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Quant_KeyUp);
            quant.AutoSize = false;
            quant.Size = new System.Drawing.Size(FlowLayoutQty.Width, 21);
            quant.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            quant.Font = new Font("Arial", 10, FontStyle.Regular);
            quant.ForeColor = Color.Black;
            quant.TextAlign = HorizontalAlignment.Center;
            quant.Enabled = false;
            FlowLayoutQty.Controls.Add(quant);

        }

        private void Quant_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (TextBox qty in FlowLayoutQty.Controls)
            {
                try
                {
                    if (qty.Name == "txtQuant" + (rowCount - 1).ToString())
                    {
                        Convert.ToInt32(qty.Text);
                    }
                }

                catch
                {
                    MessageBox.Show("Please Enter A Number", "Invalid Charactor");
                    return;
                }
                finally
                {
                    if (qty.Name == "txtQuant1")
                    {
                        if (!chkNotSale.Checked)
                        {
                            btnAddDisc.Visible = true;
                            btnAddCost.Visible = true;
                        }
                    }
                }
            }
            UpdateActiveRowPrice();
            EnableGiftBox();
            AddUpTotal();
            BtnAddAnother.Visible = true;
        }


        private void EnableGiftBox()
        {
            foreach (ComboBox gift in FlowLayoutGift.Controls)
            {
                if (gift.Name == "cmbGift" + (rowCount - 1).ToString())
                {
                    gift.Enabled = true;
                }
            }
        }

        private void EnableSize()
        {
            foreach (ComboBox size in FlowLayoutSize.Controls)
            {
                if (size.Name == "cmbSize" + (rowCount - 1).ToString())
                {
                    size.Enabled = true;
                }
            }
        }

        private void EnableQtyTextBox()
        {
            int tempCheck = rowCount - 1;

            foreach (TextBox qty in FlowLayoutQty.Controls)
            {
                if (qty.Name == "txtQuant" + tempCheck.ToString())
                {
                    qty.Enabled = true;
                }
            }
        }

        private void Sku_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = "";
            int id = -1;
            GetActiveRowDescription(sender as ComboBox);

            try
            {
                ComboBox cmbSku = (ComboBox)sender;

                if (DatabaseAssist.ConnectToDatabase() == true)
                {
                    SqlDataAdapter da = new SqlDataAdapter("Select Category FROM tblProductData Where SKU = @sku", DatabaseAssist.ConnectToLexlets);
                    da.SelectCommand.Parameters.AddWithValue("sku", Convert.ToInt32(cmbSku.SelectedItem));
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    category = (dt.Rows[0]["Category"]).ToString();
                    da.Dispose();
                    dt.Dispose();
                    SqlDataAdapter da2 = new SqlDataAdapter("Select ProductCategoryID From tblProductCategory Where ProductCategoryDescription =@desc", DatabaseAssist.ConnectToLexlets);
                    da2.SelectCommand.Parameters.AddWithValue("@desc", category);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    id = Convert.ToInt32((dt2.Rows[0]["ProductCategoryID"]));
                    dt2.Dispose();
                    da2.Dispose();
                    DatabaseAssist.ConnectToLexlets.Close();

                    FillGiftCombo(id);
                    FillSizeCombo(id);
                    EnableQtyTextBox();
                    EnableSize();
                }
            }
            catch
            {

            }
        }




        private void DisablePreviousRow()
        {
            int tempRow = rowCount - 2;

            foreach (ComboBox sku in FlowLayoutSKU.Controls)
            {
                if (sku.Name == "cmbSku" + tempRow)
                {
                    sku.Enabled = false;
                }
            }

            foreach (TextBox qty in FlowLayoutQty.Controls)
            {
                if (qty.Name == "txtQuant" + tempRow)
                {
                    qty.Enabled = false;
                }
            }

            foreach (ComboBox size in FlowLayoutSize.Controls)
            {
                if (size.Name == "cmbSize" + tempRow)
                {
                    size.Enabled = false;
                }
            }

            foreach (ComboBox gift in FlowLayoutGift.Controls)
            {
                if (gift.Name == "cmbGift" + tempRow)
                {
                    gift.Enabled = false;
                }
            }
        }

        private void BtnAddDisc_Click(object sender, EventArgs e)
        {
            if (rowCount == 11)
            {
                MessageBox.Show("Maximum Amount of Items Reached", "Limit Reached");
            }
            else
            {
                CreateNewRow();
                DisablePreviousRow();
                BtnAddAnother.Visible = false;
                BtnDelete.Visible = true;
            }
        }

        private double AddUpTotal()
        {
            double tempTotal = 0;
            string tot;
            string postageText;
            double postage;
            double fee;

            foreach (Label total in FlowLayoutTotal.Controls)
            {
                tot = total.Text;
                tot = tot.Substring(1);
                tempTotal = tempTotal + Convert.ToDouble(tot);
            }
            postageText = txtPostage.Text;
            postageText = postageText.Substring(1);
            postage = Convert.ToDouble(postageText);

            tempTotal = tempTotal + postage + GetAdjustmentsDiscounts();

            fee = ((NewSale.PaymentFeePercent / 100) * tempTotal) + NewSale.PaymentFeeGBP;
            fee = Math.Round(fee, 2);
            lblPaymentFee.Text = fee.ToString();
            lblInvoiceTotal.Text = "£" + tempTotal.ToString();
            return tempTotal;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (rowCount == 2)
            {
                MessageBox.Show("No Rows Left To Delete", "Error");
                btnAddDisc.Visible = false;
            }
            else
            {
                BtnDelete.Location = new Point(BtnDelete.Location.X, BtnDelete.Location.Y - 28);
                BtnAddAnother.Location = new Point(BtnAddAnother.Location.X, BtnAddAnother.Location.Y - 28);
                ClearRow();
                AddUpTotal();
            }
        }

        private void ClearRow()
        {
            int tempCount = rowCount - 1;

            foreach (ComboBox sku in FlowLayoutSKU.Controls)
            {
                if (sku.Name == "cmbSku" + (rowCount - 1).ToString()) // Clears current Row
                {
                    FlowLayoutSKU.Controls.Remove(sku);
                    sku.Dispose();
                }

                if (sku.Name == "cmbSku" + (rowCount - 2).ToString()) // Enables previous rows cmbsku for selection
                {
                    sku.Enabled = true;
                }
            }

            foreach (ComboBox gift in FlowLayoutGift.Controls)
            {
                if (gift.Name == "cmbGift" + (rowCount - 1).ToString())
                {
                    FlowLayoutGift.Controls.Remove(gift);
                    gift.Dispose();
                }
            }

            foreach (Label lab in FlowLayoutDescription.Controls)
            {
                if (lab.Name == "lblDesc" + (rowCount - 1).ToString())
                {

                    FlowLayoutDescription.Controls.Remove(lab);
                    lab.Dispose();
                }
            }

            foreach (ComboBox size in FlowLayoutSize.Controls)
            {
                if (size.Name == "cmbSize" + (rowCount - 1).ToString())
                {

                    FlowLayoutDescription.Controls.Remove(size);
                    size.Dispose();
                }
            }

            foreach (Label lab1 in FlowLayoutPrice.Controls)
            {
                if (lab1.Name == "lblPrice" + (rowCount - 1).ToString())
                {
                    FlowLayoutPrice.Controls.Remove(lab1);
                    lab1.Dispose();
                }
            }

            foreach (Label tot in FlowLayoutTotal.Controls)
            {
                if (tot.Name == "lblTotal" + (rowCount - 1).ToString())
                {
                    FlowLayoutTotal.Controls.Remove(tot);
                    tot.Dispose();
                }
            }

            foreach (TextBox qty in FlowLayoutQty.Controls)
            {
                if (qty.Name == "txtQuant" + (rowCount - 1).ToString())
                {
                    FlowLayoutQty.Controls.Remove(qty);
                    qty.Dispose();
                }
            }
            rowCount--;
        }



        private int SaveCustomer()
        {

            if (lblNewCustomer.Visible == true)
            {
                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();
                String sql = "";
                string sub = "No";

                sql = "INSERT into tblCustomers VALUES (@fname, @sname, @add1, @add2, @pcode, @email, @sub, @comment)";
                if (DatabaseAssist.ConnectToDatabase() == true)
                {
                    command = new SqlCommand(sql, DatabaseAssist.ConnectToLexlets);
                    command.Parameters.AddWithValue("@fname", TxtFName.Text);
                    command.Parameters.AddWithValue("@sname", TxtSName.Text);
                    command.Parameters.AddWithValue("@add1", TxtAdd1.Text);
                    command.Parameters.AddWithValue("@add2", TxtAdd2.Text);
                    command.Parameters.AddWithValue("@pcode", TxtPostcode.Text);
                    command.Parameters.AddWithValue("@email", TxtEmail.Text);
                    command.Parameters.AddWithValue("@sub", sub);
                    command.Parameters.AddWithValue("@comment", "");

                    int i = command.ExecuteNonQuery();
                    command.Dispose();
                    DatabaseAssist.ConnectToLexlets.Close();
                    return 1;
                }
                return 0;
            }
            return 0;
        }

        private void SaveInvoiceProducts()
        {

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();

            List<int> SKU = new List<int>();
            List<int> Quantity = new List<int>();
            List<double> Price = new List<double>();
            List<double> GiftPrice = new List<double>();
            List<string> Gift = new List<string>();
            List<string> Size = new List<string>();
            List<int> SKUForMaterialUpdate = new List<int>();
            List<int> QuantityForMaterialUpdate = new List<int>();


            // The 4 foreach loops add the info from dynamic controls to a list to update
            // database with multiple rows of SKU's

            foreach (ComboBox combo in FlowLayoutSKU.Controls)
            {
                SKU.Add(Convert.ToInt32(combo.SelectedItem));
            }

            foreach (TextBox qty in FlowLayoutQty.Controls)
            {
                Quantity.Add(Convert.ToInt32(qty.Text));
            }

            foreach (Label price in FlowLayoutPrice.Controls)
            {
                Price.Add(RemoveSignFromPrice(price));
            }

            foreach (ComboBox gift in FlowLayoutGift.Controls)
            {
                int index = 0;
                string giftName = gift.Text.ToString();
                index = giftName.IndexOf("£");
                giftName = giftName.Substring(0, index); //removes price from text
                Gift.Add(giftName);
            }

            foreach (ComboBox gift in FlowLayoutGift.Controls)
            {
                int index = 0;
                string giftPrice = gift.Text.ToString();
                index = giftPrice.IndexOf("£") + 1;
                //int indexSpace = gift.ProductName.IndexOf(" ",);
                giftPrice = giftPrice.Substring(index); //removes price from text
                GiftPrice.Add(Convert.ToDouble(giftPrice));
            }

            foreach (ComboBox size in FlowLayoutSize.Controls)
            {
                int index = 0;
                string sizing = size.Text.ToString();
                index = sizing.IndexOf("m") + 1;
                sizing = sizing.Substring(0, index); //removes all text apart from size
                Size.Add(sizing);
            }

            // creates a new list of sku's including product sku's from collections
            for (int i = 0; i < SKU.Count; i++)
            {

                if (DatabaseAssist.GetOneCellValue("SELECT Category FROM tblProductData WHERE SKU =@param", SKU[i], "Category") == "Collection")
                {
                    SqlDataAdapter da = new SqlDataAdapter("Select ProductSKU from tblCollectionContains where CollectionSKU= @sku", DatabaseAssist.ConnectToLexlets);
                    da.SelectCommand.Parameters.AddWithValue("@sku", SKU[i]);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        SKUForMaterialUpdate.Add(Convert.ToInt32((dt.Rows[j]["ProductSKU"])));
                        QuantityForMaterialUpdate.Add(Quantity[i]);
                    }
                }
                else
                {
                    SKUForMaterialUpdate.Add(SKU[i]);
                    QuantityForMaterialUpdate.Add(Quantity[i]);
                }
            }

            if (DatabaseAssist.ConnectToDatabase() == true)
            {

                for (int i = 0; i < SKU.Count; i++) //this was SKU.count
                {
                    if (chkNotSale.Checked == false)
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE tblProductData SET DateLastSold =@lastSold WHERE SKU = @sku", DatabaseAssist.ConnectToLexlets);
                        cmd.Parameters.AddWithValue("@lastSold", Convert.ToDateTime(dateTimePicker.Value.ToShortDateString()));
                        cmd.Parameters.AddWithValue("@sku", SKU[i]);
                        cmd.ExecuteNonQuery();


                        command = new SqlCommand("INSERT into tblInvoiceProducts VALUES (@invoicenum, @sku, @size, @quantity, @giftbox, @giftprice, @price)", DatabaseAssist.ConnectToLexlets);
                        command.Parameters.AddWithValue("@invoicenum", Convert.ToInt32(TxtInvoice.Text));
                        command.Parameters.AddWithValue("@sku", SKU[i]);
                        command.Parameters.AddWithValue("@size", Size[i]);
                        command.Parameters.AddWithValue("@quantity", Quantity[i]);
                        command.Parameters.AddWithValue("@giftprice", GiftPrice[i]);
                        command.Parameters.AddWithValue("@giftbox", Gift[i]);
                        command.Parameters.AddWithValue("@price", Price[i]);
                        command.ExecuteNonQuery();

                        UpdateProductQtySold(SKU[i], Quantity[i], DatabaseAssist.ConnectToLexlets);
                    }

                    if (Gift[i] != "No ")
                    {
                        DatabaseAssist.UpdateGiftBoxes(Gift[i], Quantity[i], "Remove");
                    }

                    if (chkAdjustMaterials.Checked == true && i == SKU.Count - 1) // will only do this loop on last iteration to prevent removing materials twice
                    {
                        for (int m = 0; m < SKUForMaterialUpdate.Count; m++)
                        {
                            DatabaseAssist.UpdateMaterialQty(SKUForMaterialUpdate[m], QuantityForMaterialUpdate[m], "Remove");
                        }
                    }
                }
            }
            DatabaseAssist.ConnectToLexlets.Close();
        }


        //private void UpdateMaterialQtyLeft(int sku, int quant, SqlConnection con)
        //{
        //    SqlCommand command;
        //    SqlDataAdapter adapter = new SqlDataAdapter();


        //    // Retrieve Qty in stock to update and insert back in
        //    SqlDataAdapter da = new SqlDataAdapter("Select * from tblProductContains where sku = @sku", con);
        //    da.SelectCommand.Parameters.AddWithValue("@sku", sku);
        //    DataTable dtProductContains = new DataTable();
        //    da.Fill(dtProductContains);

        //    for (int i = 1; i <= quant; i++) // loops though the amount of times product was sold
        //    {
        //        for (int j = 0; j < dtProductContains.Rows.Count; j++) // loops through each material and adjusts stock
        //        {
        //            int materialId = Convert.ToInt32(dtProductContains.Rows[j]["MaterialID"]);
        //            int materialQuant = Convert.ToInt32(dtProductContains.Rows[j]["MaterialQTY"]);
        //            int amountInStock = 0;

        //            // Retrieve Qty instock to asjust and insert back in
        //            SqlDataAdapter daGetQtyInStock = new SqlDataAdapter("Select QTYinStock from tblMaterials where MaterialId = @id", con);
        //            daGetQtyInStock.SelectCommand.Parameters.AddWithValue("@id", materialId);
        //            DataTable dtMaterials = new DataTable();
        //            daGetQtyInStock.Fill(dtMaterials);

        //            amountInStock = Convert.ToInt32((dtMaterials.Rows[0]["QTYinStock"]));
        //            amountInStock = amountInStock - materialQuant;

        //            command = new SqlCommand(@"UPDATE tblMaterials SET QTYinStock = @qty WHERE MaterialID = @id", con);
        //            command.Parameters.AddWithValue("@qty", amountInStock);
        //            command.Parameters.AddWithValue("@id", materialId);
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}

        private void UpdateProductQtySold(int sku, int quant, SqlConnection con)
        {
            int currentAmountSold;

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();


            // Retrieve Qty sold to update and insert back in
            SqlDataAdapter da = new SqlDataAdapter("Select QTYSold from tblProductData where sku = @sku", con);
            da.SelectCommand.Parameters.AddWithValue("@sku", sku);
            DataTable dt = new DataTable();
            da.Fill(dt);

            currentAmountSold = Convert.ToInt32((dt.Rows[0]["QTYSold"]));
            currentAmountSold = currentAmountSold + quant;


            command = new SqlCommand(@"UPDATE tblProductData SET QTYSold = @qtysold WHERE SKU = @sku", con);
            command.Parameters.AddWithValue("@qtysold", currentAmountSold);
            command.Parameters.AddWithValue("@sku", sku);
            command.ExecuteNonQuery();
        }

        private void SaveInvoiceData()
        {
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";
            double postageCost;

            postageCost = Convert.ToDouble(Helper.RemovePoundSign(txtPostage.Text));
            sql = "INSERT into tblInvoiceData VALUES (@invoicenum, @custid, @saledate, @shipping, @paymentmethod, @cost, @comment, @discountpercent, @discountgbp, @total, @fee)";
            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                command = new SqlCommand(sql, DatabaseAssist.ConnectToLexlets);

                command.Parameters.AddWithValue("@invoicenum", Convert.ToInt32(TxtInvoice.Text));
                command.Parameters.AddWithValue("@custid", Convert.ToInt32(TxtCusId.Text));
                command.Parameters.AddWithValue("@saledate", Convert.ToDateTime(dateTimePicker.Value.ToShortDateString()));
                command.Parameters.AddWithValue("@shipping", postageCost);
                command.Parameters.AddWithValue("@paymentmethod", CmbMethod.SelectedItem.ToString());
                command.Parameters.AddWithValue("@total", Convert.ToDouble(RemoveSignFromPrice(lblInvoiceTotal)));
                command.Parameters.AddWithValue("@fee", Convert.ToDouble(lblPaymentFee.Text));

                if (lblAdjustment.Visible == true)
                {
                    command.Parameters.AddWithValue("@cost", Convert.ToDouble(txtAdjustment.Text));
                    command.Parameters.AddWithValue("@comment", txtComment.Text);
                }
                else
                {
                    command.Parameters.AddWithValue("@cost", 0);
                    command.Parameters.AddWithValue("@comment", "");
                }
                // Checks to see if a discount has been applied.
                if (radioGBP.Checked == true && lblDiscountApplied.Visible == true)
                {
                    command.Parameters.AddWithValue("@discountpercent", "0");
                    command.Parameters.AddWithValue("@discountgbp", Convert.ToDouble(txtDiscount.Text));
                }
                else if (radioPercent.Checked == true && lblDiscountApplied.Visible == true)
                {
                    command.Parameters.AddWithValue("@discountpercent", Convert.ToDouble(txtDiscount.Text));
                    command.Parameters.AddWithValue("@discountgbp", "0");
                }
                else
                {
                    command.Parameters.AddWithValue("@discountpercent", "0");
                    command.Parameters.AddWithValue("@discountgbp", "0");
                }

                command.ExecuteNonQuery();
                command.Dispose();
                DatabaseAssist.ConnectToLexlets.Close();
            }
        }

        private void SaveSale()
        {

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";

            sql = "INSERT into tblSales VALUES (@customerid, @invoicenum)";
            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                command = new SqlCommand(sql, DatabaseAssist.ConnectToLexlets);
                command.Parameters.AddWithValue("@customerid", Convert.ToInt32(TxtCusId.Text));
                command.Parameters.AddWithValue("@invoicenum", Convert.ToInt32(TxtInvoice.Text));
                command.ExecuteNonQuery();
                DatabaseAssist.ConnectToLexlets.Close();
            }
        }

        private void AddToIncome()
        {

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";
            string description = "Invoice No: " + TxtInvoice.Text + " - " + TxtFName.Text + " " + TxtSName.Text;

            sql = "INSERT into tblincome (Date, Category, Description, Amount, PaymentMethod) VALUES (@date, @category, @description, @amount, @method)";
            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                command = new SqlCommand(sql, DatabaseAssist.ConnectToLexlets);
                command.Parameters.AddWithValue("@date", Convert.ToDateTime(dateTimePicker.Value.ToShortDateString()));
                command.Parameters.AddWithValue("@category", "Sale");
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@amount", (RemoveSignFromPrice(lblInvoiceTotal) - Convert.ToDouble(lblPaymentFee.Text)));
                command.Parameters.AddWithValue("@method", CmbMethod.Text);
                command.ExecuteNonQuery();
                DatabaseAssist.ConnectToLexlets.Close();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string name = TxtFName.Text + " " + TxtSName.Text;
            bool newCustomer = false;

            if (chkNotSale.Checked)
            {
                SaveInvoiceProducts();
                DialogResult result = MessageBox.Show("Not a sale, So only materials have been updated. Would you like to add another", "Success", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    ClearAll();
                    TxtSearch.Focus();
                }
                else
                {
                    this.Close();
                    return;
                }
            }

            if (SaveCustomer() == 1)
            {
                newCustomer = true;
            }

            //SaveSale();
            SaveInvoiceData();
            SaveInvoiceProducts(); // Also updates material and product stock
            AddToIncome();
            User.AddToUserLog("Add Sale", User.Username + " Added a new sale (" + TxtInvoice.Text + ") - " + TxtFName.Text + " " + TxtSName.Text);
            if (newCustomer == true)
            {
                DialogResult result =
                MessageBox.Show(name + " Has been added to the system and Sale has been Saved - Would you like to add another?", "Saved! Add another?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    this.Close();
                }
                else
                {
                    ClearAll();
                    TxtSearch.Focus();
                }
            }
            else if (newCustomer == false)
            {
                DialogResult result2 =
                MessageBox.Show("Sale Saved - Would you like to add another?", "Saved! Add another?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result2 == DialogResult.No)
                {
                    this.Close();
                }
                else
                {
                    ClearAll();
                    TxtSearch.Focus();
                }
            }
            SetAutoTextForName();

        }

        private void ClearAll()
        {
            foreach (Control c in GbxItems.Controls)
            {
                if (c.GetType() == typeof(System.Windows.Forms.FlowLayoutPanel))
                {
                    c.Controls.Clear();
                }
            }

            foreach (Control c in GbxCustomerDetails.Controls)
            {
                if (c.GetType() == typeof(System.Windows.Forms.TextBox))
                {
                    c.Text = "";
                }
            }

            CmbMethod.Text = "";
            BtnAddAnother.Visible = false;
            BtnDelete.Visible = false;
            txtAdjustment.Text = "";
            txtComment.Text = "";
            GbxItems.Enabled = false;
            GbxCustomerDetails.Enabled = true;
            BtnDone.Visible = true;
            btnEdit.Visible = false;
            lblInvoiceTotal.Text = "£0";
            lblAdjustment.Visible = false;
            lblDiscountApplied.Visible = false;
            lblNewCustomer.Visible = false;
            btnAddCost.Visible = false;
            btnRemoveCost.Visible = false;
            btnRemoveDiscount.Visible = false;
            btnAddDisc.Visible = false;
            GbxCustomerDetails.Visible = true;
            BtnDone.Enabled = false;
            chkNotSale.Checked = false;
            pnlLowerDetails.Visible = false;
            TxtSearch.Focus();
            rowCount = 1;
        }

        private void TxtPostage_Leave(object sender, EventArgs e) // Prevents a double ££ in postage label
        {
            string temp = txtPostage.Text;

            if (temp.StartsWith("£"))
            {
                return;
            }
            else
            {
                temp = "£" + temp;
                txtPostage.Text = temp;
            }
            AddUpTotal();
        }

        private void BtnAddDisc_Click_1(object sender, EventArgs e)
        {
            pnlDiscount.Visible = true;
            btnAddDisc.Visible = false;
            txtDiscount.Focus();
        }

        private double RemoveSignFromPrice(Label price)
        {
            double currentPrice = 0;
            string priceToConvert;
            priceToConvert = price.Text;
            priceToConvert = priceToConvert.Substring(1);
            currentPrice = Convert.ToDouble(priceToConvert);
            return currentPrice;
        }

        private void BtnAddDiscount_Click(object sender, EventArgs e)
        {
            double currentPrice = 0;
            double newPrice = 0;
            double postageCost = 0;

            currentPrice = Convert.ToDouble(Helper.RemovePoundSign(lblInvoiceTotal.Text));
            postageCost = Convert.ToDouble(Helper.RemovePoundSign(txtPostage.Text));

            if (radioGBP.Checked == false && radioPercent.Checked == false)
            {
                MessageBox.Show("Please Select A Discount Method");
                return;
            }

            if (radioGBP.Checked == true)
            {
                currentPrice = currentPrice - postageCost;
                discountAmount = Convert.ToDouble(txtDiscount.Text); // used to store discount amount incase user decides to remove discount
                currentPrice = (currentPrice - Convert.ToDouble(txtDiscount.Text));
                newPrice = currentPrice + postageCost;

                if (newPrice < 0)
                {
                    MessageBox.Show("Discount Cannot take Purchase Below Zero", "Far Too Much Discount");
                    return;
                }
                else
                {
                    //lblInvoiceTotal.Text = "£" + newPrice.ToString();
                    AddUpTotal();
                    lblDiscountApplied.Text = "£" + txtDiscount.Text + " Discount Applied";
                    lblDiscountApplied.Visible = true;
                }
            }

            if (radioPercent.Checked == true)
            {
                currentPrice = currentPrice - postageCost;
                discountAmount = ((Convert.ToDouble(txtDiscount.Text) / 100) * currentPrice);
                currentPrice = currentPrice - ((Convert.ToDouble(txtDiscount.Text) / 100) * currentPrice);
                newPrice = currentPrice + postageCost;

                if (newPrice < 0)
                {
                    MessageBox.Show("Discount Cannot take Purchase Below Zero", "Far Too Much Discount");
                    return;
                }
                else
                {
                    //lblInvoiceTotal.Text = "£" + newPrice.ToString();
                    AddUpTotal();
                    lblDiscountApplied.Text = txtDiscount.Text + "% Discount Applied";
                    lblDiscountApplied.Visible = true;
                }
            }
            btnRemoveDiscount.Visible = true;
            pnlDiscount.Visible = false;
        }

        private void BtnRemoveDiscount_Click(object sender, EventArgs e)
        {
            double currentPrice = 0;
            double newPrice = 0;
            double postageCost = 0;

            currentPrice = Convert.ToDouble(Helper.RemovePoundSign(lblInvoiceTotal.Text));
            postageCost = Convert.ToDouble(Helper.RemovePoundSign(txtPostage.Text));

            newPrice = ((currentPrice - postageCost) + discountAmount) + postageCost;
            discountAmount = 0;
            //lblInvoiceTotal.Text = "£"+newPrice.ToString();
            AddUpTotal();
            btnRemoveDiscount.Visible = false;
            btnAddDisc.Visible = true;
            lblDiscountApplied.Visible = false;
            radioGBP.Checked = false;
            radioPercent.Checked = false;
        }

        private void BtcCancelDiscount_Click(object sender, EventArgs e)
        {
            pnlDiscount.Visible = false;
            btnAddDisc.Visible = true;
        }

        private void BtnDone_Click(object sender, EventArgs e)
        {
            if (ValidateCustomerDetails() > 0)
            {
                MessageBox.Show("Please fix fields with errors", "Error");
                return;
            }
            else
            {
                if (TxtCusId.Visible == false)
                {
                    GetNewCustomerID();
                }
                if (rowCount == 1)
                {
                    CreateNewRow();
                }

                GbxItems.Enabled = true;
                GbxCustomerDetails.Enabled = false;
                btnEdit.Visible = true;
                BtnDone.Visible = false;
                ShowHideProductPanels("show");
                pnlLowerDetails.Visible = true;
            }
        }

        private void GetNewCustomerID()
        {
            int newID;

            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlDataAdapter da = new SqlDataAdapter("Select TOP 1 * FROM tblCustomers ORDER BY CustomerID DESC", DatabaseAssist.ConnectToLexlets);
                DataTable dt = new DataTable();

                da.Fill(dt);
                try
                {
                    newID = Convert.ToInt32(dt.Rows[0]["CustomerID"]);
                    newID++;
                }
                catch
                {
                    newID = 1;
                }
                DatabaseAssist.ConnectToLexlets.Close();
                TxtCusId.Text = newID.ToString();
                da.Dispose();
                dt.Dispose();

                TxtCusId.Visible = true;
                LblID.Visible = true;
                lblNewCustomer.Visible = true;
            }

        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            GbxItems.Enabled = false;
            GbxCustomerDetails.Enabled = true;
            btnEdit.Visible = false;
            BtnDone.Visible = true;
        }
        private int ValidateCustomerDetails()
        {
            TextBox[] textboxes = { TxtFName, TxtSName, TxtAdd1, TxtAdd2, TxtPostcode };
            PictureBox[] errorPic = { picErrorFName, picErrorSName, picErrorAdd1, picErrorAdd2, picErrorPost };
            int counterForErrorPic = 0;
            int errorCount = 0;

            // Check if text boxes are empty
            foreach (TextBox box in textboxes)
            {
                if (String.IsNullOrEmpty(box.Text))
                {
                    errorPic[counterForErrorPic].Visible = true;
                    new ToolTip().SetToolTip(errorPic[counterForErrorPic], "Field Cannot Be Empty");
                    errorCount++;
                }
                else
                {

                    new ToolTip().SetToolTip(errorPic[counterForErrorPic], "");
                    errorPic[counterForErrorPic].Visible = false;
                }

                counterForErrorPic++;
            }

            // Check if invoice exists or is empty
            if (CheckIfInvoiceExists() == true)
            {
                picErrorInvoiceNum.Visible = true;
                new ToolTip().SetToolTip(picErrorInvoiceNum, "Invoice Number Already Exists");
                errorCount++;
            }
            else if (String.IsNullOrEmpty(TxtInvoice.Text))
            {
                picErrorInvoiceNum.Visible = true;
                new ToolTip().SetToolTip(picErrorInvoiceNum, "Field Cannot Be Empty");
                errorCount++;
            }
            else
            {
                picErrorInvoiceNum.Visible = false;
            }

            // Check Email Address
            try
            {
                MailAddress m = new MailAddress(TxtEmail.Text);
                picErrorEmail.Visible = false;
            }
            catch
            {
                picErrorEmail.Visible = true;
                new ToolTip().SetToolTip(picErrorEmail, "Invalid Email Address");
                errorCount++;
            }

            // Check PaymentMethod

            if (CmbMethod.SelectedIndex == -1)
            {
                picErrorPayment.Visible = true;
                new ToolTip().SetToolTip(picErrorEmail, "Select Valid Payment Method");
                errorCount++;
            }
            else
            {
                picErrorPayment.Visible = false;
            }

            return errorCount;
        }


        private bool CheckIfInvoiceExists()
        {

            string invoice = TxtInvoice.Text;

            if (invoice.StartsWith("0"))
            {
                invoice = invoice.Substring(1);
            }

            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlCommand cmd = DatabaseAssist.ConnectToLexlets.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select InvoiceNumber from tblInvoiceData WHERE InvoiceNumber = @invoice";
                cmd.Parameters.AddWithValue("@invoice", invoice);
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
                DatabaseAssist.ConnectToLexlets.Close();

                if (dt.Rows.Count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private void CmbMethod_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlCommand cmd = DatabaseAssist.ConnectToLexlets.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select MethodId, FeePercent, FeeAmount from tblPaymentMethods WHERE MethodName = @name";
                cmd.Parameters.AddWithValue("@name", CmbMethod.SelectedItem.ToString());
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
                NewSale.PaymentFeePercent = Convert.ToDouble(dt.Rows[0]["FeePercent"]);
                NewSale.PaymentFeeGBP = Convert.ToDouble(dt.Rows[0]["FeeAmount"]);
                DatabaseAssist.ConnectToLexlets.Close();
                BtnDone.Enabled = true;
            }
        }
        private void LblInvoiceTotal_TextChanged(object sender, EventArgs e)
        {
            BtnSave.Enabled = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnAddCost_Click(object sender, EventArgs e)
        {
            pnlAdditionalCost.Visible = true;
            btnAddCost.Visible = false;
            txtAdjustment.Focus();
        }
        private void BtnCancelCosting_Click(object sender, EventArgs e)
        {
            pnlAdditionalCost.Visible = false;
            btnRemoveCost.Visible = false;
            btnAddCost.Visible = true;
        }
        private void BtnAddCosting_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAdjustment.Text) || (string.IsNullOrEmpty(txtComment.Text)))
            {
                MessageBox.Show("Please Enter Adjustment Price and Comment", "Error");
                txtAdjustment.Focus();
                return;
            }

            double adjustment = Convert.ToDouble(txtAdjustment.Text);
            AddUpTotal();
            pnlAdditionalCost.Visible = false;
            btnRemoveCost.Visible = true;
            lblAdjustment.Text = "Adjustment Of £" + adjustment.ToString() + " Added";
            lblAdjustment.Visible = true;
        }

        private double GetAdjustmentsDiscounts()
        {
            double sum, discount, adjustment;

            if (!string.IsNullOrEmpty(txtAdjustment.Text))
            {
                adjustment = Convert.ToDouble(Helper.RemovePoundSign(txtAdjustment.Text));
            }
            else
            {
                adjustment = 0;
            }

            if (!string.IsNullOrEmpty(txtDiscount.Text))
            {
                discount = 0 - discountAmount;
            }
            else
            {
                discount = 0;
            }

            sum = adjustment + discount;

            return sum;
        }
        private void BtnRemoveCost_Click(object sender, EventArgs e)
        {

            btnRemoveCost.Visible = false;
            btnAddCost.Visible = true;
            txtAdjustment.Text = "";
            txtComment.Text = "";
            lblAdjustment.Text = "";
            lblAdjustment.Visible = false;
            AddUpTotal();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        
        private void ChkNotSale_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNotSale.Checked)
            {
                GbxCustomerDetails.Visible = false;
                //BtnDone.Enabled = true;
                BtnDone.Visible = false;
                chkAdjustMaterials.Checked = true;
                chkAdjustMaterials.Enabled = false;
                pnlLowerDetails.Visible = true;
                CreateNewRow();
                ShowHideProductPanels("show");
                GbxItems.Enabled = true;
                pnlCostings.Visible = false;
                btnAddCost.Visible = false;
                btnAddDisc.Visible = false;
                chkNotSale.Enabled = false;
            }
            else
            {
                GbxCustomerDetails.Visible = true;
                BtnDone.Enabled = false;
            }
        }
    }
}
