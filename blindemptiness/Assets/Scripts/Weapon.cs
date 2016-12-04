using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

[System.Serializable]
public class Weapon<T> : WeaponBase
    where T : Ammo
{
    public float damage
    {
        get
        {
            return ammo.ammo.Average(c => c.damage);
        }
    }
    public float range = 1f;
	public float dispersion = 1f;
    public AmmoContainer <T> ammo = new AmmoContainer<T>();

    public override Type GetAmmoType
    {
        get
        {
            return typeof(AmmoContainer<T>);
        }
    }

    public override int Id
    {
        get
        {
            return ammo.id;
        }
    }

    public override Ammo Fire ()
    {
        if(ammo.Count != 0)
        {
            T fired = ammo.ammo[0];
            ammo.ammo.RemoveAt(0);
            Debug.Log("Fire in the hole !");
           
            return fired;
        }
        else
        {
            Debug.Log("No ammo left! Reload !");
        }
        return null;
    }

    public override void Reload(ref Inventory instance, ref List<Item> inventory)
    {
        int containerIndex = -1;

        var containersToReloadBase = instance.GetAllContainers(ammo.id);
        if (containersToReloadBase != null)
        {
           List<AmmoContainer<T>> containersToReload = containersToReloadBase.Select(c => c as AmmoContainer<T>).Where(c => c != null).ToList();
            if (containersToReload != null)
            {
               
                AmmoContainer<T> containerToReload = containersToReload.Where(d => d != null && d.Count != 0).FirstOrDefault();

                if (containerToReload != null)
                {
                    containerIndex = inventory.IndexOf(containerToReload);
                    inventory[containerIndex] = ammo.Merge(containerToReload);
                }
                else
                {
                    Debug.Log("You dont have bullets in your containers!");
                }
            }
            else
            {
                Debug.Log("You dont have containers to reload!!! Pick one");
            }
        }
        else
        {
            Debug.Log("You dont have containers to reload!!! Pick one");
        }
    }

    
}
