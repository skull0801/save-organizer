using System;
using System.Collections.Generic;

public class MFAppInfo
{
    private static MFAppInfo _sharedInstance;
    private MFGame _selectedGame;

    public MFUserInfo userInfo;
    public MFGame selectedGame
    {
        get
        {
            return _selectedGame;
        }
        set
        {
            _selectedGame = value;
            if (_selectedGame != null)
            {
                selectedProfile = _selectedGame.currentProfile;
            }
            else
            {
                selectedProfile = null;
            }
        }
    }
    public MFProfile selectedProfile;

    private MFAppInfo()
    {
        LoadUserInfo();
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

    public static MFAppInfo sharedInstance()
    {
        if (_sharedInstance == null)
        {
            _sharedInstance = new MFAppInfo();
        }
        return _sharedInstance;
    }

}
