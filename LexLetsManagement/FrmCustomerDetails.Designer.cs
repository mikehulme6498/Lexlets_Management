namespace LexLetsManagement
{
    partial class FrmCustomerDetails
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
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.gbxDetails = new System.Windows.Forms.GroupBox();
            this.lblSubscibed = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.lblAdd1 = new System.Windows.Forms.Label();
            this.lblAdd2 = new System.Windows.Forms.Label();
            this.lblPostcode = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.gbxStats = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listViewCategorysBought = new System.Windows.Forms.ListView();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTimesBought = new System.Windows.Forms.Label();
            this.lblRefunds = new System.Windows.Forms.Label();
            this.lblItemsRefunded = new System.Windows.Forms.Label();
            this.lblSpent = new System.Windows.Forms.Label();
            this.lblItemsBought = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gbxComments = new System.Windows.Forms.GroupBox();
            this.richTextBoxComments = new System.Windows.Forms.RichTextBox();
            this.gbxInvoices = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.flowLayoutPanelInvoices = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.flowLayoutPanelRefunds = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.gbxDetails.SuspendLayout();
            this.gbxStats.SuspendLayout();
            this.gbxComments.SuspendLayout();
            this.gbxInvoices.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search Customer";
            // 
            // TxtSearch
            // 
            this.TxtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSearch.ForeColor = System.Drawing.Color.Black;
            this.TxtSearch.Location = new System.Drawing.Point(135, 26);
            this.TxtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(595, 22);
            this.TxtSearch.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(736, 26);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 22);
            this.button1.TabIndex = 4;
            this.button1.Text = "Load Customer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // gbxDetails
            // 
            this.gbxDetails.Controls.Add(this.lblSubscibed);
            this.gbxDetails.Controls.Add(this.lblId);
            this.gbxDetails.Controls.Add(this.lblAdd1);
            this.gbxDetails.Controls.Add(this.lblAdd2);
            this.gbxDetails.Controls.Add(this.lblPostcode);
            this.gbxDetails.Controls.Add(this.lblEmail);
            this.gbxDetails.Controls.Add(this.lblName);
            this.gbxDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDetails.ForeColor = System.Drawing.Color.SteelBlue;
            this.gbxDetails.Location = new System.Drawing.Point(12, 12);
            this.gbxDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxDetails.Name = "gbxDetails";
            this.gbxDetails.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxDetails.Size = new System.Drawing.Size(312, 209);
            this.gbxDetails.TabIndex = 5;
            this.gbxDetails.TabStop = false;
            this.gbxDetails.Text = "Details";
            // 
            // lblSubscibed
            // 
            this.lblSubscibed.AutoSize = true;
            this.lblSubscibed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubscibed.ForeColor = System.Drawing.Color.Black;
            this.lblSubscibed.Location = new System.Drawing.Point(8, 172);
            this.lblSubscibed.Name = "lblSubscibed";
            this.lblSubscibed.Size = new System.Drawing.Size(87, 20);
            this.lblSubscibed.TabIndex = 12;
            this.lblSubscibed.Text = "Subscibed";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.ForeColor = System.Drawing.Color.Black;
            this.lblId.Location = new System.Drawing.Point(8, 148);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(26, 20);
            this.lblId.TabIndex = 11;
            this.lblId.Text = "ID";
            // 
            // lblAdd1
            // 
            this.lblAdd1.AutoSize = true;
            this.lblAdd1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdd1.ForeColor = System.Drawing.Color.Black;
            this.lblAdd1.Location = new System.Drawing.Point(8, 54);
            this.lblAdd1.Name = "lblAdd1";
            this.lblAdd1.Size = new System.Drawing.Size(85, 20);
            this.lblAdd1.TabIndex = 10;
            this.lblAdd1.Text = "Address 1";
            // 
            // lblAdd2
            // 
            this.lblAdd2.AutoSize = true;
            this.lblAdd2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdd2.ForeColor = System.Drawing.Color.Black;
            this.lblAdd2.Location = new System.Drawing.Point(8, 76);
            this.lblAdd2.Name = "lblAdd2";
            this.lblAdd2.Size = new System.Drawing.Size(85, 20);
            this.lblAdd2.TabIndex = 9;
            this.lblAdd2.Text = "Address 2";
            // 
            // lblPostcode
            // 
            this.lblPostcode.AutoSize = true;
            this.lblPostcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostcode.ForeColor = System.Drawing.Color.Black;
            this.lblPostcode.Location = new System.Drawing.Point(8, 98);
            this.lblPostcode.Name = "lblPostcode";
            this.lblPostcode.Size = new System.Drawing.Size(79, 20);
            this.lblPostcode.TabIndex = 8;
            this.lblPostcode.Text = "Postcode";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.Black;
            this.lblEmail.Location = new System.Drawing.Point(8, 121);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(51, 20);
            this.lblEmail.TabIndex = 7;
            this.lblEmail.Text = "Email";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(8, 32);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 20);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Name";
            // 
            // gbxStats
            // 
            this.gbxStats.Controls.Add(this.label2);
            this.gbxStats.Controls.Add(this.listViewCategorysBought);
            this.gbxStats.Controls.Add(this.label11);
            this.gbxStats.Controls.Add(this.lblTimesBought);
            this.gbxStats.Controls.Add(this.lblRefunds);
            this.gbxStats.Controls.Add(this.lblItemsRefunded);
            this.gbxStats.Controls.Add(this.lblSpent);
            this.gbxStats.Controls.Add(this.lblItemsBought);
            this.gbxStats.Controls.Add(this.label24);
            this.gbxStats.Controls.Add(this.label3);
            this.gbxStats.Controls.Add(this.label4);
            this.gbxStats.Controls.Add(this.label5);
            this.gbxStats.Controls.Add(this.label7);
            this.gbxStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxStats.ForeColor = System.Drawing.Color.SteelBlue;
            this.gbxStats.Location = new System.Drawing.Point(355, 12);
            this.gbxStats.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxStats.Name = "gbxStats";
            this.gbxStats.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxStats.Size = new System.Drawing.Size(479, 209);
            this.gbxStats.TabIndex = 12;
            this.gbxStats.TabStop = false;
            this.gbxStats.Text = "Stats";
            
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 25);
            this.label2.TabIndex = 24;
            this.label2.Text = "Categories Bought";
            this.label2.Visible = false;
            // 
            // listViewCategorysBought
            // 
            this.listViewCategorysBought.HideSelection = false;
            this.listViewCategorysBought.Location = new System.Drawing.Point(232, 50);
            this.listViewCategorysBought.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewCategorysBought.Name = "listViewCategorysBought";
            this.listViewCategorysBought.Size = new System.Drawing.Size(231, 147);
            this.listViewCategorysBought.TabIndex = 23;
            this.listViewCategorysBought.UseCompatibleStateImageBehavior = false;
            this.listViewCategorysBought.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(255, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 20);
            this.label11.TabIndex = 22;
            // 
            // lblTimesBought
            // 
            this.lblTimesBought.AutoSize = true;
            this.lblTimesBought.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimesBought.ForeColor = System.Drawing.Color.Black;
            this.lblTimesBought.Location = new System.Drawing.Point(145, 53);
            this.lblTimesBought.Name = "lblTimesBought";
            this.lblTimesBought.Size = new System.Drawing.Size(18, 20);
            this.lblTimesBought.TabIndex = 17;
            this.lblTimesBought.Text = "1";
            // 
            // lblRefunds
            // 
            this.lblRefunds.AutoSize = true;
            this.lblRefunds.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefunds.ForeColor = System.Drawing.Color.Black;
            this.lblRefunds.Location = new System.Drawing.Point(145, 94);
            this.lblRefunds.Name = "lblRefunds";
            this.lblRefunds.Size = new System.Drawing.Size(18, 20);
            this.lblRefunds.TabIndex = 16;
            this.lblRefunds.Text = "1";
            // 
            // lblItemsRefunded
            // 
            this.lblItemsRefunded.AutoSize = true;
            this.lblItemsRefunded.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemsRefunded.ForeColor = System.Drawing.Color.Black;
            this.lblItemsRefunded.Location = new System.Drawing.Point(145, 113);
            this.lblItemsRefunded.Name = "lblItemsRefunded";
            this.lblItemsRefunded.Size = new System.Drawing.Size(18, 20);
            this.lblItemsRefunded.TabIndex = 15;
            this.lblItemsRefunded.Text = "1";
            // 
            // lblSpent
            // 
            this.lblSpent.AutoSize = true;
            this.lblSpent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpent.ForeColor = System.Drawing.Color.Black;
            this.lblSpent.Location = new System.Drawing.Point(145, 133);
            this.lblSpent.Name = "lblSpent";
            this.lblSpent.Size = new System.Drawing.Size(18, 20);
            this.lblSpent.TabIndex = 14;
            this.lblSpent.Text = "1";
            // 
            // lblItemsBought
            // 
            this.lblItemsBought.AutoSize = true;
            this.lblItemsBought.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemsBought.ForeColor = System.Drawing.Color.Black;
            this.lblItemsBought.Location = new System.Drawing.Point(145, 73);
            this.lblItemsBought.Name = "lblItemsBought";
            this.lblItemsBought.Size = new System.Drawing.Size(18, 20);
            this.lblItemsBought.TabIndex = 12;
            this.lblItemsBought.Text = "1";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(27, 52);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(118, 20);
            this.label24.TabIndex = 11;
            this.label24.Text = "Times Bought:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(68, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Refunds:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(13, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Refunded Items:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(45, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Total Spent:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(5, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "How Many Items:";
            // 
            // gbxComments
            // 
            this.gbxComments.Controls.Add(this.richTextBoxComments);
            this.gbxComments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxComments.ForeColor = System.Drawing.Color.SteelBlue;
            this.gbxComments.Location = new System.Drawing.Point(865, 12);
            this.gbxComments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxComments.Name = "gbxComments";
            this.gbxComments.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxComments.Size = new System.Drawing.Size(341, 209);
            this.gbxComments.TabIndex = 25;
            this.gbxComments.TabStop = false;
            this.gbxComments.Text = "Comments";
            // 
            // richTextBoxComments
            // 
            this.richTextBoxComments.Location = new System.Drawing.Point(5, 30);
            this.richTextBoxComments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBoxComments.Name = "richTextBoxComments";
            this.richTextBoxComments.Size = new System.Drawing.Size(329, 174);
            this.richTextBoxComments.TabIndex = 0;
            this.richTextBoxComments.Text = "";
            // 
            // gbxInvoices
            // 
            this.gbxInvoices.Controls.Add(this.label9);
            this.gbxInvoices.Controls.Add(this.label8);
            this.gbxInvoices.Controls.Add(this.label6);
            this.gbxInvoices.Controls.Add(this.flowLayoutPanelInvoices);
            this.gbxInvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxInvoices.ForeColor = System.Drawing.Color.SteelBlue;
            this.gbxInvoices.Location = new System.Drawing.Point(12, 257);
            this.gbxInvoices.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxInvoices.Name = "gbxInvoices";
            this.gbxInvoices.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxInvoices.Size = new System.Drawing.Size(545, 364);
            this.gbxInvoices.TabIndex = 12;
            this.gbxInvoices.TabStop = false;
            this.gbxInvoices.Text = "Invoices";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(141, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 25);
            this.label9.TabIndex = 3;
            this.label9.Text = "Invoice";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(275, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 25);
            this.label8.TabIndex = 2;
            this.label8.Text = "Total";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 25);
            this.label6.TabIndex = 1;
            this.label6.Text = "Date";
            // 
            // flowLayoutPanelInvoices
            // 
            this.flowLayoutPanelInvoices.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelInvoices.Location = new System.Drawing.Point(11, 75);
            this.flowLayoutPanelInvoices.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanelInvoices.Name = "flowLayoutPanelInvoices";
            this.flowLayoutPanelInvoices.Size = new System.Drawing.Size(515, 270);
            this.flowLayoutPanelInvoices.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.flowLayoutPanelRefunds);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox1.Location = new System.Drawing.Point(647, 257);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(555, 364);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Refunds";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(149, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 25);
            this.label10.TabIndex = 7;
            this.label10.Text = "Invoice";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(284, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 25);
            this.label12.TabIndex = 6;
            this.label12.Text = "Total";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(29, 38);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 25);
            this.label13.TabIndex = 5;
            this.label13.Text = "Date";
            // 
            // flowLayoutPanelRefunds
            // 
            this.flowLayoutPanelRefunds.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelRefunds.Location = new System.Drawing.Point(19, 75);
            this.flowLayoutPanelRefunds.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanelRefunds.Name = "flowLayoutPanelRefunds";
            this.flowLayoutPanelRefunds.Size = new System.Drawing.Size(515, 270);
            this.flowLayoutPanelRefunds.TabIndex = 4;
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.groupBox1);
            this.pnlDetails.Controls.Add(this.gbxInvoices);
            this.pnlDetails.Controls.Add(this.gbxComments);
            this.pnlDetails.Controls.Add(this.gbxStats);
            this.pnlDetails.Controls.Add(this.gbxDetails);
            this.pnlDetails.Location = new System.Drawing.Point(4, 66);
            this.pnlDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(1215, 699);
            this.pnlDetails.TabIndex = 26;
            this.pnlDetails.Visible = false;
            // 
            // FrmCustomerDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1221, 737);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmCustomerDetails";
            this.Text = "FrmCustomerDetails";
            this.Load += new System.EventHandler(this.FrmCustomerDetails_Load);
            this.gbxDetails.ResumeLayout(false);
            this.gbxDetails.PerformLayout();
            this.gbxStats.ResumeLayout(false);
            this.gbxStats.PerformLayout();
            this.gbxComments.ResumeLayout(false);
            this.gbxInvoices.ResumeLayout(false);
            this.gbxInvoices.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlDetails.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox gbxDetails;
        private System.Windows.Forms.Label lblAdd1;
        private System.Windows.Forms.Label lblAdd2;
        private System.Windows.Forms.Label lblPostcode;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.GroupBox gbxStats;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listViewCategorysBought;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblTimesBought;
        private System.Windows.Forms.Label lblRefunds;
        private System.Windows.Forms.Label lblItemsRefunded;
        private System.Windows.Forms.Label lblSpent;
        private System.Windows.Forms.Label lblItemsBought;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gbxComments;
        private System.Windows.Forms.RichTextBox richTextBoxComments;
        private System.Windows.Forms.GroupBox gbxInvoices;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelInvoices;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSubscibed;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRefunds;
        private System.Windows.Forms.Panel pnlDetails;
    }
}