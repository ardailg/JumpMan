using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    void Update()
    {
        CheckBirdPosition();
    }
    
    void CheckBirdPosition()
    {
        if (transform.position.x <= -15) // Yaratılan enemyler oyun alanından çıktıktan sonra -15 konumuna gelince tekrar object poola dönüyor 
        {
            gameObject.SetActive(false);
            ObjectPoolBird.instance.ReturnToPool(gameObject);
        }
    }
}
