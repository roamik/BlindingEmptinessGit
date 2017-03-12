using UnityEngine;
using System.Collections;

public class MetalWallBulletEffect : MonoBehaviour
{
    GameObject partSystem;

    void Start()
    {
        partSystem = Resources.Load("Prefabs/PS_Metal") as GameObject;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "Bullet")
        {
            ContactPoint2D contact = coll.contacts[0];
            //contact.point; //this is the Vector3 position of the point of contact
            GameObject gm = Instantiate(partSystem, contact.point, Quaternion.Euler(new Vector3(0, -90, 0))) as GameObject;
            Destroy(gm, 1f);
        }
    }
}
