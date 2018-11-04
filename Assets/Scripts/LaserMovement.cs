using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : MonoBehaviour {
	Vector3 direction;
	float lifetime = 0;
	// Use this for initialization
	void Start () {
		direction = transform.rotation * Vector3.up * 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += direction;
		lifetime++;
		if (lifetime == 600) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag != "Player") {
			Destroy (gameObject);
		}
	}
}
