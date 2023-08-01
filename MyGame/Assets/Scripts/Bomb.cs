using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float bombSpeed = 5f;
    private float horizontalForce = 0f;

    public void InitializeBombMovement(float randomForceX)
    {
        horizontalForce = randomForceX;
    }
    
    void Update()
    {
        transform.Translate(Vector2.down * bombSpeed * Time.deltaTime);
        
        transform.Translate(Vector2.right * horizontalForce * Time.deltaTime);
        
        CheckBombPosition();
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
    
    public void CheckBombPosition()
    {
        if (transform.position.y <= -10) // Yaratılan enemyler oyun alanından çıktıktan sonra -15 konumuna gelince tekrar object poola dönüyor 
        {
            gameObject.SetActive(false);
            ObjectPoolBomb.instance.ReturnToPool(gameObject);
        }
    }
}
