using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ItemDataBase : MonoBehaviour
{
    public List<Item> items = new List<Item>() { };

    void LoadItems()
    {
        #region Shotgun

        var shotgunBullet = new ShotgunBullet()
        {
            bulletDamage = 2f,
            bulletMass = 0.1f,
            bulletSpeed = 70f,
            bulletDispersion = 45f,
            itemSprite = new ItemImage("Sprites/", "Shotgun_Bullet")
        };

        var shotgunShell = new Shell()
        {
            itemSprite = new ItemImage("Sprites/", "Shotgun_Shell"),
        };

        var shotgunAmmo = new ShotgunAmmo()
        {
            damageCoefficient = 1.2f,
            description = "A bullet for shotgun!",
            name = "ShotgunBullet",
            itemSprite = new ItemImage("Sprites/", "Shotgun_Bullet"),
            bullets = new Bullet[20].Select(c => c = shotgunBullet).ToList(),
            shell = shotgunShell,
            ammoDispersion = 1f
        };

        var clipShotgunMagazine = new AmmoContainer<ShotgunAmmo>()
        {
            id = 4,
            MaxCount = 10,
            ammo = new ShotgunAmmo[10].Select(c => c = shotgunAmmo).ToList()       
        };

        var shotgunAmmoContainer = new AmmoContainer<ShotgunAmmo>()
        {
            itemSprite = new ItemImage("Sprites/", "ShotgunAmmo"),
            id = 4,
            name = "Shotgun Ammo",
            description = "Bullets for your shotgun",
            MaxCount = 10,
            ammo = new ShotgunAmmo[10].Select(c => c = shotgunAmmo).ToList()
        };

        var shotgun = new ShotgunWeapon
        {
            id = 2,
            name = "Shotgun",
            description = "A shotgun!",
            ammo = clipShotgunMagazine,
            fireDelay = 0.6f,
            itemSprite = new ItemImage("Sprites/", "DoubleBarrel"),
            FireSound = new ItemSound("Sound/", "shotgunFire"),
            NoBulletSound = new ItemSound("Sound/", "no_ammo")
        };
        #endregion

        #region Rifle

        var rifleBullet = new Bullet()
        {
            bulletDamage = 3f,
            bulletMass = 0.1f,
            bulletSpeed = 55f,
            bulletDispersion = 5f,
            itemSprite = new ItemImage("Sprites/", "Luger_Bullet"),
        };

        var rifleShell = new Shell()
        {
            itemSprite = new ItemImage("Sprites/", "Luger_Shell"),
        };

        var rifleAmmo = new RifleAmmo()
        {
            damageCoefficient = 1.2f,
            description = "A bullet for rifle!",
            name = "RifleBullet",
            itemSprite = new ItemImage("Sprites/", "Luger_Ammo"),
            bullets = new Bullet[1].Select(c => c = rifleBullet).ToList(),
            shell = rifleShell,
            ammoDispersion = 1f
        };

        var clipRifleMagazine = new AmmoContainer<RifleAmmo>()
        {
            id = 3,
            MaxCount = 15,
            ammo = new RifleAmmo[15].Select(c => c = rifleAmmo).ToList()
        };

        var winterRifle = new RifleWeapon
        {
            id = 1,
            name = "Winter Rifle",
            description = "A rifle used in extra cold regions!",
            ammo = clipRifleMagazine,
            itemSprite = new ItemImage("Sprites/", "WinterRifle"),
            FireSound = new ItemSound("Sound/", "shotgunFire"),
            NoBulletSound = new ItemSound("Sound/", "no_ammo"),
            fireDelay = 0.2f
        };

        var rifleAmmoContainer = new AmmoContainer<RifleAmmo>()
        {
            itemSprite = new ItemImage("Sprites/", "LugerAmmo"),
            id = 3,
            name = "Rifle Ammo",
            description = "Rifle bullets",
            MaxCount = 20,
            ammo = new RifleAmmo[20].Select(c => c = rifleAmmo).ToList()
        };
        #endregion

        items.AddRange(new List<Item>() { winterRifle, rifleAmmoContainer, shotgun, shotgunAmmoContainer });
    }

	// Use this for initialization
	void Start ()
    {
        LoadItems();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
