using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customization : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Awake()
    {
        Resume();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else { 
                Pause();
            }
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    /*void OpenMenu()
    {

    }

    void CloseMenu()
    {

    }

    void ChangeCharacter()
    {

    }

    void ChangeWeapon()
    {

    }*/

}


//someone presses escape
//overlay menu
//CHOICES(Change hair, change shirt, change weapon, close menu)
//if change hair, take input of left click or right click

 //seperate classes for weapons?