using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiter : MonoBehaviour {
	public bool anticlockwise = false;
	Vector3 startPos;
	public float speed = 1;
	public float distance = 2;
	// Use this for initialization
	void Start () {
		startPos = transform.position;
		transform.position += transform.rotation * Vector3.up * distance;
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (startPos, Vector3.forward, speed * (anticlockwise ? 1: -1));
	}
}
