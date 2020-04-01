using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float health;
   

   

    //applies damage to enemy
    public virtual void TakeDamage(int damage) { }

    public virtual void Move() { }
    //aaaa
    
}
