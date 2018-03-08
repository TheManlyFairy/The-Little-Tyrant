using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{

    public float maxFear = 5, currentFear = 0;

    void Start()
    {

    }

    public override void InflictDamage()
    {
        
    }

    public override void TakeDamage(float damageTaken)
    {
        currentHealth -= damageTaken;
        if (currentHealth <= maxHealth / 2)
            GetComponent<Renderer>().material.color = Color.yellow;
    }
}
