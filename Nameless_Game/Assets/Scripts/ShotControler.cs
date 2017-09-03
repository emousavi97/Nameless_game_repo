using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotControler : MonoBehaviour {
	Rigidbody rb;
	public float speed=5f;
	float timer=0f;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.velocity = transform.forward * speed;
		timer += Time.deltaTime;
	}
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag ("Shot")) {
			Destroy (collision.gameObject);
			Destroy (gameObject);

		} else if (collision.gameObject.CompareTag ("E")) {
			
			Vector3 normalE = new Vector3 (-1f, 0f, 0f);
			Vector3 OutVec = Vector3.Reflect (transform.forward, normalE);
			transform.rotation = Quaternion.LookRotation (OutVec);
				
		} else if (collision.gameObject.CompareTag ("W")) {
					
			Vector3 normalW = new Vector3 (1f, 0f, 0f);
			Vector3 OutVec = Vector3.Reflect (transform.forward, normalW);
			transform.rotation = Quaternion.LookRotation (OutVec);

		} else if (collision.gameObject.CompareTag ("S")) {
					
			Vector3 normalS = new Vector3 (0f, 1f, 0f);
			Vector3 OutVec = Vector3.Reflect (transform.forward, normalS);
			transform.rotation = Quaternion.LookRotation (OutVec);

		} else if (collision.gameObject.CompareTag ("N")) {
					
			Vector3 normalN = new Vector3 (0f, -1f, 0f);
			Vector3 OutVec = Vector3.Reflect (transform.forward, normalN);
			transform.rotation = Quaternion.LookRotation (OutVec);

		} else if (collision.gameObject.CompareTag ("Player") && timer>0.2f) {
			Destroy (gameObject);
		}
	}

}
