using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class SpriteManager : MonoBehaviour {

    public Sprite intact, damaged, destroyed;
    Actor actor;
    Animator anim;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        actor = GetComponent<Actor>();
        actor.OnTakeDamage += DamageTaken;
    }

    void DamageTaken(float hpRatio)
    {
        anim.Play("Hit");
        if (actor.HPRatio <= 0)
            spriteRenderer.sprite = destroyed;
        else if (actor.HPRatio <= 0.5f)
            spriteRenderer.sprite = damaged;
    }
}
