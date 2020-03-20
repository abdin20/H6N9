using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customization : MonoBehaviour
{
    //variables
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    private int _characterCount = 2;
    public int weaponCount;
    private int _currentCharacterCount;
    private int _currentWeaponCount;
    public GameObject Player;
    public AnimatorOverrideController CharacterAnimator;

    public Sprite LightBandit;
    public Sprite HeavyBandit;
    public Sprite Sword;
    public Sprite Sword2;
    public Sprite Sword3;   

    public Image Characters;
    public Image Weapons;

    void Awake() //ensure game starts unpaused
    {
        Resume();
        _currentCharacterCount = 1; //sets default character
        _currentWeaponCount = 1; //sets default weapon
    }

    void Update()
    {
        //overlay pops up if escape button is pressed
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
        //resuming game
        pauseMenuUI.SetActive(false);
        //time is normal
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        //pausing game
        pauseMenuUI.SetActive(true);
        //time stops
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ChangeCharacterLeft()
    {
        if(_currentCharacterCount != 1) //turning left on the wheel
        {
            _currentCharacterCount--; //turn left
            instantiateCharacter();
        }
        else
        {
            //rollover case
            _currentCharacterCount = _characterCount;
            instantiateCharacter();
        }

    }

    public void ChangeCharacterRight()
    {
        if (_currentCharacterCount != _characterCount)
        {
            _currentCharacterCount++; //turning right on the wheel
            instantiateCharacter();
        }
        else
        {
            //rollover case
            _currentCharacterCount = 1;
            instantiateCharacter();
        }
    }

    public void ChangeWeaponLeft()
    {
        if (_currentWeaponCount != 1)
        {
            _currentWeaponCount--; //turning left on wheel
            instantiateWeapon();
        }
        else
        {
            //rollover
            _currentWeaponCount = weaponCount;
            instantiateWeapon();
        }
    }

    public void ChangeWeaponRight()
    {
        if (_currentWeaponCount != weaponCount)
        {
            _currentWeaponCount++; //turning right on wheel
            instantiateWeapon();
        }
        else
        {
            //rollover
            _currentWeaponCount = 1;
            instantiateWeapon();
        }
    }

    void instantiateCharacter()
    {
        if (_currentCharacterCount == 1)
        {
            Characters.sprite = LightBandit; //sets character in overlay
            CreateCharacter("light");
        }
        else if(_currentCharacterCount == 2)
        {
            Characters.sprite = HeavyBandit; //sets character in overlay
            CreateCharacter("heavy");
        }
    }

    void instantiateWeapon()
    {
        //sets sword in overlay
        if (_currentWeaponCount == 1)
        {
            Weapons.sprite = Sword;
            //SetWeapon(1);
        }
        else if(_currentWeaponCount == 2)
        {
            Weapons.sprite = Sword2;
            //SetWeapon(2);
        }
        else if(_currentWeaponCount == 3)
        {
            Weapons.sprite = Sword3;
            //SetWeapon(3);
        }

        //SetWeapon coming in phase 3
    }
    
    public void CreateCharacter(string name)
    {
        //changing character appearance
        if (name == "heavy")
        {
            Player.GetComponent<SpriteRenderer>().color = Color.blue; //second player
            
        } else if (name == "light")
        {
            Player.GetComponent<SpriteRenderer>().color = Color.white; //default player
        }
    }

}