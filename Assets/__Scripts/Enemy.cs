﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health=10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage) {
        Debug.Log("working");

        health += -damage;

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
