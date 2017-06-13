using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyByContact : MonoBehaviour {

	public GameObject asteroidExplosionVFX,playerExplosionVFX;
	private gameController Control11;
	public int scoreIncrement;

	void Start()
	{
		GameObject gameControllerObject= GameObject.FindWithTag("GameController");
		if (gameControllerObject != null) 
		{
			Control11 = gameControllerObject.GetComponent<gameController>();
		}
		if(gameControllerObject==null)
			Debug.Log("Can't Find 'GameControl' Script");
	}



	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary") {
			return;
		} else {
			Instantiate (asteroidExplosionVFX, transform.position, transform.rotation);
			if (other.tag == "Player")
			{
				Instantiate (playerExplosionVFX, transform.position, transform.rotation);
				Control11.GameOver ();
			}
			Control11.addScore (scoreIncrement);
			Destroy (other.gameObject);
			Destroy (gameObject);
			}
	}

}
