using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Enemy
{

    private Animator _animator;
    private Rigidbody2D _dogRigidBody;



    public float xRange = 3f;
    private float _xMax;
    private float _xMin;
    private float _direction;

    public float speed;
    public float range;

    public GameObject preFabFireBall;
    private GameObject _fireBall;

    public float thrust;



    void Start()
    {   
        //get components of object
        _animator = GetComponent<Animator>();
        _dogRigidBody = GetComponent<Rigidbody2D>();

        _xMax = transform.position.x;
        _xMin = transform.position.x - xRange;
    }

    // Update is called once per frame
    void Update()
    {   
        //move and attack every update
        Move();
    }

    //applies damage to enemy
    public override void TakeDamage(int damage)
    {

        health += -damage; //takes damage

        if (health <= 0) //checks if player died
        {
            Destroy(this.gameObject);
            player.GetComponent<Player>().score += 2; //add score to player
        }
    }


    public override void Move()
    {

        //get the current position
        Vector2 pos = transform.position;


        //check if we have to start adding or subtracting from the x axis
        if (pos.x >= _xMax)
        {
            _direction = -1f;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (pos.x <= _xMin)
        {
            _direction = 1f;
            GetComponent<SpriteRenderer>().flipX = true;
        }


        //set the new x position
        transform.position = new Vector2((pos.x + (_direction * speed)), pos.y );

    }

    //collider
    private void OnTriggerEnter2D(Collider2D other)
    {   
        //if dog collides with player
        if (other.gameObject.tag == "Player")
        {   
            //animation for exploding
            //then explode 
            _animator.Play("DogExplode");

            //set speed to so movement stops
            speed = 0;
            Invoke("Attack", 3);
        }

    }

    public void Attack()
    {
        //intiate 3 fireballs for self destruct
        GameObject fireBall1= Instantiate(preFabFireBall);
        GameObject fireBall2 = Instantiate(preFabFireBall);
        GameObject fireBall3 = Instantiate(preFabFireBall);

        //set positions and velocity to fireballs
        fireBall1.transform.position = new Vector2(transform.position.x + 0.8f, transform.position.y);
        //add force to the feather to shoot it 
        fireBall1.GetComponent<Rigidbody2D>().velocity = new Vector2(thrust, 0f);

        fireBall2.transform.position = new Vector2(transform.position.x - 0.8f, transform.position.y);
        //add force to the feather to shoot it 
        fireBall2.GetComponent<Rigidbody2D>().velocity = new Vector2(-thrust, 0f);

        fireBall3.transform.position = new Vector2(transform.position.x, transform.position.y+ 0.3f);
        //add force to the feather to shoot it 
        fireBall3.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,thrust);

        Destroy(this.gameObject);

    }
}
