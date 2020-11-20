namespace LexLetsManagement
{
    partial class FrmYearlyOverview
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
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.radYear = new System.Windows.Forms.RadioButton();
            this.radDates = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSerachType = new System.Windows.Forms.Label();
            this.pnlToFrom = new System.Windows.Forms.Panel();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.flHeadings = new System.Windows.Forms.FlowLayoutPanel();
            this.fltotal = new System.Windows.Forms.FlowLayoutPanel();
            this.fl12 = new System.Windows.Forms.FlowLayoutPanel();
            this.fl11 = new System.Windows.Forms.FlowLayoutPanel();
            this.fl10 = new System.Windows.Forms.FlowLayoutPanel();
            this.fl9 = new System.Windows.Forms.FlowLayoutPanel();
            this.fl8 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.fl7 = new System.Windows.Forms.FlowLayoutPanel();
            this.fl6 = new System.Windows.Forms.FlowLayoutPanel();
            this.fl5 = new System.Windows.Forms.FlowLayoutPanel();
            this.fl4 = new System.Windows.Forms.FlowLayoutPanel();
            this.fl3 = new System.Windows.Forms.FlowLayoutPanel();
            this.fl2 = new System.Windows.Forms.FlowLayoutPanel();
            this.fl1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.pnlToFrom.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbYear
            // 
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(84, 69);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(121, 24);
            this.cmbYear.TabIndex = 0;
            this.cmbYear.SelectedValueChanged += new System.EventHandler(this.cmbYear_SelectedValueChanged);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(84, 71);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 22);
            this.dtpFrom.TabIndex = 1;
            this.dtpFrom.Visible = false;
            // 
            // radYear
            // 
            this.radYear.AutoSize = true;
            this.radYear.Checked = true;
            this.radYear.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radYear.ForeColor = System.Drawing.Color.Black;
            this.radYear.Location = new System.Drawing.Point(18, 41);
            this.radYear.Name = "radYear";
            this.radYear.Size = new System.Drawing.Size(88, 23);
            this.radYear.TabIndex = 3;
            this.radYear.TabStop = true;
            this.radYear.Text = "By Year";
            this.radYear.UseVisualStyleBackColor = true;
            this.radYear.CheckedChanged += new System.EventHandler(this.radYear_CheckedChanged);
            // 
            // radDates
            // 
            this.radDates.AutoSize = true;
            this.radDates.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDates.ForeColor = System.Drawing.Color.Black;
            this.radDates.Location = new System.Drawing.Point(18, 76);
            this.radDates.Name = "radDates";
            this.radDates.Size = new System.Drawing.Size(252, 23);
            this.radDates.TabIndex = 4;
            this.radDates.Text = "From Specific Month and Year";
            this.radDates.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radYear);
            this.groupBox1.Controls.Add(this.radDates);
            this.groupBox1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox1.Location = new System.Drawing.Point(33, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 111);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "View 12 Month Period By";
            // 
            // lblSerachType
            // 
            this.lblSerachType.AutoSize = true;
            this.lblSerachType.Location = new System.Drawing.Point(3, 72);
            this.lblSerachType.Name = "lblSerachType";
            this.lblSerachType.Size = new System.Drawing.Size(48, 17);
            this.lblSerachType.TabIndex = 6;
            this.lblSerachType.Text = "From :";
            this.lblSerachType.Click += new System.EventHandler(this.lblSerachType_Click);
            // 
            // pnlToFrom
            // 
            this.pnlToFrom.Controls.Add(this.lblSerachType);
            this.pnlToFrom.Controls.Add(this.dtpFrom);
            this.pnlToFrom.Controls.Add(this.cmbYear);
            this.pnlToFrom.Location = new System.Drawing.Point(379, 24);
            this.pnlToFrom.Name = "pnlToFrom";
            this.pnlToFrom.Size = new System.Drawing.Size(297, 99);
            this.pnlToFrom.TabIndex = 8;
            // 
            // pnlDetails
            // 
            this.pnlDetails.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetails.Controls.Add(this.flHeadings);
            this.pnlDetails.Controls.Add(this.fltotal);
            this.pnlDetails.Controls.Add(this.fl12);
            this.pnlDetails.Controls.Add(this.fl11);
            this.pnlDetails.Controls.Add(this.fl10);
            this.pnlDetails.Controls.Add(this.fl9);
            this.pnlDetails.Controls.Add(this.fl8);
            this.pnlDetails.Controls.Add(this.panel6);
            this.pnlDetails.Controls.Add(this.fl7);
            this.pnlDetails.Controls.Add(this.fl6);
            this.pnlDetails.Controls.Add(this.fl5);
            this.pnlDetails.Controls.Add(this.fl4);
            this.pnlDetails.Controls.Add(this.fl3);
            this.pnlDetails.Controls.Add(this.fl2);
            this.pnlDetails.Controls.Add(this.fl1);
            this.pnlDetails.Location = new System.Drawing.Point(13, 149);
            this.pnlDetails.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(1399, 693);
            this.pnlDetails.TabIndex = 9;
            this.pnlDetails.Visible = false;
            // 
            // flHeadings
            // 
            this.flHeadings.Location = new System.Drawing.Point(3, 64);
            this.flHeadings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flHeadings.Name = "flHeadings";
            this.flHeadings.Size = new System.Drawing.Size(223, 583);
            this.flHeadings.TabIndex = 32;
            // 
            // fltotal
            // 
            this.fltotal.Location = new System.Drawing.Point(1289, 64);
            this.fltotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fltotal.Name = "fltotal";
            this.fltotal.Size = new System.Drawing.Size(87, 583);
            this.fltotal.TabIndex = 33;
            // 
            // fl12
            // 
            this.fl12.Location = new System.Drawing.Point(1203, 64);
            this.fl12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fl12.Name = "fl12";
            this.fl12.Size = new System.Drawing.Size(87, 583);
            this.fl12.TabIndex = 33;
            // 
            // fl11
            // 
            this.fl11.Location = new System.Drawing.Point(1116, 64);
            this.fl11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fl11.Name = "fl11";
            this.fl11.Size = new System.Drawing.Size(87, 583);
            this.fl11.TabIndex = 33;
            // 
            // fl10
            // 
            this.fl10.Location = new System.Drawing.Point(1029, 64);
            this.fl10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fl10.Name = "fl10";
            this.fl10.Size = new System.Drawing.Size(87, 583);
            this.fl10.TabIndex = 33;
            // 
            // fl9
            // 
            this.fl9.Location = new System.Drawing.Point(943, 64);
            this.fl9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fl9.Name = "fl9";
            this.fl9.Size = new System.Drawing.Size(87, 583);
            this.fl9.TabIndex = 33;
            // 
            // fl8
            // 
            this.fl8.Location = new System.Drawing.Point(856, 64);
            this.fl8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fl8.Name = "fl8";
            this.fl8.Size = new System.Drawing.Size(87, 583);
            this.fl8.TabIndex = 33;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.SteelBlue;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.lblDate);
            this.panel6.Location = new System.Drawing.Point(0, -1);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1398, 49);
            this.panel6.TabIndex = 3;
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.SteelBlue;
            this.lblDate.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(-2, 8);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(1399, 33);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Date";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fl7
            // 
            this.fl7.Location = new System.Drawing.Point(769, 64);
            this.fl7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fl7.Name = "fl7";
            this.fl7.Size = new System.Drawing.Size(87, 583);
            this.fl7.TabIndex = 33;
            // 
            // fl6
            // 
            this.fl6.Location = new System.Drawing.Point(683, 64);
            this.fl6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fl6.Name = "fl6";
            this.fl6.Size = new System.Drawing.Size(87, 583);
            this.fl6.TabIndex = 33;
            // 
            // fl5
            // 
            this.fl5.Location = new System.Drawing.Point(596, 64);
            this.fl5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fl5.Name = "fl5";
            this.fl5.Size = new System.Drawing.Size(87, 583);
            this.fl5.TabIndex = 33;
            // 
            // fl4
            // 
            this.fl4.Location = new System.Drawing.Point(509, 64);
            this.fl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fl4.Name = "fl4";
            this.fl4.Size = new System.Drawing.Size(87, 583);
            this.fl4.TabIndex = 33;
            // 
            // fl3
            // 
            this.fl3.Location = new System.Drawing.Point(423, 64);
            this.fl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fl3.Name = "fl3";
            this.fl3.Size = new System.Drawing.Size(87, 583);
            this.fl3.TabIndex = 33;
            // 
            // fl2
            // 
            this.fl2.Location = new System.Drawing.Point(336, 64);
            this.fl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fl2.Name = "fl2";
            this.fl2.Size = new System.Drawing.Size(87, 583);
            this.fl2.TabIndex = 32;
            // 
            // fl1
            // 
            this.fl1.Location = new System.Drawing.Point(249, 64);
            this.fl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fl1.Name = "fl1";
            this.fl1.Size = new System.Drawing.Size(87, 583);
            this.fl1.TabIndex = 31;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(697, 97);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.BackColor = System.Drawing.Color.DarkOrange;
            this.BtnClose.ForeColor = System.Drawing.Color.White;
            this.BtnClose.Location = new System.Drawing.Point(1128, 848);
            this.BtnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(149, 39);
            this.BtnClose.TabIndex = 31;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // FrmYearlyOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1536, 926);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.pnlToFrom);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmYearlyOverview";
            this.Text = "FYealry Overview";
            this.Load += new System.EventHandler(this.FrmYearlyOverview_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlToFrom.ResumeLayout(false);
            this.pnlToFrom.PerformLayout();
            this.pnlDetails.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.RadioButton radYear;
        private System.Windows.Forms.RadioButton radDates;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSerachType;
        private System.Windows.Forms.Panel pnlToFrom;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.FlowLayoutPanel fltotal;
        private System.Windows.Forms.FlowLayoutPanel fl12;
        private System.Windows.Forms.FlowLayoutPanel fl11;
        private System.Windows.Forms.FlowLayoutPanel fl10;
        private System.Windows.Forms.FlowLayoutPanel fl9;
        private System.Windows.Forms.FlowLayoutPanel fl8;
        private System.Windows.Forms.FlowLayoutPanel fl7;
        private System.Windows.Forms.FlowLayoutPanel fl6;
        private System.Windows.Forms.FlowLayoutPanel fl5;
        private System.Windows.Forms.FlowLayoutPanel fl4;
        private System.Windows.Forms.FlowLayoutPanel fl3;
        private System.Windows.Forms.FlowLayoutPanel fl2;
        private System.Windows.Forms.FlowLayoutPanel fl1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.FlowLayoutPanel flHeadings;
    }
}