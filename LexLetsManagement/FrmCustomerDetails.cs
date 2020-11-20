using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace LexLetsManagement
{
    public partial class FrmCustomerDetails : Form
    {
        Helper CurrentCustomer = new Helper();

        public FrmCustomerDetails()
        {
            InitializeComponent();
        }

        private void FrmCustomerDetails_Load(object sender, EventArgs e)
        {
            TxtSearch.Focus();
            SetAutoTextForName();
        }

        private void CreateInvoiceRow(string date, int invoice, double price, FlowLayoutPanel panel)
        {
            int space = 35;
            string invoiceLength;
            invoiceLength = invoice.ToString();
            space -= invoiceLength.Length;

            Label label = new Label
            {
                Width = flowLayoutPanelInvoices.Width,
                Font = new Font("Arial", 8, FontStyle.Regular),
                ForeColor = Color.Black,
                //label.Location = new Point(5, 5);
                Text = Convert.ToDateTime(date).ToShortDateString().PadRight(25) + invoice.ToString().PadRight(space) + "£" + price.ToString()
            };
            panel.Controls.Add(label);
        }


        private void SetAutoTextForName()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";
            AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();
            sql = "SELECT FirstName, Surname, Address1,CustomerID FROM tblCustomers";
            SqlCommand command = new SqlCommand(sql, DatabaseAssist.ConnectToLexlets);
            DatabaseAssist.ConnectToLexlets.Open();
            SqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                autotext.Add(dr.GetString(0) + " " + dr.GetString(1) + " - " + dr.GetString(2) + " Id: " + dr.GetInt32(3).ToString());
            }
            TxtSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
            TxtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TxtSearch.AutoCompleteCustomSource = autotext;
            DatabaseAssist.ConnectToLexlets.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanelInvoices.Controls.Clear();
            CurrentCustomer.CustomerID = GetCustomerIdFromSearch();

            FillDetails();
            GetInvoices("Select * from tblInvoiceData where CustomerId = @param", CurrentCustomer.CustomerID, flowLayoutPanelInvoices);
            GetInvoices("Select * from tblRefundedInvoiceData where CustomerId = @param", CurrentCustomer.CustomerID, flowLayoutPanelRefunds);


            lblTimesBought.Text = CurrentCustomer.TimesBought.ToString();
            lblItemsBought.Text = CurrentCustomer.ItemsBought.ToString();
            lblItemsRefunded.Text = CurrentCustomer.ItemsRefunded.ToString();
            lblRefunds.Text = CurrentCustomer.TimesRefunded.ToString();
            lblSpent.Text = "£" + CurrentCustomer.TotalSpent.ToString();
            pnlDetails.Visible = true;
        }

        private void GetInvoices(string sql, int param, FlowLayoutPanel panel)
        {
            SqlCommand command = new SqlCommand(sql, DatabaseAssist.ConnectToLexlets);
            command.Parameters.AddWithValue("@param", param);
            DatabaseAssist.ConnectToLexlets.Open();
            command.ExecuteNonQuery();
            DatabaseAssist.ConnectToLexlets.Close();

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                Label label = new Label
                {
                    ForeColor = Color.Black
                };
                int x = (flowLayoutPanelRefunds.Width - 25) / 2;
                int y = flowLayoutPanelRefunds.Height / 2;

                label.Location = new Point(10, 10);
                label.Text = "No Invoices";
                panel.Controls.Add(label);
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CreateInvoiceRow(dt.Rows[i]["SaleDate"].ToString(), Convert.ToInt32(dt.Rows[i]["InvoiceNumber"]), Convert.ToDouble(dt.Rows[i]["InvoiceTotal"]), panel);

                    if (panel.Name == "flowLayoutPanelInvoices")
                    {
                        CurrentCustomer.ItemsBought += CountItemsInEachInvoice("Select * from tblInvoiceProducts where InvoiceNumber = @param", Convert.ToInt32(dt.Rows[i]["InvoiceNumber"]));
                        CurrentCustomer.TotalSpent += Convert.ToDouble((dt.Rows[i]["Invoicetotal"]));
                        CurrentCustomer.TimesBought++;
                    }
                    else if (panel.Name == "flowLayoutPanelRefunds")
                    {
                        CurrentCustomer.ItemsRefunded = CountItemsInEachInvoice("Select * from tblRefundedInvoiceProducts where InvoiceNumber = @param", Convert.ToInt32(dt.Rows[i]["InvoiceNumber"]));
                        CurrentCustomer.TotalSpent -= Convert.ToDouble((dt.Rows[i]["Invoicetotal"]));
                        CurrentCustomer.TimesRefunded++;


                    }
                }
            }
        }
        private int CountItemsInEachInvoice(string sql, int invoice)
        {
            int items = 0;

            SqlCommand command = new SqlCommand(sql, DatabaseAssist.ConnectToLexlets);
            command.Parameters.AddWithValue("@param", invoice);

            DatabaseAssist.ConnectToLexlets.Open();
            command.ExecuteNonQuery();
            DatabaseAssist.ConnectToLexlets.Close();

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                items += Convert.ToInt32(dt.Rows[i]["Quantity"]);
            }

            return items;
        }

        private int GetCustomerIdFromSearch()
        {
            int id;

            try
            {
                var stringToSplit = TxtSearch.Text;
                var indexOfFirstSpace = stringToSplit.IndexOf(":") + 1;
                var cusId = stringToSplit.Substring(indexOfFirstSpace);
                id = Convert.ToInt32(cusId);
            }

            catch
            {
                id = -1;
                MessageBox.Show("Id Not Found");

            }

            return id;
        }

        private void FillDetails()
        {
            SqlCommand command = new SqlCommand("Select * from tblCustomers where CustomerID = @id", DatabaseAssist.ConnectToLexlets);
            command.Parameters.AddWithValue("@id", CurrentCustomer.CustomerID);

            DatabaseAssist.ConnectToLexlets.Open();
            command.ExecuteNonQuery();
            DatabaseAssist.ConnectToLexlets.Close();

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            lblId.Text = "ID: " + (dt.Rows[0]["CustomerID"].ToString());
            lblName.Text = (dt.Rows[0]["FirstName"].ToString()) + " " + (dt.Rows[0]["Surname"].ToString());
            lblAdd1.Text = (dt.Rows[0]["Address1"].ToString());
            lblAdd2.Text = (dt.Rows[0]["Address2"].ToString());
            lblPostcode.Text = (dt.Rows[0]["Postcode"].ToString());
            lblEmail.Text = (dt.Rows[0]["Email"].ToString());
            lblSubscibed.Text = "Subscribed: " + (dt.Rows[0]["Subscribed"].ToString());
            User.AddToUserLog("Viewed Customer", User.Username + " Viewed " + lblName.Text + "'s Details");
            if (string.IsNullOrEmpty(dt.Rows[0]["Comments"].ToString()))
            {
                richTextBoxComments.Text = "No Comments";
            }
            else
            {
                richTextBoxComments.Text = (dt.Rows[0]["Comments"].ToString());
            }

        }
    }
}
