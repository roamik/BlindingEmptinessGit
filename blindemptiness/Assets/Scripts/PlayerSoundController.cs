using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityStandardAssets._2D;

namespace Assets.Scripts
{
    public class PlayerSoundController : MonoBehaviour
    {
        FireManager fireManager;
        Inventory playerInventory;
        public AudioClip changeWeaponSound;
        private float nextFire;

        public void Awake()
        {
            fireManager = GameObject.Find("GameHandlers").GetComponentInChildren<FireManager>();
            changeWeaponSound = Resources.Load<AudioClip>("Sound/changeWeapon");
            playerInventory = gameObject.GetComponent<Inventory>();
        }

        public void Start()
        {
            fireManager.OnFire += (sender, e) => PlayWeaponFireSound(sender as WeaponBase);
            playerInventory.OnChange += (sender, e) => PlayInventoryChangeSound();
        }

        public void PlayInventoryChangeSound()
        {
            if (playerInventory.VisibleInventory.Count() > 1)
            {
                AudioSource.PlayClipAtPoint(changeWeaponSound, transform.position, 10000f);
            }
        }

        public void PlayWeaponFireSound(WeaponBase fireItem)
        {
            AudioSource.PlayClipAtPoint(fireItem.FireSound.ItemAudioClip(), transform.position, 10000f);
        }
    }
}