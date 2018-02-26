using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

	[SerializeField] private AudioClip[] clips;

	public AudioSource myAudioSource;
	// Use this for initialization
	void Start ()
	{
		myAudioSource = GetComponent<AudioSource>();
 	}
	
	public void PlayDisgustedSound()
	{
		myAudioSource.clip = clips[0];
		myAudioSource.loop = false;
		myAudioSource.volume = 1;
		myAudioSource.Play();
	}
	
	public void PlayDelishSound()
	{
		myAudioSource.clip = clips[1];
		myAudioSource.loop = false;
		myAudioSource.volume = 1;
		myAudioSource.Play();
	}
}
