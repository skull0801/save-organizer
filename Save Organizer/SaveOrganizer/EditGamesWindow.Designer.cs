namespace SaveOrganizer
{
    partial class EditGamesWindow
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
            this.GamesList = new System.Windows.Forms.ListBox();
            this.DeleteGameButton = new System.Windows.Forms.Button();
            this.NewGameButton = new System.Windows.Forms.Button();
            this.EditGameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GamesList
            // 
            this.GamesList.FormattingEnabled = true;
            this.GamesList.Location = new System.Drawing.Point(9, 12);
            this.GamesList.Name = "GamesList";
            this.GamesList.Size = new System.Drawing.Size(237, 186);
            this.GamesList.TabIndex = 13;
            // 
            // DeleteGameButton
            // 
            this.DeleteGameButton.Location = new System.Drawing.Point(253, 70);
            this.DeleteGameButton.Name = "DeleteGameButton";
            this.DeleteGameButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteGameButton.TabIndex = 16;
            this.DeleteGameButton.Text = "Delete";
            this.DeleteGameButton.UseVisualStyleBackColor = true;
            this.DeleteGameButton.Click += new System.EventHandler(this.DeleteGameButton_Click);
            // 
            // NewGameButton
            // 
            this.NewGameButton.Location = new System.Drawing.Point(253, 12);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(75, 23);
            this.NewGameButton.TabIndex = 14;
            this.NewGameButton.Text = "New";
            this.NewGameButton.UseVisualStyleBackColor = true;
            this.NewGameButton.Click += new System.EventHandler(this.NewGameButton_Click);
            // 
            // EditGameButton
            // 
            this.EditGameButton.Location = new System.Drawing.Point(253, 41);
            this.EditGameButton.Name = "EditGameButton";
            this.EditGameButton.Size = new System.Drawing.Size(75, 23);
            this.EditGameButton.TabIndex = 15;
            this.EditGameButton.Text = "Edit";
            this.EditGameButton.UseVisualStyleBackColor = true;
            this.EditGameButton.Click += new System.EventHandler(this.EditGameButton_Click);
            // 
            // EditGamesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 211);
            this.Controls.Add(this.GamesList);
            this.Controls.Add(this.DeleteGameButton);
            this.Controls.Add(this.NewGameButton);
            this.Controls.Add(this.EditGameButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditGamesWindow";
            this.Text = "Edit Games";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox GamesList;
        private System.Windows.Forms.Button DeleteGameButton;
        private System.Windows.Forms.Button NewGameButton;
        private System.Windows.Forms.Button EditGameButton;
    }
}