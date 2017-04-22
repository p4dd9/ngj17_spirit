using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOfScreen : MonoBehaviour
{
    float leftConstraint = 0;
    float rightConstraint = 0;
    float bottomConstraint = 0;
    float topConstraint = 0; 
    float distanceZ;
    float buffer;

    void Start()
    {
        distanceZ = Mathf.Abs(transform.position.z - Camera.main.transform.position.z);

        leftConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
        rightConstraint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;
        bottomConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).y;
        topConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, distanceZ)).y;

        buffer = transform.localScale.x;
    }

    void LateUpdate()
    {
        if (transform.position.x < leftConstraint - buffer)
        {
            transform.position = new Vector3(rightConstraint, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > rightConstraint + buffer)
        {
            transform.position = new Vector3(leftConstraint, transform.position.y, transform.position.z);
        }

        if (transform.position.y < bottomConstraint - buffer)
        {
            transform.position = new Vector3(transform.position.x, topConstraint, transform.position.z);
        }
        else if (transform.position.y > topConstraint + + buffer)
        {
            transform.position = new Vector3(transform.position.x, bottomConstraint, transform.position.z);
        }
    }
}
