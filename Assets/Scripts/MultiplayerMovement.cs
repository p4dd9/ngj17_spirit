using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MultiplayerMovement : MonoBehaviour
{
    public float thrust = 2;
    public float directionLagCoefficient = 2;

    private Vector2 currentDirection;
    private Vector2 desiredDirection;

    private new Rigidbody2D rigidbody2D;
    private bool isPlayer1;

    private void Start()
    {
        GameManager.Instance.currentGameState = EGameState.Multiplayer;

        this.rigidbody2D = this.GetComponent<Rigidbody2D>();
        if (gameObject.tag == "Player1")
            isPlayer1 = true;
        else
            isPlayer1 = false;
    }

    private void Update()
    {
        if(GameManager.Instance.currentGameState == EGameState.GameOver)
        {
            return;
        }

        float inputX;
        float inputY;

        if (isPlayer1)
        {
            inputX = Input.GetAxis("P1Horizontal");
            inputY = Input.GetAxis("P1Vertical");
        }
        else
        {
            inputX = Input.GetAxis("P2Horizontal");
            inputY = Input.GetAxis("P2Vertical");
        }
       

        this.desiredDirection = new Vector2(inputX, inputY);
        this.currentDirection = Vector2.Lerp(this.currentDirection, this.desiredDirection.normalized, Time.deltaTime * directionLagCoefficient);
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.currentGameState == EGameState.GameOver)
        {
            return;
        }

        this.rigidbody2D.AddForce(this.currentDirection.normalized * this.currentDirection.magnitude * this.thrust);
    }
}
