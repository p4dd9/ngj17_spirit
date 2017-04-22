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

    public Attack AttackBehavior = Attack.Consume;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "GoodStuff")
        {
            switch (AttackBehavior)
            {
                case Attack.Consume:
                    if (other.gameObject.transform.localScale.x < transform.localScale.x)
                    {
                        Destroy(other.gameObject);
                    }
                    break;

                case Attack.Split:
                    break;
            }

        }
    }

}
