using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotControler : MonoBehaviour {
	Rigidbody rb;
	public float speed=5f;
	float timer=0f;
	PlayerHealth playerHealth;
	public int dameg;
	GameControler gameControler;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		playerHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ();
		gameControler = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameControler> ();

	}
	

	void FixedUpdate () {
		rb.velocity = transform.forward * Time.deltaTime * speed;
		timer += Time.deltaTime;
	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Shot")) {
			Destroy (other.gameObject);
			Destroy (gameObject);
			Debug.Log ("shot to shot");
		} else if (other.gameObject.CompareTag ("E")) {
			
			Vector3 normalE = new Vector3 (-1f, 0f, 0f);
			Vector3 OutVec = Vector3.Reflect (transform.forward, normalE);
			transform.rotation = Quaternion.LookRotation (OutVec);
				
		} else if (other.gameObject.CompareTag ("W")) {
					
			Vector3 normalW = new Vector3 (1f, 0f, 0f);
			Vector3 OutVec = Vector3.Reflect (transform.forward, normalW);
			transform.rotation = Quaternion.LookRotation (OutVec);

		} else if (other.gameObject.CompareTag ("S")) {
					
			Vector3 normalS = new Vector3 (0f, 1f, 0f);
			Vector3 OutVec = Vector3.Reflect (transform.forward, normalS);
			transform.rotation = Quaternion.LookRotation (OutVec);

		} else if (other.gameObject.CompareTag ("N")) {
					
			Vector3 normalN = new Vector3 (0f, -1f, 0f);
			Vector3 OutVec = Vector3.Reflect (transform.forward, normalN);
			transform.rotation = Quaternion.LookRotation (OutVec);

		} else if (other.gameObject.CompareTag ("Player") && timer > 0.2f) {
			
			Destroy (gameObject);
			playerHealth.TakeDamage (dameg);
			Debug.Log ("player");

		} else if (other.gameObject.CompareTag ("Enemy")) {
			
			Destroy (gameObject);
			Destroy (other.gameObject);
			gameControler.PntCntr (1);
		}
	}

}
