using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{ 
	AudioSource audioSource;
	[SerializeField] AudioClip Clip;

    // Start is called before the first frame update
    void Awake()
    {
		audioSource = GetComponent<AudioSource>();
		audioSource.PlayOneShot(Clip);

	}
	
}
