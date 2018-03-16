using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : DestructibleObject {

    public override void TakeDamage(float damageTaken)
    {
        currentHealth -= damageTaken;
        anim.Play("TakeHit");
        if (state == DestructionState.Intact && currentHealth <= 0)
        {
            state = DestructionState.Destroyed;
            spriteRenderer.sprite = Destroyed;
            Player.GainFear(fearValue);
            InflictDamage();
        }
    }
    public override void InflictDamage()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 8);
        foreach (Collider2D actor in colliders)
        {
            Debug.Log(actor.name);
            actor.GetComponent<Actor>().TakeDamage(damage);
        }
    }
}
