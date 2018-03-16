using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Actor
{
    public Player player;
    public float fearToBeControlled = 1;
    public float moveSpeed = 6, rotationSpeed = 3;
    public enum StateOfMind { FreeAlive, ControlledAlive, AwaitingOrders, PerformingOrder, Dead }
    public StateOfMind state = StateOfMind.FreeAlive;
    
    void Start()
    {
        
    }

    void Update()
    {

    }

    IEnumerator FollowPlayer()
    {
        while (state == StateOfMind.ControlledAlive)
        {
            
            if (Vector2.Distance(transform.position, player.transform.position) > 10f)
            {
                Vector3 difference = player.transform.position - transform.position;
                float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            }
            yield return null;
        }
            
    }

    public void BecomeControlled()
    {
        player = FindObjectOfType<Player>();
        if (Player.ReduceFear(fearToBeControlled))
        {
            state = StateOfMind.ControlledAlive;
            StartCoroutine(FollowPlayer());
        }
    }

    public override void InflictDamage()
    {
        throw new NotImplementedException();
    }
    public override void TakeDamage(float damageTaken)
    {
        throw new NotImplementedException();
    }
}
