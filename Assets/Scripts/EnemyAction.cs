using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyAction : MonoBehaviour
{
    public enum Attack
    {
        Consume,
        Split
    }

    public Attack AttackBehavior = Attack.Consume;
    public float PushForce = 2f;
    public GameObject GoodStuffPrefab;
    public Action onCollided;

    // Use this for initialization
    void Start ()
    {
        GeneralLevel generalLevel = FindObjectOfType<GeneralLevel>();

        if(generalLevel != null)
        {
            onCollided += generalLevel.CheckForCompletion;
        }
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
                        StartCoroutine(GameManager.Instance.CheckIfGameOver());
                    }
                    else
                    {
                        Destroy(gameObject);

                        if(this.onCollided != null)
                        {
                            this.onCollided();
                        }
                    }
                    break;

                case Attack.Split:
                    if (other.gameObject.transform.localScale.x > other.gameObject.GetComponent<Merging>().minSize)
                    {
                        Rigidbody2D otherRB = other.gameObject.GetComponent<Rigidbody2D>();
                        Transform oldTransform = other.gameObject.transform;
                        Destroy(other.gameObject);

                        if(GoodStuffPrefab != null)
                        {
                            float newScal = oldTransform.localScale.x / 2f;
                            Vector3 dir = new Vector3(newScal, newScal, 0);
                            GameObject split1 = Instantiate(GoodStuffPrefab, oldTransform.position - dir, Quaternion.identity);
                            GameObject split2 = Instantiate(GoodStuffPrefab, oldTransform.position + dir, Quaternion.identity);

                            // update scale, mass and drag
                            split1.transform.localScale = Vector3.one * newScal;
                            Rigidbody2D split1RB = split1.GetComponent<Rigidbody2D>();
                            split1RB.mass = otherRB.mass / 2f;
                            split1RB.drag = otherRB.drag / 2f;

                            split2.transform.localScale = Vector3.one * newScal;
                            Rigidbody2D split2RB = split2.GetComponent<Rigidbody2D>();
                            split2RB.mass = otherRB.mass / 2f;
                            split2RB.drag = otherRB.drag / 2f;

                            // push the 2 new objects away
                            split1.GetComponent<Rigidbody2D>().AddForce(-dir * PushForce, ForceMode2D.Impulse);
                            split2.GetComponent<Rigidbody2D>().AddForce(dir * PushForce, ForceMode2D.Impulse);
                        }
                    }
                    break;
            }

        }
    }

    //private void adjustRigidbody (GameObject other)
    //{
    //    Rigidbody2D otherRB = other.GetComponent<Rigidbody2D>();
    //    otherRB.mass
    //}

}
