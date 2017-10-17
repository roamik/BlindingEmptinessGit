using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class InputManager : MonoBehaviour
    {
        public static event Action OnItemChangeKeyDown;

        public static event Action OnFireKeyDown;

        public static event Action OnReloadKeyDown;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (OnItemChangeKeyDown != null)
                {
                    OnItemChangeKeyDown();
                }
            }

            if (Input.GetButton("Fire1"))//&& nextFire < Time.time
            {
                if (OnFireKeyDown != null)
                {
                    OnFireKeyDown();
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                if (OnReloadKeyDown != null)
                {
                    OnReloadKeyDown();   
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
