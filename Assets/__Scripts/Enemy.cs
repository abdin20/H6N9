using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float health;
    public GameObject player; //every enemy has refernce to the player
   

   

    //applies damage to enemy
    public virtual void TakeDamage(int damage) { }

    //every enemy moves differently
    public virtual void Move() { }
  
    
}
