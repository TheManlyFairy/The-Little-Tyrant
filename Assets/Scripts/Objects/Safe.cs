using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : DestructibleObject {

    public override void TakeDamage(float damageTaken)
    {
        currentHealth -= damageTaken;
        anim.Play("TakeHit");
        if (state == DestructionState.Intact && currentHealth <= maxHealth / 2)
        {
            state = DestructionState.Damaged;
            spriteRenderer.sprite = Damaged;
        }
        if (state == DestructionState.Damaged && currentHealth <= 0)
        {
            state = DestructionState.Destroyed;
            spriteRenderer.sprite = Destroyed;
            Player.GainFear(fearValue);
        }
    }
    public override void InflictDamage()
    {
        
    }
}
