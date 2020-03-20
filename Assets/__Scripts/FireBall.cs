using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Arrows
{
    //collision event
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if hit by enemy lower health and use hurt animation
        if (other.gameObject.tag == "enemy")
        {
            //enemy takes damage
            other.gameObject.GetComponent<Enemy>().TakeDamage(1);
        }
    }


    public override void Update()
    {
       //phase 3

    }


    public override void OnMouseClick()
    {
        
        //phase 3
    }
}
