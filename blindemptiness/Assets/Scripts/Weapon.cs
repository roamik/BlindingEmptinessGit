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

    public override bool HasAmmo
    {
        get
        {
           return ammo != null && ammo.Count > 0 ;
        }
    }

    public override AmmoContainerBase Magazine
    {
        get
        {
            return ammo;
        }
    }

    public override Ammo Fire ()
    {
        if(HasAmmo)
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


    public override void Reload(ref AmmoContainerBase container)
    {
        //int containerIndex = -1;

        //var containersToReloadBase = inventory.GetAllContainers<T>(ammo.id);
        //if (containersToReloadBase != null)
        //{
        //   List<AmmoContainer<T>> containersToReload = containersToReloadBase.Select(c => c as AmmoContainer<T>).Where(c => c != null).ToList();
        //    if (containersToReload != null)
        //    {
        //        AmmoContainer<T> containerToReload = containersToReload.Where(d => d != null && d.Count != 0).FirstOrDefault();
        var isContainerValid = container is AmmoContainer<T>;
                if (isContainerValid)
                {
                    container = ammo.Merge(ref container);
                }
                else
                {
                    Debug.Log("You dont have bullets in your containers!");
                }
    //}
        //    else
        //    {
        //        Debug.Log("You dont have containers to reload!!! Pick one");
        //    }
        //}
        //else
        //{
        //    Debug.Log("You dont have containers to reload!!! Pick one");
        //}
    }

    
}
