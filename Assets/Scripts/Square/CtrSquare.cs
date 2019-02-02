using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrSquare : MonoBehaviour {


	Rigidbody2D rgb;

	public float maxVel = 6.0f;
	float v;
	// Use this for initialization
	void Start () {
		rgb = GetComponent<Rigidbody2D> ();

		Vector2 vel = new Vector2 (0, rgb.velocity.y);
		vel.x = -maxVel;
		rgb.velocity = vel;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		v = Input.GetAxis ("Horizontal");
			
	}


	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name.Equals ("leftBoundarie")) {
			//Debug.Log ("You touched left-side limit");
			move_to_right ();
		} else if (other.gameObject.name.Equals ("rightBoundarie")) {
			//Debug.Log ("You touched right-side limit");
			move_to_left ();
		}
		else
			Debug.Log ("no limit touched");
	}

	void OnTriggerExit2D(Collider2D other){
		
	}


	void move_to_left(){
		Debug.Log ("Moving to left side");
		Vector2 vel = new Vector2 (0, rgb.velocity.y);
		vel.x = -maxVel;
		rgb.velocity = vel;

	}

	void move_to_right(){
		Debug.Log ("Moving to right side");
		Vector2 vel = new Vector2 (0, rgb.velocity.y);
		vel.x = maxVel;
		rgb.velocity = vel;
		
	}

}
