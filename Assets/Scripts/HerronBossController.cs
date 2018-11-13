using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerronBossController : MonoBehaviour {
	float timer = 0;
	float timer2 = 0;
	float attackTimer = 0;
	public float height = 9;
	public float attackSpeed = 0.2f;
	public float attackDelay = 600;
	public float health = 18;
	float maxHealth;
	public GameObject healthBar;
	public Vector3 nextLvlPos = new Vector3(0,1,0);
	public GameObject nextLvlObj;
	public GameObject endScreen;

	void Start() {
		maxHealth = health;
	}

	// Update is called once per frame
	void Update () {
		attackTimer++;
		healthBar.transform.localScale = new Vector3(health * (5 / maxHealth), 0.2f, 0);
		if (health <= 0) {
			Instantiate (nextLvlObj, nextLvlPos, Quaternion.identity);
			endScreen.transform.localScale = new Vector3 (1, 1, 1);
			Destroy (gameObject);
		}
		else if (health > maxHealth) {
			health = maxHealth;
		}
		RaycastHit2D rayHitDown = Physics2D.Raycast (transform.position, Vector2.down, Mathf.Infinity, 1);
		if (attackTimer < attackDelay) {
			timer++;
			timer2 += 0.77f;
			transform.position = new Vector3 (Mathf.Sin(timer2/140) * 30, Mathf.Sin (timer/20) * 2 + height, 0);
			transform.rotation = Quaternion.Euler (0,0,Mathf.Sin(timer2/140) * Mathf.Sin (timer/20) * 100);
		}
		else if (attackTimer == attackDelay) {
			StartCoroutine (HeronAttack());
		}
	}
	IEnumerator HeronAttack() {
		RaycastHit2D rayHitDown = Physics2D.Raycast (transform.position, Vector2.down, Mathf.Infinity, 1);
		float rayDist = rayHitDown.distance;
		while (rayHitDown.distance > 0.5f) {
			rayHitDown = Physics2D.Raycast (transform.position, Vector2.down, Mathf.Infinity, 1);
			transform.position += new Vector3(0,-attackSpeed * 3,0);
			yield return new WaitForFixedUpdate ();
		}
		while (rayHitDown.distance < rayDist) {
			rayHitDown = Physics2D.Raycast (transform.position, Vector2.down, Mathf.Infinity, 1);
			transform.position += new Vector3(0,attackSpeed,0);
			yield return new WaitForFixedUpdate ();
		}
		attackTimer = 0;
		yield return null;
	}
	void OnCollisionEnter2D(Collision2D col) {
		if (col.collider.tag == "Enemy") {
			Destroy (col.gameObject);
			health++;
		}
	}
	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Scythe") {
			health -= 3;
		}
	}
}
