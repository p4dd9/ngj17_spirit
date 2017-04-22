using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class PlayerMovementAudio : MonoBehaviour
{
    public float minVolume = 0.25f;

    private AudioSource audioSource;
    private new Rigidbody2D rigidbody2D;
    private float currentLerpValue = 0;
    private AnimationCurve volumeCurve;

    private void Awake()
    {
        this.volumeCurve = AnimationCurve.EaseInOut(0, this.minVolume, 1, 1);
    }

    private void Start()
    {   
        this.audioSource = this.GetComponent<AudioSource>();
        this.rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(this.rigidbody2D.velocity.magnitude > 1)
        {
            this.currentLerpValue = Mathf.Clamp01(this.currentLerpValue + Time.deltaTime);
        }
        else
        {
            this.currentLerpValue = Mathf.Clamp01(this.currentLerpValue - Time.deltaTime);
        }

        float newVolume = this.volumeCurve.Evaluate(this.currentLerpValue);

        if (this.audioSource.volume != newVolume)
        {
            this.audioSource.volume = this.volumeCurve.Evaluate(newVolume);
        }
    }
}
