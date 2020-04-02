using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCoin : MonoBehaviour
{
   public GameObject coin;
   public GameObject prefabCoin;
   public Rigidbody2D coin_vertForce;
    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag ==  "Player"){
        coinSpawner();
        Destroy(this.gameObject);
        }

    }
    public void coinSpawner(){
        for (int i = 1; i <= 10; i++)
        {
            coin = Instantiate(prefabCoin, new Vector2(transform.position.x,transform.position.y + 3 + (float)0.3*i),Quaternion.identity);
            coin.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,5f);
        }
    }
}
