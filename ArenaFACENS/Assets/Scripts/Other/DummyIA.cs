using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyIA : MonoBehaviour {

    CharacterBehaviours chara;
    [SerializeField]
    LayerMask players;
    CharacterBehaviours target;

	// Use this for initialization
	void Start () {
        chara = GetComponent<CharacterBehaviours>();
	}
	
	// Update is called once per frame
	void Update () {
        if (chara.IsDead) return;
        if (!target)
        {
            CharacterCommands.GetVision(chara, players);
        }
        else
        {
            if (Vector2.Distance(transform.position, target.transform.position) <= chara.Weapon.Range)
            {
                CharacterCommands.Attack(chara, target);
            }
        }
	}
}
