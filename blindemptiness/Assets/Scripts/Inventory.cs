using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System;

public class Inventory : MonoBehaviour
{

   // public GameObject[] weapons;
   // bool[] weaponAvailable;
    private Animator anim;
    private ItemDataBase dataBase;
    public Item currentItem;
    public List<Item> inventory = new List<Item>() { };
    private GameObject arm;
    private GameObject graphicArm;
    private SpriteRenderer graphicArmSpriteRenderer;

    public void AddItem(Item item)
    {
        inventory.Add(item);
    }

    //public Image weaponImag;

    // int currentActiveWeapon; 


    // Use this for initialization
    void Start ()
    {
        foreach (Transform t in transform)
        {
            if (t.name == "Arm")
            {
                arm = t.gameObject;
                foreach (Transform t2 in arm.transform)
                {
                    if (t2.name == "GraphArm")
                    {
                        graphicArm = t2.gameObject;
                    }

                }

            }
     
        }

        if(graphicArm != null)
        {
            graphicArmSpriteRenderer = graphicArm.GetComponent<SpriteRenderer>();
        }
        dataBase = GameObject.Find("DataBase").GetComponent<ItemDataBase>();
        inventory.AddRange(dataBase.items);
        #region Comented code
        // weaponAvailable = new bool[weapons.Length];

        //for(int i =0; i < weapons.Length; i++)
        //{
        //  //  weaponAvailable[i] = false;
        //}

        //currentActiveWeapon = 0; //0 - is a index of a weapon
        //weaponAvailable[currentActiveWeapon] = true;
        /*for (int i = 0; i < weapons.Length; i++)
        {
            weaponAvailable[i] = true;
        }*/

        //DeactivateWeapon();

        //SetWeaponActive(currentActiveWeapon);
        #endregion
    }

    // Update is called once per frame
    void Update ()
    {
        //toggle weapons
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeInventoryItem();

            #region Coment
            //int i;
            //for (i = currentActiveWeapon + 1; i < weapons.Length; i++)
            //{
            //    if (weaponAvailable[i] == true)
            //    {
            //        currentActiveWeapon = i;
            //        SetWeaponActive(currentActiveWeapon);
            //        return;
            //    }
            //}

            //for (i = 0; i < currentActiveWeapon; i++)
            //{
            //    if (weaponAvailable[i] == true)
            //    {
            //        currentActiveWeapon = i;
            //        SetWeaponActive(currentActiveWeapon);
            //        return;
            //    }
            //}
            #endregion
        }
    }

    void ChangeInventoryItem()
    {
        if (inventory.Count != 0)
        {
            int index = inventory.IndexOf(currentItem);
            if (inventory.Count == index + 1)
            {

                currentItem = inventory.FirstOrDefault();
            }
            else
            {
                currentItem = inventory[index + 1];
            }

            ChangeArmItem();
        }
    }

    void ChangeArmItem()
    {
        if (graphicArmSpriteRenderer != null)
        {
            graphicArmSpriteRenderer.sprite = currentItem.itemSpite;
        }
    }
}
