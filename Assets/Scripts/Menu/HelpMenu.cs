using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : Menu
{
    #region Public Methods

    public void Back()
    {
        MenuManager.GoToMenu(MenuName.Main);
    }

    public void Credits()
    {
        MenuManager.GoToMenu(MenuName.Credits);
    }
    #endregion
}