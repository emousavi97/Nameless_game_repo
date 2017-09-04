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
	public Color damageflashColour = new Color(1f, 0f, 0f, 0.1f);
	public Color treatmentflashColour = new Color(0f, 1f, 0f, 0.1f);

	public Text restart;


	Move Move;
	Fire Fire;
	GameControler gameControler;
	bool isDead;
	bool damaged;
	bool istreatment;

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
			damageImage.color = damageflashColour;
		}
		else
		{
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;




		if(istreatment)
		{
			damageImage.color = treatmentflashColour;
		}
		else
		{
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		istreatment = false;


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

	public void treatment(int amount){
		currentHealth += amount;
		istreatment = true;
		healthSlider.value = currentHealth;
		if (currentHealth > 100) {
			currentHealth = 100;
		}

	}
}
