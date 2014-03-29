using UnityEngine;
using System.Collections;

public class ship : MonoBehaviour {

	public GameObject soundEffects;
	public AudioClip soundShipHit;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col) {
		soundEffects.audio.PlayOneShot(soundShipHit);
	}
}
