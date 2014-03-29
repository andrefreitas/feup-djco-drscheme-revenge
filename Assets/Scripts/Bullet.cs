using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int maxCollisions = 2;
	public int currentCollisions = 0;
	public float speedforce = 150f;
	public GameObject soundEffects;
	public AudioClip bounce;
	public AudioClip explode;


	void Start () {
		soundEffects = GameObject.Find ("soundEffects");

	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.y >= 10) {
				Destroy (gameObject);
		} else {

		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		string name = col.gameObject.name;
		//Debug.Log ("hit " + name);

		if (name == "leftWall" || name == "rightWall" || name == "ProtectionCICA" || name == "ProtectionMoodle" || name == "ProtectionFEUPLoad" ) {
			soundEffects.audio.PlayOneShot(bounce);
		}
		else if(name == "enemy") {
			soundEffects.audio.PlayOneShot(explode);
			Destroy(gameObject);
		}

	}
	
}