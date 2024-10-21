using Manager.Definitions;
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

            BuildOperations();
        }

        private void BuildOperations()
        {
            foreach (var op in OperationDefList.Operations)
            {
                EdOperation.Items.Add(op);
            }
        }

        private void FrmStep_Load(object sender, EventArgs e)
        {
            if (Step != null)
            {
                this.Text = "Edit Step";

                EdName.Text = Step.Name;
                EdArgs.Text = Step.Arguments;

                var op = OperationDefList.Operations.Find(x => x.Ident == Step.Operation);
                if (op != null) EdOperation.SelectedItem = op;
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (!Messages.ValidateField(EdName, "Name")) return;

            var operation = EdOperation.SelectedItem as OperationDef;
            if (operation == null)
            {
                Messages.Error("Select an operation");
                EdOperation.Focus();
                return;
            }

            //

            if (Step == null)
            {
                Step = new();
            }

            Step.Name = EdName.Text;
            Step.Operation = operation.Ident;
            Step.Arguments = EdArgs.Text;

            DialogResult = DialogResult.OK;
        }

        private void EdOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            var op = EdOperation.SelectedItem as OperationDef;

            OpArgsList.Items.Clear();
            foreach (var arg in op.Arguments)
            {
                OpArgsList.Items.Add(arg);
            }
        }

        private void OpArgsList_DoubleClick(object sender, EventArgs e)
        {
            var arg = OpArgsList.SelectedItem as OperationArgument;
            if (arg == null) return;

            EdArgs.SelectedText = arg.Ident + "=";
        }

    }
}
