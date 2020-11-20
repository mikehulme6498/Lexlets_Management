using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace LexLetsManagement
{
    public partial class Frmmainmenu : Form
    {
        Color btnHover = Color.LightSkyBlue;
        Color btnNormal = Color.SteelBlue;

        public Frmmainmenu()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void Butaddmaterial_Click(object sender, EventArgs e)
        {
            Frmaddmaterial formaddmaterial = new Frmaddmaterial();
            formaddmaterial.ShowDialog();

        } 
        private void Btnslide_Click(object sender, EventArgs e)
        {
            if (MenuLeft.Width == 204)
            {
                MenuLeft.Width = 70;

                picLogo.Image = Properties.Resources.Logo_Small;
                BtnSales.Text = "";
                BtnStock.Text = "";
                BtnProducts.Text = "";
                BtnReports.Text = "";
                BtnAccounts.Text = "";
                BtnDesigner.Text = "";
            }

            else
            {
                MenuLeft.Width = 204;
                picLogo.Image = Properties.Resources.Logo_Proper_one;
                BtnSales.Text = "Sales";
                BtnStock.Text = "Stock";
                BtnProducts.Text = "Products";
                BtnReports.Text = "Reports";
                BtnAccounts.Text = "Accounts";
                BtnDesigner.Text = "Designer";
            }
        }

        private void AddCustomers_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Add New Customer";
            Forminpanel(new FrmAddNewCustomer());
        }

        private void ViewCustomers_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "View Customer Details";
            Forminpanel(new FrmCustomerDetails());
        }

        private void EditCustomer_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Page Not Implemented Yet");
        }

        private void Frmmainmenu_Load(object sender, EventArgs e)
        {
            DatabaseAssist.ConnectToLexlets.StateChange += ConnectToLexlets_StateChange;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            menuTop.Size = new Size(1000, 50);

            lbldatabase.Text = "Using " + DatabaseAssist.GetDatabaseName() + " Database";
            lblUser.Text = "User : " + User.Username.ToString();
            Forminpanel(new FrmOverview());
        }

        private void ConnectToLexlets_StateChange(object sender, StateChangeEventArgs e)
        {
            lblConnection.Invoke((MethodInvoker)delegate ()
            {
                lblConnection.Text = "Connection: " + DatabaseAssist.ConnectToLexlets.State.ToString();
            });
        }
        private void MenuTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void PicMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            picMaximize.Visible = false;
            picRestore.Visible = true;

        }
        private void PicClose_Click(object sender, EventArgs e)
        {
            this.Close();
            frmlogin login = new frmlogin();
            login.Show();
            //Application.Exit();
        }
        private void PicRestore_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            picMaximize.Visible = true;
            picRestore.Visible = false;
        }
        private void PicMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void Forminpanel(object frmload)
        {
            if (this.pnlcenter.Controls.Count > 0)
                this.pnlcenter.Controls.RemoveAt(0);
            Form fh = frmload as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.pnlcenter.Controls.Add(fh);
            this.pnlcenter.Tag = fh;
            fh.FormClosed += new FormClosedEventHandler(fh_FormClosed); //Creates close event to show overview again when form is closed
            fh.Show();

        }

        private void fh_FormClosed(object sender, FormClosedEventArgs e)
        {
            lblTitle.Text = "Overview";
            Forminpanel(new FrmOverview());
        }

        private void BtnStock_Click(object sender, EventArgs e)
        {
            MenuStripStock.Show(BtnStock, BtnStock.Width, 0);
            ChangeSelectedButtonColour(BtnStock);
        }

        private void AddNewItemOfStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Add New Material";
            Forminpanel(new Frmaddmaterial());

        }

        private void ViewAllStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "View All Stock";
            Forminpanel(new FrmViewAllMaterials());
        }

        private void EditDeleteItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Edit / Delete Material";
            Forminpanel(new FrmEditDeleteMaterial());
        }

        private void BtnProducts_Click(object sender, EventArgs e)
        {
            MenuStripProducts.Show(BtnProducts, BtnProducts.Width, 0);
            ChangeSelectedButtonColour(BtnProducts);
        }

        private void AddNewProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Add New Product";
            Forminpanel(new FrmAddNewProduct());
        }
        private void ViewAllProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "View All Products";
            Forminpanel(new FrmViewAllProducts());

        }
        private void EditDeleteProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Edit / Delete Product";
            Forminpanel(new FrmEditDeleteProduct());

        }
        private void BtnSales_Click(object sender, EventArgs e)
        {
            MenuStripSales.Show(BtnSales, BtnSales.Width, 0);
            ChangeSelectedButtonColour(BtnSales);
        }
        private void Frmmainmenu_SizeChanged(object sender, EventArgs e)
        {
            menuTop.Width = this.Width;
            lblTitle.Location = new Point(this.Width / 3, lblTitle.Location.Y);

        }
        private void BtnAccounts_Click(object sender, EventArgs e)
        {
            MenuStripAccounts.Show(BtnAccounts, BtnAccounts.Width, 0);
            ChangeSelectedButtonColour(BtnAccounts);
        }

        private void BtnReports_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Invoices";
            Forminpanel(new FrmInvoices());
            ChangeSelectedButtonColour(BtnReports);
        }


        private void toolStripMenuAddCollection_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Add New Collection";
            Forminpanel(new FrmAddNewCollection());
        }

        private void BtnCustomers_Click(object sender, EventArgs e)
        {
            MenuStripCustomers.Show(BtnCustomers, BtnCustomers.Width, 0);
            ChangeSelectedButtonColour(BtnCustomers);
        }
        
        private void Refund_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Refund";
            Forminpanel(new FrmRefund());
        }

        private void NewSale_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "New Sale";
            Forminpanel(new FrmNewSale());
        }

        private void AddExpense_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Add Expense";
            Forminpanel(new FrmOutgoing());
        }

        private void MonthlyAccounts_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Accounts";
            Forminpanel(new FrmAccounts());
        }

        private void ChangeSelectedButtonColour(Button but)
        {
            foreach (Button button in MenuLeft.Controls.OfType<Button>())
            {
                if (button.Name == but.Name)
                {
                    button.BackColor = Color.LightSkyBlue;
                }
                else
                {
                    button.BackColor = Color.SteelBlue;
                }
            }
        }

        private void btnOverview_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Overview";
            ChangeSelectedButtonColour(btnOverview);
            Forminpanel(new FrmOverview());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User.AddToUserLog("Log Out", User.Username + " Logged Out");
            User.Username = "";
            User.AccessLevel = 0;
            this.Close();
            frmlogin login = new frmlogin();
            login.Show();
        }

        private void viewYearlyFiguresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Yearly Figures";
            ChangeSelectedButtonColour(BtnAccounts);
            Forminpanel(new FrmYearlyOverview());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Settings";
            ChangeSelectedButtonColour(btnSettings);
            Forminpanel(new FrmSettings());
        }

        private void addMaterialToStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Adjutst Material Stock";
            ChangeSelectedButtonColour(BtnStock);
            Forminpanel(new FrmAddMaterialToStock());
        }

        private void BtnDesigner_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Designer";
            ChangeSelectedButtonColour(BtnDesigner);
            Forminpanel(new FrmDesigner());
        }

        private void lbldatabase_Click(object sender, EventArgs e)
        {
            DatabaseAssist.BackupDatabase();
        }
    }
}
