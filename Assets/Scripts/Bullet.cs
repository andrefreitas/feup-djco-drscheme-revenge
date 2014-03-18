using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int maxCollisions = 2;
	public int currentCollisions = 0;

	// Use this for initialization
	void Start () {
		rigidbody.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.y >= 10) {
				Destroy (gameObject);
		} else {

		}
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.name == "LeftLimit" || col.gameObject.name == "RightLimit") {
						
		
		} else if (col.gameObject.name == "Student") {
				Destroy(gameObject);
		}

		else if (currentCollisions < maxCollisions) {
			currentCollisions++;
		}

		else Destroy(gameObject);
	}
}