using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberFire : MonoBehaviour {
	public GameObject bomb;
	public float timebtwn=0.5f;
	float timer = 1.5f;
	// Use this for initialization
	/*void Start () {
		
	}*/
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= timebtwn) {
			timer = 0f;
			Instantiate (bomb, transform.position, transform.rotation);
		}
	}
}
