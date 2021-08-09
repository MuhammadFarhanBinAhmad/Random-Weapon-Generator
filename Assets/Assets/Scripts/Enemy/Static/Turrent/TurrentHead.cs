using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentHead : MonoBehaviour
{
    /// <summary>
    /// 0 - Scanning - turrent turning 360 degrees trying to find player
    /// 1 - Firing - player is spotted and engaging target
    /// 2 - Finding - lost sight of player and currerntly in high alert mode
    /// </summary>
    int current_Mode;

    [Header("Bullet Stats")]
    AmmoPool the_Ammo_Pool;
    public float fire_Rate;
    public Transform bullet_Spawn_Point;
    float next_Time_To_Fire = 0;
    [Header("Time and Target")]
    public float time_Before_Reset;
    public float timer;
    public bool target_Lock;
    Transform current_Target;

    public EnemyBasicStats the_EBS;
    public Light mode_Light;
    float t = 0;
    float min = 1f, max = 5f;

    private void Start()
    {
        the_Ammo_Pool = FindObjectOfType<AmmoPool>();
        timer = time_Before_Reset;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CurrentMode();
    }
    void CurrentMode()
    {
        //Scan area for player
        switch (current_Mode)
        {
            case 0:
                {
                    RaycastHit hit;

                    transform.Rotate(0, 1, 0);
                    if (timer < time_Before_Reset)
                    {
                        timer = time_Before_Reset;
                    }
                    if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
                    {
                        if (hit.transform.GetComponent<PlayerManager>() != null)
                        {
                            current_Target = hit.transform.GetComponent<PlayerManager>().transform;
                            current_Mode = 1;
                        }
                    }
                    break;
                }
            case 1:
                {
                    if (current_Target != null)
                    {
                        RaycastHit hit;

                        if (Physics.Raycast(transform.position, transform.forward, out hit, 250))
                        {
                            if (hit.transform.GetComponent<PlayerManager>() == null)
                            {
                                TargetLost();
                            }
                            else
                            {
                                TargetLock();
                            }
                        }
                    }

                    mode_Light.intensity = Mathf.Lerp(min, max, t);

                    t += .5f;

                    if (t > 4)

                    {
                        float temp = max;
                        max = min;
                        min = temp;
                        t = 0.0f;
                    }
                    break;
                }
        }
    }
    void TargetLock()
    {
        //target located and lock

        transform.LookAt(current_Target);
        timer = time_Before_Reset;//reset timer each time target is lock

        if (Time.time >= next_Time_To_Fire)
        {
            Shooting();
        }
    }
    void TargetLost()
    {
        //if no target is lock within a period of time, the turrent resets

        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            mode_Light.intensity = 1;
            current_Mode = 0;
        }
    }
    void Shooting()
    {
        {
            next_Time_To_Fire = Time.time + 1f / fire_Rate;
            for (int i = 0; i < the_Ammo_Pool.bullet_Pool.Count; i++)
            {
                if (!the_Ammo_Pool.bullet_Pool[i].activeInHierarchy)
                {
                    the_Ammo_Pool.bullet_Pool[i].transform.position = bullet_Spawn_Point.transform.position;
                    the_Ammo_Pool.bullet_Pool[i].transform.rotation = bullet_Spawn_Point.transform.rotation;
                    the_Ammo_Pool.bullet_Pool[i].SetActive(true);
                    the_Ammo_Pool.bullet_Pool[i].GetComponent<BulletStats>().bullet_Damage = the_EBS.unit_Damage;
                    the_Ammo_Pool.bullet_Pool[i].gameObject.tag = "HurtPlayer";
                    break;
                }
            }
        }
    }
}
