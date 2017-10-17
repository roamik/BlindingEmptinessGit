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
        public AudioClip changeWeaponSound;

        public void Awake()
        {
            changeWeaponSound = Resources.Load<AudioClip>("Sound/changeWeapon");
        }

        public void Start()
        {
            WeaponManager.OnFire += (weapon) => PlayWeaponFireSound(weapon);
            Inventory.OnChange += (inv) => PlayInventoryChangeSound();
            WeaponManager.OnCantFire += (weapon) => PlayWeaponNoAmmoSound(weapon);
        }

        public void PlayInventoryChangeSound()
        {
            AudioSource.PlayClipAtPoint(changeWeaponSound, transform.position, 10000f);
        }

        public void PlayWeaponFireSound(WeaponBase fireItem)
        {
            AudioSource.PlayClipAtPoint(fireItem.FireSound.ItemAudioClip(), transform.position, 10000f);
        }

        public void PlayWeaponNoAmmoSound(WeaponBase fireItem)
        {
            AudioSource.PlayClipAtPoint(fireItem.NoBulletSound.ItemAudioClip(), transform.position, 10000f);
        }
    }
}