﻿using UnityEngine;
using System.Collections;

public abstract class Spells : MonoBehaviour
{

    public LayerMask CollisionMask;

    public GameObject Owner { get; private set; }
    public int Damage { get; private set; }

    public void Initialize(GameObject owner, int damage)
    {
        Damage = damage;
        Owner = owner;
        OnInitialized();
    }

    protected virtual void OnInitialized()
    {

    }


    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if ((CollisionMask.value & (1 << other.gameObject.layer)) == 0)
        {
            OnNotCollideWith(other);
            return;
        }
        var isOwner = other.gameObject == Owner;
        if (isOwner)
        {
            OnCollideOwner();
            return;
        }
        var takeDamage = (ITakeDamage)other.GetComponent(typeof(ITakeDamage));
        var takeEffect = (ITakeEffect)other.GetComponent(typeof(ITakeEffect));
        if (takeDamage != null || takeEffect != null)
        {
            if (takeDamage != null)
            {
                OnCollideTakeDamage(other, takeDamage);
            }
            if (takeEffect != null)
            {
                OnCollideTakeEffect(other, takeEffect);
            }
            return;
        }
        OnCollideOther(other);
    }

    protected virtual void OnNotCollideWith(Collider2D other)
    {

    }

    protected virtual void OnCollideOwner()
    {

    }
    protected virtual void OnCollideTakeDamage(Collider2D other, ITakeDamage takeDamage)
    {

    }
    protected virtual void OnCollideTakeEffect(Collider2D other, ITakeEffect takeEffect)
    {

    }
    protected virtual void OnCollideOther(Collider2D other)
    {

    }
}
