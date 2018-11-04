using System.Collections;
using System.Collections.Generic;
using System ;
using UnityEngine;

public class Floater : MonoBehaviour {
	float startPos;
	public float startGrav = -0.2f;
	public float grav;
	public int delay = 0;
	public float acceleration = 0.005f;
	float NabsS;
	float absS;
	Vector3 direction;
	// Use this for initialization
	void Start () {
		direction = transform.rotation * Vector3.up;
		NabsS = -1 * (Mathf.Abs (startGrav) - acceleration / 2);
		absS = Mathf.Abs (startGrav) - acceleration / 2;
		grav += acceleration * -(grav / Mathf.Abs(grav));
	}

	// Update is called once per frame
	void Update () {
		if (delay <= 0) {
			transform.position += new Vector3((float)Math.Round((double)direction.x * grav, 5),  (float)Math.Round((double)direction.y * grav, 5),  (float)Math.Round((double)direction.z * grav, 5));
			grav += acceleration;
			if (grav <= NabsS || grav >= absS) {
				acceleration *= -1;
			}
		} else {
			delay--;
		}
	}
}
