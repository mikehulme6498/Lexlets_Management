using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LexLetsManagement
{
    class MonthlyReports
    {
        private int orders;
        private int itemsSold;
        private string monthName;
        private double fees;
        private double wages;
        private double charmsBeads;
        private double stationary;
        private double equipment;
        private double utility;
        private double advertising;
        private double insurance;
        private double totalIn;
        private double totalOut;
        private int startYear;
        private double[] totals; // Array to store each category value when user searches for specific dates


        public MonthlyReports(String name)
        {
            monthName = name;
            ItemsSold = 0;
            totalIn = 0;
            totals = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        }


        public void AddToTotal(int index, double value)
        {
            totals[index] += value;
        }

        public double GetTotal(int index)
        {
            return totals[index];
        }

        public int StartYear
        {
            get { return startYear; }
            set { startYear = value; }
        }

        public int Orders
        {
            get { return orders; }
            set { orders += value; }
        }

        public double TotalOut
        {
            get { return totalOut; }
            set { totalOut += value; }
        }
        public double TotalIn
        {
            get { return totalIn; }
            set { totalIn += value; }
        }
        public double Insurance
        {
            get { return insurance; }
            set { insurance += value; }
        }
        public double Advertising
        {
            get { return advertising; }
            set { advertising += value; }
        }
        public double Utility
        {
            get { return utility; }
            set { utility += value; }
        }
        public double Equipment
        {
            get { return equipment; }
            set { equipment += value; }
        }
        public double Stationary
        {
            get { return stationary; }
            set { stationary += value; }
        }
        public double CharmsBeads
        {
            get { return charmsBeads; }
            set { charmsBeads += value; }
        }
        public double Wages
        {
            get { return wages; }
            set { wages += value; }
        }
        public int ItemsSold
        {
            get { return itemsSold; }
            set { itemsSold += value; }
        }
        public double Fees
        {
            get { return fees; }
            set { fees += value; }
        }
        public string Name
        {
            get { return monthName; }
        }
        static public int GetSalesThisMonth(int month, int year)
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

            if (DatabaseAssist.ConnectToLexlets.State.ToString() == "Closed") { DatabaseAssist.ConnectToLexlets.Open(); }
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DatabaseAssist.ConnectToLexlets);
            adapter.SelectCommand.Parameters.AddWithValue("@month", month);
            adapter.SelectCommand.Parameters.AddWithValue("@year", year);
            adapter.Fill(data);

            for (int i = 0; i < data.Rows.Count; i++)
            {
                sales++;
            }

            DatabaseAssist.ConnectToLexlets.Close();
            adapter.Dispose();
            data.Dispose();

            return sales;
        }

        static public Dictionary<string, double> GetMonthOutgoingByCategory(int monthNum, int year)
        {
            Dictionary<String, Double> month = new Dictionary<string, double>();

            DataTable test = DatabaseAssist.CreateDataTable("Select Category, SUM (Amount) From tblOutgoing Where MONTH(Date) = @param AND YEAR(Date) = @param2 GROUP BY Category ", monthNum, year);

            for (int i = 0; i < test.Rows.Count; i++)
            {
                month.Add(test.Rows[i][0].ToString(), Convert.ToDouble(test.Rows[i][1]));
            }
            return month;
        }

        static public double GetAccounts(string sql, int month, int year)
        {
            double income = 0;
            DataTable data = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(sql, DatabaseAssist.ConnectToLexlets);
            adapter.SelectCommand.Parameters.AddWithValue("@month", month);
            adapter.SelectCommand.Parameters.AddWithValue("@year", year);
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
            return income;
        }

        static public void GetMonthlyFigures(int monthNum, int year, FlowLayoutPanel panel, string BreifOrFull, MonthlyReports reports)
        {
            double income = 0;
            double outgoing = 0;
            double profit;
            Dictionary<string, Double> expenses = GetMonthOutgoingByCategory(monthNum, year);


            if (monthNum == 13)
            {
                income = GetAccounts("SELECT Amount From tblIncome where YEAR(Date) = @year", monthNum, year);
                outgoing = GetAccounts("SELECT Amount From tblOutgoing where YEAR(Date) = @year", monthNum, year);
                //CreateHeaderLabel("Total", fl13);
            }
            else
            {
                income = GetAccounts("SELECT Amount From tblIncome where MONTH(Date) = @month AND YEAR(Date) = @year", monthNum, year);
                outgoing = GetAccounts("SELECT Amount From tblOutgoing where MONTH(Date) = @month AND YEAR(Date) = @year", monthNum, year);
            }

            profit = income - outgoing;
            profit = Math.Round(profit, 2);
            reports.totalIn += income;
            reports.totalOut += outgoing;
            reports.orders += GetSalesThisMonth(monthNum, year);
            reports.itemsSold += (ItemsSoldInMonth(monthNum, year));

            Helper.CreateLabel(GetSalesThisMonth(monthNum, year).ToString(), panel, "None", "BlackAlignCenter");
            Helper.CreateLabel(ItemsSoldInMonth(monthNum, year).ToString(), panel, "None", "BlackAlignCenter");
            Helper.CreateLabel("£" + income.ToString(), panel, "None", "BlackAlignCenter12");

            if (BreifOrFull == "Full")
            {
                Helper.CreateLabel("", panel, "None", "BlackAlignCenter12");
                DataTable expenseCategory = DatabaseAssist.CreateDataTable("Select CategoryName From tblOutgoingCategory Order by CategoryName Asc", 1, 1);

                Helper.ChangeBackgoundColour = false;
                for (int i = 0; i < expenseCategory.Rows.Count; i++)
                {
                    double cost = Convert.ToDouble(DatabaseAssist.GetOneCellValue("Select Category, SUM(Amount) as Amount From tblOutgoing Where MONTH(Date) = @param And YEAR(Date) =@param2 And Category = @param3 GROUP BY Category ", monthNum, year, expenseCategory.Rows[i]["CategoryName"].ToString(), "Amount"));
                    reports.AddToTotal(i, cost);
                    Helper.CreateLabel("£" + cost, panel, "None", "BlackAlignLeftItalic");
                }

            }

            Helper.CreateLabel("£" + outgoing, panel, "None", "");
            Helper.CreateLabel("£" + profit, panel, "None", "MoneyRedGreen");
        }

        static int ItemsSoldInMonth(int monthNum, int year)
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
                sql = "SELECT tblInvoiceData.InvoiceNumber, tblInvoiceProducts.SKU FROM tblInvoiceData Inner join tblInvoiceProducts on tblInvoiceProducts.InvoiceNumber = tblInvoiceData.InvoiceNumber Where month(SaleDate) = @month AND year(saleDate) = @year";
            }
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DatabaseAssist.ConnectToLexlets);
            adapter.SelectCommand.Parameters.AddWithValue("@month", monthNum);
            adapter.SelectCommand.Parameters.AddWithValue("@year", year);
            adapter.Fill(data);

            for (int i = 0; i < data.Rows.Count; i++)
            {
                items++;
            }
            return items;
        }

        public void ClearAll()
        {
            itemsSold = 0;
            orders = 0;
            totalIn = 0;
            totalOut = 0;
            wages = 0;
            equipment = 0;
            fees = 0;
            charmsBeads = 0;
            utility = 0;
            advertising = 0;
            insurance = 0;

            for (int i = 0; i < totals.Length; i++)
            {
                totals[i] = 0;
            }

        }
    }
}
