using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour {

    public Sprite intact, damaged, destroyed;
    Actor actor;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        actor = GetComponent<Actor>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        actor.OnTakeDamage += DamageTaken;
    }

    void DamageTaken(float hpRatio)
    {
        if (actor.HPRatio <= 0)
            spriteRenderer.sprite = destroyed;
        else if (actor.HPRatio <= 0.5f)
            spriteRenderer.sprite = damaged;
    }
}
