using Manager.Storage;
using Manager.Theme;
using Manager.Utility;
using System.Reflection;

namespace Manager
{
    public partial class FrmMain : Form
    {

        private readonly List<UserControl> _ucList = [];

        public FrmMain()
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);

            LogService.LogControl = this.EdLog;

            DarkTitle.UseImmersiveDarkMode(this.Handle);

            MyToolStripRenderer.ConfigToolStrip(ToolBar);

            BackColor = Vars.BACKGROUND;
        }

        private void CreateUC<T>() where T : UserControl, new()
        {
            var uc = new T()
            {
                Visible = false,
                Parent = BoxUC,
                Dock = DockStyle.Fill
            };

            _ucList.Add(uc);
        }

        private void ShowUC<T>() where T : UserControl
        {
            foreach (var uc in _ucList)
            {
                uc.Visible = uc is T;
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ConfigLoader.Load();

            CreateUC<UCServers>();
            CreateUC<UCPipelines>();
        }

        private void BtnServers_Click(object sender, EventArgs e)
        {
            ShowUC<UCServers>();
        }

        private void BtnPipelines_Click(object sender, EventArgs e)
        {
            ShowUC<UCPipelines>();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            //verificar primeiro se existe pipeline em andamento...

            if (Vars.Config.Servers.Any(x => x.Status == ServerStatus.CONNECTING)) 
            {
                Messages.Error("There are servers currently connecting");
                return;
            }

            /*var connectedServers = Vars.Config.Servers.Where(x => x.Status == ServerStatus.CONNECTED);
            foreach (var server in connectedServers)
            {
                server.Disconnect();
            }*/

            e.Cancel = false;
        }
    }
}
