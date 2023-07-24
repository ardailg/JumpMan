using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform spawnPoint;
    public float minSpawnInterval;
    public float maxSpawnInterval;
    private float enemySpeed;

    private float timer;
    private float spawnInterval;

    public float initialEnemySpeed;
    public float maxEnemySpeed;

    public ObjectPoolEnemy ObjectPoolEnemy;

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
                SpawnEnemy();
                ResetTimer();

                // Enemy spawn interval'ını oyun hızına bağlı olarak ayarlama
                spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval) / GameManager.instance.gameSpeed;
                
                // Mathf.Clamp fonksiyonu hızın iki değer arasında kalmasını maksimum değeri aşmamasını sağlıyor
                enemySpeed = Mathf.Clamp(initialEnemySpeed * GameManager.instance.gameSpeed, initialEnemySpeed, maxEnemySpeed);
            }
        }
    }

    void ResetTimer()
    {
        timer = 0f;
        spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    }
    
    void SpawnEnemy()
    {
        GameObject newEnemy = ObjectPoolEnemy.GetPooledObject();

        if (newEnemy != null)
        {
            Vector3 spawnPosition = spawnPoint.position;
            newEnemy.transform.position = spawnPosition;
            
            newEnemy.SetActive(true);

            Rigidbody2D rgb = newEnemy.GetComponent<Rigidbody2D>();
            rgb.velocity = Vector2.left * enemySpeed;
        }
    }
}
