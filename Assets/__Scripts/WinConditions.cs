using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinConditions : MonoBehaviour
{
    public Text winConditionsText;
    
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "LevelOneScene")
        {
            winConditionsText.text = "Victory Upgrades\nScore 5-9: Max HP +1 \nScore 10+: Max DMG -1";
        }
        else if (SceneManager.GetActiveScene().name == "LevelTwoScene")
        {
            winConditionsText.text = "Victory Upgrades\nScore 20-29: Max HP -1 \nScore 30+: Max DMG -1";
        }
        else
        {
            Debug.Log("Error writing win conditions");
        }
    }

}

//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//LEVEL 1: "Score 5-9: Max HP +1 \nScore 10+: Max DMG -1"
//LEVEL 2: "Score 20-29: Max HP -1 \nScore 30+: Max DMG -1"