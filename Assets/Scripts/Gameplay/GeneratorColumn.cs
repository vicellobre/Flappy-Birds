using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorColumn : StringEventInvoker
{

    #region Fields

    // TIMER
    private float               _spawnRate = ConfigurationUtils.TimerSpawn;
    private float               _timeSinceLastSpawned;
    private const float         _RESTART_TIMER = 15f;

    [SerializeField]
    private Timer               _timer;

    // COLUMNS
    [SerializeField]
    private GameObject          _prefabColumn;
    private readonly Vector3    _SCALE_INVERSE = new Vector3(1, -1, 1);
    #endregion

    #region Methods Privates

    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        unityEvents.Add(EventName.DifficultyUpEvent, new DifficultyUpEvent());
        EventManager.AddInvoker(EventName.DifficultyUpEvent, this);

        PoolObjects.InitializePool();
    }

    /// <summary>
    /// Es llamado antes del primer frame
    /// </summary>
    private void Start()
    {
        SpawColumn();
        StartClock();
    }

    /// <summary>
    /// Es llamado en cada frame
    /// </summary>
    private void Update()
    {
        if (ConfigurationUtils.GameOver) return;

        _timeSinceLastSpawned += Time.deltaTime;
        if (_timeSinceLastSpawned >= _spawnRate)
        {
            _timeSinceLastSpawned = 0;
            SpawColumn();

            if(!_timer.Running && ConfigurationUtils.Difficulty != Difficulty.Hard)
            {
                LevelUp();
                AudioManager.Play(AudioClipName.LevelUp);
            }
        }
    }

    /// <summary>
    /// Establece la duracion del reloj y lo inicia/ejeucta
    /// </summary>
    private void StartClock()
    {
        _timer.Duration = _RESTART_TIMER;
        _timer.Run();
    }

    /// <summary>
    /// Genera una columna
    /// </summary>
    private void SpawColumn()
    {
        GameObject go = PoolObjects.GetObject(PoolObjects.PoolColumns, _prefabColumn);
        TypeColumn(go);
        go.SetActive(true);
        go.GetComponent<Column>().StartMoving();
    }

    private void LevelUp()
    {
        if (ConfigurationUtils.Difficulty == Difficulty.Easy )
        {
            ConfigurationUtils.Difficulty = Difficulty.Medium;
        }else {
            ConfigurationUtils.Difficulty = Difficulty.Hard;
        }
        
        _spawnRate = ConfigurationUtils.TimerSpawn;
         StartClock();
        unityEvents[EventName.DifficultyUpEvent].Invoke("");
    }

    private void TypeColumn(GameObject column)
    {
        int typeColumn = Random.Range(0, 3); //CONST
        switch (typeColumn)
        {   // Column Down
            case 0:
                TypeZero(column);
                break;
            // Column up
            case 1:
                TypeOne(column);
                break;
            // Column Down and column up
            case 2:
                TypeZero(column);
                TypeTwo(column.transform.position.y);
                break;
        }   
    }

    private void TypeZero(GameObject column)
    {
        column.transform.localScale = Vector3.one;
        float positionY = Random.Range(-7, -2);
        column.transform.position = new Vector2(12, positionY); //CONST
    }

    private void TypeOne(GameObject column)
    {
        column.transform.localScale = _SCALE_INVERSE; //CONST
        float positionY = Random.Range(4, 9.5f); //CONST
        column.transform.position = new Vector2(12, positionY); //CONST
    }

    private void TypeTwo(float positionY)
    {
        GameObject columnUp = PoolObjects.GetObject(PoolObjects.PoolColumns, _prefabColumn);
        columnUp.transform.localScale = _SCALE_INVERSE; //CONST

        float otherY = Random.Range(positionY + 12.5f, 9.5f); //CONST
        columnUp.transform.position = new Vector2(12, otherY); //CONST

        columnUp.SetActive(true);
        Column script = columnUp.GetComponent<Column>();
        script.StartMoving();
        script.DisableEdgeCollider();
    }
    #endregion
}