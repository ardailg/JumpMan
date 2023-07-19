using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Update()
    {
        CheckEnemyPosition();
    }
    
    public void CheckEnemyPosition()
    {
        if (transform.position.x <= -15) // Yaratılan enemyler oyun alanından çıktıktan sonra -15 konumuna gelince tekrar object poola dönüyor 
        {
            ObjectPoolEnemy.instance.ReturnToPool(gameObject);
        }
    }
}
