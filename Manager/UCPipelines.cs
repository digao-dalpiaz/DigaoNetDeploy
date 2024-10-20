using Manager.Storage;
using Manager.Theme;

namespace Manager
{
    public partial class UCPipelines : UserControl
    {
        public UCPipelines()
        {
            InitializeComponent();

            MyToolStripRenderer.ConfigToolStrip(ToolBar);

            List.BackColor = Vars.BACKGROUND;
        }

        private void UCPipelines_Load(object sender, EventArgs e)
        {
            FillList();
        }

        private void FillList()
        {
            foreach (var pipeline in Vars.Config.Pipelines)
            {
                List.Items.Add(pipeline);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var f = new FrmPipeline();
            if (f.ShowDialog() == DialogResult.OK)
            {
                var pipeline = f.Pipeline;

                Vars.Config.Pipelines.Add(pipeline);
                List.Items.Add(pipeline);
                List.SelectedItem = pipeline;

                ConfigLoader.Save();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            var pipeline = List.SelectedItem as Pipeline;
            if (pipeline == null) return;

            var f = new FrmPipeline();
            f.Pipeline = pipeline;
            if (f.ShowDialog() == DialogResult.OK)
            {
                List.Invalidate();

                ConfigLoader.Save();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var pipeline = List.SelectedItem as Pipeline;
            if (pipeline == null) return;

            if (MessageBox.Show($"Delete pipeline '{pipeline.Name}'", "Delete pipeline",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Vars.Config.Pipelines.Remove(pipeline);
                List.Items.Remove(pipeline);

                ConfigLoader.Save();
            }
        }

        private void List_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) return;
            var pipeline = List.Items[e.Index] as Pipeline;

            DrawItemEx.Draw(e, Properties.Resources.pipeline_blue, pipeline.Name);
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {
            BtnEdit.PerformClick();
        }
    }
}
