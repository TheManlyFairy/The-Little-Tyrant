using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DestructibleObject : Actor
{

    public enum DestructionState { Intact, Damaged, Destroyed };
    protected DestructionState state = DestructionState.Intact;

    public float fearValue;
    public DestructionState State { get { return state; } }

    protected Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
}
