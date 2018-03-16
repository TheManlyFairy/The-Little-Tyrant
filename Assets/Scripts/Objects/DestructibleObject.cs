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

    public Sprite Intact, Damaged, Destroyed;
    protected SpriteRenderer spriteRenderer;
    protected Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Intact;
    }
}
