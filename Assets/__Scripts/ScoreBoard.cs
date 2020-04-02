using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreBoard : MonoBehaviour
{
    public Text scoreText;
    public GameObject player;
    public string playerScore;
    void Start()
    {
        GameObject player = GameObject.Find("Player"); //find the player object
    }

    void LateUpdate()
    {
        setScoreText(); //run the score method eachframe
    }
    public void setScoreText()
    {
        playerScore = (player.GetComponent<Player>().score).ToString(); //getting score
        scoreText.text = "Score: " + playerScore; //setting score

    }
}