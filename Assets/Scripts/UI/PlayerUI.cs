using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {


    public Image lifeBar;
    Player player;

    void Start ()
    {
        player = FindObjectOfType<Player>();
        lifeBar.fillAmount = player.HPRatio;
        player.OnTakeDamage += DamageTaken;
	}

    void DamageTaken(float damage)
    {
        lifeBar.fillAmount = player.HPRatio;
    }
}
