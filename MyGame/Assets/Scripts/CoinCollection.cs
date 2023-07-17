using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollection : MonoBehaviour
{
    public Transform character; // Karakterin transform bileşeni
    public Transform[] coins; // Coin'lerin transform bileşenleri
    public float minDistance;
    public Transform spawnPoint;
    public float verticalOffset;

    private Score score;
    void Start()
    {
        GameObject[] coinObjects = GameObject.FindGameObjectsWithTag("Coin");
        coins = new Transform[coinObjects.Length];
        
        for (int i = 0; i < coinObjects.Length; i++)
        {
            coins[i] = coinObjects[i].transform;
        }

        score = FindObjectOfType<Score>(); // Score script'ini bul ve referans al
    }

    void Update()
    {
        foreach (Transform coin in coins)
        {
            float distance = Vector2.Distance(character.position, coin.position);
            if ((distance < minDistance) && (coin.gameObject.activeSelf)) // Coin pozisyonu değişecek if'e bir kere girmesi için 
            {
                CollectCoin(coin.gameObject);
            }
        }
    }

    void CollectCoin(GameObject coin)
    {
        coin.SetActive(false);
        ObjectPool.instance.pooledObjects.Add(coin);
        
        Vector3 spawnPosition = spawnPoint.position + new Vector3(0f, verticalOffset, 0f);
        coin.transform.position = spawnPosition;
        
        score.UpdateScore();
    }
}
