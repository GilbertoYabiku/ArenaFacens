using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	private int hunger = 5, sanity = 5, health = 20, vision = 5, speed = 5, attack = 5, score = 0; //Player stats
    private string playerName;
	List<Transform> foundItems = new List<Transform>(); //List of collectable itens found by CharacterCommands.GetVision()
    bool isOut = false;

    private float hungerDuration;

    private void Update()
    {
        if (hunger > 0)
        {
            if (hungerDuration < 1)
            {
                hungerDuration += Time.deltaTime;
            }
            else
            {
                hunger--;
                hungerDuration = 0;
            }
        }
        else
        {
            if (!isOut)
            {
                isOut = true;
                print(PlayerName + " is Out!");               
            }
        }
    }

    #region Getters/Setters
    public int Hunger
	{
		get
		{
			return hunger;
		}

		set
		{
			hunger = value;
		}
	}

	public int Sanity
	{
		get
		{
			return sanity;
		}

		set
		{
			sanity = value;
		}
	}

	public int Health
	{
		get
		{
			return health;
		}

		set
		{
			health = value;
		}
	}

	public int Vision
	{
		get
		{
			return vision;
		}

		set
		{
			vision = value;
		}
	}

	public int Speed
	{
		get
		{
			return speed;
		}

		set
		{
			speed = value;
		}
	}

	public int Attack
	{
		get
		{
			return attack;
		}

		set
		{
			attack = value;
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
		set
		{
			foundItems = value;
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
    #endregion
}
