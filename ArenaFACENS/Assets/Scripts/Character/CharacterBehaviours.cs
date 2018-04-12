using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBehaviours : Character {

    private List<GameObject> foodList = new List<GameObject>();
    private List<GameObject> weaponList = new List<GameObject>();

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
