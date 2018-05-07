using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayRecord : MonoBehaviour {

	public ReplayPlayer player;
	public Animator m_animation;
	List<Frame> frames;
	List<AnimationRecord> animationRecords;
	int maxLength;
	int length;
	int frameIndex = -1;

	public ReplayRecord(){
		

	}

	void Start()
	{
        if (player == null)
        {
            player = FindObjectOfType<ReplayPlayer>();
        }
        if (player)
        {
            player.Add(this);
            maxLength = player.maxLength;
            frames = new List<Frame>();
        }
	}

	void Update()
	{
        if (Game.gameModes == Game.GameModes.RECORD)
        {
            animationRecords = new List<AnimationRecord>();
            if (m_animation != null)
            {
                foreach (AnimatorControllerParameter item in m_animation.parameters)
                {
                    string name = item.name;
                    if (item.type == AnimatorControllerParameterType.Bool)
                    {
                        animationRecords.Add(new AnimationRecord(name, m_animation.GetBool(name), item.type));
                    }
                    if (item.type == AnimatorControllerParameterType.Float)
                    {
                        animationRecords.Add(new AnimationRecord(name, m_animation.GetFloat(name), item.type));
                    }
                    if (item.type == AnimatorControllerParameterType.Int)
                    {
                        animationRecords.Add(new AnimationRecord(name, m_animation.GetInteger(name), item.type));
                    }

                }
            }
            Frame frame = new Frame(this.gameObject, transform.position, transform.rotation, transform.localScale, animationRecords);
            Add(frame);
        }		
	}
	void Add (Frame frm)
	{
		if (length < maxLength) {

		} else {
			frames.RemoveAt (0);
			length = maxLength - 1;
		}
		frames.Add (frm);
		length++;
	}
	public void Play()
	{
		Frame frm;
		if ((frm = GetFrame()) != null)
		{
			transform.position = frm.Pos;
			transform.rotation = frm.Rotation;
			transform.localScale = frm.Scale;
			foreach (AnimationRecord item in frm.AnimationRecord) {
				string name = item.Name;
				if (item.Type == AnimatorControllerParameterType.Bool)
				{
					m_animation.SetBool(name, item.Value_bool);
					continue;
				}
				else if (item.Type == AnimatorControllerParameterType.Int)
				{
					m_animation.SetInteger(name, item.Value_int);
					continue;
				}
				else if (item.Type == AnimatorControllerParameterType.Float)
				{
					m_animation.SetFloat(name, item.Value_float);
					continue;
				}
			}
		}
		else {
			Game.gameModes = Game.GameModes.PAUSE;
		}
	}

	Frame GetFrame()
	{
		frameIndex++;
		if (Game.gameModes == Game.GameModes.PAUSE) {
			frameIndex--;
            Time.timeScale = 0;
		} else {
            Time.timeScale = 1;
        }
		if (frameIndex >= length) {
			Game.gameModes = Game.GameModes.PAUSE;
			frameIndex = length - 1;
			return null;
		}
		if (frameIndex == -1) {
			frameIndex = length - 1;
		}
		return frames [frameIndex];
	}
    public void SetFrame(int value)
    {
        frameIndex = value;
    }
    public int GetFrameIndex()
    {
        return frameIndex;
    }
    public int Length
    {
        get
        {
            return length;
        }
    }
}
