﻿namespace Manager
{
    public partial class UCServers : UserControl
    {
        public UCServers()
        {
            InitializeComponent();
        }

        private void UCServers_Load(object sender, EventArgs e)
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

        private void List_DrawItem(object sender, DrawItemEventArgs e)
        {
            var server = List.Items[e.Index] as Server;

            e.DrawBackground();
            if (e.State.HasFlag(DrawItemState.Selected))
            {
                e.Graphics.FillRectangle(Brushes.LightBlue, e.Bounds);
            }

            const int imgSize = 32;
            
            e.Graphics.DrawImage(Properties.Resources.server, e.Bounds.X + 4, e.Bounds.Y + ((e.Bounds.Height - imgSize) / 2), imgSize, imgSize);

            var textSize = e.Graphics.MeasureString("A", e.Font);
            e.Graphics.DrawString(server.Name, e.Font, Brushes.Black, e.Bounds.X + imgSize + 12, e.Bounds.Y + ((e.Bounds.Height - textSize.Height) / 2));
            e.DrawFocusRectangle();
        }
    }
}