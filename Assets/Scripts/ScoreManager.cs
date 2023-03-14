using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text highScoreText;

    float score;
    float highScore;
    bool scoreCalculateStarted = true;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetFloat("highScore");
        if (highScoreText)
        {
            highScoreText.text = "HighScore: " +highScore.ToString("#.00");
        }
        updateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreCalculateStarted)
        {
            score += Time.deltaTime;
            updateScoreText();
        }
    }
    private void updateScoreText()
    {
        if (scoreText)
        {
            scoreText.text = score.ToString("#.00") + " Seconds";
        }
    }

    public void saveScore()
    {
        scoreCalculateStarted = false;
        if (highScore < score)
        {
            PlayerPrefs.SetFloat("highScore", score);
        }
    }
    private void OnDisable()
    {
        saveScore();
    }
}
