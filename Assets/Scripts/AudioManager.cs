using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
	private AudioSource audioSource;

    private void Awake()
    {
        this.audioSource = this.gameObject.AddComponent<AudioSource>();
        this.audioSource.volume = 0.25f;
    }

    private void Start()
    {
        this.audioSource.clip = Resources.Load<AudioClip>("origameplay_1");
        this.audioSource.Play();
    }

    private void Update()
    {
        if(!this.audioSource.isPlaying)
        {
            this.audioSource.loop = true;
            this.audioSource.clip = Resources.Load<AudioClip>("origameplay_2");
            this.audioSource.Play();
        }
    }
}
