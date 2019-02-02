using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {

	private Material backgroundMaterial;
	private Vector2 offset;
	private Vector3 lastPlayerPos;
	private FlyingPlayer playerCtr; 
	private float distanceToMove;

	public float xVelocity, yVeclocity;

	// Use this for initialization
	void Start () {
		//offset = new Vector2 (xVelocity, yVeclocity);
		playerCtr = FindObjectOfType<FlyingPlayer>();
		lastPlayerPos = playerCtr.transform.position;


	}
	
	// Update is called once per frame
	void FixedUpdate () {
		offset = new Vector2 (xVelocity, yVeclocity);
		backgroundMaterial.mainTextureOffset += offset;

		distanceToMove = playerCtr.transform.position.x - lastPlayerPos.x;
		transform.position = new Vector3 (transform.position.x + distanceToMove, transform.position.y, transform.position.z);
		lastPlayerPos = playerCtr.transform.position;

	}

	private void Awake(){
		backgroundMaterial = GetComponent<Renderer> ().material;
	}
}
