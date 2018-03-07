using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour {

    protected float health;
    protected float damage;

    public abstract void InflictDamage();
    public abstract void TakeDamage();
}
