using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour 
{
    public Image timer;
    public float levelTime;

	void Start () 
    {
		
	}
	
	void Update () 
    {
        
	}

   void CountdownTimer()
    {
        timer.fillAmount -= Time.deltaTime / levelTime;
        if (timer.fillAmount <= 0)
        {
            Time.timeScale = 0.0f;
            Debug.Log("You Lose");
        }
    }
}
