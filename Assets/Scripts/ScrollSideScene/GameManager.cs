
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Transform enemyGenerator;
	private Vector3 enemyStartPoint;

	public PlayerCtr thePlayer;
	private Vector3 playerStartPoint;

	private PlatformDestroyer[] platformList;

	private ScoreManager theScoreManager;
	private BackgroundManager theBackgroundManager;

	public DeathMenu theDeathScreen;

	public bool powerupReset;

	// Use this for initialization
	void Start () {
		enemyStartPoint = enemyGenerator.position;
		playerStartPoint = thePlayer.transform.position;

		theScoreManager = FindObjectOfType<ScoreManager> ();
		theBackgroundManager = FindObjectOfType<BackgroundManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RestartGame(){
		theScoreManager.scoreIncreasing = false;
		thePlayer.gameObject.SetActive (false);
		//StartCoroutine ("RestartGameCo");
		theDeathScreen.gameObject.SetActive(true);
	}

	public void Reset(){
		theDeathScreen.gameObject.SetActive(false);
		platformList = FindObjectsOfType<PlatformDestroyer> ();
		for (int i = 0; i < platformList.Length; i++) {
			platformList [i].gameObject.SetActive (false);
		}
		thePlayer.transform.position = playerStartPoint;
		enemyGenerator.position = enemyStartPoint;
		thePlayer.gameObject.SetActive (true);
		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;

		powerupReset = true;
		theBackgroundManager.changeBackground ();

	}


	//create co-rutine
	/*
	public IEnumerator RestartGameCo(){
		theScoreManager.scoreIncreasing = false;
		thePlayer.gameObject.SetActive (false);
		yield return new WaitForSeconds (0.5f);
		platformList = FindObjectsOfType<PlatformDestroyer> ();
		for (int i = 0; i < platformList.Length; i++) {
			platformList [i].gameObject.SetActive (false);
		}
		thePlayer.transform.position = playerStartPoint;
		enemyGenerator.position = enemyStartPoint;
		thePlayer.gameObject.SetActive (true);
		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;
	}
	*/


}
