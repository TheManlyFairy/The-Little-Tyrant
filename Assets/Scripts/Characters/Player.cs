using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Image lifeBar;

    public float startHealth;
    public float health;
    public int fear = 3;

    void Start()
    {
        lifeBar.fillAmount = 1;
        startHealth = health;
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D colInfo)
    {
        if ((colInfo.gameObject.tag == "Hit") || (colInfo.gameObject.tag == "Explosion"))
        {
            TakeDamage(colInfo, colInfo.relativeVelocity.magnitude);
        }
    }

    public void InflictDamage()
    {
        throw new NotImplementedException();
    }

    public void TakeDamage(Collision2D colInfo, float damage)
    {
        lifeBar.fillAmount = ((colInfo.relativeVelocity.magnitude * damage) / startHealth);
        health -= (colInfo.relativeVelocity.magnitude * damage);
        if (lifeBar.fillAmount <= 0.2)
        {
            lifeBar.color = Color.red;
        }
        throw new NotImplementedException();
    }
}

