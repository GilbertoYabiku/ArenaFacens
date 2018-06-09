using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private List<GameObject> scripts = new List<GameObject>();
	private static GameManager instance;
	private List<GameObject> allScripts = new List<GameObject>();
	void Start () 
	{
		if (instance == null) {
			DontDestroyOnLoad (gameObject);
			instance = this;
		} 
		else if (instance != this) 
		{
			Destroy (gameObject);
		}
		PreencheListaScripts ();

	}

	public void PreencheListaScripts()
	{
		Object [] subList = Resources.LoadAll("Prefabs", typeof(GameObject));
		foreach (GameObject subListObject in subList) 
		{    
			GameObject script = (GameObject)subListObject;
			allScripts.Add (script);
		}
	}

	public void ValidaScripts()
	{
		
		string raText = GameObject.FindGameObjectWithTag ("RA").GetComponent<Text>().text;

		for (int i = 0; i < allScripts.Count; i++) 
		{
			if (raText == allScripts [i].name) 
			{
				scripts.Add (allScripts [i]);
				allScripts.Remove (allScripts [i]);
				break;
			} 
			if (i == allScripts.Count - 1)
			{
				RaiseError ();
			}
		}
	}

	protected void RaiseError ()
	{
		GameObject[] aux = Resources.FindObjectsOfTypeAll<GameObject>();//FindGameObjectWithTag ("Error");
		foreach (GameObject item in aux) {
			if (item.CompareTag ("Error")) 
			{
				GameObject errorDialog = item;
				errorDialog.SetActive (true);
				break;
			}
		}
	}

	public void CloseError ()
	{
		GameObject errorDialog = GameObject.FindGameObjectWithTag ("Error");
		errorDialog.SetActive (false);
	}
		
	public List<GameObject> Scripts 
	{
		get {
			return scripts;
		}
	}

	public static GameManager Instance {
		get {
			return instance;
		}
	}
}
