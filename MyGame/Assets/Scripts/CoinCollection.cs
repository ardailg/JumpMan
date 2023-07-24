using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollection : MonoBehaviour
 {
     public Transform character; // Karakterin transform bileşeni
     public Transform hairCenter; // Karakterin saçının transform bileşeni
     public Transform feetCenter; //Karakterin ayaklarının transform bileşeni
     public float feetTouchDistance;
     public float hairTouchDistance;
     public float minDistance;
     public Transform spawnPoint;
     public float verticalOffset;
     public Score score;
     
     void Update()
     {
         for (int i = 0; i < ObjectPool.instance.activePooledObjects.Count; i++)
         {
             GameObject coinObject = ObjectPool.instance.activePooledObjects[i];
             Transform coin = coinObject.transform;
             
             float distanceToCharacter = Vector2.Distance(character.position, coin.position);
             float distanceToHair = Vector2.Distance(hairCenter.position, coin.position);
             float distanceToFeet = Vector2.Distance(feetCenter.position, coin.position);

             if (distanceToCharacter < minDistance || distanceToHair < hairTouchDistance || distanceToFeet < feetTouchDistance)
             {
                 CollectCoin(coin.gameObject);
                 // activePooledObjects'den ayrılan coinler için index küçülttüm
                 i--;
             }
         }
     }
 
     void CollectCoin(GameObject coin)
     {
         coin.SetActive(false);
         
         GameObject particle = ObjectPoolParticle.instance.GetPooledObject();
         if (particle != null)
         {
             particle.transform.position = coin.transform.position;
             particle.SetActive(true);
         }
         
         ObjectPool.instance.ReturnToPool(coin);
         
         Vector3 spawnPosition = spawnPoint.position + new Vector3(0f, verticalOffset, 0f);
         coin.transform.position = spawnPosition;
                
         score.UpdateScore();
     }
 }
