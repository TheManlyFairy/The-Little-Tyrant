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
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);

    }

    public override void TakeDamage()
    {
        throw new NotImplementedException();
    }
}
