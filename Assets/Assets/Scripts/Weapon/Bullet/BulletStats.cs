using System.Collections;
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
    public GameObject acid_Smoke,small_Explosion,large_Explosion;
    //For Rocket Only
    public bool is_Rocket;

    public LayerMask Weapon_Layer;


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
    internal void Destroy()
    {
        bullet_Damage = 0;
        gameObject.SetActive(false);
    }
    /// <summary>
    /// *NOTE: IGNORE ALL THIS, THIS ALL IS OUTDATED
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (tag == "HurtEnemy")
        {
            if (other.GetComponent<BaseEnemy>() != null)
            {
                //other.GetComponent<BaseEnemy>().TakingDamage(bullet_Damage);
                //Set Element type

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
                            other.GetComponent<BaseEnemy>().debuff_Timer = 10;//set timer
                            GameObject AS = Instantiate(acid_Smoke, transform.localPosition, transform.rotation);//spawn acid smoke
                            AS.transform.parent = other.transform;//acid stick to enemy
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

                            if (!is_Rocket)
                            {
                                print("Explosive");
                                other.GetComponent<BaseEnemy>().TakingDamage(bullet_Damage * 1.25f);
                                //other.GetComponent<Rigidbody>().AddExplosionForce(2.5f, transform.position, 1);
                                Destroy();
                            }
                            //For Rocket
                            else
                            {
                                print("Rocket");
                                other.GetComponent<BaseEnemy>().TakingDamage(bullet_Damage);
                                GameObject REE = Instantiate(large_Explosion, transform.position, transform.rotation);//Rocket Explosion
                                REE.GetComponent<ElementalRocket>().element_Type = element_Type;
                                //other.GetComponent<Rigidbody>().AddExplosionForce(1000, transform.position, 2);
                                Destroy();
                            }
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
                            FindObjectOfType<PlayerManager>().weapon_Inventory[FindObjectOfType<PlayerManager>().current_Weapon].gun_Total_Ammo++;//Add 1 round to current total ammo
                            FindObjectOfType<PlayerUIHUD>().AmmoUpdate(FindObjectOfType<PlayerManager>().current_Weapon);
                            Destroy();
                            break;
                        }
                    case 7:
                        {
                            print("QuickPace");
                            other.GetComponent<BaseEnemy>().TakingDamage(bullet_Damage);
                            PlayerManager PM = FindObjectOfType<PlayerManager>();
                            if (PM.speed_Movement <= (PM.the_Basic_Stats.speed * 2))
                            {
                                PM.speed_Movement += (PM.the_Basic_Stats.speed / 10);
                                print("hit");
                            }
                            Destroy();
                            break;
                        }
                }
            }
            /*if (other.GetComponent<PlayerManager>() != null)
            {
                other.GetComponent<PlayerManager>().TakeDamage(10);
            }*/
            //this is not very efficient
            if (other.gameObject.layer == LayerMask.NameToLayer("Ground") || other.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                if (is_Rocket)
                {
                    GameObject REE = Instantiate(large_Explosion, transform.position, transform.rotation);//Rocket Explosion
                    //REE.GetComponent<ElementalRocket>().element_Type = element_Type;
                    Destroy();
                }
                else if (round_Type == 1)
                {
                    GameObject REE = Instantiate(small_Explosion, transform.position, transform.rotation);//Rocket Explosion
                    Destroy();
                }
                else
                {
                    Destroy();
                }
            }
            else
            {
                Invoke("Destroy", 2.5f);
            }
        }
        if (tag == "HurtPlayer" && other.GetComponent<PlayerManager>())
        {
            FindObjectOfType<PlayerManager>().TakeDamage(bullet_Damage);
            Destroy();
        }
    }
}
