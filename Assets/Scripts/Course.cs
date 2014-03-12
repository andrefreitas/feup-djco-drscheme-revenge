using UnityEngine;
using System.Collections;

public class Course : MonoBehaviour {
	public AudioClip sound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col) {
		audio.PlayOneShot(sound);
		Destroy(gameObject);
	}
}
