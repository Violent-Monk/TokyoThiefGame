using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    GameObject pauseMenuUI;
    GameObject controlsMenuUI;

    private AudioSource[] allAudioSources;

    private void Start()
    {
        pauseMenuUI = transform.GetChild(0).gameObject;
        controlsMenuUI = transform.GetChild(1).gameObject;
        allAudioSources = FindObjectsOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && FindObjectOfType<GameManager>().gameHasEnded == false)
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Play();
        }
        controlsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Pause();
        }
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
