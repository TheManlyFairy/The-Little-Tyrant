using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Player playerToFollow;
    public float distanceAheadOfPlayer; // how far ahead of the player the camera will be
    public float moveSpeedDivision; // divide value return by GetAxis to reduce camera movement speed

    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        float xPos = Input.GetAxis("Horizontal");
        float yPos = Input.GetAxis("Vertical");
        xPos = ((xPos * distanceAheadOfPlayer) / moveSpeedDivision) + playerToFollow.transform.position.x;
        yPos = ((yPos * distanceAheadOfPlayer) / moveSpeedDivision) + playerToFollow.transform.position.y;
        transform.position = new Vector3(xPos, yPos, transform.position.z);

    }
}
