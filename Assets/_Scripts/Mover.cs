using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
	public Rigidbody body;
	public float speed;
	void Start()
	{
		body.velocity = transform.forward * speed;
	}
}
