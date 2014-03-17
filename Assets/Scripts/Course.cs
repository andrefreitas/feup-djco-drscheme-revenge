using UnityEngine;
using System.Collections;

public class Course : MonoBehaviour {
	public AudioClip sound;
	public GameObject audioObject;

	// Use this for initialization
	void Start () {
		audioObject = GameObject.Find ("AudioObject");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col) {
		audioObject.audio.PlayOneShot (sound);
		Destroy(gameObject);
	}
}
