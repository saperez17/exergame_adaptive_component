using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour {

	private bool doublePoints;

	private bool powerupActive;

	private float powerupLengthCounter;

	private ScoreManager theScoreManager;
	private GameManager theGameManager;

	private float normalPointsPerSecond;


	// Use this for initialization
	void Start () {
		theScoreManager = FindObjectOfType<ScoreManager>();
		theGameManager = FindObjectOfType<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (powerupActive) {
			powerupLengthCounter -= Time.deltaTime;

			if (theGameManager.powerupReset) {
				powerupLengthCounter = 0;
				theGameManager.powerupReset = false;
			}
			if(doublePoints){
				theScoreManager.pointsPerScond = normalPointsPerSecond * 2;
				
			}


			if(powerupLengthCounter <= 0){
				theScoreManager.pointsPerScond = normalPointsPerSecond;
				powerupActive = false;
			}
		}

	}

	public void ActivatePowerup(bool points, float time){
		doublePoints = points;
		time = powerupLengthCounter;

		normalPointsPerSecond = theScoreManager.pointsPerScond;

		powerupActive = true;

	}
}
