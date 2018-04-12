using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public Transform maxRange;
	public Transform playerHolder;

	public void Spawnplayer(GameObject player){
		Vector2 spawnLocation = new Vector2 (Random.Range (transform.position.x, maxRange.position.x), Random.Range (transform.position.y, maxRange.position.y));
		GameObject _player = Instantiate (player, spawnLocation, Quaternion.identity);
		_player.transform.SetParent (playerHolder);
	}

	public void SpawnItem(GameObject item){
		Vector2 spawnLocation = new Vector2 (Random.Range (transform.position.x, maxRange.position.x), Random.Range (transform.position.y, maxRange.position.y));
		Instantiate (item, spawnLocation, Quaternion.identity);
	}
}
