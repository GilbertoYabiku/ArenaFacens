using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {
	[SerializeField]
	protected int score = 0;
	[SerializeField]
	private GameObject holder;

	// Use this for initialization
	void Awake () {
		if (!holder) {
			holder = GameObject.Find ("ObjectHolder");
		}
	}
	
	public  void HideObject(){
		transform.position = holder.transform.position;
	}

    public void SetScore(CharacterBehaviours character)
    {
        character.Score += score;
    }
}
