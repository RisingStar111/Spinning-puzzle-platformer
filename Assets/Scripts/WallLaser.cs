using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallLaser : MonoBehaviour {
	public float fireTimer = 0;
	public GameObject WallLaserLaser;
	Vector3 direction;
	// Use this for initialization
	void Start () {
		direction = transform.rotation * Vector3.up * 0.65f;
	}
	
	// Update is called once per frame
	void Update () {
		fireTimer++;
		if (fireTimer == 60) {
			Instantiate (WallLaserLaser, transform.position + direction, transform.rotation);
			fireTimer = 0;
		}
	}
}
