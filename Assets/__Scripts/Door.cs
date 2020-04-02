using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public GameObject player;
    private Rigidbody2D _doorRigidBody;

    void Start()
    {   
        //acquire the rigidbody
        _doorRigidBody = GetComponent<Rigidbody2D>();
    }

  
    void OnCollisionEnter2D(Collision2D col)
    {   
        //if the player collides and has a key
        if (col.gameObject.tag == "Player" && (player.GetComponent<Player>().key))
        {
            Destroy(this.gameObject); //destroy the door
        }
    }
}
