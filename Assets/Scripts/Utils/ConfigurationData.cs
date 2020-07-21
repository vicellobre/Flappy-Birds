using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    private const string    CONFIGURATION_DATA_FILE_NAME = "ConfigurationData.csv";

    // configuration data
    private static float    _VELOCITY_SCROLLING_EASY = -2;
    private static float    _VELOCITY_SCROLLING_MEDIUM = -2.5f;
    private static float    _VELOCITY_SCROLLING_HARD = -3;
    private static float    _POSITION_DOWN_EASY = 14;
    private static float    _POSITION_DOWN_MEDIUM = 13;
    private static float    _POSITION_DOWN_HARD = 12;
    private static float    _POSITION_UP_EASY = 17.5f;
    private static float    _POSITION_UP_MEDIUM = 16.5f;
    private static float    _POSITION_UP_HARD = 15.5f;
    private static float    _TIMER_SPAWN_EASY = 2.25f;
    private static float    _TIMER_SPAWN_MEDIUM = 2;
    private static float    _TMER_SPAWN_HARD = 1.75f;
    #endregion

    #region Properties

    public float VelocityScrollingEasy { get => _VELOCITY_SCROLLING_EASY; }
    public float VelocityScrollingMedium { get => _VELOCITY_SCROLLING_MEDIUM; }
    public float VelocityScrollingHard { get => _VELOCITY_SCROLLING_HARD; }
    public float PositionDownEasy { get => _POSITION_DOWN_EASY; }
    public float PositionDownMedium { get => _POSITION_DOWN_MEDIUM; }
    public float PositionDownHard { get => _POSITION_DOWN_HARD; }
    public float PositionUpEasy { get => _POSITION_UP_EASY; }
    public float PositionUpMedium { get => _POSITION_UP_MEDIUM; }
    public float PositionUpHard { get => _POSITION_UP_HARD; }
    public float TimerSapwnEasy { get => _TIMER_SPAWN_EASY; }
    public float TimerSapwnMedium { get => _TIMER_SPAWN_MEDIUM; }
    public float TimerSapwnHard { get => _TMER_SPAWN_HARD; }
    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData() {
        StreamReader file = null;
        try {
            file = File.OpenText(Path.Combine(Application.streamingAssetsPath, CONFIGURATION_DATA_FILE_NAME));
            string names = file.ReadLine();
            string values = file.ReadLine();

            SetConfigurationDataFields(values);
        } catch (Exception) {} finally {
            if (file != null) {
                file.Close();
            }
        }
    }
    #endregion

    #region Private Methods

    /// <summary>
    /// Sets the configuration data fields from the provided
    /// csv string
    /// </summary>
    /// <param name="csvValues">csv string of values</param>
    private static void SetConfigurationDataFields(string csvValues) {
        string[] values = csvValues.Split(';');
        _VELOCITY_SCROLLING_EASY = float.Parse(values[0]);
        _VELOCITY_SCROLLING_MEDIUM = float.Parse(values[1]);
        _VELOCITY_SCROLLING_HARD = float.Parse(values[2]);
        _POSITION_DOWN_EASY = float.Parse(values[3]);
        _POSITION_DOWN_MEDIUM = float.Parse(values[4]);
        _POSITION_DOWN_HARD = float.Parse(values[5]);
        _POSITION_UP_EASY = float.Parse(values[6]);
        _POSITION_UP_MEDIUM = float.Parse(values[7]);
        _POSITION_UP_HARD = float.Parse(values[8]);
        _TIMER_SPAWN_EASY = float.Parse(values[9]);
        _TIMER_SPAWN_MEDIUM = float.Parse(values[10]);
        _TMER_SPAWN_HARD = float.Parse(values[11]);
    }
    #endregion
}