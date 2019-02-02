using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText;

	public float scoreCount;
	public float hiScoreCount;

	public float pointsPerScond;

	public bool scoreIncreasing;

	private float normalPointsPerSecond;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey("HighScore")) {
			hiScoreCount = PlayerPrefs.GetFloat ("HighScore");
		}
	}
	
	// Update is called once per frame

	void Update () {
		if (scoreIncreasing) {
			scoreCount += pointsPerScond * Time.deltaTime;
		}



		scoreText.text = "Score: " + Mathf.Round(scoreCount);
		highScoreText.text = "Puntaje mas alto: " + Mathf.Round(hiScoreCount);

		if (scoreCount > hiScoreCount) {
			hiScoreCount = scoreCount;
			PlayerPrefs.SetFloat ("HighScore", hiScoreCount);
		}
		
	}

	public void AddScore(int pointsToAdd){
		scoreCount += pointsToAdd;
	}
}
