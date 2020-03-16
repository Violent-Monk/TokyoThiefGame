using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;
    public float restartDelay = 1f;
    GameOverMenu menu;

    private void Start()
    {
        menu = GetComponent<GameOverMenu>();
    }

    public void EndGame(bool delay)
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            if (delay)
            {
                Invoke("GameOver", restartDelay);
            }
            else
            {
                Invoke("GameOver", 0f);
            }
            
        }
    }

    void GameOver()
    {
        menu.Pause();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}