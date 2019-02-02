using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceLayer : MonoBehaviour {

	//The interface layer is responsable for tracking Exergame's state and event and reporting it to the Adaption component.

	//First, this interface should know all the possible different events and states

	private EventScript theEvents;
	private StateScript theStates;

	//private Update updateFn;
	void Start () {

		theEvents = new EventScript ();
		theStates = new StateScript ();
		Scene scene = SceneManager.GetActiveScene ();
		theEvents = GetComponent<EventScript> ();
		//Debug.Log ("Active Scene is: " + scene.name);


	}

	// Update is called once per frame
	void Update () {

	}

	public void ForwardEvent(string eventN){

	}


}
