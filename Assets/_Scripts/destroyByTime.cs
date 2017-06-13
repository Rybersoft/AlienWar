using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyByTime : MonoBehaviour {

	float lifetime= 2.0f; 
	void Start()
	{
		Destroy (gameObject, lifetime);
	}

}
