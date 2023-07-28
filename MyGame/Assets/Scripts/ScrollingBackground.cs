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
    private float loopPoint = -17.73f; // -17.73
    
    private bool transition;

    private Vector3 startPosition;
    
    public Transform backgroundTransform;

    void Start()
    {
        startPosition = backgroundTransform.position;
    }
    
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

        if (!transition && Mathf.Approximately(loopSpeed, maxLoopSpeed))
        {
            transition = true;
            StartTransition();
        }
        
        if (backgroundTransform.position.x < loopPoint)
        {
            backgroundTransform.position = startPosition;
        }
    }
    
    private void StartTransition() // yeni backgrounda geçiş
    {
        loopPoint = -54.84f;

        startPosition.x = -35.69f;
    }
    
}
