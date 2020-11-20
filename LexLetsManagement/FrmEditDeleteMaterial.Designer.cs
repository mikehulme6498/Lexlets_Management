namespace LexLetsManagement
{
    partial class FrmEditDeleteMaterial
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
            System.Windows.Forms.Label materialIdLabel;
            System.Windows.Forms.Label categoryLabel;
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label qTYinStockLabel;
            System.Windows.Forms.Label lowLevelWarningLabel;
            System.Windows.Forms.Label costPerItemLabel;
            System.Windows.Forms.Label sizeonBraceletLabel;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label lblsupplier;
            this.materialIdTextBox = new System.Windows.Forms.TextBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.qTYinStockTextBox = new System.Windows.Forms.TextBox();
            this.lowLevelWarningTextBox = new System.Windows.Forms.TextBox();
            this.costPerItemTextBox = new System.Windows.Forms.TextBox();
            this.sizeonBraceletTextBox = new System.Windows.Forms.TextBox();
            this.gbxEditMaterial = new System.Windows.Forms.GroupBox();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.tblSuppliersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lexletsdatabaseDataSet = new LexLetsManagement.lexletsdatabaseDataSet();
            this.cmbColour = new System.Windows.Forms.ComboBox();
            this.tblColoursBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnloadimage = new System.Windows.Forms.Button();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.picLoadImage = new System.Windows.Forms.PictureBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.gbxFindMaterial = new System.Windows.Forms.GroupBox();
            this.dataGridEditMaterial = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtByDesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtByMatID = new System.Windows.Forms.TextBox();
            this.tblColoursTableAdapter = new LexLetsManagement.lexletsdatabaseDataSetTableAdapters.tblColoursTableAdapter();
            this.tblSuppliersTableAdapter = new LexLetsManagement.lexletsdatabaseDataSetTableAdapters.tblSuppliersTableAdapter();
            this.btnChange = new System.Windows.Forms.Button();
            materialIdLabel = new System.Windows.Forms.Label();
            categoryLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            qTYinStockLabel = new System.Windows.Forms.Label();
            lowLevelWarningLabel = new System.Windows.Forms.Label();
            costPerItemLabel = new System.Windows.Forms.Label();
            sizeonBraceletLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            lblsupplier = new System.Windows.Forms.Label();
            this.gbxEditMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblSuppliersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lexletsdatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblColoursBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoadImage)).BeginInit();
            this.gbxFindMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEditMaterial)).BeginInit();
            this.SuspendLayout();
            // 
            // materialIdLabel
            // 
            materialIdLabel.AutoSize = true;
            materialIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            materialIdLabel.ForeColor = System.Drawing.Color.Black;
            materialIdLabel.Location = new System.Drawing.Point(111, 55);
            materialIdLabel.Name = "materialIdLabel";
            materialIdLabel.Size = new System.Drawing.Size(77, 17);
            materialIdLabel.TabIndex = 22;
            materialIdLabel.Text = "Material Id:";
            // 
            // categoryLabel
            // 
            categoryLabel.AutoSize = true;
            categoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            categoryLabel.ForeColor = System.Drawing.Color.Black;
            categoryLabel.Location = new System.Drawing.Point(120, 82);
            categoryLabel.Name = "categoryLabel";
            categoryLabel.Size = new System.Drawing.Size(69, 17);
            categoryLabel.TabIndex = 24;
            categoryLabel.Text = "Category:";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            descriptionLabel.ForeColor = System.Drawing.Color.Black;
            descriptionLabel.Location = new System.Drawing.Point(105, 140);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(83, 17);
            descriptionLabel.TabIndex = 25;
            descriptionLabel.Text = "Description:";
            // 
            // qTYinStockLabel
            // 
            qTYinStockLabel.AutoSize = true;
            qTYinStockLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            qTYinStockLabel.ForeColor = System.Drawing.Color.Black;
            qTYinStockLabel.Location = new System.Drawing.Point(95, 170);
            qTYinStockLabel.Name = "qTYinStockLabel";
            qTYinStockLabel.Size = new System.Drawing.Size(91, 17);
            qTYinStockLabel.TabIndex = 27;
            qTYinStockLabel.Text = "QTYin Stock:";
            // 
            // lowLevelWarningLabel
            // 
            lowLevelWarningLabel.AutoSize = true;
            lowLevelWarningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lowLevelWarningLabel.ForeColor = System.Drawing.Color.Black;
            lowLevelWarningLabel.Location = new System.Drawing.Point(53, 196);
            lowLevelWarningLabel.Name = "lowLevelWarningLabel";
            lowLevelWarningLabel.Size = new System.Drawing.Size(132, 17);
            lowLevelWarningLabel.TabIndex = 29;
            lowLevelWarningLabel.Text = "Low Level Warning:";
            // 
            // costPerItemLabel
            // 
            costPerItemLabel.AutoSize = true;
            costPerItemLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            costPerItemLabel.ForeColor = System.Drawing.Color.Black;
            costPerItemLabel.Location = new System.Drawing.Point(92, 224);
            costPerItemLabel.Name = "costPerItemLabel";
            costPerItemLabel.Size = new System.Drawing.Size(96, 17);
            costPerItemLabel.TabIndex = 31;
            costPerItemLabel.Text = "Cost Per Item:";
            // 
            // sizeonBraceletLabel
            // 
            sizeonBraceletLabel.AutoSize = true;
            sizeonBraceletLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sizeonBraceletLabel.ForeColor = System.Drawing.Color.Black;
            sizeonBraceletLabel.Location = new System.Drawing.Point(40, 252);
            sizeonBraceletLabel.Name = "sizeonBraceletLabel";
            sizeonBraceletLabel.Size = new System.Drawing.Size(151, 17);
            sizeonBraceletLabel.TabIndex = 33;
            sizeonBraceletLabel.Text = "Size on Bracelet (mm):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.ForeColor = System.Drawing.Color.Black;
            label3.Location = new System.Drawing.Point(120, 112);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(53, 17);
            label3.TabIndex = 37;
            label3.Text = "Colour:";
            // 
            // lblsupplier
            // 
            lblsupplier.AutoSize = true;
            lblsupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblsupplier.ForeColor = System.Drawing.Color.Black;
            lblsupplier.Location = new System.Drawing.Point(120, 282);
            lblsupplier.Name = "lblsupplier";
            lblsupplier.Size = new System.Drawing.Size(64, 17);
            lblsupplier.TabIndex = 39;
            lblsupplier.Text = "Supplier:";
            // 
            // materialIdTextBox
            // 
            this.materialIdTextBox.Enabled = false;
            this.materialIdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialIdTextBox.ForeColor = System.Drawing.Color.Black;
            this.materialIdTextBox.Location = new System.Drawing.Point(195, 50);
            this.materialIdTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.materialIdTextBox.Name = "materialIdTextBox";
            this.materialIdTextBox.Size = new System.Drawing.Size(52, 23);
            this.materialIdTextBox.TabIndex = 23;
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.DarkOrange;
            this.BtnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.ForeColor = System.Drawing.Color.White;
            this.BtnCancel.Location = new System.Drawing.Point(791, 735);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(109, 30);
            this.BtnCancel.TabIndex = 12;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Visible = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.BackColor = System.Drawing.Color.YellowGreen;
            this.BtnUpdate.Enabled = false;
            this.BtnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUpdate.ForeColor = System.Drawing.Color.White;
            this.BtnUpdate.Location = new System.Drawing.Point(905, 735);
            this.BtnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(109, 30);
            this.BtnUpdate.TabIndex = 13;
            this.BtnUpdate.Text = "Update";
            this.BtnUpdate.UseVisualStyleBackColor = false;
            this.BtnUpdate.Visible = false;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionTextBox.ForeColor = System.Drawing.Color.Black;
            this.descriptionTextBox.Location = new System.Drawing.Point(195, 137);
            this.descriptionTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(140, 23);
            this.descriptionTextBox.TabIndex = 6;
            // 
            // qTYinStockTextBox
            // 
            this.qTYinStockTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qTYinStockTextBox.ForeColor = System.Drawing.Color.Black;
            this.qTYinStockTextBox.Location = new System.Drawing.Point(195, 164);
            this.qTYinStockTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.qTYinStockTextBox.Name = "qTYinStockTextBox";
            this.qTYinStockTextBox.Size = new System.Drawing.Size(52, 23);
            this.qTYinStockTextBox.TabIndex = 7;
            // 
            // lowLevelWarningTextBox
            // 
            this.lowLevelWarningTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lowLevelWarningTextBox.ForeColor = System.Drawing.Color.Black;
            this.lowLevelWarningTextBox.Location = new System.Drawing.Point(195, 192);
            this.lowLevelWarningTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lowLevelWarningTextBox.Name = "lowLevelWarningTextBox";
            this.lowLevelWarningTextBox.Size = new System.Drawing.Size(52, 23);
            this.lowLevelWarningTextBox.TabIndex = 8;
            // 
            // costPerItemTextBox
            // 
            this.costPerItemTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.costPerItemTextBox.ForeColor = System.Drawing.Color.Black;
            this.costPerItemTextBox.Location = new System.Drawing.Point(195, 222);
            this.costPerItemTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.costPerItemTextBox.Name = "costPerItemTextBox";
            this.costPerItemTextBox.Size = new System.Drawing.Size(52, 23);
            this.costPerItemTextBox.TabIndex = 9;
            // 
            // sizeonBraceletTextBox
            // 
            this.sizeonBraceletTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizeonBraceletTextBox.ForeColor = System.Drawing.Color.Black;
            this.sizeonBraceletTextBox.Location = new System.Drawing.Point(195, 249);
            this.sizeonBraceletTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sizeonBraceletTextBox.Name = "sizeonBraceletTextBox";
            this.sizeonBraceletTextBox.Size = new System.Drawing.Size(52, 23);
            this.sizeonBraceletTextBox.TabIndex = 10;
            // 
            // gbxEditMaterial
            // 
            this.gbxEditMaterial.Controls.Add(this.cmbSupplier);
            this.gbxEditMaterial.Controls.Add(lblsupplier);
            this.gbxEditMaterial.Controls.Add(this.cmbColour);
            this.gbxEditMaterial.Controls.Add(label3);
            this.gbxEditMaterial.Controls.Add(this.materialIdTextBox);
            this.gbxEditMaterial.Controls.Add(this.btnloadimage);
            this.gbxEditMaterial.Controls.Add(this.txtImagePath);
            this.gbxEditMaterial.Controls.Add(this.picLoadImage);
            this.gbxEditMaterial.Controls.Add(this.cmbCategory);
            this.gbxEditMaterial.Controls.Add(materialIdLabel);
            this.gbxEditMaterial.Controls.Add(categoryLabel);
            this.gbxEditMaterial.Controls.Add(this.sizeonBraceletTextBox);
            this.gbxEditMaterial.Controls.Add(descriptionLabel);
            this.gbxEditMaterial.Controls.Add(sizeonBraceletLabel);
            this.gbxEditMaterial.Controls.Add(this.descriptionTextBox);
            this.gbxEditMaterial.Controls.Add(this.costPerItemTextBox);
            this.gbxEditMaterial.Controls.Add(qTYinStockLabel);
            this.gbxEditMaterial.Controls.Add(costPerItemLabel);
            this.gbxEditMaterial.Controls.Add(this.qTYinStockTextBox);
            this.gbxEditMaterial.Controls.Add(this.lowLevelWarningTextBox);
            this.gbxEditMaterial.Controls.Add(lowLevelWarningLabel);
            this.gbxEditMaterial.Enabled = false;
            this.gbxEditMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxEditMaterial.ForeColor = System.Drawing.Color.SteelBlue;
            this.gbxEditMaterial.Location = new System.Drawing.Point(25, 438);
            this.gbxEditMaterial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxEditMaterial.Name = "gbxEditMaterial";
            this.gbxEditMaterial.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxEditMaterial.Size = new System.Drawing.Size(557, 326);
            this.gbxEditMaterial.TabIndex = 22;
            this.gbxEditMaterial.TabStop = false;
            this.gbxEditMaterial.Text = "Edit / Delete Material";
            this.gbxEditMaterial.Visible = false;
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tblSuppliersBindingSource, "SupplierId", true));
            this.cmbSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSupplier.ForeColor = System.Drawing.Color.Black;
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(195, 277);
            this.cmbSupplier.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(157, 25);
            this.cmbSupplier.TabIndex = 11;
            // 
            // tblSuppliersBindingSource
            // 
            this.tblSuppliersBindingSource.DataMember = "tblSuppliers";
            this.tblSuppliersBindingSource.DataSource = this.lexletsdatabaseDataSet;
            // 
            // lexletsdatabaseDataSet
            // 
            this.lexletsdatabaseDataSet.DataSetName = "lexletsdatabaseDataSet";
            this.lexletsdatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cmbColour
            // 
            this.cmbColour.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tblColoursBindingSource, "ColourId", true));
            this.cmbColour.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbColour.ForeColor = System.Drawing.Color.Black;
            this.cmbColour.FormattingEnabled = true;
            this.cmbColour.Location = new System.Drawing.Point(195, 107);
            this.cmbColour.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbColour.Name = "cmbColour";
            this.cmbColour.Size = new System.Drawing.Size(140, 25);
            this.cmbColour.TabIndex = 5;
            // 
            // tblColoursBindingSource
            // 
            this.tblColoursBindingSource.DataMember = "tblColours";
            this.tblColoursBindingSource.DataSource = this.lexletsdatabaseDataSet;
            // 
            // btnloadimage
            // 
            this.btnloadimage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnloadimage.ForeColor = System.Drawing.Color.Black;
            this.btnloadimage.Location = new System.Drawing.Point(385, 193);
            this.btnloadimage.Margin = new System.Windows.Forms.Padding(4);
            this.btnloadimage.Name = "btnloadimage";
            this.btnloadimage.Size = new System.Drawing.Size(140, 28);
            this.btnloadimage.TabIndex = 18;
            this.btnloadimage.Text = "Change Image";
            this.btnloadimage.UseVisualStyleBackColor = true;
            this.btnloadimage.Click += new System.EventHandler(this.Btnloadimage_Click);
            // 
            // txtImagePath
            // 
            this.txtImagePath.Location = new System.Drawing.Point(344, 229);
            this.txtImagePath.Margin = new System.Windows.Forms.Padding(4);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(165, 30);
            this.txtImagePath.TabIndex = 19;
            this.txtImagePath.Visible = false;
            // 
            // picLoadImage
            // 
            this.picLoadImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLoadImage.Location = new System.Drawing.Point(372, 50);
            this.picLoadImage.Margin = new System.Windows.Forms.Padding(4);
            this.picLoadImage.Name = "picLoadImage";
            this.picLoadImage.Size = new System.Drawing.Size(165, 134);
            this.picLoadImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLoadImage.TabIndex = 35;
            this.picLoadImage.TabStop = false;
            // 
            // cmbCategory
            // 
            this.cmbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategory.ForeColor = System.Drawing.Color.Black;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(195, 78);
            this.cmbCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(140, 25);
            this.cmbCategory.TabIndex = 4;
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.Red;
            this.BtnDelete.Enabled = false;
            this.BtnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.ForeColor = System.Drawing.Color.White;
            this.BtnDelete.Location = new System.Drawing.Point(1020, 736);
            this.BtnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(109, 30);
            this.BtnDelete.TabIndex = 14;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Visible = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // gbxFindMaterial
            // 
            this.gbxFindMaterial.Controls.Add(this.dataGridEditMaterial);
            this.gbxFindMaterial.Controls.Add(this.label2);
            this.gbxFindMaterial.Controls.Add(this.TxtByDesc);
            this.gbxFindMaterial.Controls.Add(this.label1);
            this.gbxFindMaterial.Controls.Add(this.txtByMatID);
            this.gbxFindMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxFindMaterial.ForeColor = System.Drawing.Color.SteelBlue;
            this.gbxFindMaterial.Location = new System.Drawing.Point(25, 57);
            this.gbxFindMaterial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxFindMaterial.Name = "gbxFindMaterial";
            this.gbxFindMaterial.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxFindMaterial.Size = new System.Drawing.Size(917, 353);
            this.gbxFindMaterial.TabIndex = 37;
            this.gbxFindMaterial.TabStop = false;
            this.gbxFindMaterial.Text = "Find Material";
            this.gbxFindMaterial.Visible = false;
            // 
            // dataGridEditMaterial
            // 
            this.dataGridEditMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEditMaterial.Location = new System.Drawing.Point(19, 126);
            this.dataGridEditMaterial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridEditMaterial.Name = "dataGridEditMaterial";
            this.dataGridEditMaterial.RowTemplate.Height = 24;
            this.dataGridEditMaterial.Size = new System.Drawing.Size(856, 217);
            this.dataGridEditMaterial.TabIndex = 5;
            this.dataGridEditMaterial.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridEditMaterial_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(25, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "By Desription";
            // 
            // TxtByDesc
            // 
            this.TxtByDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtByDesc.Location = new System.Drawing.Point(121, 78);
            this.TxtByDesc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtByDesc.Name = "TxtByDesc";
            this.TxtByDesc.Size = new System.Drawing.Size(100, 22);
            this.TxtByDesc.TabIndex = 2;
            this.TxtByDesc.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TxtByDesc_MouseClick);
            this.TxtByDesc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtByDesc_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(25, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "By ID";
            // 
            // txtByMatID
            // 
            this.txtByMatID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtByMatID.Location = new System.Drawing.Point(121, 50);
            this.txtByMatID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtByMatID.Name = "txtByMatID";
            this.txtByMatID.Size = new System.Drawing.Size(100, 22);
            this.txtByMatID.TabIndex = 1;
            this.txtByMatID.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TxtByMatID_MouseClick);
            this.txtByMatID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtByMatID_KeyUp);
            // 
            // tblColoursTableAdapter
            // 
            this.tblColoursTableAdapter.ClearBeforeFill = true;
            // 
            // tblSuppliersTableAdapter
            // 
            this.tblSuppliersTableAdapter.ClearBeforeFill = true;
            // 
            // btnChange
            // 
            this.btnChange.BackColor = System.Drawing.Color.Yellow;
            this.btnChange.Location = new System.Drawing.Point(743, 414);
            this.btnChange.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(157, 27);
            this.btnChange.TabIndex = 42;
            this.btnChange.Text = "Change Product";
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Visible = false;
            this.btnChange.Click += new System.EventHandler(this.BtnChange_Click);
            // 
            // FrmEditDeleteMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1232, 778);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnUpdate);
            this.Controls.Add(this.gbxFindMaterial);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.gbxEditMaterial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmEditDeleteMaterial";
            this.Text = "FrmEditDeleteMaterial";
            this.Load += new System.EventHandler(this.FrmEditDeleteMaterial_Load);
            this.gbxEditMaterial.ResumeLayout(false);
            this.gbxEditMaterial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblSuppliersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lexletsdatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblColoursBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoadImage)).EndInit();
            this.gbxFindMaterial.ResumeLayout(false);
            this.gbxFindMaterial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEditMaterial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox materialIdTextBox;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.PictureBox picLoadImage;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.TextBox qTYinStockTextBox;
        private System.Windows.Forms.TextBox lowLevelWarningTextBox;
        private System.Windows.Forms.TextBox costPerItemTextBox;
        private System.Windows.Forms.TextBox sizeonBraceletTextBox;
        private System.Windows.Forms.GroupBox gbxEditMaterial;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button btnloadimage;
        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.GroupBox gbxFindMaterial;
        private System.Windows.Forms.DataGridView dataGridEditMaterial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtByDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtByMatID;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.ComboBox cmbColour;
        private lexletsdatabaseDataSet lexletsdatabaseDataSet;
        private System.Windows.Forms.BindingSource tblColoursBindingSource;
        private lexletsdatabaseDataSetTableAdapters.tblColoursTableAdapter tblColoursTableAdapter;
        private System.Windows.Forms.BindingSource tblSuppliersBindingSource;
        private lexletsdatabaseDataSetTableAdapters.tblSuppliersTableAdapter tblSuppliersTableAdapter;
        private System.Windows.Forms.Button btnChange;
    }
}