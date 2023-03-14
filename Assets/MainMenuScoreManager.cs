using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScoreManager : MonoBehaviour
{

    [SerializeField]
    private Text highScoreText;
    float highScore = 0;
    // Start is called before the first frame update

    private void Start()
    {
        highScore = PlayerPrefs.GetFloat("highScore");
        highScoreText.text = "HighScore " + highScore.ToString("#.00") + " Seconds";
    }
}
