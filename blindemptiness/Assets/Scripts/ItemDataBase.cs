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
            bulletSpeed = 4f,
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
            maxCount = 10000,
            ammo = new ShotgunAmmo[10000].Select(c => c = shotgunAmmo).ToList()       
        };

        var shotgunAmmoContainer = new AmmoContainer<ShotgunAmmo>()
        {
            itemSprite = new ItemImage("Sprites/", "ShotgunAmmo"),
            id = 4,
            name = "Shotgun Ammo",
            description = "Bullets for your shotgun",
            maxCount = 10,
            ammo = new ShotgunAmmo[10].Select(c => c = shotgunAmmo).ToList()
        };

        var shotgun = new ShotgunWeapon
        {
            id = 2,
            name = "Shotgun",
            description = "A shotgun!",
            ammo = clipShotgunMagazine,
            itemSprite = new ItemImage("Sprites/", "DoubleBarrel"),
            fireDelay = 0.6f
        };
        #endregion

        #region Rifle

        var rifleBullet = new Bullet()
        {
            bulletDamage = 3f,
            bulletMass = 0.1f,
            bulletSpeed = 6f,
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
            maxCount = 10000,
            ammo = new RifleAmmo[10000].Select(c => c = rifleAmmo).ToList()
        };

        var winterRifle = new RifleWeapon
        {
            id = 1,
            name = "Winter Rifle",
            description = "A rifle used in extra cold regions!",
            ammo = clipRifleMagazine,
            itemSprite = new ItemImage("Sprites/", "WinterRifle"),
            fireDelay = 1f
        };

        var rifleAmmoContainer = new AmmoContainer<RifleAmmo>()
        {
            itemSprite = new ItemImage("Sprites/", "LugerAmmo"),
            id = 3,
            name = "Rifle Ammo",
            description = "Rifle bullets",
            maxCount = 20,
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
