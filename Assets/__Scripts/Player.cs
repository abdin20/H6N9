using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    [SerializeField] float      m_speed = 1.0f;
    [SerializeField] float      m_jumpForce = 2.0f;

    private Animator            animator;
    private Rigidbody2D         playerRigidBody;

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
        //Attack animation 
        if (Input.GetMouseButtonDown(0)) {
            animator.SetTrigger("Attack");
        }

        //Jump if player hits space
        else if (Input.GetKeyDown("space")) {
       
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
}
