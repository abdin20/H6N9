using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    [SerializeField] float      m_speed = 1.0f;
    [SerializeField] float      m_jumpForce = 2.0f;

    private Animator            animator;
    private Rigidbody2D         playerRigidBody;

    public float health = 2;

    public GameObject shield;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
      

        // Handle input
        float inputX = Input.GetAxis("Horizontal");

        // flip the sprite if the player inputs another direction
        if (inputX > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (inputX < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }


        // Move
        playerRigidBody.velocity = new Vector2(inputX * m_speed, playerRigidBody.velocity.y);

        

        //Animations
        animator.SetInteger("AnimState", 0);
   

        //Jump if player hits space
        if (Input.GetKeyDown("space") && playerRigidBody.velocity.y==0) {
       
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, m_jumpForce);

        }  //Run
        else if (Mathf.Abs(inputX) > Mathf.Epsilon)
        {
            animator.SetInteger("AnimState", 2);
        }
        else  //if no other animation  then the player is idling
        {
           animator.SetInteger("AnimState", 0);
        }
            
    }

   
    //collision event
    private void OnTriggerEnter2D(Collider2D other)
    {   
        //if hit by enemy lower health and use hurt animation
        if(other.gameObject.tag == "enemy" )
        {
              //if player does not have shield 
            if (shield == null)
            {
                Debug.Log("hit by enemy");
                animator.SetTrigger("Hurt");
                health += -1;

                if (health <= 0)
                {
                    Application.LoadLevel(Application.loadedLevel);
                }

            }
            else //he has shield so no health is lost but we destroy the shield
            {
                Destroy(shield);
            }

        }

        //if if hit flag we win
        if (other.gameObject.tag == "Respawn")
        {
                
         Application.LoadLevel(Application.loadedLevel);
    
        }

    }
}
