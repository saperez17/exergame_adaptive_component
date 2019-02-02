using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Data;
using UnityEngine.UI;

public class DbManager : MonoBehaviour {

	//Database conection
	//DbProperties dbProp;

	//Hear Rate and User Id UI text
	private DbProperties dbProp;
	private string connectionInfo;
	private MySqlConnection conn;
	private MySqlDataReader rdr;
	private MySqlCommand cmd;

	// Use this for initialization
	void Start () {
		dbProp = GetComponent<DbProperties> (); //Use GetComponent<nameComponent>(); when this belongs to
												//the same gameobject your calling it from.
		connectionInfo = "Server=" + dbProp.db_host + ";Database=" + dbProp.db + ";Uid=" + dbProp.db_user + ";Pwd=" + dbProp.db_pass + ";";
		conn = null;
		rdr = null;
		cmd = null;
		//Consult ();

		//Initialize UI Texts

	}

	public void ConnectDb(){
		//dbProp = gameObject.GetComponent<DbProperties> ();
		DbProperties dbProp = GetComponent<DbProperties> ();
		Debug.Log (dbProp.db);
		MySqlConnection myconn = new MySqlConnection ();
		myconn.ConnectionString = connectionInfo;

		try {
			myconn.Open();
			Debug.Log("Sucessfully conected");
		}
		catch(MySqlException error){
			Debug.Log ("Failure database connection" + error);
			
			
		}

	}

	public float[] Consult(){
		//DbProperties dbProp = GetComponent<DbProperties> ();
		float[] query = new float[2];
		var listOfDouble = new List<double>();
		string strConsult = "SELECT * FROM usermodel ORDER BY ID DESC LIMIT 1"; 
		try{
			conn = new MySqlConnection (connectionInfo);
			conn.Open();

			cmd = new MySqlCommand(strConsult, conn);
			rdr = cmd.ExecuteReader();

			rdr.Read();
			query[0] = rdr.GetFloat(3);
			query[1]  = rdr.GetFloat(4);
			return query;

			//while(rdr.Read()){
				//Debug.Log(rdr.GetInt32(0) + ":" + rdr.GetInt32(1) + ":" + rdr.GetInt32(2));
				//listOfDouble.Add(rdr.GetInt32(0)); listOfDouble.Add(rdr.GetInt32(1)); listOfDouble.Add(rdr.GetInt32(2)); 
			//}


		}catch(MySqlException error){
			Debug.Log ("Error executing consult method" + error.ToString ());
			return null;
			//return new List<double> ();
			
		}finally{
			if (rdr != null) {
				rdr.Close ();
			}
			if (conn != null) {
				conn.Close ();
			}
		}
						
	}
	/*
	public float[] retrieveHRData(int sampleNumber, int userID, ){
		float[] query = new float[sampleNumber];
		string strQuery = "SELECT FROM "
	}
	*/

	/*
	public bool SearchUser(int id){
		//It verifies if the user's ID exists in the database system
		string[] query = new string[2];
		string strConsult = "SELECT ID FROM user_index WHERE ID = " + id.ToString ();
		try{
			conn =  new MySqlConnection (connectionInfo);
			conn.Open();

			cmd = new MySqlCommand(strConsult, conn);
			rdr = cmd.ExecuteReader();

			if(rdr.Read()){
				query[0] = rdr.GetString(0);
				//query[1] = rdr.GetString(4);
			}

			Debug.Log("user validation search result: " +  query[0]);
			if(!string.IsNullOrEmpty(query[0])){
				return true;
				//return query;
			}else
				return false;
				//return false;

		}catch(MySqlException error){
			Debug.Log ("Error executing SearchUser() method" + error.ToString ());
			return false;
			//return new List<double> ();

		}finally{
			if (rdr != null) {
				rdr.Close ();
			}
			if (conn != null) {
				conn.Close ();
			}
		}
	}
	*/


	public string[] SearchUser(int id){
		//It verifies if the user's ID exists in the database system
		string[] query = new string[2];
		string strConsult = "SELECT ID FROM user_index WHERE ID = " + id.ToString ();
		try{
			conn =  new MySqlConnection (connectionInfo);
			conn.Open();

			cmd = new MySqlCommand(strConsult, conn);
			rdr = cmd.ExecuteReader();

			if(rdr.Read()){
				query[0] = rdr.GetString(0);
				//query[1] = rdr.GetString(4);
			}

			Debug.Log("user validation search result: " +  query[0]);
			return query;

		}catch(MySqlException error){
			Debug.Log ("Error executing SearchUser() method" + error.ToString ());
			return query;
			//return new List<double> ();

		}finally{
			if (rdr != null) {
				rdr.Close ();
			}
			if (conn != null) {
				conn.Close ();
			}
		}
	}




	public bool UpdateTable(string tableName, string columnName, int val, string userId){
		//UpdateTable updates  an specific field for the specificed table and column
		//Args:
		//	-tableName: Table name that will be updated
		//	-columnName: Name of the column for which a value will be updated
		//	-val: Value used for updating the table
		//	userId: Id of the user used for searching the specified columnName.
		string strUpdate = "UPDATE " + tableName + " SET " + columnName + " = " + val + " WHERE ID = " + int.Parse(userId);
		try{
			conn = new MySqlConnection(connectionInfo);
			conn.Open();

			cmd = new MySqlCommand(strUpdate, conn);

			if(cmd.ExecuteNonQuery() != 0){
				//cmd.ExecuteQuery() returns a number different than zero when the query has been completed.
				return true;
			}
				
			else
				return false;



		
		}catch(MySqlException e){
			Debug.Log ("Error executing UpdateTable() method" + e.ToString ());
			return false;
		}finally{
			
			if (conn != null) {
				conn.Close ();
			}
		}


	}
		


	public bool CreateUser(){

		return true;
	}
		


	

}
