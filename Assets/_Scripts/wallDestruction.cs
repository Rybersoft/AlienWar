using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallDestruction : MonoBehaviour {
	public int wallHealth=2;
	private gameController Control11;
	public int scoreIncrement;

	public GameObject asteroidExplosionVFX, playerExplosionVFX;

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
		if ((other.tag == "Boundary")||(other.tag=="enemy")) {
			return;
		} else {
			
			if (other.tag == "Player")
			{
				Instantiate (asteroidExplosionVFX, transform.position, transform.rotation);
				Instantiate (playerExplosionVFX, transform.position, transform.rotation);
				Control11.lifeDown ();
			}
			if (wallHealth > 0) {
				wallHealth -= 1;
				Destroy (other.gameObject);		//To destroy the bolt after collision
				return;
			}
			else
			Control11.addScore (scoreIncrement);
			Destroy (other.gameObject);
			Destroy (gameObject);
			Instantiate (asteroidExplosionVFX, transform.position, transform.rotation);
		}
	}
}
