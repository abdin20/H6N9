using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : Enemy
{
    public float yRange=3f;
    private float _yMax;
    private float _yMin;
    private float _direction;

    public float speed;


    public GameObject preFabFeather;
    private GameObject _feather;

    public float thrust;

    private float _currentTime;
    private float _lastTime;
        


    // Start is called before the first frame update
    void Start()
    {
        //set the max heights
        _yMax = transform.position.y;
        _yMin = transform.position.y - yRange;
    }

    // Update is called once per frame
    void Update()
    {   
        //every frame move and attack
        Move();
        Attack();
    }

    //applies damage to enemy
    public override void TakeDamage(int damage)
    {

        health += -damage; //takes damage

        if (health <= 0) //checks if player died
        {
            Destroy(this.gameObject);
        }
    }


      public override void Move()
    {

        //get the current position
        Vector2 pos = transform.position;
  

        //check if we have to start adding or subtracting from the y axis
        if (pos.y >= _yMax)
        {
            _direction = -1f;
        }
        else if (pos.y <= _yMin)
        {
            _direction = 1f;
        }

    
        //set the new y position
        transform.position = new Vector2(pos.x, (pos.y + (_direction * speed)));

    }

    void Attack()
    {

        //get current time
        _currentTime = Time.time;

        //only run attack if feather isnt already in game and 3 seconds passed
        if (_feather == null   && (_currentTime - _lastTime) >=3f)
        {
            //initialize the feather projectile
            _feather = Instantiate(preFabFeather);

            _feather.transform.position = new Vector2(transform.position.x + 0.3f, transform.position.y);

            //add force to the feather to shoot it 
            _feather.GetComponent<Rigidbody2D>().velocity = new Vector2(-thrust, 0f);

            //reset time
            _lastTime = Time.time;

        }

        //after the feather is made, destory it after 4 seconds
        if(_feather!=null &&  (_currentTime - _lastTime) >= 4f){
            Destroy(_feather);
            _feather = null;
            _lastTime = Time.time;
        }

     

    }
}
