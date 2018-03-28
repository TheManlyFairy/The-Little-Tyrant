using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{

    public float maxFear = 5, currentFear = 5;

    void Start()
    {

    }

    public override void InflictDamage()
    {
        
    }
    public override void TakeDamage(float damageTaken)
    {
        currentHealth -= damageTaken;
        if (OnTakeDamage != null)
            OnTakeDamage(damageTaken);
    }
    public void TakeOver(NPC ownedNPC)
    {
        ownedNPC.player = this;
        ownedNPC.state = NPC.StateOfMind.ControlledAlive;
    }

    public void GainFear(float fearValue)
    {
        currentFear += fearValue;
        if (currentFear > maxFear)
            currentFear = maxFear;
    }
    public bool ReduceFear(float fearValue)
    {
        if (fearValue > currentFear)
            return false;
        else
        {
            currentFear -= fearValue;
            return true;
        }
    }
}
