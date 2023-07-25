using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public EnemyController enemyController;
    public CoinController coinController;

    public bool isGameOver;
    
    public float gameSpeed = 1f;
    public float accelerationRate;

    [SerializeField] private GameObject UIManager;
    
    public TextMeshProUGUI yourScore;
    public TextMeshProUGUI highScoresText;

    public Score Score;
    public ScoreManager ScoreManager;
    
    private void Awake() // Singleton (instance kullanarak farklı scriptlerde erişebiliyorum), ayrıca GameManager'dan sadece bir tane olmasını sağlıyor
    {
        UIManager.SetActive(false);
        
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        if (!isGameOver)
        {
            gameSpeed += accelerationRate * Time.deltaTime; // Oyunun hızı zamanla artıyor
        }
        
    }
    
    public void OnGameOver()
    {
        enemyController.StopSpawnEnemy();
        coinController.StopSpawnCoin();
        
        enemyController.DeactivateExistingEnemies();
        coinController.DeactivateExistingCoins();
        
        isGameOver = true;
        
        UIManager.SetActive(true);
        
        Score.CoinCountText.gameObject.SetActive(false);
        
        YourScore();
        
        ScoreManager.SaveHighScore(Score.coinCount); // Skorları kaydediyorum

        ShowHighScores();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void YourScore()
    {
        yourScore.text = "Your Score: " + Score.coinCount;
    }
    
    public void ShowHighScores()
    {
        List<int> highScores = ScoreManager.GetHighScores();

        string highScoresText = "Top 3 Scores" + "\n";

        for (int i = 0; i < highScores.Count; i++)
        {
            highScoresText += (i + 1) + ". " + highScores[i] + "\n";
        }

        this.highScoresText.text = highScoresText; // highScoresText değişkeni dışarıdaki highScoresText bileşenini temsil ediyor.
    }
}
