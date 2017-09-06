using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffaloController : MonoBehaviour {

	Rigidbody rb;
	public float speed = 500f;
	float timer = 0f;
	PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		playerHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ();

	}

	// Update is called once per frame
	void FixedUpdate () {
		rb.velocity = transform.forward * Time.deltaTime * speed;
		timer += Time.deltaTime;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("E") && timer>=0.5f) {

			Destroy (gameObject);

		} else if (other.gameObject.CompareTag ("W") && timer>=0.5f) {

			Destroy (gameObject);

		} else if(other.CompareTag("Player")){
			playerHealth.TakeDamage(20);
			Destroy(gameObject);
		}

	}
}
