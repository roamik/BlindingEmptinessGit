using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class ItemDataBase : MonoBehaviour
{
    public List<Item> items = new List<Item>() { };

    void LoadItems()
    {
        items.Add(
            new ShotgunWeapon("Sprites/", "WinterRifle")
            {
                id = 1,
                name = "WinterRifle",
                description = "A rifle used in winter.",
                damage = 1f,
                range = 1f,
                maxAmmo = 2,
                ammo = new List<ShotgunAmmo>() { new ShotgunAmmo(), new ShotgunAmmo() }
            });
        items.Add(
            new AmmoContainer("Sprites/", "ShotgunAmmo")
            {
                id = 2,
                name = "WinterRifleAmmo",
                description = "Ammo Container",
                maxCount = 10,
                ammo = new Ammo[10].Select(c => c = new ShotgunAmmo()).ToList()
            });
    }

	// Use this for initialization
	void Start ()
    {
        LoadItems();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
