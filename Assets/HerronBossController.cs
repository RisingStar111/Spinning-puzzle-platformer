using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerronBossController : MonoBehaviour {
	float timer = 0;
	float timer2 = 0;
	float attackTimer = 0;
	public float attackDelay = 600;
	
	// Update is called once per frame
	void Update () {
		attackTimer++;
		RaycastHit2D rayHitDown = Physics2D.Raycast (transform.position, Vector2.down, Mathf.Infinity, 1);
		if (attackTimer < attackDelay) {
			timer++;
			timer2 += 0.77f;
			transform.position = new Vector3 (Mathf.Sin(timer2/140) * 30, Mathf.Sin (timer/20) * 2 + 11, 0);
		}
		else if (attackTimer >= attackDelay) {
			StartCoroutine (HeronAttack());
		}
	}
	IEnumerator HeronAttack() {
		attackTimer = 0;
		RaycastHit2D rayHitDown = Physics2D.Raycast (transform.position, Vector2.down, Mathf.Infinity, 1);
		float rayDist = rayHitDown.distance;
		Debug.Log (rayDist);
		while (rayHitDown.distance > 0.5f) {
			transform.position += new Vector3(0,-0.2f,0);
		}
		while (rayHitDown.distance < rayDist) {
			transform.position += new Vector3(0,0.2f,0);
		} return null;
	}
}
