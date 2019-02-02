using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {

	public GameObject myEnemyObj;

	// Use this for initialization
	void Start () {
		myEnemyObj = GameObject.Find ("EnemyDestructionPoint");
	}
	
	// Update is called once per frame
	void Update () {
		//
		if(transform.position.x < myEnemyObj.transform.position.x){
			//Destroy (gameObject);

			gameObject.SetActive (false); 
		}

	}
}
