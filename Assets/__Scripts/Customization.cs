using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customization : MonoBehaviour
{
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

    void Awake()
    {
        Resume();
        _currentCharacterCount = 1;
        _currentWeaponCount = 1;
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
        if(_currentCharacterCount != 1)
        {
            _currentCharacterCount--;
            instantiateCharacter();
        }
        else
        {
            _currentCharacterCount = _characterCount;
            instantiateCharacter();
        }

    }

    public void ChangeCharacterRight()
    {
        if (_currentCharacterCount != _characterCount)
        {
            _currentCharacterCount++;
            instantiateCharacter();
        }
        else
        {
            _currentCharacterCount = 1;
            instantiateCharacter();
        }
    }

    public void ChangeWeaponLeft()
    {
        if (_currentWeaponCount != 1)
        {
            _currentWeaponCount--;
            instantiateWeapon();
        }
        else
        {
            _currentWeaponCount = weaponCount;
            instantiateWeapon();
        }
    }

    public void ChangeWeaponRight()
    {
        if (_currentWeaponCount != weaponCount)
        {
            _currentWeaponCount++;
            instantiateWeapon();
        }
        else
        {
            _currentWeaponCount = 1;
            instantiateWeapon();
        }
    }

    void instantiateCharacter()
    {
        if (_currentCharacterCount == 1)
        {
            Characters.sprite = LightBandit;
        }
        else if(_currentCharacterCount == 2)
        {
            Characters.sprite = HeavyBandit;
            CreateCharacter("heavy");
        }
    }

    void instantiateWeapon()
    {
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
    }
    
    public void CreateCharacter(string name)
    {
        if (name == "heavy")
        {

            GameObject Character = new GameObject();
            Character.name = "Player";
            Character.AddComponent<Rigidbody2D>();
            Character.AddComponent<SpriteRenderer>();
            //Character.AddComponent<Player>();
            Character.AddComponent<Animation>();
            Character.GetComponent<SpriteRenderer>().sprite = HeavyBandit;

            Character.transform.position = new Vector3(1f, -8f, 10f);


            //Animator anim = Player.GetComponent<Animator>();
            Player.GetComponent<SpriteRenderer>().color = Color.blue;
            //Player.GetComponent<Animator>().runtimeAnimatorController = CharacterAnimator;
            //anim.runtimeAnimatorController = Resources.Load("HeavyBandit_AnimController") as RuntimeAnimatorController;

        }
    }

    //button.GetComponent<Image>().sprite = Image1;

}


//someone presses escape
//overlay menu
//CHOICES(Change hair, change shirt, change weapon, close menu)
//if change hair, take input of left click or right click

 //seperate classes for weapons?