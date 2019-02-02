using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {

	public bool doublePoints;

	public float powerupLength;

	private PowerupManager thePowerupManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		thePowerupManager = FindObjectOfType<PowerupManager> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "PlayerCharacter") {
			thePowerupManager.ActivatePowerup (doublePoints, powerupLength);
		}
		gameObject.SetActive (false);
	}
}
