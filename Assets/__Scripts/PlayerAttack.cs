using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float timeBetweenAttacks;
    private float _currentTime;
    private float _lastTime;

    public Transform attackPosition;
    public float attackRange;
    public static int damage = 3;
    public int newDamage;

    private Animator _animator;

    public LayerMask enemies;


   public Collider2D[] enemiesInRange;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _currentTime = Time.time;
        _lastTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        newDamage = damage;

        // Handle input
        float inputX = Input.GetAxis("Horizontal");

        // flip the hitbox if the player inputs another direction
        if (inputX < 0)
        {
            attackPosition.transform.position= new Vector3(transform.position.x -0.5f,attackPosition.transform.position.y,0);
        }
        else if (inputX > 0)
        {
            attackPosition.transform.position = new Vector3(transform.position.x + 0.5f, attackPosition.transform.position.y, 0);
        }

        //Attack animation 
        
        if (Input.GetMouseButtonDown(0))
            {

            //get current time
            _currentTime = Time.time;
            //if the time elapsed is greater that the interval set we let the animation go through and attack
            if ( (_currentTime - _lastTime) >= timeBetweenAttacks)
            {   
                //reset time
                _lastTime = Time.time;
                //change animtation to attack
                _animator.SetTrigger("Attack");

                //get the enemies in range of attack and add to array
                enemiesInRange = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, enemies);
                Invoke("DamageEnemy", 0.5f); //attack after a delay since we need to wait for sword animation to go through
            }
            }
             
    }

    
    //damage enemeies
    void DamageEnemy()
    {
        for (int i = 0; i < enemiesInRange.Length; i++)
        {
            enemiesInRange[i].GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
