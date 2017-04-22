using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIFade : MonoBehaviour
{
    public float fadeTarget = 0.75f;
    public float fadeTime = 1;
    private Image image;
    private float startTime;
    private float startAlpha;

	// Use this for initialization
	void Start ()
    {
        this.image = this.GetComponent<Image>();
        this.startTime = Time.time;
        this.startAlpha = this.image.color.a;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Color c = this.image.color;
        c.a = Mathf.Lerp(this.startAlpha, this.fadeTarget, Mathf.InverseLerp(this.startTime, this.startTime + this.fadeTime, Time.time));
        this.image.color = c;
	}
}
