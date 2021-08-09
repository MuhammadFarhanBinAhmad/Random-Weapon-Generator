using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ForceFieldPlayerDetection : MonoBehaviour
{
    NavMeshAgent agent;
    BasicMovingEnemyComponents the_BMEC;

    public GameObject the_FF_GameObject;

    public float forcefield_Down_Timer;
    float forcefield_Timer;

    enum ForceFieldStatus
    {
        Patrolling,
        PlayerDetected,
        PlayerOutOfRange
    }

    ForceFieldStatus the_FFS;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        the_BMEC = GetComponent<BasicMovingEnemyComponents>();

        the_FF_GameObject.SetActive(false);
        forcefield_Timer = forcefield_Down_Timer;
    }

    private void FixedUpdate()
    {
        ShieldState();
    }
    void ShieldState()
    {
        switch (the_FFS)
        {
            case ForceFieldStatus.Patrolling:
                {
                    if (the_BMEC.the_PM != null)
                    {
                        the_FFS = ForceFieldStatus.PlayerDetected;
                    }
                    break;
                }
            case ForceFieldStatus.PlayerDetected:
                {
                    the_FF_GameObject.SetActive(true);
                    if (the_BMEC.the_PM == null)
                    {
                        the_FFS = ForceFieldStatus.PlayerOutOfRange;
                    }
                    break;
                }
            case ForceFieldStatus.PlayerOutOfRange:
                {
                    if (forcefield_Timer > 0)
                    {
                        forcefield_Timer -= Time.deltaTime;
                    }
                    else
                    {
                        the_FFS = ForceFieldStatus.Patrolling;
                        forcefield_Timer = forcefield_Down_Timer;
                        the_FF_GameObject.SetActive(false);
                    }
                    break;
                }
        }

    }
}
