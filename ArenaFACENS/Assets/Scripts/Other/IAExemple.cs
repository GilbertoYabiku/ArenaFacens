using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAExemple : MonoBehaviour {

    CharacterBehaviours chara, enemy;
    Transform target;
    [SerializeField]
    LayerMask detectable;
    States charaState = States.Seeking;

	// Use this for initialization
	void Awake () {
        chara = GetComponent<CharacterBehaviours>();
        chara.PlayerName = "StatePlayer";
	}
	
	// Update is called once per frame
	void Update () {
        StateSetter();
        switch (charaState)
        {
            case States.Moving:
                if (enemy && Vector2.Distance(transform.position, enemy.transform.position) <= chara.Vision && !enemy.IsDead)
                {
                    CharacterCommands.SetPath(chara, enemy.transform.position);
                }
                else if (target)
                {
                    CharacterCommands.SetPath(chara, target.position);
                }
                break;
            case States.Attacking:
                AttackState();
                break;
            case States.Eating:
                EatState();
                break;
            case States.Seeking:
                SeekState();
                break;
            default:
                break;
        }
    }

    void StateSetter()
    {
        if (!target && !enemy)
        {
            charaState = States.Seeking;
        }
        if (target || enemy)
        {
            charaState = States.Moving;
        }
        if (enemy && Vector2.Distance(transform.position, enemy.transform.position) <= chara.Weapon.Range)
        {
            charaState = States.Attacking;
        }
        if (chara.Health < 15 || chara.Energy < 15)
        {
            charaState = States.Eating;
        }
    }

    void SeekState()
    {
        CharacterCommands.GetVision(chara, detectable);
        if (chara.FoundItems.Count > 0)
        {
            foreach (Transform item in chara.FoundItems)
            {
                if (item.tag == "Weapon" && item.GetComponent<Weapon>().Damage > chara.Weapon.Damage)
                {
                    target = item;
                    break;
                }
                else if (item.tag == "Treasure")
                {
                    target = item;
                    break;
                }
            }
            if (!target && !chara.FullFoodBag)
            {
                List<Transform> foundFood = new List<Transform>();
                foreach (Transform item in chara.FoundItems)
                {
                    if (item.tag == "Food")
                    {
                        foundFood.Add(item);
                    }
                }
                target = GetClosest(foundFood);
            }
            if (!enemy)
            {
                List<Transform> enemyList = new List<Transform>();
                foreach (Transform _enemy in chara.FoundItems)
                {
                    if (_enemy.tag == "Player" && _enemy.GetComponent<CharacterBehaviours>() != chara)
                    {
                        enemyList.Add(_enemy);
                        print(_enemy.name);
                    }
                }
                if (enemyList.Count > 1)
                {
                    GameObject closestEnemy = GetClosest(enemyList).gameObject;
                    enemy = closestEnemy.GetComponent<CharacterBehaviours>();
                }
                else if (enemyList.Count != 0)
                {
                    enemy = enemyList[0].GetComponent<CharacterBehaviours>();
                }
            }
        }
    }

    Transform GetClosest(List<Transform> _list)
    {
        if (_list.Count == 0)
        {
            return null;
        }
        if (_list.Count == 1)
        {
            return _list[0];
        }
        else
        {
            List<Transform> sorted = new List<Transform>();
            float distance, minDistance;
            Transform closest = _list[0];
            minDistance = Vector2.Distance(chara.transform.position, _list[0].transform.position);
            foreach (Transform item in _list)
            {
                distance = Vector2.Distance(chara.transform.position, item.position);
                if (distance < minDistance)
                {
                    closest = item;
                    minDistance = distance;
                }
            }
            return closest;
        }
    }

    void MoveState(Transform _target)
    {
        CharacterCommands.SetPath(chara, _target.position);
    }

    void AttackState()
    {
        if (!enemy.IsDead)
        {
            CharacterCommands.Attack(chara, enemy);
        }
        else
        {
            enemy = null;
        }
    }

    void EatState()
    {
        if (chara.FoodList.Count != 0)
        {
            CharacterCommands.Eat(chara, chara.FoodList[0]);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform == target)
        {
            if (col.tag == "Food")
            {
                CharacterCommands.CatchFood(chara, col.gameObject);
            }
            if (col.tag == "Weapon")
            {
                CharacterCommands.CatchWeapon(chara, col.gameObject);
            }
            if (col.tag == "Treasure")
            {
                CharacterCommands.CatchTreasure(chara, col.gameObject);
            }
            target = null;
        }
    }
}

public enum States
{
    Moving,
    Attacking,
    Eating,
    Seeking
}
