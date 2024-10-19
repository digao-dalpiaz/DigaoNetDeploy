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
            ToolBar.SuspendLayout();
            SuspendLayout();
            // 
            // ToolBar
            // 
            ToolBar.ImageScalingSize = new Size(32, 32);
            ToolBar.Items.AddRange(new ToolStripItem[] { BtnServers, BtnPipelines });
            ToolBar.Location = new Point(0, 0);
            ToolBar.Name = "ToolBar";
            ToolBar.Size = new Size(800, 39);
            ToolBar.TabIndex = 0;
            ToolBar.Text = "toolStrip1";
            // 
            // BtnServers
            // 
            BtnServers.Image = Properties.Resources.server;
            BtnServers.ImageTransparentColor = Color.Magenta;
            BtnServers.Name = "BtnServers";
            BtnServers.Size = new Size(92, 36);
            BtnServers.Text = "Servers";
            // 
            // BtnPipelines
            // 
            BtnPipelines.Image = Properties.Resources.pipeline;
            BtnPipelines.ImageTransparentColor = Color.Magenta;
            BtnPipelines.Name = "BtnPipelines";
            BtnPipelines.Size = new Size(104, 36);
            BtnPipelines.Text = "Pipelines";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ToolBar);
            Name = "FrmMain";
            Text = "Digao Net Deploy - Manager";
            ToolBar.ResumeLayout(false);
            ToolBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip ToolBar;
        private ToolStripButton BtnServers;
        private ToolStripButton BtnPipelines;
    }
}
