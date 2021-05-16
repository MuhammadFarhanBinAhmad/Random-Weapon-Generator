using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUNINATORGunCreation : MonoBehaviour
{

    RandomWeaponGenerator the_RWG;

    public GameObject GUN_INATOR;

    public int w_Total_Cost;

    int w_Cost, ra_Cost, e_Cost, ro_Cost;
    int w_Type, ra_Type, e_Type, ro_Type;

    bool GUN_INATOR_Open;

    private void Start()
    {
        the_RWG = GetComponent<RandomWeaponGenerator>();
    }

    public void WeaponType(int type)
    {
        if (type == 0)
        {
            w_Cost = 1;
        }
        if (type == 1)
        {
            w_Cost = 2;
        }
        if (type == 2)
        {
            w_Cost = 2;
        }
        if (type == 3)
        {
            w_Cost = 3;
        }
        if (type == 4)
        {
            w_Cost = 3;
        }
        if (type == 5)
        {
            w_Cost = 4;
        }
        if (type == 6)
        {
            w_Cost = 5;
        }
        w_Type = type;
        Order();
    }
    public void RarityType(int rarity)
    {
        if (rarity == 0)
        { 
            ra_Cost = 1;
        }
        if (rarity == 1)
        {
            ra_Cost = 2;
        }
        if (rarity == 2)
        {
            ra_Cost = 3;
        }
        if (rarity == 3)
        {
            ra_Cost = 4;
        }
        if (rarity == 4)
        {
            ra_Cost = 5;
        }
        ra_Type = rarity;
        Order();
    }
    public void ElementType(int element)
    {
        if (element != 0)
        {
            e_Cost = 2;
        }
        else
        {
            e_Cost = 0;
        }
        e_Type = element;
        Order();
    }
    public void RoundType(int round)
    {
        if (round != 0)
        {
            ro_Cost = 2;
        }
        else
        {
            e_Cost = 0;
        }
        ro_Type = round;
        Order();
    }
    void Order()
    {
        w_Total_Cost = w_Cost + ra_Cost + e_Cost + ro_Cost;

        the_RWG.the_Weapon_Type = w_Type;
        the_RWG.the_Weapon_Rarity = ra_Type;
        the_RWG.the_Element_Type = e_Type;
        the_RWG.the_Round_Type = ro_Type;
    }
    public void CreateRandomWeapon()
    {
        w_Total_Cost = 5;

        if (FindObjectOfType<PlayerManager>().money_Total >= w_Total_Cost)
        {
            w_Type = Random.Range(0, 7);
            print(w_Type);
            the_RWG.the_Weapon_Type = w_Type;
            the_RWG.the_Weapon_Rarity = Random.Range(0, 4);
            the_RWG.the_Element_Type = Random.Range(0, 5);
            the_RWG.the_Round_Type = Random.Range(0, 6);

            FindObjectOfType<PlayerManager>().money_Total -= w_Total_Cost;

            the_RWG.CreateWeaponStats(w_Type);
        }
    }

    public void CreateWeapon()
    {
        if (FindObjectOfType<PlayerManager>().money_Total >= w_Total_Cost)
        {
            FindObjectOfType<PlayerManager>().money_Total -= w_Total_Cost;
            the_RWG.CreateWeaponStats(w_Type);
        }
        else
        {
            print("Not Enough Money");
        }
    }

    public void OpenStore()
    {
        if (!GUN_INATOR_Open)
        {
            Cursor.lockState = CursorLockMode.None;
            GUN_INATOR_Open = true;
            GUN_INATOR.SetActive(true);
            Time.timeScale = 0;

        }
        else if (GUN_INATOR_Open)
        {
            Cursor.lockState = CursorLockMode.Locked;
            GUN_INATOR_Open = false;
            GUN_INATOR.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
