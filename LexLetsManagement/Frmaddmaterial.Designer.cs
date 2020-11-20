namespace LexLetsManagement
{
    partial class Frmaddmaterial
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
            System.Windows.Forms.Label categoryLabel;
            System.Windows.Forms.Label materialIdLabel;
            System.Windows.Forms.Label sizeonBraceletLabel;
            System.Windows.Forms.Label costPerItemLabel;
            System.Windows.Forms.Label lowLevelWarningLabel;
            System.Windows.Forms.Label qTYinStockLabel;
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.lexletsdatabaseDataSet = new LexLetsManagement.lexletsdatabaseDataSet();
            this.tblMaterialsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblMaterialsTableAdapter = new LexLetsManagement.lexletsdatabaseDataSetTableAdapters.tblMaterialsTableAdapter();
            this.tableAdapterManager = new LexLetsManagement.lexletsdatabaseDataSetTableAdapters.TableAdapterManager();
            this.btnloadimage = new System.Windows.Forms.Button();
            this.materialIdTextBox = new System.Windows.Forms.TextBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.lblColour = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.tblMaterialCategoryBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.lexletsdatabaseDataSet1 = new LexLetsManagement.lexletsdatabaseDataSet1();
            this.lblImage = new System.Windows.Forms.Label();
            this.picLoadImage = new System.Windows.Forms.PictureBox();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblLowLevel = new System.Windows.Forms.Label();
            this.qTYinStockTextBox = new System.Windows.Forms.TextBox();
            this.lblQTY = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lowLevelWarningTextBox = new System.Windows.Forms.TextBox();
            this.cmbColour = new System.Windows.Forms.ComboBox();
            this.tblColoursBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sizeonBraceletTextBox = new System.Windows.Forms.TextBox();
            this.costPerItemTextBox = new System.Windows.Forms.TextBox();
            this.tblSuppliersBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tblSuppliersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblMaterialCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tblMaterialCategoryTableAdapter = new LexLetsManagement.lexletsdatabaseDataSetTableAdapters.tblMaterialCategoryTableAdapter();
            this.tblColoursTableAdapter = new LexLetsManagement.lexletsdatabaseDataSetTableAdapters.tblColoursTableAdapter();
            this.tblSuppliersTableAdapter = new LexLetsManagement.lexletsdatabaseDataSetTableAdapters.tblSuppliersTableAdapter();
            this.tblMaterialCategoryTableAdapter1 = new LexLetsManagement.lexletsdatabaseDataSet1TableAdapters.tblMaterialCategoryTableAdapter();
            this.tblSuppliersTableAdapter1 = new LexLetsManagement.lexletsdatabaseDataSet1TableAdapters.tblSuppliersTableAdapter();
            categoryLabel = new System.Windows.Forms.Label();
            materialIdLabel = new System.Windows.Forms.Label();
            sizeonBraceletLabel = new System.Windows.Forms.Label();
            costPerItemLabel = new System.Windows.Forms.Label();
            lowLevelWarningLabel = new System.Windows.Forms.Label();
            qTYinStockLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lexletsdatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMaterialsBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblMaterialCategoryBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lexletsdatabaseDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoadImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblColoursBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSuppliersBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSuppliersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMaterialCategoryBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // categoryLabel
            // 
            categoryLabel.AutoSize = true;
            categoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            categoryLabel.ForeColor = System.Drawing.Color.Black;
            categoryLabel.Location = new System.Drawing.Point(104, 81);
            categoryLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            categoryLabel.Name = "categoryLabel";
            categoryLabel.Size = new System.Drawing.Size(69, 17);
            categoryLabel.TabIndex = 3;
            categoryLabel.Text = "Category:";
            // 
            // materialIdLabel
            // 
            materialIdLabel.AutoSize = true;
            materialIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            materialIdLabel.ForeColor = System.Drawing.Color.Black;
            materialIdLabel.Location = new System.Drawing.Point(96, 53);
            materialIdLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            materialIdLabel.Name = "materialIdLabel";
            materialIdLabel.Size = new System.Drawing.Size(77, 17);
            materialIdLabel.TabIndex = 1;
            materialIdLabel.Text = "Material Id:";
            // 
            // sizeonBraceletLabel
            // 
            sizeonBraceletLabel.AutoSize = true;
            sizeonBraceletLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sizeonBraceletLabel.ForeColor = System.Drawing.Color.Black;
            sizeonBraceletLabel.Location = new System.Drawing.Point(22, 258);
            sizeonBraceletLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            sizeonBraceletLabel.Name = "sizeonBraceletLabel";
            sizeonBraceletLabel.Size = new System.Drawing.Size(151, 17);
            sizeonBraceletLabel.TabIndex = 13;
            sizeonBraceletLabel.Text = "Size on Bracelet (mm):";
            // 
            // costPerItemLabel
            // 
            costPerItemLabel.AutoSize = true;
            costPerItemLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            costPerItemLabel.ForeColor = System.Drawing.Color.Black;
            costPerItemLabel.Location = new System.Drawing.Point(55, 229);
            costPerItemLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            costPerItemLabel.Name = "costPerItemLabel";
            costPerItemLabel.Size = new System.Drawing.Size(118, 17);
            costPerItemLabel.TabIndex = 11;
            costPerItemLabel.Text = "Cost Per Item (£):";
            // 
            // lowLevelWarningLabel
            // 
            lowLevelWarningLabel.AutoSize = true;
            lowLevelWarningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lowLevelWarningLabel.ForeColor = System.Drawing.Color.Black;
            lowLevelWarningLabel.Location = new System.Drawing.Point(41, 200);
            lowLevelWarningLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lowLevelWarningLabel.Name = "lowLevelWarningLabel";
            lowLevelWarningLabel.Size = new System.Drawing.Size(132, 17);
            lowLevelWarningLabel.TabIndex = 9;
            lowLevelWarningLabel.Text = "Low Level Warning:";
            // 
            // qTYinStockLabel
            // 
            qTYinStockLabel.AutoSize = true;
            qTYinStockLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            qTYinStockLabel.ForeColor = System.Drawing.Color.Black;
            qTYinStockLabel.Location = new System.Drawing.Point(82, 171);
            qTYinStockLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            qTYinStockLabel.Name = "qTYinStockLabel";
            qTYinStockLabel.Size = new System.Drawing.Size(91, 17);
            qTYinStockLabel.TabIndex = 7;
            qTYinStockLabel.Text = "QTYin Stock:";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            descriptionLabel.ForeColor = System.Drawing.Color.Black;
            descriptionLabel.Location = new System.Drawing.Point(90, 139);
            descriptionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(83, 17);
            descriptionLabel.TabIndex = 5;
            descriptionLabel.Text = "Description:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.Color.Black;
            label1.Location = new System.Drawing.Point(120, 111);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(53, 17);
            label1.TabIndex = 23;
            label1.Text = "Colour:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.ForeColor = System.Drawing.Color.Black;
            label2.Location = new System.Drawing.Point(113, 287);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(60, 17);
            label2.TabIndex = 26;
            label2.Text = "Supplier";
            // 
            // lexletsdatabaseDataSet
            // 
            this.lexletsdatabaseDataSet.DataSetName = "lexletsdatabaseDataSet1";
            this.lexletsdatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblMaterialsBindingSource
            // 
            this.tblMaterialsBindingSource.DataMember = "tblMaterials";
            this.tblMaterialsBindingSource.DataSource = this.lexletsdatabaseDataSet;
            // 
            // tblMaterialsTableAdapter
            // 
            this.tblMaterialsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.tblCollectionContainsTableAdapter = null;
            this.tableAdapterManager.tblCollectionDataTableAdapter = null;
            this.tableAdapterManager.tblColoursTableAdapter = null;
            this.tableAdapterManager.tblCustomersTableAdapter = null;
            this.tableAdapterManager.tblIncomeTableAdapter = null;
            this.tableAdapterManager.tblMaterialCategoryTableAdapter = null;
            this.tableAdapterManager.tblMaterialsTableAdapter = this.tblMaterialsTableAdapter;
            this.tableAdapterManager.tblOutgoingTableAdapter = null;
            this.tableAdapterManager.tblProductConatinsTableAdapter = null;
            this.tableAdapterManager.tblProductDataTableAdapter = null;
            this.tableAdapterManager.tblSaleItemsTableAdapter = null;
            this.tableAdapterManager.tblsalesTableAdapter = null;
            this.tableAdapterManager.tblSuppliersTableAdapter = null;
            this.tableAdapterManager.tblUsersTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = LexLetsManagement.lexletsdatabaseDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // btnloadimage
            // 
            this.btnloadimage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnloadimage.ForeColor = System.Drawing.Color.Black;
            this.btnloadimage.Location = new System.Drawing.Point(483, 215);
            this.btnloadimage.Name = "btnloadimage";
            this.btnloadimage.Size = new System.Drawing.Size(105, 30);
            this.btnloadimage.TabIndex = 18;
            this.btnloadimage.Text = "Attach Image";
            this.btnloadimage.UseVisualStyleBackColor = true;
            this.btnloadimage.Click += new System.EventHandler(this.Btnloadimage_Click);
            // 
            // materialIdTextBox
            // 
            this.materialIdTextBox.Enabled = false;
            this.materialIdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialIdTextBox.Location = new System.Drawing.Point(180, 50);
            this.materialIdTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.materialIdTextBox.Name = "materialIdTextBox";
            this.materialIdTextBox.Size = new System.Drawing.Size(89, 23);
            this.materialIdTextBox.TabIndex = 2;
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.YellowGreen;
            this.BtnSave.ForeColor = System.Drawing.Color.White;
            this.BtnSave.Location = new System.Drawing.Point(459, 370);
            this.BtnSave.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(149, 40);
            this.BtnSave.TabIndex = 16;
            this.BtnSave.Text = "Save Material";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.DarkOrange;
            this.BtnCancel.ForeColor = System.Drawing.Color.White;
            this.BtnCancel.Location = new System.Drawing.Point(306, 370);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(149, 40);
            this.BtnCancel.TabIndex = 20;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnCancel);
            this.groupBox1.Controls.Add(this.BtnSave);
            this.groupBox1.Controls.Add(this.lblSupplier);
            this.groupBox1.Controls.Add(label2);
            this.groupBox1.Controls.Add(this.cmbSupplier);
            this.groupBox1.Controls.Add(this.lblColour);
            this.groupBox1.Controls.Add(this.cmbCategory);
            this.groupBox1.Controls.Add(this.lblImage);
            this.groupBox1.Controls.Add(this.btnloadimage);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(materialIdLabel);
            this.groupBox1.Controls.Add(this.materialIdTextBox);
            this.groupBox1.Controls.Add(this.picLoadImage);
            this.groupBox1.Controls.Add(categoryLabel);
            this.groupBox1.Controls.Add(this.txtImagePath);
            this.groupBox1.Controls.Add(this.lblSize);
            this.groupBox1.Controls.Add(descriptionLabel);
            this.groupBox1.Controls.Add(this.descriptionTextBox);
            this.groupBox1.Controls.Add(this.lblCost);
            this.groupBox1.Controls.Add(qTYinStockLabel);
            this.groupBox1.Controls.Add(this.lblLowLevel);
            this.groupBox1.Controls.Add(this.qTYinStockTextBox);
            this.groupBox1.Controls.Add(this.lblQTY);
            this.groupBox1.Controls.Add(lowLevelWarningLabel);
            this.groupBox1.Controls.Add(this.lblCategory);
            this.groupBox1.Controls.Add(this.lowLevelWarningTextBox);
            this.groupBox1.Controls.Add(this.cmbColour);
            this.groupBox1.Controls.Add(costPerItemLabel);
            this.groupBox1.Controls.Add(this.sizeonBraceletTextBox);
            this.groupBox1.Controls.Add(this.costPerItemTextBox);
            this.groupBox1.Controls.Add(sizeonBraceletLabel);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(622, 425);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add New Material";
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplier.ForeColor = System.Drawing.Color.Red;
            this.lblSupplier.Location = new System.Drawing.Point(363, 286);
            this.lblSupplier.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(125, 17);
            this.lblSupplier.TabIndex = 27;
            this.lblSupplier.Text = "Incorrect Selection";
            this.lblSupplier.Visible = false;
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(180, 284);
            this.cmbSupplier.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(179, 24);
            this.cmbSupplier.TabIndex = 25;
            // 
            // lblColour
            // 
            this.lblColour.AutoSize = true;
            this.lblColour.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColour.ForeColor = System.Drawing.Color.Red;
            this.lblColour.Location = new System.Drawing.Point(321, 109);
            this.lblColour.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblColour.Name = "lblColour";
            this.lblColour.Size = new System.Drawing.Size(125, 17);
            this.lblColour.TabIndex = 24;
            this.lblColour.Text = "Incorrect Selection";
            this.lblColour.Visible = false;
            // 
            // cmbCategory
            // 
            this.cmbCategory.DataSource = this.tblMaterialCategoryBindingSource1;
            this.cmbCategory.DisplayMember = "CategoryName";
            this.cmbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(180, 79);
            this.cmbCategory.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(137, 24);
            this.cmbCategory.TabIndex = 22;
            this.cmbCategory.ValueMember = "CategoryId";
            // 
            // tblMaterialCategoryBindingSource1
            // 
            this.tblMaterialCategoryBindingSource1.DataMember = "tblMaterialCategory";
            this.tblMaterialCategoryBindingSource1.DataSource = this.lexletsdatabaseDataSet1;
            // 
            // lexletsdatabaseDataSet1
            // 
            this.lexletsdatabaseDataSet1.DataSetName = "lexletsdatabaseDataSet1";
            this.lexletsdatabaseDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImage.ForeColor = System.Drawing.Color.Red;
            this.lblImage.Location = new System.Drawing.Point(474, 144);
            this.lblImage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(122, 17);
            this.lblImage.TabIndex = 6;
            this.lblImage.Text = "Please Add Image";
            this.lblImage.Visible = false;
            // 
            // picLoadImage
            // 
            this.picLoadImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLoadImage.Location = new System.Drawing.Point(469, 79);
            this.picLoadImage.Name = "picLoadImage";
            this.picLoadImage.Size = new System.Drawing.Size(133, 133);
            this.picLoadImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLoadImage.TabIndex = 17;
            this.picLoadImage.TabStop = false;
            // 
            // txtImagePath
            // 
            this.txtImagePath.Location = new System.Drawing.Point(477, 250);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(125, 30);
            this.txtImagePath.TabIndex = 19;
            this.txtImagePath.Visible = false;
           
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.ForeColor = System.Drawing.Color.Red;
            this.lblSize.Location = new System.Drawing.Point(226, 257);
            this.lblSize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(156, 17);
            this.lblSize.TabIndex = 5;
            this.lblSize.Text = "Please Enter A Number";
            this.lblSize.Visible = false;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionTextBox.ForeColor = System.Drawing.Color.Black;
            this.descriptionTextBox.Location = new System.Drawing.Point(180, 139);
            this.descriptionTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(227, 23);
            this.descriptionTextBox.TabIndex = 6;
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCost.ForeColor = System.Drawing.Color.Red;
            this.lblCost.Location = new System.Drawing.Point(226, 229);
            this.lblCost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(156, 17);
            this.lblCost.TabIndex = 4;
            this.lblCost.Text = "Please Enter A Number";
            this.lblCost.Visible = false;
            // 
            // lblLowLevel
            // 
            this.lblLowLevel.AutoSize = true;
            this.lblLowLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowLevel.ForeColor = System.Drawing.Color.Red;
            this.lblLowLevel.Location = new System.Drawing.Point(226, 199);
            this.lblLowLevel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLowLevel.Name = "lblLowLevel";
            this.lblLowLevel.Size = new System.Drawing.Size(156, 17);
            this.lblLowLevel.TabIndex = 3;
            this.lblLowLevel.Text = "Please Enter A Number";
            this.lblLowLevel.Visible = false;
            // 
            // qTYinStockTextBox
            // 
            this.qTYinStockTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qTYinStockTextBox.ForeColor = System.Drawing.Color.Black;
            this.qTYinStockTextBox.Location = new System.Drawing.Point(180, 168);
            this.qTYinStockTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.qTYinStockTextBox.Name = "qTYinStockTextBox";
            this.qTYinStockTextBox.Size = new System.Drawing.Size(42, 23);
            this.qTYinStockTextBox.TabIndex = 8;
            // 
            // lblQTY
            // 
            this.lblQTY.AutoSize = true;
            this.lblQTY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQTY.ForeColor = System.Drawing.Color.Red;
            this.lblQTY.Location = new System.Drawing.Point(226, 170);
            this.lblQTY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQTY.Name = "lblQTY";
            this.lblQTY.Size = new System.Drawing.Size(156, 17);
            this.lblQTY.TabIndex = 2;
            this.lblQTY.Text = "Please Enter A Number";
            this.lblQTY.Visible = false;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.ForeColor = System.Drawing.Color.Red;
            this.lblCategory.Location = new System.Drawing.Point(321, 84);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(125, 17);
            this.lblCategory.TabIndex = 1;
            this.lblCategory.Text = "Incorrect Selection";
            this.lblCategory.Visible = false;
            // 
            // lowLevelWarningTextBox
            // 
            this.lowLevelWarningTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lowLevelWarningTextBox.ForeColor = System.Drawing.Color.Black;
            this.lowLevelWarningTextBox.Location = new System.Drawing.Point(180, 197);
            this.lowLevelWarningTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.lowLevelWarningTextBox.Name = "lowLevelWarningTextBox";
            this.lowLevelWarningTextBox.Size = new System.Drawing.Size(42, 23);
            this.lowLevelWarningTextBox.TabIndex = 10;
            // 
            // cmbColour
            // 
            this.cmbColour.DataSource = this.tblColoursBindingSource;
            this.cmbColour.DisplayMember = "ColourName";
            this.cmbColour.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbColour.FormattingEnabled = true;
            this.cmbColour.Location = new System.Drawing.Point(180, 109);
            this.cmbColour.Margin = new System.Windows.Forms.Padding(2);
            this.cmbColour.Name = "cmbColour";
            this.cmbColour.Size = new System.Drawing.Size(137, 24);
            this.cmbColour.TabIndex = 0;
            this.cmbColour.ValueMember = "ColourId";
            // 
            // tblColoursBindingSource
            // 
            this.tblColoursBindingSource.DataMember = "tblColours";
            this.tblColoursBindingSource.DataSource = this.lexletsdatabaseDataSet;
            // 
            // sizeonBraceletTextBox
            // 
            this.sizeonBraceletTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizeonBraceletTextBox.ForeColor = System.Drawing.Color.Black;
            this.sizeonBraceletTextBox.Location = new System.Drawing.Point(180, 255);
            this.sizeonBraceletTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.sizeonBraceletTextBox.Name = "sizeonBraceletTextBox";
            this.sizeonBraceletTextBox.Size = new System.Drawing.Size(42, 23);
            this.sizeonBraceletTextBox.TabIndex = 14;
            // 
            // costPerItemTextBox
            // 
            this.costPerItemTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.costPerItemTextBox.ForeColor = System.Drawing.Color.Black;
            this.costPerItemTextBox.Location = new System.Drawing.Point(180, 226);
            this.costPerItemTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.costPerItemTextBox.Name = "costPerItemTextBox";
            this.costPerItemTextBox.Size = new System.Drawing.Size(42, 23);
            this.costPerItemTextBox.TabIndex = 12;
            // 
            // tblSuppliersBindingSource1
            // 
            this.tblSuppliersBindingSource1.DataMember = "tblSuppliers";
            this.tblSuppliersBindingSource1.DataSource = this.lexletsdatabaseDataSet1;
            // 
            // tblSuppliersBindingSource
            // 
            this.tblSuppliersBindingSource.DataMember = "tblSuppliers";
            this.tblSuppliersBindingSource.DataSource = this.lexletsdatabaseDataSet;
            // 
            // tblMaterialCategoryBindingSource
            // 
            this.tblMaterialCategoryBindingSource.DataMember = "tblMaterialCategory";
            this.tblMaterialCategoryBindingSource.DataSource = this.lexletsdatabaseDataSet;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(9, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 427);
            this.panel1.TabIndex = 21;
            // 
            // tblMaterialCategoryTableAdapter
            // 
            this.tblMaterialCategoryTableAdapter.ClearBeforeFill = true;
            // 
            // tblColoursTableAdapter
            // 
            this.tblColoursTableAdapter.ClearBeforeFill = true;
            // 
            // tblSuppliersTableAdapter
            // 
            this.tblSuppliersTableAdapter.ClearBeforeFill = true;
            // 
            // tblMaterialCategoryTableAdapter1
            // 
            this.tblMaterialCategoryTableAdapter1.ClearBeforeFill = true;
            // 
            // tblSuppliersTableAdapter1
            // 
            this.tblSuppliersTableAdapter1.ClearBeforeFill = true;
            // 
            // Frmaddmaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(866, 449);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Frmaddmaterial";
            this.Text = "frmaddmaterial";
            this.Load += new System.EventHandler(this.Frmaddmaterial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lexletsdatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMaterialsBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblMaterialCategoryBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lexletsdatabaseDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoadImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblColoursBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSuppliersBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSuppliersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMaterialCategoryBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private lexletsdatabaseDataSet lexletsdatabaseDataSet;
        private System.Windows.Forms.BindingSource tblMaterialsBindingSource;
        private lexletsdatabaseDataSetTableAdapters.tblMaterialsTableAdapter tblMaterialsTableAdapter;
        private lexletsdatabaseDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Button btnloadimage;
        private System.Windows.Forms.TextBox materialIdTextBox;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.PictureBox picLoadImage;
        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label lblLowLevel;
        private System.Windows.Forms.TextBox qTYinStockTextBox;
        private System.Windows.Forms.Label lblQTY;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox lowLevelWarningTextBox;
        private System.Windows.Forms.ComboBox cmbColour;
        private System.Windows.Forms.TextBox sizeonBraceletTextBox;
        private System.Windows.Forms.TextBox costPerItemTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.BindingSource tblMaterialCategoryBindingSource;
        private lexletsdatabaseDataSetTableAdapters.tblMaterialCategoryTableAdapter tblMaterialCategoryTableAdapter;
        private System.Windows.Forms.BindingSource tblColoursBindingSource;
        private lexletsdatabaseDataSetTableAdapters.tblColoursTableAdapter tblColoursTableAdapter;
        private System.Windows.Forms.BindingSource tblSuppliersBindingSource;
        private lexletsdatabaseDataSetTableAdapters.tblSuppliersTableAdapter tblSuppliersTableAdapter;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblColour;
        private lexletsdatabaseDataSet1 lexletsdatabaseDataSet1;
        private System.Windows.Forms.BindingSource tblMaterialCategoryBindingSource1;
        private lexletsdatabaseDataSet1TableAdapters.tblMaterialCategoryTableAdapter tblMaterialCategoryTableAdapter1;
        private System.Windows.Forms.BindingSource tblSuppliersBindingSource1;
        private lexletsdatabaseDataSet1TableAdapters.tblSuppliersTableAdapter tblSuppliersTableAdapter1;
    }
}