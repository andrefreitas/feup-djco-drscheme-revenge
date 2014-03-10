using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public LayerMask collisionMask;

	public float angle = 0;
	// Use this for initialization
	void Start () {

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
			Debug.Log("Wall collision...");
		}
		else Destroy(gameObject);
	}
}