using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUIController : MonoBehaviour
{
    private GameObject gameOverMenuUI;

    private void Start()
    {
        Transform gameOverUITransform = transform.Find("GameOverMenu");
        if (gameOverUITransform != null)
        {
            gameOverMenuUI = gameOverUITransform.gameObject;
        }
        else
        {
            Debug.LogError("Could not find the GameOverUI GameObject!");
        }
    }
    public void RestartGame()
    {
        UnfreezeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void HomeButton()
    {
        UnfreezeGame();
        SceneManager.LoadScene("MainMenu");
    }
    public void UnfreezeGame() {
        hideGameOverUI();
        Time.timeScale = 1f;
    }

    public void showGameOverUI()
    {
        gameOverMenuUI.SetActive(true);
    }
    public void hideGameOverUI()
    {
        gameOverMenuUI.SetActive(false);
    }
}
