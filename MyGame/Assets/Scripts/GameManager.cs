using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerMovement playerMovement;
    public BackgroundController backgroundController;
    public EnemyController enemyController;
    public CoinController coinController;
    public BirdController birdController;
    public Score Score;
    
    public bool isGameOver;
    
    public float gameSpeed = 1f;
    public float accelerationRate;
    
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject StartPanel;
    
    public TextMeshProUGUI yourScore;
    public TextMeshProUGUI highScoresText;
    public TextMeshProUGUI score;
    
    public Animator characterAnimator;
    public GameObject character;

    private void Awake() // Singleton (instance kullanarak farklı scriptlerde erişebiliyorum), ayrıca GameManager'dan sadece bir tane olmasını sağlıyor
    {
        GameOverPanel.SetActive(false);
        characterAnimator = character.GetComponent<Animator>();
        playerMovement = character.GetComponent<PlayerMovement>();
        
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        MusicManager.instance.gameSource.PlayOneShot(MusicManager.instance.gameMusic); // Game Music ekledim
        StartPanel.SetActive(true);

        playerMovement.canMove = false;
        characterAnimator.enabled = false;
        backgroundController.scrollingBackground.enabled = false;
        coinController.coinSpawn.enabled = false;
        enemyController.enemySpawn.enabled = false;
        birdController.birdSpawn.enabled = false;
    }

    void Update()
    {
        if (!isGameOver && !isGameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                QuitGame();
            }
        }

        // Add game start check
        if (!isGameOver && !isGameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            StartToPlay();
        }

        if (!isGameOver && isGameStarted)
        {
            gameSpeed += accelerationRate * Time.deltaTime; // Oyunun hızı zamanla artıyor
        }
    }
    
    public void OnGameOver()
    {
        MusicManager.instance.gameSource2.Stop(); // Game Over olunca müziği durdurdum
        
        enemyController.StopSpawnEnemy();
        coinController.StopSpawnCoin();
        birdController.StopSpawnBird();
        
        enemyController.DeactivateExistingEnemies();
        coinController.DeactivateExistingCoins();
        birdController.DeactivateExistingBird();
        
        isGameOver = true;
        isGameStarted = false;
        
        GameOverPanel.SetActive(true);
        
        Score.CoinCountText.gameObject.SetActive(false);

        YourScore();
        
        ScoreManager.instance.SaveHighScore(Score.coinCount); // Skorları kaydediyorum

        ShowHighScores();
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            QuitGame();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void YourScore()
    {
        yourScore.text = "Your Score: " + Score.coinCount;
    }
    
    public void ShowHighScores()
    {
        List<int> highScores = ScoreManager.instance.GetHighScores();

        string highScoresText = "Top 3 Scores" + "\n****************\n";

        for (int i = 0; i < highScores.Count; i++)
        {
            highScoresText += (i + 1) + ". " + highScores[i] + "\n";
        }

        this.highScoresText.text = highScoresText; // highScoresText değişkeni dışarıdaki highScoresText bileşenini temsil ediyor.
    }

    private bool isGameStarted;

    public void StartToPlay()
    {
        StartPanel.SetActive(false);

        score.gameObject.SetActive(true);
        playerMovement.canMove = true;
        characterAnimator.enabled = true;
        backgroundController.scrollingBackground.enabled = true;
        coinController.coinSpawn.enabled = true;
        enemyController.enemySpawn.enabled = true;

        birdController.birdSpawn.enabled = false;
        
        // Set the game as started
        isGameStarted = true;
    }
    
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
