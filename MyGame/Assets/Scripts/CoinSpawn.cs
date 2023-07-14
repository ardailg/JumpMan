using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public Transform spawnPoint;
    public float minSpawnInterval;
    public float maxSpawnInterval;
    public float coinSpeed;

    private float timer;
    private float spawnInterval;

    public ObjectPool ObjectPool;

    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnCoin();
            ResetTimer();
        }
    }

    void ResetTimer()
    {
        timer = 0f;
        spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    }
    
    void SpawnCoin()
    {
        GameObject newCoin = ObjectPool.GetPooledObject();

        if (newCoin != null)
        {
            float verticalOffset = Random.Range(-2f, 2f);
            Vector3 spawnPosition = spawnPoint.position + new Vector3(0f, verticalOffset, 0f);
            newCoin.transform.position = spawnPosition;
            
            newCoin.SetActive(true);

            Rigidbody2D rgb = newCoin.GetComponent<Rigidbody2D>();
            rgb.velocity = Vector2.left * coinSpeed;
        }
    }
}
