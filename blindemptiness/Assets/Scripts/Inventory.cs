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
    private InputManager inputManager;

    public delegate void InventoryChangeEventHandler(object sender, EventArgs e);

    public event InventoryChangeEventHandler OnChange;

    public event InventoryChangeEventHandler OnAfterChange;

    public void AddItem(Item item)
    {
        inventory.Add(item);
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

    // Use this for initialization
    void Start()
    {
        inputManager = GameObject.Find("GameHandlers").GetComponentInChildren<InputManager>();
        inputManager.OnItemChangeKeyDown += (e) => OnChange(this, e);
        dataBase = GameObject.Find("GameHandlers").GetComponentInChildren<ItemDataBase>();
        OnChange += (sender, e) => ChangeInventoryItem();
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

            OnAfterChange(currentItem, EventArgs.Empty);
            int currentItemId = currentItem.id;
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

}
