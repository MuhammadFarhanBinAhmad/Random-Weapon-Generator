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

    public float unit_Charging_Time = 2;
    float unit_Current_Charging_Time;

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

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        agent.destination = check_Point[current_CheckPoint].transform.position;
        transform.LookAt(check_Point[current_CheckPoint].transform);
        CurrentTask();
    }
    void CurrentTask()
    {
        switch (current_UT)
        {
            case unit_Task.Patrolling:
                {
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

                            print("Patrolling");
                        }
                    }
                    else
                    {
                        current_UT = unit_Task.Attacking;
                    }
                    break;
                }
            case unit_Task.Attacking:
                {
                    if (the_PM != null)
                    {
                        agent.destination = the_PM.transform.position;
                        if (agent.remainingDistance >= agent.stoppingDistance)
                        {
                            transform.LookAt(the_PM.transform.position);
                            print("Attacking");
                        }
                        else
                        {
                            agent.speed = 0;
                            unit_Current_Charging_Time = unit_Charging_Time;
                            current_UT = unit_Task.ChargingAttack;
                            print("FinishAttacking");
                        }
                    }
                    else
                    {
                        the_PM = null;
                        agent.speed = the_EBS.unit_Speed;
                        current_UT = unit_Task.Patrolling;
                        print("Patrolling");
                    }
                    break;
                }
            case unit_Task.ChargingAttack:
                {
                    if (unit_Current_Charging_Time > 0)
                    {
                        unit_Current_Charging_Time -= Time.deltaTime;
                        print("Charging");
                    }
                    else if (unit_Current_Charging_Time < 0)
                    {
                        agent.speed = the_EBS.unit_Speed;
                        if (the_PM != null)
                        {
                            current_UT = unit_Task.Attacking;
                        }
                        else
                        {
                            current_UT = unit_Task.Patrolling;
                        }
                    }
                    break;
                }
        }

    }
}
