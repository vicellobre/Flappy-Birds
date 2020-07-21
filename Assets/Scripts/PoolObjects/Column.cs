using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Column
/// </summary>
public class Column : StringEventInvoker
{
    #region  Fields

    // saved for efficiency
    [SerializeField]
    private Rigidbody2D     _rigidbody2D;

    [SerializeField]
    private EdgeCollider2D  _edgeCollider2D;
    #endregion

    #region Public Methods

    /// <summary>
    /// Initializes object. We don't use Start for this because
    /// we want to set up the points added event when we
    /// create the object in the column pool
    /// </summary>
    public void Initialize()
    {
        unityEvents.Add(EventName.GetPointsEvent, new GetPointsEvent());
        EventManager.AddInvoker(EventName.GetPointsEvent, this);

        EventManager.AddListener(EventName.DifficultyUpEvent, MostSpeed);
        EventManager.AddListener(EventName.GameOverEvent, StopMoving);
    }

    /// <summary>
    /// Starts the column moving
    /// </summary>
    public void StartMoving()
    {
        // apply velocity to get moving
        //_rigidbody2D.velocity = new Vector2(ConfigurationUtils.VelocityScrolling, 0);
        _rigidbody2D.velocity = new Vector2(ConfigurationUtils.VelocityScrolling, 0);
        _edgeCollider2D.enabled = true;
        //HACER MOVER LAS COLUMNAS VERTICALMENTE
    }

    /// <summary>
    /// Stops the column
    /// </summary>
    public void StopMoving(string notging)
    {
        _rigidbody2D.velocity = Vector2.zero;
    }

    public void DisableEdgeCollider()
    {
        _edgeCollider2D.enabled = false;
    }
    #endregion


    #region Private Methods

    /// <summary>
    /// Called when the column became invisible
    /// </summary>
    private void OnBecameInvisible()
    {
        PoolObjects.ReturnObject(PoolObjects.PoolColumns, gameObject);
    }

    /// <summary>
    /// Processes trigger collisions with other game objects
    /// </summary>
    /// <param name="other">information about the other collider</param>
    private void OnTriggerExit2D(Collider2D other)
    {
        // if colliding with Player, add score
        if (other.gameObject.CompareTag("Player") && !ConfigurationUtils.GameOver)
        {
            unityEvents[EventName.GetPointsEvent].Invoke("");
            AudioManager.Play(AudioClipName.Points);
        }
    }

    private void MostSpeed(string nothing)
    {
        _rigidbody2D.velocity = new Vector2(ConfigurationUtils.VelocityScrolling, 0);
    }
    #endregion
}