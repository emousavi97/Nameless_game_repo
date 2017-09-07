using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerController : MonoBehaviour {

	public GameObject First_aid_box;
	public float timebtwn=0.5f;
	float timer = 0f;
	public float destroy_after=5f;

	// Use this for initialization
	void Start () {
		
		Destroy (gameObject,destroy_after);
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= timebtwn) {
			timer = 0f;
			Instantiate (First_aid_box, transform.position, transform.rotation);
		}
	}
}
