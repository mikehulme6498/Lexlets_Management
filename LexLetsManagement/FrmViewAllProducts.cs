using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;



namespace LexLetsManagement
{
    public partial class FrmViewAllProducts : Form
    {
        public FrmViewAllProducts()
        {
            InitializeComponent();
        }

        private void ViewAllProducts_Load(object sender, EventArgs e)
        {
            ChangeView();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void CreatePanel(FlowLayoutPanel panel, Image picture, int sku, string category, string description, double price, int sold)
        public void CreatePanel(FlowLayoutPanel panel, Image pic, string skuNo, string cat, string desc, string col, double price, int qty)
        {
            Panel itemPanel = new Panel();
            itemPanel.AutoSize = false;
            itemPanel.Size = new Size(340, 150);
            itemPanel.BorderStyle = BorderStyle.FixedSingle;
            itemPanel.BackColor = Color.GhostWhite;
            itemPanel.Tag = skuNo;


            PictureBox picture = new PictureBox();
            picture.Location = new Point(5, 5);
            picture.Size = new Size(140, 140);
            picture.Image = pic;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.SendToBack();
            itemPanel.Controls.Add(picture);

            Label sku = new Label();
            sku.Location = new Point(150, 5);
            sku.Size = new Size(190, 25);
            sku.Text = "SKU: " + skuNo;
            sku.Font = new Font("Calibri", 12, FontStyle.Bold);
            itemPanel.Controls.Add(sku);

            Label description = new Label();
            description.Location = new Point(150, 25);
            description.Size = new Size(190, 20);
            description.Text = desc;
            description.Font = new Font("Calibri", 11, FontStyle.Bold);
            itemPanel.Controls.Add(description);

            Label colour = new Label();
            colour.Location = new Point(150, 45);
            colour.Size = new Size(190, 20);
            colour.Text = col;
            colour.Font = new Font("Calibri", 10, FontStyle.Regular);
            itemPanel.Controls.Add(colour);

            Label category = new Label();
            category.Location = new Point(150, 65);
            category.Size = new Size(190, 20);
            category.Text = cat;
            category.Font = new Font("Calibri", 10, FontStyle.Regular);
            itemPanel.Controls.Add(category);

            Label sellPrice = new Label();
            sellPrice.Location = new Point(150, 100);
            sellPrice.Size = new Size(190, 20);
            sellPrice.Text = "£" + price.ToString();
            sellPrice.Font = new Font("Calibri", 10, FontStyle.Regular);
            itemPanel.Controls.Add(sellPrice);

            Label sold = new Label();
            sold.Location = new Point(150, 125);
            sold.Size = new Size(190, 20);
            sold.Text = "Sold: " + qty.ToString();
            sold.Font = new Font("Calibri", 10, FontStyle.Regular);
            itemPanel.Controls.Add(sold);
            itemPanel.MouseHover += ItemPanel_MouseHover;
            panel.Invoke((MethodInvoker)delegate ()
            {
                panel.Controls.Add(itemPanel);
            });
        }

        private void ItemPanel_MouseHover(object sender, EventArgs e)
        {
            PopUpMenu(sender as Panel);
        }


        private void PopUpMenu(Panel pan)
        {
            Panel popup = new Panel();
            popup.Width = pan.Width;
            popup.Location = new Point(0, pan.Height - 30);
            popup.BackColor = Color.Aqua;
            popup.MouseLeave += Popup_MouseLeave;
            pan.Controls.Add(popup);
            pan.Controls.SetChildIndex(popup, 6);

            Button edit = new Button();
            edit.Size = new Size(100, 20);
            edit.Click += Edit_Click;
            edit.Tag = pan.Tag;
            popup.Controls.Add(edit);
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            string sku = but.Tag.ToString();
            MessageBox.Show("You Clicked on SKU" + sku);
        }

        private void Popup_MouseLeave(object sender, EventArgs e)
        {
            PopUpMenuRemove(sender as Panel);
        }

        private void PopUpMenuRemove(Panel panel)
        {
            panel.Dispose();
        }

        private void LoadData()
        {
            if (DatabaseAssist.ConnectToDatabase() == true)
            {

                SqlDataAdapter adapter = new SqlDataAdapter("select Sku, Category, Description, Sellprice, QTYSold, DateLastSold, DateAdded from tblProductData", DatabaseAssist.ConnectToLexlets);

                DataSet ds = new DataSet();
                adapter.Fill(ds, "tblProductData");
                dataGridView1.Invoke((MethodInvoker)delegate ()
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "tblProductData";
                    dataGridView1.Columns["sellPrice"].HeaderText = "Price";
                    dataGridView1.Columns["sellPrice"].DefaultCellStyle.Format = "£0.00";
                    dataGridView1.Columns["QTYSold"].HeaderText = "Quantity Sold";
                    dataGridView1.Columns["DateLastSold"].HeaderText = "Last Sold";
                    dataGridView1.Columns["Description"].Width = 250;
                    dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                });
                DatabaseAssist.ConnectToLexlets.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatabaseAssist.RunQuery("UPDATE tblProductData SET QTYSold = '0' WHERE QTYSold != '0'");
            LoadData();
        }
        void FillPanels()
        {
            string sku;
            string category;
            string description;
            string colour;
            string textToSplit;
            double price;
            int qtySold;
            int index;
            Image image;

            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlDataAdapter da = new SqlDataAdapter("select sku, category, Description, sellprice, Image, QTYSold from tblProductData", DatabaseAssist.ConnectToLexlets);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DatabaseAssist.ConnectToLexlets.Close();


                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    image = (Bitmap)((new ImageConverter()).ConvertFrom(dt.Rows[i]["Image"]));
                    sku = (dt.Rows[i]["SKU"].ToString());
                    category = (dt.Rows[i]["Category"].ToString());
                    textToSplit = (dt.Rows[i]["Description"].ToString());
                    try
                    {
                        index = textToSplit.IndexOf("-");
                        description = textToSplit.Substring(0, index - 1);
                        colour = textToSplit.Substring(index + 2);
                    }
                    catch
                    {
                        description = textToSplit;
                        colour = "";
                    }
                    price = Convert.ToDouble(dt.Rows[i]["SellPrice"]);
                    qtySold = Convert.ToInt32(dt.Rows[i]["QTYSold"]);

                    CreatePanel(flowLayoutPanelItemsDetailed, image, sku, category, description, colour, price, qtySold);
                }
            }
        }

        private void ChangeView()
        {
            if (radioDetailed.Checked)
            {
                flowLayoutPanelItemsDetailed.Visible = true;
                dataGridView1.Visible = false;
                flowLayoutPanelItemsDetailed.Controls.Clear();
                flowLayoutPanelItemsDetailed.Visible = false;
                flowLayoutPanelItemsDetailed.Enabled = false;
                using (FrmPleaseWait frm = new FrmPleaseWait(FillPanels))
                {
                    frm.ShowDialog(this);
                }

                flowLayoutPanelItemsDetailed.Enabled = true;
                flowLayoutPanelItemsDetailed.Visible = true;
            }
            else
            {
                flowLayoutPanelItemsDetailed.Visible = false;
                dataGridView1.Visible = true;
                using (FrmPleaseWait frm = new FrmPleaseWait(LoadData))
                {
                    frm.ShowDialog(this);
                }
            }
        }


        private void radioList_CheckedChanged(object sender, EventArgs e)
        {
            ChangeView();
        }
    }   

}
