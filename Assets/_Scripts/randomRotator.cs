using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomRotator : MonoBehaviour {

	public Rigidbody Asteroid;

	void Start () 
	{
		float tumble=Random.Range(5,10);
		Asteroid.angularVelocity = Random.insideUnitSphere * tumble;
	}

}
