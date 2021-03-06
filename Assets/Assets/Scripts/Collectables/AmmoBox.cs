using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    int ammo_Type;

    public List<int> ammo_To_Give = new List<int>();//amount of ammo to give

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerManager>() !=null)
        {
            PickUpAmmo(other.GetComponent<PlayerManager>());
        }
    }

    void PickUpAmmo(PlayerManager PM)
    {

        ammo_Type = PM.weapon_Inventory[PM.current_Weapon].the_Weapon_Type_Int;
        /*PM.weapon_Inventory[PM.current_Weapon].gun_Total_Ammo += ammo_To_Give[ammo_Type];//give ammo to respective weapon type
        FindObjectOfType<PlayerUIHUD>().AmmoUpdate(PM.current_Weapon);*/
        PM.weapon_Inventory[PM.current_Weapon].AddAmmo(ammo_To_Give[ammo_Type]);
        Destroy(gameObject);
    }
}
