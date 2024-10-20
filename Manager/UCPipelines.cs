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
    }
}
