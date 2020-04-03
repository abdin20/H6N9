using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Text healthText;
    public GameObject player;
    public string playerHealth;

    
    void Start()
    {
        GameObject player = GameObject.Find("Player"); //find the player object
    }


    void Update()
    {
        setCountText(); //run the method every frame
    }
    public void setCountText()
    {
        playerHealth = (player.GetComponent<Player>().newHealth).ToString(); //getting player health
        healthText.text = "Health left: " + playerHealth; //setting text of player health

    }
}