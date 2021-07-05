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
    //NAME//
    public string weapon_name;

    //Weapon Part//
    //public List<GameObject> W_body = new List<GameObject>();
    [Header("Weapon Body")]
    public List<GameObject> b_pistol = new List<GameObject>();
    public List<GameObject> b_submachinegun = new List<GameObject>();
    public List<GameObject> b_rifle = new List<GameObject>();
    public List<GameObject> b_shotgun = new List<GameObject>();
    public List<GameObject> b_doublebarrelshotgun = new List<GameObject>();
    public List<GameObject> b_machinegun = new List<GameObject>();

    [Header("Weapon unlockables")]
    public List<bool> weapon_Unlock = new List<bool>();
    public List<bool> round_Unlock = new List<bool>();
    public List<bool> element_Unlock = new List<bool>();

    public GameObject w_Spawn_Point;
    GUNINATORGunCreation the_GUNINATORGunCreation;
    int the_Weapon_Body_Number;
    GameObject the_Weapon_Body_GO;
    //Stats//
    //TYPE//
    /// <Type of mode>
    /// 1 - Single
    /// 2 - Auto
    /// </summary>
    /// 
    internal int the_Weapon_Type;
    internal int the_Weapon_Mode;
    internal int the_Weapon_Rarity;
    internal int the_Round_Type;
    internal int the_Element_Type;

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

    //public GameObject testObject;
    private void Start()
    {
        the_GUNINATORGunCreation = GetComponent<GUNINATORGunCreation>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
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
    internal void CreateWeaponStats(int WT)
    {
        //the_Weapon_Body_Number
        //Set up Stats base on weapon type and rarity
        //1st case:Weapon Type
        //2nd case:Rarity
        switch (the_Weapon_Type)
        {
            //PISTOL
            case 0:
                {
                    the_Weapon_Body_Number = Random.Range(0, b_pistol.Count);
                    the_Weapon_Body_GO = b_pistol[the_Weapon_Body_Number];
                    switch (the_Weapon_Rarity)
                    {
                        //Rarity
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
                                reload_Time = 1;
                                fire_Rate = 1;
                                total_Ammo = 100;
                                mag_Capacity = 10;
                                min_Damage = 25;
                                max_Damage = 35;
                                break;
                            }
                        case 2:
                            {
                                reload_Time = 1;
                                fire_Rate = 1;
                                total_Ammo = 100;
                                mag_Capacity = 10;
                                min_Damage = 40;
                                max_Damage = 55;
                                break;
                            }
                        case 3:
                            {
                                reload_Time = 1;
                                fire_Rate = 1;
                                total_Ammo = 100;
                                mag_Capacity = 10;
                                min_Damage = 60;
                                max_Damage = 80;
                                break;
                            }
                        case 4:
                            {
                                reload_Time = 1;
                                fire_Rate = 1;
                                total_Ammo = 100;
                                mag_Capacity = 10;
                                min_Damage = 100;
                                max_Damage = 125;
                                break;
                            }

                    }
                    break;
                }
            //SMG
            case 1:
                {
                    the_Weapon_Body_Number = Random.Range(0, b_submachinegun.Count);
                    the_Weapon_Body_GO = b_submachinegun[the_Weapon_Body_Number];
                    switch (the_Weapon_Rarity)
                    {
                        case 0:
                            {

                                reload_Time = 1.25f;
                                fire_Rate = 8f;
                                total_Ammo = 250;
                                mag_Capacity = 25;
                                min_Damage = 5;
                                max_Damage = 15;
                                break;
                            }
                        case 1:
                            {

                                reload_Time = 1.25f;
                                fire_Rate = 8f;
                                total_Ammo = 250;
                                mag_Capacity = 25;
                                min_Damage = 20;
                                max_Damage = 35;
                                break;
                            }
                        case 2:
                            {

                                reload_Time = 1.25f;
                                fire_Rate = 8f;
                                total_Ammo = 250;
                                mag_Capacity = 25;
                                min_Damage = 40;
                                max_Damage = 55;
                                break;
                            }
                        case 3:
                            {

                                reload_Time = 1.25f;
                                fire_Rate = 8f;
                                total_Ammo = 250;
                                mag_Capacity = 25;
                                min_Damage = 60;
                                max_Damage = 75;
                                break;
                            }
                        case 4:
                            {

                                reload_Time = 1.25f;
                                fire_Rate = 8f;
                                total_Ammo = 250;
                                mag_Capacity = 25;
                                min_Damage = 80;
                                max_Damage = 100;
                                break;
                            }
                    }
                    break;
                }
            //Rifle
            case 2:
                {
                    the_Weapon_Body_Number = Random.Range(0, b_rifle.Count);
                    the_Weapon_Body_GO = b_rifle[the_Weapon_Body_Number];
                    switch (the_Weapon_Rarity)
                    {
                        case 0:
                            {
                                reload_Time = 1.25f;
                                fire_Rate = 6f;
                                total_Ammo = 300;
                                mag_Capacity = 30;
                                min_Damage = 40;
                                max_Damage = 55;
                                break;
                            }
                        case 1:
                            {
                                reload_Time = 1.25f;
                                fire_Rate = 6f;
                                total_Ammo = 300;
                                mag_Capacity = 30;
                                min_Damage = 60;
                                max_Damage = 75;
                                break;
                            }
                        case 2:
                            {
                                reload_Time = 1.25f;
                                fire_Rate = 6f;
                                total_Ammo = 300;
                                mag_Capacity = 30;
                                min_Damage = 80;
                                max_Damage = 95;
                                break;
                            }
                        case 3:
                            {
                                reload_Time = 1.25f;
                                fire_Rate = 6f;
                                total_Ammo = 300;
                                mag_Capacity = 30;
                                min_Damage = 100;
                                max_Damage = 125;
                                break;
                            }
                        case 4:
                            {
                                reload_Time = 1.25f;
                                fire_Rate = 6f;
                                total_Ammo = 300;
                                mag_Capacity = 30;
                                min_Damage = 130;
                                max_Damage = 150;
                                break;
                            }
                    }
                    break;
                }
            //SHOTGUN
            case 3:
                {
                    the_Weapon_Body_Number = Random.Range(0, b_shotgun.Count);
                    the_Weapon_Body_GO = b_shotgun[the_Weapon_Body_Number];
                    switch (the_Weapon_Rarity)
                    {
                        case 0:
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
                        case 1:
                            {
                                reload_Time = .75f;
                                fire_Rate = .7f;
                                total_Ammo = 80;
                                mag_Capacity = 8;
                                min_Damage = 25;
                                max_Damage = 35;
                                rounds_Shot = 10;
                                break;
                            }
                        case 2:
                            {
                                reload_Time = .75f;
                                fire_Rate = .7f;
                                total_Ammo = 80;
                                mag_Capacity = 8;
                                min_Damage = 40;
                                max_Damage = 60;
                                rounds_Shot = 10;
                                break;
                            }
                        case 3:
                            {
                                reload_Time = .75f;
                                fire_Rate = .7f;
                                total_Ammo = 80;
                                mag_Capacity = 8;
                                min_Damage = 10;
                                max_Damage = 65;
                                rounds_Shot = 75;
                                break;
                            }
                        case 4:
                            {
                                reload_Time = .75f;
                                fire_Rate = .7f;
                                total_Ammo = 80;
                                mag_Capacity = 8;
                                min_Damage = 10;
                                max_Damage = 80;
                                rounds_Shot = 105;
                                break;
                            }
                    }
                    break;
                }
            //DOUBLE BARREL SHOTGUN
            case 4:
                {
                    the_Weapon_Body_Number = Random.Range(0, b_doublebarrelshotgun.Count);
                    the_Weapon_Body_GO = b_doublebarrelshotgun[the_Weapon_Body_Number];
                    switch (the_Weapon_Rarity)
                    {
                        case 0:
                            {
                                reload_Time = .75f;
                                fire_Rate = .7f;
                                total_Ammo = 40;
                                mag_Capacity = 2;
                                min_Damage = 15;
                                max_Damage = 25;
                                rounds_Shot = 30;
                                break;
                            }
                        case 1:
                            {
                                reload_Time = .75f;
                                fire_Rate = .7f;
                                total_Ammo = 40;
                                mag_Capacity = 2;
                                min_Damage = 30;
                                max_Damage = 40;
                                rounds_Shot = 30;
                                break;
                            }
                        case 2:
                            {
                                reload_Time = .75f;
                                fire_Rate = .7f;
                                total_Ammo = 40;
                                mag_Capacity = 2;
                                min_Damage = 45;
                                max_Damage = 55;
                                rounds_Shot = 30;
                                break;
                            }
                        case 3:
                            {
                                reload_Time = .75f;
                                fire_Rate = .7f;
                                total_Ammo = 40;
                                mag_Capacity = 2;
                                min_Damage = 60;
                                max_Damage = 75;
                                rounds_Shot = 30;
                                break;
                            }
                        case 4:
                            {
                                reload_Time = .75f;
                                fire_Rate = .7f;
                                total_Ammo = 40;
                                mag_Capacity = 2;
                                min_Damage = 80;
                                max_Damage = 100;
                                rounds_Shot = 30;
                                break;
                            }
                    }
                    break;
                }
            //MACHINEGUN
            case 5:
                {
                    the_Weapon_Body_Number = Random.Range(0, b_machinegun.Count);
                    the_Weapon_Body_GO = b_machinegun[the_Weapon_Body_Number];
                    switch (the_Weapon_Rarity)
                    {
                        case 0:
                            {
                                reload_Time = 1.5f;
                                fire_Rate = 6f;
                                total_Ammo = 400;
                                mag_Capacity = 100;
                                min_Damage = 25;
                                max_Damage = 35;
                                break;
                            }
                        case 1:
                            {
                                reload_Time = 1.5f;
                                fire_Rate = 6f;
                                total_Ammo = 400;
                                mag_Capacity = 100;
                                min_Damage = 40;
                                max_Damage = 60;
                                break;
                            }
                        case 2:
                            {
                                reload_Time = 1.5f;
                                fire_Rate = 6f;
                                total_Ammo = 400;
                                mag_Capacity = 100;
                                min_Damage = 65;
                                max_Damage = 80;
                                break;
                            }
                        case 3:
                            {
                                reload_Time = 1.5f;
                                fire_Rate = 6f;
                                total_Ammo = 400;
                                mag_Capacity = 100;
                                min_Damage = 90;
                                max_Damage = 100;
                                break;
                            }
                        case 4:
                            {
                                reload_Time = 1.5f;
                                fire_Rate = 6f;
                                total_Ammo = 400;
                                mag_Capacity = 100;
                                min_Damage = 105;
                                max_Damage = 130;
                                break;
                            }
                    }
                    break;
                }
            //ROCKET
            case 6:
                {
                    switch (the_Weapon_Rarity)
                    {
                        case 0:
                            {
                                reload_Time = 1.5f;
                                fire_Rate = 1;
                                total_Ammo = 10;
                                mag_Capacity = 1;
                                min_Damage = 150;
                                max_Damage = 300;
                                break;
                            }
                        case 1:
                            {
                                reload_Time = 1.5f;
                                fire_Rate = 1;
                                total_Ammo = 10;
                                mag_Capacity = 1;
                                min_Damage = 400;
                                max_Damage = 550;
                                break;
                            }
                        case 2:
                            {
                                reload_Time = 1.5f;
                                fire_Rate = 1;
                                total_Ammo = 10;
                                mag_Capacity = 1;
                                min_Damage = 575;
                                max_Damage = 650;
                                break;
                            }
                        case 3:
                            {
                                reload_Time = 1.5f;
                                fire_Rate = 1;
                                total_Ammo = 10;
                                mag_Capacity = 1;
                                min_Damage = 700;
                                max_Damage = 850;
                                break;
                            }
                        case 4:
                            {
                                reload_Time = 1.5f;
                                fire_Rate = 1;
                                total_Ammo = 10;
                                mag_Capacity = 1;
                                min_Damage = 950;
                                max_Damage = 1200;
                                break;
                            }
                    }
                    break;
                }
        }
        if (weapon_Unlock[the_Weapon_Type])
        {
            if (the_Weapon_Type != 6)
            {
                RoundType(the_Round_Type);//excluding rocket
            }
            else
            {
                ElementalType(the_Element_Type);//for rocket 
            }
        }
        else
        {
            print("Weapon lock");
        }
    }
    void RoundType(int RT)
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
        /// 8 - Flyer - Make Player jump higher*Remove
        /// 9 - Tracer - Home to the nearest enemy*Remove
        the_Round_Type = RT;

        //Set Ammo type
        switch(RT)
        {
            case 0:
                {
                    break;
                }
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
                    weapon_name += "Healing ";
                    break;
                }
            case 5:
                {
                    weapon_name += "Payback ";
                    break;
                }
            case 6:
                {
                    weapon_name += "QuickPace ";
                    break;
                }
        }
        if (round_Unlock[the_Round_Type])
        {
            ElementalType(the_Element_Type);
        }
        else
        {
            print("round lock");
        }

    }
    void ElementalType(int ET)
    {
        /// <Type of Element>
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
        }
        if (element_Unlock[the_Element_Type])
        {
            CreateWeaponType();
        }
        else
        {
            print("Element lock");
        }
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
                    weapon_name += "Assault Rifle ";
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
        FindObjectOfType<PlayerManager>().money_Total -= the_GUNINATORGunCreation.w_Total_Cost;
        GameObject GO = Instantiate(the_Weapon_Body_GO, w_Spawn_Point.transform.position, w_Spawn_Point.transform.rotation);
        BaseGun NewWeapon = GO.GetComponent<BaseGun>();
        NewWeapon.reload_Time = reload_Time;
        NewWeapon.fire_Rate = fire_Rate;
        NewWeapon.gun_Total_Ammo = total_Ammo;
        NewWeapon.gun_Total_Mag_Capacity = mag_Capacity;
        NewWeapon.min_Damage = min_Damage;
        NewWeapon.max_Damage = max_Damage;
        NewWeapon.the_Weapon_Type = the_Weapon_Type;
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
