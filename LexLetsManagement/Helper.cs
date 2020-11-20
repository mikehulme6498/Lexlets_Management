using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace LexLetsManagement
{
    class Helper
    {
        public int CustomerID { get; set; }
        public int TimesBought { get; set; }
        public int ItemsBought { get; set; }
        public int TimesRefunded { get; set; }
        public int ItemsRefunded { get; set; }
        public double TotalSpent { get; set; }
        public string PaymentMethod { get; set; }
        public int Invoice { get; set; }
        public double GiftBoxTotal { get; set; }
        public double PostageTotal { get; set; }
        public double PaymentFeePercent { get; set; }
        public double PaymentFeeGBP { get; set; }
        static private bool changeBackgroundColour = false;

        public Helper()
        {
            TimesBought = 0;
            ItemsBought = 0;
            TimesRefunded = 0;
            ItemsRefunded = 0;
            TotalSpent = 0;
        }

        static public bool ChangeBackgoundColour
        {
            get { return changeBackgroundColour; }
            set { changeBackgroundColour = value; }
        }
        static public string LoadingStatus
        {
            get { return LoadingStatus; }
            set
            {
                LoadingStatus = value;
            }
        }
        static public string RemovePoundSign(string text)
        {
            string tempText = text;

            if (tempText.StartsWith("£"))
            {
                tempText = tempText.Substring(1);

                if (string.IsNullOrEmpty(tempText))
                {
                    tempText = "0";
                }
            }
            return tempText;
        }

        static public string CheckTextBoxForString(string text)
        {
            string tempString = text;

            if (string.IsNullOrEmpty(tempString))
            {
                return "empty";
            }

            if (text.StartsWith("£"))
            {
                tempString = RemovePoundSign(text);
            }

            try
            {
                Convert.ToDouble(tempString);
                return "number";
            }

            catch
            {
                return "notnumber";
            }
        }


        static public bool ValidateCombo(ComboBox combo)
        {

            if (combo.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select from the drop down menu", "Invalid Selection");
                combo.Focus();
                return true;
            }
            return false;
        }

        static public void CreateLabel(string text, FlowLayoutPanel panel, string toolTip, string format)
        {
            Label label = new Label
            {
                AutoSize = false,
                Width = panel.Width,
                Height = 32,
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.Black,
                Text = text
            };

            if (format == "BlackAlignLeft")
            {
                label.Font = new Font("Arial", 8, FontStyle.Regular);
                label.Height = 22;
            }

            if (format == "BlackAlignLeftItalic")
            {
                label.Font = new Font("Arial", 8, FontStyle.Italic);
                label.Height = 22;
                if (ChangeBackgoundColour == false)
                {
                    label.BackColor = Color.LightGray;
                    ChangeBackgoundColour = true;
                }
                else
                {
                    label.BackColor = Color.DarkGray;
                    ChangeBackgoundColour = false;
                }
            }

            if (format == "BlackAlignLeft12")
            {
                label.Font = new Font("Arial", 12, FontStyle.Regular);
                label.Height = 32;
            }

            if (format == "MoneyRedGreen")
            {
                double number = Convert.ToDouble(Helper.RemovePoundSign(text));
                label.TextAlign = ContentAlignment.MiddleLeft;

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

            if (format == "Header")
            {
                label.Font = new Font("Franklin Gothic Medium Cond", 10, FontStyle.Regular);
                label.ForeColor = Color.SteelBlue;
                label.TextAlign = ContentAlignment.MiddleCenter;

                if (text == "13")
                {
                    label.Text = "Total";
                }
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
        static public string GenerateSHA256HASH(string input, string salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
            SHA256Managed sha256HashString = new SHA256Managed();
            byte[] hash = sha256HashString.ComputeHash(bytes);

            return ByteArrayToHexString(hash);
        }
        static public string ByteArrayToHexString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
        static public string CreateSalt(int size)
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
        static public void FillCombo(ComboBox combo, string sqlQuery, string columnName)
        {
            combo.Items.Clear();

            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlDataAdapter da = new SqlDataAdapter(sqlQuery, DatabaseAssist.ConnectToLexlets);
                DataTable dt = new DataTable();

                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    combo.Items.Add(dt.Rows[i][columnName]);
                }

                DatabaseAssist.ConnectToLexlets.Close();
                da.Dispose();
                dt.Dispose();
                dt.Clear();
            }
        }
    }
}
