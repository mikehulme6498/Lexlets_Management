using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LexLetsManagement
{
    public partial class FrmEditDeleteProduct : Form
    {
        int rowCount = 1;
        double totalprice = 0;
        int lastSKU = -1;

        public FrmEditDeleteProduct()
        {
            InitializeComponent();
        }

        private void AddNewProduct_Load(object sender, EventArgs e)
        {
            CmbR1Category.Text = "";
            CmbR1Colour.Text = "";
            FillCategory(CmbR1Category);
            gbxMaterials.Location = new Point(40, 26);
            pnlHidden.Location = new Point(784, 65);
            BtnDone.Location = new Point(704, 416);
            BtnEdit.Location = new Point(704, 416);
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetColID(CmbR1Colour, LblR1ColId);
            FillDescription(CmbR1Description, LblR1CatID, LblR1ColId);
        }

        private void CmbDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCostandMaterialID(LblR1Cost, LblR1MatId, LblR1CatID, LblR1ColId, CmbR1Description);
        }

        public void FillDescription(ComboBox desc, Label cat, Label col)
        {
            desc.Items.Clear();

            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlDataAdapter da = new SqlDataAdapter("Select MaterialId, Description FROM tblMaterials WHERE Category = @category AND ColourID = @colour ORDER BY Description ASC", DatabaseAssist.ConnectToLexlets);
                da.SelectCommand.Parameters.AddWithValue("@category", Convert.ToInt32(cat.Text));
                da.SelectCommand.Parameters.AddWithValue("@colour", Convert.ToInt32(col.Text));
                DataTable dt = new DataTable();

                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    desc.Items.Add(dt.Rows[i]["Description"]);
                }

                DatabaseAssist.ConnectToLexlets.Close();
                da.Dispose();
                dt.Dispose();
                dt.Clear();
                desc.Enabled = true;
            }
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

                category.Enabled = true;
            }
        }

        public void FillColour(ComboBox Colour, ComboBox category)
        {
            Colour.Items.Clear();

            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlDataAdapter da = new SqlDataAdapter("Select ColourName FROM tblColours", DatabaseAssist.ConnectToLexlets);
                DataTable dt = new DataTable();

                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Colour.Items.Add(dt.Rows[i]["ColourName"]);
                }

                DatabaseAssist.ConnectToLexlets.Close();
                da.Dispose();
                dt.Dispose();
                dt.Clear();
            }

            category.Enabled = true;
        }
        public void GetCostandMaterialID(Label cost, Label id, Label cat, Label Col, ComboBox desc)
        {

            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlDataAdapter da = new SqlDataAdapter("Select MaterialId, CostPerItem FROM tblMaterials WHERE Category = @category AND ColourID = @colour AND Description =@desc", DatabaseAssist.ConnectToLexlets);
                da.SelectCommand.Parameters.AddWithValue("@category", Convert.ToInt32(cat.Text));
                da.SelectCommand.Parameters.AddWithValue("@colour", Convert.ToInt32(Col.Text));
                da.SelectCommand.Parameters.AddWithValue("@desc", desc.SelectedItem.ToString());
                DataTable dt = new DataTable();

                try
                {
                    da.Fill(dt);
                    cost.Text = (dt.Rows[0]["CostPerItem"].ToString());
                    id.Text = (dt.Rows[0]["MaterialId"].ToString());
                }

                catch
                {
                    MessageBox.Show("No Entries Found");
                }
                DatabaseAssist.ConnectToLexlets.Close();
                da.Dispose();
                dt.Dispose();
            }
        }


        public void GetCostOfRow(Label cost, TextBox qty, Label costPer)
        {
            try
            {
                int Qty = Convert.ToInt32(qty.Text);
                double Cost = Convert.ToDouble(costPer.Text);

                double Total = Qty * Cost;
                cost.Text = Total.ToString();
            }

            catch
            {
                MessageBox.Show("Please Enter A Number");
                qty.Text = "";
            }
        }

        private void PicAdd_Click(object sender, EventArgs e)
        {
            PicAdd.Visible = false;

            if (rowCount == 1)
            {
                FillCategory(CmbR2Category);
                pnlRow2.Visible = true;
                PicDelete.Visible = true;
                rowCount++;
                PicAdd.Location = new Point(PicAdd.Location.X, PicAdd.Location.Y + 32);

                return;
            }
            else if (rowCount == 2)
            {
                FillCategory(CmbR3Category);
                pnlRow3.Visible = true;
                rowCount++;
            }
            else if (rowCount == 3)
            {
                FillCategory(CmbR4Category);
                pnlRow4.Visible = true;
                rowCount++;
            }
            else if (rowCount == 4)
            {
                FillCategory(CmbR5Category);
                pnlRow5.Visible = true;
                rowCount++;
            }
            else if (rowCount == 5)
            {
                FillCategory(CmbR6Category);
                pnlRow6.Visible = true;
                rowCount++;
            }
            else if (rowCount == 6)
            {
                FillCategory(CmbR7Category);
                pnlRow7.Visible = true;
                rowCount++;
            }
            else if (rowCount == 7)
            {
                FillCategory(CmbR8Category);
                pnlRow8.Visible = true;
                rowCount++;
            }
            else if (rowCount == 8)
            {
                FillCategory(CmbR9Category);
                pnlRow9.Visible = true;
                rowCount++;
            }
            else if (rowCount == 9)
            {
                FillCategory(CmbR10Category);
                pnlRow10.Visible = true;
                PicAdd.Visible = false;
                rowCount++;
            }
            PicDelete.Location = new Point(PicDelete.Location.X, PicDelete.Location.Y + 32);
            PicAdd.Location = new Point(PicAdd.Location.X, PicAdd.Location.Y + 32);
        }

        private void CmbR2Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbR2Category.ForeColor = Color.Black;
            CmbR2Colour.Enabled = true;
            GetCatID(CmbR2Category, LblR2CatID);
            FillColour(CmbR2Colour, CmbR2Description);

        }

        public void GetCatID(ComboBox catName, Label labelID)
        {

            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlDataAdapter da = new SqlDataAdapter("Select CategoryID FROM tblMaterialCategory WHERE CategoryName = @name", DatabaseAssist.ConnectToLexlets);
                da.SelectCommand.Parameters.AddWithValue("@name", catName.SelectedItem.ToString());
                DataTable dt = new DataTable();

                da.Fill(dt);
                labelID.Text = (dt.Rows[0]["CategoryID"].ToString());

                DatabaseAssist.ConnectToLexlets.Close();
                da.Dispose();
                dt.Dispose();
                dt.Clear();
            }
        }

        public void GetColID(ComboBox colID, Label labelID)
        {

            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlDataAdapter da = new SqlDataAdapter("Select ColourID FROM tblColours WHERE ColourName = @name", DatabaseAssist.ConnectToLexlets);
                da.SelectCommand.Parameters.AddWithValue("@name", colID.SelectedItem);
                DataTable dt = new DataTable();

                da.Fill(dt);
                labelID.Text = (dt.Rows[0]["ColourID"].ToString());

                DatabaseAssist.ConnectToLexlets.Close();
                da.Dispose();
                dt.Dispose();
                dt.Clear();
            }
        }
        private void CmbR2Colour_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbR2Colour.ForeColor = Color.Black;
            GetColID(CmbR2Colour, LblR2ColId);
            FillDescription(CmbR2Description, LblR2CatID, LblR2ColId);
        }

        private void CmbR2Description_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbR2Description.ForeColor = Color.Black;
            GetCostandMaterialID(LblR2Cost, LblR2MatId, LblR2CatID, LblR2ColId, CmbR2Description);
        }


        private void LblR2Cost_TextChanged(object sender, EventArgs e)
        {
            TxtR2Qty.Enabled = true;
        }

        private void CmbR1Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbR1Category.ForeColor = Color.Black;
            CmbR1Colour.Enabled = true;
            CmbR1Description.Text = "";
            CmbR1Colour.Text = "";
            FillColour(CmbR1Colour, CmbR1Description);
            GetCatID(CmbR1Category, LblR1CatID);
        }

        private void CmbR1Colour_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbR1Colour.ForeColor = Color.Black;
            GetColID(CmbR1Colour, LblR1ColId);
            FillDescription(CmbR1Description, LblR1CatID, LblR1ColId);
        }

        private void CmbR1Description_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbR1Description.ForeColor = Color.Black;
            GetCostandMaterialID(LblR1Cost, LblR1MatId, LblR1CatID, LblR1ColId, CmbR1Description);
        }



        private void LblR1Cost_TextChanged(object sender, EventArgs e)
        {
            TxtR1Qty.Enabled = true;
        }

        private void CmbR3Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbR3Category.ForeColor = Color.Black;
            CmbR3Colour.Enabled = true;
            GetCatID(CmbR3Category, LblR3CatID);
            FillColour(CmbR3Colour, CmbR3Description);
        }

        private void CmbR3Colour_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbR3Colour.ForeColor = Color.Black;
            GetColID(CmbR3Colour, LblR3ColId);
            FillDescription(CmbR3Description, LblR3CatID, LblR3ColId);
        }

        private void CmbR3Description_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbR3Description.ForeColor = Color.Black;
            GetCostandMaterialID(LblR3Cost, LblR3MatId, LblR3CatID, LblR3ColId, CmbR3Description);
        }

        private void LblR3Cost_TextChanged(object sender, EventArgs e)
        {
            TxtR3Qty.Enabled = true;
        }

        private void CmbR4Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbR4Category.ForeColor = Color.Black;
            CmbR4Colour.Enabled = true;
            GetCatID(CmbR4Category, LblR4CatID);
            FillColour(CmbR4Colour, CmbR4Description);
        }

        private void CmbR5Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbR5Category.ForeColor = Color.Black;
            CmbR5Colour.Enabled = true;
            GetCatID(CmbR5Category, LblR5CatID);
            FillColour(CmbR5Colour, CmbR5Description);
        }

        private void CmbR6Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbR6Category.ForeColor = Color.Black;
            CmbR6Colour.Enabled = true;
            GetCatID(CmbR6Category, LblR6CatID);
            FillColour(CmbR6Colour, CmbR6Description);
        }

        private void CmbR7Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbR7Category.ForeColor = Color.Black;
            CmbR7Colour.Enabled = true;
            GetCatID(CmbR7Category, LblR7CatID);
            FillColour(CmbR7Colour, CmbR7Description);
        }

        private void CmbR8Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbR8Category.ForeColor = Color.Black;
            CmbR8Colour.Enabled = true;
            GetCatID(CmbR8Category, LblR8CatID);
            FillColour(CmbR8Colour, CmbR8Description);
        }

        private void CmbR9Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbR9Category.ForeColor = Color.Black;
            CmbR9Colour.Enabled = true;
            GetCatID(CmbR9Category, LblR9CatID);
            FillColour(CmbR9Colour, CmbR9Description);
        }

        private void CmbR10Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbR10Category.ForeColor = Color.Black;
            CmbR10Colour.Enabled = true;
            GetCatID(CmbR10Category, LblR10CatID);
            FillColour(CmbR10Colour, CmbR10Description);
        }

        private void CmbR4Colour_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbR4Colour.ForeColor = Color.Black;
            GetColID(CmbR4Colour, LblR4ColId);
            FillDescription(CmbR4Description, LblR4CatID, LblR4ColId);
        }

        private void CmbR5Colour_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbR5Colour.ForeColor = Color.Black;
            GetColID(CmbR5Colour, LblR5ColId);
            FillDescription(CmbR5Description, LblR5CatID, LblR5ColId);
        }

        private void CmbR6Colour_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbR6Colour.ForeColor = Color.Black;
            GetColID(CmbR6Colour, LblR6ColId);
            FillDescription(CmbR6Description, LblR6CatID, LblR6ColId);
        }

        private void CmbR7Colour_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbR7Colour.ForeColor = Color.Black;
            GetColID(CmbR7Colour, LblR7ColId);
            FillDescription(CmbR7Description, LblR7CatID, LblR7ColId);
        }

        private void CmbR8Colour_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbR8Colour.ForeColor = Color.Black;
            GetColID(CmbR8Colour, LblR8ColId);
            FillDescription(CmbR8Description, LblR8CatID, LblR8ColId);
        }

        private void CmbR9Colour_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbR9Colour.ForeColor = Color.Black;
            GetColID(CmbR9Colour, LblR9ColId);
            FillDescription(CmbR9Description, LblR9CatID, LblR9ColId);
        }

        private void CmbR10Colour_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbR10Colour.ForeColor = Color.Black;
            GetColID(CmbR10Colour, LblR10ColId);
            FillDescription(CmbR10Description, LblR10CatID, LblR10ColId);
        }

        private void CmbR4Description_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbR4Description.ForeColor = Color.Black;
            GetCostandMaterialID(LblR4Cost, LblR4MatId, LblR4CatID, LblR4ColId, CmbR4Description);
        }

        private void CmbR5Description_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbR5Description.ForeColor = Color.Black;
            GetCostandMaterialID(LblR5Cost, LblR5MatId, LblR5CatID, LblR5ColId, CmbR5Description);
        }

        private void CmbR6Description_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbR6Description.ForeColor = Color.Black;
            GetCostandMaterialID(LblR6Cost, LblR6MatId, LblR6CatID, LblR6ColId, CmbR6Description);
        }

        private void CmbR7Description_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbR7Description.ForeColor = Color.Black;
            GetCostandMaterialID(LblR7Cost, LblR7MatId, LblR7CatID, LblR7ColId, CmbR7Description);
        }

        private void CmbR8Description_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbR8Description.ForeColor = Color.Black;
            GetCostandMaterialID(LblR8Cost, LblR8MatId, LblR8CatID, LblR8ColId, CmbR8Description);
        }

        private void CmbR9Description_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbR9Description.ForeColor = Color.Black;
            GetCostandMaterialID(LblR9Cost, LblR9MatId, LblR9CatID, LblR9ColId, CmbR9Description);
        }

        private void CmbR10Description_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbR10Description.ForeColor = Color.Black;
            GetCostandMaterialID(LblR10Cost, LblR10MatId, LblR10CatID, LblR10ColId, CmbR10Description);
        }

        private void LblR4Cost_TextChanged(object sender, EventArgs e)
        {
            TxtR4Qty.Enabled = true;
        }

        private void LblR5Cost_TextChanged(object sender, EventArgs e)
        {
            TxtR5Qty.Enabled = true;
        }

        private void LblR6Cost_TextChanged(object sender, EventArgs e)
        {
            TxtR6Qty.Enabled = true;
        }

        private void LblR7Cost_TextChanged(object sender, EventArgs e)
        {
            TxtR7Qty.Enabled = true;
        }

        private void LblR8Cost_TextChanged(object sender, EventArgs e)
        {
            TxtR8Qty.Enabled = true;
        }

        private void LblR9Cost_TextChanged(object sender, EventArgs e)
        {
            TxtR9Qty.Enabled = true;
        }

        private void LblR10Cost_TextChanged(object sender, EventArgs e)
        {
            TxtR10Qty.Enabled = true;
        }


        private void PicDelete_Click(object sender, EventArgs e)
        {

            if (rowCount == 2)
            {
                CmbR1Category.Enabled = true;
                PicDelete.Visible = false;
                pnlRow2.Visible = false;
                ClearRow(LblR2CatID, LblR2ColId, LblR2MatId, CmbR2Category, CmbR2Colour, CmbR2Description, LblR2Cost, TxtR2Qty, LblR2Total);
                PicAdd.Location = new Point(PicAdd.Location.X, PicAdd.Location.Y - 32);
                rowCount--;

                return;
            }
            if (rowCount == 3)
            {
                CmbR2Category.Enabled = true;
                pnlRow3.Visible = false;
                ClearRow(LblR3CatID, LblR3ColId, LblR3MatId, CmbR3Category, CmbR3Colour, CmbR3Description, LblR3Cost, TxtR3Qty, LblR3Total);
                DeleteFromTotal(LblR2Total);
                rowCount--;
            }
            else if (rowCount == 4)
            {
                CmbR3Category.Enabled = true;
                pnlRow4.Visible = false;
                ClearRow(LblR4CatID, LblR4ColId, LblR4MatId, CmbR4Category, CmbR4Colour, CmbR4Description, LblR4Cost, TxtR4Qty, LblR4Total);
                DeleteFromTotal(LblR3Total);
                rowCount--;
            }
            else if (rowCount == 5)
            {
                CmbR4Category.Enabled = true;
                pnlRow5.Visible = false;
                ClearRow(LblR5CatID, LblR5ColId, LblR5MatId, CmbR5Category, CmbR5Colour, CmbR5Description, LblR5Cost, TxtR5Qty, LblR5Total);
                DeleteFromTotal(LblR4Total);
                rowCount--;
            }
            else if (rowCount == 6)
            {
                CmbR5Category.Enabled = true;
                pnlRow6.Visible = false;
                ClearRow(LblR2CatID, LblR6ColId, LblR6MatId, CmbR6Category, CmbR6Colour, CmbR6Description, LblR6Cost, TxtR6Qty, LblR6Total);
                DeleteFromTotal(LblR5Total);
                rowCount--;
            }
            else if (rowCount == 7)
            {
                CmbR6Category.Enabled = true;
                pnlRow7.Visible = false;
                ClearRow(LblR7CatID, LblR7ColId, LblR7MatId, CmbR7Category, CmbR7Colour, CmbR7Description, LblR7Cost, TxtR7Qty, LblR7Total);
                DeleteFromTotal(LblR6Total);
                rowCount--;
            }
            else if (rowCount == 8)
            {
                CmbR7Category.Enabled = true;
                pnlRow8.Visible = false;
                ClearRow(LblR8CatID, LblR8ColId, LblR8MatId, CmbR8Category, CmbR8Colour, CmbR8Description, LblR8Cost, TxtR8Qty, LblR8Total);
                DeleteFromTotal(LblR7Total);
                rowCount--;
            }
            else if (rowCount == 9)
            {
                CmbR8Category.Enabled = true;
                pnlRow9.Visible = false;
                ClearRow(LblR9CatID, LblR9ColId, LblR9MatId, CmbR9Category, CmbR9Colour, CmbR9Description, LblR9Cost, TxtR9Qty, LblR9Total);
                DeleteFromTotal(LblR8Total);
                rowCount--;
            }
            else if (rowCount == 10)
            {
                CmbR9Category.Enabled = true;
                pnlRow10.Visible = false;
                ClearRow(LblR10CatID, LblR10ColId, LblR10MatId, CmbR10Category, CmbR10Colour, CmbR10Description, LblR10Cost, TxtR10Qty, LblR10Total);
                rowCount--;
                DeleteFromTotal(LblR9Total);
                PicAdd.Visible = true;
            }


            PicDelete.Location = new Point(PicDelete.Location.X, PicDelete.Location.Y - 32);
            PicAdd.Location = new Point(PicAdd.Location.X, PicAdd.Location.Y - 32);
        }

        public void ClearRow(Label LblCat, Label LblCol, Label LblMat, ComboBox CmbCat, ComboBox CmbCol, ComboBox CmbDesc, Label LblCost, TextBox TxtQty, Label LblTotal)
        {
            LblCat.Text = "";
            LblCol.Text = "";
            LblMat.Text = "";
            CmbCat.Items.Clear();
            CmbCat.Text = "";
            CmbCol.Items.Clear();
            CmbCol.Enabled = false;
            CmbCol.Text = "";
            CmbDesc.Enabled = false;
            CmbDesc.Items.Clear();
            CmbDesc.Text = "";
            LblCost.Text = "";
            TxtQty.Text = "";
            TxtQty.Enabled = false;
            LblTotal.Text = "";
        }

        private void TxtR1Qty_KeyUp(object sender, KeyEventArgs e)
        {
            TxtR1Qty.ForeColor = Color.Black;
            GetCostOfRow(LblR1Total, TxtR1Qty, LblR1Cost);
        }

        private void TxtR2Qty_KeyUp(object sender, KeyEventArgs e)
        {
            TxtR2Qty.ForeColor = Color.Black;
            GetCostOfRow(LblR2Total, TxtR2Qty, LblR2Cost);
        }

        private void TxtR3Qty_KeyUp(object sender, KeyEventArgs e)
        {
            TxtR3Qty.ForeColor = Color.Black;
            GetCostOfRow(LblR3Total, TxtR3Qty, LblR3Cost);
        }

        private void TxtR4Qty_KeyUp(object sender, KeyEventArgs e)
        {
            TxtR4Qty.ForeColor = Color.Black;
            GetCostOfRow(LblR4Total, TxtR4Qty, LblR4Cost);
        }

        private void TxtR5Qty_KeyUp(object sender, KeyEventArgs e)
        {
            TxtR5Qty.ForeColor = Color.Black;
            GetCostOfRow(LblR5Total, TxtR5Qty, LblR5Cost);
        }

        private void TxtR6Qty_KeyUp(object sender, KeyEventArgs e)
        {
            TxtR6Qty.ForeColor = Color.Black;
            GetCostOfRow(LblR6Total, TxtR6Qty, LblR6Cost);
        }

        private void TxtR7Qty_KeyUp(object sender, KeyEventArgs e)
        {
            TxtR7Qty.ForeColor = Color.Black;
            GetCostOfRow(LblR7Total, TxtR7Qty, LblR7Cost);
        }

        private void TxtR8Qty_KeyUp(object sender, KeyEventArgs e)
        {
            TxtR8Qty.ForeColor = Color.Black;
            GetCostOfRow(LblR8Total, TxtR8Qty, LblR8Cost);
        }

        private void TxtR9Qty_KeyUp(object sender, KeyEventArgs e)
        {
            TxtR9Qty.ForeColor = Color.Black;
            GetCostOfRow(LblR9Total, TxtR9Qty, LblR9Cost);
        }

        private void TxtR10Qty_KeyUp(object sender, KeyEventArgs e)
        {
            TxtR10Qty.ForeColor = Color.Black;
            GetCostOfRow(LblR10Total, TxtR10Qty, LblR10Cost);
        }

        private void LblR1Total_TextChanged(object sender, EventArgs e)
        {
            PicAdd.Visible = true;
            BtnDone.Enabled = true;
        }

        private void LblR2Total_TextChanged(object sender, EventArgs e)
        {
            PicAdd.Visible = true;
        }

        private void LblR3Total_TextChanged(object sender, EventArgs e)
        {
            PicAdd.Visible = true;
        }

        private void LblR4Total_TextChanged(object sender, EventArgs e)
        {
            PicAdd.Visible = true;
        }

        private void LblR5Total_TextChanged(object sender, EventArgs e)
        {
            PicAdd.Visible = true;
        }

        private void LblR6Total_TextChanged(object sender, EventArgs e)
        {
            PicAdd.Visible = true;
        }

        private void LblR7Total_TextChanged(object sender, EventArgs e)
        {
            PicAdd.Visible = true;
        }

        private void LblR8Total_TextChanged(object sender, EventArgs e)
        {
            PicAdd.Visible = true;
        }

        private void LblR9Total_TextChanged(object sender, EventArgs e)
        {
            PicAdd.Visible = true;
        }

        private void BtnDone_Click(object sender, EventArgs e)
        {
            if (ValidateMaterials() != 0)
            {
                MessageBox.Show("Please Correct Fields In Red", "Invalid Entry");
            }
            else
            {

                totalprice = 0;
                BtnDone.Visible = false;
                gbxProductDetails.Enabled = true;
                gbxMaterials.Enabled = false;
                BtnEdit.Visible = true;
                pnlAddDelete.Visible = false;
                CalculateCost();
                BtnSave.Enabled = true;
                //GetLastSKU();
                GetSuggestedPrice();
                FillProductCategory();
                TxtDescription.Focus();
            }
        }

        public int ValidateMaterials()
        {
            int check = 0;
            ComboBox[] combos = { CmbR1Category, CmbR2Category, CmbR3Category, CmbR4Category, CmbR5Category, CmbR6Category,
                                  CmbR7Category, CmbR8Category, CmbR9Category, CmbR10Category,
                                  CmbR1Colour, CmbR2Colour, CmbR3Colour, CmbR4Colour, CmbR5Colour, CmbR6Colour, CmbR7Colour,
                                  CmbR8Colour, CmbR9Colour, CmbR10Colour,
                                  CmbR1Description, CmbR2Description, CmbR3Description, CmbR4Description, CmbR5Description,
                                  CmbR6Description, CmbR7Description, CmbR8Description, CmbR9Description, CmbR10Description};
            TextBox[] textBox = { TxtR1Qty, TxtR2Qty, TxtR3Qty, TxtR4Qty, TxtR5Qty, TxtR6Qty, TxtR7Qty, TxtR8Qty, TxtR9Qty, TxtR10Qty, };

            foreach (ComboBox combo in combos)
            {
                if (combo.Visible == true)
                {
                    if (combo.SelectedIndex == -1)
                    {
                        combo.ForeColor = Color.Red;
                        check++;
                    }
                }
            }

            foreach (TextBox text in textBox)
            {
                if (text.Visible == true)
                {
                    try
                    {
                        Convert.ToInt32(text.Text);
                    }

                    catch
                    {
                        text.ForeColor = Color.Red;
                        check++;
                    }

                }
            }
            return check;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            BtnEdit.Visible = false;
            gbxProductDetails.Enabled = false;
            pnlAddDelete.Visible = true;
            gbxMaterials.Enabled = true;
            BtnDone.Visible = true;
        }



        public void DeleteFromTotal(Label num)
        {
            totalprice = totalprice - Convert.ToDouble(num.Text);
            TxtCost.Text = totalprice.ToString();
        }

        public void CalculateCost()
        {
            Label[] RowTotal = { LblR1Total, LblR2Total, LblR3Total, LblR4Total, LblR5Total,
                                 LblR6Total, LblR7Total, LblR8Total, LblR9Total, LblR10Total };


            foreach (Label label in RowTotal)
            {
                if (!String.IsNullOrEmpty(label.Text))
                {
                    totalprice = totalprice + Convert.ToDouble(label.Text);
                }
            }
            TxtCost.Text = totalprice.ToString();
        }

        public void GetLastSKU()
        {
            int tempSKU;

            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlDataAdapter da = new SqlDataAdapter("Select TOP 1 * FROM tblProductData ORDER BY SKU DESC", DatabaseAssist.ConnectToLexlets);
                DataTable dt = new DataTable();

                da.Fill(dt);
                tempSKU = Convert.ToInt32(dt.Rows[0]["SKU"]);
                tempSKU++;
                lastSKU = tempSKU;
                TxtSKU.Text = tempSKU.ToString();

                DatabaseAssist.ConnectToLexlets.Close();
                da.Dispose();
                dt.Dispose();
                dt.Clear();
            }
        }

        public void CheckForDuplicateSKU()
        {
            int tempSKU;

            try
            {
                int checkSKU = Convert.ToInt32(TxtSKU.Text);


                if (DatabaseAssist.ConnectToDatabase() == true)
                {
                    SqlDataAdapter da = new SqlDataAdapter("Select SKU FROM tblProductData", DatabaseAssist.ConnectToLexlets);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        tempSKU = Convert.ToInt32(dt.Rows[i]["SKU"]);
                        if (tempSKU == checkSKU)
                        {
                            MessageBox.Show("SKU Already Exists, Next available is " + lastSKU);
                            TxtSKU.Focus();
                        }
                    }

                    DatabaseAssist.ConnectToLexlets.Close();
                    da.Dispose();
                    dt.Dispose();
                    dt.Clear();
                }
            }


            catch
            {
                MessageBox.Show("SKU Must be a number");
                TxtSKU.Text = "";
            }

        }

        public void GetSuggestedPrice()
        {
            LblSuggested.Visible = true;
            double suggestedPrice = Convert.ToDouble(TxtCost.Text);
            suggestedPrice = Math.Ceiling(suggestedPrice + 18);
            LblSuggested.Text = "Suggested Price £" + suggestedPrice.ToString();

        }

        public void FillProductCategory()
        {


            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlDataAdapter da = new SqlDataAdapter("Select ProductCategoryDescription FROM tblProductCategory ORDER BY ProductCategoryDescription ASC", DatabaseAssist.ConnectToLexlets);
                DataTable dt = new DataTable();

                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CmbCategory.Items.Add(dt.Rows[i]["ProductCategoryDescription"]);
                }

                DatabaseAssist.ConnectToLexlets.Close();
                da.Dispose();
                dt.Dispose();
                dt.Clear();
            }
        }

        private void BtnAttachImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png)"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string PicPath = dlg.FileName.ToString();
                TxtPicPath.Text = PicPath;
                PicImage.ImageLocation = PicPath;

            }

            LblAddImage.Visible = false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateDetails() != 0)
            {
                MessageBox.Show("Please Correct The Fields In Red");
            }
            else
            {

                Panel[] panelRows = { pnlRow2, pnlRow3, pnlRow4, pnlRow5, pnlRow6, pnlRow7, pnlRow8, pnlRow9, pnlRow10 };
                int prodCatID;
                byte[] imagebt = null;

                if (!String.IsNullOrEmpty(TxtPicPath.Text))
                {
                    FileStream fstream = new FileStream(TxtPicPath.Text, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fstream);
                    imagebt = br.ReadBytes((int)fstream.Length);
                }


                SqlCommand command, commandImage;
                SqlDataAdapter adapter = new SqlDataAdapter();

                // Fills temp data table with materials used to make the product

                FillDataTableWithMaterials();

                if (DatabaseAssist.ConnectToDatabase() == true)
                {

                    // Gets Product Category ID From combobox's selected item ready for Insert Into New Datatable

                    SqlDataAdapter da = new SqlDataAdapter("SELECT ProductCategoryID FROM tblProductCategory WHERE ProductCategoryDescription = @desc", DatabaseAssist.ConnectToLexlets);
                    da.SelectCommand.Parameters.AddWithValue("@desc", CmbCategory.SelectedItem);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    prodCatID = Convert.ToInt32(dt.Rows[0]["ProductCategoryID"]);

                    // Removes old data and inserts temp Data Table into tblProductContains Database

                    SqlCommand removematerials = new SqlCommand(@"DELETE FROM tblProductContains WHERE SKU = @sku", DatabaseAssist.ConnectToLexlets);
                    removematerials.Parameters.AddWithValue("@sku", Convert.ToInt32(TxtSKU.Text));
                    removematerials.ExecuteNonQuery();

                    for (int j = 0; j < DataGridMaterials.Rows.Count - 1; j++)
                    {
                        SqlCommand cmd = new SqlCommand(@"INSERT INTO tblProductContains (SKU, MaterialID, MaterialQTY) VALUES ('" + DataGridMaterials.Rows[j].Cells[0].Value + "','" + DataGridMaterials.Rows[j].Cells[1].Value + "','" + DataGridMaterials.Rows[j].Cells[2].Value + "')", DatabaseAssist.ConnectToLexlets);
                        cmd.ExecuteNonQuery();
                    }

                    DataGridMaterials.Rows.Clear();

                    // Inserts Data into tblProductData


                    command = new SqlCommand(@"UPDATE tblProductData SET Category = @catID, Description = @Desc, CostToMake = @cost, SellPrice = @sell WHERE SKU = @sku", DatabaseAssist.ConnectToLexlets);

                    command.Parameters.AddWithValue("@sku", Convert.ToInt32(TxtSKU.Text));
                    command.Parameters.AddWithValue("@catID", CmbCategory.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@desc", TxtDescription.Text);
                    command.Parameters.AddWithValue("@cost", Convert.ToDouble(TxtCost.Text));
                    command.Parameters.AddWithValue("@sell", Convert.ToDouble(TxtPrice.Text));

                    if (!String.IsNullOrEmpty(TxtPicPath.Text))
                    {
                        commandImage = new SqlCommand(@"UPDATE tblProductData SET Image = @image WHERE SKU = @sku", DatabaseAssist.ConnectToLexlets);
                        commandImage.Parameters.AddWithValue("@sku", Convert.ToInt32(TxtSKU.Text));
                        commandImage.Parameters.AddWithValue("@image", imagebt);
                        commandImage.ExecuteNonQuery();
                        commandImage.Dispose();
                    }



                    int i = command.ExecuteNonQuery();


                    command.Dispose();
                    DatabaseAssist.ConnectToLexlets.Close();

                    if (i != 0)
                    {
                        User.AddToUserLog("Update Product", User.Username + " Updated Product (" + CmbCategory.SelectedItem.ToString() + " - " + TxtDescription.Text + ")");
                        DialogResult result = MessageBox.Show("Product Updated - Would You Like To Change Another?", "Success", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            ClearEverything();
                            ChangeProduct();
                            foreach (Panel panel in panelRows)
                            {
                                panel.Visible = false;
                            }
                            FillCategory(CmbR1Category);
                        }
                        else
                        {
                            this.Close();
                        }


                    }

                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
            }
        }

        public void ClearEverything()
        {

            CmbCategory.SelectedItem = "";
            CmbCategory.Text = "";
            TxtSKU.Text = "";
            TxtDescription.Text = "";
            TxtCost.Text = "";
            TxtPrice.Text = "";
            PicImage.ImageLocation = "";
            PicImage.Image = null;
            TxtPicPath.Text = "";
            ClearRow(LblR1CatID, LblR1ColId, LblR1MatId, CmbR1Category, CmbR1Colour, CmbR1Description, LblR1Cost, TxtR1Qty, LblR1Total);
            ClearRow(LblR2CatID, LblR2ColId, LblR2MatId, CmbR2Category, CmbR2Colour, CmbR2Description, LblR2Cost, TxtR2Qty, LblR2Total);
            ClearRow(LblR3CatID, LblR3ColId, LblR3MatId, CmbR3Category, CmbR3Colour, CmbR3Description, LblR3Cost, TxtR3Qty, LblR3Total);
            ClearRow(LblR4CatID, LblR4ColId, LblR4MatId, CmbR4Category, CmbR4Colour, CmbR4Description, LblR4Cost, TxtR4Qty, LblR4Total);
            ClearRow(LblR5CatID, LblR5ColId, LblR5MatId, CmbR5Category, CmbR5Colour, CmbR5Description, LblR5Cost, TxtR5Qty, LblR5Total);
            ClearRow(LblR6CatID, LblR6ColId, LblR6MatId, CmbR6Category, CmbR6Colour, CmbR6Description, LblR6Cost, TxtR6Qty, LblR6Total);
            ClearRow(LblR7CatID, LblR7ColId, LblR7MatId, CmbR7Category, CmbR7Colour, CmbR7Description, LblR7Cost, TxtR7Qty, LblR7Total);
            ClearRow(LblR8CatID, LblR8ColId, LblR8MatId, CmbR8Category, CmbR8Colour, CmbR8Description, LblR8Cost, TxtR8Qty, LblR8Total);
            ClearRow(LblR9CatID, LblR9ColId, LblR9MatId, CmbR9Category, CmbR9Colour, CmbR9Description, LblR9Cost, TxtR9Qty, LblR9Total);
            ClearRow(LblR10CatID, LblR10ColId, LblR10MatId, CmbR10Category, CmbR10Colour, CmbR10Description, LblR10Cost, TxtR10Qty, LblR10Total);
            pnlRow2.Visible = false;
            pnlRow3.Visible = false;
            pnlRow4.Visible = false;
            pnlRow5.Visible = false;
            pnlRow6.Visible = false;
            pnlRow7.Visible = false;
            pnlRow8.Visible = false;
            pnlRow9.Visible = false;
            pnlRow10.Visible = false;
            gbxProductDetails.Enabled = false;
            PicAdd.Location = new Point(11, 48);
            PicDelete.Location = new Point(11, 48);
            PicAdd.Visible = false;
            PicDelete.Visible = false;
            pnlAddDelete.Visible = true;
            CmbR1Category.Focus();
            BtnEdit.Visible = false;
            BtnDone.Visible = true;
            gbxMaterials.Enabled = true;
            CmbCategory.Enabled = false;
            TxtCost.Enabled = false;
            TxtPrice.Enabled = false;
            BtnAttachImage.Enabled = false;
            BtnSave.Enabled = false;
            BtnDone.Enabled = false;


        }

        public int ValidateDetails()
        {
            int faults = 0;

            if (CmbCategory.SelectedIndex == -1)
            {
                CmbCategory.ForeColor = Color.Red;
                faults++;
            }

            if (String.IsNullOrEmpty(TxtDescription.Text) || (TxtDescription.Text == "Please Enter a Description"))
            {
                TxtDescription.Text = "Please Enter a Description";
                TxtDescription.ForeColor = Color.Red;
                faults++;
            }
            /*
            if (String.IsNullOrEmpty(TxtPicPath.Text))
            {
                LblAddImage.Visible = true;
                faults++;
            }
            */
            try
            {
                Convert.ToDouble(TxtCost.Text);
            }

            catch
            {
                TxtCost.ForeColor = Color.Red;
                faults++;
            }

            try
            {
                Convert.ToDouble(TxtPrice.Text);
            }

            catch
            {
                TxtPrice.ForeColor = Color.Red;
                faults++;
            }


            return faults;
        }

        public void FillDataTableWithMaterials()
        {
            DataGridMaterials.Enabled = false;
            DataGridMaterials.ColumnCount = 3;
            DataGridMaterials.Columns[0].Name = "ProductID";
            DataGridMaterials.Columns[1].Name = "MaterialID";
            DataGridMaterials.Columns[2].Name = "MaterialQty";

            ArrayList row = new ArrayList();

            AddToDataTable(row, LblR1Total, TxtSKU, LblR1MatId, TxtR1Qty);
            AddToDataTable(row, LblR2Total, TxtSKU, LblR2MatId, TxtR2Qty);
            AddToDataTable(row, LblR3Total, TxtSKU, LblR3MatId, TxtR3Qty);
            AddToDataTable(row, LblR4Total, TxtSKU, LblR4MatId, TxtR4Qty);
            AddToDataTable(row, LblR5Total, TxtSKU, LblR5MatId, TxtR5Qty);
            AddToDataTable(row, LblR6Total, TxtSKU, LblR6MatId, TxtR6Qty);
            AddToDataTable(row, LblR7Total, TxtSKU, LblR7MatId, TxtR7Qty);
            AddToDataTable(row, LblR8Total, TxtSKU, LblR8MatId, TxtR8Qty);
            AddToDataTable(row, LblR9Total, TxtSKU, LblR9MatId, TxtR9Qty);
            AddToDataTable(row, LblR10Total, TxtSKU, LblR10MatId, TxtR10Qty);


        }

        public void AddToDataTable(ArrayList row, Label total, TextBox SKU, Label Matid, TextBox qty)
        {
            if (!String.IsNullOrEmpty(total.Text))
            {
                row = new ArrayList {
                Convert.ToInt32(SKU.Text),
                Convert.ToInt32(Matid.Text),
                Convert.ToInt32(qty.Text)
                };
                DataGridMaterials.Rows.Add(row.ToArray());
            }
        }




        private void TxtDescription_TextChanged(object sender, EventArgs e)
        {
            TxtDescription.ForeColor = Color.Black;
            CmbCategory.Enabled = true;
        }

        private void CmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbCategory.ForeColor = Color.Black;
            TxtCost.Enabled = true;
            TxtPrice.Enabled = true;
        }

        private void TxtPicPath_TextChanged(object sender, EventArgs e)
        {
            BtnSave.Enabled = true;
        }

        private void TxtPrice_TextChanged(object sender, EventArgs e)
        {
            TxtPrice.ForeColor = Color.Black;
            BtnAttachImage.Enabled = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ClearEverything();
            this.Close();
        }

        public void ValidateInputInt(TextBox text)
        {
            if (!String.IsNullOrEmpty(text.Text))
            {
                try
                {
                    Convert.ToInt32(text.Text);
                }

                catch
                {

                }
            }
        }

        private void TxtSKU_Leave(object sender, EventArgs e)
        {
            CheckForDuplicateSKU();
        }

        private void TxtCost_TextChanged(object sender, EventArgs e)
        {
            TxtCost.ForeColor = Color.Black;
        }

        private void TextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            string byDescription = TxtByDescription.Text;


            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select SKU, Category, Description, SellPrice From tblProductData WHERE Description LIKE '%'+@bydesc+'%'", DatabaseAssist.ConnectToLexlets);
                adapter.SelectCommand.Parameters.AddWithValue("@byDesc", byDescription);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tblProducts");
                DataGridView1.DataSource = ds;
                DataGridView1.DataMember = "tblProducts";
                DatabaseAssist.ConnectToLexlets.Close();
            }

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Panel[] panelRows = { pnlRow2, pnlRow3, pnlRow4, pnlRow5, pnlRow6, pnlRow7, pnlRow8, pnlRow9, pnlRow10 };
            ComboBox[] category = { CmbR1Category, CmbR2Category, CmbR3Category, CmbR4Category, CmbR5Category, CmbR6Category,
                                    CmbR7Category, CmbR8Category, CmbR9Category, CmbR10Category};
            ComboBox[] colour = { CmbR1Colour, CmbR2Colour, CmbR3Colour, CmbR4Colour, CmbR5Colour, CmbR6Colour, CmbR7Colour,
                                 CmbR8Colour, CmbR9Colour, CmbR10Colour};
            ComboBox[] description = {CmbR1Description, CmbR2Description, CmbR3Description, CmbR4Description, CmbR5Description,
                                        CmbR6Description, CmbR7Description, CmbR8Description, CmbR9Description, CmbR10Description };
            Label[] cost = { LblR1Cost, LblR2Cost, LblR3Cost, LblR4Cost, LblR5Cost, LblR7Cost, LblR8Cost, LblR9Cost, LblR10Cost };

            TextBox[] qty = { TxtR1Qty, TxtR2Qty, TxtR3Qty, TxtR4Qty, TxtR5Qty, TxtR6Qty, TxtR7Qty, TxtR8Qty, TxtR9Qty, TxtR10Qty };

            Label[] total = { LblR1Total, LblR2Total, LblR3Total, LblR4Total, LblR5Total, LblR6Total, LblR7Total, LblR8Total, LblR9Total, LblR10Total, };


            int countrows = 0;
            int id = Convert.ToInt32(DataGridView1.Rows[e.RowIndex].Cells["SKU"].Value.ToString());
            string categoryDescription = (DataGridView1.Rows[e.RowIndex].Cells["Category"].Value.ToString());

            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlCommand cmd = DatabaseAssist.ConnectToLexlets.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from tblProductData where SKU = @SKU";
                cmd.Parameters.AddWithValue("@SKU", id);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                TxtSKU.Text = id.ToString();
                Button1.Enabled = true;

                foreach (DataRow dr in dt.Rows)
                {
                    TxtDescription.Text = dr["Description"].ToString();
                    TxtCost.Text = dr["CostToMake"].ToString();
                    CmbCategory.SelectedItem = categoryDescription;
                    CmbCategory.SelectedValue = categoryDescription;
                    CmbCategory.Text = categoryDescription;
                    TxtPrice.Text = dr["SellPrice"].ToString();

                    Image x = (Bitmap)((new ImageConverter()).ConvertFrom(dr["Image"]));
                    PicImage.Image = x;

                }

                SqlCommand cmd2 = DatabaseAssist.ConnectToLexlets.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "SELECT tblProductContains.SKU, tblProductContains.MaterialID, tblProductContains.MaterialQTY, " +
                                   "tblMaterialCategory.CategoryName, tblColours.ColourName, tblMaterials.Description, tblMaterials.CostPerItem " +
                                   "FROM (((tblProductContains " +
                                   "Inner Join tblMaterials on tblProductContains.MaterialID = tblMaterials.MaterialId) " +
                                   "Inner Join tblMaterialCategory on tblMaterials.Category = tblMaterialCategory.CategoryId) " +
                                   "Inner Join tblColours on tblMaterials.ColourID = tblColours.ColourId) WHERE tblProductContains.SKU = @SKU";
                cmd2.Parameters.AddWithValue("@SKU", id);
                cmd2.ExecuteNonQuery();
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                da2.Fill(dt2);
                DatabaseAssist.ConnectToLexlets.Close();

                foreach (DataRow dr in dt2.Rows)
                {
                    countrows++;
                }

                rowCount = countrows;
                bool first = true;

                for (int i = 0; i < countrows; i++)
                {
                    double costper = 0;
                    double totalcost = 0;
                    int quantity = 0;
                    FillCategory(category[i]);
                    FillColour(colour[i], category[i]);

                    panelRows[i].Visible = true;
                    category[i].Text = dt2.Rows[i]["CategoryName"].ToString();
                    category[i].Enabled = false;
                    colour[i].Text = dt2.Rows[i]["ColourName"].ToString();
                    colour[i].Enabled = false;
                    description[i].Text = dt2.Rows[i]["Description"].ToString();
                    description[i].Enabled = false;
                    cost[i].Text = dt2.Rows[i]["CostPerItem"].ToString();
                    cost[i].Enabled = false;
                    qty[i].Text = dt2.Rows[i]["MaterialQTY"].ToString();
                    cost[i].Enabled = false;
                    costper = Convert.ToDouble(cost[i].Text);
                    quantity = Convert.ToInt32(qty[i].Text);
                    totalcost = costper * quantity;
                    total[i].Text = totalcost.ToString();

                    if (i == 0)
                    {
                        // skips the code below on first iteration on loop
                    }
                    else
                    {

                        if (first == true)
                        {
                            pnlAddDelete.Location = new Point(4, 82);
                            PicAdd.Location = new Point(PicAdd.Location.X, PicAdd.Location.Y + 32);
                            first = false;
                        }
                        else
                        {
                            PicDelete.Location = new Point(PicDelete.Location.X, PicDelete.Location.Y + 32);
                            PicAdd.Location = new Point(PicAdd.Location.X, PicAdd.Location.Y + 32);
                        }
                    }
                }


                panelRows[countrows - 1].Visible = false;
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            gbxSearch.Visible = false;
            PicAdd.Visible = true;
            PicDelete.Visible = true;
            gbxMaterials.Visible = true;
            gbxProductDetails.Visible = true;
            pnlAddDelete.Visible = true;
            BtnDone.Visible = true;
            BtnChange.Visible = true;

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            ChangeProduct();
        }

        private void ChangeProduct()
        {
            ClearEverything();
            gbxMaterials.Visible = false;
            gbxProductDetails.Visible = false;
            pnlAddDelete.Visible = false;
            PicAdd.Location = new Point(8, 39);
            PicDelete.Location = new Point(8, 39);
            gbxSearch.Visible = true;
            BtnChange.Visible = false;
            BtnDone.Visible = false;
            rowCount = 1;
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            if (DatabaseAssist.ConnectToDatabase() == true)
            {
                SqlCommand cmd = new SqlCommand("DELETE from tblProductData WHERE SKU = @sku", DatabaseAssist.ConnectToLexlets);
                SqlCommand cmd2 = new SqlCommand("DELETE from tblProductContains WHERE SKU = @sku", DatabaseAssist.ConnectToLexlets);

                cmd.Parameters.AddWithValue("@sku", Convert.ToInt32(TxtSKU.Text));
                cmd2.Parameters.AddWithValue("@sku", Convert.ToInt32(TxtSKU.Text));
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                DatabaseAssist.ConnectToLexlets.Close();
                cmd.Dispose();
                cmd2.Dispose();
                User.AddToUserLog("Delete Product", User.Username + " Deleted Product (" + CmbCategory.SelectedItem.ToString() + " - " + TxtDescription.Text + ")");
                MessageBox.Show("Product Deleted", "Success");
                ClearEverything();
                gbxMaterials.Visible = false;
                gbxProductDetails.Visible = false;
                pnlAddDelete.Visible = false;
                PicAdd.Location = new Point(8, 39);
                PicDelete.Location = new Point(8, 39);
                gbxSearch.Visible = true;
                BtnChange.Visible = false;
                rowCount = 1;

            }
        }

        private void TxtBySKU_KeyUp(object sender, KeyEventArgs e)
        {
            string bySKU = TxtBySKU.Text;

            if (Helper.CheckTextBoxForString(TxtBySKU.Text) == "notnumber")
            {
                MessageBox.Show("SKU Numbers do not contain letters, Please Enter a Number", "Invalid Charactor");
                TxtBySKU.Text = "";
                TxtBySKU.Focus();
            }
            else
            {
                if (DatabaseAssist.ConnectToDatabase() == true)
                {


                    SqlDataAdapter adapter = new SqlDataAdapter("select SKU, Category, Description, SellPrice FROM tblProductData WHERE SKU = @bysku", DatabaseAssist.ConnectToLexlets);
                    adapter.SelectCommand.Parameters.AddWithValue("@bysku", bySKU);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "tblProducts");
                    DataGridView1.DataSource = ds;
                    DataGridView1.DataMember = "tblProducts";
                    DataGridView1.Columns["Category"].Width = 150;
                }
            }
        }

        private void TxtByDescription_Enter(object sender, EventArgs e)
        {
            TxtBySKU.Text = "";

        }

        private void TxtBySKU_Enter(object sender, EventArgs e)
        {
            TxtByDescription.Text = "";
        }
    }
}

