using UnityEngine;
using System.Collections;

public class BulletDestroy : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        
        if (coll.gameObject.tag != "Bullet")
        {
                Destroy(gameObject, 0.1f);
        }
    }
}