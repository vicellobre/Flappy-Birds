using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Object pool generic
/// </summary>
public static class PoolObjects
{
    #region Fields

    private static GameObject       _prefabColumn;
    private static List<GameObject> _poolColumns;
    #endregion


    #region Properties

    public static GameObject PrefabColum { get { return _prefabColumn; } }
    public static List<GameObject> PoolColumns { get { return _poolColumns; } }
    #endregion


    #region Public Methods

    /// <summary>
    /// Initializes the pool
    /// </summary>
    public static void InitializePool()
    {
        // create and fill pool
        _prefabColumn = Resources.Load<GameObject>("Prefabs/Column");
        _poolColumns = new List<GameObject>(2);
        for (int i = 0; i < _poolColumns.Capacity; i++)
        {
            _poolColumns.Add(GetNewObject(_prefabColumn));
        }
    }

    /// <summary>
    /// Gets a object from the pool
    /// </summary>
    /// <returns>object</returns>
    public static GameObject GetObject(List<GameObject> pool, GameObject prefab)
    {
        // check for available object in pool
        if (pool.Count > 0)
        {
            GameObject go = pool[pool.Count - 1];
            pool.RemoveAt(pool.Count - 1);
            return go;
        }
        else
        {
            // pool empty, so expand pool and return new object
            pool.Capacity++;
            return GetNewObject(prefab);
        }
    }

    /// <summary>
    /// Returns a object to the pool
    /// </summary>
    /// <param name="pool"></param>
    /// <param name="prefab"></param>
    public static void ReturnObject(List<GameObject> pool, GameObject prefab)
    {
        if (prefab.CompareTag("Column"))
        {
            prefab.GetComponent<Column>().StopMoving("");
        }
        prefab.SetActive(false);

        if (!pool.Contains(prefab))
        {
            pool.Add(prefab);
        }
    }

    /// <summary>
    /// Gets a new object
    /// </summary>
    /// <returns>object</returns>
    public static GameObject GetNewObject(GameObject prefab)
    {
        GameObject go = GameObject.Instantiate(prefab);
        if (go.CompareTag("Column"))
        {
            go.GetComponent<Column>().Initialize();
        }

        go.SetActive(false);
        //GameObject.DontDestroyOnLoad(go);
        return go;
    }

    /// <summary>
    /// Return all the object of a type to the pool
    /// </summary>
    /// <param name="pool"></param>
    /// <param name="tag"></param>
    public static void ReturnPoolObjects(List<GameObject> pool, string tag)
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag(tag))
        {
            ReturnObject(pool, go);
        }

    }
    #endregion
}