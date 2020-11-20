using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LexLetsManagement
{
    public partial class FrmPleaseWait : Form
    {
        public Action Worker { get; set; }

        public FrmPleaseWait(Action worker)
        {
            InitializeComponent();
            if (worker == null)
            {
                throw new ArgumentNullException();
            }
            Worker = worker;

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }

    }
}
