using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    public GameObject Arrow;
    public GameObject Arrow2;
    public float speed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)){
            OnMouseClick();
        }
        if(Arrow2 != null){
        Arrow2.transform.position =  Arrow2.transform.position  + new Vector3(speed,0,0);
        }
            
    }
    public void OnMouseClick(){
        //spawn arrows
            //check location
           Arrow2 = Instantiate(Arrow,new Vector3(0,1,0),Quaternion.identity);
            Invoke("arrowDelay",1f);
    }
    public void arrowDelay(){
        Debug.Log("yo");
        Destroy(Arrow2);
    }
}
