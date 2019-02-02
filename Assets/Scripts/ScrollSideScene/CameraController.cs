using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public FlyingPlayer playerCtr;


	private Vector3 lastPlayerPos;
	private float distanceToMove;

	void Start () {
		playerCtr = FindObjectOfType<FlyingPlayer> ();
		lastPlayerPos = playerCtr.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		distanceToMove = playerCtr.transform.position.x - lastPlayerPos.x;
		transform.position = new Vector3 (transform.position.x + distanceToMove, transform.position.y, transform.position.z);

		lastPlayerPos = playerCtr.transform.position;
	}
}
