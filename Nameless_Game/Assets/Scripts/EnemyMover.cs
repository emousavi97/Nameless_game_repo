using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {
	Rigidbody rb;
	public float speed = 5f;
	float timer = 0f;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.velocity = transform.forward * Time.deltaTime * speed;
		timer += Time.deltaTime;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("E") && timer>=0.5f) {

			Vector3 normalE = new Vector3 (-1f, 0f, 0f);
			Vector3 OutVec = Vector3.Reflect (transform.forward, normalE);
			transform.rotation = Quaternion.LookRotation (OutVec);

		} else if (other.gameObject.CompareTag ("W") && timer>=0.5f) {

			Vector3 normalW = new Vector3 (1f, 0f, 0f);
			Vector3 OutVec = Vector3.Reflect (transform.forward, normalW);
			transform.rotation = Quaternion.LookRotation (OutVec);

		}

	}
		
}
