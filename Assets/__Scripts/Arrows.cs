using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    public GameObject Arrow;
    public GameObject Arrow2;
    public float speed = 0.01f;
    public int direction = 1;
    // Start is called before the first frame update
 
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            OnMouseClick();
        }
        if (Arrow2 != null)
        {
            Arrow2.transform.position = Arrow2.transform.position + new Vector3(speed * direction, 0, 0);
        }

    }
    public void OnMouseClick()
    {
        //spawn arrows
        //check location
        if (Arrow2 == null)
        {
            Arrow2 = Instantiate(Arrow, new Vector3(transform.position.x,transform.position.y + 0.8f , 0), Quaternion.identity);
            Invoke("arrowDelay", 1f);
            if (GetComponent<SpriteRenderer>().flipX == true)
            {
                direction = 1;
                Arrow2.transform.Rotate(new Vector3(0, 0, 0));
            }
            else
            {
                direction = -1;
                Arrow2.transform.Rotate(new Vector3(0, 180, 0));
            }
        }
        else
        {

        }

    }
    public void arrowDelay()
    {
        Debug.Log("yo");
        Destroy(Arrow2);
    }
}
