using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public Vector2 speed = new Vector2(50, 50);
    public float thrust = 2;
    public float directionLagCoefficient = 2;

    private Vector2 currentDirection;
    private Vector2 desiredDirection;

    private new Rigidbody2D rigidbody2D;

    private void Start()
    {
        this.rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        this.desiredDirection = new Vector2(speed.x * inputX,speed.y * inputY);
        this.currentDirection = Vector2.Lerp(this.currentDirection, this.desiredDirection.normalized, Time.deltaTime * directionLagCoefficient);
    }

    void FixedUpdate()
    {
        this.rigidbody2D.AddForce(this.currentDirection.normalized * this.currentDirection.magnitude * this.thrust);
    }
}
