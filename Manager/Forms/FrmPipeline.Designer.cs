namespace Manager
{
    partial class FrmPipeline
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
            BtnCancel = new Button();
            BtnOK = new Button();
            EdName = new TextBox();
            label1 = new Label();
            Steps = new ListBox();
            label2 = new Label();
            BtnNew = new Button();
            BtnEdit = new Button();
            BtnRemove = new Button();
            BtnUp = new Button();
            BtnDown = new Button();
            SuspendLayout();
            // 
            // BtnCancel
            // 
            BtnCancel.DialogResult = DialogResult.Cancel;
            BtnCancel.Location = new Point(320, 408);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(104, 32);
            BtnCancel.TabIndex = 8;
            BtnCancel.Text = "Cancel";
            BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnOK
            // 
            BtnOK.Location = new Point(216, 408);
            BtnOK.Name = "BtnOK";
            BtnOK.Size = new Size(96, 32);
            BtnOK.TabIndex = 7;
            BtnOK.Text = "OK";
            BtnOK.UseVisualStyleBackColor = true;
            BtnOK.Click += BtnOK_Click;
            // 
            // EdName
            // 
            EdName.Location = new Point(16, 32);
            EdName.Name = "EdName";
            EdName.Size = new Size(600, 23);
            EdName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 14);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 10;
            label1.Text = "Name";
            // 
            // Steps
            // 
            Steps.DrawMode = DrawMode.OwnerDrawFixed;
            Steps.FormattingEnabled = true;
            Steps.IntegralHeight = false;
            Steps.ItemHeight = 48;
            Steps.Location = new Point(16, 96);
            Steps.Name = "Steps";
            Steps.Size = new Size(464, 296);
            Steps.TabIndex = 1;
            Steps.DrawItem += Steps_DrawItem;
            Steps.DoubleClick += Steps_DoubleClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 78);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 14;
            label2.Text = "Steps";
            // 
            // BtnNew
            // 
            BtnNew.Location = new Point(488, 96);
            BtnNew.Name = "BtnNew";
            BtnNew.Size = new Size(128, 32);
            BtnNew.TabIndex = 2;
            BtnNew.Text = "New";
            BtnNew.UseVisualStyleBackColor = true;
            BtnNew.Click += BtnNew_Click;
            // 
            // BtnEdit
            // 
            BtnEdit.Location = new Point(488, 136);
            BtnEdit.Name = "BtnEdit";
            BtnEdit.Size = new Size(128, 32);
            BtnEdit.TabIndex = 3;
            BtnEdit.Text = "Edit";
            BtnEdit.UseVisualStyleBackColor = true;
            BtnEdit.Click += BtnEdit_Click;
            // 
            // BtnRemove
            // 
            BtnRemove.Location = new Point(488, 176);
            BtnRemove.Name = "BtnRemove";
            BtnRemove.Size = new Size(128, 32);
            BtnRemove.TabIndex = 4;
            BtnRemove.Text = "Remove";
            BtnRemove.UseVisualStyleBackColor = true;
            BtnRemove.Click += BtnRemove_Click;
            // 
            // BtnUp
            // 
            BtnUp.Location = new Point(488, 240);
            BtnUp.Name = "BtnUp";
            BtnUp.Size = new Size(128, 32);
            BtnUp.TabIndex = 5;
            BtnUp.Text = "Move Up";
            BtnUp.UseVisualStyleBackColor = true;
            BtnUp.Click += BtnUp_Click;
            // 
            // BtnDown
            // 
            BtnDown.Location = new Point(488, 280);
            BtnDown.Name = "BtnDown";
            BtnDown.Size = new Size(128, 32);
            BtnDown.TabIndex = 6;
            BtnDown.Text = "Move Down";
            BtnDown.UseVisualStyleBackColor = true;
            BtnDown.Click += BtnDown_Click;
            // 
            // FrmPipeline
            // 
            AcceptButton = BtnOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = BtnCancel;
            ClientSize = new Size(633, 450);
            Controls.Add(BtnDown);
            Controls.Add(BtnUp);
            Controls.Add(BtnRemove);
            Controls.Add(BtnEdit);
            Controls.Add(BtnNew);
            Controls.Add(label2);
            Controls.Add(Steps);
            Controls.Add(BtnCancel);
            Controls.Add(BtnOK);
            Controls.Add(EdName);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmPipeline";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "New Pipeline";
            Load += FrmPipeline_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnCancel;
        private Button BtnOK;
        private TextBox EdName;
        private Label label1;
        private ListBox Steps;
        private Label label2;
        private Button BtnNew;
        private Button BtnEdit;
        private Button BtnRemove;
        private Button BtnUp;
        private Button BtnDown;
    }
}