using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DamageBar : MonoBehaviour
{
    public Text damageText;
    public GameObject player;
    private string playerDamage;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player"); //find the player object
    }

    void Update()
    {
        playerDamage = (player.GetComponent<PlayerAttack>().newDamage).ToString(); //getting player health
        damageText.text = "Damage: " + playerDamage; //setting text of player health
    }
}
