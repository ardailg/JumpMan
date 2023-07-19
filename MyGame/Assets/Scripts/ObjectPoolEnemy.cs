using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolEnemy : MonoBehaviour
{
    public static ObjectPoolEnemy instance;

    public List<GameObject> pooledEnemy; //Objeleri List'de saklıyorum

    public int amountToPool;

    public GameObject enemyPrefab;

    private void Awake()
    {
        pooledEnemy = new List<GameObject>();

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
                return pooledEnemy[i];
            }
        }

        GameObject obj = Instantiate(enemyPrefab, transform);
        obj.SetActive(false);
        pooledEnemy.Add(obj);
        return obj;
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        pooledEnemy.Add(obj);
        obj.transform.position = transform.position;
    }
}
