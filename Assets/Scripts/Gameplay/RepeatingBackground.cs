using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{

    #region Fields

    [SerializeField]
    private SpriteRenderer _sprite;

    [SerializeField]
    Rigidbody2D _rigidbody2D;
    private Vector2 _position;
    private float _width;
    #endregion

    #region Private Methods

    /// <summary>
    /// Es llamado antes del primer frame
    /// </summary>
    private void Start()
    {
        _width = _sprite.size.x;
        //_position = new Vector2(_width, transform.position.y);
        _position = new Vector2(_width * 2, 0);
    }

    /// <summary>
    /// Es llamado en cada frame
    /// </summary>
    private void Update()
    {
        Repeating();
    }

    /// <summary>
    /// Reposiciona el objeto a una distancia
    /// dos veces su collider, hacia atrás
    /// </summary>
    private void Repeating()
    {
        if (transform.position.x <= -_width)
        {
            //_rigidbody2D.MovePosition(_position);
            transform.Translate(_position);
        }
    }
    #endregion
}