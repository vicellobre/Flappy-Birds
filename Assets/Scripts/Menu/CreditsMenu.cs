﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : Menu
{
    public void Back()
    {
        MenuManager.GoToMenu(MenuName.Help);
    }
}