using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolBird : MonoBehaviour
{
    public static ObjectPoolBird instance;

    public List<GameObject> pooledBird; //Objeleri List'de saklıyorum
    public List<GameObject> activePooledBird;

    public int amountToPool;

    public GameObject birdPrefab;

    private void Awake()
    {
        pooledBird = new List<GameObject>();
        activePooledBird = new List<GameObject>();

        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(birdPrefab, transform);
            obj.SetActive(false);
            pooledBird.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledBird.Count; i++)
        {
            if (!pooledBird[i].activeInHierarchy)
            {
                // Move the object from pooledObjects to activePooledObjects
                GameObject obj = pooledBird[i];
                pooledBird.RemoveAt(i);
                activePooledBird.Add(obj);
                obj.SetActive(true);

                return obj;
            }
        }

        GameObject newObj = Instantiate(birdPrefab, transform);
        newObj.SetActive(false);
        activePooledBird.Add(newObj);
        pooledBird.Add(newObj);
        
        return newObj;
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        activePooledBird.Remove(obj);
        pooledBird.Add(obj);
        obj.transform.position = transform.position;
    }
}
