using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

/// <summary>
/// A container for the configuration data
/// </summary>
public class LanguagesData
{

    #region Fields

    private Dictionary<string, Dictionary<string, string>> dictionary =
        new Dictionary<string, Dictionary<string, string>>();
    private const string LANGUAGES_DATA_FILE_NAME = "LanguagesData.csv";
    #endregion

    #region Properties

    public Dictionary<string, Dictionary<string, string>> Dict
    {
        get { return dictionary; }
    }
    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public LanguagesData()
    {
        StreamReader file = null;
        try
        {
            file = File.OpenText(Path.Combine(Application.streamingAssetsPath, LANGUAGES_DATA_FILE_NAME));

            //CONVIERTE UN ENUM A ARRAY
            string[] words = Enum.GetNames(typeof(WordsName));
            //INICIALIZANDO DICCIONARIO EXTERNO (PALABRAS)
            foreach (string word in words)
            {
                dictionary.Add(word, new Dictionary<string, string>());
            }

            //CONVIRTIENDO UN ENUM A ARRAY PARA CREAR LA TUPLA CON EL METODO ZIP
            string[] languages = Enum.GetNames(typeof(LanguageName));
            //LEYENDO LA PRIMERA LINEA
            string line = file.ReadLine();
            //OBTENIENDO PRIMERA PALABRA
            int i = 0;
            while (line != null && i < words.Length)
            {

                //OBTENIENDO EL SEGUNDO ARRAY PARA CREAR LA TUPLA CON EL METODO ZIP
                string[] translation = line.Split(';');
                //CREANDO LA TUPLA ITERABLE CON EL METODO ZIP
                var tuples = languages.Zip(translation, (l, t) => new { Language = l, Translation = t });
                //PARA RECORRER 2 ENUMERABLES EN UN FOREACH
                foreach (var tuple in tuples)
                {
                    dictionary[words[i]].Add(tuple.Language, tuple.Translation);
                }

                //LEYENDO LA SIGUIENTE LINEA
                line = file.ReadLine();
                //SIGUIENTE PALABRA
                i++;
            }
        }
        catch (Exception)
        {
            LoadFileManual();
        }
        finally
        {
            if (file != null)
            {
                file.Close();
            }
        }
    }

        private void LoadFileManual() {
        dictionary.Add("Back", new Dictionary<string, string>());
        dictionary.Add("Credits", new Dictionary<string, string>());
        dictionary.Add("Exit", new Dictionary<string, string>());
        dictionary.Add("GameOver", new Dictionary<string, string>());
        dictionary.Add("Gameplay", new Dictionary<string, string>());
        dictionary.Add("Help", new Dictionary<string, string>());
        dictionary.Add("HighScore", new Dictionary<string, string>());
        dictionary.Add("Home", new Dictionary<string, string>());
        dictionary.Add("Language", new Dictionary<string, string>());
        dictionary.Add("Music", new Dictionary<string, string>());
        dictionary.Add("Restart", new Dictionary<string, string>());
        dictionary.Add("Score", new Dictionary<string, string>());
        dictionary.Add("Settings", new Dictionary<string, string>());
        dictionary.Add("Sounds", new Dictionary<string, string>());

        dictionary["Back"].Add("English", "Back");
        dictionary["Back"].Add("Spanish", "Atras");

        dictionary["Credits"].Add("English", "Credits");
        dictionary["Credits"].Add("Spanish", "Creditos");
        
        dictionary["Exit"].Add("English", "Exit");
        dictionary["Exit"].Add("Spanish", "Salir");
        
        dictionary["GameOver"].Add("English", "GameOver");
        dictionary["GameOver"].Add("Spanish", "GameOver");

        dictionary["Gameplay"].Add("English", "Play");
        dictionary["Gameplay"].Add("Spanish", "Jugar");
        
        dictionary["Help"].Add("English", "Help");
        dictionary["Help"].Add("Spanish", "Ayuda");
        
        dictionary["HighScore"].Add("English", "HighScore");
        dictionary["HighScore"].Add("Spanish", "Mejor Puntaje");
        
        dictionary["Home"].Add("English", "Exit to menu");
        dictionary["Home"].Add("Spanish", "Salir a inicio");
        
        dictionary["Language"].Add("English", "Language");
        dictionary["Language"].Add("Spanish", "Idioma");
        
        dictionary["Music"].Add("English", "Music");
        dictionary["Music"].Add("Spanish", "Musica");
        
        dictionary["Restart"].Add("English", "Tap to restart");
        dictionary["Restart"].Add("Spanish", "Toca para reiniciar");

        dictionary["Score"].Add("English", "Score");
        dictionary["Score"].Add("Spanish", "Puntaje");

        dictionary["Settings"].Add("English", "Settings");
        dictionary["Settings"].Add("Spanish", "Ajustes");
        
        dictionary["Sounds"].Add("English", "Sounds");
        dictionary["Sounds"].Add("Spanish", "Sonidos");
    }
    #endregion
}