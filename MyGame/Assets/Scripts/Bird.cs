using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Transform character;

    public float shootDistance;

    public bool canShoot = true;

    void Update()
    {
        CheckBirdPosition();
        CheckForShoot();
    }
    
    public void CheckBirdPosition()
    {
        if (transform.position.x <= -15) // Yaratılan enemyler oyun alanından çıktıktan sonra -15 konumuna gelince tekrar object poola dönüyor 
        {
            gameObject.SetActive(false);
            ObjectPoolBird.instance.ReturnToPool(gameObject);
        }
    }
    
    public void CheckForShoot()
    {
        if (canShoot && Mathf.Abs(transform.position.x - character.position.x) < shootDistance)
        {
            ShootBomb();
            canShoot = false; // Bir kere bomba atılsın
        }
    }

    public void ShootBomb()
    {
        GameObject newBomb =  ObjectPoolBomb.instance.GetPooledObject();
        newBomb.transform.position = transform.position;
        newBomb.SetActive(true);

        float randomForceX = Random.Range(-6f, 2f);
        Bomb bombComponent = newBomb.GetComponent<Bomb>();
        bombComponent.InitializeBombMovement(randomForceX);
    }
}
