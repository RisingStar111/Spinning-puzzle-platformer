using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour {
	public float direction = 0.1f;
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D rayHitLeft = Physics2D.Raycast (transform.position, Vector2.left);
		RaycastHit2D rayHitRight = Physics2D.Raycast (transform.position, Vector2.right);
		RaycastHit2D rayHitDown = Physics2D.Raycast (transform.position, Vector2.down);
		transform.position += new Vector3(direction,0,0);
		if ((direction == 0.1f && rayHitRight.distance <= 0.6 && rayHitRight.distance != 0) || (direction == -0.1f && rayHitLeft.distance <= 0.6 && rayHitLeft.distance != 0)) {
			direction *= -1;
		}else if (rayHitDown.distance == 0){
			direction *= -1;
			transform.position += new Vector3(direction * 3,0,0);
		}
	}
}
