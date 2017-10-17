using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityStandardAssets._2D;
using Assets.Scripts;

[System.Serializable]
public class Inventory : MonoBehaviour
{
    public IEnumerable<Item> VisibleInventory { get { return inventory.Where(i => i is IVisible); } }

    private ItemDataBase dataBase;
    public Item currentItem;
    public int currentIndex;
    public List<Item> inventory = new List<Item>() { };


    public delegate void RefAction<T1, T2>(ref T1 arg1, T2 arg2);

    public delegate void RefAction<T1>(ref T1 arg1);

    public static event Action<Inventory> OnChange;

    public static event Action<Item> OnAfterChange;

    public static event RefAction<AmmoContainerBase> OnContainerAvailable;

    private event Action<Item> OnNewItemAdded;

    public void AddItem(Item item)
    {
        inventory.Add(item);

        if(OnNewItemAdded != null)
        {
            OnNewItemAdded(item);
        }
    }

    public List<AmmoContainerBase> GetAllContainers(int id)
    {
        var allContainers = inventory.Where(d => d != null && d.id == id);
        if (allContainers != null && allContainers.Count() != 0)
        {
            var allBaseContainers = allContainers.Select(g => g as AmmoContainerBase).ToList();
            if (allBaseContainers != null && allBaseContainers.Count != 0)
            {
                return allBaseContainers;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }

    public List<AmmoContainer<T>> GetAllContainers<T>(int id)  where T : Ammo
    {
        var allContainers = inventory.Where(d => d != null && d.id == id && d is AmmoContainer<T>);
        if (allContainers != null && allContainers.Count() != 0)
        {
            var allBaseContainers = allContainers.Select(g => g as AmmoContainer<T>).ToList();
            if (allBaseContainers != null && allBaseContainers.Count != 0)
            {
                return allBaseContainers;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }

    // Use this for initialization
    void Start()
    {
        InputManager.OnItemChangeKeyDown += () => OnChange(this);
        dataBase = GameObject.Find("GameHandlers").GetComponentInChildren<ItemDataBase>();
        OnChange += (inv) => ChangeInventoryItem();
        OnAfterChange += (item) => RefreshAvailableContainer();
        OnNewItemAdded += (item) => RefreshAvailableContainer();
        WeaponManager.OnCantReload += (item) => RefreshAvailableContainer();
    }

    // Update is called once per frame
    void Update()
    {
        CleanInventory();
    }

    void ChangeInventoryItem()
    {
        if (VisibleInventory.Count() != 0)
        {

            if (VisibleInventory.Count() == currentIndex + 1)
            {
                currentIndex = 0;
                currentItem = VisibleInventory.ElementAt(currentIndex);
            }
            else
            {
                currentItem = VisibleInventory.ElementAt(currentIndex + 1);
                currentIndex++;
            }

            OnAfterChange(currentItem);
        }
    }

    void CleanInventory()
    {
        foreach (Item item in inventory)
        {
            if (item == null)
            {
                inventory.Remove(item);
                break;
            }
        }
    }

    void RefreshAvailableContainer()
    {
        if (currentItem is WeaponBase)
        {
            var magazine = (currentItem as WeaponBase).Magazine;
            if (magazine != null)
            {
                var containers = GetAllContainers(magazine.id);
                var container = containers != null ? containers.OrderBy(c => c.Count).FirstOrDefault(c => c.Count > 0)  : null;
                if (OnContainerAvailable != null)
                {
                    OnContainerAvailable(ref container);
                }
            }
        }
    }

}
