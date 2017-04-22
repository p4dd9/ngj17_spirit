using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIFade : MonoBehaviour
{
    public float fadeTarget = 0.75f;
    private Image image;

	// Use this for initialization
	void Start ()
    {
        this.image = this.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Color c = this.image.color;
        c.a = Mathf.Lerp(c.a, this.fadeTarget, Time.deltaTime);
        this.image.color = c;
	}
}
