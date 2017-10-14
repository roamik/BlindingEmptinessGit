using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerAnimController : MonoBehaviour
    {
        Inventory playerInventory;
        Animator animator;
        private void Start()
        {
            playerInventory = GameObject.Find("Player_test_2").GetComponentInChildren<Inventory>();
            animator = GetComponent<Animator>();
            playerInventory.OnAfterChange += (sender, e) => ChangePlayerAnimController();
            playerInventory.OnAfterChange += (sender, e) => SetVisibleItemAnimControllerId(sender as Item);
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

            playerInventory.OnAfterChange -= (sender, e) => ChangePlayerAnimController();
        }

        void SetVisibleItemAnimControllerId(Item item)
        {
            animator.SetInteger("ItemId", item.id);
        }
    }
}
