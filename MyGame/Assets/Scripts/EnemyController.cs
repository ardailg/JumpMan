using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public PlayerDie playerDie;
    public EnemySpawn enemySpawn;
    
    public void StopSpawnEnemy()
    {
        if (playerDie != null && enemySpawn != null && playerDie.character.gameObject.activeSelf == false)
        {
            enemySpawn.enabled = false;
        }
    }
    
    public void DeactivateExistingEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemyObject in enemies)
        {
            enemyObject.SetActive(false);
        }
    }
}
