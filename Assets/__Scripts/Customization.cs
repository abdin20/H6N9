using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customization : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    private int characterCount = 2;
    public int weaponCount;
    private int currentCharacterCount;
    private int currentWeaponCount;

    public Sprite LightBandit;
    public Sprite HeavyBandit;
    public Sprite Sword;
    public Sprite Sword2;
    public Sprite Sword3;   

    public Image Characters;
    public Image Weapons;

    void Awake()
    {
        Resume();
        currentCharacterCount = 1;
        currentWeaponCount = 1;
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

    public void Resume()
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

    public void ChangeCharacterLeft()
    {
        if(currentCharacterCount != 1)
        {
            currentCharacterCount--;
            instantiateCharacter();
        }
        else
        {
            currentCharacterCount = characterCount;
            instantiateCharacter();
        }

    }

    public void ChangeCharacterRight()
    {
        if (currentCharacterCount != characterCount)
        {
            currentCharacterCount++;
            instantiateCharacter();
        }
        else
        {
            currentCharacterCount = 1;
            instantiateCharacter();
        }
    }

    public void ChangeWeaponLeft()
    {
        if (currentWeaponCount != 1)
        {
            currentWeaponCount--;
            instantiateWeapon();
        }
        else
        {
            currentWeaponCount = weaponCount;
            instantiateWeapon();
        }
    }

    public void ChangeWeaponRight()
    {
        if (currentWeaponCount != weaponCount)
        {
            currentWeaponCount++;
            instantiateWeapon();
        }
        else
        {
            currentWeaponCount = 1;
            instantiateWeapon();
        }
    }

    void instantiateCharacter()
    {
        if (currentCharacterCount == 1)
        {
            Characters.sprite = LightBandit;
        }
        else if(currentCharacterCount == 2)
        {
            Characters.sprite = HeavyBandit;
        }
    }

    void instantiateWeapon()
    {
        if (currentWeaponCount == 1)
        {
            Weapons.sprite = Sword;
        }
        else if(currentWeaponCount == 2)
        {
            Weapons.sprite = Sword2;
        }
        else if(currentWeaponCount == 3)
        {
            Weapons.sprite = Sword3;
        }
    }
    

    //button.GetComponent<Image>().sprite = Image1;

}


//someone presses escape
//overlay menu
//CHOICES(Change hair, change shirt, change weapon, close menu)
//if change hair, take input of left click or right click

 //seperate classes for weapons?