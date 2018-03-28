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
    public GameObject PointMarker;
    Vector2 destination;
    Actor target;
    
    public void BecomeControlled()
    {
        player = FindObjectOfType<Player>();
        state = StateOfMind.ControlledAlive;
        StopAllCoroutines();
        StartCoroutine(FollowPlayer());
    }
    public void WalkToPoint(Vector2 dest)
    {
        destination = dest;
        state = StateOfMind.PerformingOrder;
        StopAllCoroutines();
        StartCoroutine(WalkToPoint());
    }
    public void Attack(Actor target)
    {
        destination = target.transform.position;
        this.target = target;
        state = StateOfMind.PerformingOrder;
        StopAllCoroutines();
        StartCoroutine(Attack());
    }

    public override void InflictDamage()
    {
        throw new NotImplementedException();
    }
    public override void TakeDamage(float damageTaken)
    {
        currentHealth -= damageTaken;
        if (HPRatio <= 0)
            state = StateOfMind.Dead;
    }

    IEnumerator FollowPlayer()
    {
        while (state == StateOfMind.ControlledAlive)
        {
            if (Vector2.Distance(transform.position, player.transform.position) > 15)
            {
                Vector3 difference = player.transform.position - transform.position;
                float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            }
            yield return null;
        }
    }
    IEnumerator WalkToPoint()
    {

        float dist = Vector2.Distance(transform.position, destination);
        while (dist > 5)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);

            Vector3 difference = (Vector3)destination - transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

            yield return null;

            dist = Vector2.Distance(transform.position, destination);
        }
        StopCoroutine(WalkToPoint());
        StartCoroutine(Attack());
    }
    IEnumerator Attack()
    {
        Vector2 closestPointOnObject = target.GetComponent<Collider2D>().bounds.ClosestPoint(transform.position);
        Vector2 closestPointOnSelf = GetComponent<Collider2D>().bounds.ClosestPoint(target.transform.position);

        float dist = Vector2.Distance(transform.position, target.transform.position);

        while (dist > 5)
        {

            transform.position = Vector2.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);

            Vector3 difference = target.transform.position - transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

            yield return null;

            closestPointOnObject = target.GetComponent<Collider2D>().bounds.ClosestPoint(transform.position);
            closestPointOnSelf = GetComponent<Collider2D>().bounds.ClosestPoint(target.transform.position);
            dist = Vector2.Distance(closestPointOnObject, closestPointOnSelf);
        }

        while (target.HPRatio > 0)
        {
            target.TakeDamage(damage);
            yield return new WaitForSeconds(1);
        }
    }
}
