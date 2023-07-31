using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieBird : MonoBehaviour
{
    public Transform character;
    
    public float deathDistance;
    
    public BackgroundController backgroundController;
    
    void Update()
    {
        foreach (GameObject birdObject in ObjectPoolBird.instance.activePooledBird)
        {
            Transform bird = birdObject.transform;
            // Calculate the distance between the player and each enemy
            float distanceToBird = Vector2.Distance(character.position, bird.position);

            // Check if the player is too close to the enemy and trigger the player's death
            if (distanceToBird < deathDistance)
            {
                CharacterDeath();
                break;
            }
        }
    }
    
    public void CharacterDeath()
    {
        GameOverSoundManager.instance.gameOverSource.PlayOneShot(GameOverSoundManager.instance.gameOverSound); // Game Over Sound'u ekledim
        character.gameObject.SetActive(false);
        //Debug.Log("Player Died!");
        backgroundController.StopBackground();
        
        GameManager.instance.OnGameOver(); // Singleton kullanarak çağırdım (instance)
    }
}
