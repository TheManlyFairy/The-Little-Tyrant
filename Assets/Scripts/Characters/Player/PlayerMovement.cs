using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 5;

	void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 moveDirection = new Vector2();

        if (Input.GetKey(KeyCode.W))
            moveDirection += Vector2.up;
        if (Input.GetKey(KeyCode.S))
            moveDirection += Vector2.down;
        if (Input.GetKey(KeyCode.A))
            moveDirection += Vector2.left;
        if (Input.GetKey(KeyCode.D))
            moveDirection += Vector2.right;

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
}
