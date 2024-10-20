using Manager.Storage;
using Manager.Utility;

namespace Manager
{
    public partial class FrmPipeline : Form
    {

        public Pipeline ReturningObj { get; set; }

        public FrmPipeline()
        {
            InitializeComponent();
        }

        private void FrmPipeline_Load(object sender, EventArgs e)
        {
            if (ReturningObj != null)
            {
                Text = "Edit Pipeline";

                EdName.Text = ReturningObj.Name;
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (!Messages.ValidateField(EdName, "Name")) return;

            if (Steps.Items.Count == 0)
            {
                Messages.Error("There are no steps in the pipeline");
                return;
            }

            //

            if (ReturningObj == null)
            {
                ReturningObj = new();
            }

            ReturningObj.Name = EdName.Text;
            //ReturningObj.Steps....

            DialogResult = DialogResult.OK;
        }
    }
}
