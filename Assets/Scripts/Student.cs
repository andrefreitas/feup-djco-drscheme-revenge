using UnityEngine;
using System.Collections;

public class Student : MonoBehaviour {

	public float moveDistance = 0.1f;
	public float rotationAngle = 1f;

	public float xMin = -5.9f;
	public float xMax = 5.9f;
	public float maxRotationAngle = 45f;

	public string keyRotateLeft = "a";
	public string keyRotateRight = "d";
	public string keyShoot = "w";
	public string keyMoveLeft = "left";
	public string keyMoveRight = "right";
	public float currentAngle = 0;
	public GameObject bulletObj;
	public long timer = 20;
	public long deltaTimeToBullet = 20;
	public float force = 150f;

	public GameObject gun;
	public GameObject bulletRef;

	// Use this for initialization
	void Start () {
		gun = GameObject.Find("Gun");
		bulletRef = (GameObject) Instantiate(bulletObj, gun.transform.position, gun.transform.rotation);
		bulletRef.transform.parent = gun.transform;
		bulletRef.transform.localScale -= new Vector3 (0.6f, 0.2f, 0.6f);
		bulletRef.transform.position += new Vector3(0, 1f, 0);
		bulletRef.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		timer--;
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

		else if (Input.GetKey(keyRotateRight) && (currentAngle > -maxRotationAngle) ) {
			gun.transform.Rotate(0, 0, -rotationAngle);
			currentAngle -= rotationAngle;
		}

		if (Input.GetKey (keyShoot) && timer <= 0) {
			GameObject instance1 = (GameObject) Instantiate(bulletRef, bulletRef.transform.position, bulletRef.transform.rotation);
			instance1.SetActive(true);

			float angleRad = (Mathf.PI * currentAngle) / 180;
			float x = - Mathf.Sin(angleRad) * force;
			float y = Mathf.Cos(angleRad) * force;

			instance1.rigidbody.AddForce(new Vector3(x, y, 0));
			timer = deltaTimeToBullet;
		}

	}
}
