namespace LexLetsManagement
{
    partial class FrmRefund
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtInvoice = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAdd1 = new System.Windows.Forms.Label();
            this.lblAdd2 = new System.Windows.Forms.Label();
            this.lblPoscode = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlCustomer = new System.Windows.Forms.Panel();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.bgwGetCustomer = new System.ComponentModel.BackgroundWorker();
            this.pnlItems = new System.Windows.Forms.Panel();
            this.lblsize = new System.Windows.Forms.Label();
            this.pnlDiscounts = new System.Windows.Forms.Panel();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblAdjustment = new System.Windows.Forms.Label();
            this.lblprice = new System.Windows.Forms.Label();
            this.lblsku = new System.Windows.Forms.Label();
            this.lblgift = new System.Windows.Forms.Label();
            this.lbldesc = new System.Windows.Forms.Label();
            this.lblqty = new System.Windows.Forms.Label();
            this.dgvRefunds = new System.Windows.Forms.DataGridView();
            this.Row = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Invoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyToRemove = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiftBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbxRefundAmount = new System.Windows.Forms.GroupBox();
            this.lblPost = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblRefundTotal = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblOther = new System.Windows.Forms.Label();
            this.lblGiftboxes = new System.Windows.Forms.Label();
            this.lblProducts = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPostage = new System.Windows.Forms.Label();
            this.lblInvoiceTotal = new System.Windows.Forms.Label();
            this.radFullRefund = new System.Windows.Forms.RadioButton();
            this.radPartRefund = new System.Windows.Forms.RadioButton();
            this.pnlAdjustment = new System.Windows.Forms.Panel();
            this.picErrorAdj = new System.Windows.Forms.PictureBox();
            this.txtAdj = new System.Windows.Forms.TextBox();
            this.btcCancelDiscount = new System.Windows.Forms.Button();
            this.btnAddDiscount = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.gbxType = new System.Windows.Forms.GroupBox();
            this.gbxFullRefund = new System.Windows.Forms.GroupBox();
            this.gbxReason = new System.Windows.Forms.GroupBox();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAddAdj = new System.Windows.Forms.Button();
            this.btnRemoveAdj = new System.Windows.Forms.Button();
            this.chkPostage = new System.Windows.Forms.CheckBox();
            this.chkGift = new System.Windows.Forms.CheckBox();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.pnlCustomer.SuspendLayout();
            this.pnlItems.SuspendLayout();
            this.pnlDiscounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefunds)).BeginInit();
            this.gbxRefundAmount.SuspendLayout();
            this.pnlAdjustment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picErrorAdj)).BeginInit();
            this.gbxType.SuspendLayout();
            this.gbxFullRefund.SuspendLayout();
            this.gbxReason.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Invoice Number";
            // 
            // txtInvoice
            // 
            this.txtInvoice.Location = new System.Drawing.Point(131, 20);
            this.txtInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Size = new System.Drawing.Size(100, 23);
            this.txtInvoice.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(29, 0);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(133, 22);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAdd1
            // 
            this.lblAdd1.Location = new System.Drawing.Point(21, 40);
            this.lblAdd1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAdd1.Name = "lblAdd1";
            this.lblAdd1.Size = new System.Drawing.Size(141, 15);
            this.lblAdd1.TabIndex = 4;
            this.lblAdd1.Text = "Address 1";
            this.lblAdd1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAdd2
            // 
            this.lblAdd2.Location = new System.Drawing.Point(21, 24);
            this.lblAdd2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAdd2.Name = "lblAdd2";
            this.lblAdd2.Size = new System.Drawing.Size(141, 15);
            this.lblAdd2.TabIndex = 5;
            this.lblAdd2.Text = "Address 2";
            this.lblAdd2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPoscode
            // 
            this.lblPoscode.Location = new System.Drawing.Point(21, 55);
            this.lblPoscode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPoscode.Name = "lblPoscode";
            this.lblPoscode.Size = new System.Drawing.Size(141, 15);
            this.lblPoscode.TabIndex = 6;
            this.lblPoscode.Text = "Postcode";
            this.lblPoscode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(21, 70);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(141, 15);
            this.lblEmail.TabIndex = 7;
            this.lblEmail.Text = "Email";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(235, 20);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(76, 24);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlCustomer
            // 
            this.pnlCustomer.Controls.Add(this.lblPaymentMethod);
            this.pnlCustomer.Controls.Add(this.lblDate);
            this.pnlCustomer.Controls.Add(this.lblName);
            this.pnlCustomer.Controls.Add(this.lblAdd1);
            this.pnlCustomer.Controls.Add(this.lblEmail);
            this.pnlCustomer.Controls.Add(this.lblAdd2);
            this.pnlCustomer.Controls.Add(this.lblPoscode);
            this.pnlCustomer.Location = new System.Drawing.Point(339, 5);
            this.pnlCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.pnlCustomer.Name = "pnlCustomer";
            this.pnlCustomer.Size = new System.Drawing.Size(170, 129);
            this.pnlCustomer.TabIndex = 9;
            this.pnlCustomer.Visible = false;
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.Location = new System.Drawing.Point(21, 101);
            this.lblPaymentMethod.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(141, 15);
            this.lblPaymentMethod.TabIndex = 9;
            this.lblPaymentMethod.Text = "Payment Method";
            this.lblPaymentMethod.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(21, 86);
            this.lblDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(141, 15);
            this.lblDate.TabIndex = 8;
            this.lblDate.Text = "Date";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlItems
            // 
            this.pnlItems.Controls.Add(this.lblsize);
            this.pnlItems.Controls.Add(this.pnlDiscounts);
            this.pnlItems.Controls.Add(this.lblprice);
            this.pnlItems.Controls.Add(this.lblsku);
            this.pnlItems.Controls.Add(this.lblgift);
            this.pnlItems.Controls.Add(this.lbldesc);
            this.pnlItems.Controls.Add(this.lblqty);
            this.pnlItems.Enabled = false;
            this.pnlItems.Location = new System.Drawing.Point(23, 138);
            this.pnlItems.Margin = new System.Windows.Forms.Padding(2);
            this.pnlItems.Name = "pnlItems";
            this.pnlItems.Size = new System.Drawing.Size(485, 193);
            this.pnlItems.TabIndex = 11;
            this.pnlItems.Visible = false;
            // 
            // lblsize
            // 
            this.lblsize.AutoSize = true;
            this.lblsize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsize.Location = new System.Drawing.Point(221, 9);
            this.lblsize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblsize.Name = "lblsize";
            this.lblsize.Size = new System.Drawing.Size(55, 25);
            this.lblsize.TabIndex = 18;
            this.lblsize.Text = "Size";
            // 
            // pnlDiscounts
            // 
            this.pnlDiscounts.Controls.Add(this.lblDiscount);
            this.pnlDiscounts.Controls.Add(this.lblAdjustment);
            this.pnlDiscounts.Location = new System.Drawing.Point(2, 151);
            this.pnlDiscounts.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDiscounts.Name = "pnlDiscounts";
            this.pnlDiscounts.Size = new System.Drawing.Size(462, 40);
            this.pnlDiscounts.TabIndex = 47;
            this.pnlDiscounts.Visible = false;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.ForeColor = System.Drawing.Color.Red;
            this.lblDiscount.Location = new System.Drawing.Point(7, 7);
            this.lblDiscount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(63, 17);
            this.lblDiscount.TabIndex = 40;
            this.lblDiscount.Text = "Discount";
            this.lblDiscount.Visible = false;
            // 
            // lblAdjustment
            // 
            this.lblAdjustment.AutoSize = true;
            this.lblAdjustment.ForeColor = System.Drawing.Color.Red;
            this.lblAdjustment.Location = new System.Drawing.Point(7, 21);
            this.lblAdjustment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAdjustment.Name = "lblAdjustment";
            this.lblAdjustment.Size = new System.Drawing.Size(78, 17);
            this.lblAdjustment.TabIndex = 41;
            this.lblAdjustment.Text = "Adjustment";
            this.lblAdjustment.Visible = false;
            // 
            // lblprice
            // 
            this.lblprice.AutoSize = true;
            this.lblprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprice.Location = new System.Drawing.Point(269, 9);
            this.lblprice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblprice.Name = "lblprice";
            this.lblprice.Size = new System.Drawing.Size(61, 25);
            this.lblprice.TabIndex = 17;
            this.lblprice.Text = "Price";
            // 
            // lblsku
            // 
            this.lblsku.AutoSize = true;
            this.lblsku.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsku.Location = new System.Drawing.Point(34, 9);
            this.lblsku.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblsku.Name = "lblsku";
            this.lblsku.Size = new System.Drawing.Size(57, 25);
            this.lblsku.TabIndex = 13;
            this.lblsku.Text = "SKU";
            // 
            // lblgift
            // 
            this.lblgift.AutoSize = true;
            this.lblgift.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblgift.Location = new System.Drawing.Point(357, 9);
            this.lblgift.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblgift.Name = "lblgift";
            this.lblgift.Size = new System.Drawing.Size(88, 25);
            this.lblgift.TabIndex = 16;
            this.lblgift.Text = "Gift Box";
            // 
            // lbldesc
            // 
            this.lbldesc.AutoSize = true;
            this.lbldesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldesc.Location = new System.Drawing.Point(108, 9);
            this.lbldesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbldesc.Name = "lbldesc";
            this.lbldesc.Size = new System.Drawing.Size(120, 25);
            this.lbldesc.TabIndex = 14;
            this.lbldesc.Text = "Description";
            // 
            // lblqty
            // 
            this.lblqty.AutoSize = true;
            this.lblqty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblqty.Location = new System.Drawing.Point(318, 9);
            this.lblqty.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblqty.Name = "lblqty";
            this.lblqty.Size = new System.Drawing.Size(46, 25);
            this.lblqty.TabIndex = 15;
            this.lblqty.Text = "Qty";
            // 
            // dgvRefunds
            // 
            this.dgvRefunds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRefunds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Row,
            this.Invoice,
            this.SKU,
            this.Description,
            this.Size,
            this.Price,
            this.Qty,
            this.QtyToRemove,
            this.GiftBox});
            this.dgvRefunds.Location = new System.Drawing.Point(562, 34);
            this.dgvRefunds.Margin = new System.Windows.Forms.Padding(2);
            this.dgvRefunds.Name = "dgvRefunds";
            this.dgvRefunds.RowHeadersWidth = 51;
            this.dgvRefunds.Size = new System.Drawing.Size(105, 75);
            this.dgvRefunds.TabIndex = 12;
            this.dgvRefunds.Visible = false;
            // 
            // Row
            // 
            this.Row.HeaderText = "Row";
            this.Row.MinimumWidth = 6;
            this.Row.Name = "Row";
            this.Row.Width = 50;
            // 
            // Invoice
            // 
            this.Invoice.HeaderText = "Invoice No";
            this.Invoice.MinimumWidth = 6;
            this.Invoice.Name = "Invoice";
            this.Invoice.Width = 80;
            // 
            // SKU
            // 
            this.SKU.HeaderText = "SKU";
            this.SKU.MinimumWidth = 6;
            this.SKU.Name = "SKU";
            this.SKU.Width = 50;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.Width = 125;
            // 
            // Size
            // 
            this.Size.HeaderText = "Size";
            this.Size.MinimumWidth = 6;
            this.Size.Name = "Size";
            this.Size.Width = 50;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.Width = 50;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.MinimumWidth = 6;
            this.Qty.Name = "Qty";
            this.Qty.Width = 50;
            // 
            // QtyToRemove
            // 
            this.QtyToRemove.HeaderText = "QtyToRemove";
            this.QtyToRemove.MinimumWidth = 6;
            this.QtyToRemove.Name = "QtyToRemove";
            this.QtyToRemove.Width = 125;
            // 
            // GiftBox
            // 
            this.GiftBox.HeaderText = "Gift Box";
            this.GiftBox.MinimumWidth = 6;
            this.GiftBox.Name = "GiftBox";
            this.GiftBox.Width = 50;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkOrange;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(396, 531);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 29);
            this.button1.TabIndex = 31;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.Chartreuse;
            this.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSave.Enabled = false;
            this.BtnSave.Location = new System.Drawing.Point(471, 531);
            this.BtnSave.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(77, 29);
            this.BtnSave.TabIndex = 30;
            this.BtnSave.Text = "Refund";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Visible = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(44, 25);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 20);
            this.label13.TabIndex = 33;
            this.label13.Text = "Postage";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(4, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "Refund Amount";
            // 
            // gbxRefundAmount
            // 
            this.gbxRefundAmount.Controls.Add(this.lblPost);
            this.gbxRefundAmount.Controls.Add(this.label8);
            this.gbxRefundAmount.Controls.Add(this.lblRefundTotal);
            this.gbxRefundAmount.Controls.Add(this.label10);
            this.gbxRefundAmount.Controls.Add(this.lblOther);
            this.gbxRefundAmount.Controls.Add(this.lblGiftboxes);
            this.gbxRefundAmount.Controls.Add(this.lblProducts);
            this.gbxRefundAmount.Controls.Add(this.label5);
            this.gbxRefundAmount.Controls.Add(this.label4);
            this.gbxRefundAmount.Controls.Add(this.label3);
            this.gbxRefundAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxRefundAmount.ForeColor = System.Drawing.Color.SteelBlue;
            this.gbxRefundAmount.Location = new System.Drawing.Point(23, 404);
            this.gbxRefundAmount.Margin = new System.Windows.Forms.Padding(2);
            this.gbxRefundAmount.Name = "gbxRefundAmount";
            this.gbxRefundAmount.Padding = new System.Windows.Forms.Padding(2);
            this.gbxRefundAmount.Size = new System.Drawing.Size(222, 156);
            this.gbxRefundAmount.TabIndex = 35;
            this.gbxRefundAmount.TabStop = false;
            this.gbxRefundAmount.Text = "Amount To Be Refunded";
            this.gbxRefundAmount.Visible = false;
            // 
            // lblPost
            // 
            this.lblPost.AutoSize = true;
            this.lblPost.ForeColor = System.Drawing.Color.Black;
            this.lblPost.Location = new System.Drawing.Point(78, 97);
            this.lblPost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPost.Name = "lblPost";
            this.lblPost.Size = new System.Drawing.Size(18, 20);
            this.lblPost.TabIndex = 9;
            this.lblPost.Text = "£";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(10, 96);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "Postage";
            // 
            // lblRefundTotal
            // 
            this.lblRefundTotal.AutoSize = true;
            this.lblRefundTotal.ForeColor = System.Drawing.Color.Black;
            this.lblRefundTotal.Location = new System.Drawing.Point(78, 118);
            this.lblRefundTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRefundTotal.Name = "lblRefundTotal";
            this.lblRefundTotal.Size = new System.Drawing.Size(18, 20);
            this.lblRefundTotal.TabIndex = 7;
            this.lblRefundTotal.Text = "£";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(26, 117);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 20);
            this.label10.TabIndex = 6;
            this.label10.Text = "Total";
            // 
            // lblOther
            // 
            this.lblOther.AutoSize = true;
            this.lblOther.ForeColor = System.Drawing.Color.Black;
            this.lblOther.Location = new System.Drawing.Point(78, 76);
            this.lblOther.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOther.Name = "lblOther";
            this.lblOther.Size = new System.Drawing.Size(18, 20);
            this.lblOther.TabIndex = 5;
            this.lblOther.Text = "£";
            // 
            // lblGiftboxes
            // 
            this.lblGiftboxes.AutoSize = true;
            this.lblGiftboxes.ForeColor = System.Drawing.Color.Black;
            this.lblGiftboxes.Location = new System.Drawing.Point(78, 55);
            this.lblGiftboxes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGiftboxes.Name = "lblGiftboxes";
            this.lblGiftboxes.Size = new System.Drawing.Size(18, 20);
            this.lblGiftboxes.TabIndex = 4;
            this.lblGiftboxes.Text = "£";
            // 
            // lblProducts
            // 
            this.lblProducts.AutoSize = true;
            this.lblProducts.ForeColor = System.Drawing.Color.Black;
            this.lblProducts.Location = new System.Drawing.Point(78, 35);
            this.lblProducts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(18, 20);
            this.lblProducts.TabIndex = 3;
            this.lblProducts.Text = "£";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(25, 76);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Other";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(15, 55);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Gift Box";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(9, 35);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Products";
            // 
            // lblPostage
            // 
            this.lblPostage.AutoSize = true;
            this.lblPostage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostage.ForeColor = System.Drawing.Color.Black;
            this.lblPostage.Location = new System.Drawing.Point(108, 25);
            this.lblPostage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPostage.Name = "lblPostage";
            this.lblPostage.Size = new System.Drawing.Size(18, 20);
            this.lblPostage.TabIndex = 36;
            this.lblPostage.Text = "£";
            // 
            // lblInvoiceTotal
            // 
            this.lblInvoiceTotal.AutoSize = true;
            this.lblInvoiceTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceTotal.ForeColor = System.Drawing.Color.Black;
            this.lblInvoiceTotal.Location = new System.Drawing.Point(108, 47);
            this.lblInvoiceTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInvoiceTotal.Name = "lblInvoiceTotal";
            this.lblInvoiceTotal.Size = new System.Drawing.Size(18, 20);
            this.lblInvoiceTotal.TabIndex = 37;
            this.lblInvoiceTotal.Text = "£";
            // 
            // radFullRefund
            // 
            this.radFullRefund.AutoSize = true;
            this.radFullRefund.Checked = true;
            this.radFullRefund.ForeColor = System.Drawing.Color.Black;
            this.radFullRefund.Location = new System.Drawing.Point(13, 18);
            this.radFullRefund.Margin = new System.Windows.Forms.Padding(2);
            this.radFullRefund.Name = "radFullRefund";
            this.radFullRefund.Size = new System.Drawing.Size(101, 21);
            this.radFullRefund.TabIndex = 38;
            this.radFullRefund.TabStop = true;
            this.radFullRefund.Text = "Full Refund";
            this.radFullRefund.UseVisualStyleBackColor = true;
            this.radFullRefund.Visible = false;
            this.radFullRefund.CheckedChanged += new System.EventHandler(this.radFullRefund_CheckedChanged);
            // 
            // radPartRefund
            // 
            this.radPartRefund.AutoSize = true;
            this.radPartRefund.ForeColor = System.Drawing.Color.Black;
            this.radPartRefund.Location = new System.Drawing.Point(95, 18);
            this.radPartRefund.Margin = new System.Windows.Forms.Padding(2);
            this.radPartRefund.Name = "radPartRefund";
            this.radPartRefund.Size = new System.Drawing.Size(105, 21);
            this.radPartRefund.TabIndex = 39;
            this.radPartRefund.Text = "Part Refund";
            this.radPartRefund.UseVisualStyleBackColor = true;
            this.radPartRefund.Visible = false;
            this.radPartRefund.CheckedChanged += new System.EventHandler(this.radPartRefund_CheckedChanged);
            // 
            // pnlAdjustment
            // 
            this.pnlAdjustment.Controls.Add(this.picErrorAdj);
            this.pnlAdjustment.Controls.Add(this.txtAdj);
            this.pnlAdjustment.Controls.Add(this.btcCancelDiscount);
            this.pnlAdjustment.Controls.Add(this.btnAddDiscount);
            this.pnlAdjustment.Controls.Add(this.label6);
            this.pnlAdjustment.Location = new System.Drawing.Point(255, 486);
            this.pnlAdjustment.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAdjustment.Name = "pnlAdjustment";
            this.pnlAdjustment.Size = new System.Drawing.Size(116, 66);
            this.pnlAdjustment.TabIndex = 42;
            this.pnlAdjustment.Visible = false;
            // 
            // picErrorAdj
            // 
            this.picErrorAdj.Cursor = System.Windows.Forms.Cursors.Help;
            this.picErrorAdj.Image = global::LexLetsManagement.Properties.Resources.Error;
            this.picErrorAdj.Location = new System.Drawing.Point(75, 24);
            this.picErrorAdj.Margin = new System.Windows.Forms.Padding(2);
            this.picErrorAdj.Name = "picErrorAdj";
            this.picErrorAdj.Size = new System.Drawing.Size(10, 11);
            this.picErrorAdj.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picErrorAdj.TabIndex = 40;
            this.picErrorAdj.TabStop = false;
            this.picErrorAdj.Tag = "";
            this.picErrorAdj.Visible = false;
            // 
            // txtAdj
            // 
            this.txtAdj.Location = new System.Drawing.Point(28, 21);
            this.txtAdj.Margin = new System.Windows.Forms.Padding(2);
            this.txtAdj.Name = "txtAdj";
            this.txtAdj.Size = new System.Drawing.Size(44, 23);
            this.txtAdj.TabIndex = 7;
            // 
            // btcCancelDiscount
            // 
            this.btcCancelDiscount.BackColor = System.Drawing.Color.Red;
            this.btcCancelDiscount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btcCancelDiscount.ForeColor = System.Drawing.Color.White;
            this.btcCancelDiscount.Location = new System.Drawing.Point(54, 42);
            this.btcCancelDiscount.Margin = new System.Windows.Forms.Padding(2);
            this.btcCancelDiscount.Name = "btcCancelDiscount";
            this.btcCancelDiscount.Size = new System.Drawing.Size(54, 20);
            this.btcCancelDiscount.TabIndex = 6;
            this.btcCancelDiscount.Text = "Cancel";
            this.btcCancelDiscount.UseVisualStyleBackColor = false;
            this.btcCancelDiscount.Click += new System.EventHandler(this.btcCancelDiscount_Click);
            // 
            // btnAddDiscount
            // 
            this.btnAddDiscount.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAddDiscount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddDiscount.ForeColor = System.Drawing.Color.White;
            this.btnAddDiscount.Location = new System.Drawing.Point(11, 42);
            this.btnAddDiscount.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddDiscount.Name = "btnAddDiscount";
            this.btnAddDiscount.Size = new System.Drawing.Size(40, 20);
            this.btnAddDiscount.TabIndex = 5;
            this.btnAddDiscount.Text = "Add";
            this.btnAddDiscount.UseVisualStyleBackColor = false;
            this.btnAddDiscount.Click += new System.EventHandler(this.btnAddDiscount_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Adjustment";
            // 
            // gbxType
            // 
            this.gbxType.Controls.Add(this.radFullRefund);
            this.gbxType.Controls.Add(this.radPartRefund);
            this.gbxType.ForeColor = System.Drawing.Color.SteelBlue;
            this.gbxType.Location = new System.Drawing.Point(23, 343);
            this.gbxType.Margin = new System.Windows.Forms.Padding(2);
            this.gbxType.Name = "gbxType";
            this.gbxType.Padding = new System.Windows.Forms.Padding(2);
            this.gbxType.Size = new System.Drawing.Size(196, 41);
            this.gbxType.TabIndex = 43;
            this.gbxType.TabStop = false;
            this.gbxType.Text = "Refund Type";
            this.gbxType.Visible = false;
            // 
            // gbxFullRefund
            // 
            this.gbxFullRefund.Controls.Add(this.label13);
            this.gbxFullRefund.Controls.Add(this.label2);
            this.gbxFullRefund.Controls.Add(this.lblPostage);
            this.gbxFullRefund.Controls.Add(this.lblInvoiceTotal);
            this.gbxFullRefund.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxFullRefund.ForeColor = System.Drawing.Color.SteelBlue;
            this.gbxFullRefund.Location = new System.Drawing.Point(24, 404);
            this.gbxFullRefund.Margin = new System.Windows.Forms.Padding(2);
            this.gbxFullRefund.Name = "gbxFullRefund";
            this.gbxFullRefund.Padding = new System.Windows.Forms.Padding(2);
            this.gbxFullRefund.Size = new System.Drawing.Size(192, 127);
            this.gbxFullRefund.TabIndex = 46;
            this.gbxFullRefund.TabStop = false;
            this.gbxFullRefund.Text = "Amount To Be Refunded";
            this.gbxFullRefund.Visible = false;
            // 
            // gbxReason
            // 
            this.gbxReason.Controls.Add(this.txtReason);
            this.gbxReason.Controls.Add(this.label7);
            this.gbxReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxReason.ForeColor = System.Drawing.Color.SteelBlue;
            this.gbxReason.Location = new System.Drawing.Point(224, 343);
            this.gbxReason.Margin = new System.Windows.Forms.Padding(2);
            this.gbxReason.Name = "gbxReason";
            this.gbxReason.Padding = new System.Windows.Forms.Padding(2);
            this.gbxReason.Size = new System.Drawing.Size(244, 41);
            this.gbxReason.TabIndex = 48;
            this.gbxReason.TabStop = false;
            this.gbxReason.Text = "Reason";
            this.gbxReason.Visible = false;
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(70, 18);
            this.txtReason.Margin = new System.Windows.Forms.Padding(2);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(143, 23);
            this.txtReason.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(9, 20);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Reason";
            // 
            // btnAddAdj
            // 
            this.btnAddAdj.FlatAppearance.BorderSize = 0;
            this.btnAddAdj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAdj.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAdj.ForeColor = System.Drawing.Color.Black;
            this.btnAddAdj.Image = global::LexLetsManagement.Properties.Resources.greencross20x20;
            this.btnAddAdj.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddAdj.Location = new System.Drawing.Point(252, 463);
            this.btnAddAdj.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddAdj.Name = "btnAddAdj";
            this.btnAddAdj.Size = new System.Drawing.Size(127, 23);
            this.btnAddAdj.TabIndex = 44;
            this.btnAddAdj.Text = "  Add Adjustment";
            this.btnAddAdj.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddAdj.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddAdj.UseVisualStyleBackColor = true;
            this.btnAddAdj.Visible = false;
            this.btnAddAdj.Click += new System.EventHandler(this.btnAddAdj_Click);
            // 
            // btnRemoveAdj
            // 
            this.btnRemoveAdj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveAdj.FlatAppearance.BorderSize = 0;
            this.btnRemoveAdj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAdj.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveAdj.ForeColor = System.Drawing.Color.Black;
            this.btnRemoveAdj.Image = global::LexLetsManagement.Properties.Resources.delete20x20;
            this.btnRemoveAdj.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveAdj.Location = new System.Drawing.Point(253, 463);
            this.btnRemoveAdj.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveAdj.Name = "btnRemoveAdj";
            this.btnRemoveAdj.Size = new System.Drawing.Size(136, 23);
            this.btnRemoveAdj.TabIndex = 45;
            this.btnRemoveAdj.Text = "  Remove Adjustment";
            this.btnRemoveAdj.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveAdj.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemoveAdj.UseVisualStyleBackColor = true;
            this.btnRemoveAdj.Visible = false;
            this.btnRemoveAdj.Click += new System.EventHandler(this.btnRemoveAdj_Click);
            // 
            // chkPostage
            // 
            this.chkPostage.AutoSize = true;
            this.chkPostage.Checked = true;
            this.chkPostage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPostage.Location = new System.Drawing.Point(11, 5);
            this.chkPostage.Margin = new System.Windows.Forms.Padding(2);
            this.chkPostage.Name = "chkPostage";
            this.chkPostage.Size = new System.Drawing.Size(132, 21);
            this.chkPostage.TabIndex = 51;
            this.chkPostage.Text = "Refund Postage";
            this.chkPostage.UseVisualStyleBackColor = true;
            this.chkPostage.CheckedChanged += new System.EventHandler(this.chkPostage_CheckedChanged);
            // 
            // chkGift
            // 
            this.chkGift.AutoSize = true;
            this.chkGift.Checked = true;
            this.chkGift.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGift.Location = new System.Drawing.Point(11, 21);
            this.chkGift.Margin = new System.Windows.Forms.Padding(2);
            this.chkGift.Name = "chkGift";
            this.chkGift.Size = new System.Drawing.Size(129, 21);
            this.chkGift.TabIndex = 52;
            this.chkGift.Text = "Refund Gift Box";
            this.chkGift.UseVisualStyleBackColor = true;
            this.chkGift.CheckedChanged += new System.EventHandler(this.chkGift_CheckedChanged);
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.chkGift);
            this.pnlOptions.Controls.Add(this.chkPostage);
            this.pnlOptions.Location = new System.Drawing.Point(249, 404);
            this.pnlOptions.Margin = new System.Windows.Forms.Padding(2);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(156, 55);
            this.pnlOptions.TabIndex = 53;
            this.pnlOptions.Visible = false;
            // 
            // FrmRefund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(863, 687);
            this.Controls.Add(this.pnlOptions);
            this.Controls.Add(this.gbxRefundAmount);
            this.Controls.Add(this.gbxReason);
            this.Controls.Add(this.gbxFullRefund);
            this.Controls.Add(this.btnAddAdj);
            this.Controls.Add(this.btnRemoveAdj);
            this.Controls.Add(this.gbxType);
            this.Controls.Add(this.pnlAdjustment);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.dgvRefunds);
            this.Controls.Add(this.pnlItems);
            this.Controls.Add(this.pnlCustomer);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtInvoice);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmRefund";
            this.Text = "FrmRefund";
         
            this.pnlCustomer.ResumeLayout(false);
            this.pnlItems.ResumeLayout(false);
            this.pnlItems.PerformLayout();
            this.pnlDiscounts.ResumeLayout(false);
            this.pnlDiscounts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefunds)).EndInit();
            this.gbxRefundAmount.ResumeLayout(false);
            this.gbxRefundAmount.PerformLayout();
            this.pnlAdjustment.ResumeLayout(false);
            this.pnlAdjustment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picErrorAdj)).EndInit();
            this.gbxType.ResumeLayout(false);
            this.gbxType.PerformLayout();
            this.gbxFullRefund.ResumeLayout(false);
            this.gbxFullRefund.PerformLayout();
            this.gbxReason.ResumeLayout(false);
            this.gbxReason.PerformLayout();
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInvoice;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAdd1;
        private System.Windows.Forms.Label lblAdd2;
        private System.Windows.Forms.Label lblPoscode;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlCustomer;
        private System.ComponentModel.BackgroundWorker bgwGetCustomer;
        private System.Windows.Forms.Panel pnlItems;
        private System.Windows.Forms.Label lblsku;
        private System.Windows.Forms.Label lbldesc;
        private System.Windows.Forms.Label lblqty;
        private System.Windows.Forms.Label lblgift;
        private System.Windows.Forms.Label lblprice;
        private System.Windows.Forms.DataGridView dgvRefunds;
        private System.Windows.Forms.Label lblsize;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbxRefundAmount;
        private System.Windows.Forms.Label lblRefundTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblOther;
        private System.Windows.Forms.Label lblGiftboxes;
        private System.Windows.Forms.Label lblProducts;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPostage;
        private System.Windows.Forms.Label lblInvoiceTotal;
        private System.Windows.Forms.RadioButton radFullRefund;
        private System.Windows.Forms.RadioButton radPartRefund;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblAdjustment;
        private System.Windows.Forms.Panel pnlAdjustment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAdj;
        private System.Windows.Forms.Button btcCancelDiscount;
        private System.Windows.Forms.Button btnAddDiscount;
        private System.Windows.Forms.GroupBox gbxType;
        private System.Windows.Forms.Button btnAddAdj;
        private System.Windows.Forms.Button btnRemoveAdj;
        private System.Windows.Forms.Label lblPost;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gbxFullRefund;
        private System.Windows.Forms.Panel pnlDiscounts;
        private System.Windows.Forms.GroupBox gbxReason;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox picErrorAdj;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row;
        private System.Windows.Forms.DataGridViewTextBoxColumn Invoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyToRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiftBox;
        private System.Windows.Forms.CheckBox chkPostage;
        private System.Windows.Forms.CheckBox chkGift;
        private System.Windows.Forms.Panel pnlOptions;
    }
}