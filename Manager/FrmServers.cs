namespace Manager
{
    public partial class FrmServers : Form
    {
        public FrmServers()
        {
            InitializeComponent();
        }

        private void FrmServers_Load(object sender, EventArgs e)
        {
            FillList();
        }

        private void FillList()
        {
            foreach (var server in Vars.Config.Servers)
            {
                List.Items.Add(server);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var f = new FrmServerEdit();
            if (f.ShowDialog() == DialogResult.OK)
            {
                var server = f.Server;

                Vars.Config.Servers.Add(server);
                List.Items.Add(server);
                List.SelectedItem = server;

                ConfigLoader.Save();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            var server = List.SelectedItem as Server;
            if (server == null) return;

            var f = new FrmServerEdit();
            f.Server = server;
            if (f.ShowDialog() == DialogResult.OK)
            {
                List.Invalidate();

                ConfigLoader.Save();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var server = List.SelectedItem as Server;
            if (server == null) return;

            if (MessageBox.Show($"Delete server '{server.Name}'", "Delete server", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Vars.Config.Servers.Remove(server);
                List.Items.Remove(server);

                ConfigLoader.Save();
            }
        }

    }
}
