using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class LoginPageManager : MonoBehaviour {

	public InputField idNewUTxt; 
	public InputField idLoginTxt;
	public InputField ageTxt;
	public InputField weightTxt;


	private string id;
	private string age;
	private string weight;

	//Variables used when validating user
	//private string[] searchUser;
	public bool searchUser;


	//Database references
	private DbManager dbManager;

	// Use this for initialization
	public string sceneName;

	void Start () {
		dbManager = FindObjectOfType<DbManager> ();
		//searchUser = new string[2];
		searchUser = false;
		
	}



	public void ButtonCreateClick(){
		//SceneManager.LoadScene (sceneName);
		if ((idNewUTxt.text != "") && (ageTxt.text != "") && (weightTxt.text != "")) {
			//Validate input field data.
			int i;
			if (int.TryParse (idNewUTxt.text, out i)) {
				if (int.TryParse (ageTxt.text, out i)) {
					if (int.TryParse (weightTxt.text, out i)) {
						//Validate user
						searchUser = dbManager.SearchUser(int.Parse(idNewUTxt.text));
						if (searchUser) {
							Debug.Log ("User found");

						}
							
						else
							Debug.Log ("User not found. Do you wanna create a new user ID?");

					} else
						Debug.Log ("Weigh Text contains number characters");
				} else
					Debug.Log ("Age text is incorrect");
			}else
				Debug.Log("Id Text is incorrect");
		} else {
			Debug.Log ("One or more input fields missing");
		}
			
	}


	public void ButtonLoginClick(){
		//SceneManager.LoadScene (sceneName);
		if ((idLoginTxt.text != "")) {
			//Validate input field data.
			int i;
			if (int.TryParse (idLoginTxt.text, out i)) {
				searchUser = dbManager.SearchUser (int.Parse (idLoginTxt.text));
				if (searchUser ) {
					PlayerPrefs.SetString ("userID", idLoginTxt.text);
					//PlayerPrefs.SetString("hr_database", searchUser[1]);
					SceneManager.LoadScene ("MainMenu");
				}
					
				else
					Debug.Log ("User not found");
			}else
				Debug.Log("Id Text is incorrect");
		} else {
			Debug.Log ("One or more input fields missing");
		}

	}




}
