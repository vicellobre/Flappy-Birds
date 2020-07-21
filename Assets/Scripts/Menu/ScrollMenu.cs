using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollMenu : MonoBehaviour
{

    #region Fields

    [Header("Componentes RawImage")]

    [Tooltip("Componente RawImage de este mismo objecto")]
    [SerializeField]
    private RawImage _rawImage;
    private readonly Rect _RECT_INIT = new Rect(0, 0, 1, 1);

    [Space]

    [Tooltip("Ajustar la velocidad de scrolling")]
    [SerializeField]
    [Range(0.001f, 0.1f)]
    private float _velocityScrolling;
    #endregion

    #region Private Methods

    // Update is called once per frame
    private void Update()
    {
        _rawImage.uvRect = (_rawImage.uvRect.x + _velocityScrolling) >= 1
            ? _RECT_INIT
            : new Rect(_rawImage.uvRect.x + _velocityScrolling, 0, 1, 1);
    }
    #endregion
}