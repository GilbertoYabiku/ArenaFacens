using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	private int energy = 20, sanity = 5, health = 20, vision = 10, speed = 5, attack = 5, score = 0; //Player stats
    private string playerName;
	private List<Transform> foundItems = new List<Transform>(); //List of collectable itens found by CharacterCommands.GetVision()
    private List<Food> foodList = new List<Food>(5);
    private List<Treasure> treasureList = new List<Treasure>();
    private Weapon weapon;
    private bool  isDead = false, fullFoodBag = false;

    SpriteRenderer sprite;
    Rigidbody2D rigid;
    CircleCollider2D col;

    private float energyDuration = 1f;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        StartCoroutine("HungerCount");
    }

    private void Update()
    {
        if (health <= 0 && !isDead)
        {
            isDead = true;
            health = 0;
            sprite.color = Color.gray;
            rigid.constraints = RigidbodyConstraints2D.FreezeAll;
            col.enabled = false;
            print(playerName + " died of Pain");
        }
        fullFoodBag = foodList.Count == 5;
    }

    public void Consume(Food food)
    {
        energy += food.HungerRegain;
        health += food.HealthRegain;
        FoodList.Remove(food);
    }

    public void TakeDamage(Weapon _weapon, CharacterBehaviours _attacker)
    {
        if (!_weapon.CanAttack && !_weapon.Attacked)
        {
            health -= _weapon.Damage + _attacker.Attack;
        }
    }

    public void Collect(Treasure _type, int _effect)
    {
        switch (_type.TresureType)
        {
            case TreasureType.Vision:
                vision += _effect;
                break;
            case TreasureType.Hunger:
                energyDuration += _effect;
                break;
            case TreasureType.Power:
                attack += _effect;
                break;
            case TreasureType.Speed:
                speed += _effect;
                break;
            default:
                break;
        }
    }

    IEnumerator HungerCount()
    {
        while (energy > 0 && !isDead)
        {
            yield return new WaitForSeconds(energyDuration);
            energy--;
        }
        if (energy == 0 && !isDead)
        {
            isDead = true;
            sprite.color = Color.gray;
            rigid.constraints = RigidbodyConstraints2D.FreezeAll;
            col.enabled = false;
            print(playerName + " died of Hunger");
        }
    }

    #region Getters/Setters
    public int Energy
    {
        get
        {
            return energy;
        }
    }

    public int Sanity
    {
        get
        {
            return sanity;
        }
    }

    public int Health
    {
        get
        {
            return health;
        }

    }

    public int Vision
    {
        get
        {
            return vision;
        }
    }

    public int Speed
    {
        get
        {
            return speed;
        }
    }

    public int Attack
    {
        get
        {
            return attack;
        }
    }

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

    public List<Transform> FoundItems
    {
        get
        {
            return foundItems;
        }
    }

    public List<Food> FoodList
    {
        get
        {
            return foodList;
        }
    }

    public string PlayerName
    {
        get
        {
            return playerName;
        }
        set
        {
            playerName = value;
        }
    }

    public Weapon Weapon
    {
        get
        {
            return weapon;
        }
        set
        {
            weapon = value;
        }
    }

    public List<Treasure> TreasureList
    {
        get
        {
            return treasureList;
        }
    }

    public bool IsDead
    {
        get
        {
            return isDead;
        }
    }

    public bool FullFoodBag
    {
        get
        {
            return fullFoodBag;
        }
    }
    #endregion
}
