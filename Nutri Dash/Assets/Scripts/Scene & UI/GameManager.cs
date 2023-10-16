using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager instance;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private TextMeshProUGUI lifeNumber;
    [SerializeField] private TextMeshProUGUI totalScoreText;
    [SerializeField] private TextMeshProUGUI totalScoreNumber;
    [SerializeField] private TextMeshProUGUI gameOverScoreText;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject youAreFullText;

    [Header("Scores")]
    private int playerScore = 0;
    private int ongScore = 0;
    private int totalScore = 0;
    private int currentLife;
    private int maxLife = 3;
    private int gameOverScore = 0;

    [Header("Audio")]
    [SerializeField] private AudioSource collectSound;
    [SerializeField] private AudioSource carCrash;
    [SerializeField] private AudioSource backgroundGameplay;
    [SerializeField] private AudioSource backgroundGameOver;

    void Awake()
    {
        instance = this;
        currentLife = maxLife;
        UpdatePlayerLife(currentLife);
    }



    public void PlayerScore()
    {
        collectSound.Play();
        playerScore += 5;
        if (playerScore >= 30)
        {
            playerScore = 30;
            youAreFullText.gameObject.SetActive(true);
        }
        UpdatePlayerScore(playerScore);
    }

    public void LoseScore()
    {
        playerScore -= 3;
        if (playerScore <= 0)
        {
            playerScore = 0;
        }

        if (playerScore < 30)
        {
            youAreFullText.gameObject.SetActive(false);
        }
        UpdatePlayerScore(playerScore);
    }

    public void GeralScore()
    {
        totalScore = ongScore + playerScore;
        ongScore = totalScore;
        playerScore = 0;
        youAreFullText.gameObject.SetActive(false);
        UpdateTotalScore(totalScore);
        UpdatePlayerScore(playerScore);
    }

    public void PlayerLife()
    {
        currentLife--;
        carCrash.Play();
        UpdatePlayerLife(currentLife);

        if (currentLife <= 0)
        {
            gameOverScore = totalScore;
            Time.timeScale = 0;
            gameOverMenu.SetActive(true);
            backgroundGameplay.Pause();
            backgroundGameOver.Play();
            scoreText.gameObject.SetActive(false);
            lifeText.gameObject.SetActive(false);
            lifeNumber.gameObject.SetActive(false);
            totalScoreText.gameObject.SetActive(false);
            totalScoreNumber.gameObject.SetActive(false);

            UpdateGameOverScore(gameOverScore);
        }
    }


    //Updates
    public void UpdatePlayerLife(int currentLife)
    {
        lifeNumber.text = currentLife.ToString();
    }

    public void UpdatePlayerScore(int playerScore)
    {
        scoreText.text = playerScore.ToString();
    }

    public void UpdateTotalScore(int totalScore)
    {
        totalScoreNumber.text = totalScore.ToString();
    }

    public void UpdateGameOverScore(int gameOverScore)
    {
        gameOverScoreText.text = gameOverScore.ToString();
    }
}
