using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityStandardAssets._2D;

namespace Assets.Scripts
{
    public class WeaponManager : MonoBehaviour
    {
        PlatformerCharacter2D playerCharacterController;

        bool IsPlayerFacingRight { get; set; }

        AmmoContainerBase AvailableContainer;

        float nextFire;

        WeaponBase CurrentWeapon { get; set; }

        public delegate void RefAction<T1, T2>(ref T1 arg1, T2 arg2);

        public delegate void RefAction<T1>(ref T1 arg1);

        public static event Action<WeaponBase> OnFire;

        public static event Action<WeaponBase> OnReload;

        public static event Action<WeaponBase> OnCantFire;

        public static event Action<WeaponBase> OnCantReload;

        public static event Action<WeaponBase> OnAfterFire;

        public static event Action<WeaponBase, AmmoContainerBase> OnAfterReload;

        void Start()
        {
            nextFire = Time.time;
            playerCharacterController = GameObject.Find("Player_test_2").GetComponentInChildren<PlatformerCharacter2D>();
            playerCharacterController.OnFlip += (playerFacing, e) => { IsPlayerFacingRight = (bool)playerFacing; };
            InputManager.OnFireKeyDown += () => WeaponNextFireCalculation();
            InputManager.OnReloadKeyDown += () => WeaponReloadCalculation();
            Inventory.OnAfterChange += (item) => CurrentWeapon = item as WeaponBase;
            Inventory.OnContainerAvailable += SetContainerRef;
            OnFire += (weapon) => PlayerWeaponFire(weapon);
            OnReload += (weapon) => PlayerWeaponReload(weapon);

        }

        void SetContainerRef(ref AmmoContainerBase container)
        {
            AvailableContainer = container;
        }

        void WeaponNextFireCalculation()
        {
            if (nextFire < Time.time && CurrentWeapon != null)
            {
                if (CurrentWeapon.HasAmmo)
                {
                    if (OnFire != null)
                    {
                        OnFire(CurrentWeapon);
                        if (OnAfterFire != null)
                        {
                            OnAfterFire(CurrentWeapon);
                        }
                    }
                }
                else
                {
                    if (OnCantFire != null)
                    {
                        OnCantFire(CurrentWeapon);
                    }
                }
                nextFire = Time.time + CurrentWeapon.fireDelay;
            }
        }

        void PlayerWeaponFire(WeaponBase fireItem)
        {
            fireItem.Fire().BulletFire(!IsPlayerFacingRight);
        }

        void PlayerWeaponReload(WeaponBase fireItem)
        {
            fireItem.Reload(ref AvailableContainer);
        }

        void WeaponReloadCalculation()
        {
            if (AvailableContainer != null && AvailableContainer.Count > 0)
            {
                if (OnReload != null)
                {
                    OnReload(CurrentWeapon);
                    if (OnAfterReload != null)
                    {
                        OnAfterReload(CurrentWeapon, AvailableContainer);
                    }
                }
            }
            else
            {
                if(OnCantReload != null)
                {
                    OnCantReload(CurrentWeapon);
                }
            }
        }
    }
}
