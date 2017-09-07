using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControler : MonoBehaviour {
	
	public GameObject  one, two, three, four, five, six;
	public GameObject bomber;
	public GameObject Healer;
	public GameObject Buffalo;
	public GameObject Eagle;
	public GameObject Bw, Be;
	public Text pnt_txt;
	public Text eagle_txt;
	float timer = 0f;
	float buffalo_timer=0f;
	public float timebtwn = 5f;
	public float buffalo_timebtwn = 5f;
	int MyEagles=0;
	int points=0;

	void Start () {
		pnt_txt.text="0";
		eagle_txt.text="0";
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		buffalo_timer += Time.deltaTime;

		if (buffalo_timer >= buffalo_timebtwn) {
			buffalo_timer = 0f;
			int b = Random.Range (1, 3);
			if (b == 1) {
				Instantiate (Buffalo, Bw.transform.position, Bw.transform.rotation);
			} else {
				Instantiate (Buffalo, Be.transform.position, Be.transform.rotation);
			}
		}


		if (timer >= timebtwn) {
			timer = 0f;
			int rand = Random.Range (1, 11);
			if (rand <= 2) {
				Make (Healer);
			} else if (rand > 2 && rand <= 8) {
				Make (bomber);
			} else {
				Make (Eagle);
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

	public void CatchEagle(){
		MyEagles++;
		eagle_txt.text = MyEagles + "";
	}

	public void ReleaseEagle(){
		if (MyEagles > 0) {
			MyEagles--;
			eagle_txt.text = MyEagles + "";
		}
	}

	public bool DoWeHaveEagle(){
		return (MyEagles != 0);
	}
}
