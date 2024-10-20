using Manager.Storage;
using Manager.Utility;

namespace Manager.Forms
{
    public partial class FrmStep : Form
    {

        public Step Step { get; set; }

        public FrmStep()
        {
            InitializeComponent();
        }

        private void FrmStep_Load(object sender, EventArgs e)
        {
            if (Step != null)
            {
                this.Text = "Edit Step";

                EdName.Text = Step.Name;
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (!Messages.ValidateField(EdName, "Name")) return;

            //

            if (Step == null)
            {
                Step = new();
            }

            Step.Name = EdName.Text;

            DialogResult = DialogResult.OK;
        }

        
    }
}
