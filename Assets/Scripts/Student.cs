using UnityEngine;
using System.Collections;

public class Student : MonoBehaviour {

	public float moveDistance = 0.1f;
	public float rotationAngle = 1f; 

	public float xMin = -5.2f;
	public float xMax = 5.2f;
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

	public GameObject ship;
	public GameObject bulletRef;
	public GameObject audioObject;
	public AudioClip shotSound;
	public AudioClip shipExplosionSound;
	public int lifes = 3;

	// Use this for initialization
	void Start () {
		ship = GameObject.Find("Ship");
		audioObject = GameObject.Find ("AudioObject");
		bulletRef = (GameObject) Instantiate(bulletObj, ship.transform.position, ship.transform.rotation);
		bulletRef.transform.parent = ship.transform;
		/*bulletRef.transform.localScale -= new Vector3 (0.6f, 0.2f, 0.6f)*/;
		bulletRef.transform.position += new Vector3(0, 1f, 0);
		bulletRef.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		timer--;

		// Move Ship Left
		if (Input.GetKey (keyMoveLeft) && (transform.position.x > xMin)) {
			transform.Translate(Vector3.left * moveDistance);
		}

		// Move Ship Right
		else if (Input.GetKey (keyMoveRight) && (transform.position.x < xMax)) {
			transform.Translate(Vector3.right * moveDistance);
		}

		// Rotate Left
		if (Input.GetKey (keyRotateLeft) && (currentAngle < maxRotationAngle)) {
			ship.transform.Rotate(0, 0, rotationAngle);
			currentAngle += rotationAngle;
		}

		// Rotate Right
		else if (Input.GetKey(keyRotateRight) && (currentAngle > -maxRotationAngle) ) {
			ship.transform.Rotate(0, 0, -rotationAngle);
			currentAngle -= rotationAngle;
		}

		// Shoot
		if (Input.GetKey (keyShoot) && timer <= 0) {

			// Create Bullet
			GameObject instance1 = (GameObject) Instantiate(bulletRef, bulletRef.transform.position, bulletRef.transform.rotation);
			instance1.SetActive(true);
			float angleRad = (Mathf.PI * currentAngle) / 180;
			float x = - Mathf.Sin(angleRad) * force;
			float y = Mathf.Cos(angleRad) * force;
			instance1.rigidbody2D.AddForce(new Vector3(x, y, 0));
			timer = deltaTimeToBullet;

			// Play sound
			audioObject.audio.PlayOneShot(shotSound);

		}

	}

	public void decreaseLifes() {
		if (lifes > 0) {
			lifes--;
		}

		Debug.Log ("Lost a life!");
	}
	

	void OnCollisionEnter(Collision col) {
		decreaseLifes ();
		audioObject.audio.PlayOneShot(shipExplosionSound);

		if (lifes == 0) {
			Destroy (gameObject);
			Debug.Log ("Game Over!");
		}
		//audio.PlayOneShot(sound);
		//Destroy(gameObject);
	}
}
