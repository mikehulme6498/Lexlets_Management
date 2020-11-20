using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LexLetsManagement
{
    public partial class FrmRefund : Form
    {
        DataTable Refunds = new DataTable();
        Helper CurrentCustomer = new Helper();

        public FrmRefund()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //bgwGetCustomer.RunWorkerAsync();

            if (SearchForInvoice() == -1)
            {
                return;
            }
            pnlCustomer.Visible = true;
            GetInvoiceDetails();
            //progressBarLoading.Visible = false;
            if (GetQuantityOfProductsInInvoice() == 1) // Wont allow part refund if there is only 1 product in invoice
            {
                radPartRefund.Enabled = false;
            }
            BtnSave.Visible = true;
            button1.Visible = true;
            radFullRefund.Visible = true;
            radPartRefund.Visible = true;
            gbxReason.Visible = true;
            gbxType.Visible = true;
            pnlItems.Visible = true;
            gbxFullRefund.Visible = true;
            pnlDiscounts.Visible = true;
            BtnSave.Enabled = true;
        }

        private void bgwGetCustomer_ProcessChanged(object sender, ProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }     

        private void GetInvoiceDetails()
        {
            int posX = 51;
            int posY = 40;
            double discountPercent = 0;
            double discountGBP = 0;
            double adjustment = 0;
            string adjustmentComment = "";


            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlDataAdapter da = new SqlDataAdapter("Select tblInvoiceProducts.SKU, tblProductData.Description, tblInvoiceProducts.Size, tblInvoiceProducts.Quantity, tblInvoiceProducts.GiftBox, tblInvoiceProducts.SKUPrice FROM tblInvoiceProducts INNER JOIN tblProductData on tblProductData.SKU = tblInvoiceProducts.SKU WHERE tblInvoiceProducts.InvoiceNumber = @invoice", DatabaseAssist.ConnectToLexlets);
                da.SelectCommand.Parameters.AddWithValue("@invoice", txtInvoice.Text);
                SqlDataAdapter da2 = new SqlDataAdapter("Select * From tblInvoiceData where InvoiceNumber = @invoice", DatabaseAssist.ConnectToLexlets);
                da2.SelectCommand.Parameters.AddWithValue("@invoice", txtInvoice.Text);
                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();

                da.Fill(dt);
                da2.Fill(dt2);

                CurrentCustomer.PaymentMethod = (dt2.Rows[0]["PaymentMethod"].ToString());
                CurrentCustomer.Invoice = Convert.ToInt32(txtInvoice.Text);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int qty = Convert.ToInt16(dt.Rows[i]["Quantity"]);
                    CreateButton(i, "btnDelete", posX, posY);
                    CreateLabel(dt, i, "lblSku", "Sku", posX, posY);
                    CreateLabel(dt, i, "lblDesc", "Description", posX + 60, posY);
                    CreateLabel(dt, i, "lblSize", "Size", posX + 240, posY);
                    CreateLabel(dt, i, "lblPrice", "SKUPrice", posX + 305, posY);
                    CreateCombo(dt, i, "cmbQuantity", "Quantity", posX + 365, posY, qty);
                    CreateLabel(dt, i, "lblGift", "GiftBox", posX + 440, posY);
                    posY += 23;
                }

                CurrentCustomer.PostageTotal = Convert.ToDouble((dt2.Rows[0]["Shipping"]));
                lblPostage.Text = "£" + (dt2.Rows[0]["Shipping"].ToString());
                lblPost.Text = "£" + (dt2.Rows[0]["Shipping"].ToString());
                lblInvoiceTotal.Text = "£" + (dt2.Rows[0]["InvoiceTotal"].ToString());
                lblPaymentMethod.Text = "Payment Method : " + (dt2.Rows[0]["PaymentMethod"].ToString());
                lblDate.Text = "Sale Date : " + Convert.ToDateTime((dt2.Rows[0]["SaleDate"])).ToShortDateString();
                discountPercent = Convert.ToDouble(dt2.Rows[0]["DiscountPercent"]);
                discountGBP = Convert.ToDouble(dt2.Rows[0]["DiscountGBP"]);
                adjustment = Convert.ToDouble(dt2.Rows[0]["AddidtionalCost"]);
                adjustmentComment = (dt2.Rows[0]["CostComment"].ToString());

                if (discountPercent > 0)
                {
                    lblDiscount.Text = discountPercent.ToString() + "% Discount Applied";
                    lblDiscount.Visible = true;
                }

                if (discountGBP > 0)
                {
                    lblDiscount.Text = "£" + discountGBP.ToString() + " Discount Applied";
                    lblDiscount.Visible = true;
                }

                if (adjustment > 0)
                {
                    lblAdjustment.Text = "Price Adjustment of £" + adjustment.ToString() + " (Reason - " + adjustmentComment + ")";
                    lblAdjustment.Visible = true;
                }
                DatabaseAssist.ConnectToLexlets.Close();
                da.Dispose();
                dt.Dispose();
                da2.Dispose();
                dt2.Dispose();
            }
        }

        private void CreateButton(int count, string name, int x, int y)
        {
            Button button = new Button();
            button.Name = name + count.ToString();
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Location = new Point(x - 25, y);
            button.Size = new System.Drawing.Size(21, 21);
            button.Image = Properties.Resources.delete16x16;
            button.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            button.Click += new System.EventHandler(Button_Click);
            button.Tag = "Delete";
            new ToolTip().SetToolTip(button, button.Name);
            pnlItems.Controls.Add(button);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            int activeRow; // Gets row number from button click

            Button btn = (Button)sender;
            string name = btn.Name;
            name = name.Substring(name.Length - 1);
            activeRow = Convert.ToInt32(name);

            if (btn.Tag.ToString() == "Delete")
            {
                AddToArray(activeRow); // Also adds row it is deleting to datagridview ready to remove from database
                ChangeDeleteUndoIcon(activeRow);
                UpdatePartRefundTotals();
            }
            else // If tag is undo
            {
                dgvRefunds.Rows.RemoveAt(getRowIndex(activeRow));
                ChangeDeleteUndoIcon(activeRow);
                RemoveStrikeThrough(activeRow);
                UpdatePartRefundTotals();
            }
            pnlOptions.Visible = true;
        }

        private void RemoveStrikeThrough(int row)
        {
            foreach (Label Labels in pnlItems.Controls.OfType<Label>())
            {
                if (Labels.Name.EndsWith(row.ToString()))
                {
                    Labels.Enabled = true;
                    Labels.Font = new Font("Arial", 10, FontStyle.Regular);
                }
            }

            foreach (ComboBox combo in pnlItems.Controls.OfType<ComboBox>())
            {
                if (combo.Name.EndsWith(row.ToString()))
                {
                    combo.Enabled = true;
                    combo.Font = new Font("Arial", 10, FontStyle.Regular);
                }
            }
        }

        private int getRowIndex(int activeRow)
        {
            int rowIndex = -1;

            foreach (DataGridViewRow row in dgvRefunds.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(activeRow.ToString()))
                {
                    rowIndex = row.Index;
                    return rowIndex;
                }
            }
            return 0;
        }

        private void ChangeDeleteUndoIcon(int row)
        {
            foreach (Button but in pnlItems.Controls.OfType<Button>())
            {
                if (but.Name.EndsWith(row.ToString()))
                {
                    if (but.Tag.ToString() == "Delete")
                    {
                        but.Image = Properties.Resources.undo_16x16;
                        but.Tag = "Undo";
                        return;
                    }
                    else
                    {
                        but.Image = Properties.Resources.delete16x16;
                        but.Tag = "Delete";
                        return;
                    }
                }
            }
        }

        private int GetQuantityOfProductsInInvoice()
        {
            int total = 0;
            foreach (ComboBox combo in pnlItems.Controls.OfType<ComboBox>())
            {
                if (combo.Name.Contains("Quantity"))
                {
                    int qty = Convert.ToInt32(combo.SelectedItem);
                    total += qty;
                }
            }
            return total;
        }
        private void AddToArray(int row)
        {
            ArrayList rows = new ArrayList();

            rows = new ArrayList
            {
                row,
                txtInvoice.Text,
                GetLabelInfo(row, "Sku"),
                GetLabelInfo(row, "Desc"),
                GetLabelInfo(row, "Size"),
                GetLabelInfo(row, "Price"),
                GetComboInfo(row, "Quantity"), //one for original qty
                GetComboInfo(row, "Quantity"), //one to deduct 
                GetLabelInfo(row, "Gift"),
            };

            dgvRefunds.Rows.Add(rows.ToArray());
        }

        private string GetComboInfo(int row, string name)
        {
            string value = "";

            foreach (ComboBox combo in pnlItems.Controls.OfType<ComboBox>())
            {
                if (combo.Name.Contains(name) && combo.Name.EndsWith(row.ToString()))
                {
                    value = combo.SelectedItem.ToString();
                    combo.Enabled = false;
                    combo.Font = new Font("Arial", 10, FontStyle.Strikeout);
                    return value;
                }
            }
            return value;
        }

        private string GetLabelInfo(int row, string name)
        {
            string value = "";

            foreach (Label Labels in pnlItems.Controls.OfType<Label>())
            {
                if (Labels.Name.Contains(name) && Labels.Name.EndsWith(row.ToString()))
                {

                    value = Labels.Text;
                    Labels.Enabled = false;
                    Labels.Font = new Font("Arial", 10, FontStyle.Strikeout);
                    return value;
                }
            }
            return value;
        }

        private void CreateCombo(DataTable datatab, int count, string name, string column, int x, int y, int qty)
        {

            ComboBox combo = new ComboBox();
            combo.Name = name + count.ToString();
            combo.AutoSize = false;
            combo.Location = new Point(x, y);
            combo.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            combo.Font = new Font("Arial", 10, FontStyle.Regular);
            combo.ForeColor = Color.Black;
            combo.Width = 45;

            for (int i = 0; i < qty; i++)
            {
                combo.Items.Add(i + 1);
                combo.SelectedItem = (i + 1).ToString();
                combo.Text = (i + 1).ToString();
            }

            combo.Leave += Combo_Leave;
            pnlItems.Controls.Add(combo);
        }

        private void Combo_Leave(object sender, EventArgs e)
        {
            Helper.ValidateCombo(sender as ComboBox);
        }

        private void CreateLabel(DataTable datatab, int count, string name, string column, int x, int y)
        {

            Label lab = new Label();
            lab.Name = name + count.ToString();
            lab.AutoSize = false;
            lab.Location = new Point(x, y);
            lab.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            lab.Font = new Font("Arial", 10, FontStyle.Regular);
            lab.ForeColor = Color.Black;
            lab.TextAlign = ContentAlignment.MiddleCenter;
            lab.BorderStyle = BorderStyle.None;
            new ToolTip().SetToolTip(lab, lab.Name);

            if (column == "Description")
            {
                lab.Size = new System.Drawing.Size(170, 21);
            }
            else
            {
                lab.Size = new System.Drawing.Size(50, 21);
            }

            if (column == "SKUPrice")
            {
                lab.Text = "£" + (datatab.Rows[count][column].ToString());
            }
            else
            {
                lab.Text = (datatab.Rows[count][column].ToString());
            }
            pnlItems.Controls.Add(lab);

        }

        private int SearchForInvoice()
        {
            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * FROM tblInvoiceData WHERE InvoiceNumber = @invoice", DatabaseAssist.ConnectToLexlets);
                da.SelectCommand.Parameters.AddWithValue("@invoice", txtInvoice.Text);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    DatabaseAssist.ConnectToLexlets.Close();
                    MessageBox.Show("Invoice Does Not Exist", "Error");
                    txtInvoice.Text = "";
                    txtInvoice.Focus();
                    return -1;
                }
                else
                {
                    CurrentCustomer.CustomerID = Convert.ToInt32((dt.Rows[0]["CustomerId"]));

                    SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM tblCustomers WHERE CustomerID = @id", DatabaseAssist.ConnectToLexlets);
                    da2.SelectCommand.Parameters.AddWithValue("@id", CurrentCustomer.CustomerID);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);

                    lblName.Text = (dt2.Rows[0]["FirstName"].ToString() + " " + (dt2.Rows[0]["Surname"].ToString()));
                    lblAdd1.Text = (dt2.Rows[0]["Address1"].ToString());
                    lblAdd2.Text = (dt2.Rows[0]["Address2"].ToString());
                    lblPoscode.Text = (dt2.Rows[0]["Postcode"].ToString());
                    lblEmail.Text = (dt2.Rows[0]["Email"].ToString());
                    dt2.Dispose();
                    da2.Dispose();
                }
                DatabaseAssist.ConnectToLexlets.Close();

                dt.Dispose();
                da.Dispose();
            }
            return 0;
        }

        private void radPartRefund_CheckedChanged(object sender, EventArgs e)
        {
            gbxRefundAmount.Visible = true;
            gbxFullRefund.Visible = false;
            btnAddAdj.Visible = true;
            pnlItems.Enabled = true;            
        }

        private void radFullRefund_CheckedChanged(object sender, EventArgs e)
        {
            gbxRefundAmount.Visible = false;
            gbxFullRefund.Visible = true;
            btnAddAdj.Visible = false;
            pnlItems.Enabled = false;
            pnlOptions.Visible = false;
        }

        private void UpdatePartRefundTotals()
        {
            double price = 0;
            double giftBox = 0;
            string other = "0";
            double total = 0;
            double postage = 0;

            for (int i = 0; i < dgvRefunds.Rows.Count - 1; i++)
            {
                string tempPrice = dgvRefunds.Rows[i].Cells[5].Value.ToString();
                string giftName = dgvRefunds.Rows[i].Cells[8].Value.ToString();

                try
                {
                    price = Convert.ToDouble(Helper.RemovePoundSign(tempPrice)) * Convert.ToDouble(dgvRefunds.Rows[i].Cells[6].Value);
                    if (chkGift.Checked)
                    {
                        giftBox += Convert.ToDouble(GetGiftBoxPrice(giftName)) * Convert.ToDouble(dgvRefunds.Rows[i].Cells[6].Value);
                    }
                    else
                    {
                        giftBox = 0.00;
                    }
                    other = Helper.RemovePoundSign(lblOther.Text).ToString();

                }
                catch
                {
                    price = 0;
                    giftBox = 0;
                    total = 0;
                    postage = 0;
                }
            }

            if (chkPostage.Checked)
            {
                postage = CurrentCustomer.PostageTotal;
            }
            else
            {
                postage = 0.00;
            }
            total = price + giftBox + Convert.ToDouble(other) + postage;
            lblProducts.Text = "£" + price.ToString();
            lblGiftboxes.Text = "£" + giftBox.ToString();
            lblOther.Text = "£" + other.ToString();
            lblPost.Text = "£" + postage.ToString();
            lblRefundTotal.Text = "£" + total.ToString();
        }

        private string GetGiftBoxPrice(string giftname)
        {
            string price = "";

            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlDataAdapter da = new SqlDataAdapter("Select GiftBoxPrice FROM tblInvoiceProducts WHERE  GiftBox = @box", DatabaseAssist.ConnectToLexlets);
                da.SelectCommand.Parameters.AddWithValue("@box", giftname);
                DataTable dt = new DataTable();

                da.Fill(dt);
                price = (dt.Rows[0]["GiftBoxPrice"].ToString());
                DatabaseAssist.ConnectToLexlets.Close();
                da.Dispose();
                dt.Dispose();
            }
            return price;
        }
        private void btnRemoveAdj_Click(object sender, EventArgs e)
        {
            pnlAdjustment.Visible = false;
            btnRemoveAdj.Visible = false;
            btnAddAdj.Visible = true;
            lblOther.Text = "£0";
            UpdatePartRefundTotals();
        }

        private void btnAddDiscount_Click(object sender, EventArgs e)
        {
            if (Helper.CheckTextBoxForString(txtAdj.Text) != "number")
            {
                MessageBox.Show("Please Enter a number", "Invalid Charactor");
                picErrorAdj.Visible = true;
                return;
            }
            else
            {
                lblOther.Text = "£" + txtAdj.Text;
                UpdatePartRefundTotals();
                btnAddAdj.Visible = false;
                btnRemoveAdj.Visible = true;
                pnlAdjustment.Visible = false;
            }
        }

        private void btnAddAdj_Click(object sender, EventArgs e)
        {
            pnlAdjustment.Visible = true;
        }

        private void btcCancelDiscount_Click(object sender, EventArgs e)
        {
            pnlAdjustment.Visible = false;

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

            if (radPartRefund.Checked)
            {
                if (dgvRefunds.Rows.Count <= 1)
                {
                    MessageBox.Show("No Items Have Been Selected For Refund", "Error");
                    return;
                }
            }

            if (Helper.CheckTextBoxForString(txtReason.Text) == "empty")
            {
                MessageBox.Show("Please Enter A Reason", "Error");
                return;
            }

            /*if (QuantityLeftAfterPartRefund() == 0)
            {
                radFullRefund.Checked = true;
            } */

            if (radFullRefund.Checked)
            {
                CopyToRefundTable();
                RemoveFromInvoices();
                AddToOutgoings();
                AddToRefunds();
                UpdateStockFullRefund();
            }
            else if (radPartRefund.Checked)
            {
                CopyToRefundTable();
                AddToOutgoings();
                AddToRefunds();
                UpdateStockPartRefund();

            }
            User.AddToUserLog("Refund", User.Username + " Addded a refund " + "(" + txtInvoice + ") " + lblName.Text);
            MessageBox.Show("Invoice Refunded", "Success");
            this.Close();
        }

        private void RemoveFromInvoices()
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM tblInvoiceData WHERE InvoiceNumber = @invoice", DatabaseAssist.ConnectToLexlets);
            SqlCommand cmd2 = new SqlCommand("DELETE FROM tblInvoiceProducts WHERE InvoiceNumber = @invoice", DatabaseAssist.ConnectToLexlets);

            cmd.Parameters.AddWithValue("@invoice", CurrentCustomer.Invoice);
            cmd2.Parameters.AddWithValue("@invoice", CurrentCustomer.Invoice);

            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                DatabaseAssist.ConnectToLexlets.Close();

                cmd.Dispose();
                cmd2.Dispose();
            }
        }
        private void CopyToRefundTable()
        {
            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                if (radFullRefund.Checked == true)
                {
                    SqlCommand cmd = new SqlCommand("INSERT tblRefundedInvoiceData SELECT * FROM tblInvoiceData WHERE InvoiceNumber = @invoice", DatabaseAssist.ConnectToLexlets);
                    SqlCommand cmd2 = new SqlCommand("INSERT tblRefundedInvoiceProducts SELECT * FROM tblInvoiceProducts WHERE InvoiceNumber = @invoice", DatabaseAssist.ConnectToLexlets);

                    cmd.Parameters.AddWithValue("@invoice", CurrentCustomer.Invoice);
                    cmd2.Parameters.AddWithValue("@invoice", CurrentCustomer.Invoice);


                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    DatabaseAssist.ConnectToLexlets.Close();

                    cmd.Dispose();
                    cmd2.Dispose();
                }
                else if (radPartRefund.Checked == true)
                {

                    for (int i = 0; i < dgvRefunds.Rows.Count - 1; i++)
                    {
                        int invoice = (Convert.ToInt32(dgvRefunds.Rows[i].Cells[1].Value));
                        int sku = (Convert.ToInt16(dgvRefunds.Rows[i].Cells[2].Value));
                        int qtyToRemove = (Convert.ToInt16(dgvRefunds.Rows[i].Cells[7].Value));


                        int quantity = Convert.ToInt16(DatabaseAssist.GetOneCellValue("Select Quantity From tblInvoiceProducts " +
                                            "WHERE InvoiceNumber = @param AND SKU = @param2", invoice, sku, "Quantity"));
                        int quantityLeft = quantity - qtyToRemove;

                        SqlCommand cmd = new SqlCommand("INSERT INTO tblRefundedInvoiceProducts SELECT * FROM tblInvoiceProducts WHERE InvoiceNumber = @invoice AND SKU=@sku", DatabaseAssist.ConnectToLexlets);
                        cmd.Parameters.AddWithValue("@invoice", invoice);
                        cmd.Parameters.AddWithValue("@sku", sku);

                        SqlCommand cmd2 = new SqlCommand("INSERT tblRefundedInvoiceData SELECT * FROM tblInvoiceData WHERE InvoiceNumber = @invoice", DatabaseAssist.ConnectToLexlets);
                        cmd2.Parameters.AddWithValue("@invoice", invoice);
                        if (DatabaseAssist.ConnectToDatabase() == true)
                        {
                            cmd.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            DatabaseAssist.ConnectToLexlets.Close();


                            UpdateRow(invoice, sku, qtyToRemove); // Updates invoice by reducing the quantity sold

                            if (quantityLeft == 0)
                            {

                                RemoveRow(invoice, sku); // Removes row as there is none left
                            }
                        }
                    }
                }
            }
        }

        private void UpdateRow(int invoice, int sku, int qtyToRemove)
        {

            int quantity = Convert.ToInt16(DatabaseAssist.GetOneCellValue("Select Quantity From tblInvoiceProducts " +
                                        "WHERE InvoiceNumber = @param AND SKU = @param2", invoice, sku, "Quantity"));


            quantity -= qtyToRemove;
            UpdateInvoiceData(invoice);

            SqlCommand cmd = new SqlCommand("UPDATE tblInvoiceProducts set Quantity = @quantity WHERE InvoiceNumber =@invoice AND SKU =@sku", DatabaseAssist.ConnectToLexlets);
            SqlCommand cmd2 = new SqlCommand("UPDATE tblRefundedInvoiceProducts set Quantity = @quantity WHERE InvoiceNumber =@invoice AND SKU =@sku", DatabaseAssist.ConnectToLexlets);

            cmd.Parameters.AddWithValue("@invoice", invoice);
            cmd.Parameters.AddWithValue("@sku", sku);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd2.Parameters.AddWithValue("@invoice", invoice);
            cmd2.Parameters.AddWithValue("@sku", sku);
            cmd2.Parameters.AddWithValue("@quantity", qtyToRemove);
            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();

                cmd.Dispose();
                cmd2.Dispose();

                DatabaseAssist.ConnectToLexlets.Close();
            }
        }

        private void UpdateInvoiceData(int invoice)
        {

            double invoiceTotal = Convert.ToDouble(DatabaseAssist.GetOneCellValue("Select InvoiceTotal From tblInvoiceData " +
                                        "WHERE InvoiceNumber = @param", invoice, "InvoiceTotal"));
            double newPrice = invoiceTotal - Convert.ToDouble(Helper.RemovePoundSign(lblRefundTotal.Text));

            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlCommand cmd3 = new SqlCommand("UPDATE tblInvoiceData set InvoiceTotal = @price WHERE InvoiceNumber =@invoice", DatabaseAssist.ConnectToLexlets);
                cmd3.Parameters.AddWithValue("@invoice", invoice);
                cmd3.Parameters.AddWithValue("@price", newPrice);
                cmd3.ExecuteNonQuery();
                cmd3.Dispose();
                DatabaseAssist.ConnectToLexlets.Close();
            }
        }

        private void RemoveRow(int invoice, int sku)
        {
            SqlCommand cmd = new SqlCommand("DELETE From tblInvoiceProducts WHERE InvoiceNumber = @invoice AND SKU = @sku", DatabaseAssist.ConnectToLexlets);
            cmd.Parameters.AddWithValue("@invoice", invoice);
            cmd.Parameters.AddWithValue("@sku", sku);
            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                DatabaseAssist.ConnectToLexlets.Close();
            }
        }

        private void UpdateStockFullRefund()
        {
            List<int> SkuList = new List<int>();
            List<int> QtyList = new List<int>();
            List<string> Gift = new List<string>();


            foreach (Label Labels in pnlItems.Controls.OfType<Label>())
            {
                if (Labels.Name.Contains("Sku"))
                {
                    SkuList.Add(Convert.ToInt32(Labels.Text));
                }

                if (Labels.Name.Contains("Gift"))
                {
                    Gift.Add(Labels.Text);
                }
            }

            foreach (ComboBox qty in pnlItems.Controls.OfType<ComboBox>())
            {
                if (qty.Name.Contains("Quantity"))
                {
                    QtyList.Add(Convert.ToInt32(qty.SelectedItem));
                }
            }

            for (int i = 0; i < SkuList.Count; i++)
            {
                DatabaseAssist.UpdateMaterialQty(SkuList[i], QtyList[i], "Add");
                DatabaseAssist.UpdateProductQtySold(SkuList[i], QtyList[i], "Remove");

                if (Gift[i] != "No ")
                {
                    DatabaseAssist.UpdateGiftBoxes(Gift[i], QtyList[i], "Add");
                }
            }
        }
        private void UpdateStockPartRefund()
        {
            List<int> SkuList = new List<int>();
            List<int> QtyList = new List<int>();
            List<string> Gift = new List<string>();

            for (int i = 0; i < dgvRefunds.Rows.Count - 1; i++)
            {
                SkuList.Add((Convert.ToInt16(dgvRefunds.Rows[i].Cells[2].Value)));
                QtyList.Add((Convert.ToInt16(dgvRefunds.Rows[i].Cells[6].Value)));
                Gift.Add(dgvRefunds.Rows[i].Cells[8].Value.ToString());
            }

            for (int i = 0; i < SkuList.Count; i++)
            {
                DatabaseAssist.UpdateMaterialQty(SkuList[i], QtyList[i], "Add");
                DatabaseAssist.UpdateProductQtySold(SkuList[i], QtyList[i], "Remove");

                if (Gift[i] != "No " && chkGift.Checked == true)
                {
                    DatabaseAssist.UpdateGiftBoxes(Gift[i], QtyList[i], "Add");
                }
            }
        }
        public void AddToOutgoings()
        {
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";
            DateTime today = DateTime.Today;

            sql = "INSERT into tblOutgoing (Date, Category, Description, Amount, PaymentMethod) VALUES (@date, @category, @description, @amount, @method)";
            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                command = new SqlCommand(sql, DatabaseAssist.ConnectToLexlets);
                command.Parameters.AddWithValue("@date", today);
                command.Parameters.AddWithValue("@method", CurrentCustomer.PaymentMethod);

                if (radFullRefund.Checked)
                {
                    string description = "Invoice No: " + txtInvoice.Text + " - " + lblName.Text;
                    command.Parameters.AddWithValue("@description", description);
                    command.Parameters.AddWithValue("@category", "Full Refund");
                    command.Parameters.AddWithValue("@amount", Helper.RemovePoundSign(lblInvoiceTotal.Text));
                }
                else if (radPartRefund.Checked)
                {
                    string description = "Invoice No: " + txtInvoice.Text + " - " + lblName.Text;
                    command.Parameters.AddWithValue("@description", description);
                    command.Parameters.AddWithValue("@category", "Part Refund");
                    command.Parameters.AddWithValue("@amount", Helper.RemovePoundSign(lblRefundTotal.Text));
                }
                command.ExecuteNonQuery();
                DatabaseAssist.ConnectToLexlets.Close();
            }
        }

        public void AddToRefunds()
        {
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";
            DateTime today = DateTime.Today;

            sql = "INSERT into tblRefunds VALUES (@date, @custID, @invoice, @refundtype, @amount, @reason, @refundmethod)";
            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                command = new SqlCommand(sql, DatabaseAssist.ConnectToLexlets);
                command.Parameters.AddWithValue("@date", today);
                command.Parameters.AddWithValue("@custID", CurrentCustomer.CustomerID);
                command.Parameters.AddWithValue("@invoice", CurrentCustomer.Invoice);
                command.Parameters.AddWithValue("@reason", txtReason.Text);
                command.Parameters.AddWithValue("@refundmethod", CurrentCustomer.PaymentMethod);

                if (radFullRefund.Checked)
                {
                    command.Parameters.AddWithValue("@refundtype", "Full Refund");
                    command.Parameters.AddWithValue("@amount", Convert.ToDouble(Helper.RemovePoundSign(lblInvoiceTotal.Text)));
                }
                else if (radPartRefund.Checked)
                {
                    command.Parameters.AddWithValue("@refundtype", "Part Refund");
                    command.Parameters.AddWithValue("@amount", Convert.ToDouble(Helper.RemovePoundSign(lblRefundTotal.Text)));
                }
                command.ExecuteNonQuery();
                DatabaseAssist.ConnectToLexlets.Close();
            }
        }

        private void chkPostage_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePartRefundTotals();
        }

        private void chkGift_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePartRefundTotals();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
