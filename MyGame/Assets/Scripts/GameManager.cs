using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public EnemyController enemyController;
    public CoinController coinController;

    public bool isGameOver;
    
    public float gameSpeed = 1f;
    public float accelerationRate;
    private void Awake() // Singleton (instance kullanarak farklı scriptlerde erişebiliyorum), ayrıca GameManager'dan sadece bir tane olmasını sağlıyor
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        if (!isGameOver)
        {
            gameSpeed += accelerationRate * Time.deltaTime; // Oyunun hızı zamanla artıyor
        }
        
    }
    
    public void OnGameOver()
    {
        enemyController.StopSpawnEnemy();
        coinController.StopSpawnCoin();
        
        enemyController.DeactivateExistingEnemies();
        coinController.DeactivateExistingCoins();
        
        //Debug.Log("Game Over!");
        //gameSpeed = 1f;
        isGameOver = true;
    }
}
