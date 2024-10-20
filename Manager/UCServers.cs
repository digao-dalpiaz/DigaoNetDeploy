using Manager.Storage;
using Manager.Theme;

namespace Manager
{
    public partial class UCServers : UserControl
    {

        private readonly ListEngine<Server, FrmServer> _listEngine;

        public UCServers()
        {
            InitializeComponent();

            MyToolStripRenderer.ConfigToolStrip(ToolBar);
            List.BackColor = Vars.BACKGROUND;

            _listEngine = new(Vars.Config.Servers, List, "Server");
        }

        private void UCServers_Load(object sender, EventArgs e)
        {
            _listEngine.FillList();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            _listEngine.Add();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            _listEngine.Edit();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            _listEngine.Delete();
        }

        private void List_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) return;
            var server = List.Items[e.Index] as Server;

            DrawItemEx.Draw(e, Properties.Resources.server_blue, server.Name);
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {
            BtnEdit.PerformClick();
        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            _listEngine.MoveUp();
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            _listEngine.MoveDown();
        }
    }
}
