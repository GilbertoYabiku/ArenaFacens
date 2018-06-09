using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCommands : MonoBehaviour {
	
	//Detecta coletáveis no campo de visão e retorna uma lista com esses objetos
	public static void GetVision(CharacterBehaviours m_chara, LayerMask m_detectable)
    {
        if (m_chara.IsDead)
        {
            return;
        }
        if (m_chara.FoundItems.Count > 0)
        {
            m_chara.FoundItems.Clear();
        }
		Collider2D[] objects = Physics2D.OverlapCircleAll(m_chara.transform.position, m_chara.Vision, m_detectable);//Lista de todos os objetos no campo de visão
        if (objects.Length == 0)
        {
			m_chara.FoundItems.Add (m_chara.transform);
        }
        else
        {
			foreach (var obj in objects) {
				m_chara.FoundItems.Add (obj.transform);//Retorna a posição do objeto
			}
        }
    }

    //Faz a movimentação de um objeto para uma posição
    public static void SetPath(CharacterBehaviours m_chara, Vector2 target)
    {
        if (m_chara.IsDead)
        {
            return;
        }
        m_chara.transform.position = Vector2.MoveTowards(m_chara.transform.position, target, m_chara.Speed * Time.deltaTime);
    }

    //Adiciona um objeto do tipo comida para a lista de comida
	public static void CatchFood(CharacterBehaviours m_character, GameObject m_food)
    {
        if (m_character.IsDead)
        {
            return;
        }
        if (Game.gameModes == Game.GameModes.PLAY)
        {
            Food food = m_food.GetComponent<Food>();
            food.HideObject();
            return;
        }
        else if (!m_character.FullFoodBag && m_food.GetComponent<Food>())
        {
			Food food = m_food.GetComponent<Food> ();
            m_character.FoodList.Add(food);
			food.HideObject ();
			food.SetScore(m_character);
        }
    }

    //Adiciona um objeto do tipo arma para a lista de arma
	public static void CatchWeapon(CharacterBehaviours m_chara, GameObject m_weapon)
    {
        if (m_chara.IsDead)
        {
            return;
        }
        if (Game.gameModes == Game.GameModes.PLAY)
        {
            Weapon weapon = m_weapon.GetComponent<Weapon>();
            weapon.HideObject();
            return;
        }
        else if (m_chara.Weapon != null && m_weapon.GetComponent<Weapon>())
        {
			Weapon weapon = m_weapon.GetComponent<Weapon> ();
            if (weapon.Owner == null)
            {
                weapon.CollectWeapon(m_chara);
                weapon.HideObject();
                weapon.SetScore(m_chara);
            }
            else
            {
                return;
            }
        }
    }

    public static void CatchTreasure(CharacterBehaviours m_chara, GameObject m_treasure)
    {
        if (m_chara.IsDead)
        {
            return;
        }
        if (Game.gameModes == Game.GameModes.PLAY)
        {
            Treasure treasure = m_treasure.GetComponent<Treasure>();
            treasure.HideObject();
        }
        else if (m_treasure != null && m_treasure.GetComponent<Treasure>())
        {
            Treasure treasure = m_treasure.GetComponent<Treasure>();
            m_chara.Collect(treasure, treasure.Effect);
            m_chara.TreasureList.Add(treasure);
            treasure.HideObject();            
        }
    }

    public static void Attack(CharacterBehaviours m_chara, CharacterBehaviours m_target)
    {
        if (m_chara.IsDead)
        {
            return;
        }
        if (m_chara.Weapon.CanAttack && Vector2.Distance(m_chara.transform.position, m_target.transform.position) <= m_chara.Weapon.Range)
        {
            m_chara.Weapon.AttackPlayer(m_chara, m_target);
        }
    }

    public static void Eat(CharacterBehaviours m_chara, Food m_food)
    {
        if (m_chara.IsDead)
        {
            return;
        }
        m_chara.Consume(m_food);
    }
}
