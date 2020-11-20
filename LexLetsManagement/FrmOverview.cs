using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace LexLetsManagement
{
    public partial class FrmOverview : Form
    {
        public FrmOverview()
        {
            InitializeComponent();
        }

        private void FrmOverview_Load(object sender, EventArgs e)
        {
            using (FrmPleaseWait frm = new FrmPleaseWait(LoadData))
            {
                Cursor.Current = Cursors.WaitCursor;
                frm.ShowDialog(this);
            }

            Cursor.Current = Cursors.Default;
            pnlOverview.Visible = true;
        }

        private void LoadData()
        {
            FlowLayoutPanel[] panels = { fl1, fl2, fl3, fl4, fl5, fl6, fl7, fl8, fl9, fl10, fl11, fl12, fl12, fl13 };
            lblYear.Text = DateTime.Now.Year.ToString() + " So Far";

            foreach (Panel pan in panels)
            {
                pan.Controls.Clear();
            }
            FillCustomers();
            FillLowStock();
            FillBestSellers();


            for (int i = 0; i <= 11; i++)
            {
                CreateHeaderLabel(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i + 1), panels[i]);
            }

            for (int i = 0; i < DateTime.Now.Month; i++)
            {
                GetMonthlyFigures(i + 1, panels[i]);
            }

            CreateHeaderLabel("13", fl13);
            GetMonthlyFigures(13, fl13);
        }

        private int ItemsSoldInMonth(int monthNum)
        {
            int items = 0;
            string sql = "";
            DataTable data = new DataTable();

            if (monthNum == 13)
            {
                sql = "SELECT tblInvoiceData.InvoiceNumber, tblInvoiceProducts.SKU FROM tblInvoiceData Inner join tblInvoiceProducts on tblInvoiceProducts.InvoiceNumber = tblInvoiceData.InvoiceNumber Where year(SaleDate) = @year";
            }
            else
            {
                sql = "SELECT tblInvoiceData.InvoiceNumber, tblInvoiceProducts.SKU FROM tblInvoiceData Inner join tblInvoiceProducts on tblInvoiceProducts.InvoiceNumber = tblInvoiceData.InvoiceNumber Where month(SaleDate) = @month AND year(SaleDate) = @year";
            }
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DatabaseAssist.ConnectToLexlets);
            adapter.SelectCommand.Parameters.AddWithValue("@month", monthNum);
            adapter.SelectCommand.Parameters.AddWithValue("@year", DateTime.Now.Year);
            adapter.Fill(data);

            for (int i = 0; i < data.Rows.Count; i++)
            {
                items++;
            }
            return items;
        }

        private void GetMonthlyFigures(int monthNum, FlowLayoutPanel panel)
        {
            double income;
            double outgoing;
            double profit;

            if (monthNum == 13)
            {
                income = GetAccounts("SELECT Amount From tblIncome where YEAR(Date) = @year", monthNum);
                outgoing = GetAccounts("SELECT Amount From tblOutgoing where YEAR(Date) = @year", monthNum);
                //CreateHeaderLabel("Total", fl13);
            }
            else
            {
                income = GetAccounts("SELECT Amount From tblIncome where MONTH(Date) = @month AND YEAR(Date) = @year", monthNum);
                outgoing = GetAccounts("SELECT Amount From tblOutgoing where MONTH(Date) = @month AND YEAR(Date) = @year", monthNum);
            }

            profit = income - outgoing;

            CreateLabel(GetSalesThisMonth(monthNum).ToString(), panel, "None", "BlackAlignCenter");
            CreateLabel(ItemsSoldInMonth(monthNum).ToString(), panel, "None", "BlackAlignCenter");
            CreateLabel("£" + income.ToString(), panel, "None", "BlackAlignCenter");
            CreateLabel("£" + outgoing, panel, "None", "BlackAlignCenter");
            CreateLabel("£" + Math.Round(profit, 2), panel, "None", "MoneyRedGreen");
        }

        private void MonthBreakdown(int monthNum, FlowLayoutPanel panelMonth, FlowLayoutPanel panelAmount)
        {
            Dictionary<string, double> temp = GetMonthOutgoingByCategory(monthNum);

            foreach (string s in temp.Keys)
            {
                CreateLabel(s + " : ", panelMonth, "", "");
                CreateLabel("£" + temp[s].ToString(), panelAmount, "", "");
            }
        }
        private double GetAccounts(string sql, int month)
        {
            double income = 0;
            DataTable data = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(sql, DatabaseAssist.ConnectToLexlets);
            adapter.SelectCommand.Parameters.AddWithValue("@month", month);
            adapter.SelectCommand.Parameters.AddWithValue("@year", DateTime.Now.Year);
            adapter.Fill(data);

            if (data.Rows.Count == 0)
            {
                income = 0;
                return income;
            }

            for (int i = 0; i < data.Rows.Count; i++)
            {
                income += Convert.ToDouble(data.Rows[i]["Amount"]);
            }
            return Math.Round(income, 2);
        }

        private int GetSalesThisMonth(int month)
        {
            int sales = 0;
            string sql = "";
            DataTable data = new DataTable();

            if (month == 13)
            {
                sql = "SELECT InvoiceNumber From tblInvoiceData where YEAR(SaleDate) = @year";
            }
            else
            {
                sql = "SELECT InvoiceNumber From tblInvoiceData where MONTH(SaleDate) = @month AND YEAR(SaleDate) = @year";
            }

            SqlDataAdapter adapter = new SqlDataAdapter(sql, DatabaseAssist.ConnectToLexlets);
            adapter.SelectCommand.Parameters.AddWithValue("@month", month);
            adapter.SelectCommand.Parameters.AddWithValue("@year", DateTime.Now.Year);
            adapter.Fill(data);

            for (int i = 0; i < data.Rows.Count; i++)
            {

                sales++;
            }
            return sales;
        }

        private void FillLowStock()
        {
            flowLayoutLowStockQty.Controls.Clear();
            string sql = "SELECT TOP 10 tblColours.ColourName, tblMaterials.MaterialId, tblMaterials.Description, tblMaterials.QTYinStock," +
                            "tblSuppliers.SupplierName FROM (((tblMaterials INNER JOIN tblMaterialCategory on tblMaterialCategory.CategoryId = tblMaterials.Category)" +
                            "INNER JOIN tblColours on tblColours.ColourId = tblMaterials.ColourID)" +
                            "INNER JOIN tblSuppliers on tblSuppliers.SupplierId = tblMaterials.SupplierId) where tblmaterials.QTYinStock < tblmaterials.LowLevelWarning AND tblMaterials.LowLevelWarning > -1 ORDER BY tblMaterials.QtyinStock asc";

            DataTable lowStock = DatabaseAssist.CreateDataTable(sql);

            for (int i = 0; i < lowStock.Rows.Count; i++)
            {
                CreateLabel(lowStock.Rows[i]["Description"].ToString(), flowLayoutLowStockItem, "Material Id : " + lowStock.Rows[i]["MaterialId"].ToString() + "\nColour : " + (lowStock.Rows[i]["ColourName"].ToString()) + "\nBuy From " + lowStock.Rows[i]["SupplierName"].ToString(), "BlackAlignLeft");
                CreateLabel(lowStock.Rows[i]["QTYinStock"].ToString().PadRight(3) + " Left", flowLayoutLowStockQty, "None", "BlackAlignLeft");
            }
        }
        private void FillCustomers()
        {
            flowLayoutPanelCustomers.Controls.Clear();
            DataTable customers = DatabaseAssist.CreateDataTable("SELECT * FROM vwTopCustomers");

            for (int i = 0; i <= 9; i++)
            {
                CreateLabel((i + 1).ToString().PadRight(5) + customers.Rows[i]["FirstName"].ToString() + " " + customers.Rows[i]["Surname"].ToString(), flowLayoutPanelCustomers, "Customer ID : " + customers.Rows[i]["CustomerId"].ToString(), "BlackAlignLeft");
                CreateLabel("£" + customers.Rows[i]["Total Spent"].ToString(), flowLayoutCustomersSpent, "None", "BlackAlignLeft");
            }
        }

        private void FillBestSellers()
        {
            flowLayoutSellersSold.Controls.Clear();
            string sql = "SELECT TOP 10 SKU, Category, Description, QTYSold From tblProductData Order by QTYSold desc";
            DataTable sellers = DatabaseAssist.CreateDataTable(sql);
            string stringToSplit, description, colour;
            int index;


            for (int i = 0; i <= 9; i++)
            {
                stringToSplit = (sellers.Rows[i]["Description"].ToString());
                try
                {
                    index = stringToSplit.IndexOf("-");
                    colour = stringToSplit.Substring(index + 2);
                    description = stringToSplit.Substring(0, index - 1);
                }
                catch
                {
                    description = sellers.Rows[i]["Description"].ToString();
                    colour = "";
                }
                CreateLabel(description, flowLayoutSellersName, "SKU : " + sellers.Rows[i]["SKU"].ToString() + "\nColour : " + colour + "\nCategory : " + sellers.Rows[i]["Category"], "BlackAlignLeft");
                CreateLabel(sellers.Rows[i]["QTYSold"].ToString(), flowLayoutSellersSold, "None", "BlackAlignLeft");
            }
        }

        private void CreateLabel(string text, FlowLayoutPanel panel, string toolTip, string format)
        {
            Label label = new Label();

            label.AutoSize = false;
            label.Width = panel.Width;
            label.Height = 32;
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.ForeColor = Color.Black;
            label.Text = text;

            if (format == "BlackAlignLeft")
            {
                label.Font = new Font("Arial", 8, FontStyle.Regular);
                label.Height = 22;
            }

            if (format == "MoneyRedGreen")
            {
                double number = Convert.ToDouble(Helper.RemovePoundSign(text));
                label.TextAlign = ContentAlignment.MiddleCenter;

                if (number < 0)
                {
                    label.ForeColor = Color.Red;
                }
                else
                {
                    label.ForeColor = Color.Green;
                }
            }

            if (format == "BlackAlignCenter")
            {
                label.TextAlign = ContentAlignment.MiddleCenter;
            }

            if (toolTip != "None")
            {
                new ToolTip().SetToolTip(label, toolTip);
                label.Cursor = Cursors.Help;
            }
            panel.Invoke((MethodInvoker)delegate ()
            {
                panel.Controls.Add(label);
            });
        }



        private void CreateHeaderLabel(string text, FlowLayoutPanel panel)
        {
            Label label = new Label();

            label.AutoSize = false;
            label.Width = panel.Width;
            label.Height = 32;
            label.Font = new Font("Franklin Gothic Medium Cond", 10, FontStyle.Regular);
            label.ForeColor = Color.SteelBlue;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Text = text;

            if (text == "13")
            {
                label.Text = "Total";
            }
            panel.Invoke((MethodInvoker)delegate ()
            {
                panel.Controls.Add(label);

            });
        }

        private Dictionary<string, double> GetMonthOutgoingByCategory(int monthNum)
        {
            Dictionary<String, Double> month = new Dictionary<string, double>();
            DataTable test = DatabaseAssist.CreateDataTable("Select Category, SUM (Amount) From tblOutgoing Where MONTH(Date) = @param GROUP BY Category ", monthNum);

            for (int i = 0; i < test.Rows.Count; i++)
            {
                month.Add(test.Rows[i][0].ToString(), Convert.ToDouble(test.Rows[i][1]));
            }
            return month;
        }

        private void FillChart(DataTable data)
        {

            List<MonthlyReports> months = new List<MonthlyReports>();

            months.Add(new MonthlyReports("Jan"));
            months.Add(new MonthlyReports("Feb"));
            months.Add(new MonthlyReports("Mar"));
            months.Add(new MonthlyReports("Apr"));
            months.Add(new MonthlyReports("May"));
            months.Add(new MonthlyReports("Jun"));
            months.Add(new MonthlyReports("Jul"));
            months.Add(new MonthlyReports("Aug"));
            months.Add(new MonthlyReports("Sep"));
            months.Add(new MonthlyReports("Oct"));
            months.Add(new MonthlyReports("Nov"));
            months.Add(new MonthlyReports("Dec"));

            for (int i = 0; i < data.Rows.Count; i++) // goes through each row of invoices
            {
                string date = (data.Rows[i]["SaleDate"]).ToString();
                int index = date.IndexOf("/") + 1;
                string month = date.Substring(index, 2);
                int monthNum = Convert.ToInt16(month);


                for (int j = 0; j < DateTime.Now.Month; j++)
                {
                    if (monthNum == j + 1)
                    {
                        months[j].ItemsSold++;
                        months[j].TotalIn = Convert.ToDouble(data.Rows[i]["InvoiceTotal"]) - Convert.ToDouble(data.Rows[i]["PaymentFee"]);
                    }

                }
            }

            for (int i = 0; i < DateTime.Now.Month; i++)
            {
                months[i].TotalIn -= GetAccounts("SELECT Amount From tblOutgoing where MONTH(Date) = @month AND YEAR(Date) = @year", i + 1);
            }

            for (int i = 0; i < DateTime.Now.Month; i++)
            {
                chartYear.Series["Sales"].Points.AddXY(months[i].Name, months[i].ItemsSold);
                chartYear.Series["Profit"].Points.AddXY(months[i].Name, months[i].TotalIn);
            }       

        }
       
    }
}
