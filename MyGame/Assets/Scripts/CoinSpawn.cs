using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public Transform spawnPoint;
    public float minSpawnInterval;
    public float maxSpawnInterval;
    private float coinSpeed;

    private float timer;
    private float spawnInterval;

    public float initialCoinSpeed;
    public float maxCoinSpeed;

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
            if (!GameManager.instance.isGameOver)
            {
                SpawnCoin();
                ResetTimer();
                
                // Mathf.Clamp fonksiyonu hızın iki değer arasında kalmasını maksimum değeri aşmamasını sağlıyor
                coinSpeed = Mathf.Clamp(initialCoinSpeed * GameManager.instance.gameSpeed, initialCoinSpeed, maxCoinSpeed);
            }
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
            float verticalOffset = Random.Range(-1.5f, 2f);
            Vector3 spawnPosition = spawnPoint.position + new Vector3(0f, verticalOffset, 0f);
            newCoin.transform.position = spawnPosition;
            
            newCoin.SetActive(true);

            Rigidbody2D rgb = newCoin.GetComponent<Rigidbody2D>();
            rgb.velocity = Vector2.left * coinSpeed;
        }
    }
}
