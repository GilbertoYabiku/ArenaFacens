using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviours : MonoBehaviour {

	bool isTracking = false;
	[SerializeField]
	float camSpeed = 3;
	int currentTarget = 0;
	public LevelManager lvlManager;
	List<Transform> playerList = new List<Transform>();
	Transform target;

    // Use this for initialization
    void Start () {
		playerList = lvlManager.players;
		ChangeTarget(0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (isTracking==true) {
				isTracking = false;
			} else {
				isTracking = true;
			}
		}
		if (!isTracking) {
			if (Input.GetKey(KeyCode.RightArrow)) {
				transform.position += new Vector3 (camSpeed, 0, 0) * Time.deltaTime;
			}
			else if (Input.GetKey(KeyCode.LeftArrow)) {
				transform.position += new Vector3 (-camSpeed, 0, 0) * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.UpArrow)) {
				transform.position += new Vector3 (0, camSpeed, 0) * Time.deltaTime;
			}
			else if (Input.GetKey(KeyCode.DownArrow)) {
				transform.position += new Vector3 (0, -camSpeed, 0) * Time.deltaTime;
			}
		}
		if (isTracking) {
			if (Input.GetKeyDown(KeyCode.Period)) {
				currentTarget++;
				if (currentTarget >= playerList.Count) {
					currentTarget = 0;
				}
				ChangeTarget (currentTarget);
			}
			if (Input.GetKeyDown(KeyCode.Comma)) {
				currentTarget--;
				if (currentTarget < 0) {
					currentTarget = playerList.Count -1;
				}
				ChangeTarget (currentTarget);
			}
		}
	}

	void FixedUpdate(){
		if (isTracking) {
			transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
		}
	}

	void ChangeTarget(int t){
		if (t < playerList.Count && playerList[t].gameObject.activeSelf == true) {
			target = playerList [t];
		}
	}

    #region Getters/Setters
    public bool IsTracking
    {
        get
        {
            return isTracking;
        }

        set
        {
            isTracking = value;
        }
    }

    public Transform Target
    {
        get
        {
            return target;
        }

        set
        {
            target = value;
        }
    }
    #endregion
}
