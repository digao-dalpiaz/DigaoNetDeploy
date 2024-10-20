using Manager.Forms;
using Manager.Storage;
using Manager.Theme;
using Manager.Utility;

namespace Manager
{
    public partial class FrmPipeline : Form
    {

        public Pipeline ReturningObj { get; set; }

        private bool _modified;

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
                ReturningObj.Steps.ForEach(x => Steps.Items.Add(x));
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
            ReturningObj.Steps = Steps.Items.Cast<Step>().ToList();

            DialogResult = DialogResult.OK;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            var f = new FrmStep();
            if (f.ShowDialog() == DialogResult.OK)
            {
                Steps.Items.Add(f.Step);

                _modified = true;
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            var step = Steps.SelectedItem as Step;
            if (step == null) return;

            var f = new FrmStep();
            f.Step = step;
            if (f.ShowDialog() == DialogResult.OK)
            {
                Steps.Invalidate();

                _modified = true;
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            var step = Steps.SelectedItem as Step;
            if (step == null) return;

            if (MessageBox.Show($"Delete Step '{step.Name}'?", "Delete Step",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Steps.Items.Remove(step);

                _modified = true;
            }
        }

        private void MoveStep(int flag)
        {
            var index = Steps.SelectedIndex;
            if (index == -1) return;

            var newIndex = index + flag;
            if (newIndex < 0 || newIndex > Steps.Items.Count-1) return;

            var step = Steps.Items[index];

            Steps.Items.RemoveAt(index);
            Steps.Items.Insert(newIndex, step);
            Steps.SelectedIndex = newIndex;

            _modified = true;
        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            MoveStep(-1);
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            MoveStep(+1);
        }

        private void Steps_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) return;
            var step = Steps.Items[e.Index] as Step;

            DrawItemEx.Draw(e, Properties.Resources.step, step.Name, Color.Black, Color.FromArgb(242, 242, 99));
        }

        private void Steps_DoubleClick(object sender, EventArgs e)
        {
            BtnEdit.PerformClick();
        }

        private void FrmPipeline_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_modified)
            {
                if (MessageBox.Show("Discard the changes?", "Discard Changes", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
