using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

[System.Serializable]
public class Boundary
{
	public float xMin,xMax,zMin,zMax;
}

public class playerController : MonoBehaviour {
	public Rigidbody shots;
	public Transform shotLocation;//For location where the shots will be fired//
	public Transform shotRotation;//To get zero rotation we will use background to get quternion value for rotation//
	public Rigidbody shipBody;
	public float speed;
	public float tiltSide,tiltFront;
	public float fireRate;
	private float nextFire;
	public Boundary boundary;

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movementTouch = new Vector3 (CnInputManager.GetAxis("Horizontal"),CnInputManager.GetAxis("Vertical"),0f);
		//  Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		// shipBody.velocity = movement * speed;				//To use for Keyboard only
		shipBody.velocity=movementTouch*speed;

		//To Clamp the ship in playfield starts//
		shipBody.position = new Vector3
			(
				Mathf.Clamp(shipBody.position.x, boundary.xMin,boundary.xMax),
				0.0f,
				Mathf.Clamp(shipBody.position.z, boundary.zMin,boundary.zMax)
			);//To Clamp the ship in playfield ends//
		shipBody.rotation = Quaternion.Euler (shipBody.velocity.z * tiltFront,0.0f, (shipBody.velocity.x * (-tiltSide)));
	}
	void Update()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shots, shotLocation.position, shotRotation.rotation);
		}
	}
}
