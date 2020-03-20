using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float timeBetweenAttacks;
    private float currentTime;
    private float lastTime;

    public Transform attackPosition;
    public float attackRange;
    public int damage;

    private Animator animator;

    public LayerMask enemies;



   public Collider2D[] enemiesInRange;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentTime = Time.time;
        lastTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

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
            currentTime = Time.time;
            //if the time elapsed is greater that the interval set we let the animation go through and attack
            if ( (currentTime - lastTime) >= timeBetweenAttacks)
            {   
                //reset time
                lastTime = Time.time;
                //change animtation to attack
                animator.SetTrigger("Attack");

                //get the enemies in range of attack and add to array
                enemiesInRange = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, enemies);
                Invoke("DamageEnemy", 0.5f); //attack after a delay since we need to wait for sword animation to go through
            }
            }
             
    }

    
    //damage enemeies
    void DamageEnemy()
    {
        Debug.Log("hit enemy with sword");
        for (int i = 0; i < enemiesInRange.Length; i++)
        {
            enemiesInRange[i].GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
