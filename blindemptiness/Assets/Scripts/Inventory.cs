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
    public IEnumerable<Item> Containers { get { return inventory.Where(i => i is AmmoContainerBase); } }

    private Animator anim;
    private ItemDataBase dataBase;
    public Item currentItem;
    public int currentIndex;
    public List<Item> inventory = new List<Item>() { };
    private GameObject arm;
    private GameObject graphicArm;
    private SpriteRenderer graphicArmSpriteRenderer;
    private float nextFire;
    

    public void AddItem(Item item)
    {
        //item.AddToInventory(ref inventory);
        //item.temp = DateTime.Now.Ticks.ToString();
        inventory.Add(item);
    }

    public List<AmmoContainerBase> GetAllContainers(int id )
    {
        var allContainers = inventory.Where(d => d !=null && d.id == id);
        if(allContainers != null && allContainers.Count() != 0)
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
        nextFire = Time.time;
        dataBase = GameObject.Find("DataBase").GetComponent<ItemDataBase>();
        //inventory.AddRange(dataBase.items);
        foreach (Transform t in transform)
        {
            if (t.name == "ArmRight")
            {

                foreach (Transform t2 in t.transform)
                {
                    if (t2.name == "Forearm")
                    {
                        foreach (Transform t3 in t2.transform)
                        {
                            if (t3.name == "GraphArm")
                            {
                                graphicArm = t3.gameObject;
                            }

                        }
                    }

                }
            }

        }
    
        if(graphicArm != null)
        {
            graphicArmSpriteRenderer = graphicArm.GetComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update ()
    {
        CleanInventory();
        //toggle weapons
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeInventoryItem();
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            foreach (Item item in inventory)
            {
               Debug.Log(item.ToString());
            }
        }
        if (Input.GetButton("Fire1")&& nextFire < Time.time)
        {
            if(currentItem != null && currentItem is WeaponBase)
            {            
                (currentItem as WeaponBase).Fire().Fire(!GetComponent<PlatformerCharacter2D>().m_FacingRight);
                nextFire = Time.time + (currentItem as WeaponBase).fireDelay;
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentItem != null && currentItem is WeaponBase)
            {           
                Inventory instance = this;
                (currentItem as WeaponBase).Reload(ref instance, ref inventory);
            }
        }
        
    }

    void ChangeInventoryItem()
    {
        anim = GetComponent<Animator>();

            if (VisibleInventory.Count() != 0)
            {

                if (VisibleInventory.Count() == currentIndex + 1)
                {
                    currentItem = null;
                    currentIndex = -1;
                }
                else
                {
                    currentItem = VisibleInventory.ElementAt(currentIndex + 1);
                    currentIndex++;
                }

                ChangeArmItem();
                int currentItemId = currentItem != null ? currentItem.id : -1;
                anim.SetInteger("ItemId", currentItemId);
            }
    }

    void ChangeArmItem()
    {
        if (graphicArmSpriteRenderer != null)
        {
            
            if(currentItem == null || currentItem.itemSprite == null)
            {
                graphicArmSpriteRenderer.sprite = null;
            }
            else
            {
                graphicArmSpriteRenderer.sprite = VisibleInventory.ElementAt(currentIndex).itemSprite.ItemSprite();
            }
        }
    }

    void CleanInventory()
    {
        foreach (Item item in inventory)
        {
            if(item == null)
            {
                inventory.Remove(item);
                break;
            }
        }
    }
}
