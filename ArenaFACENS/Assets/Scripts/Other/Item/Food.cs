using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Items {

    [SerializeField]
    private int hungerRegain, healthRegain;

    private void Start()
    {
        score = 50;
    }

    public int HungerRegain
    {
        get
        {
            return hungerRegain;
        }
    }

    public int HealthRegain
    {
        get
        {
            return healthRegain;
        }
    }
}
