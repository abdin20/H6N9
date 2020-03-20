using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Text healthText;
    public GameObject player;




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
        Debug.Log("in count");
        Debug.Log(player.GetComponent<Player>().health);
        healthText.text = "Health left:" + player.GetComponent<Player>().health;

    }
}