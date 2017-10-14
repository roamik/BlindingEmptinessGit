using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

[System.Serializable]
public class Ammo : Item
{
    public float damageCoefficient = 1f;
    public List <Bullet> bullets;
    public Shell shell;
    public float ammoDispersion = 0f;


    public float damage
    {
        get
        {
            return bullets.Sum(p => p.bulletDamage) * damageCoefficient;
        }
    }

    public void Fire(bool flip)
    {
        GameObject bulletPrefab = Resources.Load("Prefabs/bulletPrefab") as GameObject;
        GameObject bulletSpawner = GameObject.Find("bulletSpawner");
        //GameObject shellSpawner = GameObject.Find("shellSpawner");
        List<GameObject> bulletsGameObjects = new List<GameObject>();

        foreach(Bullet bullet in bullets)
        {
            //var rigidBody = bulletPrefab.GetComponent<Rigidbody2D>();
            bulletPrefab.GetComponent<Rigidbody2D>().mass = bullet.bulletMass;
            //bulletPrefab.GetComponent<Rigidbody2D>().velocity = bulletSpawner.transform.forward * bullet.bulletSpeed;
            bulletPrefab.transform.position = bulletSpawner.transform.position;
            bulletPrefab.transform.rotation = bulletSpawner.transform.rotation;
            bulletPrefab.transform.localScale = bulletSpawner.transform.localScale;
            float rotAngle = UnityEngine.Random.Range(bullet.bulletDispersion * ammoDispersion * -1, bullet.bulletDispersion * ammoDispersion);
            bulletPrefab.transform.Rotate(0, 0, rotAngle);
            bulletPrefab.GetComponent<SpriteRenderer>().sprite = bullet.itemSprite.ItemSprite();
            GameObject bulletg = GameObject.Instantiate(bulletPrefab);
            //bulletg.GetComponent<Rigidbody2D>().velocity = bulletSpawner.transform.forward * bullet.bulletSpeed;
            var blabla = Quaternion.AngleAxis(bulletPrefab.transform.rotation.eulerAngles.z, Vector3.forward) * Vector2.right;
            if(flip)
            {
                blabla = Quaternion.AngleAxis(bulletPrefab.transform.rotation.eulerAngles.z, Vector3.forward) * Vector2.left;
            }
            Debug.Log(blabla);
            bulletg.GetComponent<Rigidbody2D>().AddForce(blabla * bullet.bulletSpeed, ForceMode2D.Impulse);
            GameObject.Destroy(bulletg, 0.05f);
            // bulletsGameObjects.Add(bulletPrefab);
        }

        foreach(GameObject gm in bulletsGameObjects)
        {
            GameObject bullet = GameObject.Instantiate(gm);
            GameObject.Destroy(bullet, 10f);
        }
        
    }
}
