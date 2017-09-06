using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
	float timer = 0f;
	public float timebtwn = 0.3f;
	public GameObject shot;
	public GameObject shotspon;
	float camraylength = 100f;
	int floorMask; 
	public GameObject ganpivot;
	GameControler gameControler;
	public GameObject Eagle;


	void Awake(){
		floorMask = LayerMask.GetMask ("Floor");
		gameControler = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameControler> ();

	}
	

	void Update () {
		timer += Time.deltaTime;
		if (Input.GetButton ("Fire1") && timer >= timebtwn ) {
			Instantiate (shot, shotspon.transform.position, shotspon.transform.rotation);
			timer = 0f;
		}

		if (Input.GetKeyDown (KeyCode.F) && gameControler.DoWeHaveEagle ()) {
			gameControler.ReleaseEagle ();
			Instantiate (Eagle, shotspon.transform.position, shotspon.transform.rotation);
		}
		Turning ();
	}

	void Turning(){
		
		Ray CamRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit FloorHit;

		if (Physics.Raycast (CamRay, out FloorHit, camraylength, floorMask)) {

			Vector3 playerToMouse = FloorHit.point - ganpivot.transform.position;
			playerToMouse.z = 0f;

			ganpivot.transform.rotation = Quaternion.LookRotation (playerToMouse,transform.forward);

		}
	}
}
