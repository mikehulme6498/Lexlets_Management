using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace LexLetsManagement
{
    public partial class FrmYearlyOverview : Form
    {
        MonthlyReports yearTotals = new MonthlyReports("SpecificYear");

        public FrmYearlyOverview()
        {
            InitializeComponent();
        }

        private void FrmYearlyOverview_Load(object sender, EventArgs e)
        {
            dtpFrom.CustomFormat = "MMMM/yyyy";
            GetYearsAvailableForCombo();
        }

        private void GetYearsAvailableForCombo()
        {
            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlDataAdapter da = new SqlDataAdapter("Select DISTINCT YEAR(Date) AS Date FROM tblIncome ORDER BY Date DESC", DatabaseAssist.ConnectToLexlets);
                DataTable dt = new DataTable();

                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmbYear.Items.Add(dt.Rows[i]["Date"]);
                }

                DatabaseAssist.ConnectToLexlets.Close();
                da.Dispose();
                dt.Dispose();
                dt.Clear();
            }
        }


        private void radYear_CheckedChanged(object sender, EventArgs e)
        {
            if (radYear.Checked)
            {
                cmbYear.Visible = true;
                dtpFrom.Visible = false;
                lblSerachType.Text = "Year : ";
            }
            else
            {
                cmbYear.Visible = false;
                dtpFrom.Visible = true;
                lblSerachType.Text = "Month : ";
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (FrmPleaseWait frm = new FrmPleaseWait(LoadData))
            {
                frm.ShowDialog(this);
            }
            pnlDetails.Visible = true;
            User.AddToUserLog("Viewed Accounts", User.Username + " Viewed 12 months Figures starting from " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dtpFrom.Value.Month).ToString() + " " + dtpFrom.Value.Year.ToString());
        }

        private void LoadData()
        {
            FlowLayoutPanel[] panels = { fl1, fl2, fl3, fl4, fl5, fl6, fl7, fl8, fl9, fl10, fl11, fl12, fl12, fltotal };

            //pnlDetails.Invoke((MethodInvoker)delegate ()
            //{
            //    pnlDetails.Visible = true;
            //});

            yearTotals.ClearAll();
            ClearPanels(panels);

            cmbYear.Invoke((MethodInvoker)delegate ()
            {
                if (radYear.Checked & cmbYear.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Select a Year", "No Date Selected", MessageBoxButtons.OK);
                    return;
                }
            });
            LoadRowNames();
            CreateAndFillData(panels);
            CreateTotalsPanel();
        }

        private void CreateAndFillData(FlowLayoutPanel[] panels)
        {
            int startMonth, tempMonth;
            int startYear, tempYear;


            if (radDates.Checked)
            {
                startMonth = dtpFrom.Value.Month;
                startYear = dtpFrom.Value.Year;
            }
            else
            {
                startMonth = 1;
                startYear = yearTotals.StartYear;
            }
            tempMonth = startMonth;
            tempYear = startYear;


            for (int i = 0; i < 12; i++)
            {
                if (tempMonth == 13)
                {
                    tempMonth = 1;
                    tempYear++;
                }
                Helper.CreateLabel(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(tempMonth), panels[i], "None", "Header");
                tempMonth++;
            }
            lblDate.Invoke((MethodInvoker)delegate ()
            {
                lblDate.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(startMonth) + " " + startYear.ToString() + " To " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(tempMonth - 1) + " " + tempYear.ToString();
            });
            Helper.CreateLabel("Total", fltotal, "None", "Header");

            for (int i = 0; i < 12; i++)
            {
                if (startMonth == 13)
                {
                    startMonth = 1;
                    startYear++;
                }
                MonthlyReports.GetMonthlyFigures(startMonth, startYear, panels[i], "Full", yearTotals);
                startMonth++;
            }
        }
        private void ClearPanels(FlowLayoutPanel[] panels)
        {
            foreach (Panel pan in panels)
            {
                pan.Invoke((MethodInvoker)delegate ()
                {
                    pan.Controls.Clear();
                });
            }
        }
        private void CreateTotalsPanel()
        {
            double profit = yearTotals.TotalIn - yearTotals.TotalOut;
            profit = Math.Round(profit, 2);
            Helper.CreateLabel(yearTotals.Orders.ToString(), fltotal, "None", "BlackAlignCenter");
            Helper.CreateLabel(yearTotals.ItemsSold.ToString(), fltotal, "None", "BlackAlignCenter");
            Helper.CreateLabel(yearTotals.TotalIn.ToString(), fltotal, "None", "BlackAlignCenter");
            Helper.CreateLabel("", fltotal, "None", "BlackAlignCenter12");
            Helper.ChangeBackgoundColour = false;
            for (int i = 0; i < 11; i++)
            {
                Helper.CreateLabel(yearTotals.GetTotal(i).ToString(), fltotal, "None", "BlackAlignLeftItalic");
            }

            Helper.CreateLabel("£" + yearTotals.TotalOut.ToString(), fltotal, "None", "");
            Helper.CreateLabel("£" + profit, fltotal, "None", "MoneyRedGreen");
        }

        private void LoadRowNames()
        {
            DataTable Expenses = DatabaseAssist.CreateDataTable("Select CategoryName From tblOutgoingCategory Order By CategoryName Asc", 1, 1);
            flHeadings.Invoke((MethodInvoker)delegate ()
            {
                flHeadings.Controls.Clear();
            });
            Helper.CreateLabel("", flHeadings, "None", "BlackAlignLeft12");
            Helper.CreateLabel("Sales", flHeadings, "None", "BlackAlignLeft12");
            Helper.CreateLabel("Items Sold", flHeadings, "None", "BlackAlignLeft12");
            Helper.CreateLabel("Income", flHeadings, "None", "BlackAlignLeft12");
            Helper.CreateLabel("Expenses", flHeadings, "None", "BlackAlignLeft12");


            for (int i = 0; i < Expenses.Rows.Count; i++)
            {
                Helper.CreateLabel(Expenses.Rows[i][0].ToString(), flHeadings, "None", "BlackAlignLeft");
            }

            Helper.CreateLabel("Total Expenses", flHeadings, "None", "BlackAlignLeft12");
            Helper.CreateLabel("Profit", flHeadings, "None", "BlackAlignLeft12");
        }
        private void cmbYear_SelectedValueChanged(object sender, EventArgs e)
        {
            yearTotals.StartYear = Convert.ToInt16(cmbYear.SelectedItem);
        }
    }
}
