using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPoints : MonoBehaviour {

	public int scoreToGive;

	private ScoreManager theScoreManager;

	private AudioSource pointSound;

	// Use this for initialization
	void Start () {
		theScoreManager = FindObjectOfType<ScoreManager> ();
		pointSound = GameObject.Find ("PointSound").GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "PlayerCharacter") {
			theScoreManager.AddScore (scoreToGive);
			gameObject.SetActive (false);
			if (pointSound.isPlaying) {
				pointSound.Stop ();
				pointSound.Play ();
			}else
				pointSound.Play ();
				
			
		}
	}

}
