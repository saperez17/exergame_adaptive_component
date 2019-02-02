using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateFn : MonoBehaviour {


	private DbManager dbManag;
	private float [] dataControl;
	public bool test;

	//This is the first function triggerd just after an event accurs, and it is intended to update the User Model according to the user actions.

	//1. Allow wearable device updates HR data in the database. In this regard, a boolean value must be change from here, and readen by the android app.

	// Use this for initialization
	void Start () {
		dbManag = FindObjectOfType<DbManager> ();
		dataControl = new float[2];
		test = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void HrDataTransferPermission(int val){
		//Allow Heart Rate in
		if(PlayerPrefs.HasKey("userID")){ 
			bool res = dbManag.UpdateTable ("user_index", "hr_in", val, PlayerPrefs.GetString ("userID"));
			if (res) {
				if(val == 0)
					Debug.Log("Hear rate data transfer for UserID" + PlayerPrefs.GetString ("userID") + "disabled");
				else
					Debug.Log("Hear rate data transfer for UserID" + PlayerPrefs.GetString ("userID") + "enabled");
			}
			else
				Debug.Log("Something went wrong when enabling heart rate data transfer");
		}

	}

}
