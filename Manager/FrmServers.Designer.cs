namespace Manager
{
    partial class FrmServers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBox1 = new ListBox();
            toolStrip1 = new ToolStrip();
            BtnAdd = new ToolStripButton();
            BtnEdit = new ToolStripButton();
            BtnDelete = new ToolStripButton();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.Dock = DockStyle.Fill;
            listBox1.FormattingEnabled = true;
            listBox1.IntegralHeight = false;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(0, 25);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(420, 313);
            listBox1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { BtnAdd, BtnEdit, BtnDelete });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(420, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // BtnAdd
            // 
            BtnAdd.Image = Properties.Resources.add;
            BtnAdd.ImageTransparentColor = Color.Magenta;
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(51, 22);
            BtnAdd.Text = "New";
            // 
            // BtnEdit
            // 
            BtnEdit.Image = Properties.Resources.edit;
            BtnEdit.ImageTransparentColor = Color.Magenta;
            BtnEdit.Name = "BtnEdit";
            BtnEdit.Size = new Size(47, 22);
            BtnEdit.Text = "Edit";
            // 
            // BtnDelete
            // 
            BtnDelete.Image = Properties.Resources.delete;
            BtnDelete.ImageTransparentColor = Color.Magenta;
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(70, 22);
            BtnDelete.Text = "Remove";
            // 
            // FrmServers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 338);
            Controls.Add(listBox1);
            Controls.Add(toolStrip1);
            Margin = new Padding(3, 2, 3, 2);
            MinimizeBox = false;
            Name = "FrmServers";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Servers";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private ToolStrip toolStrip1;
        private ToolStripButton BtnAdd;
        private ToolStripButton BtnEdit;
        private ToolStripButton BtnDelete;
    }
}