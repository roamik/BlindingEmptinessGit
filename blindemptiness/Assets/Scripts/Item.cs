using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item
{
    public int id;
    private static int lastId = 0;
    public string name;
    public string description;
    public Sprite itemSpite;
    //private string itemSpritePath;
    //private string itemSpriteName;

    public Item ()
    {
        //id = lastId++;
    }

    public Item (string itemSpritePath, string itemSpriteName)
       :this ()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>(itemSpritePath);
        foreach (Sprite s in sprites)
        {
            if (s.name == itemSpriteName)
            {
                this.itemSpite = s;
                break;
            }
        }
    }
}

