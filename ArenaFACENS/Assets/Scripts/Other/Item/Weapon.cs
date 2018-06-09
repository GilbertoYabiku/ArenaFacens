using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Items {

    [SerializeField]
    private int damage;
    [SerializeField]
    private float range, coolDown;
    private float attackTime = 0;
    private bool canAttack = true, attacked = false;
    private CharacterBehaviours owner;

    //private void Update()
    //{
    //    if (attacked)
    //    {
    //        if (attackTime < coolDown)
    //        {
    //            attackTime += Time.deltaTime;
    //        }
    //        else
    //        {
    //            canAttack = true;
    //            attacked = false;
    //        }
    //    }
    //}

    public void CollectWeapon(CharacterBehaviours _chara)
    {
        if (!owner)
        {
            _chara.Weapon = this;
            owner = _chara;
        }
    }

    public void AttackPlayer(CharacterBehaviours character, CharacterBehaviours target)
    {
        if (canAttack && Vector2.Distance(character.transform.position, target.transform.position) <= character.Weapon.Range)
        {
            canAttack = false;
            target.TakeDamage(this, character);
            attacked = true;
            StartCoroutine("AttackTime");
        }
    }

    IEnumerator AttackTime()
    {
        yield return new WaitForSeconds(coolDown);
        canAttack = true;
        attacked = false;
    }

    public int Damage
    {
        get
        {
            return damage;
        }
    }

    public float Range
    {
        get
        {
            return range;
        }
    }

    public bool CanAttack
    {
        get
        {
            return canAttack;
        }
    }

    public float CoolDown
    {
        get
        {
            return coolDown;
        }
    }

    public CharacterBehaviours Owner
    {
        get
        {
            return owner;
        }
    }

    public bool Attacked
    {
        get
        {
            return attacked;
        }
    }
}
