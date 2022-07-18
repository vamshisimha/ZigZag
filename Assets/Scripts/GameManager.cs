using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public bool isStarted;
    public int score;
    public Text scoreText;
    public Text highScoreText;
    public Text hintText;


    private void Awake()
    {
        highScoreText.text = "HighScore: " + GetHighScore();
    }

    private void Update()
    {
       // if (Input.GetKeyDown(KeyCode.Return))
        {
            isStarted = true;
            FindObjectOfType<Road>().SartBuilding();
            Destroy(hintText);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !isStarted)
        {
            Application.Quit();
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Score: " + score;

        if(score > GetHighScore())
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "HighScore: " + score;
        }
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }
}
