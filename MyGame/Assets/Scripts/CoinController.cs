using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public PlayerDie playerDie;
    public CoinSpawn coinSpawn;

    public void StopSpawnCoin()
    {
        if ((playerDie != null) && (coinSpawn != null) && (playerDie.character.gameObject.activeSelf == false))
        {
            coinSpawn.enabled = false;
        }
    }
    
    public void DeactivateExistingCoins()
    {
        foreach (GameObject coinObject in ObjectPool.instance.activePooledObjects) // pool'daki coinlerin içinde teker teker dönüyor ve SetActive(false) ediyor
        {
            coinObject.SetActive(false);
        }
    }
}
