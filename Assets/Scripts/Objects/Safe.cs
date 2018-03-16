using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : DestructibleObject {

    public override void InflictDamage()
    {

    }
    public override void TakeDamage(float damageTaken)
    {
        currentHealth -= damageTaken;

        anim.Play("TakeHit");

        if (OnTakeDamage != null)
        {
            OnTakeDamage(damageTaken);
        }

        if (state == DestructionState.Intact && HPRatio <= 0.5f)
        {
            state = DestructionState.Damaged;
        }
        if (state == DestructionState.Damaged && HPRatio <= 0)
        {
            Destruction();
        }
    } 

    void Destruction()
    {
        state = DestructionState.Destroyed;
        if (OnDestruction!=null)
        {
            OnDestruction();
            Player.GainFear(fearValue);
        }
    }
}
