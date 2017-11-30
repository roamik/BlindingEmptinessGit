using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class WeaponImageChanger : MonoBehaviour
    {
        Image imageRenderer;
        Text textRenderer;

        public void Start()
        {
            imageRenderer = gameObject.GetComponentInChildren<Image>();
            textRenderer = gameObject.GetComponentInChildren<Text>();
            imageRenderer.color = new Color(255f,255f,255f,0f);
            imageRenderer.type = Image.Type.Filled;
            imageRenderer.fillMethod = Image.FillMethod.Radial360;
            imageRenderer.preserveAspect = true;
            Inventory.OnAfterChange += (item) => ChangeSprite(item);
            Inventory.OnAfterChange += (item) => UpdateText(item);
            WeaponManager.OnAfterFire += (weapon) => UpdateText(weapon);
            WeaponManager.OnAfterReload += (weapon, container) => UpdateText(weapon);

        }

        void ChangeSprite(Item item)
        {
            if (imageRenderer != null)
            {
                if (item == null || item.itemSprite == null)
                {
                    imageRenderer.sprite = null;
                    imageRenderer.color = new Color(255f, 255f, 255f, 0f);
                }
                else
                {
                    imageRenderer.sprite = item.itemSprite.ItemSprite();
                    imageRenderer.color = new Color(255f, 255f, 255f, 255f);
                }
            }
        }

        void UpdateText(Item item)
        {
            if (textRenderer != null)
            {
                if (item == null)
                {
                    textRenderer.text = string.Empty;
                }
                else
                {
                    textRenderer.text = (item as WeaponBase).Magazine.Count.ToString() + "/" + (item as WeaponBase).Magazine.MaxCount.ToString();
                }
            }
        }
    }
}
