using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Bullet : Item
{
    public float bulletSpeed = 1f;
    public float bulletDamage = 1f;
    public float bulletMass = 1f;
    public float bulletDispersion = 0f;
}
