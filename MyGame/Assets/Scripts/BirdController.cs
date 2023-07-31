using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public PlayerDieBird playerDieBird;
    public BirdSpawn birdSpawn;
    
    public void StopSpawnBird()
    {
        if ((playerDieBird != null) && (birdSpawn != null) && (playerDieBird.character.gameObject.activeSelf == false))
        {
            birdSpawn.enabled = false;
        }
    }
    
    public void DeactivateExistingBird()
    {
        foreach (GameObject birdObject in ObjectPoolBird.instance.activePooledBird) // pool'daki birdlerin içinde teker teker dönüyor ve SetActive(false) ediyor
        {
            birdObject.SetActive(false);
        }
    }
}
