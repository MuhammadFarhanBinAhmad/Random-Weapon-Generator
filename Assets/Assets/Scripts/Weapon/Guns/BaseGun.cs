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
    [Header("Weapon features")]
    //TYPE//
    public int the_Weapon_Mode;
    internal int the_Weapon_Type;

    ///*Weapon(For Special Weapon only)
    public bool is_Shotgun;
    public bool is_Rocket;

    public int the_Round_Type;

    public int the_Element_Type;
    [Header("Ammo")]
    public int gun_Total_Mag_Capacity, gun_Total_Ammo;
    public int gun_current_Mag_Capacity, gun_current_Ammo;

    int i = 1;
    [Header("Current state")]
    bool currently_Shooting;
    bool currently_Reloading;
    [Header("Rate & Reload")]
    public float fire_Rate;
    public float next_Time_To_Fire = 0;
    public float reload_Time;
    [Header("Damage")]
    public int min_Damage, max_Damage;

    [Header("Barrel & Bullet")]
    public GameObject bullet;
    public GameObject barrel;
    public Transform bullet_Spawn_Point;

    [Header("SFX & VFX")]

    public GameObject muzzle_Flash;
    public List<AudioClip> weapon_Shoot_Sound = new List<AudioClip>();
    public AudioSource weapon_AudioSource;

    internal bool weapon_Eqip;

    private void Start()
    {
        this.name = weapon_Name;
        //Set Weapon pickup boxcollider
        BoxCollider BC = gameObject.AddComponent<BoxCollider>();
        float bc_X = BC.size.x;
        float bc_Y = BC.size.y;
        float bc_Z = BC.size.x;
        BC.size = new Vector3(bc_X * 1.25f, bc_Y * 2f, bc_Z * 1.25f);
        BC.isTrigger = true;

        weapon_AudioSource.clip = weapon_Shoot_Sound[the_Weapon_Type];

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (bullet_Spawn_Point == null)
            {
                barrel = gameObject.transform.GetChild(0).gameObject;
                bullet_Spawn_Point = barrel.transform.GetChild(0).GetChild(0);
            }
        }
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
        if (bullet_Spawn_Point == null)
        {
            barrel = gameObject.transform.GetChild(0).gameObject;
            bullet_Spawn_Point = barrel.transform.GetChild(0).GetChild(0);
            muzzle_Flash = barrel.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        }
        if (bullet_Spawn_Point == null)
        {
            bullet_Spawn_Point = gameObject.transform.GetChild(0).Find("BulletSpawn");
        }
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
                        the_Ammo_Pool.bullet_Pool[i].GetComponent<BulletStats>().is_Rocket = is_Rocket;
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
                muzzle_Flash.GetComponent<ParticleSystem>().Play();
                gun_current_Mag_Capacity--;
                the_Player_UI_HUD.AmmoUpdate(the_Player_Manager.current_Weapon);
            }
        }
    }
}
