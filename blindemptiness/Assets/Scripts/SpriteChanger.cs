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

        public void Start()
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            Inventory.OnAfterChange += (item) => ChangeSprite(item);
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
