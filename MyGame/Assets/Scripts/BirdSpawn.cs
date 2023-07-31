using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawn : MonoBehaviour
{
    public Transform spawnPoint;
    
    public float minSpawnInterval;
    public float maxSpawnInterval;
    private float birdSpeed;

    private float timer;
    private float spawnInterval;

    public float initialBirdSpeed;
    public float maxBirdSpeed;

    public ObjectPoolBird ObjectPoolBird;

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
                birdSpeed = Mathf.Clamp(initialBirdSpeed * GameManager.instance.gameSpeed, initialBirdSpeed, maxBirdSpeed);
            }
        }
    }

    void ResetTimer()
    {
        timer = 0f;
        spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    }
    
    public void SpawnEnemy()
    {
        GameObject newEnemy = ObjectPoolBird.GetPooledObject();

        if (newEnemy != null)
        {
            Vector3 spawnPosition = spawnPoint.position;
            newEnemy.transform.position = spawnPosition;
            
            newEnemy.SetActive(true);

            Rigidbody2D rgb = newEnemy.GetComponent<Rigidbody2D>();
            rgb.velocity = Vector2.left * birdSpeed;
        }
    }
}
