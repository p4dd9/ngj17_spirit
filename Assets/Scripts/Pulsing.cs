using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulsing : MonoBehaviour
{
    public Light Light;
    public float MaxIntensity = 10f;
    public float MinIntensity = 1f;
    public float Steps;
    public float GlowRate;


    private float timer = 0f;
    private bool inc = true;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(timer > GlowRate)
        {
           if(inc)
                Light.intensity += Steps;
            else
                Light.intensity -= Steps;
            timer = 0;
        }

        timer += Time.deltaTime;

        if (Light.intensity > MaxIntensity && inc)
        {
            inc = false;
        }
        else if(Light.intensity <= MinIntensity && !inc)
        {
            inc = true;
        }

    }
}
