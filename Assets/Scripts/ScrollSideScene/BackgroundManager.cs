using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour {

	public GameObject[] theBackgrounds;

	private int selector;


	// Use this for initialization
	void Start () {
		
		selector = Random.Range (0, theBackgrounds.Length);
		//Debug.Log ("Selector = " + selector);
		//Debug.Log("Array Length = " + theBackgrounds.Length );
		for (int i = 0; i <= theBackgrounds.Length - 1; i++) {
			if (i != selector)
				theBackgrounds [i].SetActive (false);
			else
				theBackgrounds [i].SetActive (true);
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void Awake(){
		//theBackgrounds [selector].SetActive (true);
	} 

	public void changeBackground(){
		theBackgrounds [selector].SetActive (false);
		selector = Random.Range (0, theBackgrounds.Length);
		theBackgrounds [selector].SetActive (true);
	}
}
