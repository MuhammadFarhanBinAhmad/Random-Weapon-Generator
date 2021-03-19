using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWeaponGenerator : MonoBehaviour
{
    /// <Type of Weapon>
    /// 0 - Pistol
    /// 1 - SubMachineGun
    /// 2 - Rifle
    /// 3 - Shotgun
    /// 4 - DoubleBarrrel_ShotGun
    /// 5 - MachineGun
    /// 6 - Rocket

    /*public enum Type { Pistol, SubMachineGun, Rifle, Shotgun,DoubleBarrrel_ShotGun, MachineGun,Rocket };
    public Type the_Weapon_Type;*/
    public int the_Weapon_Type;
    //NAME//
    public string weapon_name;

    //TYPE//
    /// <Type of mode>
    /// 1 - Single
    /// 2 - Burst
    /// 3 - Auto
    /// </summary>
    int the_Weapon_Mode;

    int the_Round_Type;

    int the_Element_Type;

    //STATS//

    float fire_Rate;
    float reload_Time;
    int min_Damage, max_Damage;
    int total_Ammo;
    int mag_Capacity;
    //For ShotGuns
    int rounds_Shot;
    bool is_Shotgun;
    //For Rocket
    bool is_Rocket;

    public GameObject testObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //the_Weapon_Type = Random.Range(0,6);
            the_Weapon_Type = 6;
            CreateWeaponStats(the_Weapon_Type);
        }
    }
    /// <Type of Weapon>
    /// 0 - Pistol
    /// 1 - SubMachineGun
    /// 2 - Rifle
    /// 3 - Shotgun
    /// 4 - DoubleBarrrel_ShotGun
    /// 5 - MachineGun
    /// 6 - Rocket
    void CreateWeaponStats(int WT)
    {
        //Set up Stats
        switch (the_Weapon_Type)
        {
            case 0:
                {
                    reload_Time = 1;
                    fire_Rate = 1;
                    total_Ammo = 100;
                    mag_Capacity = 10;
                    min_Damage = 10;
                    max_Damage = 20;
                    break;
                }
            case 1:
                {
                    reload_Time = 1.25f;
                    fire_Rate = 6.5f;
                    total_Ammo = 250;
                    mag_Capacity = 25;
                    min_Damage = 15;
                    max_Damage = 25;
                    break;
                }
            case 2:
                {
                    reload_Time = 1.25f;
                    fire_Rate = 4f;
                    total_Ammo = 300;
                    mag_Capacity = 30;
                    min_Damage = 20;
                    max_Damage = 35;
                    break;
                }
            case 3:
                {
                    reload_Time = .75f;
                    fire_Rate = .7f;
                    total_Ammo = 80;
                    mag_Capacity = 8;
                    min_Damage = 10;
                    max_Damage = 20;
                    rounds_Shot = 10;
                    break;
                }
            case 4:
                {
                    reload_Time = .75f;
                    fire_Rate = .7f;
                    total_Ammo = 40;
                    mag_Capacity = 2;
                    min_Damage = 15;
                    max_Damage = 35;
                    rounds_Shot = 30;
                    break;
                }
            case 5:
                {
                    reload_Time = 1.5f;
                    fire_Rate = 4.5f;
                    total_Ammo = 400;
                    mag_Capacity = 100;
                    min_Damage = 25;
                    max_Damage = 40;
                    break;
                }
            case 6:
                {
                    reload_Time = 1.5f;
                    fire_Rate = 1;
                    total_Ammo = 10;
                    mag_Capacity = 1;
                    min_Damage = 150;
                    max_Damage = 300;
                    break;
                }
        }
        if (the_Weapon_Type !=6)
        {
            AmmoType(Random.Range(0, 9));//excluding rocket
        }
        else
        {
            ElementalType(Random.Range(0, 5));//for rocket 
        }
    }
    void AmmoType(int RT)
    {
        /// <Type of Round>
        /// 0 - Normal
        /// 1 - Explosive - create small explosive that hurt nearby enemy
        /// 2 - Piercing - pierce through enemy
        /// 3 - Stunning - Stun enemy for a bit
        /// 4 - Punch out - push enemy back
        /// 5 - Healing - gain small bit of health from hit enemy
        /// 6 - Payback - A succesful hit return 1 round back
        /// 7 - QuickPace - Every Succesful hit make the player faster
        /// 8 - Flyer - Make Player jump higher
        /// 9 - Tracer - Home to the nearest enemy
        the_Round_Type = RT;

        //Set Ammo type
        switch(RT)
        {
            case 1:
                {
                    if (!is_Rocket)
                    {
                        weapon_name += "Explosive ";
                    }
                    break;
                }
            case 2:
                {
                    weapon_name += "Piercing ";
                    break;
                }
            case 3:
                {
                    weapon_name += "Stunning ";
                    break;
                }
            case 4:
                {
                    weapon_name += "Punch out ";
                    break;
                }
            case 5:
                {
                    weapon_name += "Healing ";
                    break;
                }
            case 6:
                {
                    weapon_name += "Payback ";
                    break;
                }
            case 7:
                {
                    weapon_name += "QuickPace ";
                    break;
                }
            case 8:
                {
                    weapon_name += "Flyer ";
                    break;
                }
            case 9:
                {
                    weapon_name += "Tracer ";
                    break;
                }
        }

        ElementalType(Random.Range(0,6));

    }
    void ElementalType(int ET)
    {
        ///TYPE
        /// 0 - Normal - None
        /// 1 - Ice - Slow down hit enemy
        /// 2 - Fire - passive damage on hit enemy
        /// 3 - Acid - create smoke on hit enemy that damage nearby enemy and yourself
        /// 4 - Holy - x2 for dark enemy
        /// 5 - Dark - x2 for light enemy
        the_Element_Type = ET;

        //Set Element type
        switch (ET)
        {
            case 0:
                {
                    break;
                }
            case 1:
                {
                    weapon_name += "Ice ";
                    break;
                }
            case 2:
                {
                    weapon_name += "Fire ";
                    break;
                }
            case 3:
                {
                    weapon_name += "Acid ";
                    break;
                }
            case 4:
                {
                    weapon_name += "Holy ";
                    break;
                }
            case 5:
                {
                    weapon_name += "Dark ";
                    break;
                }
        }

        CreateWeaponType();
    }
    void CreateWeaponType()
    {
        //Set up Weapon Type
        switch (the_Weapon_Type)
        {
            case 0:
                {
                    weapon_name += "Pistol ";
                    the_Weapon_Mode = 1;
                    break;
                }
            case 1: 
                {
                    weapon_name += "SubMachineGun ";
                    the_Weapon_Mode = 2;
                    break;
                }
            case 2:
                {
                    weapon_name += "Rifle ";
                    the_Weapon_Mode = 2;
                    break;
                }
            case 3:
                {
                    weapon_name += "Shotgun";
                    is_Shotgun = true;
                    the_Weapon_Mode = 1;
                    break;
                }
            case 4:
                {
                    weapon_name += "Double Barrel Shotgun";
                    is_Shotgun = true;
                    the_Weapon_Mode = 1;
                    break;
                }
            case 5:
                {
                    weapon_name += "MachineGun";
                    the_Weapon_Mode = 2;
                    break;
                }
            case 6:
                {
                    weapon_name += "Rocket";
                    is_Rocket = true;
                    the_Weapon_Mode = 1;
                    the_Round_Type = 1;
                    break;
                }
        }
        SpawnWeapon();
    }
    void SpawnWeapon()
    {
        GameObject GO = Instantiate(testObject, transform.position, transform.rotation);
        BaseGun NewWeapon = GO.GetComponent<BaseGun>();
        NewWeapon.reload_Time = reload_Time;
        NewWeapon.fire_Rate = fire_Rate;
        NewWeapon.gun_Total_Ammo = total_Ammo;
        NewWeapon.gun_Total_Mag_Capacity = mag_Capacity;
        NewWeapon.min_Damage = min_Damage;
        NewWeapon.max_Damage = max_Damage;
        NewWeapon.the_Weapon_Mode = the_Weapon_Mode;
        NewWeapon.the_Round_Type = the_Round_Type;
        NewWeapon.the_Element_Type = the_Element_Type;
        NewWeapon.weapon_Name = weapon_name;
        if (is_Shotgun)
        {
            NewWeapon.is_Shotgun = is_Shotgun;
        }
        if (is_Rocket)
        {
            NewWeapon.is_Rocket = is_Rocket;
        }
        //Reset special stats
        weapon_name = null;
        NewWeapon = null;
        is_Shotgun = false;
        is_Rocket = false;
    }
}
