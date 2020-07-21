using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameOverMenu : MenuObject, IPointerDownHandler, IPointerUpHandler
{
    #region Fields

    [SerializeField]
    private GameObject  _restartText, _gameOverText;

    [SerializeField]
    private Image       _buttonRestart;
    #endregion

    #region Protected Methods

    protected override void Awake()
    {
        Initialize();
    }
    #endregion

    #region Private Methods
    private void Start()
    {
        unityEvents.Add(EventName.RestartGameEvent, new RestartGameEvent());
        EventManager.AddInvoker(EventName.RestartGameEvent, this);
    }

    /// <summary>
    /// Se llama cuando el objeto está activo
    /// </summary>
    private void OnEnable()
    {
        Invoke("ActiveRestart", 1.5f);
    }

    /// <summary>
    /// Traduce el text de todos los
    /// objetos Text al idioma actual
    /// <para>
    /// Solo si el idioma actual es
    /// distinto al predeterminado
    /// </para>
    /// </summary>
    private new void Initialize()
    {
        if (ConfigurationUtils.Language != ConfigurationUtils.Language_DEFAULT)
        {
            foreach (Transform child in _gameOverText.transform)
            {
                if (child.TryGetComponent(out Text txt))
                {
                    txt.text = txt.text = TextName(txt);
                }
            }
		}
    }

    /// <summary>
    /// Activa el mensaje de reinicio
    ///  y el boton de pantalla completa
    /// </summary>
    private void ActiveRestart()
    {
        _restartText.SetActive(true);
        _buttonRestart.enabled = true;
    }
    #endregion

    #region Public Methods

    public void OnPointerDown(PointerEventData eventData) {}

    /// <summary>
    /// Reinicia el juego solo si
    /// el boton de reinicio se encuentra habilitado
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerUp(PointerEventData eventData)
    {
        if (_buttonRestart.enabled)
        {
            unityEvents[EventName.RestartGameEvent].Invoke("");
            MenuManager.GoToMenu(MenuName.Gameplay);   
        }
    }

    /// <summary>
    /// Llama al metodo del HUD
    /// y carga la escena de inicio
    /// </summary>
    public void Home()
    {
        unityEvents[EventName.RestartGameEvent].Invoke("");
        MenuManager.GoToMenu(MenuName.Main);
    }
    #endregion
}