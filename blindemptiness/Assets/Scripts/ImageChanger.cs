using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ImageChanger : MonoBehaviour
    {
        Image imageRenderer;
        Inventory playerInventory;

        public void Start()
        {
            playerInventory = GameObject.Find("Player_test_2").GetComponentInChildren<Inventory>();
            imageRenderer = gameObject.GetComponent<Image>();
            imageRenderer.color = new Color(255f,255f,255f,0f);
            imageRenderer.type = Image.Type.Filled;
            imageRenderer.fillMethod = Image.FillMethod.Radial360;
            imageRenderer.preserveAspect = true;
            playerInventory.OnAfterChange += (sender, e) => ChangeSprite(sender as Item);
        }

        void ChangeSprite(Item item)
        {
            if (imageRenderer != null)
            {
                if (item == null || item.itemSprite == null)
                {
                    imageRenderer.sprite = null;
                }
                else
                {
                    imageRenderer.sprite = item.itemSprite.ItemSprite();
                    imageRenderer.color = new Color(255f, 255f, 255f, 255f);
                }
            }
        }
    }
}
