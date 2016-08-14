using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SaveOrganizer
{
    public partial class MainWindow : Form
    {
        private MFUserInfo userInfo;
        private MFGame selectedGame;
        private MFProfile selectedProfile;

        private bool loading = false; // shows if animating loading bar
        private bool performingTask = false; // shows if performing operation (such as loading or backing up)

        private System.Windows.Forms.Timer loadingBarTimer;

        public MainWindow()
        {
            InitializeComponent();
            SetupWindow();
            LoadUserInfo();
            RefreshWindow();
        }

        private void SetupWindow()
        {
            loadingBarTimer = new System.Windows.Forms.Timer();
            loadingBarTimer.Interval = 50;
            loadingBarTimer.Tick += new EventHandler(StepLoadingBar);
        }

        public void LoadUserInfo()
        {
            userInfo = new MFUserInfo();
            selectedGame = userInfo.currentGame;
            if (selectedGame != null)
            {
                selectedProfile = selectedGame.currentProfile;
            }
        }

        public void RefreshWindow()
        {
            RefreshGames();
            RefreshProfiles();

            SortingSelector.SelectedIndex = 1;

            RefreshSavesList();
        }

        public void RefreshGames()
        {
            GamesSelector.Items.Clear();
            string[] gameNames = userInfo.GetAllGamesNames();
            GamesSelector.Items.AddRange(gameNames);
            GamesSelector.SelectedIndex = userInfo.currentGameIndex;
        }

        public void RefreshProfiles()
        {
            ProfilesSelector.Items.Clear();
            string[] profileNames = selectedGame.GetAllProfileNames();
            ProfilesSelector.Items.AddRange(profileNames);
            ProfilesSelector.SelectedIndex = selectedGame.currentProfileIndex;
        }

        public void RefreshSavesList()
        {
            if (selectedProfile != null)
            {
                SavesList.Items.Clear();
                string[] saveNames = selectedProfile.GetAllSaveFileNames();
                SavesList.Items.AddRange(saveNames);
            }
        }

        private void GamesSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox selector = (ComboBox)sender;
            userInfo.currentGameIndex = selector.SelectedIndex;
            selectedGame = userInfo.currentGame;
            RefreshProfiles();
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
            if (LoadSaveProgressBar.Value >= LoadSaveProgressBar.Maximum)
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
    }
}
