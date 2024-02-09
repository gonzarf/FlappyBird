using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePool : MonoBehaviour
{
    private List<GameObject> pool;

    [Tooltip("Object that is gonna be cloned and returned in this pool")]
    public GameObject _pipe;

    [Tooltip("Starting size of the pool")]
    public uint poolSize;

    [Tooltip("Should the pool be expanded if it doesn't find any Inactive GameObject?")]
    public bool shouldExpand = true;

    void Awake()
    {
        Init(poolSize);
    }

    public void Init(uint _size)
    {
        pool = new List<GameObject>();

        for (int i = 0; i < _size; i++)
        {
            AddGameObjectToPool();
        }
    }

    public GameObject GetInactiveGameObject()
    {
        foreach (GameObject o in pool)
        {
            if (!o.activeInHierarchy)
            {
                return o;
            }
        }

        if (shouldExpand)
        {
            return AddGameObjectToPool();
        }

        // if can't expand, that must be handled in the other script
        return null;
    }

    private GameObject AddGameObjectToPool()
    {
        GameObject obj = Instantiate(_pipe, transform);
        obj.SetActive(false);
        pool.Add(obj);
        return obj;
    }
}
