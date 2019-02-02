using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DbProperties : MonoBehaviour{
	
	//Database connection properties
	public string db_host;
	public string db_user;
	public string db_pass;
	public string db;


//Declare constructor
	public DbProperties(){
		db_host = "localhost";
		db_user = "root";
		db_pass = "";
		db = "bdadaptativecomponent"; 
	}

	public void setDb_host(string str){
		this.db_host = str;
	}
	public void setDb_user(string str){
		this.db_user = str;
	}
	public void setDb_pass(string str){
		this.db_pass = str;
	}
	public void setDb(string str){
		this.db = str;
	}
	// Use this for initialization
	void Start () {
		

	}
	

}
