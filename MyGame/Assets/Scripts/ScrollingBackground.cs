using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingBackground : MonoBehaviour
{
    public float initialLoopSpeed;
    public float maxLoopSpeed;
    
    private float loopSpeed;
    
    public Transform backgroundTransform;
    
    void Update()
    {
        loopSpeed = GameManager.instance.gameSpeed * initialLoopSpeed;

        // Maksimum hız değerini aştığında artık hızlanmayı durdur
        loopSpeed = Mathf.Clamp(loopSpeed, 0f, maxLoopSpeed);
        
        float x = backgroundTransform.position.x - loopSpeed * Time.deltaTime; //her frame arası ne kadar zaman geçtiğini hesaplıyor
        float y = backgroundTransform.position.y;
        float z = backgroundTransform.position.z;

        Vector3 newPosition = new Vector3(x, y, z); //yeni pozisyonu Vektör3'e tanımladım
        backgroundTransform.position = newPosition;

        // -17.73
        if (backgroundTransform.position.x < -17.73f)
        {
            Vector3 startPosition = new Vector3(0, 0, 0);
            backgroundTransform.position = startPosition;
        }
    }
}
