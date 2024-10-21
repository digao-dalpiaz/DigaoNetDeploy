namespace Manager.Forms
{
    partial class FrmStep
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
            EdName = new TextBox();
            label1 = new Label();
            BtnCancel = new Button();
            BtnOK = new Button();
            label2 = new Label();
            EdOperation = new ComboBox();
            OpArgsList = new ListBox();
            EdArgs = new TextBox();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // EdName
            // 
            EdName.Location = new Point(16, 32);
            EdName.Name = "EdName";
            EdName.Size = new Size(400, 23);
            EdName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 14);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 2;
            label1.Text = "Name";
            // 
            // BtnCancel
            // 
            BtnCancel.DialogResult = DialogResult.Cancel;
            BtnCancel.Location = new Point(400, 432);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(104, 32);
            BtnCancel.TabIndex = 5;
            BtnCancel.Text = "Cancel";
            BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnOK
            // 
            BtnOK.Location = new Point(296, 432);
            BtnOK.Name = "BtnOK";
            BtnOK.Size = new Size(96, 32);
            BtnOK.TabIndex = 4;
            BtnOK.Text = "OK";
            BtnOK.UseVisualStyleBackColor = true;
            BtnOK.Click += BtnOK_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 70);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 11;
            label2.Text = "Operation";
            // 
            // EdOperation
            // 
            EdOperation.DropDownStyle = ComboBoxStyle.DropDownList;
            EdOperation.FormattingEnabled = true;
            EdOperation.Location = new Point(16, 88);
            EdOperation.Name = "EdOperation";
            EdOperation.Size = new Size(400, 23);
            EdOperation.TabIndex = 1;
            EdOperation.SelectedIndexChanged += EdOperation_SelectedIndexChanged;
            // 
            // OpArgsList
            // 
            OpArgsList.FormattingEnabled = true;
            OpArgsList.IntegralHeight = false;
            OpArgsList.ItemHeight = 15;
            OpArgsList.Location = new Point(16, 144);
            OpArgsList.Name = "OpArgsList";
            OpArgsList.Size = new Size(760, 96);
            OpArgsList.TabIndex = 2;
            OpArgsList.DoubleClick += OpArgsList_DoubleClick;
            // 
            // EdArgs
            // 
            EdArgs.AcceptsReturn = true;
            EdArgs.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EdArgs.Location = new Point(16, 264);
            EdArgs.Multiline = true;
            EdArgs.Name = "EdArgs";
            EdArgs.ScrollBars = ScrollBars.Both;
            EdArgs.Size = new Size(760, 160);
            EdArgs.TabIndex = 3;
            EdArgs.WordWrap = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 126);
            label3.Name = "label3";
            label3.Size = new Size(90, 15);
            label3.TabIndex = 15;
            label3.Text = "Arguments info";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 246);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 16;
            label4.Text = "Arguments";
            // 
            // FrmStep
            // 
            AcceptButton = BtnOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = BtnCancel;
            ClientSize = new Size(793, 474);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(EdArgs);
            Controls.Add(OpArgsList);
            Controls.Add(EdOperation);
            Controls.Add(label2);
            Controls.Add(BtnCancel);
            Controls.Add(BtnOK);
            Controls.Add(EdName);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmStep";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "New Step";
            Load += FrmStep_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox EdName;
        private Label label1;
        private Button BtnCancel;
        private Button BtnOK;
        private Label label2;
        private ComboBox EdOperation;
        private ListBox OpArgsList;
        private TextBox EdArgs;
        private Label label3;
        private Label label4;
    }
}