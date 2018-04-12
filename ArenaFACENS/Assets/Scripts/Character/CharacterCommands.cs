using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCommands : MonoBehaviour {
	
	//Detecta coletáveis no campo de visão e retorna uma lista com esses objetos
	public static List<Transform> GetVision(Transform playerTransform, int m_vision, LayerMask m_detectable)
    {
		Collider2D[] objects = Physics2D.OverlapCircleAll(playerTransform.position, m_vision, m_detectable);//Lista de todos os objetos no campo de visão
		List <Transform> tList = new List <Transform>();//Lista com todos os componentes Transform dos objetos no campo de visão
        if (objects.Length == 0)
        {
			tList.Add (playerTransform);
			return tList;//Retorna a sua própria posição
        }
        else
        {
			foreach (var obj in objects) {
				tList.Add (obj.transform);//Retorna a posição do objeto
			}
			return tList;
        }
    }

    //Faz a movimentação de um objeto para uma posição
    public static void SetPath(Transform go, Vector2 target, int m_speed)
    {
        go.position = Vector2.MoveTowards(go.position, target, m_speed * Time.deltaTime);
    }

    //Adiciona um objeto do tipo comida para a lista de comida
	public static void CatchFood(CharacterBehaviours m_character, GameObject m_food)
    {
        if (Game.gameModes == Game.GameModes.PLAY)
        {
            Items food = m_food.GetComponent<Items>();
            food.HideObject();
            return;
        }
        else if (m_character.FoodList.Count < 10)
        {
			Items food = m_food.GetComponent<Items> ();
            m_character.FoodList.Add(m_food);
			food.HideObject ();
			m_character.Hunger += food.HungerRegain;
			m_character.Score += food.Score;
        }
    }

    //Adiciona um objeto do tipo arma paara a lista de arma
	public static void CatchWeapon(CharacterBehaviours m_character, GameObject m_weapon)
    {
        if (Game.gameModes == Game.GameModes.PLAY)
        {
            Items weapon = m_weapon.GetComponent<Items>();
            weapon.HideObject();
            return;
        }
        else if (m_character.WeaponList.Count < 10)
        {
			Items weapon = m_weapon.GetComponent<Items> ();
            m_character.WeaponList.Add(m_weapon);
			weapon.HideObject ();
			m_character.Score += weapon.Score;
        }
    }
}
