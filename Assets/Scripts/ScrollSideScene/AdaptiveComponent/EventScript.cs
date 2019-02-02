using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventScript : MonoBehaviour {


	//Class tha defines possible events
	public List<string> feasibleEvents;
	private string lastEvent;

	private StateScript myStatesObj; 
	private bool test;

	// Use this for initialization
	void Start () {

		feasibleEvents = new List<string> (){ "wait","play-game-button-clicked", "quit-button-clicked", "log-out-button-clicked" };
		lastEvent = feasibleEvents [0];
		myStatesObj = GetComponent<StateScript> ();
		test = true;


		
	}
	
	// Update is called once per frame
	void Update () {

		/* Test Event and State update
		if (waitEvent) {
			UpdateLastEvent (0);
		}

		if(playGameEvent){
			UpdateLastEvent (1);
		}

		if (quitButtonEvnt) {
			UpdateLastEvent (2);
		}

		if (logOutEvent)
			UpdateLastEvent (3);

		*/


		//Simulate a user playing the game
		//1. Start on the wait event
		if(test){
            /*
            UpdateLastEvent(0);
            //2. Play a game scenario
            UpdateLastEvent(1);
            //.
            //Wait until scenario finishes
            //
            //3. Quit game scenario
            UpdateLastEvent(2);
            //Maybe wait a few seconds before starting the next scenario, but keep recording heart rate data.
            //.
            //.
            //4. Play another scenario.
            UpdateLastEvent(1);
            //Wait until scenario finishes
            //
            //5. Quit scenario
            UpdateLastEvent(2);
            //Exergame session is over, finish hear rate data transmission.
            //UpdateLastEvent(3);
            test = false;
            */
        }
				
				

	}

	//Update last event. This function is called by other objects that belong to the exergame such as buttons, timers, etc, by doing triggering new events.
	public void UpdateLastEvent(int eventPos){
		//string.Compare(str1,str2) compares two strings and return zero if these are equal.
		lastEvent = feasibleEvents [eventPos];
		myStatesObj.UpdateState (lastEvent);
	}

	//Informa a la clase States del nuevo evento que ha sido detectado
	public void ToStateAction(string detectedEvent){
		//myStatesObj.UpdateState (detectedEvent);
		lastEvent = feasibleEvents [0];
	}

}
