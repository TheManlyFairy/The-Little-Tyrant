using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour {

    public float damage, maxHealth, currentHealth;

    public abstract void InflictDamage();
    public abstract void TakeDamage(float damageTaken);
}
