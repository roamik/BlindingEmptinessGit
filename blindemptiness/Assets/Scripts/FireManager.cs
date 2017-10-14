using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityStandardAssets._2D;

namespace Assets.Scripts
{
    public class FireManager : MonoBehaviour
    {
        InputManager inputManager;
        Inventory playerInventory;
        PlatformerCharacter2D playerCharacterController;

        bool IsPlayerFacingRight { get; set; }

        float nextFire;

        public delegate void FireEventHandler(object sender, EventArgs e);

        public event FireEventHandler OnFire;

        void Start()
        {
            nextFire = Time.time;
            playerInventory = GameObject.Find("Player_test_2").GetComponentInChildren<Inventory>();
            playerCharacterController = GameObject.Find("Player_test_2").GetComponentInChildren<PlatformerCharacter2D>();
            playerCharacterController.OnFlip += (playerFacing, e) => { IsPlayerFacingRight = (bool)playerFacing; };
            OnFire += (sender, e) => PlayerWeaponFire(sender as WeaponBase);
            inputManager = GameObject.Find("GameHandlers").GetComponentInChildren<InputManager>();
            inputManager.OnFireKeyDown += (e) => NextFireCalculation();

        }

        void NextFireCalculation ()
        {
            if (nextFire < Time.time)
            {
                OnFire(playerInventory.currentItem, EventArgs.Empty);
                nextFire = Time.time + (playerInventory.currentItem as WeaponBase).fireDelay;
            }
        }

        void PlayerWeaponFire(WeaponBase fireItem)
        {
            fireItem.Fire().Fire(!IsPlayerFacingRight);
        }
    }
}
