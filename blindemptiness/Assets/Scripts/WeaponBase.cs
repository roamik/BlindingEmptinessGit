using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Assets.Scripts;

[System.Serializable]
public abstract class WeaponBase : Item, IVisible
{
    public abstract bool HasAmmo { get; }
    public abstract AmmoContainerBase Magazine { get; }
    public ItemSound FireSound { get; set; }
    public ItemSound NoBulletSound { get; set; }

    public abstract int Id
    {
        get;
    }
    public abstract Type GetAmmoType
    {
        get;
    }

    public abstract void Reload(ref AmmoContainerBase container);
    public abstract Ammo Fire();
    public float fireDelay = 0f;
}
