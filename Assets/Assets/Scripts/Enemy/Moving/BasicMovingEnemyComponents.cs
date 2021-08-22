using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicMovingEnemyComponents : EnemyRange
{

    public EnemyBasicStats the_EBS;
    NavMeshAgent agent;

    [Header("Patrolling Spot")]
    public List<Transform> check_Point = new List<Transform>();
    public int current_CheckPoint;

    [Header("Attack and Charging Stats")]
    Vector3 player_Pos;
    public float unit_Charging_Time = 2;
    public float unit_Current_Charging_Time;

    enum unit_Task
    {
        Patrolling,
        Attacking,
        ChargingAttack
    }
    unit_Task current_UT;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.speed = the_EBS.unit_Speed;
        unit_Current_Charging_Time = unit_Charging_Time;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CurrentTask();
    }
    void CurrentTask()
    {
        switch (current_UT)
        {
            case unit_Task.Patrolling:
                {
                    if (agent.speed < the_EBS.unit_Speed)
                    {
                        agent.speed = the_EBS.unit_Speed;
                    }
                    if (the_PM == null)
                    {
                        {
                            if (agent.remainingDistance <= agent.stoppingDistance)
                            {
                                if (current_CheckPoint > check_Point.Count - 1)
                                {
                                    current_CheckPoint = 0;
                                }
                                else
                                {
                                    current_CheckPoint++;
                                }
                            }
                            agent.destination = check_Point[current_CheckPoint].transform.position;
                            transform.LookAt(check_Point[current_CheckPoint].transform);
                            print("Patrolling");
                        }
                    }
                    else
                    {
                        current_UT = unit_Task.ChargingAttack;
                        agent.isStopped = true;
                    }
                    break;
                }
            case unit_Task.ChargingAttack:
                {
                    print("Charging");
                    if (unit_Current_Charging_Time >= 0)
                    {
                        unit_Current_Charging_Time -= Time.deltaTime;
                    }
                    else if (unit_Current_Charging_Time <= 0)
                    {
                        if (the_PM != null)
                        {
                            agent.isStopped = false;
                            player_Pos = the_PM.transform.position;
                            current_UT = unit_Task.Attacking;
                        }
                        else
                        {
                            agent.isStopped = false;
                            unit_Current_Charging_Time = unit_Charging_Time;
                            current_UT = unit_Task.Patrolling;
                        }
                    }
                    break;
                }
            case unit_Task.Attacking:
                {
                    if (the_PM != null)
                    {
                        print("Attacking");
                        transform.LookAt(player_Pos);
                        agent.speed = the_EBS.unit_Speed * 2;
                        agent.destination = player_Pos;
                        if (agent.remainingDistance <= agent.stoppingDistance)
                        {
                            agent.speed = 0;
                            unit_Current_Charging_Time = unit_Charging_Time;
                            current_UT = unit_Task.ChargingAttack;
                        }

                        /*agent.destination = the_PM.transform.position;
                        if (agent.remainingDistance >= agent.stoppingDistance)
                        {
                            transform.LookAt(the_PM.transform.position);
                        }
                        else
                        {
                            //agent.speed = 0;
                            unit_Current_Charging_Time = unit_Charging_Time;
                            current_UT = unit_Task.ChargingAttack;
                        }*/
                    }
                    else
                    {
                        the_PM = null;
                        agent.speed = the_EBS.unit_Speed;
                        unit_Current_Charging_Time = unit_Charging_Time;
                        current_UT = unit_Task.Patrolling;
                    }
                    break;
                }

        }

    }
}
