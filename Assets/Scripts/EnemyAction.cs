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

    public GameObject SplitEffect;
    public Attack AttackBehavior = Attack.Consume;
    public float PushForce = 2f;
    public GameObject GoodStuffPrefab;

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
                        StartCoroutine(GameManager.Instance.CheckIfGameOver());
                    }
                    else
                    {
                        Destroy(gameObject);
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
                            float newScale = oldTransform.localScale.x / 2f;
                            if (newScale < other.gameObject.GetComponent<Merging>().minSize)
                                newScale = other.gameObject.GetComponent<Merging>().minSize;

                            Vector3 dir = new Vector3(newScale, newScale, 0);
                            GameObject split1 = Instantiate(GoodStuffPrefab, oldTransform.position - dir, Quaternion.identity);
                            GameObject split2 = Instantiate(GoodStuffPrefab, oldTransform.position + dir, Quaternion.identity);

                            if (SplitEffect != null)
                            {
                                GameObject ps = Instantiate(SplitEffect, transform.position, transform.rotation);
                                Destroy(ps, ps.GetComponent<ParticleSystem>().main.duration);
                            }

                            // update scale, mass and drag
                            split1.transform.localScale = Vector3.one * newScale;
                            Rigidbody2D split1RB = split1.GetComponent<Rigidbody2D>();
                            split1RB.mass = otherRB.mass / 2f;
                            split1RB.drag = otherRB.drag / 2f;

                            split2.transform.localScale = Vector3.one * newScale;
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
