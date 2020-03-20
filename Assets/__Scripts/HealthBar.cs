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




    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        setCountText();
    }
    public void setCountText()
    {
        playerHealth = (player.GetComponent<Player>().health).ToString();
        Debug.Log(playerHealth);
        healthText.text = "Health left: " + playerHealth;

    }
}