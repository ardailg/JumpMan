using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    public List<GameObject> pooledObjects; //Objeleri List'de saklıyorum

    public int amountToPool;

    public GameObject coinPrefab;

    private void Awake()
    {
        pooledObjects = new List<GameObject>();
        
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(coinPrefab, transform);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        
        GameObject obj = Instantiate(coinPrefab, transform);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }
}
