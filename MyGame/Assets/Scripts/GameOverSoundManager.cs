using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSoundManager : MonoBehaviour
{
    public static GameOverSoundManager instance;
    
    public AudioSource gameOverSource;
    public AudioClip gameOverSound;
    
    private void Awake() // Singleton (instance kullanarak farklı scriptlerde erişebiliyorum), ayrıca SoundManager'dan sadece bir tane olmasını sağlıyor
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
