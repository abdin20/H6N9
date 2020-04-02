using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public GameObject preFabEagle;
    public GameObject preFabDog;

    public GameObject player;
    public GameObject eagle;
    public Vector3 offset;

    public Vector2 eaglePos;
    public Vector2 playerPos;
    public Vector2 dogPos;

    // Start is called before the first frame update
    void Start()
    {   
        
        //instantiate enemies
        eagle= Instantiate(preFabEagle, eaglePos, Quaternion.identity);
        Instantiate(preFabDog, dogPos, Quaternion.identity);
            
        //set the offset of the camera only on the x axis
        offset = new Vector3(transform.position.x - player.transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {   
        
        //add the offset every frame so it follows the player
        transform.position = new Vector3(player.transform.position.x + offset.x, offset.y, transform.position.z);
    }
}
