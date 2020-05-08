using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;
	private HealthBarController healthBar;

	private void Start()
	{
		GameObject gameControllerObj = GameObject.FindWithTag("GameController");
		GameObject healthBarControllerObj = GameObject.FindWithTag("HealthBar");
		if (gameControllerObj != null)
		{
			gameController = gameControllerObj.GetComponent<GameController>();
		}
		if (healthBarControllerObj != null)
		{
			healthBar = healthBarControllerObj.GetComponent<HealthBarController>();
		}
		if (gameController == null)
		{
			Debug.Log("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log("collider other: " + other.name);
		if (other.tag == "Boundary" || other.tag == "Enemy") {
			return;
		}
		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}
		
		if (other.tag == "Player")
		{
			if (healthBar)
			{
				healthBar.onTakeDamage(10);
				if (healthBar.health <= 0)
				{
					Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
					gameController.GameOver();
					Destroy(other.gameObject);
				} 
			}
			
		}
		gameController.AddScore(scoreValue);
		Destroy (gameObject);
	}
}
