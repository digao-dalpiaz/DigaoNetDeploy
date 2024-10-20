namespace Manager
{
    partial class UCServers
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

        #region Component Designer generated code

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
            List.BorderStyle = BorderStyle.None;
            List.Dock = DockStyle.Fill;
            List.DrawMode = DrawMode.OwnerDrawFixed;
            List.FormattingEnabled = true;
            List.IntegralHeight = false;
            List.ItemHeight = 48;
            List.Location = new Point(0, 31);
            List.Name = "List";
            List.Size = new Size(541, 420);
            List.TabIndex = 2;
            List.DrawItem += List_DrawItem;
            List.DoubleClick += List_DoubleClick;
            // 
            // ToolBar
            // 
            ToolBar.ImageScalingSize = new Size(24, 24);
            ToolBar.Items.AddRange(new ToolStripItem[] { BtnAdd, BtnEdit, BtnDelete });
            ToolBar.Location = new Point(0, 0);
            ToolBar.Name = "ToolBar";
            ToolBar.Size = new Size(541, 31);
            ToolBar.TabIndex = 3;
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
            // UCServers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(List);
            Controls.Add(ToolBar);
            Name = "UCServers";
            Size = new Size(541, 451);
            Load += UCServers_Load;
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
