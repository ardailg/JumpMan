using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolParticle : MonoBehaviour
{
    public static ObjectPoolParticle instance;

    public List<GameObject> pooledParticles; //Objeleri List'de saklıyorum
    public List<GameObject> activePooledParticles; // Aktif olan objeler için

    public int amountToPool;

    public GameObject particle;

    private void Awake()
    {
        pooledParticles = new List<GameObject>();
        activePooledParticles = new List<GameObject>();
        
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(particle, transform);
            obj.SetActive(false);
            pooledParticles.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledParticles.Count; i++)
        {
            if (!pooledParticles[i].activeInHierarchy)
            {
                GameObject obj = pooledParticles[i];
                pooledParticles.RemoveAt(i);
                activePooledParticles.Add(obj);
                obj.SetActive(true);
                
                StartDisableParticleCoroutine(obj, 2f); // StartDisableParticleCoroutine(particle, 2f);

                return obj;
            }
        }

        GameObject newObj = Instantiate(particle, transform);
        newObj.SetActive(false);
        activePooledParticles.Add(newObj);
        pooledParticles.Add(newObj);
        
        return newObj;
    }
    
    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        activePooledParticles.Remove(obj);
        pooledParticles.Add(obj);
        obj.transform.position = transform.position;
        obj.GetComponent<ParticleSystem>().Clear();
        obj.GetComponent<ParticleSystem>().Stop();
    }

    //Coroutine
    public void StartDisableParticleCoroutine(GameObject particleObj, float delay)
    {
        StartCoroutine(DisableParticleAfterDelay(particleObj, delay));
    }

    private IEnumerator DisableParticleAfterDelay(GameObject particleObj, float delay)
    {
        yield return new WaitForSeconds(delay);
        ReturnToPool(particleObj);
    }
}
