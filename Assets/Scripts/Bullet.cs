using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int maxCollisions = 2;
	public int currentCollisions = 0;


	void Start () {

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
		Debug.Log ("hit " + name);

		if (name == "leftWall") {
			transform.Rotate(0, 0, 130);
		}

	}
}