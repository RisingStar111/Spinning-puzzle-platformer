using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D col) {
		if(col.tag == "Player") {
			if (gameObject.tag == "Key") {
				foreach(Transform door in transform){
					if (door.tag == "KeyDoor") {	
						door.position = new Vector3 (1000, 1000, 0);
					}
				}
			}
			Destroy (gameObject);
		}
	}
}
