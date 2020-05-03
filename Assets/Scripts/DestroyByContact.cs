using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

	private void Start()
	{
		GameObject gameControllerObj = GameObject.FindWithTag("GameController");
		if (gameControllerObj != null)
		{
			gameController = gameControllerObj.GetComponent<GameController>();
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
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}
		gameController.AddScore(scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
