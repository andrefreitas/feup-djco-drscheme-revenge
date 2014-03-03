using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float force = 150f;

	// Use this for initialization
	void Start () {
		rigidbody.AddForce(new Vector3(0, force, 0));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col) {
		Destroy(gameObject);
	}
}