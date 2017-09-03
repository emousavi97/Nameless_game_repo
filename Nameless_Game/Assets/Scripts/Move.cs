using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
	private Rigidbody rb;
	public float speede = 5f;
	public float jump_force = 400f;
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	

	void FixedUpdate () {
		float H = Input.GetAxis ("Horizontal");
		Vector3 move = new Vector3 (H*Time.deltaTime*speede, 0.0f, 0.0f);
		Vector3 jump = new Vector3 (0.0f, jump_force, 0.0f);
		rb.MovePosition (transform.position + move);
		if (Input.GetKeyDown ("space") && transform.position.y<-4){
			rb.AddForce (jump);
		} 
	}
}