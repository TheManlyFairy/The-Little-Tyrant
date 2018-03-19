using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_NPCCommand : MonoBehaviour {

    public bool selected;
    SpriteRenderer rend;
    Vector2 destination;
    Actor target;
    public float moveSpeed;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        selected = false;
    }

    public void SelectDeselect()
    {
        selected = !selected;
        if (selected)
        {
            rend.color = Color.red;
            Test_PlayerCommand.AddUnit(this);
        }
        else
        {
            rend.color = Color.white;
            Test_PlayerCommand.RemoveUnit(this);
        }
    }
    public void WalkToPoint(Vector2 dest)
    {
        SelectDeselect();
        destination = dest;
        StartCoroutine(WalkToPoint());
    }
    public void Attack(Actor target)
    {
        SelectDeselect();
        destination = target.transform.position;
        this.target = target;
        StartCoroutine(WalkToPoint());
    }

    IEnumerator WalkToPoint()
    {
        float dist = Vector2.Distance(transform.position, destination);
        while(dist > 5)
        {
            
            Debug.Log("Walking");

            transform.position = Vector2.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
            yield return null;
            dist = Vector2.Distance(transform.position, destination);
        }
        StopCoroutine(WalkToPoint());
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        while (target.HPRatio > 0)
        {
            target.TakeDamage(1);
            yield return new WaitForSeconds(1);
        }
    }
}
