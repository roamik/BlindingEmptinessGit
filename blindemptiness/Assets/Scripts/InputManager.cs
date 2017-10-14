using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class InputManager : MonoBehaviour
    {
        public delegate void InventoryChangeKeyDownEventHandler(EventArgs e);
        public event InventoryChangeKeyDownEventHandler OnItemChangeKeyDown;

        public delegate void FireKeyDownEventHandler(EventArgs e);
        public event FireKeyDownEventHandler OnFireKeyDown;

        public delegate void ReloadKeyDownEventHandler(EventArgs e);
        public event ReloadKeyDownEventHandler OnReloadKeyDown;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (OnItemChangeKeyDown != null)
                {
                    OnItemChangeKeyDown(EventArgs.Empty);
                }
            }

            if (Input.GetButton("Fire1"))//&& nextFire < Time.time
            {
                if (OnFireKeyDown != null)
                {
                    OnFireKeyDown(EventArgs.Empty);
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                if (OnReloadKeyDown != null)
                {
                    OnReloadKeyDown(EventArgs.Empty);
                    //if (currentItem != null && currentItem is WeaponBase)
                    //{
                    //    Inventory instance = this;
                    //    (currentItem as WeaponBase).Reload(ref instance, ref inventory);
                    //}
                }
            }

            #region DebugStuff
            //if (Input.GetKeyDown(KeyCode.O))
            //{
            //    foreach (Item item in inventory)
            //    {
            //        Debug.Log(item.ToString());
            //    }
            //}
            #endregion
        }
    }
}
