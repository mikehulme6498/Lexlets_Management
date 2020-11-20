namespace LexLetsManagement
{
    partial class FrmAddNewCollection
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
            this.components = new System.ComponentModel.Container();
            this.gbxMaterials = new System.Windows.Forms.GroupBox();
            this.flowLayoutCost = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutSellPrice = new System.Windows.Forms.FlowLayoutPanel();
            this.lblprice = new System.Windows.Forms.Label();
            this.lbldescription = new System.Windows.Forms.Label();
            this.flowLayoutDescription = new System.Windows.Forms.FlowLayoutPanel();
            this.lblsku = new System.Windows.Forms.Label();
            this.flowLayoutSKU = new System.Windows.Forms.FlowLayoutPanel();
            this.tblMaterialCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lexletsdatabaseDataSet = new LexLetsManagement.lexletsdatabaseDataSet();
            this.tblColoursBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblMaterialsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblMaterialCategoryTableAdapter = new LexLetsManagement.lexletsdatabaseDataSetTableAdapters.tblMaterialCategoryTableAdapter();
            this.tblColoursTableAdapter = new LexLetsManagement.lexletsdatabaseDataSetTableAdapters.tblColoursTableAdapter();
            this.tblMaterialsTableAdapter = new LexLetsManagement.lexletsdatabaseDataSetTableAdapters.tblMaterialsTableAdapter();
            this.lblSuggested = new System.Windows.Forms.Label();
            this.TxtPicPath = new System.Windows.Forms.TextBox();
            this.BtnAttachImage = new System.Windows.Forms.Button();
            this.CmbCategory = new System.Windows.Forms.ComboBox();
            this.TxtPrice = new System.Windows.Forms.TextBox();
            this.TxtCost = new System.Windows.Forms.TextBox();
            this.TxtDescription = new System.Windows.Forms.TextBox();
            this.TxtSKU = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnDone = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.gbxProductDetails = new System.Windows.Forms.GroupBox();
            this.picErrorPrice = new System.Windows.Forms.PictureBox();
            this.picErrorCost = new System.Windows.Forms.PictureBox();
            this.picErrorCategory = new System.Windows.Forms.PictureBox();
            this.picErrorDescription = new System.Windows.Forms.PictureBox();
            this.picErrorSKU = new System.Windows.Forms.PictureBox();
            this.lblSellPrice = new System.Windows.Forms.Label();
            this.lblAddImage = new System.Windows.Forms.Label();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddAnother = new System.Windows.Forms.Button();
            this.gbxMaterials.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblMaterialCategoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lexletsdatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblColoursBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMaterialsBindingSource)).BeginInit();
            this.gbxProductDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picErrorPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picErrorCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picErrorCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picErrorDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picErrorSKU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxMaterials
            // 
            this.gbxMaterials.Controls.Add(this.flowLayoutCost);
            this.gbxMaterials.Controls.Add(this.label1);
            this.gbxMaterials.Controls.Add(this.flowLayoutSellPrice);
            this.gbxMaterials.Controls.Add(this.lblprice);
            this.gbxMaterials.Controls.Add(this.lbldescription);
            this.gbxMaterials.Controls.Add(this.flowLayoutDescription);
            this.gbxMaterials.Controls.Add(this.lblsku);
            this.gbxMaterials.Controls.Add(this.flowLayoutSKU);
            this.gbxMaterials.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxMaterials.ForeColor = System.Drawing.Color.SteelBlue;
            this.gbxMaterials.Location = new System.Drawing.Point(15, 32);
            this.gbxMaterials.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxMaterials.Name = "gbxMaterials";
            this.gbxMaterials.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxMaterials.Size = new System.Drawing.Size(964, 475);
            this.gbxMaterials.TabIndex = 0;
            this.gbxMaterials.TabStop = false;
            this.gbxMaterials.Text = "Add Products To Collection";
            
            // 
            // flowLayoutCost
            // 
            this.flowLayoutCost.Location = new System.Drawing.Point(664, 78);
            this.flowLayoutCost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutCost.Name = "flowLayoutCost";
            this.flowLayoutCost.Size = new System.Drawing.Size(131, 370);
            this.flowLayoutCost.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(655, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cost To Make";
            // 
            // flowLayoutSellPrice
            // 
            this.flowLayoutSellPrice.Location = new System.Drawing.Point(802, 78);
            this.flowLayoutSellPrice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutSellPrice.Name = "flowLayoutSellPrice";
            this.flowLayoutSellPrice.Size = new System.Drawing.Size(131, 370);
            this.flowLayoutSellPrice.TabIndex = 1;
            // 
            // lblprice
            // 
            this.lblprice.AutoSize = true;
            this.lblprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprice.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblprice.Location = new System.Drawing.Point(815, 39);
            this.lblprice.Name = "lblprice";
            this.lblprice.Size = new System.Drawing.Size(104, 25);
            this.lblprice.TabIndex = 4;
            this.lblprice.Text = "Sell Price";
            // 
            // lbldescription
            // 
            this.lbldescription.AutoSize = true;
            this.lbldescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldescription.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbldescription.Location = new System.Drawing.Point(365, 39);
            this.lbldescription.Name = "lbldescription";
            this.lbldescription.Size = new System.Drawing.Size(120, 25);
            this.lbldescription.TabIndex = 3;
            this.lbldescription.Text = "Description";
            // 
            // flowLayoutDescription
            // 
            this.flowLayoutDescription.Location = new System.Drawing.Point(195, 78);
            this.flowLayoutDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutDescription.Name = "flowLayoutDescription";
            this.flowLayoutDescription.Size = new System.Drawing.Size(461, 370);
            this.flowLayoutDescription.TabIndex = 1;
            // 
            // lblsku
            // 
            this.lblsku.AutoSize = true;
            this.lblsku.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsku.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblsku.Location = new System.Drawing.Point(93, 39);
            this.lblsku.Name = "lblsku";
            this.lblsku.Size = new System.Drawing.Size(57, 25);
            this.lblsku.TabIndex = 2;
            this.lblsku.Text = "SKU";
            // 
            // flowLayoutSKU
            // 
            this.flowLayoutSKU.Location = new System.Drawing.Point(56, 78);
            this.flowLayoutSKU.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutSKU.Name = "flowLayoutSKU";
            this.flowLayoutSKU.Size = new System.Drawing.Size(131, 370);
            this.flowLayoutSKU.TabIndex = 0;
            // 
            // tblMaterialCategoryBindingSource
            // 
            this.tblMaterialCategoryBindingSource.DataMember = "tblMaterialCategory";
            this.tblMaterialCategoryBindingSource.DataSource = this.lexletsdatabaseDataSet;
            // 
            // lexletsdatabaseDataSet
            // 
            this.lexletsdatabaseDataSet.DataSetName = "lexletsdatabaseDataSet";
            this.lexletsdatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblColoursBindingSource
            // 
            this.tblColoursBindingSource.DataMember = "tblColours";
            this.tblColoursBindingSource.DataSource = this.lexletsdatabaseDataSet;
            // 
            // tblMaterialsBindingSource
            // 
            this.tblMaterialsBindingSource.DataMember = "tblMaterials";
            this.tblMaterialsBindingSource.DataSource = this.lexletsdatabaseDataSet;
            // 
            // tblMaterialCategoryTableAdapter
            // 
            this.tblMaterialCategoryTableAdapter.ClearBeforeFill = true;
            // 
            // tblColoursTableAdapter
            // 
            this.tblColoursTableAdapter.ClearBeforeFill = true;
            // 
            // tblMaterialsTableAdapter
            // 
            this.tblMaterialsTableAdapter.ClearBeforeFill = true;
            // 
            // lblSuggested
            // 
            this.lblSuggested.AutoSize = true;
            this.lblSuggested.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuggested.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblSuggested.Location = new System.Drawing.Point(149, 254);
            this.lblSuggested.Name = "lblSuggested";
            this.lblSuggested.Size = new System.Drawing.Size(112, 17);
            this.lblSuggested.TabIndex = 18;
            this.lblSuggested.Text = "Suggested Price";
            this.lblSuggested.Visible = false;
            // 
            // TxtPicPath
            // 
            this.TxtPicPath.Location = new System.Drawing.Point(316, 262);
            this.TxtPicPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtPicPath.Name = "TxtPicPath";
            this.TxtPicPath.Size = new System.Drawing.Size(137, 30);
            this.TxtPicPath.TabIndex = 27;
            this.TxtPicPath.Visible = false;
            // 
            // BtnAttachImage
            // 
            this.BtnAttachImage.Enabled = false;
            this.BtnAttachImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAttachImage.ForeColor = System.Drawing.Color.Black;
            this.BtnAttachImage.Location = new System.Drawing.Point(460, 263);
            this.BtnAttachImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnAttachImage.Name = "BtnAttachImage";
            this.BtnAttachImage.Size = new System.Drawing.Size(137, 32);
            this.BtnAttachImage.TabIndex = 26;
            this.BtnAttachImage.Text = "Attach Image";
            this.BtnAttachImage.UseVisualStyleBackColor = true;
            this.BtnAttachImage.Click += new System.EventHandler(this.BtnAttachImage_Click);
            // 
            // CmbCategory
            // 
            this.CmbCategory.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tblMaterialCategoryBindingSource, "CategoryId", true));
            this.CmbCategory.Enabled = false;
            this.CmbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCategory.FormattingEnabled = true;
            this.CmbCategory.Location = new System.Drawing.Point(151, 132);
            this.CmbCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CmbCategory.Name = "CmbCategory";
            this.CmbCategory.Size = new System.Drawing.Size(177, 25);
            this.CmbCategory.TabIndex = 25;
            this.CmbCategory.SelectedIndexChanged += new System.EventHandler(this.CmbCategory_SelectedIndexChanged);
            // 
            // TxtPrice
            // 
            this.TxtPrice.Enabled = false;
            this.TxtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPrice.Location = new System.Drawing.Point(151, 203);
            this.TxtPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtPrice.Name = "TxtPrice";
            this.TxtPrice.Size = new System.Drawing.Size(57, 23);
            this.TxtPrice.TabIndex = 19;
            // 
            // TxtCost
            // 
            this.TxtCost.Enabled = false;
            this.TxtCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCost.Location = new System.Drawing.Point(151, 169);
            this.TxtCost.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtCost.Name = "TxtCost";
            this.TxtCost.Size = new System.Drawing.Size(57, 23);
            this.TxtCost.TabIndex = 18;
            // 
            // TxtDescription
            // 
            this.TxtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescription.Location = new System.Drawing.Point(151, 96);
            this.TxtDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtDescription.Name = "TxtDescription";
            this.TxtDescription.Size = new System.Drawing.Size(177, 23);
            this.TxtDescription.TabIndex = 17;
            this.TxtDescription.TextChanged += new System.EventHandler(this.TxtDescription_TextChanged);
            // 
            // TxtSKU
            // 
            this.TxtSKU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSKU.Location = new System.Drawing.Point(151, 62);
            this.TxtSKU.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtSKU.Name = "TxtSKU";
            this.TxtSKU.Size = new System.Drawing.Size(79, 23);
            this.TxtSKU.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(51, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 25);
            this.label9.TabIndex = 4;
            this.label9.Text = "Category";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(89, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 25);
            this.label8.TabIndex = 3;
            this.label8.Text = "Price";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(92, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 25);
            this.label7.TabIndex = 2;
            this.label7.Text = "Cost";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(29, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 25);
            this.label6.TabIndex = 1;
            this.label6.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(92, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "SKU";
            // 
            // BtnDone
            // 
            this.BtnDone.BackColor = System.Drawing.Color.Chartreuse;
            this.BtnDone.Location = new System.Drawing.Point(985, 483);
            this.BtnDone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnDone.Name = "BtnDone";
            this.BtnDone.Size = new System.Drawing.Size(75, 27);
            this.BtnDone.TabIndex = 16;
            this.BtnDone.Text = "Done";
            this.BtnDone.UseVisualStyleBackColor = false;
            this.BtnDone.Click += new System.EventHandler(this.BtnDone_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.BackColor = System.Drawing.Color.Gold;
            this.BtnEdit.Location = new System.Drawing.Point(985, 483);
            this.BtnEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(75, 27);
            this.BtnEdit.TabIndex = 17;
            this.BtnEdit.Text = "Edit";
            this.BtnEdit.UseVisualStyleBackColor = false;
            this.BtnEdit.Visible = false;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.DarkOrange;
            this.BtnCancel.ForeColor = System.Drawing.Color.White;
            this.BtnCancel.Location = new System.Drawing.Point(913, 832);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(149, 39);
            this.BtnCancel.TabIndex = 29;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.YellowGreen;
            this.BtnSave.ForeColor = System.Drawing.Color.White;
            this.BtnSave.Location = new System.Drawing.Point(1067, 832);
            this.BtnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(149, 39);
            this.BtnSave.TabIndex = 28;
            this.BtnSave.Text = "Save Collection";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // gbxProductDetails
            // 
            this.gbxProductDetails.Controls.Add(this.picErrorPrice);
            this.gbxProductDetails.Controls.Add(this.picErrorCost);
            this.gbxProductDetails.Controls.Add(this.picErrorCategory);
            this.gbxProductDetails.Controls.Add(this.picErrorDescription);
            this.gbxProductDetails.Controls.Add(this.picErrorSKU);
            this.gbxProductDetails.Controls.Add(this.lblSellPrice);
            this.gbxProductDetails.Controls.Add(this.lblAddImage);
            this.gbxProductDetails.Controls.Add(this.TxtPicPath);
            this.gbxProductDetails.Controls.Add(this.label4);
            this.gbxProductDetails.Controls.Add(this.lblSuggested);
            this.gbxProductDetails.Controls.Add(this.label6);
            this.gbxProductDetails.Controls.Add(this.label7);
            this.gbxProductDetails.Controls.Add(this.label8);
            this.gbxProductDetails.Controls.Add(this.label9);
            this.gbxProductDetails.Controls.Add(this.BtnAttachImage);
            this.gbxProductDetails.Controls.Add(this.TxtSKU);
            this.gbxProductDetails.Controls.Add(this.TxtDescription);
            this.gbxProductDetails.Controls.Add(this.picImage);
            this.gbxProductDetails.Controls.Add(this.TxtCost);
            this.gbxProductDetails.Controls.Add(this.TxtPrice);
            this.gbxProductDetails.Controls.Add(this.CmbCategory);
            this.gbxProductDetails.Enabled = false;
            this.gbxProductDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxProductDetails.ForeColor = System.Drawing.Color.SteelBlue;
            this.gbxProductDetails.Location = new System.Drawing.Point(53, 542);
            this.gbxProductDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxProductDetails.Name = "gbxProductDetails";
            this.gbxProductDetails.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxProductDetails.Size = new System.Drawing.Size(707, 330);
            this.gbxProductDetails.TabIndex = 37;
            this.gbxProductDetails.TabStop = false;
            this.gbxProductDetails.Text = "Product Details";
            // 
            // picErrorPrice
            // 
            this.picErrorPrice.Cursor = System.Windows.Forms.Cursors.Help;
            this.picErrorPrice.Image = global::LexLetsManagement.Properties.Resources.Error;
            this.picErrorPrice.Location = new System.Drawing.Point(215, 209);
            this.picErrorPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picErrorPrice.Name = "picErrorPrice";
            this.picErrorPrice.Size = new System.Drawing.Size(19, 18);
            this.picErrorPrice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picErrorPrice.TabIndex = 39;
            this.picErrorPrice.TabStop = false;
            this.picErrorPrice.Tag = "";
            this.picErrorPrice.Visible = false;
            // 
            // picErrorCost
            // 
            this.picErrorCost.Cursor = System.Windows.Forms.Cursors.Help;
            this.picErrorCost.Image = global::LexLetsManagement.Properties.Resources.Error;
            this.picErrorCost.Location = new System.Drawing.Point(215, 172);
            this.picErrorCost.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picErrorCost.Name = "picErrorCost";
            this.picErrorCost.Size = new System.Drawing.Size(19, 18);
            this.picErrorCost.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picErrorCost.TabIndex = 38;
            this.picErrorCost.TabStop = false;
            this.picErrorCost.Tag = "";
            this.picErrorCost.Visible = false;
            // 
            // picErrorCategory
            // 
            this.picErrorCategory.Cursor = System.Windows.Forms.Cursors.Help;
            this.picErrorCategory.Image = global::LexLetsManagement.Properties.Resources.Error;
            this.picErrorCategory.Location = new System.Drawing.Point(335, 139);
            this.picErrorCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picErrorCategory.Name = "picErrorCategory";
            this.picErrorCategory.Size = new System.Drawing.Size(19, 18);
            this.picErrorCategory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picErrorCategory.TabIndex = 37;
            this.picErrorCategory.TabStop = false;
            this.picErrorCategory.Tag = "";
            this.picErrorCategory.Visible = false;
            // 
            // picErrorDescription
            // 
            this.picErrorDescription.Cursor = System.Windows.Forms.Cursors.Help;
            this.picErrorDescription.Image = global::LexLetsManagement.Properties.Resources.Error;
            this.picErrorDescription.Location = new System.Drawing.Point(335, 102);
            this.picErrorDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picErrorDescription.Name = "picErrorDescription";
            this.picErrorDescription.Size = new System.Drawing.Size(19, 18);
            this.picErrorDescription.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picErrorDescription.TabIndex = 36;
            this.picErrorDescription.TabStop = false;
            this.picErrorDescription.Tag = "";
            this.picErrorDescription.Visible = false;
            // 
            // picErrorSKU
            // 
            this.picErrorSKU.Cursor = System.Windows.Forms.Cursors.Help;
            this.picErrorSKU.Image = global::LexLetsManagement.Properties.Resources.Error;
            this.picErrorSKU.Location = new System.Drawing.Point(244, 68);
            this.picErrorSKU.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picErrorSKU.Name = "picErrorSKU";
            this.picErrorSKU.Size = new System.Drawing.Size(19, 18);
            this.picErrorSKU.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picErrorSKU.TabIndex = 35;
            this.picErrorSKU.TabStop = false;
            this.picErrorSKU.Tag = "";
            this.picErrorSKU.Visible = false;
            // 
            // lblSellPrice
            // 
            this.lblSellPrice.AutoSize = true;
            this.lblSellPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSellPrice.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblSellPrice.Location = new System.Drawing.Point(149, 234);
            this.lblSellPrice.Name = "lblSellPrice";
            this.lblSellPrice.Size = new System.Drawing.Size(67, 17);
            this.lblSellPrice.TabIndex = 29;
            this.lblSellPrice.Text = "Sell Price";
            this.lblSellPrice.Visible = false;
            // 
            // lblAddImage
            // 
            this.lblAddImage.AutoSize = true;
            this.lblAddImage.ForeColor = System.Drawing.Color.Red;
            this.lblAddImage.Location = new System.Drawing.Point(437, 129);
            this.lblAddImage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddImage.Name = "lblAddImage";
            this.lblAddImage.Size = new System.Drawing.Size(172, 25);
            this.lblAddImage.TabIndex = 28;
            this.lblAddImage.Text = "Please Add Image";
            this.lblAddImage.Visible = false;
            // 
            // picImage
            // 
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(427, 49);
            this.picImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(205, 208);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 16;
            this.picImage.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Image = global::LexLetsManagement.Properties.Resources.delete20x20;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(985, 397);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(33, 31);
            this.btnDelete.TabIndex = 40;
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddAnother
            // 
            this.btnAddAnother.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddAnother.FlatAppearance.BorderSize = 0;
            this.btnAddAnother.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAnother.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAnother.ForeColor = System.Drawing.Color.Black;
            this.btnAddAnother.Image = global::LexLetsManagement.Properties.Resources.greencross20x20;
            this.btnAddAnother.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddAnother.Location = new System.Drawing.Point(985, 355);
            this.btnAddAnother.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddAnother.Name = "btnAddAnother";
            this.btnAddAnother.Size = new System.Drawing.Size(201, 37);
            this.btnAddAnother.TabIndex = 39;
            this.btnAddAnother.Text = "  Add Another Item";
            this.btnAddAnother.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddAnother.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddAnother.UseVisualStyleBackColor = true;
            this.btnAddAnother.Visible = false;
            this.btnAddAnother.Click += new System.EventHandler(this.btnAddAnother_Click_1);
            // 
            // FrmAddNewCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1235, 882);
            this.Controls.Add(this.btnAddAnother);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.gbxProductDetails);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnDone);
            this.Controls.Add(this.gbxMaterials);
            this.Controls.Add(this.BtnEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmAddNewCollection";
            this.Text = "AddNewProduct";
            this.Load += new System.EventHandler(this.FrmAddNewCollection_Load);
            this.gbxMaterials.ResumeLayout(false);
            this.gbxMaterials.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblMaterialCategoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lexletsdatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblColoursBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMaterialsBindingSource)).EndInit();
            this.gbxProductDetails.ResumeLayout(false);
            this.gbxProductDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picErrorPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picErrorCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picErrorCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picErrorDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picErrorSKU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxMaterials;
        private lexletsdatabaseDataSet lexletsdatabaseDataSet;
        private System.Windows.Forms.BindingSource tblMaterialCategoryBindingSource;
        private lexletsdatabaseDataSetTableAdapters.tblMaterialCategoryTableAdapter tblMaterialCategoryTableAdapter;
        private System.Windows.Forms.BindingSource tblColoursBindingSource;
        private lexletsdatabaseDataSetTableAdapters.tblColoursTableAdapter tblColoursTableAdapter;
        private System.Windows.Forms.BindingSource tblMaterialsBindingSource;
        private lexletsdatabaseDataSetTableAdapters.tblMaterialsTableAdapter tblMaterialsTableAdapter;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtSKU;
        private System.Windows.Forms.TextBox TxtPrice;
        private System.Windows.Forms.TextBox TxtCost;
        private System.Windows.Forms.TextBox TxtDescription;
        private System.Windows.Forms.ComboBox CmbCategory;
        private System.Windows.Forms.TextBox TxtPicPath;
        private System.Windows.Forms.Button BtnAttachImage;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Button BtnDone;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Label lblSuggested;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.GroupBox gbxProductDetails;
        private System.Windows.Forms.Label lblAddImage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutSKU;
        private System.Windows.Forms.Label lbldescription;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutDescription;
        private System.Windows.Forms.Label lblsku;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutSellPrice;
        private System.Windows.Forms.Label lblprice;
        private System.Windows.Forms.Button btnAddAnother;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutCost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSellPrice;
        private System.Windows.Forms.PictureBox picErrorPrice;
        private System.Windows.Forms.PictureBox picErrorCost;
        private System.Windows.Forms.PictureBox picErrorCategory;
        private System.Windows.Forms.PictureBox picErrorDescription;
        private System.Windows.Forms.PictureBox picErrorSKU;
    }
}