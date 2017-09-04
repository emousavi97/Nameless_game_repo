using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControler : MonoBehaviour {
	
	public GameObject  one, two, three, four, five, six;
	public GameObject bomber;
	public GameObject Healer;
	public Text pnt_txt;
	float timer = 0;
	public float timebtwn = 5f;
	int points=0;
	// Use this for initialization
	void Start () {
		pnt_txt.text="0";
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= timebtwn) {
			timer = 0f;
			int rand = Random.Range (1, 11);
			if (rand < 6) {
				Make (Healer);
			} else {
				Make (bomber);
			}
		}

	}
	void Make(GameObject enemy){
		
			int a = Random.Range (1, 7);

			switch (a) {
			case 1:
				Instantiate (enemy, one.transform.position, one.transform.rotation);
				break;
			case 2:
				Instantiate (enemy, two.transform.position, two.transform.rotation);
				break;
			case 3:
				Instantiate (enemy, three.transform.position, three.transform.rotation);
				break;
			case 4:
				Instantiate (enemy, four.transform.position, four.transform.rotation);
				break;
			case 5:
				Instantiate (enemy, five.transform.position, five.transform.rotation);
				break;
			case 6:
				Instantiate (enemy, six.transform.position, six.transform.rotation);
				break;
			default:
				break;

			}
	}
	public void PntCntr(int point){
		points += point;
		pnt_txt.text = points+"";
	}
}
