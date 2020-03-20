using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBetweenAttacks;
    public float startTimeAttack;

    public Transform attackPosition;
    public float attackRange;
    public int damage;

    private Animator animator;

    public LayerMask enemies;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
                animator.SetTrigger("Attack");

                //get the enemies in range of attack and loop through it
                Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(attackPosition.position,attackRange,enemies);
                for (int i = 0; i < enemiesInRange.Length; i++)
                {
                    enemiesInRange[i].GetComponent<Enemy>().TakeDamage(damage);
                }   
            }
            
        

      
    }

    void onDrawDizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }
}
