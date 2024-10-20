using Manager.Storage;
using Manager.Theme;
using Manager.Utility;
using Renci.SshNet;
using Renci.SshNet.Common;

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

            _listEngine = new(Vars.Config.Servers, List, "Server",
                BtnEdit, BtnDelete, BtnUp, BtnDown);
        }

        private void UCServers_Load(object sender, EventArgs e)
        {
            _listEngine.Init();
            UpdConnectionButtons();
        }

        private void List_SelectedIndexChanged(object sender, EventArgs e)
        {
            _listEngine.UpdateButtons();
            UpdConnectionButtons();
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

        private void UpdConnectionButtons()
        {
            Invoke(() =>
            {
                var server = List.SelectedItem as Server;

                BtnConnect.Enabled = server?.Status == ServerStatus.DISCONNECTED;
                BtnDisconnect.Enabled = server?.Status == ServerStatus.CONNECTED;
            });
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            var server = List.SelectedItem as Server;

            server.Status = ServerStatus.CONNECTING;
            UpdConnectionButtons();

            server.Tunnel = new SshClient(server.Host, server.Port, server.User, server.Password);
            server.Tunnel.ErrorOccurred += Tunnel_ErrorOccurred;
            server.Tunnel.ServerIdentificationReceived += Tunnel_ServerIdentificationReceived;

            LogServer(server, "Connecting...");

            Task.Run(() =>
            {
                try
                {
                    server.Tunnel.Connect();
                    server.Status = ServerStatus.CONNECTED;

                    LogServer(server, "Connected successfully!", Color.Lime);
                }
                catch (Exception ex)
                {
                    server.Status = ServerStatus.DISCONNECTED;
                    LogServer(server, "ERROR ON CONNECTING: " + ex.Message, Color.Crimson);
                }

                UpdConnectionButtons();
            });
        }

        private static Server GetServerFromTunnel(SshClient tunnel)
        {
            return Vars.Config.Servers.Find(x => x.Tunnel == tunnel);
        }

        private static void LogServer(Server server, string message, Color? color = null)
        {
            LogService.Log($"{server.Name} > {message}", color);
        }

        private void Tunnel_ServerIdentificationReceived(object sender, SshIdentificationEventArgs e)
        {
            var server = GetServerFromTunnel((SshClient)sender);

            LogServer(server, $"Server identification: {e.SshIdentification}");
        }

        private void Tunnel_ErrorOccurred(object sender, ExceptionEventArgs e)
        {
            var server = GetServerFromTunnel((SshClient)sender);

            LogServer(server, $"ERROR: {e.Exception.Message}", Color.Crimson);
            SetDisconnected(server);
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            var server = List.SelectedItem as Server;

            LogServer(server, "Disconnecting...");
            server.Tunnel.Disconnect();

            SetDisconnected(server);
        }

        private void SetDisconnected(Server server)
        {
            LogServer(server, "Disconnected.");
            server.Status = ServerStatus.DISCONNECTED;
            UpdConnectionButtons();
        }
    }
}
