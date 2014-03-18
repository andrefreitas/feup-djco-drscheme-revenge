using UnityEngine;
using System.Collections;

public class Protection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.name == "BigCourse(Clone)" ||
		    col.gameObject.name == "MediumCourse(Clone)" ||
		    col.gameObject.name == "SmallCourse(Clone)") {
			Destroy(gameObject);
		}
	}
}
