using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
	private AudioSource audioSource;
	private float defaultVolume = 0.25f;
	private string introFileName = "origameplay_1";
	private string loopFileName = "origameplay_2";

	private void Awake ()
	{
		this.audioSource = this.gameObject.AddComponent<AudioSource> ();
		this.audioSource.volume = this.defaultVolume;
	}

	private void Start ()
	{
		this.audioSource.clip = Resources.Load<AudioClip> (this.introFileName);
		this.audioSource.Play ();
	}

	private void Update ()
	{
		if (!this.audioSource.isPlaying) {
			this.audioSource.loop = true;
			this.audioSource.clip = Resources.Load<AudioClip> (this.loopFileName);
			this.audioSource.Play ();
		}
	}
}
