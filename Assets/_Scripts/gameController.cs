using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour {

	int score;
	public GameObject[] hazards;
	GameObject hazard;
	public GameObject playerShip;
	public Vector3 spawnValues;
	public int hazardCount;
	public int level;
	public int lifeCount;
	public float startWait;
	public float spawnWait;

	//Text Systems//
	public Text scoreText;
	public Text lifeText;
	public Text restartText;
	public Text gameOverText;
	public Text levelText;
	//Text Systems//

	public bool gameover = false, restart = false;

	void Start () 
	{
		gameOverText.text = "";
		restartText.text = "";
		score = 0;
		lifeCount = 2;
		level = 1;
		UpdateScore ();
		lifeText.text = ":" + lifeCount;
		levelText.text = ": " + level;
		Instantiate (playerShip,transform.position,transform.rotation);
		StartCoroutine(SpawnWaves ());

	}

	void Update()
	{
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

		IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait); 
		while (true) {
			
			for (int i = 0; i < hazardCount; ++i) {
				if (level < hazards.Length) {														//Reveals the enemy types with level
					hazard = hazards [Random.Range (0, (level-1))];
				} else {
					hazard = hazards [Random.Range (0, hazards.Length)];
				}
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				addScore (1);	//To increase score by 1 for every asteroid launched//
				if (gameover)
					break;     //To end loop as soon as player is hit//
				yield return new WaitForSeconds (spawnWait); 
			}
			yield return new WaitForSeconds (spawnWait);
			if (gameover) {
				restartText.text = "Press 'R' To Restart";
				restart = true;
				break;
			}
			StartCoroutine(levelUp ());
			hazardCount += 20;
		}
	}
	public void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	public void addScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	public void GameOver()
	{	
		gameOverText.text = "Game Over!";
		gameover=true;	
	}
	IEnumerator levelUp(){
		level++;
		levelText.text = ":"+level;
		gameOverText.text = "Level Up!";							//We will use the gameovertextbox to display the level up notification.
		yield return new WaitForSeconds (spawnWait);
		gameOverText.text = "";
		spawnWait = spawnWait - spawnWait * 0.15f;


	}


	public void lifeUp(){
		lifeCount++;
		lifeText.text = ":" + lifeCount;
	}


	public void lifeDown(){
		if (lifeCount > 0) {
			lifeCount--;
			Instantiate (playerShip, transform.position, transform.rotation);
			lifeText.text = ":" + lifeCount;
		}
		else
			GameOver ();
	
	}
}