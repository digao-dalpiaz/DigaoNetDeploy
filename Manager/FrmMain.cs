namespace Manager
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ConfigLoader.Load();
        }

        private void BtnServers_Click(object sender, EventArgs e)
        {
            var f = new FrmServers();
            f.ShowDialog();
        }

        private void BtnPipelines_Click(object sender, EventArgs e)
        {
            var f = new FrmPipelines();
            f.ShowDialog();
        }

        
    }
}
