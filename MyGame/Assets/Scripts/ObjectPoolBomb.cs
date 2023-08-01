using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolBomb : MonoBehaviour
{
    public static ObjectPoolBomb instance;

    public List<GameObject> pooledBombs; //Objeleri List'de saklıyorum
    public List<GameObject> activePooledBombs; // Aktif olan objeler için

    public int amountToPool;

    public GameObject bomb;

    private void Awake()
    {
        pooledBombs = new List<GameObject>();
        activePooledBombs = new List<GameObject>();
        
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(bomb, transform);
            obj.SetActive(false);
            pooledBombs.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledBombs.Count; i++)
        {
            if (!pooledBombs[i].activeInHierarchy)
            {
                GameObject obj = pooledBombs[i];
                pooledBombs.RemoveAt(i);
                activePooledBombs.Add(obj);
                obj.SetActive(true);
                
                StartDisableBombCoroutine(obj, 2f); // StartDisableParticleCoroutine(particle, 2f);

                return obj;
            }
        }

        GameObject newObj = Instantiate(bomb, transform);
        newObj.SetActive(false);
        activePooledBombs.Add(newObj);
        pooledBombs.Add(newObj);
        
        return newObj;
    }
    
    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        activePooledBombs.Remove(obj);
        pooledBombs.Add(obj);
        obj.transform.position = transform.position;
        obj.GetComponent<ParticleSystem>().Clear();
        obj.GetComponent<ParticleSystem>().Stop();
    }

    //Coroutine
    public void StartDisableBombCoroutine(GameObject particleObj, float delay)
    {
        StartCoroutine(DisableBombAfterDelay(particleObj, delay));
    }

    private IEnumerator DisableBombAfterDelay(GameObject particleObj, float delay)
    {
        yield return new WaitForSeconds(delay);
        ReturnToPool(particleObj);
    }
    
}
