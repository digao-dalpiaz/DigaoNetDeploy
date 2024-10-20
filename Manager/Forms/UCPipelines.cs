using Manager.Storage;
using Manager.Theme;
using Manager.Utility;

namespace Manager
{
    public partial class UCPipelines : UserControl
    {

        private readonly ListEngine<Pipeline, FrmPipeline> _listEngine;

        public UCPipelines()
        {
            InitializeComponent();

            MyToolStripRenderer.ConfigToolStrip(ToolBar);
            List.BackColor = Vars.BACKGROUND;

            _listEngine = new(Vars.Config.Pipelines, List, "Pipeline",
                BtnEdit, BtnDelete, BtnUp, BtnDown);
        }

        private void UCPipelines_Load(object sender, EventArgs e)
        {
            _listEngine.Init();
        }

        private void List_SelectedIndexChanged(object sender, EventArgs e)
        {
            _listEngine.UpdateButtons();
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
            var pipeline = List.Items[e.Index] as Pipeline;

            DrawItemEx.Draw(e, Properties.Resources.pipeline_blue, pipeline.Name, Color.White, Vars.SELECTED);
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

        private void BtnRun_Click(object sender, EventArgs e)
        {
            if (Vars.PipelineRunning)
            {
                Messages.Error("There is already a pipeline running");
                return;
            }


        }
    }
}
