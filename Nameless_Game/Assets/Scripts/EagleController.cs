using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleController : MonoBehaviour {

	Rigidbody rb;
	public float speed = 500f;	
	GameObject player;
	PlayerHealth playerHealth;
	public int dameg = 20;
	GameControler gameControler;
	float timer = 0f;

	bool IsTame;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		rb = GetComponent<Rigidbody> ();
		playerHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ();	
		gameControler = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameControler> ();
		Vector3 ves = transform.position - player.transform.position;
		if (ves.magnitude <= 2f) {
			IsTame = true;
		} else {
			IsTame = false;

		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		timer += Time.deltaTime;
		if (IsTame) {
			rb.velocity = transform.forward * Time.deltaTime * speed;
			Debug.Log ("IsTame = true");
		} else {
			Vector3 vec = player.transform.position - transform.position;
			transform.rotation = Quaternion.LookRotation (vec);
			rb.velocity = transform.forward * Time.deltaTime * speed;

			if (Input.GetKeyDown (KeyCode.E) && vec.magnitude <= 4) {
				Destroy (gameObject);
				gameControler.CatchEagle ();
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player") && timer >= 0.2f) {
			playerHealth.TakeDamage (dameg);
			Destroy (gameObject);
		} else if ((other.gameObject.CompareTag ("N")
		           || other.gameObject.CompareTag ("S")
		           || other.gameObject.CompareTag ("W")
		           || other.gameObject.CompareTag ("E"))
		           && (timer >= 0.2f)) { 

			GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
			foreach (GameObject enemy in enemies)
				GameObject.Destroy (enemy);	
		}

	}
}
