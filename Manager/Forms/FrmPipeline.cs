﻿using Manager.Forms;
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

            BuildServers();
        }

        private void BuildServers()
        {
            foreach (var server in Vars.Config.Servers)
            {
                EdServer.Items.Add(server);
            }
        }

        private void FrmPipeline_Load(object sender, EventArgs e)
        {
            if (ReturningObj != null)
            {
                Text = "Edit Pipeline";

                EdName.Text = ReturningObj.Name;
                ReturningObj.Steps.ForEach(x => Steps.Items.Add(x));

                var server = Vars.Config.Servers.Find(x => x.Id == ReturningObj.ServerId);
                if (server != null) EdServer.SelectedItem = server;
            }

            UpdStepsButtons();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (!Messages.ValidateField(EdName, "Name")) return;

            var server = EdServer.SelectedItem as Server;
            if (server == null)
            {
                Messages.Error("Select a server");
                EdServer.Focus();
                return;
            }

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
            ReturningObj.ServerId = server.Id;
            ReturningObj.Steps = Steps.Items.Cast<Step>().ToList();

            DialogResult = DialogResult.OK;
        }

        private void UpdStepsButtons()
        {
            var index = Steps.SelectedIndex;
            bool sel = index != -1;

            BtnEdit.Enabled = sel;
            BtnRemove.Enabled = sel;

            BtnUp.Enabled = sel && index > 0;
            BtnDown.Enabled = sel && index < Steps.Items.Count-1;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            var f = new FrmStep();
            if (f.ShowDialog() == DialogResult.OK)
            {
                Steps.Items.Add(f.Step);
                Steps.SelectedItem = f.Step;

                _modified = true;
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            var step = Steps.SelectedItem as Step;

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
            var newIndex = index + flag;

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

            DrawItemEx.Draw(e, 
                step.Enabled ? Properties.Resources.step : Properties.Resources.step_disabled, 
                step.Name, 
                step.Enabled ? Color.Black : Color.Gray, 
                Color.FromArgb(242, 242, 99));
        }

        private void Steps_DoubleClick(object sender, EventArgs e)
        {
            BtnEdit.PerformClick();
        }

        private void FrmPipeline_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_modified && DialogResult != DialogResult.OK)
            {
                if (MessageBox.Show("Steps have been modified. Discard the changes?", "Discard Changes",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void Steps_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdStepsButtons();
        }

    }
}
