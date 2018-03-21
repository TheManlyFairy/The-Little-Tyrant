using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
    public Image timer;
    public float levelTime;

	void Start () 
    {
		
	}
	
	void Update () 
    {
        timer.fillAmount -= Time.deltaTime / levelTime;
        if(timer.fillAmount <= 0)
        {
            Time.timeScale = 0.0f;
            Debug.Log("You Lose");
        }
	}

    public void slotSelect(Button slotNumber)
    {
        switch (slotNumber.name)
        {
            case "Slot1_Button":
                print("Slot 1");
                break;
            case "Slot2_Button":
                print("Slot 2");
                break;
            case "Slot3_Button":
                print("Slot 3");
                break;
            case "Slot4_Button":
                print("Slot 4");
                break;
            case "Slot5_Button":
                print("Slot 5");
                break;
            case "Slot6_Button":
                print("Slot 6");
                break;
            default:
                print("None.");
                break;
        }
    }
}
