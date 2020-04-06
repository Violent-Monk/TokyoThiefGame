using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    GameObject startScreen;
    GameObject mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        startScreen = GameObject.Find("StartScreen");
        mainMenu = GameObject.Find("MainMenuCanvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            mainMenu.GetComponent<Canvas>().sortingOrder = 1;
            startScreen.SetActive(false);           
        }
    }
}
