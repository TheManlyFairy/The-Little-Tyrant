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
    static List<NPC> selectedUnits;
    static Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
        manager = this;
        controlledUnits = new NPC[armySize];
        selectedUnits = new List<NPC>();
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
            controlButtons[i].onClick.AddListener(delegate
            {
                //link button to SelectDeselect units;
            });

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
        if (player.currentFear >= unit.fearToBeControlled)
        {
            player.ReduceFear(unit.fearToBeControlled);
            for (int i = 0; i < manager.armySize; i++)
            {
                if (controlledUnits[i] == null)
                {
                    controlledUnits[i] = unit;
                    controlButtons[i].image.sprite = unit.GetComponent<SpriteRenderer>().sprite;
                    controlButtons[i].interactable = true;
                    unit.BecomeControlled();
                    return true;
                }
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
    public static void SelectDeselect(NPC unit)
    {
        if (selectedUnits.Contains(unit))
        {
            selectedUnits.Remove(unit);
            unit.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            selectedUnits.Add(unit);
            unit.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
    public static void DeselectAll()
    {
        foreach(NPC unit in selectedUnits)
        {
            unit.GetComponent<SpriteRenderer>().color = Color.white;
        }
        selectedUnits.Clear();
    }
    public static bool HasSelectedUnits()
    {
        return selectedUnits.Count != 0;
    }
    public static void DirectMovement(Vector2 destination)
    {
        foreach (NPC unit in selectedUnits)
            unit.WalkToPoint(destination);
        DeselectAll();
    }
    public static void DirectAttack(Actor target)
    {
        foreach (NPC unit in selectedUnits)
            unit.Attack(target);
        DeselectAll();
    }
}
