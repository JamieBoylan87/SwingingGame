using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private int timer;
    public Text scoreText;
    public Text highscoreText;

    int score = 0;
    int highscore = 0;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString() + " SECONDS";
        highscoreText.text = "FASTEST: " + highscore.ToString();
        InvokeRepeating("AddPoint", 1, 1);
    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString() + " POINTS";
        if (highscore > score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }

    }

    
}
