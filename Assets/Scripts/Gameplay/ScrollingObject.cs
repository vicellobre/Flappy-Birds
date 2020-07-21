using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : StringEventInvoker
{

    #region Fields

    [SerializeField]
    private Rigidbody2D _rigidbody2D;
    #endregion

    #region Private Methods

    /// <summary>
    /// Es llamado antes del primer frame
    /// </summary>
    private void Start()
    {
        ScrollVelocity("");

        EventManager.AddListener(EventName.DifficultyUpEvent, ScrollVelocity);
        EventManager.AddListener(EventName.GameOverEvent, StopScrolling);
    }

    /// <summary>
    /// Desplaza el objeto con una velocidad
    /// en el eje hotizontal
    /// <para>
    /// La velocidad es definida en ConfigurationUtils
    /// </para>
    /// </summary>
    private void ScrollVelocity(string nothing)
    {
        if (gameObject.name.Contains("Sky"))
        {
            _rigidbody2D.velocity = new Vector2(ConfigurationUtils.VelocityScrolling / 2, 0);
        }
        else {
            _rigidbody2D.velocity = new Vector2(ConfigurationUtils.VelocityScrolling, 0);
        }
    }

    private void StopScrolling(string nothing)
    {
        _rigidbody2D.velocity = Vector2.zero;
    }
    #endregion
}