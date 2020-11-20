using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace LexLetsManagement
{
    public partial class Frmaddmaterial : Form
    {
        public Frmaddmaterial()
        {
            InitializeComponent();
        }



        private void Frmaddmaterial_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lexletsdatabaseDataSet1.tblMaterialCategory' table. You can move, or remove it, as needed.
            this.tblMaterialCategoryTableAdapter1.Fill(this.lexletsdatabaseDataSet1.tblMaterialCategory);
            this.tblColoursTableAdapter.Fill(this.lexletsdatabaseDataSet.tblColours);
            this.tblMaterialCategoryTableAdapter.Fill(this.lexletsdatabaseDataSet.tblMaterialCategory);
            FillCombo(cmbSupplier, "Select SupplierId, SupplierName FROM tblSuppliers ORDER BY SupplierName ASC", "SupplierName", "SupplierId");
            GetNextId();
        }

        private void FillCombo(ComboBox combo, string sql, string columnName, string columnID)
        {
            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, DatabaseAssist.ConnectToLexlets);
                DataTable dt = new DataTable();

                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Text = (dt.Rows[i][columnName].ToString());
                    item.Value = Convert.ToInt32((dt.Rows[i][columnID]));
                    combo.Items.Add(item);
                }

                DatabaseAssist.ConnectToLexlets.Close();
                da.Dispose();
                dt.Dispose();
                dt.Clear();
            }
        }
        public void GetNextId()
        {
            int tempSKU;
            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlDataAdapter da = new SqlDataAdapter("Select TOP 1 * FROM tblMaterials ORDER BY MaterialId DESC", DatabaseAssist.ConnectToLexlets);
                DataTable dt = new DataTable();

                da.Fill(dt);
                tempSKU = Convert.ToInt32(dt.Rows[0]["MaterialId"]);
                tempSKU++;
                materialIdTextBox.Text = tempSKU.ToString();
                DatabaseAssist.ConnectToLexlets.Close();
                da.Dispose();
                dt.Dispose();
                dt.Clear();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (validateEntry() != 8)
            {
                MessageBox.Show("Please Fill In All Fields Correctly");
            }
            else
            {
                byte[] imagebt = null;
                FileStream fstream = new FileStream(txtImagePath.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fstream);
                imagebt = br.ReadBytes((int)fstream.Length);
                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();
                String sql = "";

                sql = "INSERT into tblMaterials (Category, ColourID, Description, QTYinStock, LowLevelWarning, CostPerItem, SizeOnBracelet, Image, SupplierID) VALUES (@category, @colourID, @description, @qty, @lowlevel, @costperitem, @sizeon, @image, @supplierID)";
                if (DatabaseAssist.ConnectToDatabase() == true)
                {
                    command = new SqlCommand(sql, DatabaseAssist.ConnectToLexlets);
                    command.Parameters.AddWithValue("@category", cmbCategory.SelectedValue.ToString());
                    command.Parameters.AddWithValue("@colourID", cmbColour.SelectedValue.ToString());
                    command.Parameters.AddWithValue("@description", descriptionTextBox.Text);
                    command.Parameters.AddWithValue("@qty", qTYinStockTextBox.Text);
                    command.Parameters.AddWithValue("@lowlevel", lowLevelWarningTextBox.Text);
                    command.Parameters.AddWithValue("@costPerItem", costPerItemTextBox.Text);
                    command.Parameters.AddWithValue("@sizeon", sizeonBraceletTextBox.Text);
                    command.Parameters.AddWithValue("@image", imagebt);
                    command.Parameters.AddWithValue("@supplierID", (cmbSupplier.SelectedItem as ComboBoxItem).Value.ToString());
                    int i = command.ExecuteNonQuery();
                    command.Dispose();
                    DatabaseAssist.ConnectToLexlets.Close();

                    if (i != 0)
                    {
                        User.AddToUserLog("Added Material", User.Username + " Added " + cmbCategory.SelectedText + " " + descriptionTextBox.Text + " To the system");
                        DialogResult result = MessageBox.Show("Material Saved - Would you like to add another?", "Success", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            ClearAll();
                        }
                        else
                        {
                            this.Close();
                        }

                    }

                    else
                    {
                        MessageBox.Show("Error Please Try Again", "Error");
                    }
                }
            }
        }

        private void ClearAll()
        {
            cmbCategory.SelectedItem = "";
            cmbCategory.Text = "";
            cmbColour.SelectedItem = "";
            cmbColour.Text = "";
            descriptionTextBox.Text = "";
            qTYinStockTextBox.Text = "";
            lowLevelWarningTextBox.Text = "";
            costPerItemTextBox.Text = "";
            sizeonBraceletTextBox.Text = "";
            txtImagePath.Text = "";
            picLoadImage.ImageLocation = "";
            cmbSupplier.SelectedItem = "";
            cmbSupplier.Text = "";
            GetNextId();
        }

        private void Btnloadimage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png)"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picPath = dlg.FileName.ToString();
                txtImagePath.Text = picPath;
                picLoadImage.ImageLocation = picPath;
                lblImage.Visible = false;
            }
        }



        public int validateEntry()
        {
            int validateScore = 0;

            if (cmbCategory.SelectedIndex == -1)
            {
                lblCategory.Visible = true;
            }
            else
            {
                lblCategory.Visible = false;
                validateScore++;
            }

            if (cmbColour.SelectedIndex == -1)
            {
                lblColour.Visible = true;
            }

            else
            {
                lblColour.Visible = false;
                validateScore++;
            }

            try
            {
                int temp = Convert.ToInt32(qTYinStockTextBox.Text);
                lblQTY.Visible = false;
                validateScore++;
            }

            catch (Exception)
            {
                lblQTY.Visible = true;
            }

            try
            {
                int temp = Convert.ToInt32(lowLevelWarningTextBox.Text);
                lblLowLevel.Visible = false;
                validateScore++;
            }
            catch (Exception)
            {
                lblLowLevel.Visible = true;
            }

            try
            {
                double temp = Convert.ToDouble(costPerItemTextBox.Text);
                lblCost.Visible = false;
                validateScore++;
            }
            catch (Exception)
            {
                lblCost.Visible = true;
            }

            try
            {
                double temp = Convert.ToDouble(sizeonBraceletTextBox.Text);
                lblSize.Visible = false;
                validateScore++;
            }
            catch (Exception)
            {
                lblSize.Visible = true;
            }

            if (string.IsNullOrEmpty(txtImagePath.Text))
            {
                lblImage.Visible = true;
            }
            else
            {
                validateScore++;
            }

            if (cmbSupplier.SelectedIndex == -1)
            {
                lblSupplier.Visible = true;
            }
            else
            {
                lblSupplier.Visible = false;
                validateScore++;
            }


            return validateScore;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
