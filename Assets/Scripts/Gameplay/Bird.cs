using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : StringEventInvoker
{

    #region Fields

    [SerializeField]
    private Rigidbody2D _rigidBody2D;
    [SerializeField]
    private Animator    _animator;

    [SerializeField]
    [Header("Fuerza de salto")]
    [Tooltip("Modificar en el editor para ajustar la fuerza de preferencia")]
    private float       _jumpForce = 200f; //CONST
    #endregion

    #region Private Methods

    /// <summary>
    /// Es llamado antes del primer frame
    /// </summary>
    private void Start()
    {
        InitializeEvents();
    }

    /// <summary>
    /// Es llamado en cada frame
    /// </summary>
    private void Update()
    {
        if (!ConfigurationUtils.GameOver && Input.GetMouseButtonDown(0))
        {
            Flap();
        }
    }

    /// <summary>
    /// Es llamado cuando se detecta una colision
    /// </summary>
    /// <param name="other"> Ignorar</param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!ConfigurationUtils.GameOver)
        {
            Dead();
        }
    }

    /// <summary>
    /// Inicializa los eventos necesarios
    /// </summary>
    private void InitializeEvents()
    {
        unityEvents.Add(EventName.GameOverEvent, new GameOverEvent());
        EventManager.AddInvoker(EventName.GameOverEvent, this);
    }

    /// <summary>
    /// Agrega una fuerza hacia arriba
    /// <para>
    /// Activa la animacion Flap
    /// </para>
    /// </summary>
    private void Flap()
    {
        AudioManager.Play(AudioClipName.Jump);
        _rigidBody2D.velocity = Vector2.zero;
        _rigidBody2D.AddForce(Vector2.up * _jumpForce);
        _animator.SetTrigger("Flap");
    }

    /// <summary>
    /// Activa la animacion Die
    /// <para>
    /// Establece la velocidad en 0
    /// </para><para>
    /// Establece la variable global del GameOver en true
    /// </para><para>
    /// Invoca los oyentes del evento GameOver 
    /// con un delay de 1seg</para>
    /// </summary>
    private void Dead()
    {
        AudioManager.Play(AudioClipName.Dead);
        _animator.SetTrigger("Die");
        _rigidBody2D.velocity = Vector2.zero;
        ConfigurationUtils.GameOver = true;
        unityEvents[EventName.GameOverEvent].Invoke("");
    }
    #endregion
}