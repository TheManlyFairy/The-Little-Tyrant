using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

    public Slider slider;
    Actor actor;

    void Start()
    {
        actor = GetComponent<Actor>();
        slider.value = actor.HPRatio;
        actor.OnTakeDamage += DamageTaken;
    }

    void DamageTaken(float hpRatio)
    {
        Debug.Log("damage");
        slider.value = actor.HPRatio;
    }
}
