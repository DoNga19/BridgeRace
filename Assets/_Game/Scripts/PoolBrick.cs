using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolBrick : MonoBehaviour
{
    [Serializable]
    public class Pool
    {
        public Material tag;
        public GameObject prefab;
    }

    #region Singleton
    public static PoolBrick instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion

    [SerializeField] public List<Pool> pools;

    [SerializeField] public Dictionary<Color, Queue<GameObject>> poolDictionary;

    [SerializeField] private GameObject prefabsUnused;

    public int size = 100;

    public void Oninit()
    {
        poolDictionary = new Dictionary<Color, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> brickPool = new Queue<GameObject>();

            for (int i = 0; i < size; i++)
            {
                GameObject brick = Instantiate(pool.prefab);
                AddToEnqueue(brick, brickPool);
            }

            poolDictionary.Add(pool.tag.color, brickPool);
        }
    }

    public void AddToEnqueue(GameObject brick, Queue<GameObject> brickPool)
    {
        brick.transform.SetParent(prefabsUnused.transform);
        brick.SetActive(false);
        brickPool.Enqueue(brick);
    }

    public GameObject SpawnBrickFromPool(Color tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            return null;
        }

        GameObject brickToSpawn = poolDictionary[tag].Dequeue();

        brickToSpawn.SetActive(true);
        brickToSpawn.transform.position = position;
        brickToSpawn.transform.rotation = rotation;

        return brickToSpawn;
    }
}
