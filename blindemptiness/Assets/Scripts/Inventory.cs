using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public GameObject[] weapons;
    bool[] weaponAvailable;
    private Animator anim;
    //public Image weaponImag;

    int currentActiveWeapon; 

	// Use this for initialization
	void Start ()
    {
        weaponAvailable = new bool[weapons.Length];

        for(int i =0; i < weapons.Length; i++)
        {
            weaponAvailable[i] = false;
        }
        
        currentActiveWeapon = 0; //0 - is a index of a weapon
        weaponAvailable[currentActiveWeapon] = true;
        /*for (int i = 0; i < weapons.Length; i++)
        {
            weaponAvailable[i] = true;
        }*/

        DeactivateWeapon();

        SetWeaponActive(currentActiveWeapon);

    }
	
	// Update is called once per frame
	void Update ()
    {
        //toggle weapons
        if (Input.GetKeyDown(KeyCode.Q))
        {
          
                int i;
                for (i = currentActiveWeapon + 1; i < weapons.Length; i++)
                {
                    if (weaponAvailable[i] == true)
                    {
                        currentActiveWeapon = i;
                        SetWeaponActive(currentActiveWeapon);
                        return;
                    }
                }

                for (i = 0; i < currentActiveWeapon; i++)
                {
                    if (weaponAvailable[i] == true)
                    {
                        currentActiveWeapon = i;
                        SetWeaponActive(currentActiveWeapon);
                        return;
                    }
                }
          }
	}

    public void SetWeaponActive(int whichWeapon)
    {
        if (!weaponAvailable[whichWeapon]) return;
        DeactivateWeapon();
        weapons[whichWeapon].SetActive(true);
    }

    void DeactivateWeapon() //set all weapons which can be allowed to find, deactivated by default in player inventory
    {
        for (int i = 0; i < weapons.Length; i++) weapons[i].SetActive(false);
    }

    public void ActivateWeapon(int wichWeapon) // activates picked weapon, so that it is available in the inventory
    {
        weaponAvailable[wichWeapon] = true;
    }
}
