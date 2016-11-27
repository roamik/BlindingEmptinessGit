using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AmmoContainer : Item
{
    public List<Ammo> ammo = new List<Ammo>() { };
    public int maxCount;

    public AmmoContainer(string itemSpritePath, string itemSpriteName)
       :base (itemSpritePath,itemSpriteName)
    {

    }
}
