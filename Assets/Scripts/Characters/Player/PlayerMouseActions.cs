using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseActions : MonoBehaviour {

    RaycastHit2D clickedObject;
    Player player;
    //public GameObject pointMarker;
    
    void Start()
    {
        player = GetComponent<Player>();
        StartCoroutine(LookAtCursor());
    }

	void Update()
    {
        //transform.LookAt(Input.mousePosition);
        if(Input.GetMouseButtonDown(0))
        {
            SearchObjectToDamage();
        }

        if(Input.GetMouseButtonDown(1))
        {
            TakeControl();
        }
    }

    void SearchObjectToDamage()
    {
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clickedObject = Physics2D.Raycast(mouseWorldPos, Vector2.zero);

        if (clickedObject && clickedObject.collider.GetComponent<DestructibleObject>())
        {
            DestructibleObject dObject = clickedObject.collider.GetComponent<DestructibleObject>();
            Vector2 closestPointOnObject = clickedObject.collider.bounds.ClosestPoint(transform.position);

            if (Vector2.Distance(transform.position, closestPointOnObject) < 5f && dObject.State != DestructibleObject.DestructionState.Destroyed)
            {
                dObject.TakeDamage(player.damage);
            }
        }
    }

    void TakeControl()
    {
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clickedObject = Physics2D.Raycast(mouseWorldPos, Vector2.zero);

        if (clickedObject && clickedObject.collider.GetComponent<NPC>())
        {
            NPC character = clickedObject.collider.GetComponent<NPC>();
            character.BecomeControlled();
        }
    }

    IEnumerator LookAtCursor()
    {
        Vector3 mousePos;

        while (true)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 difference = mousePos - player.transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            yield return null;
        }
    }
}
