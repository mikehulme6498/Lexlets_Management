namespace LexLetsManagement
{
    partial class FrmViewAllMaterials
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lexletsdatabaseDataSet = new LexLetsManagement.lexletsdatabaseDataSet();
            this.tblMaterialsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblMaterialsTableAdapter = new LexLetsManagement.lexletsdatabaseDataSetTableAdapters.tblMaterialsTableAdapter();
            this.tableAdapterManager = new LexLetsManagement.lexletsdatabaseDataSetTableAdapters.TableAdapterManager();
            this.DataGridMaterials = new System.Windows.Forms.DataGridView();
            this.chkLowLevel = new System.Windows.Forms.CheckBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCheck = new System.Windows.Forms.TextBox();
            this.listSKU = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.BtnCreateJson = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lexletsdatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMaterialsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridMaterials)).BeginInit();
            this.SuspendLayout();
            // 
            // lexletsdatabaseDataSet
            // 
            this.lexletsdatabaseDataSet.DataSetName = "lexletsdatabaseDataSet";
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
            // DataGridMaterials
            // 
            this.DataGridMaterials.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridMaterials.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridMaterials.Location = new System.Drawing.Point(57, 81);
            this.DataGridMaterials.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DataGridMaterials.Name = "DataGridMaterials";
            this.DataGridMaterials.RowHeadersWidth = 51;
            this.DataGridMaterials.RowTemplate.Height = 24;
            this.DataGridMaterials.Size = new System.Drawing.Size(1109, 679);
            this.DataGridMaterials.TabIndex = 0;
            this.DataGridMaterials.DataSourceChanged += new System.EventHandler(this.DataGridMaterials_DataSourceChanged);
            // 
            // chkLowLevel
            // 
            this.chkLowLevel.AutoSize = true;
            this.chkLowLevel.Location = new System.Drawing.Point(57, 28);
            this.chkLowLevel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkLowLevel.Name = "chkLowLevel";
            this.chkLowLevel.Size = new System.Drawing.Size(203, 21);
            this.chkLowLevel.TabIndex = 1;
            this.chkLowLevel.Text = "Show Low Level Stock Only";
            this.chkLowLevel.UseVisualStyleBackColor = true;
            this.chkLowLevel.CheckedChanged += new System.EventHandler(this.ChkLowLevel_CheckedChanged);
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.DarkOrange;
            this.BtnCancel.ForeColor = System.Drawing.Color.White;
            this.BtnCancel.Location = new System.Drawing.Point(1336, 784);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(149, 39);
            this.BtnCancel.TabIndex = 30;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(1157, 784);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 28);
            this.button1.TabIndex = 31;
            this.button1.Text = "Reset to 100";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1311, 122);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 33;
            this.button2.Text = "Check";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1188, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 17);
            this.label1.TabIndex = 34;
            this.label1.Text = "Enter Material Number To Check What SKU It is in";
            // 
            // txtCheck
            // 
            this.txtCheck.Location = new System.Drawing.Point(1191, 122);
            this.txtCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCheck.Name = "txtCheck";
            this.txtCheck.Size = new System.Drawing.Size(100, 22);
            this.txtCheck.TabIndex = 35;
            // 
            // listSKU
            // 
            this.listSKU.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listSKU.BackColor = System.Drawing.SystemColors.Control;
            this.listSKU.HideSelection = false;
            this.listSKU.Location = new System.Drawing.Point(1191, 159);
            this.listSKU.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listSKU.Name = "listSKU";
            this.listSKU.Size = new System.Drawing.Size(321, 290);
            this.listSKU.TabIndex = 36;
            this.listSKU.UseCompatibleStateImageBehavior = false;
            this.listSKU.View = System.Windows.Forms.View.List;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(801, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 17);
            this.label2.TabIndex = 37;
            this.label2.Text = "Cost Of All Materials : ";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Location = new System.Drawing.Point(944, 32);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(36, 17);
            this.lblTotalCost.TabIndex = 38;
            this.lblTotalCost.Text = "Cost";
            // 
            // BtnCreateJson
            // 
            this.BtnCreateJson.Location = new System.Drawing.Point(1189, 513);
            this.BtnCreateJson.Name = "BtnCreateJson";
            this.BtnCreateJson.Size = new System.Drawing.Size(165, 41);
            this.BtnCreateJson.TabIndex = 39;
            this.BtnCreateJson.Text = "Create JSON";
            this.BtnCreateJson.UseVisualStyleBackColor = true;
            this.BtnCreateJson.Visible = false;
            this.BtnCreateJson.Click += new System.EventHandler(this.BtnCreateJson_Click);
            // 
            // FrmViewAllMaterials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1545, 921);
            this.Controls.Add(this.BtnCreateJson);
            this.Controls.Add(this.lblTotalCost);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listSKU);
            this.Controls.Add(this.txtCheck);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.chkLowLevel);
            this.Controls.Add(this.DataGridMaterials);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmViewAllMaterials";
            this.Text = "View All Materials";
            this.Load += new System.EventHandler(this.Testform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lexletsdatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMaterialsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridMaterials)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private lexletsdatabaseDataSet lexletsdatabaseDataSet;
        private System.Windows.Forms.BindingSource tblMaterialsBindingSource;
        private lexletsdatabaseDataSetTableAdapters.tblMaterialsTableAdapter tblMaterialsTableAdapter;
        private lexletsdatabaseDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView DataGridMaterials;
        private System.Windows.Forms.CheckBox chkLowLevel;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCheck;
        private System.Windows.Forms.ListView listSKU;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.Button BtnCreateJson;
    }
}