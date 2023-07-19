using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    public Transform character;
    public Transform[] enemies;
    public float deathDistance;
    public BackgroundController backgroundController;

    void Start()
    {
        // Find all enemy objects in the scene and store their transforms in the 'enemies' array
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        enemies = new Transform[enemyObjects.Length];
        for (int i = 0; i < enemyObjects.Length; i++)
        {
            enemies[i] = enemyObjects[i].transform;
        }
    }

    void Update()
    {
        foreach (Transform enemy in enemies)
        {
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
