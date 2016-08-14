using System;
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
    public partial class EditGamesWindow : Form
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

        public EditGamesWindow()
        {
            appInfo = MFAppInfo.sharedInstance();
            InitializeComponent();
            RefreshGamesList();
            RefreshButtons();
        }

        public void RefreshButtons()
        {
            DeleteGameButton.Enabled = userInfo.games.Count > 0;
        }

        public void RefreshGamesList()
        {
            GamesList.Items.Clear();
            string[] gameNames = userInfo.GetAllGamesNames();
            GamesList.Items.AddRange(gameNames);
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            string name = GetGameNameWithTitleAndPrompt("New Game");
            if (!String.IsNullOrWhiteSpace(name))
            {
                MFGame game = new MFGame(name);
                userInfo.AddGame(game);
                RefreshGamesList();
            }
        }

        private void EditGameButton_Click(object sender, EventArgs e)
        {
            int index = GamesList.SelectedIndex;
            if (index >= 0 && index < userInfo.games.Count)
            {
                MFGame game = userInfo.games[index];
                string name = GetGameNameWithTitleAndPrompt("Edit " + game.name, "Name: ", game.name);
                game.name = name;
                userInfo.SaveGamesList();
                RefreshGamesList();
            }
        }

        private void DeleteGameButton_Click(object sender, EventArgs e)
        {
            int index = GamesList.SelectedIndex;
            if (index >= 0 && index < userInfo.games.Count)
            {
                MFGame game = userInfo.games[index];
                DialogResult confirmation = MessageBox.Show("The backup and save folders will NOT be deleted.", "Delete " + game.name + "?", MessageBoxButtons.YesNo);
                if (confirmation == DialogResult.Yes)
                {
                    userInfo.DeleteGameAtIndex(index);
                    RefreshGamesList();
                }
            }
        }

        public string GetGameNameWithTitleAndPrompt(string title, string prompt = "Name: ", string defaultText = "")
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
    }
}
