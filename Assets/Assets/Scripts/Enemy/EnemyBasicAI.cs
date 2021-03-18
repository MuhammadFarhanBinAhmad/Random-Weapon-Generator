using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBasicAI : MonoBehaviour
{

    public List<Transform> check_Point = new List<Transform>();
    public int current_CheckPoint;

    public NavMeshAgent agent;

    BaseEnemy the_BE;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        the_BE = GetComponent<BaseEnemy>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!the_BE.is_Stunned)
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
        }
        else
        {
            if(the_BE.is_Stunned)
            {
                agent.speed = 0;
            }
        }

    }
}
