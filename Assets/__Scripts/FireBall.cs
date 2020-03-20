using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //collision event
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if hit by enemy lower health and use hurt animation
        if (other.gameObject.tag == "enemy")
        {
            Debug.Log("hit enemy with fireball");

            //enemy takes damage
            other.gameObject.GetComponent<Enemy>().TakeDamage(1);
        }
    }
}
