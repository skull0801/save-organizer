namespace SaveOrganizer
{
    partial class MainWindow
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
            this.GamesSelector = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EditGameButton = new System.Windows.Forms.Button();
            this.EditProfileButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ProfilesSelector = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SortingSelector = new System.Windows.Forms.ComboBox();
            this.SearchTextInput = new System.Windows.Forms.TextBox();
            this.BackupCurrentButton = new System.Windows.Forms.Button();
            this.LoadSelectedButton = new System.Windows.Forms.Button();
            this.LoadSaveProgressBar = new System.Windows.Forms.ProgressBar();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.SavesList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // GamesSelector
            // 
            this.GamesSelector.AllowDrop = true;
            this.GamesSelector.BackColor = System.Drawing.SystemColors.Window;
            this.GamesSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GamesSelector.FormattingEnabled = true;
            this.GamesSelector.Location = new System.Drawing.Point(59, 19);
            this.GamesSelector.Name = "GamesSelector";
            this.GamesSelector.Size = new System.Drawing.Size(241, 21);
            this.GamesSelector.TabIndex = 0;
            this.GamesSelector.SelectedIndexChanged += new System.EventHandler(this.GamesSelector_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Game:";
            // 
            // EditGameButton
            // 
            this.EditGameButton.Location = new System.Drawing.Point(309, 17);
            this.EditGameButton.Name = "EditGameButton";
            this.EditGameButton.Size = new System.Drawing.Size(98, 23);
            this.EditGameButton.TabIndex = 2;
            this.EditGameButton.Text = "Edit Games";
            this.EditGameButton.UseVisualStyleBackColor = true;
            this.EditGameButton.Click += new System.EventHandler(this.EditGameButton_Click);
            // 
            // EditProfileButton
            // 
            this.EditProfileButton.Location = new System.Drawing.Point(309, 44);
            this.EditProfileButton.Name = "EditProfileButton";
            this.EditProfileButton.Size = new System.Drawing.Size(97, 23);
            this.EditProfileButton.TabIndex = 5;
            this.EditProfileButton.Text = "Edit Profiles";
            this.EditProfileButton.UseVisualStyleBackColor = true;
            this.EditProfileButton.Click += new System.EventHandler(this.EditProfileButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Profile:";
            // 
            // ProfilesSelector
            // 
            this.ProfilesSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProfilesSelector.FormattingEnabled = true;
            this.ProfilesSelector.Location = new System.Drawing.Point(59, 46);
            this.ProfilesSelector.Name = "ProfilesSelector";
            this.ProfilesSelector.Size = new System.Drawing.Size(241, 21);
            this.ProfilesSelector.TabIndex = 3;
            this.ProfilesSelector.SelectedIndexChanged += new System.EventHandler(this.ProfilesSelector_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Sort By:";
            // 
            // SortingSelector
            // 
            this.SortingSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SortingSelector.Enabled = false;
            this.SortingSelector.FormattingEnabled = true;
            this.SortingSelector.Items.AddRange(new object[] {
            "Created",
            "Name"});
            this.SortingSelector.Location = new System.Drawing.Point(59, 71);
            this.SortingSelector.Name = "SortingSelector";
            this.SortingSelector.Size = new System.Drawing.Size(77, 21);
            this.SortingSelector.TabIndex = 8;
            // 
            // SearchTextInput
            // 
            this.SearchTextInput.Enabled = false;
            this.SearchTextInput.Location = new System.Drawing.Point(142, 71);
            this.SearchTextInput.Name = "SearchTextInput";
            this.SearchTextInput.Size = new System.Drawing.Size(264, 20);
            this.SearchTextInput.TabIndex = 9;
            this.SearchTextInput.Text = "Filter...";
            // 
            // BackupCurrentButton
            // 
            this.BackupCurrentButton.Location = new System.Drawing.Point(15, 361);
            this.BackupCurrentButton.Name = "BackupCurrentButton";
            this.BackupCurrentButton.Size = new System.Drawing.Size(121, 23);
            this.BackupCurrentButton.TabIndex = 10;
            this.BackupCurrentButton.Text = "Backup Current Save";
            this.BackupCurrentButton.UseVisualStyleBackColor = true;
            this.BackupCurrentButton.Click += new System.EventHandler(this.BackupCurrentButton_Click);
            // 
            // LoadSelectedButton
            // 
            this.LoadSelectedButton.Location = new System.Drawing.Point(142, 361);
            this.LoadSelectedButton.Name = "LoadSelectedButton";
            this.LoadSelectedButton.Size = new System.Drawing.Size(121, 23);
            this.LoadSelectedButton.TabIndex = 12;
            this.LoadSelectedButton.Text = "Load Selected Save";
            this.LoadSelectedButton.UseVisualStyleBackColor = true;
            this.LoadSelectedButton.Click += new System.EventHandler(this.LoadSelectedButton_Click);
            // 
            // LoadSaveProgressBar
            // 
            this.LoadSaveProgressBar.Location = new System.Drawing.Point(269, 366);
            this.LoadSaveProgressBar.Name = "LoadSaveProgressBar";
            this.LoadSaveProgressBar.Size = new System.Drawing.Size(61, 12);
            this.LoadSaveProgressBar.TabIndex = 13;
            // 
            // SettingsButton
            // 
            this.SettingsButton.Enabled = false;
            this.SettingsButton.Location = new System.Drawing.Point(336, 361);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(70, 23);
            this.SettingsButton.TabIndex = 14;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = true;
            // 
            // SavesList
            // 
            this.SavesList.ForeColor = System.Drawing.SystemColors.MenuText;
            this.SavesList.FormattingEnabled = true;
            this.SavesList.Location = new System.Drawing.Point(17, 100);
            this.SavesList.Name = "SavesList";
            this.SavesList.Size = new System.Drawing.Size(389, 251);
            this.SavesList.TabIndex = 15;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 396);
            this.Controls.Add(this.SavesList);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.LoadSaveProgressBar);
            this.Controls.Add(this.LoadSelectedButton);
            this.Controls.Add(this.BackupCurrentButton);
            this.Controls.Add(this.SearchTextInput);
            this.Controls.Add(this.SortingSelector);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.EditProfileButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ProfilesSelector);
            this.Controls.Add(this.EditGameButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GamesSelector);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "skull0801\'s Save Organizer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox GamesSelector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EditGameButton;
        private System.Windows.Forms.Button EditProfileButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ProfilesSelector;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox SortingSelector;
        private System.Windows.Forms.TextBox SearchTextInput;
        private System.Windows.Forms.Button BackupCurrentButton;
        private System.Windows.Forms.Button LoadSelectedButton;
        private System.Windows.Forms.ProgressBar LoadSaveProgressBar;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.ListBox SavesList;
    }
}

