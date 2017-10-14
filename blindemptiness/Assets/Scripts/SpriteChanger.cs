using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class SpriteChanger : MonoBehaviour
    {
        SpriteRenderer spriteRenderer;
        Inventory playerInventory;

        public void Start()
        {
            playerInventory = GameObject.Find("Player_test_2").GetComponentInChildren<Inventory>();
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            playerInventory.OnAfterChange += (sender, e) => ChangeSprite(sender as Item);
        }

        void ChangeSprite(Item item)
        {
            if (spriteRenderer != null)
            {

                if (item == null || item.itemSprite == null)
                {
                    spriteRenderer.sprite = null;
                }
                else
                {
                    spriteRenderer.sprite = item.itemSprite.ItemSprite();
                }
            }
        }
    }
}
