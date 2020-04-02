using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelText : MonoBehaviour
{
    public Text levelText;
    public GameObject player;
    public string playerLevel;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player"); //find the player object
    }

    // Update is called once per frame
    void Update()
    {
        setLevelText(); //run the update every frame
    }
    public void setLevelText()
    {
        if(SceneManager.GetActiveScene().name == "LevelOneScene"){ //if scene one
            levelText.text = "Current Level: Level 1"; //set text to display level 1

        }
        else{
            levelText.text = "Current Level: Level 2"; //or display level 2
        }
        
    }
}