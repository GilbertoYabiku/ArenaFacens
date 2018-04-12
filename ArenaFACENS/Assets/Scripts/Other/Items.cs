using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {
	[SerializeField]
	private int score = 50;
	[SerializeField]
	private int hungerRegain = 10;
	[SerializeField]
	private GameObject holder;

	// Use this for initialization
	void Start () {
		if (!holder) {
			holder = GameObject.Find ("ObjectHolder");
		}
	}
	
	public void HideObject(){
		transform.position = holder.transform.position;
	}

	#region Getters/Setters
	public int Score 
	{
		get
		{
			return score;
		}
		set
		{
			score = value;
		}
	}

	public int HungerRegain
	{
		get
		{
			return hungerRegain;
		}
		set
		{
			hungerRegain = value;
		}
	}
	#endregion
}
