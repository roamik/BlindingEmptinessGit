using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
[System.Serializable]
public class Item
{
    public int id;
    //private static int lastId = 0;
    public string name;
    public string description;
    public ItemImage itemSprite;

    [SerializeField] public string temp;
    //private string itemSpritePath;
    //private string itemSpriteName;

    public Item ()
    {
        temp = DateTime.UtcNow.Ticks.ToString();
        //id = lastId++;
    }


    public virtual void AddToInventory(ref List<Item> inventory)
    {
        inventory.Add(this);
    }


    public override string ToString()
    {
        return name + "[" + temp + "]";
    }

    public static T DeepClone<T>(T obj)
    {
        using (var ms = new MemoryStream())
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(ms, obj);
            ms.Position = 0;

            return (T)formatter.Deserialize(ms);
        }
    }
}
[System.Serializable]
public class ItemImage
{
    public string itemSpritePath;
    public string itemSpriteName;
    public Sprite ItemSprite()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>(itemSpritePath);
        foreach (Sprite s in sprites)
        {
            if (s.name == itemSpriteName)
            {
                return s;    
            }
        }
        return null;
    }

    public ItemImage(string itemSpritePath, string itemSpriteName)
    {
        this.itemSpriteName = itemSpriteName;
        this.itemSpritePath = itemSpritePath;
    }
}



