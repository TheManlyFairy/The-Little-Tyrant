using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{

    static float maxFear = 5, currentFear = 0;

    void Start()
    {

    }

    public override void InflictDamage()
    {
        
    }
    public override void TakeDamage(float damageTaken)
    {
        currentHealth -= damageTaken;
        if (currentHealth <= maxHealth / 2)
            GetComponent<Renderer>().material.color = Color.yellow;
    }
    public void TakeOver(NPC ownedNPC)
    {
        ownedNPC.player = this;
        ownedNPC.state = NPC.StateOfMind.ControlledAlive;
    }

    public static void GainFear(float fearValue)
    {
        currentFear += fearValue;
        if (currentFear > maxFear)
            currentFear = maxFear;
    }
    public static bool ReduceFear(float fearValue)
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
