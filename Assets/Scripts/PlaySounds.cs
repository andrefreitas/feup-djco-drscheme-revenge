using UnityEngine;
using System.Collections;


public class PlaySounds : MonoBehaviour {
	public AudioClip teleportSound;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown("w"))
		{
			audio.PlayOneShot(teleportSound);
		}
		
		
	}
}
