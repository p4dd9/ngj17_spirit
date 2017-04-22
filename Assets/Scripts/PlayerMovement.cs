using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float thrust = 2;
    public float directionLagCoefficient = 2;

    private Vector2 currentDirection;
    private Vector2 desiredDirection;

    private new Rigidbody2D rigidbody2D;

    private void Start()
    {
        this.rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        this.desiredDirection = new Vector2(inputX, inputY);
        this.currentDirection = Vector2.Lerp(this.currentDirection, this.desiredDirection.normalized, Time.deltaTime * directionLagCoefficient);
    }

    private void FixedUpdate()
    {
        this.rigidbody2D.AddForce(this.currentDirection.normalized * this.currentDirection.magnitude * this.thrust);
    }

    private void LateUpdate()
    {
        //Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 5));
        //this.transform.position = worldPoint;
    }
}
