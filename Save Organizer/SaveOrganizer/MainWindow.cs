using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace SaveOrganizer
{
    public partial class MainWindow : Form
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

        private bool loading = false; // shows if animating loading bar
        private bool performingTask = false; // shows if performing operation (such as loading or backing up)

        private System.Windows.Forms.Timer loadingBarTimer;

        public MainWindow()
        {
            appInfo = MFAppInfo.sharedInstance();
            InitializeComponent();
            SetupWindow();
            RefreshWindow();
        }

        private void SetupWindow()
        {
            loadingBarTimer = new System.Windows.Forms.Timer();
            loadingBarTimer.Interval = 10;
            loadingBarTimer.Tick += new EventHandler(StepLoadingBar);

            Activated += Window_Focused;

            SaveMenu.Opened += SaveMenu_Opened;

        }

        public void RefreshWindow()
        {
            RefreshGames();
            RefreshProfiles();

            SortingSelector.SelectedIndex = 1;

            RefreshSavesList();
            RefreshButtons();
        }

        public void RefreshGames()
        {
            GamesSelector.Items.Clear();
            string[] gameNames = userInfo.GetAllGamesNames();
            GamesSelector.Items.AddRange(gameNames);
            GamesSelector.SelectedIndex = userInfo.currentGameIndex;

            GamesSelector.Enabled = GamesSelector.Items.Count > 0;
        }

        public void RefreshProfiles()
        {
            ProfilesSelector.Items.Clear();
            if (selectedGame != null)
            {
                string[] profileNames = selectedGame.GetAllProfileNames();
                ProfilesSelector.Items.AddRange(profileNames);
                ProfilesSelector.SelectedIndex = selectedGame.currentProfileIndex;
            }

            ProfilesSelector.Enabled = ProfilesSelector.Items.Count > 0;
        }

        public void RefreshSavesList()
        {
            SavesList.Items.Clear();
            if (selectedProfile != null)
            {
                string[] saveNames = selectedProfile.GetAllSaveFileNames();
                SavesList.Items.AddRange(saveNames);
            }
            LoadSelectedButton.Enabled = SavesList.SelectedIndex != -1;
        }

        public void RefreshButtons()
        {
            LoadSelectedButton.Enabled = selectedProfile != null && selectedProfile.canLoadSave;
            BackupCurrentButton.Enabled = selectedGame != null && selectedGame.canBackup;

            EditGameButton.Enabled = true;
            EditProfileButton.Enabled = selectedGame != null;
        }

        private void GamesSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox selector = (ComboBox)sender;
            userInfo.currentGameIndex = selector.SelectedIndex;
            selectedGame = userInfo.currentGame;
            selectedGame.LoadProfiles();
            RefreshProfiles();
            RefreshSavesList();
            RefreshButtons();
        }

        private void ProfilesSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox selector = (ComboBox)sender;
            if (selectedGame != null)
            {
                selectedGame.currentProfileIndex = selector.SelectedIndex;
                selectedProfile = selectedGame.currentProfile;
                RefreshSavesList();
            }
            else
            {
                //TODO handle this error
                Console.WriteLine("Selected profile without game selected!");
            }
            RefreshButtons();
        }

        private void BackupCurrentButton_Click(object sender, EventArgs e)
        {
            if (!performingTask && selectedGame != null)
            {
                MFSave save = selectedGame.BackupCurrentSave();
                if (save != null)
                {
                    Console.WriteLine("Backed up save file successfully");
                    RefreshSavesList();
                }
                else
                {
                    //TODO handle this error
                    Console.WriteLine("Could not back up");
                }
                performingTask = false;
            }
            else
            {
                //TODO 
                Console.WriteLine("Trying to backup with no game selected");
            }
        }

        private void LoadSelectedButton_Click(object sender, EventArgs e)
        {
            if (!performingTask && selectedProfile != null)
            {
                int selectedIndex = SavesList.SelectedIndex;
                if (selectedIndex >= 0 && selectedIndex < selectedProfile.saves.Count)
                {
                    StartAnimatingLoadingBar();
                    MFSave save = selectedProfile.saves[selectedIndex];
                    if (save != null)
                    {
                        bool success = selectedProfile.LoadSave(save);
                        if (success)
                        {
                            Console.WriteLine("Loaded successfully");
                        }
                        else
                        {
                            //TODO handle this error
                            Console.WriteLine("Could not load");
                        }
                    }
                    else
                    {
                        //TODO w/e
                    }
                }
                performingTask = false;
            }
            else
            {
                //TODO 
                Console.WriteLine("Trying to load with no profile selected");
            }
        }

        private void StartAnimatingLoadingBar()
        {
            if (!loading)
            {
                loading = true;
                loadingBarTimer.Start();
            }
        }

        private void StepLoadingBar(object sender, EventArgs e)
        {
            LoadSaveProgressBar.PerformStep();
            LoadSaveProgressBar.Value = LoadSaveProgressBar.Value - 1;
            if (LoadSaveProgressBar.Value >= LoadSaveProgressBar.Maximum - 1)
            {
                LoadSaveProgressBar.Value = LoadSaveProgressBar.Minimum;
                if (!performingTask)
                {
                    StopAnimatingLoadingBar();
                }
            }
        }

        private void StopAnimatingLoadingBar()
        {
            loading = false;
            loadingBarTimer.Stop();
        }

        private void EditProfileButton_Click(object sender, EventArgs e)
        {
            EditProfileWindow window = new EditProfileWindow();
            window.ShowDialog();

            RefreshWindow();
            userInfo.SaveGamesList();
        }

        private void EditGameButton_Click(object sender, EventArgs e)
        {
            EditGamesWindow window = new EditGamesWindow();
            window.ShowDialog();

            RefreshWindow();
        }

        private void Window_Focused(object sender, System.EventArgs e)
        {
            if (userInfo.currentGame != null)
            {
                userInfo.currentGame.LoadProfiles();
                RefreshProfiles();
                if (userInfo.currentGame.currentProfile != null)
                {
                    userInfo.currentGame.currentProfile.LoadSaves();
                    RefreshSavesList();
                }
            }
        }

        private void SaveMenu_Opened(object sender, System.EventArgs e)
        {

        }

        private void openLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = SavesList.SelectedIndex;
            if (index >= 0 && index < userInfo.currentGame.currentProfile.saves.Count)
            {
                MFSave save = userInfo.currentGame.currentProfile.saves[index];
                string argument = "/select, \"" + save.path + "\"";
                Process.Start("explorer.exe", argument);
            }
        }

        private void renameSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = SavesList.SelectedIndex;
            if (index >= 0 && index < userInfo.currentGame.currentProfile.saves.Count)
            {
                string newName = GetNameWithTitleAndPrompt("New Name", "Name: ", userInfo.currentGame.currentProfile.saves[index].name);
                switch(userInfo.currentGame.currentProfile.saves[index].RenameTo(newName))
                {
                    case MFSaveRenameResult.NAME_EXISTS:
                        MessageBox.Show("File with name " + newName + " already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case MFSaveRenameResult.EMPTY:
                        MessageBox.Show("File cannot have empty name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                RefreshSavesList();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = SavesList.SelectedIndex;
            if (index >= 0 && index < userInfo.currentGame.currentProfile.saves.Count)
            {
                MFSave save = userInfo.currentGame.currentProfile.saves[index];
                if (MessageBox.Show("Are you sure you want to delete?", "Delete " + save.name, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (!userInfo.currentGame.currentProfile.RemoveSaveAtIndex(index))
                    {
                        MessageBox.Show("Could not delete save!");
                    }
                    RefreshSavesList();
                }
            }
        }

        public string GetNameWithTitleAndPrompt(string title, string prompt = "Name: ", string defaultText = "")
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

        private void SavesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedButton.Enabled = SavesList.SelectedIndex != -1;
        }
    }
}
