using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseEnemy : MonoBehaviour
{

    public EnemyBasicStats the_Enemy_Stats;

    public float speed, health, damage;

    public int currently_Elemental_Damage_Type;


    //Effects
    public bool is_Stunned;

    public float debuff_Rate = 1;
    public float next_Time_To_Debuff = 0;
    public float debuff_Timer;

    NavMeshAgent agent;

    void Start()
    {
        speed = the_Enemy_Stats.speed;
        health = the_Enemy_Stats.health;
        damage = the_Enemy_Stats.damage;

        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    void FixedUpdate()
    {
        if (debuff_Timer > 0)
        {
            debuff_Timer -= Time.deltaTime;
            ElementalDamageTimer();//reset to avoid unwanted damage
        }
        else
        {
            print("hit2");
            RemoveDebuff();
        }
    }

    public void ElementalDamageTimer()
    {
        //Take damage every sec due to elemental effect
        if (Time.time >= next_Time_To_Debuff)
        {
            next_Time_To_Debuff = Time.time + 1f / debuff_Rate;
            TakingElementalDamage(currently_Elemental_Damage_Type);
        }
    }

    ///TYPE
    /// 0 - Normal - None
    /// 1 - Ice - Slow down hit enemy
    /// 2 - Fire - passive damage on hit enemy
    /// 3 - Acid - create smoke on hit enemy that damage nearby enemy and yourself
    /// 4 - Holy - x2 for dark enemy
    /// 5 - Dark - x2 for light enemy
    public void TakingElementalDamage(int ET)
    {
        print("hit");
        switch (ET)
        {
            
            case 1:
                {
                    print("ice");
                    agent.speed /= 2;
                    break;
                }
            case 2:
                {
                    TakingDamage((10));
                    break;
                }
            case 3:
                {

                    break;
                }
        }

    }

    void RemoveDebuff()
    {
        print("normal");
        is_Stunned = false;
        agent.speed = the_Enemy_Stats.speed;
    }

    public void TakingDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


}
