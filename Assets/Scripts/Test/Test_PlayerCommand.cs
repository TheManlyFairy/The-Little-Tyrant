using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_PlayerCommand : MonoBehaviour {

    public static List<Test_NPCCommand> selectedUnits;
    RaycastHit2D hit;

    void Start()
    {
        selectedUnits = new List<Test_NPCCommand>();
    }

    public static void AddUnit(Test_NPCCommand unit)
    {
        selectedUnits.Add(unit);
    }
    public static void RemoveUnit(Test_NPCCommand unit)
    {
        selectedUnits.Remove(unit);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider.name == "Floor")
            {
                foreach (Test_NPCCommand npc in selectedUnits)
                    npc.WalkToPoint(mousePos);
            }
            if(hit.collider.GetComponent<Test_NPCCommand>())
            {
                hit.collider.GetComponent<Test_NPCCommand>().SelectDeselect();
            }
            if(hit.collider.GetComponent<DestructibleObject>())
            {
                foreach (Test_NPCCommand npc in selectedUnits)
                    npc.Attack(hit.collider.GetComponent<Actor>());
            }
        }
    }
}
