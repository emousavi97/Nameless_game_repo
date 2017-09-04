using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthSlider;
	public Image damageImage;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	public Text restart;


	Move Move;
	Fire Fire;
	GameControler gameControler;
	bool isDead;
	bool damaged;


	void Awake ()
	{
		Move = GetComponent <Move> ();
		Fire = GetComponentInChildren <Fire> ();
		currentHealth = startingHealth;
		restart.text = "";
		gameControler = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameControler> ();
	}


	void Update ()
	{
		if(damaged)
		{
			damageImage.color = flashColour;
		}
		else
		{
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;

		if (isDead && Input.GetKeyDown(KeyCode.R)) {
			RestartLevel ();
		}
	}


	public void TakeDamage (int amount)
	{
		damaged = true;

		currentHealth -= amount;

		healthSlider.value = currentHealth;


		if(currentHealth <= 0 && !isDead)
		{
			Death ();
		}
	}


	void Death ()
	{
		isDead = true;
		Move.enabled = false;
		Fire.enabled = false;
		gameControler.enabled = false;


		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach(GameObject enemy in enemies)
			GameObject.Destroy(enemy);	
		
		restart.text = "Press 'R' to restart";
	}


	public void RestartLevel ()
	{
		SceneManager.LoadScene (0);
	}
}
