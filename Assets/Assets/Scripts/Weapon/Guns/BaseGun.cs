using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGun : MonoBehaviour
{

    //UI
    PlayerManager the_Player_Manager;
    public PlayerUIHUD the_Player_UI_HUD;
    //
    AmmoPool the_Ammo_Pool;
    //STATS

    public string weapon_Name;

    //TYPE//
    /// <Type of mode>
    /// 1 - Single
    /// 2 - Auto
    /// </summary>
    internal int the_Weapon_Mode;

    ///*Weapon(For Shotgun only)
    internal bool is_Shotgun;


    /// <Type of Round>
    /// 1 - Explosive
    /// 2 - Piercing
    /// 
    public int the_Round_Type;
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

    public int the_Element_Type;

    public int gun_Total_Mag_Capacity, gun_Total_Ammo;
    public int gun_current_Mag_Capacity, gun_current_Ammo;

    int i = 1;

    bool currently_Shooting;
    bool currently_Reloading;

    public float fire_Rate;
    public float next_Time_To_Fire = 0;
    public float reload_Time;

    public int min_Damage, max_Damage;
    //

    public GameObject bullet;
    public Transform bullet_Spawn_Point;
    
    internal bool weapon_Eqip;

    private void Start()
    {
        this.name = weapon_Name;
    }

    private void Update()
    {
        if (weapon_Eqip)
        {
            WeaponMode();
            if (gun_current_Mag_Capacity < gun_Total_Mag_Capacity && Input.GetKeyDown(KeyCode.R) && !currently_Reloading && gun_Total_Ammo > 0)
            {
                StartReloading();
            }
        }
    }
    public void SetValue()
    {
        //ammo pool
        the_Player_Manager = FindObjectOfType<PlayerManager>();
        the_Ammo_Pool = FindObjectOfType<AmmoPool>();

        gun_current_Mag_Capacity = gun_Total_Mag_Capacity;
        //set up Weapon UI
        the_Player_UI_HUD = FindObjectOfType<PlayerUIHUD>();
        the_Player_UI_HUD.current_Weapon = this;
        the_Player_UI_HUD.AmmoUpdate(the_Player_Manager.current_Weapon);
        the_Player_UI_HUD.WeaponNameUpdate(the_Player_Manager.current_Weapon);
    }
    void WeaponMode()
    {
        //diffent weapon setting
        switch (the_Weapon_Mode)
        {
            case 1:
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        ShootGun();
                    }
                }
                break;
            case 2:
                {
                    if (Input.GetMouseButton(0) && Time.time >= next_Time_To_Fire )
                    {
                        ShootGun();
                        next_Time_To_Fire = Time.time + 1f / fire_Rate;
                    }
                }
                break;
            case 3:
                {
                    if (Input.GetMouseButtonDown(0) && !currently_Shooting)
                    {
                        StartCoroutine("NextShot");
                        currently_Shooting = true;

                    }
                }
                break;
        }
    }

    //BURST MODE ONLY
    IEnumerator NextShot()
    {
        if (i <= 3)
        {
            ShootGun();
            i++;
            yield return new WaitForSeconds(.15f);
            StartCoroutine("NextShot");
        }
        else
        {
            i = 1;
            currently_Shooting = false;
        }
    }

    //Reloading Weapon//
    void StartReloading()
    {
            StartCoroutine("Reloading");
            currently_Reloading = true;
    }
    IEnumerator Reloading()
    {
        if (!is_Shotgun)
        {
            yield return new WaitForSeconds(reload_Time);
            //count how many ammo spent
            int AU = gun_Total_Mag_Capacity - gun_current_Mag_Capacity;
            gun_Total_Ammo -= AU;
            gun_current_Mag_Capacity = gun_Total_Mag_Capacity;//Refill mag
            the_Player_UI_HUD.AmmoUpdate(the_Player_Manager.current_Weapon);//Update UI
            currently_Reloading = false;
        }
        else
        {
            if (gun_current_Mag_Capacity < gun_Total_Mag_Capacity)
            {
                yield return new WaitForSeconds(reload_Time);
                //count how many ammo spent
                gun_Total_Ammo--;
                gun_current_Mag_Capacity++;
                the_Player_UI_HUD.AmmoUpdate(the_Player_Manager.current_Weapon);//Update UI
                StartCoroutine("Reloading");
            }
            else
            {
                currently_Reloading = false;
            }
        }

    }

    void ShootGun()
    {
        //Stop all reloading
        StopCoroutine("Reloading");
        currently_Reloading = false;

        if (gun_current_Mag_Capacity > 0)
        {
            if (!is_Shotgun)
            {
                for (int i = 0; i < the_Ammo_Pool.bullet_Pool.Count; i++)
                {
                    if (!the_Ammo_Pool.bullet_Pool[i].activeInHierarchy)
                    {
                        the_Ammo_Pool.bullet_Pool[i].transform.position = bullet_Spawn_Point.transform.position;
                        the_Ammo_Pool.bullet_Pool[i].transform.rotation = bullet_Spawn_Point.transform.rotation;
                        the_Ammo_Pool.bullet_Pool[i].SetActive(true);
                        the_Ammo_Pool.bullet_Pool[i].GetComponent<BulletStats>().bullet_Damage = Random.Range(min_Damage, max_Damage);//get damage value
                        the_Ammo_Pool.bullet_Pool[i].GetComponent<BulletStats>().round_Type = the_Round_Type;//set bullet type
                        the_Ammo_Pool.bullet_Pool[i].GetComponent<BulletStats>().ElementType(the_Element_Type);//set bullet type

                        //update Weapon UI
                        gun_current_Mag_Capacity--;
                        the_Player_UI_HUD.AmmoUpdate(the_Player_Manager.current_Weapon);
                        break;
                    }
                }
            }
            // For ShotGun
            else
            {
                for (int SB = 0; SB <= 10; SB++)//spawn multiple rounds
                {
                    for (int i = 0; i < the_Ammo_Pool.bullet_Pool.Count; i++)
                    {
                        if (!the_Ammo_Pool.bullet_Pool[i].activeInHierarchy)
                        {
                            float r_x = Random.Range(-5, 5);
                            float r_y = Random.Range(-5, 5);

                            the_Ammo_Pool.bullet_Pool[i].transform.position = bullet_Spawn_Point.transform.position;

                            //round spread
                            Quaternion q = Quaternion.Euler
                                (bullet_Spawn_Point.transform.eulerAngles.x + r_x,
                                bullet_Spawn_Point.transform.eulerAngles.y + r_y,
                                bullet_Spawn_Point.transform.eulerAngles.z);
                            the_Ammo_Pool.bullet_Pool[i].transform.rotation = q;

                            the_Ammo_Pool.bullet_Pool[i].SetActive(true);
                            the_Ammo_Pool.bullet_Pool[i].GetComponent<BulletStats>().bullet_Damage = Random.Range(min_Damage, max_Damage);//get damage value
                            the_Ammo_Pool.bullet_Pool[i].GetComponent<BulletStats>().round_Type = the_Round_Type;//set bullet type
                            the_Ammo_Pool.bullet_Pool[i].GetComponent<BulletStats>().ElementType(the_Element_Type);//set bullet type

                            //update Weapon UI
                            break;
                        }
                    }
                }
                gun_current_Mag_Capacity--;
                the_Player_UI_HUD.AmmoUpdate(the_Player_Manager.current_Weapon);
            }
        }
    }
}
