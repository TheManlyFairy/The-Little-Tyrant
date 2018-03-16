using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(SpriteRenderer))]
public abstract class Actor : MonoBehaviour {

    public float damage, maxHealth, currentHealth;
    public float HPRatio { get { return currentHealth / maxHealth; } }

    public Action<float> OnTakeDamage;
    public Action OnDestruction;

    public abstract void InflictDamage();
    public abstract void TakeDamage(float damageTaken);
}
