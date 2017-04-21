using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed = 5f;

    private Rigidbody2D circleRB;

	// Use this for initialization
	void Start ()
    {
        circleRB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical) * Speed;
        circleRB.AddForce(movement);
    }
}
