using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour {

	private gameController Control11;
	private playerController playerController;



	void Start()
	{
		GameObject gameControllerObject= GameObject.FindWithTag("GameController");
		if (gameControllerObject != null) 
		{
			Control11 = gameControllerObject.GetComponent<gameController>();
		}
		if(gameControllerObject==null)
			Debug.Log("Can't Find 'GameControl' Script");

	
		GameObject playerControllerObject= GameObject.FindWithTag("Player");
		if (playerControllerObject != null) 
		{
			playerController = playerControllerObject.GetComponent<playerController>();
		}
		if(gameControllerObject==null)
			Debug.Log("Can't Find 'GameControl' Script");
	
	
	}

	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider other)
	{
		if ((other.tag == "Boundary") || (other.tag == "enemy") || (other.tag == "pickUp") || (other.tag == "powerFire")||(other.tag == "PlayerFire")) {
			return;
		} else if (gameObject.tag == "lifePickup") {
			Control11.lifeUp ();
			Destroy (gameObject);
		} else if (gameObject.tag == "powerShotPickup") {

			Destroy (gameObject);
			playerController.powerShot ();
		}
	}
}