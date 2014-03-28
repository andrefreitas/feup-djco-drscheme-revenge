using UnityEngine;
using System.Collections;

public class AllCourses : MonoBehaviour {

	public GameObject smallAlien;
	public GameObject mediumAlien;
	public GameObject bigAlien;
	
	public float limitLeft = -6f;
	public float limitRight = 2.2f;
	
	public float upRef = 4.5f;
	public float deltaWidth = 1f;
	public float deltaHeight = 0.8f;
	public long ellapsedTime = 0;
	public long changePeriod = 60;
	
	public bool side = true;
	public float deltaMove = 0.2f;
	public float deltaDown = 0.2f;
	public float zRef = -1.5f;
	//var moveSound : AudioClip;

	// Use this for initialization
	void Start () {
		/*
		int i = 0;
		
		for(i = 0; i < 11; i++) {
			GameObject instance1 = (GameObject) Instantiate(smallAlien, new Vector3(limitLeft + i*deltaWidth, upRef, zRef), transform.rotation);
			GameObject instance2 = (GameObject) Instantiate(mediumAlien, new Vector3(limitLeft + i*deltaWidth, upRef - deltaHeight, zRef), transform.rotation);
			GameObject instance3 = (GameObject) Instantiate(mediumAlien, new Vector3(limitLeft + i*deltaWidth, upRef - deltaHeight*2, zRef), transform.rotation);
			GameObject instance4 = (GameObject) Instantiate(bigAlien, new Vector3(limitLeft + i*deltaWidth, upRef - deltaHeight*3, zRef), transform.rotation);
			GameObject instance5 = (GameObject) Instantiate(bigAlien, new Vector3(limitLeft + i*deltaWidth, upRef - deltaHeight*4, zRef), transform.rotation);
			
			instance1.transform.parent = gameObject.transform;
			instance2.transform.parent = gameObject.transform;
			instance3.transform.parent = gameObject.transform;
			instance4.transform.parent = gameObject.transform;
			instance5.transform.parent = gameObject.transform;
		}
		*/
	}
	
	// Update is called once per frame
	void Update () {
		ellapsedTime++;
		
		if(ellapsedTime % changePeriod == 0) {
			
			if(side && transform.position.x >= limitRight) {
				side = false;
				transform.Translate(new Vector3(0, -deltaDown, 0));
				if(changePeriod > 30)
					changePeriod -= 3;
			}
			
			else if(!side && transform.position.x <= 0) {
				side = true;
				transform.Translate(new Vector3(0, -deltaDown, 0));
				if(changePeriod > 30)
					changePeriod -= 3;
			}
			
			else if(side)
				transform.Translate(new Vector3(deltaMove, 0, 0));
			
			else transform.Translate(new Vector3(-deltaMove, 0, 0));
			
			//AudioSource.PlayClipAtPoint(moveSound, Vector3(0, 23, -75));
			
		}
	}
}
