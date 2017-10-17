using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerAnimController : MonoBehaviour
    {

        Animator animator;
        private void Start()
        {
            animator = GetComponent<Animator>();
            Inventory.OnAfterChange += (item) => ChangePlayerAnimController();
            Inventory.OnAfterChange += (item) => SetVisibleItemAnimControllerId(item);
        }

        void ChangePlayerAnimController()
        {
            animator.runtimeAnimatorController = Resources.Load("Animation/PlayerAnimsItem/PlayerAnimsItems") as RuntimeAnimatorController; //change animator

            SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();

            for (int i = 0; i < renderers.Length; i++)
            {
                if (renderers[i].enabled == false)
                {
                    renderers[i].enabled = true;
                }
            }

            Inventory.OnAfterChange -= (item) => ChangePlayerAnimController();
        }

        void SetVisibleItemAnimControllerId(Item item)
        {
            animator.SetInteger("ItemId", item.id);
        }
    }
}
