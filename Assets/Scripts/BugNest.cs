using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugNest : MonoBehaviour {
	public GameObject Bug;
	float timer = 0;
	float delay;
	void Start() {
		delay = Random.Range(90,180);
	}
	// Update is called once per frame
	void Update () {
		timer++;
		if (timer >= delay) {
			timer = 0;
			delay = Random.Range (90, 180);
			GameObject curBug = Instantiate (Bug);
			curBug.transform.SetParent (gameObject.transform);
			curBug.transform.localPosition = new Vector2 (0, 0);
			float randomf = Random.Range(0,1);
			if (randomf == 1) {	
				curBug.GetComponent<Walker> ().direction = 0.1f;
			} else {
				curBug.GetComponent<Walker> ().direction = -0.1f;
			}
		}
	}
}
