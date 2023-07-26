using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource coinSource;
    public AudioClip coinSound;
    
    private void Awake() // Singleton (instance kullanarak farklı scriptlerde erişebiliyorum), ayrıca SoundManager'dan sadece bir tane olmasını sağlıyor
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
}
