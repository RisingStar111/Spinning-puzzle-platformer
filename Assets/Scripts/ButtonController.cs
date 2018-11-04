using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {
	public List<Vector3> doorPositions;
	void Start() {
		foreach(Transform door in transform){
			if (door.tag == "ButtonDoor") {
				doorPositions.Add (door.position);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Box") {
			foreach(Transform door in transform){
				if (door.tag == "ButtonDoor") {	
					door.position = new Vector3 (1000, 1000, 0);
				}
			}
		}
	}
	void OnTriggerExit2D(Collider2D col) {
		if (col.tag == "Box") {
			int i = 0;
			foreach(Transform door in transform){
				if (door.tag == "ButtonDoor") {
					door.position = doorPositions [i];
					i++;
				}
			}
		}
	}
}
