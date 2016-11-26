using UnityEngine;
using System.Collections;

public class WeaponPickupController : MonoBehaviour
{
    public int wichWeapon;
    public AudioClip pickupClip;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.tag=="Player")
        {
            other.gameObject.GetComponent<Inventory>().ActivateWeapon(wichWeapon);
            Destroy(transform.root.gameObject);
            AudioSource.PlayClipAtPoint(pickupClip, transform.position, 10000f);
        }
          
        
    }
}
