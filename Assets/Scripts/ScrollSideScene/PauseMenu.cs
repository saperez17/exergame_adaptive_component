using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public string mainMenuLevel;
	private DbManager dbManager;

	public GameObject pauseMenu;

	public void PauseGame(){
		Time.timeScale = 0f;
		pauseMenu.SetActive (true);
	}

	public void ResumeGame(){
		Time.timeScale = 1f;
		pauseMenu.SetActive (false);
	}

	public void RestartGame(){
		Time.timeScale = 1f;
		pauseMenu.SetActive (false);
		FindObjectOfType<GameManager> ().Reset ();

	}


	public void QuitToMain(){
		Time.timeScale = 1f;
		dbManager = FindObjectOfType<DbManager> ();
		dbManager.UpdateTable ("user_index", "hr_in", 0, PlayerPrefs.GetString ("userID"));
		Application.LoadLevel (mainMenuLevel);
	}
}
