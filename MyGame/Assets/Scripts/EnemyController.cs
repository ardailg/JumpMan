using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public PlayerDie playerDie;
    public EnemySpawn enemySpawn;
    
    public void StopSpawnEnemy()
    {
        if ((playerDie != null) && (enemySpawn != null) && (playerDie.character.gameObject.activeSelf == false))
        {
            enemySpawn.enabled = false;
        }
    }
    
    public void DeactivateExistingEnemies()
    {
        foreach (GameObject enemyObject in ObjectPoolEnemy.instance.activePooledEnemy) // pool'daki enemylerin içinde teker teker dönüyor ve SetActive(false) ediyor
        {
            enemyObject.SetActive(false);
        }
    }
}
