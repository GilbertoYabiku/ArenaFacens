using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : Items {

    private TreasureType tresureType;
    private int effect;

    public TreasureType TresureType
    {
        get
        {
            return tresureType;
        }
    }

    public int Effect
    {
        get
        {
            return effect;
        }
    }
}

public enum TreasureType
{
    Vision,
    Hunger,
    Power,
    Speed
}
