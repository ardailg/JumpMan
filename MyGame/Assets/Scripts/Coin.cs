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
        if (transform.position.x <= -15) // Modify the condition as per your desired position
            {
                gameObject.SetActive(false);
                ObjectPool.instance.pooledObjects.Add(gameObject);
            }
    }
}
