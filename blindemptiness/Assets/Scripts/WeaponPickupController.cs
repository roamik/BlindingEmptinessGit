using UnityEngine;
using System.Collections;

public class WeaponPickupController : MonoBehaviour
{
    private Item item;
    public AudioClip pickupClip;
    private ItemDataBase dataBase;
    public int id;
    public SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start ()
    {
        
        dataBase = GameObject.Find("DataBase").GetComponent<ItemDataBase>();
        item = dataBase.items.Find(c => c.id == id);
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.itemSpite; 
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.tag=="Player")
        {
            other.gameObject.GetComponent<Inventory>().AddItem(item);
            Destroy(transform.root.gameObject);
            AudioSource.PlayClipAtPoint(pickupClip, transform.position, 10000f);
        }
          
        
    }
}
