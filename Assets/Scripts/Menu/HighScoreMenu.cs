using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreMenu : Menu
{
    #region  Fields

    [SerializeField]
    private Text _scoreText;
    #endregion

    #region Private Methods

    private void Start() {
        _scoreText.text += ": " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void Back()
    {
        MenuManager.GoToMenu(MenuName.Main);
    }
    #endregion
}