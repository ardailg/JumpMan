using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public EnemyController enemyController;
    public CoinController coinController;
    private void Awake() // Singleton (instance kullanarak farklı scriptlerde erişebiliyorum), ayrıca GameManager'dan sadece bir tane olmasını sağlıyor
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    public void OnGameOver()
    {
        enemyController.StopSpawnEnemy();
        coinController.StopSpawnCoin();
        
        enemyController.DeactivateExistingEnemies();
        coinController.DeactivateExistingCoins();
    }
    
}
