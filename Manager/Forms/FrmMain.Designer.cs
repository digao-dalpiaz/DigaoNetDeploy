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
            BoxTop = new Panel();
            BoxUC = new Panel();
            ToolBar = new ToolStrip();
            BtnServers = new ToolStripButton();
            BtnPipelines = new ToolStripButton();
            SplitterBar = new Splitter();
            EdLog = new RichTextBox();
            BoxTop.SuspendLayout();
            ToolBar.SuspendLayout();
            SuspendLayout();
            // 
            // BoxTop
            // 
            BoxTop.Controls.Add(BoxUC);
            BoxTop.Controls.Add(ToolBar);
            BoxTop.Dock = DockStyle.Fill;
            BoxTop.Location = new Point(0, 0);
            BoxTop.Name = "BoxTop";
            BoxTop.Size = new Size(1036, 336);
            BoxTop.TabIndex = 3;
            // 
            // BoxUC
            // 
            BoxUC.Dock = DockStyle.Fill;
            BoxUC.Location = new Point(107, 0);
            BoxUC.Name = "BoxUC";
            BoxUC.Size = new Size(929, 336);
            BoxUC.TabIndex = 2;
            // 
            // ToolBar
            // 
            ToolBar.Dock = DockStyle.Left;
            ToolBar.ImageScalingSize = new Size(48, 48);
            ToolBar.Items.AddRange(new ToolStripItem[] { BtnServers, BtnPipelines });
            ToolBar.Location = new Point(0, 0);
            ToolBar.Name = "ToolBar";
            ToolBar.Size = new Size(107, 336);
            ToolBar.TabIndex = 1;
            // 
            // BtnServers
            // 
            BtnServers.Image = Properties.Resources.server_orange;
            BtnServers.ImageTransparentColor = Color.Magenta;
            BtnServers.Name = "BtnServers";
            BtnServers.Size = new Size(104, 52);
            BtnServers.Text = "Servers";
            BtnServers.Click += BtnServers_Click;
            // 
            // BtnPipelines
            // 
            BtnPipelines.Image = Properties.Resources.pipeline_orange;
            BtnPipelines.ImageTransparentColor = Color.Magenta;
            BtnPipelines.Name = "BtnPipelines";
            BtnPipelines.Size = new Size(104, 52);
            BtnPipelines.Text = "Pipelines";
            BtnPipelines.Click += BtnPipelines_Click;
            // 
            // SplitterBar
            // 
            SplitterBar.Dock = DockStyle.Bottom;
            SplitterBar.Location = new Point(0, 336);
            SplitterBar.Name = "SplitterBar";
            SplitterBar.Size = new Size(1036, 5);
            SplitterBar.TabIndex = 4;
            SplitterBar.TabStop = false;
            // 
            // EdLog
            // 
            EdLog.BackColor = Color.FromArgb(45, 40, 65);
            EdLog.BorderStyle = BorderStyle.None;
            EdLog.Dock = DockStyle.Bottom;
            EdLog.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EdLog.Location = new Point(0, 341);
            EdLog.Name = "EdLog";
            EdLog.ReadOnly = true;
            EdLog.Size = new Size(1036, 324);
            EdLog.TabIndex = 5;
            EdLog.Text = "";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1036, 665);
            Controls.Add(BoxTop);
            Controls.Add(SplitterBar);
            Controls.Add(EdLog);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Digao Net Deploy";
            FormClosing += FrmMain_FormClosing;
            Load += FrmMain_Load;
            BoxTop.ResumeLayout(false);
            BoxTop.PerformLayout();
            ToolBar.ResumeLayout(false);
            ToolBar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel BoxTop;
        private Panel BoxUC;
        private ToolStrip ToolBar;
        private ToolStripButton BtnServers;
        private ToolStripButton BtnPipelines;
        private Splitter SplitterBar;
        private RichTextBox EdLog;
    }
}
