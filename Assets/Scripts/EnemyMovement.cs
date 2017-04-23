using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Speed = 5f;
    public float WanderRate = 1f;
    public float directionLagCoefficient = 2;

    private Rigidbody2D shapeRB;
    private float timer = 0f;
    private Vector2 currentDirection;
    private Vector2 desiredDirection;

    // Use this for initialization
    void Start ()
    {
        shapeRB = GetComponent<Rigidbody2D>();
        desiredDirection = wander();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(timer >= WanderRate)
        {
            desiredDirection = wander();
            timer = 0f;
        }

        timer += Time.deltaTime;
        this.currentDirection = Vector2.Lerp(this.currentDirection, this.desiredDirection.normalized, Time.deltaTime * directionLagCoefficient);
    }

    private void FixedUpdate()
    {
        shapeRB.AddForce(this.currentDirection.normalized * this.currentDirection.magnitude * Speed);
    }

    Vector2 wander()
    {
        //Vector2 dir = Random.insideUnitCircle * WanderRadius;

        //return dir * WanderDistance;
        float inputX = Random.Range(-1.0f, 1.0f);
        float inputY = Random.Range(-1.0f, 1.0f);

        return new Vector2(inputX, inputY);
    }
}
