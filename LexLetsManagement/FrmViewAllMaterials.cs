using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LexLetsManagement
{
    public partial class FrmViewAllMaterials : Form
    {
        public FrmViewAllMaterials()
        {
            InitializeComponent();
        }
        private void Testform_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            DataGridMaterials.DataSource = null;

            lblTotalCost.Text = "£" + DatabaseAssist.GetOneCellValue("SELECT ROUND(SUM(MaterialWorth),2) From vwMaterialsWithUsed", "", "Column1");
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "";
            if (DatabaseAssist.ConnectToDatabase() == true)
            {

                if (chkLowLevel.Checked)
                {
                    sql = "SELECT * FROM vwMaterialsWithUsed where QTYinStock <= LowLevelWarning Order By MaterialId";
                }
                else
                {
                    sql = "SELECT * FROM vwMaterialsWithUsed Order By MaterialId";
                }

                command = new SqlCommand(sql, DatabaseAssist.ConnectToLexlets);
                adapter.SelectCommand = command;
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tblMaterials");
                DataGridMaterials.DataSource = ds;
                DataGridMaterials.DataMember = "tblMaterials";
                DataGridMaterials.Columns["MaterialId"].HeaderText = "Id";
                DataGridMaterials.Columns["CategoryName"].HeaderText = "Category";
                DataGridMaterials.Columns["ColourName"].HeaderText = "Colour";
                DataGridMaterials.Columns["QTYinStock"].HeaderText = "Quanity";
                DataGridMaterials.Columns["LowLevelWarning"].HeaderText = "Low Alarm";
                DataGridMaterials.Columns["CostPerItem"].HeaderText = "Cost";
                DataGridMaterials.Columns["CostPerItem"].DefaultCellStyle.Format = "£0.00";
                DataGridMaterials.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                SqlCommand command2 = new SqlCommand("Select * from vwMaterialsUsed order by MaterialId asc", DatabaseAssist.ConnectToLexlets);
                SqlDataAdapter ad2 = new SqlDataAdapter();
                ad2.SelectCommand = command2;
                DataSet ds2 = new DataSet();
                ad2.Fill(ds2, "table2");
                DatabaseAssist.ConnectToLexlets.Close();
            }
        }


        private void DataGridMaterials_DataSourceChanged(object sender, EventArgs e)
        {
            //DataGridMaterials.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //DataGridMaterials.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //DataGridMaterials.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //DataGrid has calculated it's widths so we can store them

            for (int i = 0; i <= DataGridMaterials.Columns.Count - 1; i++)
            {
                //store autosized widths
                int colw = DataGridMaterials.Columns[i].Width;

                //remove autosizing
                DataGridMaterials.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //set width to calculated by autosize
                DataGridMaterials.Columns[i].Width = colw;
            }
        }

        private void ChkLowLevel_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatabaseAssist.RunQuery("Update tblMaterials set QTYinStock = '100' WHERE QTYinStock!='100'");
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCheck.Text))
            {
                return;
            }
            else
            {
                listSKU.Items.Clear();
                DataTable sku = DatabaseAssist.CreateDataTable("Select tblProductData.Description, tblProductContains.SKU from tblProductData inner join tblProductContains on tblProductData.SKU = tblProductContains.SKU Where tblProductContains.MaterialId = @param", Convert.ToInt32(txtCheck.Text), 1);
                //Select tblProductContains.SKU tblProductData.Description from tblProductContains Where MaterialId = @param"
                for (int i = 0; i < sku.Rows.Count; i++)
                {
                    listSKU.Items.Add(("SKU : " + sku.Rows[i][1]).ToString() + " - " + (sku.Rows[i][0]).ToString());
                }

            }
        }

        private void BtnCreateJson_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DataGridMaterials.Rows.Count - 1; i++)
            {

                new JSONMaterials(Convert.ToInt32(DataGridMaterials.Rows[i].Cells[0].Value.ToString()),
                                  DataGridMaterials.Rows[i].Cells[1].Value.ToString(),
                                  DataGridMaterials.Rows[i].Cells[2].Value.ToString(),
                                  DataGridMaterials.Rows[i].Cells[3].Value.ToString(),
                                  Convert.ToInt32(DataGridMaterials.Rows[i].Cells[4].Value.ToString()),
                                  Convert.ToInt32(DataGridMaterials.Rows[i].Cells[5].Value.ToString()),
                                  Convert.ToInt32(DataGridMaterials.Rows[i].Cells[7].Value.ToString()));
            }

            string output = JsonConvert.SerializeObject(JSONMaterials.GetAllLowLevelStock());
            System.IO.File.WriteAllText("Low-Stock.json", output);
        }
    }
}
