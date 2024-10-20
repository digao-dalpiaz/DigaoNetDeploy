namespace Manager
{
    partial class FrmServer
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
            label1 = new Label();
            EdName = new TextBox();
            EdHost = new TextBox();
            label2 = new Label();
            EdPort = new TextBox();
            label3 = new Label();
            BtnOK = new Button();
            BtnCancel = new Button();
            EdUser = new TextBox();
            label4 = new Label();
            EdPassword = new TextBox();
            label5 = new Label();
            label6 = new Label();
            EdKeyFile = new TextBox();
            BtnFindKeyFile = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 14);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // EdName
            // 
            EdName.Location = new Point(16, 32);
            EdName.Name = "EdName";
            EdName.Size = new Size(400, 23);
            EdName.TabIndex = 0;
            // 
            // EdHost
            // 
            EdHost.Location = new Point(16, 88);
            EdHost.Name = "EdHost";
            EdHost.Size = new Size(528, 23);
            EdHost.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 70);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 2;
            label2.Text = "Host";
            // 
            // EdPort
            // 
            EdPort.Location = new Point(552, 88);
            EdPort.Name = "EdPort";
            EdPort.Size = new Size(80, 23);
            EdPort.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(550, 70);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 4;
            label3.Text = "Port";
            // 
            // BtnOK
            // 
            BtnOK.Location = new Point(224, 296);
            BtnOK.Name = "BtnOK";
            BtnOK.Size = new Size(96, 32);
            BtnOK.TabIndex = 7;
            BtnOK.Text = "OK";
            BtnOK.UseVisualStyleBackColor = true;
            BtnOK.Click += BtnOK_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.DialogResult = DialogResult.Cancel;
            BtnCancel.Location = new Point(328, 296);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(104, 32);
            BtnCancel.TabIndex = 8;
            BtnCancel.Text = "Cancel";
            BtnCancel.UseVisualStyleBackColor = true;
            // 
            // EdUser
            // 
            EdUser.Location = new Point(16, 144);
            EdUser.Name = "EdUser";
            EdUser.Size = new Size(400, 23);
            EdUser.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 126);
            label4.Name = "label4";
            label4.Size = new Size(30, 15);
            label4.TabIndex = 8;
            label4.Text = "User";
            // 
            // EdPassword
            // 
            EdPassword.Location = new Point(16, 200);
            EdPassword.Name = "EdPassword";
            EdPassword.Size = new Size(400, 23);
            EdPassword.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 182);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 10;
            label5.Text = "Password";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 238);
            label6.Name = "label6";
            label6.Size = new Size(83, 15);
            label6.TabIndex = 12;
            label6.Text = "Private key file";
            // 
            // EdKeyFile
            // 
            EdKeyFile.Location = new Point(16, 256);
            EdKeyFile.Name = "EdKeyFile";
            EdKeyFile.Size = new Size(576, 23);
            EdKeyFile.TabIndex = 5;
            // 
            // BtnFindKeyFile
            // 
            BtnFindKeyFile.Location = new Point(592, 256);
            BtnFindKeyFile.Name = "BtnFindKeyFile";
            BtnFindKeyFile.Size = new Size(40, 24);
            BtnFindKeyFile.TabIndex = 6;
            BtnFindKeyFile.TabStop = false;
            BtnFindKeyFile.Text = "...";
            BtnFindKeyFile.UseVisualStyleBackColor = true;
            // 
            // FrmServerEdit
            // 
            AcceptButton = BtnOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = BtnCancel;
            ClientSize = new Size(649, 340);
            Controls.Add(BtnFindKeyFile);
            Controls.Add(EdKeyFile);
            Controls.Add(label6);
            Controls.Add(EdPassword);
            Controls.Add(label5);
            Controls.Add(EdUser);
            Controls.Add(label4);
            Controls.Add(BtnCancel);
            Controls.Add(BtnOK);
            Controls.Add(EdPort);
            Controls.Add(label3);
            Controls.Add(EdHost);
            Controls.Add(label2);
            Controls.Add(EdName);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmServerEdit";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "New Server";
            Load += FrmServerEdit_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox EdName;
        private TextBox EdHost;
        private Label label2;
        private TextBox EdPort;
        private Label label3;
        private Button BtnOK;
        private Button BtnCancel;
        private TextBox EdUser;
        private Label label4;
        private TextBox EdPassword;
        private Label label5;
        private Label label6;
        private TextBox EdKeyFile;
        private Button BtnFindKeyFile;
    }
}