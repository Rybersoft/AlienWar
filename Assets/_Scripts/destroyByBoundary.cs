using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyByBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other)
	{
		if (other.tag=="Player")
			return;
		else
		Destroy (other.gameObject);
	}
}
