using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

public class MFUserInfo {
    public static readonly string USER_INFO_FOLDER_NAME = "SaveOrganizer";
    public static readonly string APP_DATA_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), USER_INFO_FOLDER_NAME);
    public static readonly string GAMES_LIST_FILE_NAME = Path.Combine(APP_DATA_PATH, "gamesList.dat");

    public List<MFGame> games { get; set; }
    private XmlSerializer gamesSerializer;
    
    private int _currentGameIndex = -1;
    public int currentGameIndex
    {
        get
        {
            return _currentGameIndex;
        }
        set
        {
            if (value >= 0 && value < games.Count)
            {
                if (_currentGameIndex >= 0)
                {
                    currentGame.profiles.Clear();
                }
                _currentGameIndex = value;
                currentGame.LoadProfiles();
            }
        }
    }
    public MFGame currentGame
    {
        get
        {
            if (_currentGameIndex != -1)
            {
                return games[currentGameIndex];
            }
            return null;
        }
    }

    public MFUserInfo()
    {
        gamesSerializer = new XmlSerializer(typeof(List<MFGame>));
        games = new List<MFGame>();
        LoadUserInfo();
    }

    public string[] GetAllGamesNames()
    {
        string[] names = new string[games.Count];
        for (int i = 0; i < games.Count; i++)
        {
            names[i] = games[i].name;
        }
        return names;
    }

    /// <summary>
    /// Loads user's configuration also loads the info for all the games saved
    /// </summary>
    public void LoadUserInfo()
    {
        if (!Directory.Exists(APP_DATA_PATH))
        {
            Console.WriteLine("Creating folder at {0}", APP_DATA_PATH);
            Directory.CreateDirectory(APP_DATA_PATH);
        }
        Console.WriteLine("Loading games list");
        if (File.Exists(GAMES_LIST_FILE_NAME))
        {
            using (FileStream file = new FileStream(GAMES_LIST_FILE_NAME, FileMode.Open))
            {
                //TO-DO handle errors
                byte[] buffer = new byte[file.Length];
                file.Read(buffer, 0, (int)file.Length);
                MemoryStream stream = new MemoryStream(buffer);
                games = (List<MFGame>) gamesSerializer.Deserialize(stream);
                Console.WriteLine("Games List loaded successfully");
                if (games.Count > 0)
                {
                    currentGameIndex = 0;
                }
            }
        }
        else
        {
            Console.WriteLine("Games List file did not exist, creating a new one.");
            SaveGamesList();
        }
    }


    /// <summary>
    /// Adds default games (Just for testing)
    /// </summary>
    public void AddDefaultGames()
    {
        games.Add(new MFGame("Game", @"D:\Downloads\Save", @"D:\Downloads\Back"));
    }

    public void AddGame(MFGame game)
    {
        games.Add(game);
        if (_currentGameIndex < 0)
        {
            _currentGameIndex = 0;
        }
        MFAppInfo.sharedInstance().selectedGame = currentGame;
        SaveGamesList();
    }

    public void DeleteGameAtIndex(int index)
    {
        if (index >= 0 && index <= games.Count)
        {
            games.RemoveAt(index);
            if (_currentGameIndex >= games.Count)
            {
                _currentGameIndex -= games.Count - 1;
            }
            MFAppInfo.sharedInstance().selectedGame = currentGame;
            SaveGamesList();
        }
    }

    public void DeleteGame(MFGame game)
    {
        DeleteGameAtIndex(games.IndexOf(game));
    }

    /// <summary>
    /// Saves all the current games to file
    /// </summary>
    public void SaveGamesList()
    {
        //TO-DO handle errors
        FileStream file = File.Create(GAMES_LIST_FILE_NAME);
        gamesSerializer.Serialize(file, games);
        file.Close();
        Console.WriteLine("Games List saved successfully!");
    }

}
