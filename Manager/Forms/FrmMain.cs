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

    }
}
