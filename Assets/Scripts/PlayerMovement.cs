using System.Collections;
using System.Collections.Generic;                     //Corn, heron on bugs, rabbits, billiard table
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
	// Use this for initialization
	bool grounded = false;
	Rigidbody2D rb;
	public GameObject Scythe;
	int timer = 0;
	int attackCooldown = 60;
	float rubberBounceVel;
	float health = 3;
	float currentLevel = 1;
	public Text healthText;
	public Text speedrunTimerText;
	Vector3 cpPos = new Vector3(0,0,0);
	Vector2 vel;
	float avel;
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		healthText.text = "Health: 3";
		SceneManager.LoadScene ("Stage1", LoadSceneMode.Additive);
		transform.position = GameObject.Find ("LevelStart").transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		RaycastHit2D rayHitDown = Physics2D.Raycast (transform.position, Vector2.down);
		RaycastHit2D rayHitLeft = Physics2D.Raycast (transform.position, Vector2.left);
		RaycastHit2D rayHitRight = Physics2D.Raycast (transform.position, Vector2.right);
		timer++;
		speedrunTimerText.text = "" + Time.frameCount;
		vel = rb.velocity;
		avel = rb.angularVelocity;

		if (Input.GetKey("d") && (rayHitRight.distance >= 0.55f || rayHitRight.distance == 0 || rayHitRight.collider.tag == "Box" || rayHitRight.collider.tag == "Water" || rayHitRight.collider.tag == "LevelEnd" || rayHitRight.collider.tag == "Key")) {
			transform.position += new Vector3 (0.1f, 0, 0);
		}
		if (Input.GetKey("a") && (rayHitLeft.distance >= 0.55f || rayHitLeft.distance == 0 || rayHitLeft.collider.tag == "Box" || rayHitLeft.collider.tag == "Water" || rayHitLeft.collider.tag == "LevelEnd" || rayHitRight.collider.tag == "Key")) {
			transform.position += new Vector3 (-0.1f, 0, 0);
		}
		if (Input.GetKey(KeyCode.Space) && grounded) {
			vel.y = 0;
			vel.y += 8;
		}
		if (Input.GetMouseButton (0) && timer > attackCooldown) {
			Scythe.GetComponent<ScytheController> ().Attack ();
			timer = 0;
		}
		if (Input.GetKeyDown("r")) {
			ChangeLevel ();
		}
		if (timer == 30) {
			Scythe.transform.position = new Vector2 (1000, 1000);
		}

		if (rayHitDown.collider.tag == "Lift" && rayHitDown.distance <= 10.5f) {
			vel.y += 0.3f;
		}
		vel.x *= 0.95f;
		if (vel.y < -0.1f && rayHitDown.distance < Mathf.Abs(vel.y / 10) && rayHitDown.collider.tag != "Water" && rayHitDown.collider.tag != "LevelEnd" && rayHitDown.collider.tag != "Key") {
			vel.y *= 0.1f;
			transform.position -= new Vector3 (0, rayHitDown.distance - 0.45f, 0);
		}
		rb.velocity = vel;
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.collider.GetType() == typeof(EdgeCollider2D)) {
			grounded = true;
		}
		if (col.collider.tag == "Enemy" || col.collider.tag == "StageHazard") {
			takeDamage ();
		}
	}
	void OnCollisionStay2D(Collision2D col) {
		if (col.collider.GetType() == typeof(EdgeCollider2D)) {
			grounded = true;
		}
	}
	void OnCollisionExit2D() {
		grounded = false;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Water" && rb.drag == 0) {
			rb.drag += 5;
		}
		if (col.tag == "Rubber" && rb.velocity.y < 0) {
			rubberBounceVel = -rb.velocity.y * 0.9f;
		}
		if (col.tag == "Rotateror") {
			transform.Rotate (Vector3.forward * -90);
		}
		if (col.tag == "LevelEnd") {
			ChangeLevel ();
		}

		if (col.tag == "Enemy" || col.tag == "StageHazard") {
			takeDamage ();
		}
	}
	void OnTriggerStay2D(Collider2D col) {
		if (col.tag == "Water") {
			grounded = true;
		}
		if (col.tag == "Rubber") {
			rb.AddForce (new Vector2 (0, rubberBounceVel), ForceMode2D.Impulse);
			rubberBounceVel = 0;
		}
	}
	void OnTriggerExit2D() {
		grounded = false;
		if (rb.drag == 5) {
			rb.drag -= 5;
		}
	}
	void takeDamage() {
		health--;
		SceneManager.UnloadSceneAsync ("Stage" + currentLevel);
		SceneManager.LoadSceneAsync ("Stage" + currentLevel, LoadSceneMode.Additive);
		transform.position = cpPos;
		transform.rotation = Quaternion.LookRotation (transform.forward);
		rb.angularVelocity = 0;
		healthText.text = "Health: " + health;
		if (health <= 0) {
			Destroy (gameObject);
		}
	}
	void ChangeLevel() {
		SceneManager.UnloadSceneAsync ("Stage" + currentLevel);
		currentLevel++;
		SceneManager.LoadSceneAsync ("Stage" + currentLevel, LoadSceneMode.Additive);
		transform.position = GameObject.Find ("LevelStart").transform.position; // Loads LevelStart in current scene becuz reasons
		cpPos = GameObject.Find ("LevelStart").transform.position;
		transform.rotation = new Quaternion (0, 0, 0, 0);
		rb.angularVelocity = 0;
	}
}
