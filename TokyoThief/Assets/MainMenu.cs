using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //loads next scene
    }
    public void QuitGame()
    {
        Debug.Log("Quit!"); //Console will tell us this script is working
        Application.Quit(); //Closes game
    }
}
