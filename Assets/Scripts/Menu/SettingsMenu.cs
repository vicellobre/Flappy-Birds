using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : Menu
{

    #region Fields

    private readonly string[] LANGUAGES_NAMES = { "English", "Español" };

    [SerializeField]
    private Text musicText, languageText, soundText;

    private AudioSource _speakersMusic, _speakersSounds;
    #endregion

    #region Protected Methods

    /// <summary>
    /// Inicializa todos los gameObjects con etiqueta Boton
    /// </summary>
    protected override void Initialize()
    {
        base.Initialize();

        GameObject go = GameObject.FindGameObjectWithTag("SpeakersSounds");
        _speakersSounds = go.GetComponent<AudioSource>();

        go = GameObject.FindGameObjectWithTag("SpeakersMusic");
        _speakersMusic = go.GetComponent<AudioSource>();

        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons) {
            switch (Type(button)) {

                case ButtonName.Language:
                    languageText.text += ": " + LANGUAGES_NAMES[(int) ConfigurationUtils.Language];
                    break;

                case ButtonName.Music:
                    musicText.color = ConfigurationUtils.Music ? Color.white : Color.grey;
                    break;

                case ButtonName.Sounds:
                    soundText.color = ConfigurationUtils.Sounds ? Color.white : Color.grey;  
                    break;
            }
        }
    }

    /// <summary>
    /// Determina a qué tipo de botón pertenece el objeto
    /// </summary>
    /// <param name="button">Objeto a convetir su nombre en ButtonName</param>
    /// <returns>El nombre del objeto convertido a tipo ButtonName</returns>
    private ButtonName Type(Button button) {
        return (ButtonName) System.Enum.Parse(typeof(ButtonName), button.name);
    }
    #endregion

    #region Public Methods

    /// <summary>
    /// Habilita/Deshabilita la música del juego.
    /// </summary>
    public void Music()
    {
        AudioManager.Play(AudioClipName.Click);
        ConfigurationUtils.Music = !ConfigurationUtils.Music;
        _speakersMusic.enabled = ConfigurationUtils.Music;
        musicText.color = ConfigurationUtils.Music ? Color.white : Color.grey;
    }

    /// <summary>
    /// Habilita/Deshabilita los efectos de sonidos del juego.
    /// </summary>
    public void Sounds()
    {
        AudioManager.Play(AudioClipName.Click);
        ConfigurationUtils.Sounds = !ConfigurationUtils.Sounds;
        _speakersSounds.enabled = ConfigurationUtils.Sounds;
        soundText.color = ConfigurationUtils.Sounds ? Color.white : Color.grey;      
    }

    /// <summary>
    /// Cambia el idioma al instante
    /// y guarda el idioma actual en una
    /// variable del PlayerPrefs
    /// </summary>
    public void Language()
    {
        AudioManager.Play(AudioClipName.Click);

        int i = (int) ConfigurationUtils.Language;

        i = (i < (int) LanguageName.Spanish) ? i + 1 : 0;
        ConfigurationUtils.Language = (LanguageName) i;

        languageText.text = TextName(languageText);
        languageText.text += ": " + LANGUAGES_NAMES[(int) ConfigurationUtils.Language];

        PlayerPrefs.SetString("Language", ConfigurationUtils.Language.ToString());

        MenuManager.GoToMenu(MenuName.Settings);
    }

    /// <summary>
    /// Regresa al menú principal
    /// </summary>
    public void Back()
    {
        AudioManager.Play(AudioClipName.Click);
        PlayerPrefs.Save(); //OJO
        MenuManager.GoToMenu(MenuName.Main);
    }
    #endregion
}