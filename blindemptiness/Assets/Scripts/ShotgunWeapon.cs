using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ShotgunWeapon : Weapon
{
    public List<ShotgunAmmo> ammo = new List<ShotgunAmmo>() { };

    public ShotgunWeapon(string itemSpritePath, string itemSpriteName)
       :base (itemSpritePath,itemSpriteName)
    {

    }
}
