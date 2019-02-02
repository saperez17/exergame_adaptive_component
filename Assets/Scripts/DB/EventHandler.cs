using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventHandler : MonoBehaviour  {

	public Button btnEvent;

	public Text hrVal;
	public Text uIdVal;

	float timeLeft = 10.0f;

	CtrSquare ctrSquare;
	public DbManager dbManag;

	// Use this for initialization
	void Start () {

		//Calls the TaskOnClick/TaskWithParameters/Buttonlicked method when you click the button
		btnEvent.onClick.AddListener(TaskOnClick);
		//dataBaseM = new DbManager();
		ctrSquare = GameObject.Find("Square").GetComponent<CtrSquare>();
		UpdateSquareVel ();

		dbManag = GetComponent<DbManager> ();

	}

	void Update(){
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0) {
			UpdateSquareVel ();
			timeLeft = 10.0f;
		}
		Debug.Log (timeLeft.ToString ());
	}

	//Use to update movements and physics actions
	void FixedUpdate(){


	}
	
	// Update is called once per frame

	public void TaskOnClick(){
		//Excecuted code when btnEvent is clicked
		Debug.Log("btnEvent was cliked!");
		float[] userInfo = new float[2];
//		var consul = new List<double> ();
		DbManager dataBaseM = GetComponent<DbManager>();
		userInfo = dataBaseM.Consult();
		if (userInfo != null) {
			uIdVal.text = userInfo[0].ToString();
			hrVal.text = userInfo[1].ToString();
			//UpdateSquareVel ();
			ctrSquare.maxVel = -0.6f*userInfo[1] -59.0f;
		}
	}

	void UpdateSquareVel(){
		//Excecuted code when btnEvent is clicked
		Debug.Log("btnEvent was cliked!");
		float[] userInfo = new float[2];
		//		var consul = new List<double> ();

		userInfo = dbManag.Consult();
		if (userInfo != null) {
			uIdVal.text = userInfo[0].ToString();
			hrVal.text = userInfo[1].ToString();
			//UpdateSquareVel ();
			//ctrSquare.maxVel = -0.6f*userInfo[1] -59.0f;
			if (userInfo [1] < 70)
				ctrSquare.maxVel = ctrSquare.maxVel + 6;
			else if (userInfo [1] > 70 && userInfo [1] < 85)
				ctrSquare.maxVel = ctrSquare.maxVel + 4;
			else if (userInfo [1] > 85 && ctrSquare.maxVel > 6)
				ctrSquare.maxVel = ctrSquare.maxVel - 5;
			else
				ctrSquare.maxVel = ctrSquare.maxVel;
				
			//ctrSquare.maxVel =ctrSquare.maxVel + (0.1f*userInfo[1]);
		}
	}
}
