using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Speed = 5f;
    public float WanderDistance = 2f;
    public float WanderRadius = 5f;
    public float WanderRate = 1f;

    private Rigidbody2D shapeRB;
    private Vector2 movement = Vector2.zero;
    private float timer = 0;

	// Use this for initialization
	void Start ()
    {
        shapeRB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(timer >= WanderRate)
        {
            movement = wander();
            timer = 0f;
        }

        timer += Time.deltaTime;
       
	}

    private void FixedUpdate()
    {
        shapeRB.AddForce(movement * Speed);
    }

    Vector2 wander()
    {
        Vector2 dir = Random.insideUnitCircle * WanderRadius;

        return dir * WanderDistance;
    }
}
