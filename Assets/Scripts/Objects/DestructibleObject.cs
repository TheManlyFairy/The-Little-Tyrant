using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : Actor
{

    enum DestructionState { Intact, Damaged, Destroyed };
    DestructionState state = DestructionState.Intact;

    public float fearValue;

    void Start()
    {
        GetComponent<Renderer>().material.color = Color.green;
    }

    public override void InflictDamage()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 5);
        foreach(Collider2D actor in colliders)
        {
            actor.GetComponent<Actor>().TakeDamage(damage);
        }
    }

    public override void TakeDamage(float damageTaken)
    {
        if (state != DestructionState.Destroyed)
        {
            Debug.Log("Taking damage");
            currentHealth -= damageTaken;
            if (state == DestructionState.Intact && currentHealth <= maxHealth / 2)
            {
                state = DestructionState.Damaged;
                GetComponent<Renderer>().material.color = Color.yellow;
            }
            if (state == DestructionState.Damaged && currentHealth <= 0)
            {
                state = DestructionState.Destroyed;
                GetComponent<Renderer>().material.color = Color.red;
                InflictDamage();
            }
        }
    }
}
