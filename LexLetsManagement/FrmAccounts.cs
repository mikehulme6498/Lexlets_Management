using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace LexLetsManagement
{
    public partial class FrmAccounts : Form
    {
        MonthlyReports January = new MonthlyReports("January");
        MonthlyReports Febuary = new MonthlyReports("Febuary");
        MonthlyReports March = new MonthlyReports("March");
        MonthlyReports April = new MonthlyReports("April");
        MonthlyReports May = new MonthlyReports("May");
        MonthlyReports June = new MonthlyReports("June");
        MonthlyReports July = new MonthlyReports("July");
        MonthlyReports August = new MonthlyReports("August");
        MonthlyReports September = new MonthlyReports("September");
        MonthlyReports October = new MonthlyReports("October");
        MonthlyReports November = new MonthlyReports("November");
        MonthlyReports December = new MonthlyReports("December");

        List<MonthlyReports> months = new List<MonthlyReports>();

        public FrmAccounts()
        {
            InitializeComponent();
        }

        private void FrmAccounts_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "MMMM/yyyy";
            //LoadData();
        }

        private void LoadData()
        {
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;

            dataGridView1.Update();
            dataGridView2.Update();

            dataGridView1.Refresh();
            dataGridView2.Refresh();

            SqlCommand cmd, cmd2;
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlDataAdapter adapter2 = new SqlDataAdapter();


            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                cmd = new SqlCommand("SELECT Date, Category, Description, Amount, PaymentMethod FROM tblIncome where month(date)=@month AND year(date) =@year", DatabaseAssist.ConnectToLexlets);
                cmd2 = new SqlCommand("SELECT Date, Category, Description, Amount, PaymentMethod FROM tblOutgoing where month(date)=@month AND year(date) =@year", DatabaseAssist.ConnectToLexlets);
                cmd.Parameters.AddWithValue("@month", dateTimePicker1.Value.Month);
                cmd.Parameters.AddWithValue("@year", dateTimePicker1.Value.Year);
                cmd2.Parameters.AddWithValue("@month", dateTimePicker1.Value.Month);
                cmd2.Parameters.AddWithValue("@year", dateTimePicker1.Value.Year);
                adapter.SelectCommand = cmd;
                adapter2.SelectCommand = cmd2;

                DataSet ds = new DataSet();
                DataSet ds2 = new DataSet();

                adapter.Fill(ds, "tbl1");
                adapter2.Fill(ds2, "tbl2");

                dataGridView1.DataSource = ds;
                dataGridView2.DataSource = ds2;

                dataGridView1.DataMember = "tbl1";
                dataGridView2.DataMember = "tbl2";

                DatabaseAssist.ConnectToLexlets.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DatabaseAssist.RunQuery("Truncate table tblIncome");
            DatabaseAssist.RunQuery("Truncate table tblOutgoing");
        }



        private void btnLoad_Click(object sender, EventArgs e)
        {
            User.AddToUserLog("Viewed Accounts", User.Username + " Looked at monthly accounts from " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTimePicker1.Value.Month).ToString() + " " + dateTimePicker1.Value.Year.ToString());
            LoadData();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
