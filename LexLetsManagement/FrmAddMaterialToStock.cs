using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LexLetsManagement
{
    public partial class FrmAddMaterialToStock : Form
    {
        int materialId;

        Dictionary<int, int> MaterialUpdate = new Dictionary<int, int>();

        public FrmAddMaterialToStock()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            FillCombo(cmbCategory, "Select CategoryName FROM tblMaterialCategory", "CategoryName", "", "");
            FillCombo(cmbColour, "select ColourName FROM tblColours", "ColourName", "", "");
        }

        private void FillCombo(ComboBox combo, string sql, string column, string param, string param2)
        {
            combo.Items.Clear();
            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, DatabaseAssist.ConnectToLexlets);
                da.SelectCommand.Parameters.AddWithValue("param", param);
                da.SelectCommand.Parameters.AddWithValue("param2", param2);
                DataTable dt = new DataTable();

                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    combo.Items.Add(dt.Rows[i][column]);
                }
            }
        }

        private void FrmAddMaterialToStock_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cmbColour_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillCombo(cmbMaterial, "SELECT MaterialID, Description FROM vwMaterials WHERE CategoryName = @param AND ColourName = @param2 ORDER BY Description ASC", "Description", cmbCategory.SelectedItem.ToString(), cmbColour.SelectedItem.ToString());
            cmbMaterial.Enabled = true;
        }

        private void cmbMaterial_Leave(object sender, EventArgs e)
        {
            try
            {
                materialId = DatabaseAssist.GetOneCellValue("SELECT MaterialID FROM vwMaterials WHERE CategoryName = @param AND ColourName = @param2 AND Description = @param3", cmbCategory.SelectedItem.ToString(), cmbColour.SelectedItem.ToString(), cmbMaterial.SelectedItem.ToString(), "MaterialID");
            }
            catch
            {

            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateData() == true)
            {
                MessageBox.Show("Error");
                return;
            }
            else

                try
                {
                    MaterialUpdate.Add(materialId, Convert.ToInt32(txtQuantity.Text));
                    UpdateList();
                }
                catch
                {
                    MessageBox.Show("Item number " + materialId + " has already been added to the list");
                    return;
                }
                finally
                {
                    ClearAll();
                }
        }

        private void UpdateList()
        {
            //listBoxMaterials.Items.Add(MaterialUpdate).ToString();
            //listBoxMaterials.DataSource = new BindingSource(MaterialUpdate, null);
            listBoxMaterials.Items.Add(cmbCategory.SelectedItem.ToString() + "  " + cmbColour.SelectedItem.ToString() + " - " + cmbMaterial.SelectedItem.ToString() + " (Adding " + txtQuantity.Text.ToString() + ")");
        }

        private void ClearAll()
        {
            txtQuantity.Text = "";
            txtQuantity.Enabled = false;
            cmbColour.Text = "";
            cmbColour.Enabled = false;
            cmbCategory.Text = "";
            cmbCategory.Focus();
            cmbMaterial.Text = "";
            cmbMaterial.Enabled = false;
            LoadData();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbColour.Enabled = true;
        }

        private void cmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQuantity.Enabled = true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

            UpdateMaterials();
            ClearAll();
            listBoxMaterials.Items.Clear();
            MaterialUpdate.Clear();

        }

        private bool ValidateData()
        {
            bool errors = false;

            if (Helper.CheckTextBoxForString(txtQuantity.Text) == "notnumber")
            {
                errors = true;
            }

            else if (Helper.ValidateCombo(cmbCategory) == true)
            {
                errors = true;
            }

            else if (Helper.ValidateCombo(cmbColour) == true)
            {
                errors = true;
            }
            else if (Helper.ValidateCombo(cmbMaterial) == true)
            {
                errors = true;
            }
            else
            {
                errors = false;
            }
            return errors;
        }

        private void UpdateMaterials()
        {


            foreach (var item in MaterialUpdate)
            {

                int id = item.Key;
                int qty = item.Value;
                int currentQty = Convert.ToInt32(DatabaseAssist.GetOneCellValue("SELECT QTYinStock FROM tblMaterials WHERE MaterialID = @param", id, "QtyInStock"));
                int newQty = currentQty + qty;

                SqlDataAdapter adapter = new SqlDataAdapter("UPDATE tblMaterials SET QTYinStock = @qty Where MaterialID = @id", DatabaseAssist.ConnectToLexlets);
                adapter.SelectCommand.Parameters.AddWithValue("@id", id);
                adapter.SelectCommand.Parameters.AddWithValue("@qty", newQty);
                if (DatabaseAssist.ConnectToDatabase() == true)
                {
                    adapter.SelectCommand.ExecuteNonQuery();
                }
                string description = DatabaseAssist.GetOneCellValue("SELECT * FROM tblMaterials WHERE MaterialID = @param", id, "Description");
                int colourId = Convert.ToInt32(DatabaseAssist.GetOneCellValue("SELECT * FROM tblMaterials WHERE MaterialID = @param", id, "ColourID"));
                string colour = DatabaseAssist.GetOneCellValue("SELECT * FROM tblColours WHERE ColourID = @param", colourId, "ColourName");
                User.AddToUserLog("Materials Added To Stock", User.Username + " Added " + qty + " " + colour + " " + description);
            }
            MessageBox.Show("Materials have been added to the system", "Success", MessageBoxButtons.OK);
            DatabaseAssist.ConnectToLexlets.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
