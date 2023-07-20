using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolEnemy : MonoBehaviour
{
    public static ObjectPoolEnemy instance;

    public List<GameObject> pooledEnemy; //Objeleri List'de saklıyorum
    public List<GameObject> activePooledEnemy;

    public int amountToPool;

    public GameObject enemyPrefab;

    private void Awake()
    {
        pooledEnemy = new List<GameObject>();
        activePooledEnemy = new List<GameObject>();

        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(enemyPrefab, transform);
            obj.SetActive(false);
            pooledEnemy.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledEnemy.Count; i++)
        {
            if (!pooledEnemy[i].activeInHierarchy)
            {
                // Move the object from pooledObjects to activePooledObjects
                GameObject obj = pooledEnemy[i];
                pooledEnemy.RemoveAt(i);
                activePooledEnemy.Add(obj);
                obj.SetActive(true);

                return obj;
            }
        }

        GameObject newObj = Instantiate(enemyPrefab, transform);
        newObj.SetActive(false);
        activePooledEnemy.Add(newObj);
        pooledEnemy.Add(newObj);
        
        return newObj;
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        activePooledEnemy.Remove(obj);
        pooledEnemy.Add(obj);
        obj.transform.position = transform.position;
    }
}
