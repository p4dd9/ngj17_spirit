using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merging : MonoBehaviour
{
    public float minSize = .5f;
    public float maxSize = 4f;

    private float currentSize;

	// Use this for initialization
	void Start ()
    {
        currentSize = transform.localScale.x;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "GoodStuff")
        {
            if (gameObject.activeSelf)
            {
                // disable the other gameObject we've collided with, then flag to destroy it
                other.gameObject.SetActive(false);
                Destroy(other.gameObject);

                currentSize += other.gameObject.transform.localScale.x;
                if (currentSize > maxSize)
                    currentSize = maxSize;
                transform.localScale = new Vector3(currentSize, currentSize, currentSize);
            }
        }
    }
}
