using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
	private Rigidbody rb;
	public float speede = 5f;
	public float jump_force = 400f;
	void Start () {
		rb = GetComponent<Rigidbody> ();
		//rb.useGravity = true;
	}
	

	void FixedUpdate () {
		if (transform.position.y <= -4.5f && rb.velocity.y != 0) {
			rb.useGravity = false;
			Vector3 vec = new Vector3 (0f, 0f, 0f);
			rb.velocity = vec;
		}

		float H = Input.GetAxis ("Horizontal");
		Vector3 move = new Vector3 (H*Time.deltaTime*speede, 0.0f, 0.0f);
		if ((transform.position.x <= 8.4f && transform.position.x >= -8.4f)||(transform.position.x < -8.4f && H>0)||(transform.position.x > 8.4f && H<0 )) {
			rb.MovePosition (transform.position + move);
		}

		if (Input.GetKeyDown ("space") && transform.position.y<-4){
			Vector3 jump = new Vector3 (0.0f, jump_force, 0.0f);
			rb.useGravity = true;
			rb.AddForce (jump);
		} 
	}
}