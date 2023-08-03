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

    public void StartTransition() // yeni backgrounda geçiş
    {
        loopPoint = -54.84f;
        startPosition.x = -35.69f;
        
        GameManager.instance.birdController.birdSpawn.enabled = true; // yeni müzik başlar başlamaz bird spawnlanmaya başlıyor
        
        // Set the bird spawning flag to true when transitioning to the new background
        GameManager.instance.isBirdSpawningEnabled = true;
        
        StartCoroutine(FadeOutMusic());
    }

    private IEnumerator FadeOutMusic() // müzik yavaşçca sesi kısılarak kapanıyor
    {
        float startVolume = MusicManager.instance.gameSource.volume;
        
        float fadeDuration = 2.5f;
        float currentTime = 0f;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            MusicManager.instance.gameSource.volume = Mathf.Lerp(startVolume, 0f, currentTime / fadeDuration); // iki değer arasında bir ara değeri döndürmeye yarar
            yield return null;
        }
        
        MusicManager.instance.gameSource.volume = 0f;
            
        MusicManager.instance.gameSource.Stop();
        MusicManager.instance.gameSource2.volume = 1.0f;
        MusicManager.instance.gameSource2.clip = MusicManager.instance.gameMusic2;
        MusicManager.instance.gameSource2.Play();
        StartCoroutine(FadeInMusic());    
    }
    
    private IEnumerator FadeInMusic() // yeni müzik devreye giriyor
    {
        float targetVolume = MusicManager.instance.gameSource2.volume;
        MusicManager.instance.gameSource2.volume = 0f;

        float fadeDuration = 0.3f;
        float currentTime = 0f;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            MusicManager.instance.gameSource2.volume = Mathf.Lerp(0f, targetVolume, currentTime / fadeDuration);
            yield return null;
        }

        MusicManager.instance.gameSource2.volume = targetVolume;
    }
}
