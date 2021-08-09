using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldTimer : MonoBehaviour
{

    public GameObject the_FF_GameObject;

    public float forcefield_Time_Span;
    public float forcefield_up_Time;

    public float time_Recharge_Needed;
    public float time_Recharge;

    enum ForceFieldStatus
    {
        Activated,
        Recharging
    }

    ForceFieldStatus the_FFS;

    private void Start()
    {
        forcefield_up_Time = forcefield_Time_Span;
    }

    private void FixedUpdate()
    {
        ShieldState();
    }
    void ShieldState()
    {
        switch (the_FFS)
        {
            case ForceFieldStatus.Activated:
                {
                    if (forcefield_up_Time > 0)
                    {
                        forcefield_up_Time -= Time.deltaTime;
                    }
                    else
                    {
                        the_FF_GameObject.SetActive(false);
                        the_FFS = ForceFieldStatus.Recharging;
                    }
                    break;
                }
            case ForceFieldStatus.Recharging:
                {
                    if (time_Recharge < time_Recharge_Needed)
                    {
                        time_Recharge += Time.deltaTime;
                    }
                    else
                    {
                        forcefield_up_Time = forcefield_Time_Span;
                        the_FFS = ForceFieldStatus.Activated;
                        time_Recharge = 0;
                        the_FF_GameObject.SetActive(true);
                    }
                    break;
                }
        }

    }
}
