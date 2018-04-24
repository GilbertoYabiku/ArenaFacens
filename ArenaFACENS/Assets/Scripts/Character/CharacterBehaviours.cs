using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBehaviours : Character {

    private List<GameObject> foodList = new List<GameObject>();
    private List<GameObject> weaponList = new List<GameObject>();

    Text playerNameText; //Nome do seu personagem

    private void Start()
    {
        playerNameText = GetComponentInChildren<Text>();   //PlayerNameText é um componente do canvas filho do prefab. Deve ser referenciado dessa maneira para que o nome do seu personagem apareça na tela do jogo
    }

    #region Getters/Setters
    public List<GameObject> FoodList
    {
        get
        {
            return foodList;
        }
        set
        {
            foodList = value;
        }
    }

    public List<GameObject> WeaponList
    {
        get
        {
            return weaponList;
        }
        set
        {
            weaponList = value;
        }
    }
    #endregion
}
