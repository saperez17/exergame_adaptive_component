using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtr : MonoBehaviour {

	public float speedMultiplier;
	private float moveSpeedStore;

	public float speedIncreaseMilestone;
	public float speedIncreaseMilestoneStore;
	private float speedMilestoneCount;
	private float speedMilestoneCountStore;


	FlyingPlayer player;
	public Rigidbody2D rgb;
	public Transform tr;
	public Animator myAnim;

	public float maxVel = 5f;
	private int state;
	private int transition;
	private float upperLim;
	public float centerPos;
	private float buttomLim;

	public GameManager theGameManager;

	public AudioSource wingSound;
	public AudioSource deathSound;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<FlyingPlayer> ();
		state = 0;
		centerPos = tr.position.y;
		upperLim = centerPos + 1.3f;
		buttomLim = centerPos - 1.3f;
		speedMilestoneCount = speedIncreaseMilestone;
		player.setVel (maxVel);

		//rgb = GetComponent<Rigidbody2D> ();
		//tr = GetComponent<Transform> ();
		moveSpeedStore = player.getVel();
		speedMilestoneCountStore = speedMilestoneCount;
		speedIncreaseMilestoneStore = speedIncreaseMilestone;
	}
	
	// Update is called once per frame
	void Update () {
		
		//Debug.Log ("state: " + state + " transition: " + transition);
		if (Input.GetKeyDown ("up")) {
			switch (state) {
			case 0:
				transition = 1;
				break;
			case 1:
				transition = 5;
				break;
			case 2: 
				transition = 4;
				break;
			}
		}

		if (Input.GetKeyDown ("down")) {
			switch (state) {
			case 0:
				transition = 2;
				break;
			case 1:
				transition = 3;
				break;
			case 2:
				transition = 6;
				break;
			}
		}

		//
	}
	void FixedUpdate(){

		movePlayer ();
		player.setPosX (player.transform.position.x);
		if (player.getPosX() > speedMilestoneCount) {
			speedMilestoneCount += speedIncreaseMilestone;
			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;

			player.setVel (player.getVel () * speedMultiplier);
			//Debug.Log (player.getVel ());
		}
		rgb.velocity = new Vector2 (player.getVel(), 0);

		//Check player's velocity so flying animation is activated (or disabled)
		myAnim.SetFloat("speed",rgb.velocity.x);
	
	}

	public void movePlayer(){
		//

		if (state == 0) {
			if (transition == 1) {
				if (tr.position.y < upperLim) {
					tr.Translate (Vector3.up * maxVel * Time.deltaTime, Space.World);
					wingSound.Play();
				} else {
					state = 1;
					transition = 5;
				}
			} else if (transition == 2) {
				if (tr.position.y > buttomLim) {
					tr.Translate (Vector3.down * maxVel * Time.deltaTime, Space.World);
					wingSound.Play();
				}
					
				else {
					state = 2;
					transition = 6;
				}
					
			} else
				transition = 7;
		} else if (state == 1) {
			if (transition == 3) {
				if (tr.position.y > centerPos) {
					tr.Translate (Vector3.down * maxVel * Time.deltaTime, Space.World);
					wingSound.Play();
				}
					
				else {
					state = 0;
					transition = 7;
				}
			} else {
				transition = 5;
			}
		} else if (state == 2) {
			if (transition == 4) {
				if (tr.position.y < centerPos) {
					wingSound.Play ();
					tr.Translate (Vector3.up * maxVel * Time.deltaTime, Space.World);
				}
					
				else {
					state = 0;
					transition = 7;
				}
			} else
				transition = 6;
		} 
			
	}


	void OnCollisionEnter2D(Collision2D other){
		Debug.Log ("Enter OnCollisionEnter2D method");
		if (other.gameObject.tag == "killenemy") {
			deathSound.Play ();
			theGameManager.RestartGame ();
			player.setVel (moveSpeedStore);
			speedMilestoneCount = speedMilestoneCountStore;
			speedIncreaseMilestoneStore = speedIncreaseMilestone;
		}
	}


}
