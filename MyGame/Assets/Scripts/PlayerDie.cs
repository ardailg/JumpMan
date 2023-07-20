using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    public Transform character;
    public float deathDistance;
    public BackgroundController backgroundController;
    
    void Update()
    {
        foreach (GameObject enemyObject in ObjectPoolEnemy.instance.activePooledEnemy)
        {
            Transform enemy = enemyObject.transform;
            // Calculate the distance between the player and each enemy
            float distanceToEnemy = Vector2.Distance(character.position, enemy.position);

            // Check if the player is too close to the enemy and trigger the player's death
            if (distanceToEnemy < deathDistance)
            {
                CharacterDeath();
                break;
            }
        }
    }

    public void CharacterDeath()
    {
        character.gameObject.SetActive(false);
        //Debug.Log("Player Died!");
        backgroundController.StopBackground();
        
        GameManager.instance.OnGameOver(); // Singleton kullanarak çağırdım (instance)
    }
}
