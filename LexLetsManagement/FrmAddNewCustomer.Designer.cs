namespace LexLetsManagement
{
    partial class FrmAddNewCustomer
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
            System.Windows.Forms.Label first_NameLabel;
            System.Windows.Forms.Label surnameLabel;
            System.Windows.Forms.Label address_1Label;
            System.Windows.Forms.Label address_2Label;
            System.Windows.Forms.Label postcodeLabel;
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label subscribedLabel;
            this.lexletsdatabaseDataSet = new LexLetsManagement.lexletsdatabaseDataSet();
            this.tblCustomersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblCustomersTableAdapter = new LexLetsManagement.lexletsdatabaseDataSetTableAdapters.tblCustomersTableAdapter();
            this.tableAdapterManager = new LexLetsManagement.lexletsdatabaseDataSetTableAdapters.TableAdapterManager();
            this.TxtFirstName = new System.Windows.Forms.TextBox();
            this.TxtSurName = new System.Windows.Forms.TextBox();
            this.TxtAdd1 = new System.Windows.Forms.TextBox();
            this.TxtAdd2 = new System.Windows.Forms.TextBox();
            this.TxtPostCode = new System.Windows.Forms.TextBox();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.CmbSub = new System.Windows.Forms.ComboBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PicError6 = new System.Windows.Forms.PictureBox();
            this.PicError5 = new System.Windows.Forms.PictureBox();
            this.PicError4 = new System.Windows.Forms.PictureBox();
            this.PicError3 = new System.Windows.Forms.PictureBox();
            this.PicError2 = new System.Windows.Forms.PictureBox();
            this.PicError1 = new System.Windows.Forms.PictureBox();
            this.PicError0 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            first_NameLabel = new System.Windows.Forms.Label();
            surnameLabel = new System.Windows.Forms.Label();
            address_1Label = new System.Windows.Forms.Label();
            address_2Label = new System.Windows.Forms.Label();
            postcodeLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            subscribedLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lexletsdatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCustomersBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicError6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicError5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicError4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicError3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicError2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicError1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicError0)).BeginInit();
            this.SuspendLayout();
            // 
            // first_NameLabel
            // 
            first_NameLabel.AutoSize = true;
            first_NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            first_NameLabel.ForeColor = System.Drawing.Color.Black;
            first_NameLabel.Location = new System.Drawing.Point(35, 48);
            first_NameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            first_NameLabel.Name = "first_NameLabel";
            first_NameLabel.Size = new System.Drawing.Size(60, 13);
            first_NameLabel.TabIndex = 1;
            first_NameLabel.Text = "First Name:";
            // 
            // surnameLabel
            // 
            surnameLabel.AutoSize = true;
            surnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            surnameLabel.ForeColor = System.Drawing.Color.Black;
            surnameLabel.Location = new System.Drawing.Point(44, 71);
            surnameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            surnameLabel.Name = "surnameLabel";
            surnameLabel.Size = new System.Drawing.Size(52, 13);
            surnameLabel.TabIndex = 3;
            surnameLabel.Text = "Surname:";
            // 
            // address_1Label
            // 
            address_1Label.AutoSize = true;
            address_1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            address_1Label.ForeColor = System.Drawing.Color.Black;
            address_1Label.Location = new System.Drawing.Point(38, 93);
            address_1Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            address_1Label.Name = "address_1Label";
            address_1Label.Size = new System.Drawing.Size(57, 13);
            address_1Label.TabIndex = 5;
            address_1Label.Text = "Address 1:";
            // 
            // address_2Label
            // 
            address_2Label.AutoSize = true;
            address_2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            address_2Label.ForeColor = System.Drawing.Color.Black;
            address_2Label.Location = new System.Drawing.Point(38, 116);
            address_2Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            address_2Label.Name = "address_2Label";
            address_2Label.Size = new System.Drawing.Size(57, 13);
            address_2Label.TabIndex = 7;
            address_2Label.Text = "Address 2:";
            // 
            // postcodeLabel
            // 
            postcodeLabel.AutoSize = true;
            postcodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            postcodeLabel.ForeColor = System.Drawing.Color.Black;
            postcodeLabel.Location = new System.Drawing.Point(42, 139);
            postcodeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            postcodeLabel.Name = "postcodeLabel";
            postcodeLabel.Size = new System.Drawing.Size(55, 13);
            postcodeLabel.TabIndex = 9;
            postcodeLabel.Text = "Postcode:";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            emailLabel.ForeColor = System.Drawing.Color.Black;
            emailLabel.Location = new System.Drawing.Point(61, 162);
            emailLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(35, 13);
            emailLabel.TabIndex = 11;
            emailLabel.Text = "Email:";
            // 
            // subscribedLabel
            // 
            subscribedLabel.AutoSize = true;
            subscribedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            subscribedLabel.ForeColor = System.Drawing.Color.Black;
            subscribedLabel.Location = new System.Drawing.Point(33, 184);
            subscribedLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            subscribedLabel.Name = "subscribedLabel";
            subscribedLabel.Size = new System.Drawing.Size(63, 13);
            subscribedLabel.TabIndex = 13;
            subscribedLabel.Text = "Subscribed:";
            // 
            // lexletsdatabaseDataSet
            // 
            this.lexletsdatabaseDataSet.DataSetName = "lexletsdatabaseDataSet";
            this.lexletsdatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblCustomersBindingSource
            // 
            this.tblCustomersBindingSource.DataMember = "tblCustomers";
            this.tblCustomersBindingSource.DataSource = this.lexletsdatabaseDataSet;
            // 
            // tblCustomersTableAdapter
            // 
            this.tblCustomersTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.tblCollectionContainsTableAdapter = null;
            this.tableAdapterManager.tblCollectionDataTableAdapter = null;
            this.tableAdapterManager.tblColoursTableAdapter = null;
            this.tableAdapterManager.tblCustomersTableAdapter = this.tblCustomersTableAdapter;
            this.tableAdapterManager.tblIncomeTableAdapter = null;
            this.tableAdapterManager.tblMaterialCategoryTableAdapter = null;
            this.tableAdapterManager.tblMaterialsTableAdapter = null;
            this.tableAdapterManager.tblOutgoingTableAdapter = null;
            this.tableAdapterManager.tblProductConatinsTableAdapter = null;
            this.tableAdapterManager.tblProductDataTableAdapter = null;
            this.tableAdapterManager.tblSaleItemsTableAdapter = null;
            this.tableAdapterManager.tblsalesTableAdapter = null;
            this.tableAdapterManager.tblSuppliersTableAdapter = null;
            this.tableAdapterManager.tblUsersTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = LexLetsManagement.lexletsdatabaseDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // TxtFirstName
            // 
            this.TxtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtFirstName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tblCustomersBindingSource, "First Name", true));
            this.TxtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFirstName.Location = new System.Drawing.Point(102, 46);
            this.TxtFirstName.Margin = new System.Windows.Forms.Padding(2);
            this.TxtFirstName.Name = "TxtFirstName";
            this.TxtFirstName.Size = new System.Drawing.Size(76, 19);
            this.TxtFirstName.TabIndex = 2;
            // 
            // TxtSurName
            // 
            this.TxtSurName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtSurName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tblCustomersBindingSource, "Surname", true));
            this.TxtSurName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSurName.Location = new System.Drawing.Point(102, 68);
            this.TxtSurName.Margin = new System.Windows.Forms.Padding(2);
            this.TxtSurName.Name = "TxtSurName";
            this.TxtSurName.Size = new System.Drawing.Size(76, 19);
            this.TxtSurName.TabIndex = 4;
            // 
            // TxtAdd1
            // 
            this.TxtAdd1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtAdd1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tblCustomersBindingSource, "Address 1", true));
            this.TxtAdd1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAdd1.Location = new System.Drawing.Point(102, 91);
            this.TxtAdd1.Margin = new System.Windows.Forms.Padding(2);
            this.TxtAdd1.Name = "TxtAdd1";
            this.TxtAdd1.Size = new System.Drawing.Size(76, 19);
            this.TxtAdd1.TabIndex = 6;
            // 
            // TxtAdd2
            // 
            this.TxtAdd2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtAdd2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tblCustomersBindingSource, "Address 2", true));
            this.TxtAdd2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAdd2.Location = new System.Drawing.Point(102, 114);
            this.TxtAdd2.Margin = new System.Windows.Forms.Padding(2);
            this.TxtAdd2.Name = "TxtAdd2";
            this.TxtAdd2.Size = new System.Drawing.Size(76, 19);
            this.TxtAdd2.TabIndex = 8;
            // 
            // TxtPostCode
            // 
            this.TxtPostCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPostCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tblCustomersBindingSource, "Postcode", true));
            this.TxtPostCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPostCode.Location = new System.Drawing.Point(102, 136);
            this.TxtPostCode.Margin = new System.Windows.Forms.Padding(2);
            this.TxtPostCode.Name = "TxtPostCode";
            this.TxtPostCode.Size = new System.Drawing.Size(76, 19);
            this.TxtPostCode.TabIndex = 10;
            // 
            // TxtEmail
            // 
            this.TxtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtEmail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tblCustomersBindingSource, "Email", true));
            this.TxtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEmail.Location = new System.Drawing.Point(102, 159);
            this.TxtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(76, 19);
            this.TxtEmail.TabIndex = 12;
            // 
            // CmbSub
            // 
            this.CmbSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSub.FormattingEnabled = true;
            this.CmbSub.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.CmbSub.Location = new System.Drawing.Point(102, 182);
            this.CmbSub.Margin = new System.Windows.Forms.Padding(2);
            this.CmbSub.Name = "CmbSub";
            this.CmbSub.Size = new System.Drawing.Size(49, 21);
            this.CmbSub.TabIndex = 14;
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.DarkOrange;
            this.BtnCancel.ForeColor = System.Drawing.Color.White;
            this.BtnCancel.Location = new System.Drawing.Point(8, 277);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(112, 32);
            this.BtnCancel.TabIndex = 31;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.YellowGreen;
            this.BtnSave.ForeColor = System.Drawing.Color.White;
            this.BtnSave.Location = new System.Drawing.Point(123, 277);
            this.BtnSave.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(112, 32);
            this.BtnSave.TabIndex = 30;
            this.BtnSave.Text = "Save Product";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PicError6);
            this.groupBox1.Controls.Add(this.PicError5);
            this.groupBox1.Controls.Add(this.PicError4);
            this.groupBox1.Controls.Add(this.PicError3);
            this.groupBox1.Controls.Add(this.PicError2);
            this.groupBox1.Controls.Add(this.PicError1);
            this.groupBox1.Controls.Add(this.PicError0);
            this.groupBox1.Controls.Add(first_NameLabel);
            this.groupBox1.Controls.Add(subscribedLabel);
            this.groupBox1.Controls.Add(this.TxtFirstName);
            this.groupBox1.Controls.Add(this.TxtAdd1);
            this.groupBox1.Controls.Add(surnameLabel);
            this.groupBox1.Controls.Add(this.TxtEmail);
            this.groupBox1.Controls.Add(postcodeLabel);
            this.groupBox1.Controls.Add(address_1Label);
            this.groupBox1.Controls.Add(this.TxtAdd2);
            this.groupBox1.Controls.Add(this.CmbSub);
            this.groupBox1.Controls.Add(this.TxtPostCode);
            this.groupBox1.Controls.Add(address_2Label);
            this.groupBox1.Controls.Add(this.TxtSurName);
            this.groupBox1.Controls.Add(emailLabel);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox1.Location = new System.Drawing.Point(8, 29);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(228, 244);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add New Customer";
            // 
            // PicError6
            // 
            this.PicError6.Image = global::LexLetsManagement.Properties.Resources.Error;
            this.PicError6.Location = new System.Drawing.Point(182, 184);
            this.PicError6.Margin = new System.Windows.Forms.Padding(2);
            this.PicError6.Name = "PicError6";
            this.PicError6.Size = new System.Drawing.Size(14, 15);
            this.PicError6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicError6.TabIndex = 39;
            this.PicError6.TabStop = false;
            this.PicError6.Visible = false;
            // 
            // PicError5
            // 
            this.PicError5.Image = global::LexLetsManagement.Properties.Resources.Error;
            this.PicError5.Location = new System.Drawing.Point(182, 162);
            this.PicError5.Margin = new System.Windows.Forms.Padding(2);
            this.PicError5.Name = "PicError5";
            this.PicError5.Size = new System.Drawing.Size(14, 15);
            this.PicError5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicError5.TabIndex = 38;
            this.PicError5.TabStop = false;
            this.PicError5.Visible = false;
            // 
            // PicError4
            // 
            this.PicError4.Image = global::LexLetsManagement.Properties.Resources.Error;
            this.PicError4.Location = new System.Drawing.Point(182, 139);
            this.PicError4.Margin = new System.Windows.Forms.Padding(2);
            this.PicError4.Name = "PicError4";
            this.PicError4.Size = new System.Drawing.Size(14, 15);
            this.PicError4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicError4.TabIndex = 37;
            this.PicError4.TabStop = false;
            this.PicError4.Visible = false;
            // 
            // PicError3
            // 
            this.PicError3.Image = global::LexLetsManagement.Properties.Resources.Error;
            this.PicError3.Location = new System.Drawing.Point(182, 116);
            this.PicError3.Margin = new System.Windows.Forms.Padding(2);
            this.PicError3.Name = "PicError3";
            this.PicError3.Size = new System.Drawing.Size(14, 15);
            this.PicError3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicError3.TabIndex = 36;
            this.PicError3.TabStop = false;
            this.PicError3.Visible = false;
            // 
            // PicError2
            // 
            this.PicError2.Image = global::LexLetsManagement.Properties.Resources.Error;
            this.PicError2.Location = new System.Drawing.Point(182, 93);
            this.PicError2.Margin = new System.Windows.Forms.Padding(2);
            this.PicError2.Name = "PicError2";
            this.PicError2.Size = new System.Drawing.Size(14, 15);
            this.PicError2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicError2.TabIndex = 35;
            this.PicError2.TabStop = false;
            this.PicError2.Visible = false;
            // 
            // PicError1
            // 
            this.PicError1.Image = global::LexLetsManagement.Properties.Resources.Error;
            this.PicError1.Location = new System.Drawing.Point(182, 71);
            this.PicError1.Margin = new System.Windows.Forms.Padding(2);
            this.PicError1.Name = "PicError1";
            this.PicError1.Size = new System.Drawing.Size(14, 15);
            this.PicError1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicError1.TabIndex = 34;
            this.PicError1.TabStop = false;
            this.PicError1.Visible = false;
            // 
            // PicError0
            // 
            this.PicError0.Image = global::LexLetsManagement.Properties.Resources.Error;
            this.PicError0.Location = new System.Drawing.Point(182, 48);
            this.PicError0.Margin = new System.Windows.Forms.Padding(2);
            this.PicError0.Name = "PicError0";
            this.PicError0.Size = new System.Drawing.Size(14, 15);
            this.PicError0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicError0.TabIndex = 33;
            this.PicError0.TabStop = false;
            this.PicError0.Tag = "";
            this.PicError0.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(253, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 38);
            this.button1.TabIndex = 33;
            this.button1.Text = "Remove Duplicate Customers";
            this.button1.UseVisualStyleBackColor = true;
            
            // 
            // FrmAddNewCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(817, 466);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmAddNewCustomer";
            this.Text = "FrmAddNewCustomer";
           
            ((System.ComponentModel.ISupportInitialize)(this.lexletsdatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCustomersBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicError6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicError5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicError4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicError3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicError2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicError1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicError0)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private lexletsdatabaseDataSet lexletsdatabaseDataSet;
        private System.Windows.Forms.BindingSource tblCustomersBindingSource;
        private lexletsdatabaseDataSetTableAdapters.tblCustomersTableAdapter tblCustomersTableAdapter;
        private lexletsdatabaseDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox TxtFirstName;
        private System.Windows.Forms.TextBox TxtSurName;
        private System.Windows.Forms.TextBox TxtAdd1;
        private System.Windows.Forms.TextBox TxtAdd2;
        private System.Windows.Forms.TextBox TxtPostCode;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.ComboBox CmbSub;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox PicError6;
        private System.Windows.Forms.PictureBox PicError5;
        private System.Windows.Forms.PictureBox PicError4;
        private System.Windows.Forms.PictureBox PicError3;
        private System.Windows.Forms.PictureBox PicError2;
        private System.Windows.Forms.PictureBox PicError1;
        private System.Windows.Forms.PictureBox PicError0;
        private System.Windows.Forms.Button button1;
    }
}