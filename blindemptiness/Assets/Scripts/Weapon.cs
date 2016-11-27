using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Weapon : Item
{
    public float damage;
    public float range ;
	public float dispersion ;
    public GameObject sprite ;
    public int maxAmmo ;

    public Weapon(string itemSpritePath, string itemSpriteName)
       :base (itemSpritePath,itemSpriteName)
    {

    }


}
