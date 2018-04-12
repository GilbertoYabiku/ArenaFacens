using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationRecord {
	string name;
	float value_float;
	int value_int;
	bool value_bool;
	AnimatorControllerParameterType type;
	public AnimationRecord(string n, float value, AnimatorControllerParameterType ty){
		value_float = value;
		name = n;
		type = ty;
	}
	public AnimationRecord(string n, int value, AnimatorControllerParameterType ty){
		value_int = value;
		name = n;
		type = ty;
	}
	public AnimationRecord(string n, bool value, AnimatorControllerParameterType ty){
		value_bool = value;
		name = n;
		type = ty;
	}
	public string Name{
		get{
			return name;
		}
	}
	public float Value_float{
		get{
			return value_float;
		}
	}
	public int Value_int{
		get{
			return value_int;
		}
	}
	public bool Value_bool{
		get{
			return value_bool;
		}
	}
	public AnimatorControllerParameterType Type
	{

		get {
			return type;
		}
	}
}
