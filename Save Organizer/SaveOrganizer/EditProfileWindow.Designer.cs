namespace SaveOrganizer
{
    partial class EditProfileWindow
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
            this.SavePathText = new System.Windows.Forms.TextBox();
            this.BrowseSavePath = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GamesSelector = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BackupPathText = new System.Windows.Forms.TextBox();
            this.BrowseBackupPath = new System.Windows.Forms.Button();
            this.ProfilesList = new System.Windows.Forms.ListBox();
            this.NewProfileButton = new System.Windows.Forms.Button();
            this.EditProfileButton = new System.Windows.Forms.Button();
            this.DeleteProfileButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SavePathBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.BackupPathBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // SavePathText
            // 
            this.SavePathText.Cursor = System.Windows.Forms.Cursors.Default;
            this.SavePathText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SavePathText.Location = new System.Drawing.Point(11, 21);
            this.SavePathText.Name = "SavePathText";
            this.SavePathText.ReadOnly = true;
            this.SavePathText.Size = new System.Drawing.Size(237, 20);
            this.SavePathText.TabIndex = 5;
            this.SavePathText.TextChanged += new System.EventHandler(this.SavePathText_TextChanged);
            // 
            // BrowseSavePath
            // 
            this.BrowseSavePath.Location = new System.Drawing.Point(255, 19);
            this.BrowseSavePath.Name = "BrowseSavePath";
            this.BrowseSavePath.Size = new System.Drawing.Size(75, 23);
            this.BrowseSavePath.TabIndex = 6;
            this.BrowseSavePath.Text = "Browse...";
            this.BrowseSavePath.UseVisualStyleBackColor = true;
            this.BrowseSavePath.Click += new System.EventHandler(this.BrowseSavePath_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SavePathText);
            this.groupBox1.Controls.Add(this.BrowseSavePath);
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 52);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Save Path";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Game:";
            // 
            // GamesSelector
            // 
            this.GamesSelector.AllowDrop = true;
            this.GamesSelector.BackColor = System.Drawing.SystemColors.Window;
            this.GamesSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GamesSelector.FormattingEnabled = true;
            this.GamesSelector.Location = new System.Drawing.Point(49, 9);
            this.GamesSelector.Name = "GamesSelector";
            this.GamesSelector.Size = new System.Drawing.Size(293, 21);
            this.GamesSelector.TabIndex = 7;
            this.GamesSelector.SelectedIndexChanged += new System.EventHandler(this.GamesSelector_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BackupPathText);
            this.groupBox2.Controls.Add(this.BrowseBackupPath);
            this.groupBox2.Location = new System.Drawing.Point(12, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(336, 52);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Backup Path";
            // 
            // BackupPathText
            // 
            this.BackupPathText.Cursor = System.Windows.Forms.Cursors.Default;
            this.BackupPathText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BackupPathText.Location = new System.Drawing.Point(11, 21);
            this.BackupPathText.Name = "BackupPathText";
            this.BackupPathText.ReadOnly = true;
            this.BackupPathText.Size = new System.Drawing.Size(237, 20);
            this.BackupPathText.TabIndex = 5;
            this.BackupPathText.TextChanged += new System.EventHandler(this.BackupPathText_TextChanged);
            // 
            // BrowseBackupPath
            // 
            this.BrowseBackupPath.Location = new System.Drawing.Point(255, 19);
            this.BrowseBackupPath.Name = "BrowseBackupPath";
            this.BrowseBackupPath.Size = new System.Drawing.Size(75, 23);
            this.BrowseBackupPath.TabIndex = 6;
            this.BrowseBackupPath.Text = "Browse...";
            this.BrowseBackupPath.UseVisualStyleBackColor = true;
            this.BrowseBackupPath.Click += new System.EventHandler(this.BrowseBackupPath_Click);
            // 
            // ProfilesList
            // 
            this.ProfilesList.FormattingEnabled = true;
            this.ProfilesList.Location = new System.Drawing.Point(11, 21);
            this.ProfilesList.Name = "ProfilesList";
            this.ProfilesList.Size = new System.Drawing.Size(237, 186);
            this.ProfilesList.TabIndex = 9;
            // 
            // NewProfileButton
            // 
            this.NewProfileButton.Location = new System.Drawing.Point(255, 21);
            this.NewProfileButton.Name = "NewProfileButton";
            this.NewProfileButton.Size = new System.Drawing.Size(75, 23);
            this.NewProfileButton.TabIndex = 10;
            this.NewProfileButton.Text = "New";
            this.NewProfileButton.UseVisualStyleBackColor = true;
            this.NewProfileButton.Click += new System.EventHandler(this.NewProfileButton_Click);
            // 
            // EditProfileButton
            // 
            this.EditProfileButton.Enabled = false;
            this.EditProfileButton.Location = new System.Drawing.Point(255, 50);
            this.EditProfileButton.Name = "EditProfileButton";
            this.EditProfileButton.Size = new System.Drawing.Size(75, 23);
            this.EditProfileButton.TabIndex = 11;
            this.EditProfileButton.Text = "Edit";
            this.EditProfileButton.UseVisualStyleBackColor = true;
            this.EditProfileButton.Click += new System.EventHandler(this.EditProfileButton_Click);
            // 
            // DeleteProfileButton
            // 
            this.DeleteProfileButton.Location = new System.Drawing.Point(255, 79);
            this.DeleteProfileButton.Name = "DeleteProfileButton";
            this.DeleteProfileButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteProfileButton.TabIndex = 12;
            this.DeleteProfileButton.Text = "Delete";
            this.DeleteProfileButton.UseVisualStyleBackColor = true;
            this.DeleteProfileButton.Click += new System.EventHandler(this.DeleteProfileButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ProfilesList);
            this.groupBox3.Controls.Add(this.DeleteProfileButton);
            this.groupBox3.Controls.Add(this.NewProfileButton);
            this.groupBox3.Controls.Add(this.EditProfileButton);
            this.groupBox3.Location = new System.Drawing.Point(12, 152);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(336, 213);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Profiles";
            // 
            // EditProfileWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 377);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GamesSelector);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditProfileWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Profiles";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox SavePathText;
        private System.Windows.Forms.Button BrowseSavePath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox GamesSelector;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox BackupPathText;
        private System.Windows.Forms.Button BrowseBackupPath;
        private System.Windows.Forms.ListBox ProfilesList;
        private System.Windows.Forms.Button NewProfileButton;
        private System.Windows.Forms.Button EditProfileButton;
        private System.Windows.Forms.Button DeleteProfileButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.FolderBrowserDialog SavePathBrowser;
        private System.Windows.Forms.FolderBrowserDialog BackupPathBrowser;
    }
}