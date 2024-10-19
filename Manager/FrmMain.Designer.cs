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
            ToolBar.Size = new Size(700, 39);
            ToolBar.TabIndex = 0;
            ToolBar.Text = "toolStrip1";
            // 
            // BtnServers
            // 
            BtnServers.Image = Properties.Resources.server;
            BtnServers.ImageTransparentColor = Color.Magenta;
            BtnServers.Name = "BtnServers";
            BtnServers.Size = new Size(80, 36);
            BtnServers.Text = "Servers";
            BtnServers.Click += BtnServers_Click;
            // 
            // BtnPipelines
            // 
            BtnPipelines.Image = Properties.Resources.pipeline;
            BtnPipelines.ImageTransparentColor = Color.Magenta;
            BtnPipelines.Name = "BtnPipelines";
            BtnPipelines.Size = new Size(90, 36);
            BtnPipelines.Text = "Pipelines";
            BtnPipelines.Click += BtnPipelines_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 473);
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
    }
}
