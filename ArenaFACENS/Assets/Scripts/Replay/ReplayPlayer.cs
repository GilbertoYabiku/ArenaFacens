using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReplayPlayer : MonoBehaviour {

	List<ReplayRecord> m_replayRecords;
	public int maxLength = 100;
    bool sliderControlling;
    public Slider slider;
	public float maximumZoom = 90f;
	public float minimumZoom = 10f;
	public float zoomIndex = 5f;
	public Canvas canvas;
	int cameraIndex = 0;
	public List<Camera> cameras;
	public ReplayPlayer(){
		m_replayRecords = new List<ReplayRecord> ();
		Game.gameModes = Game.GameModes.RECORD;
        sliderControlling = false;
	}
	void Start () {
		
	}

	public void CameraChange()
	{
		cameraIndex = (cameraIndex + 1) % cameras.Count;
		if (cameras != null) 
		{
			for (int i = 0; i < cameras.Count; i++) 
			{
				if (i == cameraIndex) {
					cameras [i].enabled = true;
				} else 
				{
					cameras [i].enabled = false;
				}
			}
		}
	}

	public void Zoom ()
	{
		if (cameras [cameraIndex].fieldOfView > minimumZoom) 
		{
			cameras [cameraIndex].fieldOfView -= zoomIndex;
		}
	}

	public void Unzoom()
	{
		if (cameras [cameraIndex].fieldOfView < maximumZoom) 
		{
			cameras [cameraIndex].fieldOfView += zoomIndex;
		}
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.V)) 
		{
			CameraChange ();
		}
		if (Input.GetKeyDown (KeyCode.Z)) 
		{
			Zoom ();
		}
		if (Input.GetKeyDown (KeyCode.X)) 
		{
			Unzoom ();
		}
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (canvas.enabled) 
			{
				canvas.enabled = false;
				Exit ();
			} else 
			{
				canvas.enabled = true;
				Replay ();
			}
		}
		if (Game.gameModes != Game.GameModes.RECORD) 
		{
			foreach (ReplayRecord item in m_replayRecords) 
			{
                if (sliderControlling)
                {
                    item.SetFrame((int)slider.value);
                }
                else
                {
                    slider.value = item.GetFrameIndex();
                    slider.maxValue = item.Length;
                }
                if (Game.gameModes == Game.GameModes.REPLAY)
                {
                    item.SetFrame(-1);
                }
				if (Game.gameModes == Game.GameModes.EXIT) 
				{
					item.SetFrame (item.Length - 2);
				}
				item.Play ();
			}
		}
        if (Game.gameModes == Game.GameModes.REPLAY)
        {
            Game.gameModes = Game.GameModes.PLAY;
		}
		if (Game.gameModes == Game.GameModes.EXIT)
		{
			Game.gameModes = Game.GameModes.RECORD;
			Time.timeScale = 1;
		}
    }

	public void Add(ReplayRecord rec)
	{
		m_replayRecords.Add (rec);
	}

	public void Pause(){
		Game.gameModes = Game.GameModes.PAUSE;
		Time.timeScale = 0;
	}
	public void Play(){
		Game.gameModes = Game.GameModes.PLAY;
		Time.timeScale = 1;
	}
	public void Replay(){
		Game.gameModes = Game.GameModes.REPLAY;
		Time.timeScale = 1;
	}
	public void Exit(){
		Game.gameModes = Game.GameModes.EXIT;
	}
    public void ClickSlider()
    {
        sliderControlling = true;
    }
    public void SliderBreak()
    {
        sliderControlling = false;
        Play();
    }
}
public static class Game
{
	static GameModes gameMode;
	public enum GameModes
	{
		PLAY, PAUSE, RECORD, REPLAY, SLIDER, EXIT
	}
	public static GameModes gameModes
	{
		get 
		{
			return gameMode;
		}
		set {
			gameMode = value;
		}
	}
}