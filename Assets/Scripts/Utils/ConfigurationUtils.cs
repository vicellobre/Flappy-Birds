using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{    
    #region  Fields
    
    private const LanguageName          _LANGUAGE_DEFAULT = LanguageName.English;
    private static ConfigurationData    _CONFIGURATION_DATA;
    private static LanguagesData        _LANGUAGES_DATA;
    private static Difficulty           _DIFFICULTY;
    private static LanguageName         _LANGUAGE;
    private static bool                 _MUSIC = true;
    private static bool                 _SOUNDS = true;
    private static bool                 _GAME_OVER = false;
    private static float                _VELOCITY_SCROLLING;
    private static float                _POSITION_DOWN;
    private static float                _POSITION_UP;
    private static float                _TIMER_SPAWN;
    #endregion


    #region Properties

    public static Dictionary<string, Dictionary<string, string>> Dict { get => _LANGUAGES_DATA.Dict; }
    public static LanguageName Language_DEFAULT { get => _LANGUAGE_DEFAULT; }
    public static float VelocityScrolling       { get => _VELOCITY_SCROLLING; set => _VELOCITY_SCROLLING = value; }
    public static float PositionDown            { get => _POSITION_DOWN; set => _POSITION_DOWN = value; }
    public static float PositionUp              { get => _POSITION_UP; set => _POSITION_UP = value; }
    public static float TimerSpawn              { get => _TIMER_SPAWN; set => _TIMER_SPAWN = value; }
    public static LanguageName Language         { get => _LANGUAGE; set => _LANGUAGE = value; }
    public static bool Music                    { get => _MUSIC; set => _MUSIC = value; }
    public static bool Sounds                   { get => _SOUNDS; set => _SOUNDS = value; }
    public static bool GameOver                 { get => _GAME_OVER; set => _GAME_OVER = value;}
    public static Difficulty Difficulty{
        get => _DIFFICULTY;

        set {
            _DIFFICULTY = value;
            switch (_DIFFICULTY) {
                case Difficulty.Easy:
                    _VELOCITY_SCROLLING = _CONFIGURATION_DATA.VelocityScrollingEasy;
                    _POSITION_DOWN = _CONFIGURATION_DATA.PositionDownEasy;
                    _POSITION_UP = _CONFIGURATION_DATA.PositionUpEasy;
                    _TIMER_SPAWN = _CONFIGURATION_DATA.TimerSapwnEasy;
                    break;

                case Difficulty.Medium:
                    _VELOCITY_SCROLLING = _CONFIGURATION_DATA.VelocityScrollingMedium;
                    _POSITION_DOWN = _CONFIGURATION_DATA.PositionDownMedium;
                    _POSITION_UP = _CONFIGURATION_DATA.PositionUpMedium;
                    _TIMER_SPAWN = _CONFIGURATION_DATA.TimerSapwnMedium;
                    break;

                case Difficulty.Hard:
                    _VELOCITY_SCROLLING = _CONFIGURATION_DATA.VelocityScrollingHard;
                    _POSITION_DOWN = _CONFIGURATION_DATA.PositionDownHard;
                    _POSITION_UP = _CONFIGURATION_DATA.PositionUpHard;
                    _TIMER_SPAWN = _CONFIGURATION_DATA.TimerSapwnHard;
                    break;

                default:
                    _VELOCITY_SCROLLING = _CONFIGURATION_DATA.VelocityScrollingEasy;
                    _POSITION_DOWN = _CONFIGURATION_DATA.PositionDownEasy;
                    _POSITION_UP = _CONFIGURATION_DATA.PositionUpEasy;
                    _TIMER_SPAWN = _CONFIGURATION_DATA.TimerSapwnEasy;
                    break;
            }
        }
    }
    #endregion Properties


    #region Public Methods

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize() {
        _CONFIGURATION_DATA = new ConfigurationData();
        _LANGUAGES_DATA = new LanguagesData();

        string field = PlayerPrefs.GetString("Language", _LANGUAGE_DEFAULT.ToString());
        _LANGUAGE = (LanguageName) System.Enum.Parse(typeof(LanguageName), field);
    }
    #endregion
}