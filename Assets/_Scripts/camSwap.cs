using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camSwap : MonoBehaviour {
	public Camera cam1, cam2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClick(){
		if (cam1.isActiveAndEnabled == true) {
			cam2.gameObject.SetActive (true);
			cam1.gameObject.SetActive (false);
		} else if (cam1.isActiveAndEnabled == false){
			cam1.gameObject.SetActive (true);
			cam2.gameObject.SetActive (false);
					
		
		}
	}

}
