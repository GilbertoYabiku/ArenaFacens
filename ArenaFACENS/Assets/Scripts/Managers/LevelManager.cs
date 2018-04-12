using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {


	public List<Transform> players =  new List<Transform>();
	public CharacterBehaviours [] aux;
	void Awake () {
		aux = GetComponentsInChildren<CharacterBehaviours> ();

		foreach (var player in aux) {
			players.Add (player.transform);
		}
	}

}
