using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaveOrganizer
{
    public partial class EditProfileWindow : Form
    {
        private MFAppInfo appInfo;

        private MFUserInfo userInfo
        {
            get { return appInfo.userInfo; }
            set { appInfo.userInfo = value; }
        }
        private MFGame selectedGame
        {
            get { return appInfo.selectedGame; }
            set { appInfo.selectedGame = value; }
        }
        private MFProfile selectedProfile
        {
            get { return appInfo.selectedProfile; }
            set { appInfo.selectedProfile = value; }
        }

        public EditProfileWindow()
        {
            appInfo = MFAppInfo.sharedInstance();
            InitializeComponent();
            RefreshWindow();
        }

        public void RefreshWindow()
        {
            RefreshGames();
            RefreshGamePaths();
            RefreshProfilesList();
            RefreshButtons();
        }
        
        public void RefreshButtons()
        {
            NewProfileButton.Enabled = selectedGame != null && !String.IsNullOrWhiteSpace(selectedGame.backupsFolderPath);
            DeleteProfileButton.Enabled = selectedGame != null && selectedGame.profiles.Count > 0;
        }

        public void RefreshGames()
        {
            GamesSelector.Items.Clear();
            string[] gameNames = userInfo.GetAllGamesNames();
            GamesSelector.Items.AddRange(gameNames);
            GamesSelector.SelectedIndex = userInfo.currentGameIndex;

            GamesSelector.Enabled = GamesSelector.Items.Count > 0;
        }

        public void RefreshGamePaths()
        {
            string savePathText = null;
            string backupPathText = null;
            if (selectedGame != null)
            {
                savePathText = selectedGame.saveFolderPath;
                backupPathText = selectedGame.backupsFolderPath;
            }
            SavePathText.Text = savePathText;
            BackupPathText.Text = backupPathText;
        }

        public void RefreshProfilesList()
        {
            ProfilesList.Items.Clear();
            if (selectedGame != null)
            {
                string[] profileNames = selectedGame.GetAllProfileNames();
                ProfilesList.Items.AddRange(profileNames);
            }
        }

        private void GamesSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox selector = (ComboBox)sender;
            userInfo.currentGameIndex = selector.SelectedIndex;
            selectedGame = userInfo.currentGame;
            RefreshGamePaths();
            RefreshProfilesList();
        }

        private void NewProfileButton_Click(object sender, EventArgs e)
        {
            if (selectedGame != null && !String.IsNullOrWhiteSpace(selectedGame.backupsFolderPath))
            {
                string newProfileName = GetProfileNameWithTitleAndPrompt("Create Profile");
                if (!String.IsNullOrWhiteSpace(newProfileName))
                {
                    string path = Path.Combine(selectedGame.backupsFolderPath, newProfileName);
                    MFProfile newProfile = new MFProfile(path, selectedGame);
                    if (newProfile.path != null)
                    {
                        selectedGame.AddProfile(newProfile);
                    }
                    RefreshProfilesList();
                }
            }
        }

        private void EditProfileButton_Click(object sender, EventArgs e)
        {
            if (selectedGame != null && !String.IsNullOrWhiteSpace(selectedGame.backupsFolderPath))
            {
                int index = ProfilesList.SelectedIndex;
                if (index >= 0 && index < selectedGame.profiles.Count)
                {
                    MFProfile profile = selectedGame.profiles[index];
                    string newProfileName = GetProfileNameWithTitleAndPrompt("Edit " + profile.name, "Name: ", profile.name);
                }
            }
        }

        private void DeleteProfileButton_Click(object sender, EventArgs e)
        {
            if (selectedGame != null && !String.IsNullOrWhiteSpace(selectedGame.backupsFolderPath))
            {
                int index = ProfilesList.SelectedIndex;
                if (index >= 0 && index < selectedGame.profiles.Count)
                {
                    MFProfile profile = selectedGame.profiles[index];
                    DialogResult confirmation = MessageBox.Show("Are you sure you want to delete " + profile.name + " and all of its contents?", "", MessageBoxButtons.YesNo);
                    if (confirmation == DialogResult.Yes)
                    {
                        if (!selectedGame.RemoveProfileAtIndex(index))
                        {
                            // TODO show message that was not deleted
                            Console.WriteLine("COULD NOT DELETE");
                        }
                        RefreshProfilesList();
                    }
                }
            }
        }

        public string GetProfileNameWithTitleAndPrompt(string title, string prompt = "Name: ", string defaultText = "")
        {
            string name = null;
            TextInputForm form = new TextInputForm(title, prompt);
            form.InputText = defaultText;
            if (form.ShowDialog() == DialogResult.OK)
            {
                name = form.InputText;
            }
            return name;
        }

        private void BrowseSavePath_Click(object sender, EventArgs e)
        {
            if (selectedGame != null)
            {
                SavePathBrowser.ShowDialog();
                if (!String.IsNullOrWhiteSpace(SavePathBrowser.SelectedPath) && !SavePathBrowser.SelectedPath.Equals(selectedGame.backupsFolderPath))
                {
                    selectedGame.saveFolderPath = SavePathBrowser.SelectedPath;
                }
                RefreshGamePaths();
            }
        }

        private void BrowseBackupPath_Click(object sender, EventArgs e)
        {
            if (selectedGame != null)
            {
                BackupPathBrowser.ShowDialog();
                if (!String.IsNullOrWhiteSpace(BackupPathBrowser.SelectedPath) && !BackupPathBrowser.SelectedPath.Equals(selectedGame.saveFolderPath))
                {
                    selectedGame.backupsFolderPath = BackupPathBrowser.SelectedPath;
                }
                RefreshButtons();
                RefreshGamePaths();
                RefreshProfilesList();
            }
        }

        private void SavePathText_TextChanged(object sender, EventArgs e)
        {

        }

        private void BackupPathText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
