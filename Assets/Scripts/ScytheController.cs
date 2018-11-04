using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheController : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localPosition != new Vector3(100,100,0)){
			transform.Rotate (new Vector3(0,0,-20));
		}
	}

	public void Attack () {
		transform.localPosition = new Vector2 (1, 0);
		transform.rotation = new Quaternion(0,0,0,0);
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.tag == "Enemy" || col.tag == "Destructible") {
			Destroy (col.gameObject);
		}
	}
}
