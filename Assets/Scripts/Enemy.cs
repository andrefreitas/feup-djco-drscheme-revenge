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

	public Sprite[] sprites = new Sprite[3];

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

	void OnCollisionEnter2D(Collision2D col) {
		string name = col.gameObject.name;

		if (name == "bullet") {
			Debug.Log("detetou");
			this.GetComponent<SpriteRenderer>().sprite = sprites[2];
			StartCoroutine(WaitExplosion());
		}
		
	}

	IEnumerator WaitExplosion()
	{
		while (true) {
			yield return new WaitForSeconds(0.3f);
			Destroy(gameObject);
		}

	}

}
