using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseActions : MonoBehaviour {

    RaycastHit2D clickedObject;
    Player player;
    
    void Start()
    {
        player = GetComponent<Player>();
    }

	void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickedObject = Physics2D.Raycast(mousePos, Vector2.zero);
            if(clickedObject && clickedObject.collider.GetComponent<DestructibleObject>())
            {
                DestructibleObject dObject = clickedObject.collider.GetComponent<DestructibleObject>();
                if(Vector2.Distance(transform.position, dObject.transform.position) < 1.3f)
                {
                    dObject.TakeDamage(player.damage);
                }
            }
        }
    }
}
