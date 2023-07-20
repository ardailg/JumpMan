using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    public List<GameObject> pooledObjects; // Objeleri List'de saklıyorum
    public List<GameObject> activePooledObjects; // Aktif olan objeler için

    public int amountToPool;

    public GameObject coinPrefab;

    private void Awake()
    {
        pooledObjects = new List<GameObject>();
        activePooledObjects = new List<GameObject>();
        
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
                // Move the object from pooledObjects to activePooledObjects
                GameObject obj = pooledObjects[i];
                pooledObjects.RemoveAt(i);
                activePooledObjects.Add(obj);
                obj.SetActive(true);

                return obj;
            }
        }
        
        GameObject newObj = Instantiate(coinPrefab, transform);
        newObj.SetActive(true);
        activePooledObjects.Add(newObj);
        pooledObjects.Add(newObj);

        return newObj;
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        activePooledObjects.Remove(obj);
        pooledObjects.Add(obj);
        obj.transform.position = transform.position;
    }
}
