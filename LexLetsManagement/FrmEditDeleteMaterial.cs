using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LexLetsManagement
{
    public partial class FrmEditDeleteMaterial : Form
    {
        public FrmEditDeleteMaterial()
        {
            InitializeComponent();
        }

        private void FrmEditDeleteMaterial_Load(object sender, EventArgs e)
        {
            txtByMatID.Focus();
            FillCategory(cmbCategory);
            FillColour(cmbColour);
            FillSupplier(cmbSupplier);

            gbxEditMaterial.Visible = true;
            gbxFindMaterial.Visible = true;
            BtnUpdate.Visible = true;
            BtnCancel.Visible = true;
            BtnDelete.Visible = true;
        }

        public void FillCategory(ComboBox category)
        {
            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlDataAdapter da = new SqlDataAdapter("Select CategoryName FROM tblMaterialCategory", DatabaseAssist.ConnectToLexlets);
                DataTable dt = new DataTable();

                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    category.Items.Add(dt.Rows[i]["CategoryName"]);
                }

                DatabaseAssist.ConnectToLexlets.Close();
                da.Dispose();
                dt.Dispose();
                dt.Clear();
            }
        }

        public void FillColour(ComboBox colour)
        {


            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlDataAdapter da = new SqlDataAdapter("Select ColourName FROM tblColours", DatabaseAssist.ConnectToLexlets);
                DataTable dt = new DataTable();

                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    colour.Items.Add(dt.Rows[i]["ColourName"]);
                }

                DatabaseAssist.ConnectToLexlets.Close();
                da.Dispose();
                dt.Dispose();
                dt.Clear();
            }
        }

        public void FillSupplier(ComboBox supplier)
        {
            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlDataAdapter da = new SqlDataAdapter("Select SupplierName FROM tblSuppliers", DatabaseAssist.ConnectToLexlets);
                DataTable dt = new DataTable();

                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    supplier.Items.Add(dt.Rows[i]["SupplierName"]);
                }

                DatabaseAssist.ConnectToLexlets.Close();
                da.Dispose();
                dt.Dispose();
                dt.Clear();
            }
        }

        public void ClearAll()
        {
            txtByMatID.Text = "";
            TxtByDesc.Text = "";
            materialIdTextBox.Text = "";
            cmbCategory.Text = "";
            cmbColour.Text = "";
            cmbSupplier.Text = "";
            descriptionTextBox.Text = "";
            qTYinStockTextBox.Text = "";
            lowLevelWarningTextBox.Text = "";
            costPerItemTextBox.Text = "";
            sizeonBraceletTextBox.Text = "";
            gbxEditMaterial.Enabled = false;
            picLoadImage.Image = null;
            gbxFindMaterial.Enabled = true;
            dataGridEditMaterial.DataSource = null;
            txtByMatID.Focus();
        }

        private void TxtByMatID_MouseClick(object sender, MouseEventArgs e)
        {
            TxtByDesc.Text = "";
        }

        private void TxtByDesc_MouseClick(object sender, MouseEventArgs e)
        {
            txtByMatID.Text = "";
        }

        private void DataGridEditMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridEditMaterial.Rows[e.RowIndex].Cells["MaterialId"].Value.ToString());

                BtnCancel.Enabled = true;
                BtnUpdate.Enabled = true;
                BtnDelete.Enabled = true;

                if (DatabaseAssist.ConnectToDatabase() == true)
                {
                    SqlCommand cmd = DatabaseAssist.ConnectToLexlets.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from tblMaterials INNER JOIN tblColours on tblColours.ColourId = tblMaterials.ColourID INNER JOIN tblMaterialCategory on tblMaterialCategory.CategoryId = tblMaterials.Category INNER JOIN tblSuppliers on tblSuppliers.SupplierId = tblMaterials.SupplierID WHERE tblMaterials.MaterialID= @id ";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        materialIdTextBox.Text = dr["MaterialID"].ToString();
                        cmbCategory.Text = dr["CategoryName"].ToString();
                        cmbColour.Text = dr["ColourName"].ToString();
                        descriptionTextBox.Text = dr["Description"].ToString();
                        qTYinStockTextBox.Text = dr["QTYinStock"].ToString();
                        lowLevelWarningTextBox.Text = dr["LowLevelWarning"].ToString();
                        costPerItemTextBox.Text = dr["CostPerItem"].ToString();
                        sizeonBraceletTextBox.Text = dr["SizeOnBracelet"].ToString();
                        cmbSupplier.Text = dr["SupplierName"].ToString();
                        Image x = (Bitmap)((new ImageConverter()).ConvertFrom(dr["Image"]));
                        picLoadImage.Image = x;
                    }
                    DatabaseAssist.ConnectToLexlets.Close();
                    gbxEditMaterial.Enabled = true;
                    gbxFindMaterial.Enabled = false;
                    btnChange.Visible = true;
                }
            }
            catch
            {
                MessageBox.Show("Please Select a Row, Not a Column");
                return;
            }
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
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlDataAdapter getcatID = new SqlDataAdapter("SELECT CategoryId FROM tblMaterialCategory WHERE CategoryName = @category", DatabaseAssist.ConnectToLexlets);
                getcatID.SelectCommand.Parameters.AddWithValue("@category", cmbCategory.SelectedItem.ToString());
                DataTable dt = new DataTable();
                getcatID.Fill(dt);
                int catid = Convert.ToInt32((dt.Rows[0]["CategoryId"]));

                SqlDataAdapter getcolID = new SqlDataAdapter("SELECT ColourId FROM tblColours WHERE ColourName = @cols", DatabaseAssist.ConnectToLexlets);
                getcolID.SelectCommand.Parameters.AddWithValue("@cols", cmbColour.SelectedItem.ToString());
                DataTable dt1 = new DataTable();
                getcolID.Fill(dt1);
                int colid = Convert.ToInt32((dt1.Rows[0]["ColourId"]));

                SqlDataAdapter getsupID = new SqlDataAdapter("SELECT SupplierId FROM tblSuppliers WHERE SupplierName = @sup", DatabaseAssist.ConnectToLexlets);
                getsupID.SelectCommand.Parameters.AddWithValue("@sup", cmbSupplier.SelectedItem.ToString());
                DataTable dt2 = new DataTable();
                getsupID.Fill(dt2);
                int supid = Convert.ToInt32((dt2.Rows[0]["SupplierId"]));

                dt.Dispose();
                dt1.Dispose();
                dt2.Dispose();

                SqlDataAdapter adapter = new SqlDataAdapter("UPDATE tblMaterials SET Category = @cat, ColourID = @cols, Description = @desc, QTYinStock = @qty, LowLevelWarning = @low, CostPerItem = @cost, SizeOnBracelet = @size, SupplierID = @supplier  Where MaterialID = @id", DatabaseAssist.ConnectToLexlets);
                adapter.SelectCommand.Parameters.AddWithValue("@cat", catid);
                adapter.SelectCommand.Parameters.AddWithValue("@cols", colid);
                adapter.SelectCommand.Parameters.AddWithValue("@desc", descriptionTextBox.Text);
                adapter.SelectCommand.Parameters.AddWithValue("@qty", qTYinStockTextBox.Text);
                adapter.SelectCommand.Parameters.AddWithValue("@Low", lowLevelWarningTextBox.Text);
                adapter.SelectCommand.Parameters.AddWithValue("@cost", costPerItemTextBox.Text);
                adapter.SelectCommand.Parameters.AddWithValue("@size", sizeonBraceletTextBox.Text);
                adapter.SelectCommand.Parameters.AddWithValue("@id", materialIdTextBox.Text);
                adapter.SelectCommand.Parameters.AddWithValue("@supplier", supid);
                adapter.SelectCommand.ExecuteNonQuery();

                if (!String.IsNullOrEmpty(txtImagePath.Text))
                {

                    byte[] imagebt = null;
                    FileStream fstream = new FileStream(txtImagePath.Text, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fstream);
                    imagebt = br.ReadBytes((int)fstream.Length);
                    SqlDataAdapter adapter1 = new SqlDataAdapter("UPDATE tblMaterials SET Image =@img  Where MaterialID = @id", DatabaseAssist.ConnectToLexlets);
                    adapter1.SelectCommand.Parameters.AddWithValue("@img", imagebt);
                    adapter1.SelectCommand.Parameters.AddWithValue("@id", materialIdTextBox.Text);
                    adapter1.SelectCommand.ExecuteNonQuery();
                }

                DatabaseAssist.ConnectToLexlets.Close();
                User.AddToUserLog("Update Material", User.Username + " Updated Material (" + cmbCategory.SelectedItem.ToString() + " - " + descriptionTextBox.Text + ")");
                MessageBox.Show("Material Updated");
                ClearAll();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            User.AddToUserLog("Delete Material", User.Username + " Deleted Material (" + cmbCategory.SelectedItem.ToString() + " - " + descriptionTextBox.Text + ")");
            if (DatabaseAssist.ConnectToDatabase() == true)
            {

                SqlDataAdapter adapter = new SqlDataAdapter("Delete From tblMaterials WHERE MaterialID = @id", DatabaseAssist.ConnectToLexlets);
                adapter.SelectCommand.Parameters.AddWithValue("@id", materialIdTextBox.Text);
                adapter.SelectCommand.ExecuteNonQuery();
                DatabaseAssist.ConnectToLexlets.Close();
                MessageBox.Show("Material Deleted");
                ClearAll();
            }
        }

        private void TxtByDesc_KeyUp(object sender, KeyEventArgs e)
        {
            string byDescription = TxtByDesc.Text;

            if (DatabaseAssist.ConnectToDatabase() == true)
            {


                SqlDataAdapter adapter = new SqlDataAdapter("select tblMaterials.MaterialID, tblMaterialCategory.CategoryName, tblColours.ColourName, tblMaterials.Description from tblMaterials INNER JOIN tblMaterialCategory ON tblMaterialCategory.CategoryID = tblMaterials.Category INNER JOIN tblColours ON tblColours.ColourID = tblMaterials.ColourID WHERE tblMaterials.Description like '%'+@byDesc+'%'", DatabaseAssist.ConnectToLexlets);
                adapter.SelectCommand.Parameters.AddWithValue("@byDesc", byDescription);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tblMaterials");
                dataGridEditMaterial.DataSource = ds;
                dataGridEditMaterial.DataMember = "tblMaterials";
                dataGridEditMaterial.Columns["CategoryName"].HeaderText = "Category";
                dataGridEditMaterial.Columns["CategoryName"].Width = 100;
                dataGridEditMaterial.Columns["ColourName"].HeaderText = "Colour";
                dataGridEditMaterial.Columns["ColourName"].Width = 125;
                dataGridEditMaterial.Columns["Description"].Width = 175;
                DatabaseAssist.ConnectToLexlets.Close();
            }
        }

        private void TxtByMatID_KeyUp(object sender, KeyEventArgs e)
        {

            string byMaterialID = txtByMatID.Text;

            if (Helper.CheckTextBoxForString(txtByMatID.Text) == "notnumber")
            {
                MessageBox.Show("ID Numbers do not contain letters, Please Enter a Number", "Invalid Charactor");
                txtByMatID.Text = "";
                txtByMatID.Focus();
            }
            else
            {

                if (DatabaseAssist.ConnectToDatabase() == true)
                {

                    SqlDataAdapter adapter = new SqlDataAdapter("select tblMaterials.MaterialID, tblMaterialCategory.CategoryName, tblColours.ColourName, tblMaterials.Description from tblMaterials INNER JOIN tblMaterialCategory ON tblMaterialCategory.CategoryID = tblMaterials.Category INNER JOIN tblColours ON tblColours.ColourID = tblMaterials.ColourID WHERE tblMaterials.MaterialID = @byid", DatabaseAssist.ConnectToLexlets);
                    adapter.SelectCommand.Parameters.AddWithValue("@byid", byMaterialID);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "tblMaterials");
                    dataGridEditMaterial.DataSource = ds;
                    dataGridEditMaterial.DataMember = "tblMaterials";
                    dataGridEditMaterial.Columns["CategoryName"].HeaderText = "Category";
                    dataGridEditMaterial.Columns["CategoryName"].Width = 100;
                    dataGridEditMaterial.Columns["ColourName"].HeaderText = "Colour";
                    dataGridEditMaterial.Columns["ColourName"].Width = 125;
                    dataGridEditMaterial.Columns["Description"].Width = 175;
                    DatabaseAssist.ConnectToLexlets.Close();
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ClearAll();
            this.Close();
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            gbxEditMaterial.Enabled = false;
            gbxFindMaterial.Enabled = true;
            btnChange.Visible = false;
            BtnDelete.Enabled = false;
            BtnUpdate.Enabled = false;
            dataGridEditMaterial.DataSource = null;
            ClearAll();
        }
    }
}

