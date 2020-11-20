using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LexLetsManagement
{
    public partial class FrmInvoices : Form
    {
        public FrmInvoices()
        {
            InitializeComponent();
        }

        private void FrmInvoices_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            dataGridView3.DataSource = null;
            dataGridView4.DataSource = null;

            dataGridView1.Update();
            dataGridView2.Update();
            dataGridView3.Update();
            dataGridView4.Update();

            dataGridView1.Refresh();
            dataGridView2.Refresh();
            dataGridView3.Refresh();
            dataGridView4.Refresh();

            SqlCommand cmd, cmd2, cmd3, cmd4;
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlDataAdapter adapter2 = new SqlDataAdapter();
            SqlDataAdapter adapter3 = new SqlDataAdapter();
            SqlDataAdapter adapter4 = new SqlDataAdapter();

            if (DatabaseAssist.ConnectToDatabase() == true)
            {

                cmd = new SqlCommand("SELECT * FROM tblInvoiceData", DatabaseAssist.ConnectToLexlets);
                cmd2 = new SqlCommand("SELECT * FROM tblInvoiceProducts", DatabaseAssist.ConnectToLexlets);
                cmd3 = new SqlCommand("SELECT * FROM tblRefundedInvoiceData", DatabaseAssist.ConnectToLexlets);
                cmd4 = new SqlCommand("SELECT * FROM tblRefundedInvoiceProducts", DatabaseAssist.ConnectToLexlets);

                adapter.SelectCommand = cmd;
                adapter2.SelectCommand = cmd2;
                adapter3.SelectCommand = cmd3;
                adapter4.SelectCommand = cmd4;

                DataSet ds = new DataSet();
                DataSet ds2 = new DataSet();
                DataSet ds3 = new DataSet();
                DataSet ds4 = new DataSet();

                adapter.Fill(ds, "tbl1");
                adapter2.Fill(ds2, "tbl2");
                adapter3.Fill(ds3, "tbl3");
                adapter4.Fill(ds4, "tbl4");

                dataGridView1.DataSource = ds;
                dataGridView2.DataSource = ds2;
                dataGridView3.DataSource = ds3;
                dataGridView4.DataSource = ds4;

                dataGridView1.DataMember = "tbl1";
                dataGridView2.DataMember = "tbl2";
                dataGridView3.DataMember = "tbl3";
                dataGridView4.DataMember = "tbl4";
                DatabaseAssist.ConnectToLexlets.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }


    }
}
