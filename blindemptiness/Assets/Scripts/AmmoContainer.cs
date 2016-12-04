using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class AmmoContainer<T> : AmmoContainerBase
    where T : Ammo
{
    public List<T> ammo = new List<T>() { };
    public int maxCount;
    public int Count
    {
        get
        {
            return ammo != null ? ammo.Count : 0;
        }
    }
   
    public virtual AmmoContainer<T> Merge(AmmoContainer<T> container)
    {

        if (container.Count + this.Count > this.maxCount && Count != maxCount)
        {
            int takeCount = this.maxCount - this.Count;

            Debug.Log(string.Format("Take {0} from 1st container {1} to 2nd container!", container.Count, this.Count));
            this.ammo.AddRange(container.ammo.Take(takeCount));
            Debug.Log(string.Format("Take {0} bullets!", takeCount));
            container.ammo.RemoveRange( 0, takeCount);         
        }
        else if(Count == maxCount)
        {
            Debug.Log(string.Format("You have a full container of bullets! You dont need reload!"));
        }
        else
        {
            this.ammo.AddRange(container.ammo);
            Debug.Log(string.Format("Take all {0} bullets!", container.Count));
            container = null;

        }
        return container;
    }

    public override void AddToInventory(ref List<Item> inventory)
    {
       
        try {
            var anotherItem = inventory.Where(d => d.id == this.id).Select(g=>g as AmmoContainer<T>).ToList();
            if (anotherItem != null && anotherItem.Count != 0) 
            {
                AmmoContainer<T> addeble = this;
                while (addeble != null)
                {
                    AmmoContainer<T> adding = anotherItem.Where(c => c != null && c.Count < c.maxCount).FirstOrDefault();
                    if (adding != null)
                    {
                        addeble = adding.Merge(addeble);
                    }
                    else
                    {
                        base.AddToInventory(ref inventory);
                        Debug.Log(string.Format("Don't have a container to merge, just add container to inv!"));
                        break;
                    }
                   
                }
                
            }
            else
            {
                base.AddToInventory(ref inventory);
                Debug.Log(string.Format("Dont have container just add container to inv!!"));
            }
        }
        catch(System.Exception e) { };
    }

    public override string ToString()
    {
        return base.ToString() + this.Count.ToString();
    }
}
