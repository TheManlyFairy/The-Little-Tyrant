using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour {

    protected float health;
    protected float damage;

    public abstract void InflictDamage();
}
