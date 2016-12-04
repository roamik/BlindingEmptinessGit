using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class ShotgunWeapon: Weapon<ShotgunAmmo>
{
    public override void AddToInventory(ref List<Item> inventory)
    {
        this.temp = DateTime.Now.Ticks.ToString();
        base.AddToInventory(ref inventory);
    }
}
