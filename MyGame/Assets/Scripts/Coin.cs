using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void Update()
    {
        CheckCoinsPosition();
    }

    void CheckCoinsPosition()
    {
        if (transform.position.x <= -15) // Yaratılan coinler oyun alanından çıktıktan sonra -15 konumuna gelince tekrar object poola dönüyor 
            {
                gameObject.SetActive(false);
                ObjectPool.instance.pooledObjects.Add(gameObject);
            }
    }
}
