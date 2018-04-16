using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputActions : MonoBehaviour {

    RaycastHit2D clickedObject;
    Player player;
    KeyCode[] unitCodes = {KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6,
                           KeyCode.Keypad1, KeyCode.Keypad2, KeyCode.Keypad3, KeyCode.Keypad4, KeyCode.Keypad5, KeyCode.Keypad6};
    //public GameObject pointMarker;
    
    void Start()
    {
        player = GetComponent<Player>();
        StartCoroutine(LookAtCursor());
    }

	void Update()
    {
        if (Input.GetMouseButtonDown(0))
            LeftClickCommands();

        if (Input.GetMouseButtonDown(1))
            RightClickCommands();

        NumericInput();
    }

    void LeftClickCommands()
    {
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clickedObject = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
        if (clickedObject)
        {
            if (clickedObject.collider.GetComponent<DestructibleObject>())
            {
                if (UnitManager.HasSelectedUnits())
                    UnitManager.DirectAttack(clickedObject.collider.GetComponent<DestructibleObject>());
                else
                    SearchObjectToDamage();
            }

            else if (clickedObject.collider.GetComponent<NPC>())
            {
                NPC unit = clickedObject.collider.GetComponent<NPC>();
                if (UnitManager.IsManaging(unit))
                    UnitManager.SelectDeselect(unit);
            }
            else if (UnitManager.HasSelectedUnits())
                UnitManager.DirectMovement(mouseWorldPos);

        }
    }
    void RightClickCommands()
    {
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clickedObject = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
        if (clickedObject)
        {
            if (clickedObject.collider.GetComponent<NPC>())
            {
                NPC unit = clickedObject.collider.GetComponent<NPC>();
                if (UnitManager.IsManaging(unit))
                    UnitManager.RemoveUnit(unit);
                else if (player.currentFear > unit.fearToBeControlled)
                    UnitManager.AddUnit(unit);
            }
        }

    }
    void NumericInput()
    {
        for (int i = 0; i < (unitCodes.Length / 2) - 1; i++)
        {
            if (Input.GetKeyDown(unitCodes[i]) || Input.GetKeyDown(unitCodes[i + unitCodes.Length / 2 - 1]))
            {
                UnitManager.SelectDeselectByIndex(i);
                return;
            }
        }
    }

    void SearchObjectToDamage()
    {
        DestructibleObject dObject = clickedObject.collider.GetComponent<DestructibleObject>();
        Vector2 closestPointOnObject = clickedObject.collider.bounds.ClosestPoint(transform.position);

        if (Vector2.Distance(transform.position, closestPointOnObject) < 5f && dObject.State != DestructibleObject.DestructionState.Destroyed)
        {
            dObject.TakeDamage(player.damage);
        }
    }

    IEnumerator LookAtCursor()
    {
        Vector3 mousePos;
        Camera mainCam = Camera.main;
        while (true)
        {
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 difference = mousePos - player.transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            yield return null;
        }
    }
}
