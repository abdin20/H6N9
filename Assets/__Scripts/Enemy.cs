using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health=10;

    //applies damage to enemy
    public void TakeDamage(int damage) {

        health += -damage; //takes damage

        if (health <= 0) //checks if player died
        {
            Destroy(this.gameObject);
        }
    }
}
