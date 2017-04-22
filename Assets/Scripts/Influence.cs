using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Influence : MonoBehaviour
{
    private Rigidbody2D playerRB;
    public Action onCollided;

    // Use this for initialization
    void Start()
    {
        playerRB = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "GoodStuff")
        {
            Rigidbody2D otherRB = other.gameObject.GetComponent<Rigidbody2D>();
            Vector2 dir = other.gameObject.transform.position - gameObject.transform.position;

            otherRB.AddForce(dir.normalized * playerRB.velocity.magnitude, ForceMode2D.Impulse);

            if(this.onCollided != null)
            {
                this.onCollided();
            }
        }
    }
}
