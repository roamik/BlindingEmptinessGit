using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Assets.Scripts;

[System.Serializable]
public abstract class WeaponBase : Item, IVisible
{
    public ItemSound FireSound { get; set; }

    public abstract int Id
    {
        get;
    }
    public abstract Type GetAmmoType
    {
        get;
    }

    public abstract void Reload(ref Inventory instance, ref List<Item> inventory);
    public abstract Ammo Fire();
    public float fireDelay = 0f;
}
