using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    GameObject gameOverMenuUI;

    private void Start()
    {
        gameOverMenuUI = transform.GetChild(0).gameObject;   
    }

    public void ResetGame()
    {
        gameOverMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        FindObjectOfType<GameManager>().Restart();
    }

    public void Pause()
    {
        gameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }


}

