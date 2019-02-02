using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

	public ObjectPool coinPool;

	public float distanceBetweenCoins;

	public void SpawnCoins(Vector3 startPosition){
		GameObject coin = coinPool.GetPooledObject ();
		coin.transform.position = startPosition;
		coin.SetActive (true);
	}
}
