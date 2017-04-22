using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalForce : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == transform.parent.tag)
        {
            Rigidbody2D otherRB = other.gameObject.GetComponentInParent<Rigidbody2D>();

            Vector3 dir = transform.position - other.gameObject.transform.position;

            if(otherRB)
                otherRB.AddForce(dir, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == transform.parent.tag)
        {
            Rigidbody2D otherRB = other.gameObject.GetComponentInParent<Rigidbody2D>();

            Vector3 dir = transform.position - other.gameObject.transform.position;

            if (otherRB)
                otherRB.AddForce(dir);
        }
    }
}
