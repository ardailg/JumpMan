using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] float loopSpeed;
    [SerializeField] Transform backgroundTransform;
    private float x, y, z;
    private void Update()
    {
        x = backgroundTransform.position.x - loopSpeed * Time.deltaTime; //her frame arası ne kadar zaman geçtiğini hesaplıyor
        y = backgroundTransform.position.y;
        z = backgroundTransform.position.z;

        Vector3 newPosition = new Vector3(x, y, z); //yeni pozisyonu Vektör3'e tanımladım

        backgroundTransform.position = newPosition;

        //-17.73
        if (backgroundTransform.position.x < -17.73)
        {
            Vector3 startPosition = new Vector3(0, 0, 0);

            backgroundTransform.position = startPosition;
        } 
    }
}
