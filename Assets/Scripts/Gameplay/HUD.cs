using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MenuObject
{

    #region Fields

    private static int  _POINTS_INT = 0;
    
    [SerializeField]
    private Text        _pointsText;

    [SerializeField]
    GameObject gameOverMenu;
    #endregion

    #region Private Methods

    /// <summary>
    /// Es llamado antes dl metodo Start
    /// </summary>
    protected override void Awake()
    {
        Initialize();
    }

    /// <summary>
    /// Es llamado antes del primer frame
    /// </summary>
    private void Start()
    {
        _pointsText.text += ": " + _POINTS_INT.ToString();
        AddListeners();
    }

    /// <summary>
    /// Agrega todos los metodos oyentes necesarios
    /// </summary>
    private void AddListeners()
    {
        EventManager.AddListener(EventName.GameOverEvent, GameOver);
        EventManager.AddListener(EventName.RestartGameEvent, RestartGame);
        EventManager.AddListener(EventName.GetPointsEvent, GetPoints);
    }

    /// <summary>
    /// Método oyente
    /// <para>
    /// Instancia el menú GameOver
    /// </para><para>
    /// Establece los puntos a cero
    /// </para><para>
    /// Establece la varibale global GameOver en true
    /// </para>
    /// </summary>
    /// <param name="nothing">Ignorar</param>
    private void GameOver(string nothing)
    {
        SetHighScore();
        AudioManager.Play(AudioClipName.GameOver);
        Instantiate(gameOverMenu, transform);
        //MenuManager.GoToMenu(MenuName.GameOver);
        _POINTS_INT = 0;
        ConfigurationUtils.GameOver = true;
    }

    /// <summary>
    /// Método oyente
    /// <para>
    /// Establece la variable global GameOver en true
    /// </para><para>
    /// Carga la escena de Gameplay</para>
    /// </summary>
    /// <param name="nothing">Ignorar</param>
    private void RestartGame(string nothing)
    {
        PoolObjects.ReturnPoolObjects(PoolObjects.PoolColumns, "Column");
        ConfigurationUtils.GameOver = false;
        ConfigurationUtils.Difficulty = Difficulty.Easy;
    }

    /// <summary>
    /// Método oyente
    /// <para>
    /// Incremte los puntos en 1
    /// </para><para>
    /// Actualiza el texto de puntos
    /// </para>
    /// </summary>
    /// <param name="nothing"></param>
    private void GetPoints(string nothing)
    {
        _POINTS_INT++;
        _pointsText.text = "Score: " + _POINTS_INT.ToString();
    }

    private void SetHighScore()
    {
        if (_POINTS_INT > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", _POINTS_INT);
            PlayerPrefs.Save();
        }
    }
    #endregion
}