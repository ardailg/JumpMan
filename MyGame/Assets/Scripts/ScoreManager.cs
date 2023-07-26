using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    
    public const string HighScoreKeyPrefix = "HighScore_";
    public const int MaxHighScores = 3;

    private void Awake() // Singleton (instance kullanarak farklı scriptlerde erişebiliyorum), ayrıca GameManager'dan sadece bir tane olmasını sağlıyor
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    public void SaveHighScore(int score)
    {
        List<int> highScores = GetHighScores();
        
        highScores.Add(score);
        // Listeyi sıralıyorum
        highScores.Sort((a, b) => b.CompareTo(a));
        highScores = highScores.Distinct().Take(MaxHighScores).ToList();

        for (int i = 0; i < highScores.Count; i++)
        {
            string key = HighScoreKeyPrefix + (i + 1);
            PlayerPrefs.SetInt(key, highScores[i]);
        }
    }

    public List<int> GetHighScores()
    {
        List<int> highScores = new List<int>();

        for (int i = 1; i <= MaxHighScores; i++)
        {
            string key = HighScoreKeyPrefix + i;
            int highScore = PlayerPrefs.GetInt(key, 0);
            highScores.Add(highScore);
        }

        return highScores;
    }
}
