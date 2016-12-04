﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public abstract class WeaponBase : Item
{
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
