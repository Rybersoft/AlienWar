using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonFunctions : MonoBehaviour {

	public Canvas pauseMenu;
	gameController Control11;
	public Slider volSlider;
	playerController player11;
	// Use this for initialization
	void Start () {
		volumeManager ();
		
	}
	
	// Update is called once per frame
	void Update () {								
		
	}


	public void exit(){																			//To execute when exit button is pressed
		Application.Quit ();
	}

	public void pause(){
		if (Time.timeScale == 1.0f) {
			Time.timeScale = 0.0f;
			pauseMenu.scaleFactor = 1;
		}

				
			}
	public void resume(){
		if (Time.timeScale == 0.0f) {
			Time.timeScale = 1.0f;
			pauseMenu.scaleFactor = 0;
		}
	}

	public void giveReward(){
		
		GameObject gameControllerObject= GameObject.FindWithTag("GameController");
		if (gameControllerObject != null) 
		{
			Control11 = gameControllerObject.GetComponent<gameController>();
		}
		if(gameControllerObject==null)
			Debug.Log("Can't Find 'GameControl' Script");															//attach gamecontroller script to Control11

		GameObject playerControllerObject= GameObject.FindWithTag("Player");
		if (playerControllerObject != null) 
		{
			player11 = playerControllerObject.GetComponent<playerController>();
		}
		if(playerControllerObject==null)
			Debug.Log("Can't Find 'player' Script");																//attach player script to player11
		

		Control11.lifeUp ();
		player11.powerShot ();
	}


	public void volumeManager(){
		AudioListener.volume = volSlider.value;
	}


}
