namespace Manager
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ToolBar = new ToolStrip();
            BtnServers = new ToolStripButton();
            BtnPipelines = new ToolStripButton();
            BoxUC = new Panel();
            ToolBar.SuspendLayout();
            SuspendLayout();
            // 
            // ToolBar
            // 
            ToolBar.Dock = DockStyle.Left;
            ToolBar.ImageScalingSize = new Size(48, 48);
            ToolBar.Items.AddRange(new ToolStripItem[] { BtnServers, BtnPipelines });
            ToolBar.Location = new Point(0, 0);
            ToolBar.Name = "ToolBar";
            ToolBar.Size = new Size(107, 473);
            ToolBar.TabIndex = 0;
            // 
            // BtnServers
            // 
            BtnServers.Image = Properties.Resources.server_orange;
            BtnServers.ImageTransparentColor = Color.Magenta;
            BtnServers.Name = "BtnServers";
            BtnServers.Size = new Size(94, 52);
            BtnServers.Text = "Servers";
            BtnServers.Click += BtnServers_Click;
            // 
            // BtnPipelines
            // 
            BtnPipelines.Image = Properties.Resources.pipeline_orange;
            BtnPipelines.ImageTransparentColor = Color.Magenta;
            BtnPipelines.Name = "BtnPipelines";
            BtnPipelines.Size = new Size(94, 52);
            BtnPipelines.Text = "Pipelines";
            BtnPipelines.Click += BtnPipelines_Click;
            // 
            // BoxUC
            // 
            BoxUC.Dock = DockStyle.Fill;
            BoxUC.Location = new Point(107, 0);
            BoxUC.Name = "BoxUC";
            BoxUC.Size = new Size(593, 473);
            BoxUC.TabIndex = 1;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 473);
            Controls.Add(BoxUC);
            Controls.Add(ToolBar);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Digao Net Deploy";
            Load += FrmMain_Load;
            ToolBar.ResumeLayout(false);
            ToolBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip ToolBar;
        private ToolStripButton BtnServers;
        private ToolStripButton BtnPipelines;
        private Panel BoxUC;
    }
}
