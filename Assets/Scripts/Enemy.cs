using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float shootProbability = 0.3f;
	public float movementProbability = 0.1f;
	public float bounceProbability = 0.2f;
	public float signalProbability = 0.2f;

	public float speed = 5f;
	public float force = 4f;
	public int signal;

	public GameObject player;
	public GameObject ball;

	void Start () {
		Debug.Log ("Enemy!!");
		signal = 1;
	
	}
	

	void Update () {

		float randomNumber = Random.Range (0f, 1f);

		if (randomNumber < movementProbability) {
			Move ();
		}

		randomNumber = Random.Range (0f, 1f);
		if (randomNumber < shootProbability) {
			Shoot ();
		}
	
	}

	void Move() {
		float randomNumber = Random.Range (0f, 1f);
		if (randomNumber < signalProbability ) {
			signal *= -1;
		}
		rigidbody2D.AddForce(new Vector2(1, 0) * force * signal);

	}

	void Shoot() {
		float randomNumber = Random.Range (0f, 1f);
		if (randomNumber < signalProbability ) {
			signal *= -1;
		}
		rigidbody2D.AddForce(new Vector2(1, 0) * force * signal);
		
	}

}
