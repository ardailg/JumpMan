using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public const string HighScoreKeyPrefix = "HighScore_";
    public const int MaxHighScores = 3;

    public void SaveHighScore(int score)
    {
        List<int> highScores = GetHighScores();
        
        highScores.Add(score);
        // Listeyi sıralıyorum
        highScores.Sort((a, b) => b.CompareTo(a));
        highScores = highScores.GetRange(0, Mathf.Min(highScores.Count, MaxHighScores));

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
