using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public PlayerDie playerDie;
    public CoinSpawn coinSpawn;

    public void StopSpawnCoin()
    {
        if (playerDie != null && coinSpawn != null && playerDie.character.gameObject.activeSelf == false)
        {
            coinSpawn.enabled = false;
        }
    }
    
    public void DeactivateExistingCoins()
    {
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        foreach (GameObject coinObject in coins)
        {
            coinObject.SetActive(false);
        }
    }
}
