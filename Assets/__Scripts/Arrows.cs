using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    public GameObject Arrow;
    public GameObject Arrow2;
    public float speed = 0.05f;
    public int direction = 1;
    public Rigidbody2D arrow_vertForce;

    // Update is called once per frame
    public virtual void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            OnMouseClick();
        }
        if (Arrow2 != null)
        {
            //do nothing if arrow already present
        }

    }
    public virtual void OnMouseClick()
    {
        //spawn arrows
        //check location
        if (Arrow2 == null) //only create the arrows when 1 isnt active
        {
           if (GetComponent<SpriteRenderer>().flipX == true) //this means charactor is facing right
            {
                Arrow2 = Instantiate(Arrow, new Vector3(transform.position.x + 0.7f,transform.position.y + 0.8f , 0), Quaternion.identity); //create the arrow on mouse click
            }
            else
            {
                Arrow2 = Instantiate(Arrow, new Vector3(transform.position.x - 0.7f,transform.position.y + 0.8f , 0), Quaternion.identity); //create the arrow on mouse click
            }
            
            arrow_vertForce = Arrow2.GetComponent<Rigidbody2D>();
            //arrow_vertForce.AddForce(new Vector3(3f,3f,0f),ForceMode.Impulse);
            Invoke("arrowDelay", 2f);
            if (GetComponent<SpriteRenderer>().flipX == true) //this means charactor is facing right
            {
                direction = 1; //set to normal direction
                Arrow2.transform.Rotate(new Vector3(0, 0, 0)); //set to normal rotation
                arrow_vertForce.AddForce(new Vector3(10f*direction,3f),ForceMode2D.Impulse);
            }
            else
            {
                direction = -1; //set to reverse direction
                Arrow2.transform.Rotate(new Vector3(0, 180, 0)); //rotate the prefab
                arrow_vertForce.AddForce(new Vector3(10f*direction,3f,0f),ForceMode2D.Impulse);
            }
        }
        else
        { //this runs while and arrow is already active therefore doing nothing until the other arrow is destoryed

        }

    }
    public void arrowDelay()
    {
        Destroy(Arrow2); //after the invoke delay, destory the arrow
    }
    
}
