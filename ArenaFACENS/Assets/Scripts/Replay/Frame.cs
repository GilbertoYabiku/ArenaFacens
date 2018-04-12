using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame {

	Vector3 m_pos, m_scale;
	Quaternion m_rotation;
	GameObject m_go;
	List<AnimationRecord> m_animationRecord;
	public Frame(GameObject go, Vector3 pos, Quaternion rotation, Vector3 scale, List<AnimationRecord> animRecords){
		m_pos = pos;
		m_scale = scale;
		m_rotation = rotation;
        m_animationRecord = animRecords;
		m_go = go;
	}
	public Vector3 Pos{
		get{
			return m_pos;
		}
	}
	public Quaternion Rotation{
		get{
			return m_rotation;
		}
	}
	public Vector3 Scale{
		get{
			return m_scale;
		}
	}
	public GameObject GameObject{
		get{
			return m_go;
		}
	}
	public List<AnimationRecord> AnimationRecord{
		get{
			return m_animationRecord;
		}
	}
}
