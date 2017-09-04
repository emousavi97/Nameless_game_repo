using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControler : MonoBehaviour {
	int a;
	public GameObject  one, two, three, four, five, six;
	public GameObject bomber;
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
			a = Random.Range (1, 7);

			switch (a) {
			case 1:
				Instantiate (bomber, one.transform.position, one.transform.rotation);
				break;
			case 2:
				Instantiate (bomber, two.transform.position, two.transform.rotation);
				break;
			case 3:
				Instantiate (bomber, three.transform.position, three.transform.rotation);
				break;
			case 4:
				Instantiate (bomber, four.transform.position, four.transform.rotation);
				break;
			case 5:
				Instantiate (bomber, five.transform.position, five.transform.rotation);
				break;
			case 6:
				Instantiate (bomber, six.transform.position, six.transform.rotation);
				break;
			default:
				break;

			}
		}

	}
	public void PntCntr(int point){
		points += point;
		pnt_txt.text = points+"";
	}
}
