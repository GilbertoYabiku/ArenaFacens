using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public List<GameObject> characters = new List<GameObject>();
	public List<GameObject> items = new List<GameObject>();
	public int itemNumber;
	public List<Spawner> spawnList = new List<Spawner> ();

	void Awake(){
		SpawnItems ();
		SpawnCharacters ();
	}

	public void SpawnCharacters(){
		foreach (GameObject chara in characters) {
			int spawn = Random.Range (0, spawnList.Count);
			spawnList [spawn].Spawnplayer (chara);
		}
	}

	public void SpawnItems()
	{
		for (int i = 0; i < itemNumber; i++) {
			int spawn = Random.Range (0, spawnList.Count);
			spawnList [spawn].SpawnItem (items [Random.Range (0, items.Count)]);
		}
	}
}
