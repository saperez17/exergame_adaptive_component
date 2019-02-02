using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateScript : MonoBehaviour {

	// Use this for initialization
	public	List<string> feasibleStates;
	private string lastState;
	private EventScript myEventScript;
	private UpdateFn myUpdateFn;

	void Start () {
		feasibleStates = new List<string> (){ "on-hold","on-play"};
		lastState = feasibleStates [0];
		myEventScript = GetComponent<EventScript> ();
		myUpdateFn = FindObjectOfType<UpdateFn> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateState(string incomingEvent){
		if (string.Compare (lastState, feasibleStates [0]) == 0) {
			if (string.Compare (incomingEvent, myEventScript.feasibleEvents [0]) == 0) {
				Debug.Log ("Do nothing");
			} else if (string.Compare (incomingEvent, myEventScript.feasibleEvents [1]) == 0) {
				Debug.Log ("Play game button clicked");
				lastState = feasibleStates [1];
				myUpdateFn.HrDataTransferPermission (1);
			}/*
			else if (string.Compare (incomingEvent, myEventScript.feasibleEvents [3]) == 0) {
				Debug.Log ("user log out. Stop recording HR data.");
			}*/
		} else if (string.Compare (lastState, feasibleStates [1]) == 0) {

			if (string.Compare (incomingEvent, myEventScript.feasibleEvents [2]) == 0) {
				Debug.Log ("User exit an scenario continue recording HR data");
				//lastState = feasibleStates [0];
			}

			if (string.Compare (incomingEvent, myEventScript.feasibleEvents [3]) == 0) {
				Debug.Log ("User log out. Stop recording HR data");
				lastState = feasibleStates [0];
				myUpdateFn.HrDataTransferPermission (0);
			}
		} else {
			Debug.Log ("Uknown State");
		}
						
	}

}
