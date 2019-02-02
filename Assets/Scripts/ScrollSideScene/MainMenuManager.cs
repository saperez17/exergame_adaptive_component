using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	private string userID;

	public string playGameLevel;
	private UpdateFn myUpdate;

	// Use this for initialization
	void Start () {

		myUpdate = FindObjectOfType<UpdateFn> ();

		if (PlayerPrefs.HasKey ("userID")) {
			userID = PlayerPrefs.GetString ("userID");
			Debug.Log ("UserID " + userID + " login succesfully");
		}

	}
			
	// Update is called once per frame
	void Update () {
		
	}

	public void Playgame(){
		if (PlayerPrefs.HasKey ("userID")) {
			myUpdate.HrDataTransferPermission (1);
			SceneManager.LoadScene(playGameLevel);
		}


	}

	public void QuitGame(){
		
		Application.Quit ();
	}

}
