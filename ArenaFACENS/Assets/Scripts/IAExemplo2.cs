using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAExemplo2 : MonoBehaviour {

	[SerializeField]
	LayerMask detectable;
	GameObject target;

	public CharacterBehaviours chara;

	// Use this for initialization
	void Awake () {
        chara.PlayerName = "Player Name 2.0";
		chara.Speed = 5;
		chara.Vision = 5;
	}
	
	// Update is called once per frame
	void Update () {
		if (chara.Hunger <= 0) {
			return;
		}

		if (!target) {
			chara.FoundItems = CharacterCommands.GetVision (transform, chara.Vision, detectable);

			if (chara.Hunger < 5) {
				List<Transform> objects = new List<Transform> ();
				for (int i = 0; i < chara.FoundItems.Count; i++) {
					if (chara.FoundItems[i].tag == "Food") {
						objects.Add(chara.FoundItems [i].transform);
					}
				}
				target = DistanceCheck (objects).gameObject;
			} else {
				List<Transform> objects = new List<Transform> ();
				for (int i = 0; i < chara.FoundItems.Count; i++) {
					if (chara.FoundItems[i].tag == "Weapon") {
						objects.Add(chara.FoundItems [i].transform);
					}
				}
				target = DistanceCheck (objects).gameObject;
			}
		} else {
			CharacterCommands.SetPath (transform, target.transform.position, chara.Speed);
		}
	}

	Transform DistanceCheck(List<Transform> m_objecs){
		float _closest = 99f;
		Transform closestObject = null;
		foreach (Transform item in m_objecs) {
			float distance = Vector2.Distance (transform.position, item.position);
			if (distance < _closest) {
				_closest = distance;
				closestObject = item;
			}
		}
		return closestObject;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject == target) {
			if (col.tag == "Food") {
				CharacterCommands.CatchFood (chara, col.gameObject);
			}
			if (col.tag == "Weapon") {
				CharacterCommands.CatchFood (chara, col.gameObject);
			}
		}
	}
}
