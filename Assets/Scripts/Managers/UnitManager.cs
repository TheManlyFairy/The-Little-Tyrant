using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitManager : MonoBehaviour
{

    public int armySize;
    public float buttonSpacing;
    public static UnitManager manager;
    public Button buttonPrefab;

    static NPC[] controlledUnits;
    static Button[] controlButtons;

    void Start()
    {
        manager = this;
        controlledUnits = new NPC[armySize];
        InitButtons();
    }

    void InitButtons()
    {
        controlButtons = new Button[armySize];

        for (int i = 0; i < armySize; i++)
        {
            controlButtons[i] = Instantiate(buttonPrefab);
            controlButtons[i].transform.position = new Vector2(transform.position.x + (i * buttonSpacing), transform.position.y);
            controlButtons[i].transform.SetParent(transform);
            controlButtons[i].transform.localScale = new Vector2(1, 1);
            controlButtons[i].interactable = false;

        }
    }
    public static bool IsManaging(NPC unit)
    {
        for (int i = 0; i < manager.armySize; i++)
            if (controlledUnits[i] && controlledUnits[i].Equals(unit))
                return true;
        return false;
    }

    public static bool AddUnit(NPC unit)
    {
        for (int i = 0; i < manager.armySize; i++)
        {
            if (controlledUnits[i] == null)
            {
                controlledUnits[i] = unit;
                controlButtons[i].interactable = true;
                controlButtons[i].image.sprite = unit.GetComponent<SpriteRenderer>().sprite;
                return true;
            }
        }
        return false;
    }

    public static void RemoveUnit(NPC unit)
    {
        for (int i = 0; i < manager.armySize; i++)
        {
            if (controlledUnits[i] && controlledUnits[i].Equals(unit))
            {
                controlledUnits[i] = null;
                controlButtons[i].interactable = false;
                controlButtons[i].image.sprite = null;
            }
        }
    }
}
