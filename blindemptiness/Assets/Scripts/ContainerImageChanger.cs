using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ContainerImageChanger : MonoBehaviour
    {
        Image imageRenderer;
        Text textRenderer;

        public void Start()
        {
            imageRenderer = gameObject.GetComponentInChildren<Image>();
            textRenderer = gameObject.GetComponentInChildren<Text>();
            imageRenderer.color = new Color(255f, 255f, 255f, 0f);
            imageRenderer.type = Image.Type.Filled;
            imageRenderer.fillMethod = Image.FillMethod.Radial360;
            imageRenderer.preserveAspect = true;
            Inventory.OnContainerAvailable += ChangeSprite;
            Inventory.OnContainerAvailable += UpdateText;
            WeaponManager.OnAfterReload += (weapon,container) => UpdateText(ref container);
            WeaponManager.OnAfterReload += (weapon, container) => { ChangeSprite(ref container); };
        }

        void ChangeSprite(ref AmmoContainerBase container)
        {
            if (imageRenderer != null)
            {
                if (container == null || container.itemSprite == null || container.Count == 0)
                {
                    imageRenderer.sprite = null;
                    imageRenderer.color = new Color(255f, 255f, 255f, 0f);
                }
                else
                {   
                    imageRenderer.sprite = container.itemSprite.ItemSprite();
                    imageRenderer.color = new Color(255f, 255f, 255f, 255f);
                }
            }
        }

        void UpdateText(ref AmmoContainerBase container)
        {
            if (textRenderer != null)
            {
                if (container == null || container.Count == 0)
                {
                    textRenderer.text = string.Empty;
                }
                else
                {
                    textRenderer.text = container.Count.ToString() + "/" + container.MaxCount.ToString();
                }
            }
        }
    }
}
