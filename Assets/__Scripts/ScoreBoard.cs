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

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        setScoreText();
    }
    public void setScoreText()
    {
        playerScore = (player.GetComponent<Player>().score).ToString(); //getting player health
        scoreText.text = "Score: " + playerScore; //setting text of player health

    }
}