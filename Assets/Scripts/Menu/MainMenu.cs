using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : Menu
{
    #region Public Methods

    public void Help()
    {
        MenuManager.GoToMenu(MenuName.Help);
    }

    public void HighScore()
    {
        MenuManager.GoToMenu(MenuName.HighScore);
    }

    public void Play()
    {
        ConfigurationUtils.Difficulty = Difficulty.Easy;
        MenuManager.GoToMenu(MenuName.Gameplay);
    }

    public void Settings()
    {
        MenuManager.GoToMenu(MenuName.Settings);
    }

    public void Quit()
    {
        Application.Quit();
    }
    #endregion
}