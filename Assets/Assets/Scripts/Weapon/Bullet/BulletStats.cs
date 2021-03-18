﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStats : MonoBehaviour
{
    public float bullet_Speed;
    public int bullet_Damage;

    Rigidbody the_RB;


    //Round Type
    public int round_Type;

    //Element Type
    public int element_Type;

    private void Start()
    {
        the_RB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        the_RB.velocity = transform.forward * Time.deltaTime * bullet_Speed;
    }
    public void ElementType(int ET)
    {
        element_Type = ET;
    }

    void OnEnable()
    {
        Invoke("Destroy", 2.5f);//delete itself after a certain time has pass
    }
    void OnDisable()
    {
        CancelInvoke();
    }
    void Destroy()
    {
        bullet_Damage = 0;
        gameObject.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BaseEnemy>() != null)
        {
            other.GetComponent<BaseEnemy>().TakingDamage(bullet_Damage);
            //Set Element type
            ///TYPE
            /// 0 - Normal - None
            /// 1 - Ice - Slow down hit enemy
            /// 2 - Fire - passive damage on hit enemy
            /// 3 - Acid - create smoke on hit enemy that damage nearby enemy and yourself
            /// 4 - Holy - x2 for dark enemy
            /// 5 - Dark - x2 for light enemy
            /*if (element_Type != 0)
            {
                other.GetComponent<BaseEnemy>().debuff_Timer = 10;//set timer
                other.GetComponent<BaseEnemy>().currently_Elemental_Damage_Type = element_Type;
            }*/
            switch (element_Type)
            {
                case 0:
                    {
                        break;
                    }
                case 1:
                    {
                        other.GetComponent<BaseEnemy>().debuff_Timer = 10;//set timer
                        other.GetComponent<BaseEnemy>().currently_Elemental_Damage_Type = element_Type;
                        break;
                    }
                case 2:
                    {
                        other.GetComponent<BaseEnemy>().debuff_Timer = 10;//set timer
                        other.GetComponent<BaseEnemy>().currently_Elemental_Damage_Type = element_Type;
                        break;
                    }
                case 3:
                    {
                        break;
                    }
                case 4:
                    {
                        break;
                    }
                case 5:
                    {
                        break;
                    }
            }

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
            switch (round_Type)
            {
                case 0:
                    {
                        print("Normal");
                        other.GetComponent<BaseEnemy>().TakingDamage(bullet_Damage);
                        Destroy();
                        break;
                    }
                case 1:
                    {
                        print("Explosive");
                        other.GetComponent<BaseEnemy>().TakingDamage(bullet_Damage*1.25f);
                        other.GetComponent<Rigidbody>().AddExplosionForce(2.5f, transform.position, 1);
                        Destroy();
                        break;
                    }
                case 2:
                    {
                        print("Piercing");
                        other.GetComponent<BaseEnemy>().TakingDamage(bullet_Damage);
                        break;
                    }
                case 3:
                    {
                        print("Stunning");
                        other.GetComponent<BaseEnemy>().TakingDamage(bullet_Damage);
                        other.GetComponent<BaseEnemy>().debuff_Timer = 10;//set timer
                        other.GetComponent<BaseEnemy>().is_Stunned = true;
                        Destroy();
                        break;
                    }
                case 4:
                    {
                        print("Punch out");
                        other.GetComponent<BaseEnemy>().TakingDamage(bullet_Damage);
                        other.GetComponent<Rigidbody>().AddForce(-transform.forward * 5, ForceMode.Impulse);
                        Destroy();
                        break;
                    }
                case 5:
                    {
                        print("Healing");
                        other.GetComponent<BaseEnemy>().TakingDamage(bullet_Damage);
                        FindObjectOfType<PlayerManager>().health_Player += 5;
                        Destroy();
                        break;
                    }
                case 6:
                    {
                        print("Payback");
                        other.GetComponent<BaseEnemy>().TakingDamage(bullet_Damage);
                        FindObjectOfType<PlayerManager>().weapon_Inventory[FindObjectOfType<PlayerManager>().current_Weapon].gun_Total_Ammo ++;//Add 1 round to current total ammo
                        FindObjectOfType<PlayerUIHUD>().AmmoUpdate(FindObjectOfType<PlayerManager>().current_Weapon);
                        Destroy();
                        break;
                    }
                case 7:
                    {
                        print("QuickPace");
                        other.GetComponent<BaseEnemy>().TakingDamage(bullet_Damage);
                        PlayerManager PM = FindObjectOfType<PlayerManager>();
                        if (PM.speed_Movement <= (PM.the_Basic_Stats.speed*2))
                        {
                            PM.speed_Movement += (PM.the_Basic_Stats.speed / 10);
                            print("hit");
                        }
                        Destroy();
                        break;
                    }
                case 8:
                    {
                        print("Flyer");
                        other.GetComponent<BaseEnemy>().TakingDamage(bullet_Damage);
                        Destroy();
                        break;
                    }
                case 9:
                    {
                        print("Tracer");
                        other.GetComponent<BaseEnemy>().TakingDamage(bullet_Damage);
                        Destroy();
                        break;
                    }
            }
        }
    }
}
