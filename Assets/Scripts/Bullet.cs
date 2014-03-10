using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public LayerMask collisionMask;
	private float speed = 15;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;
		
		if (Physics.Raycast(ray, out hit, Time.deltaTime * speed + .1f,collisionMask)) {
			Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
			float rot = 90 - Mathf.Atan2(reflectDir.y, reflectDir.x) * Mathf.Rad2Deg;
			transform.eulerAngles = new Vector3(0,rot,0);
		}
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.name == "LeftLimit" || col.gameObject.name == "RightLimit") {
			Debug.Log("Wall collision...");
		}
		else Destroy(gameObject);
	}
}