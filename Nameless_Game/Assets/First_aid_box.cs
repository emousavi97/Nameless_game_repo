using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_aid_box : MonoBehaviour {
	Rigidbody rb;
	public float speed=500f;
	PlayerHealth playerHealth;
	public int HealAmount;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		Vector3 vec = new Vector3 (0f, -1f, 0f);
		transform.rotation = Quaternion.LookRotation (vec);
		playerHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ();

	}

	// Update is called once per frame
	void Update () {
		rb.velocity = transform.forward * Time.deltaTime * speed;
	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("N")
			|| other.gameObject.CompareTag ("S")
			|| other.gameObject.CompareTag ("W")
			|| other.gameObject.CompareTag ("E")) {
			Destroy (gameObject);
		} else if (other.CompareTag ("Player")) {
			playerHealth.treatment (HealAmount);
			Destroy (gameObject);
		}
	}
}
