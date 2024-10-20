using System.Reflection;

namespace Manager
{
    public partial class FrmMain : Form
    {

        private UCServers _ucServers;

        public FrmMain()
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);

            ToolStripRenderer.ConfigToolStrip(ToolBar);
            

            _ucServers = new();
            _ucServers.Visible = false;
            _ucServers.Parent = BoxUC;
            _ucServers.Dock = DockStyle.Fill;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ConfigLoader.Load();
        }

        private void BtnServers_Click(object sender, EventArgs e)
        {
            _ucServers.Visible = true;
        }

        private void BtnPipelines_Click(object sender, EventArgs e)
        {

        }

        
    }
}
