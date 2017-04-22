using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    public enum Attack
    {
        Consume,
        Split
    }

    public Attack Behavior = Attack;

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
        if(other.gameObject.tag == "GoodStuff")
        {
            if(other.gameObject.transform.localScale.x < transform.localScale.x)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
