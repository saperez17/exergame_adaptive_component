using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

	public GameObject theEnemy;
	public Transform generationPoint;
	public float distanceBetween;
	private Vector3 randPos;

	//Posible parametro para personalizar
	public float distanceBetweenMin;
	public float distanceBetweenMax;

	//Crea un array de objectos de enemigos para instanciarlos.
	public GameObject[] theEnemies;
	private int enemySelector;
	//Crea un array de tipo ObjectPool, el cual es basicamente un script adjunto a un GameObject para los diferentes objectos
	//que se desean traer a la pantalla.
	public ObjectPool[] theObjectPools;

	private CoinGenerator theCoinGenerator;

	public float powerupThreshold;
	public float powerupDistance;
	public ObjectPool powerupPool;

	public 
	// Use this for initialization
	void Start () {
		theCoinGenerator = FindObjectOfType<CoinGenerator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < generationPoint.position.x) {
			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);
			transform.position = new Vector3 (transform.position.x + distanceBetween, Random.Range(-3.0f, -0.4f), transform.position.z);

			enemySelector = Random.Range (0, theObjectPools.Length);
			//Instantiate (/*theEnemy*/theEnemies[enemySelector], transform.position,transform.rotation);
			//Object Pooling

			GameObject newEnemy = theObjectPools[enemySelector].GetPooledObject();
			newEnemy.transform.position = transform.position;
			newEnemy.transform.rotation = transform.rotation;
			newEnemy.SetActive (true);

			theCoinGenerator.SpawnCoins (new Vector3(Random.Range(transform.position.x+distanceBetween/4f,transform.position.x+(3f*distanceBetween/4f)), Random.Range(-3.0f, -0.4f), transform.position.z));

			if (Random.Range (0f, 100f) <= powerupThreshold) {
				GameObject newPowerup = powerupPool.GetPooledObject ();
				newPowerup.transform.position = new Vector3 (Random.Range(transform.position.x,transform.position.x + distanceBetween), Random.Range(-3.0f, -0.4f), transform.position.z);
				newPowerup.transform.rotation = transform.rotation;
				newPowerup.SetActive (true);
			}

		}
	}


}
