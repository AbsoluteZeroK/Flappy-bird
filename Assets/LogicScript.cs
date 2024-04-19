using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    //SeralizeField required to use text mesh PRO
    [SerializeField] TextMeshProUGUI HighScoreText;

    private void Start()
    {
        //We want to show the saved HighScore when we start game, if not it will always show 0
        updateHighScore();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();

        // Making it dynamic, If player beats current highscore it will have the int as highscore, & update will the update the displayed highscore from the sav file.
        checkHighScore();
        updateHighScore();
    }

    public void checkHighScore()
    {
        ////PlayerPrefs allow us to save a value. Makes a file on computer to save the value.
        if (playerScore > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
        }
    }

    [ContextMenu("Increase HighScore")]
    public void updateHighScore()
    {
        HighScoreText.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
