using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Merging : MonoBehaviour
{
    public GameObject MergeEffect;
    public float minSize = .5f;
    public float maxSize = 4f;
    public Action onCollided;

    private float currentSize;
    private Rigidbody2D shapeRB;

	// Use this for initialization
	void Start ()
    {
        shapeRB = GetComponent<Rigidbody2D>();
        currentSize = transform.localScale.x;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == gameObject.tag && 
          (transform.localScale.x < maxSize && other.gameObject.transform.localScale.x < maxSize))
        {
            if (gameObject.activeSelf)
            {
                Rigidbody2D otherRB = other.gameObject.GetComponent<Rigidbody2D>();
                // disable the other gameObject we've collided with, then flag to destroy it
                other.gameObject.SetActive(false);
                Destroy(other.gameObject);

                if(MergeEffect != null)
                {
                    GameObject ps = Instantiate(MergeEffect, transform.position , transform.rotation);
                    Destroy(ps, ps.GetComponent<ParticleSystem>().main.duration);
                }

                shapeRB.mass += otherRB.mass;
                //shapeRB.drag += otherRB.drag;

                Camera.main.GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Hit Green" + UnityEngine.Random.Range(0, 3)));

                currentSize += other.gameObject.transform.localScale.x;
                if (currentSize > maxSize)
                    currentSize = maxSize;
                transform.localScale = new Vector3(currentSize, currentSize, currentSize);

                if (this.onCollided != null)
                {
                    Debug.Log("onCollided called");
                    this.onCollided();
                    this.onCollided = null;
                }
            }
        }
    }
}
