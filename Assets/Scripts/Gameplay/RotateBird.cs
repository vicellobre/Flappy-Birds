using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBird : MonoBehaviour
{
    #region Fields

    private float _MaxDownVelocity = -10;
    private float _MaxDownAngle = -90;
    private Rigidbody2D _rb2d;
    #endregion

    #region Private Methods

    /// <summary>
    /// Es llamado antes del metodo Start
    /// </summary>
    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Es llamado en cada frame
    /// </summary>
    private void Update()
    {
        if (_rb2d && !ConfigurationUtils.GameOver)
        {
            Rotate();
        }
    }

    /// <summary>
    /// Rota al persona con una inclinacion
    /// de -90 grados con respecto a su velocidad
    /// de caida
    /// </summary>
    private void Rotate()
    {
        float curretVelocity = Mathf.Clamp(_rb2d.velocity.y, _MaxDownVelocity, 0);
        float angle = curretVelocity / _MaxDownVelocity * _MaxDownAngle;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;
    }
    #endregion
}