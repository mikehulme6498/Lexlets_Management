using System;

namespace LexLetsManagement
{
    partial class FrmViewAllProducts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BtnClose = new System.Windows.Forms.Button();
            this.flowLayoutPanelItemsDetailed = new System.Windows.Forms.FlowLayoutPanel();
            this.radioList = new System.Windows.Forms.RadioButton();
            this.radioDetailed = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(67, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(932, 552);
            this.dataGridView1.TabIndex = 0;
            // 
            // BtnClose
            // 
            this.BtnClose.BackColor = System.Drawing.Color.DarkOrange;
            this.BtnClose.ForeColor = System.Drawing.Color.White;
            this.BtnClose.Location = new System.Drawing.Point(936, 674);
            this.BtnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(112, 32);
            this.BtnClose.TabIndex = 30;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // flowLayoutPanelItemsDetailed
            // 
            this.flowLayoutPanelItemsDetailed.AutoScroll = true;
            this.flowLayoutPanelItemsDetailed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelItemsDetailed.Location = new System.Drawing.Point(9, 72);
            this.flowLayoutPanelItemsDetailed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flowLayoutPanelItemsDetailed.Name = "flowLayoutPanelItemsDetailed";
            this.flowLayoutPanelItemsDetailed.Size = new System.Drawing.Size(1086, 564);
            this.flowLayoutPanelItemsDetailed.TabIndex = 32;
            this.flowLayoutPanelItemsDetailed.Visible = false;
            // 
            // radioList
            // 
            this.radioList.AutoSize = true;
            this.radioList.Checked = true;
            this.radioList.Location = new System.Drawing.Point(10, 21);
            this.radioList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioList.Name = "radioList";
            this.radioList.Size = new System.Drawing.Size(67, 17);
            this.radioList.TabIndex = 34;
            this.radioList.TabStop = true;
            this.radioList.Text = "List View";
            this.radioList.UseVisualStyleBackColor = true;
            this.radioList.CheckedChanged += new System.EventHandler(this.radioList_CheckedChanged);
            // 
            // radioDetailed
            // 
            this.radioDetailed.AutoSize = true;
            this.radioDetailed.Location = new System.Drawing.Point(87, 21);
            this.radioDetailed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioDetailed.Name = "radioDetailed";
            this.radioDetailed.Size = new System.Drawing.Size(90, 17);
            this.radioDetailed.TabIndex = 35;
            this.radioDetailed.Text = "Detailed View";
            this.radioDetailed.UseVisualStyleBackColor = true;
            
            // 
            
            // FrmViewAllProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1095, 714);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.radioDetailed);
            this.Controls.Add(this.radioList);
            this.Controls.Add(this.flowLayoutPanelItemsDetailed);
            this.Controls.Add(this.BtnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmViewAllProducts";
            this.Text = "ViewAllProducts";
            this.Load += new System.EventHandler(this.ViewAllProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    

        #endregion
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.RadioButton radioList;
        private System.Windows.Forms.RadioButton radioDetailed;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanelItemsDetailed;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}