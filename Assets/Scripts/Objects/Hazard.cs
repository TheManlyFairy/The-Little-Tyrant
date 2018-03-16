using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : DestructibleObject {

    public override void TakeDamage(float damageTaken)
    {
        currentHealth -= damageTaken;
        anim.Play("TakeHit");

        if (OnTakeDamage != null)
            OnTakeDamage(damageTaken);

        if (state == DestructionState.Intact && currentHealth <= 0)
        {
            state = DestructionState.Destroyed;
            Player.GainFear(fearValue);
            InflictDamage();
        }
    }
    public override void InflictDamage()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 8);
        foreach (Collider2D actor in colliders)
        {
           actor.GetComponent<Actor>().TakeDamage(damage);
        }
    }
}
