using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    #region Fields

    private static readonly string _MENU = "Menu";
    private static readonly string _PREFABS = "Prefabs/";
    private static readonly string _HUD = "HUD";
    #endregion

    #region Private Methods

    /// <summary>
    /// Reproduce el sonido del botón
    /// y carga el menú escena indicado.
    /// </summary>
    /// <param name="menuName">Nombre de la escena a cargar</param>
    private static void LoadMenu(MenuName menuName)
    {
        AudioManager.Play(AudioClipName.Click);
        SceneManager.LoadScene(menuName.ToString() + _MENU);
    }

    /// <summary>
    /// Reproduce el sonido del botón
    /// y carga un menú objeto desde la carpeta Resources
    /// </summary>
    /// <param name="menuName">Nombre del objeto menú</param>
    /// <param name="audioName">Nombre del audio a reproducir</param>
    private static void LoadMenuObject(MenuName menuName, AudioClipName audioName)
    {
        AudioManager.Play(audioName);
        Object.Instantiate(Resources.Load(_PREFABS + menuName.ToString() + _MENU),
            GameObject.FindGameObjectWithTag(_HUD).transform);
    }

    /// <summary>
    /// Configura las variables para empezar un nuevo juego
    /// y reproduce el sonido indicado.
    /// <para>
    /// Establece timeScale a 1
    /// </para><para>
    /// Establece la variable global EnJuego en falso
    /// </para>
    /// </summary>
    /// <param name="audioName"></param>
    private static void NewGame()
    {
        Time.timeScale = 1;
    }
    #endregion

    #region Public Methods

    /// <summary>
    /// Carga la escena menú u objeto menú indicado.
    /// </summary>
    /// <param name="name">Nombre del menú</param>
    public static void GoToMenu(MenuName name)
    {
        switch (name)
        {
            case MenuName.Credits:

            case MenuName.Difficulty:

            case MenuName.Help:

            case MenuName.HighScore:

            case MenuName.Levels:

            case MenuName.Main:

            case MenuName.Settings:
                LoadMenu(name);
                break;

            case MenuName.GameOver:
                LoadMenuObject(name, AudioClipName.GameOver);
                break;

            case MenuName.Gameplay:
                AudioManager.Play(AudioClipName.Click);
                SceneManager.LoadScene("Gameplay");
                break;

            case MenuName.NextLevel:
                NewGame();
                if (NextLevelExist())
                {
                    int levelIndex = SceneManager.GetActiveScene().buildIndex;
                    SceneManager.LoadScene(levelIndex + 1);
                }
                else
                {
                    GoToMenu(MenuName.Main);
                }

                break;

            case MenuName.Pause:
                LoadMenuObject(name, AudioClipName.Click);
                break;

            case MenuName.Restart:
                NewGame();
                AudioManager.Play(AudioClipName.Click);
                string levelName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(levelName);
                break;
        }
    }

    /// <summary>
    /// Carga la escena menú u objeto menú indicado.
    /// </summary>
    /// <param name="name">Nombre del menú</param>
    public static bool NextLevelExist()
    {
        return SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings;
    }

    /// <summary>
    /// Carga el nivel del juego seleccionado.
    /// </summary>
    /// <param name="name">Nombre del nivel</param>
    public static void GoToLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    /// <summary>
    /// Obtiene el nombre de la escena actual
    /// </summary>
    /// <returns>Nombre de la escena actual</returns>
    public static string SceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
    #endregion
}