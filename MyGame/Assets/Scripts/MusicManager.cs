using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    
    public AudioSource gameSource;
    public AudioClip gameMusic;
    
    private void Awake() // Singleton (instance kullanarak farklı scriptlerde erişebiliyorum), ayrıca SoundManager'dan sadece bir tane olmasını sağlıyor
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
