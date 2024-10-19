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
            List = new ListBox();
            ToolBar = new ToolStrip();
            BtnAdd = new ToolStripButton();
            BtnEdit = new ToolStripButton();
            BtnDelete = new ToolStripButton();
            ToolBar.SuspendLayout();
            SuspendLayout();
            // 
            // List
            // 
            List.Dock = DockStyle.Fill;
            List.FormattingEnabled = true;
            List.IntegralHeight = false;
            List.ItemHeight = 15;
            List.Location = new Point(0, 31);
            List.Name = "List";
            List.Size = new Size(516, 406);
            List.TabIndex = 0;
            // 
            // ToolBar
            // 
            ToolBar.ImageScalingSize = new Size(24, 24);
            ToolBar.Items.AddRange(new ToolStripItem[] { BtnAdd, BtnEdit, BtnDelete });
            ToolBar.Location = new Point(0, 0);
            ToolBar.Name = "ToolBar";
            ToolBar.Size = new Size(516, 31);
            ToolBar.TabIndex = 1;
            ToolBar.Text = "toolStrip1";
            // 
            // BtnAdd
            // 
            BtnAdd.Image = Properties.Resources.add;
            BtnAdd.ImageTransparentColor = Color.Magenta;
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(59, 28);
            BtnAdd.Text = "New";
            BtnAdd.Click += BtnAdd_Click;
            // 
            // BtnEdit
            // 
            BtnEdit.Image = Properties.Resources.edit;
            BtnEdit.ImageTransparentColor = Color.Magenta;
            BtnEdit.Name = "BtnEdit";
            BtnEdit.Size = new Size(55, 28);
            BtnEdit.Text = "Edit";
            BtnEdit.Click += BtnEdit_Click;
            // 
            // BtnDelete
            // 
            BtnDelete.Image = Properties.Resources.delete;
            BtnDelete.ImageTransparentColor = Color.Magenta;
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(78, 28);
            BtnDelete.Text = "Remove";
            BtnDelete.Click += BtnDelete_Click;
            // 
            // FrmServers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(516, 437);
            Controls.Add(List);
            Controls.Add(ToolBar);
            Margin = new Padding(3, 2, 3, 2);
            MinimizeBox = false;
            Name = "FrmServers";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Servers";
            Load += FrmServers_Load;
            ToolBar.ResumeLayout(false);
            ToolBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox List;
        private ToolStrip ToolBar;
        private ToolStripButton BtnAdd;
        private ToolStripButton BtnEdit;
        private ToolStripButton BtnDelete;
    }
}