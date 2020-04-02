using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    [SerializeField] float      m_speed = 1.0f;
    [SerializeField] float      m_jumpForce = 2.0f;

    private Animator            _animator;
    private Rigidbody2D         _playerRigidBody;

    public float health = 2;
    public int score = 0;

    public GameObject shield;

    // Use this for initialization
    void Start () {
        _animator = GetComponent<Animator>();
        _playerRigidBody = GetComponent<Rigidbody2D>();
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
        _playerRigidBody.velocity = new Vector2(inputX * m_speed, _playerRigidBody.velocity.y);

        

        //Animations
        _animator.SetInteger("AnimState", 0);
   

        //Jump if player hits space
        if (Input.GetKeyDown("space") && _playerRigidBody.velocity.y==0) {
       
            _playerRigidBody.velocity = new Vector2(_playerRigidBody.velocity.x, m_jumpForce);

        }  //Run
        else if (Mathf.Abs(inputX) > Mathf.Epsilon)
        {
            _animator.SetInteger("AnimState", 2);
        }
        else  //if no other animation  then the player is idling
        {
           _animator.SetInteger("AnimState", 0);
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
                _animator.SetTrigger("Hurt");
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
        if (other.gameObject.tag == "Coin"){
            score++;
            Destroy(other.gameObject);

        }

        //if if hit flag we win
        if (other.gameObject.tag == "Respawn")
        {
                
         Application.LoadLevel(Application.loadedLevel);
    
        }


        //if hit by enemy projectile lower health and use hurt animation
        if (other.gameObject.tag == "projectile")
        {   
            //destory the projectile immediately
            Destroy(other.gameObject);
            //if player does not have shield 
            if (shield == null)
            {
                Debug.Log("hit by enemy");
                _animator.SetTrigger("Hurt");
                health += -1;

            
                 //if less than 0 health restart game
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

    }


    void OnCollisionEnter2D(Collision2D col)
    {   
        //if its a projectile 
        if (col.gameObject.tag == "projectile")
        {

            //destory the projectile immediately
            Destroy(col.gameObject);
            //if player does not have shield lower health
            if (shield == null)
            {
                Debug.Log("hit by projectile");
                _animator.SetTrigger("Hurt"); //set animation to hurt
                health += -1;                 //lower health


                //if less than 0 health restart game
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
    }
}
