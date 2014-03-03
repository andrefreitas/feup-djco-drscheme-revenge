using UnityEngine;
using System.Collections;

public class Student : MonoBehaviour {

	public float moveDistance = 0.1f;
	public float rotationAngle = 1f;

	public float xMin = -4.5f;
	public float xMax = 7.5f;
	public float maxRotationAngle = 45f;

	public string keyRotateLeft = "a";
	public string keyRotateRight = "d";
	public string keyShoot = "w";
	public string keyMoveLeft = "left";
	public string keyMoveRight = "right";
	public float currentAngle = 0;

	public GameObject gun;

	// Use this for initialization
	void Start () {
		gun = GameObject.Find("Gun");
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (keyMoveLeft)) {

			if(transform.position.x > xMin)
				transform.Translate(Vector3.left * moveDistance);

		} else if (Input.GetKey (keyMoveRight)) {

			if(transform.position.x < xMax)
				transform.Translate(Vector3.right * moveDistance);
		}

		if (Input.GetKey (keyRotateLeft) && (currentAngle < maxRotationAngle)) {
			gun.transform.Rotate(0, 0, rotationAngle);
			currentAngle += rotationAngle;
		}

		if (Input.GetKey(keyRotateRight) && (currentAngle > -maxRotationAngle) ) {
			gun.transform.Rotate(0, 0, -rotationAngle);
			currentAngle -= rotationAngle;
		}

	}
}
