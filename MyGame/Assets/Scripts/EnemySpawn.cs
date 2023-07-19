using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform spawnPoint;
    public float minSpawnInterval;
    public float maxSpawnInterval;
    public float enemySpeed;

    private float timer;
    private float spawnInterval;

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
            SpawnEnemy();
            ResetTimer();
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
